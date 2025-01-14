using System.Drawing;
using System.Text.RegularExpressions;
using BinaryKits.Zpl.Label.Elements;
using EasyCaching.Core;
using Ws.Domain.Models.Entities.Print;
using Ws.Domain.Services.Features.Templates;
using Ws.Domain.Services.Features.ZplResources;
using Ws.Labels.Service.Generate.Models.Cache;
using Ws.Labels.Service.Generate.Utils;
using Ws.Shared.Enums;

namespace Ws.Labels.Service.Generate.Services;

public partial class CacheService(
    ITemplateService templateService,
    IZplResourceService zplResourceService,
    IEasyCachingProvider easyCachingProvider,
    IRedisCachingProvider redisCachingProvider)
{
    [GeneratedRegex(",([^,]+),")]
    private static partial Regex MyRegex();

    public TemplateFromCache? GetTemplateByUidFromCacheOrDb(Guid templateUid)
    {
        string zplKey = $"TEMPLATES:{templateUid}";

        if (easyCachingProvider.Exists(zplKey))
            return easyCachingProvider.Get<TemplateFromCache>(zplKey).Value;

        Template temp = templateService.GetItemByUid(templateUid);
        if (!temp.IsExists || temp.Body == string.Empty) return null;

        TemplateFromCache tempFromCache = new(temp);

        easyCachingProvider.Set($"{zplKey}", tempFromCache, TimeSpan.FromHours(1));
        return tempFromCache;
    }

    public Dictionary<string, string> GetResourcesFromCacheOrDb(List<string> resourcesName, ushort rotate)
    {
        HashSet<string> resourceNameUniq = resourcesName.ToHashSet();
        Dictionary<string, string?> cached = redisCachingProvider
            .HMGet($"ZPL_RESOURCES:{rotate}", resourceNameUniq.ToList());

        bool allValuesNonNull = cached != null && cached.Values.All(value => value != null);

        if (allValuesNonNull)
            return cached!;

        cached = zplResourceService.GetAll().ToDictionary(
            i => $"{i.Name.ToLower()}_sql",
            i =>
            {
                if (i.Type == ZplResourceType.Text)
                    return i.Zpl;

                Bitmap resourceData = BitMapUtils.ReadSvg(i.Zpl, rotate);
                byte[] resourceBytes = BitMapUtils.ToMonochromeBytes(resourceData);
                ZplDownloadGraphics resourceZ64 = new('x', "x", resourceBytes, ZplCompressionScheme.Z64);
                string zpl = resourceZ64.ToZplString().Replace("~DGx:x.GRF", "").Replace("\n", "");

                Match match = MyRegex().Match(zpl);

                if (match.Success)
                {
                    string firstValue = match.Groups[1].Value;
                    zpl = $"^GFA,{firstValue}{zpl}";
                }
                else
                    throw new NotImplementedException();

                return zpl;
            })!;

        redisCachingProvider.HMSet($"ZPL_RESOURCES:{rotate}", cached, TimeSpan.FromHours(1));

        return cached!;
    }
}