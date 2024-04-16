using EasyCaching.Core;
using Ws.Database.Nhibernate.Entities.Ref.ZplResources;
using Ws.Domain.Models.Entities.Ref;
using Ws.Domain.Services.Aspects;
using Ws.Domain.Services.Features.ZplResource.Validators;

namespace Ws.Domain.Services.Features.ZplResource;

internal partial class ZplResourceService(SqlZplResourceRepository zplResourceRepo, IRedisCachingProvider provider)
    : IZplResourceService
{
    [Transactional]
    public ZplResourceEntity GetItemByUid(Guid uid) => zplResourceRepo.GetByUid(uid);

    [Transactional]
    public IEnumerable<ZplResourceEntity> GetAll() => zplResourceRepo.GetAll().ToList();

    [Transactional, Validate<ZplResourceNewValidator>]
    public ZplResourceEntity Create(ZplResourceEntity item) => UpdateCache(zplResourceRepo.Save(item));

    [Transactional, Validate<ZplResourceUpdateValidator>]
    public ZplResourceEntity Update(ZplResourceEntity item) => UpdateCache(zplResourceRepo.Update(item));

    [Transactional]
    public void Delete(ZplResourceEntity item)
    {
        zplResourceRepo.Delete(item);
        provider.HDel("ZPL_RESOURCES", [item.Name]);
    }

    [Transactional]
    public Dictionary<string, string> GetAllResourcesFromCacheOrDb()
    {
        Dictionary<string, string>? cached = provider.HGetAll("ZPL_RESOURCES");

        if (cached != null && cached.Any()) return cached;

        cached = zplResourceRepo.GetAll().ToDictionary(i => i.Name, i => i.Zpl);
        provider.HMSet("ZPL_RESOURCES", cached, TimeSpan.FromHours(1));

        return cached;
    }
}