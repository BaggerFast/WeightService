using Ws.Domain.Models.Entities.Ref1c.Plus;
using Ws.Domain.Services.Features.Plus;

namespace DeviceControl.Source.Pages.References1C.Plus;

// ReSharper disable ClassNeverInstantiated.Global
public sealed partial class PlusPage : SectionDataGridPageBase<Plu>
{
    # region Injects

    [Inject] private IPluService PluService { get; set; } = default!;
    [Inject] private IStringLocalizer<ApplicationResources> Localizer { get; set; } = default!;
    [Inject] private IStringLocalizer<WsDataResources> WsDataLocalizer { get; set; } = default!;

    # endregion

    private HashSet<string?> BrandNames { get; set; } = [];
    private PluValidValidator PluValidator { get; } = new();

    private bool? IsWeightFilter { get; set; }
    private string? BrandFilter { get; set; }

    protected override async Task OpenDataGridEntityModal(Plu item)
        => await OpenSectionModal<PlusUpdateDialog>(item);

    protected override async Task OpenItemInNewTab(Plu item) =>
        await OpenLinkInNewTab($"{RouteUtils.SectionPlus}/{item.Uid.ToString()}");

    protected override IEnumerable<Plu> SetSqlSectionCast()
    {
        IList<Plu> data = PluService.GetAll();
        BrandNames =
        [
            ..data.Select(i => i.Brand.Name),
            null
        ];
        return data;
    }

    protected override IEnumerable<Plu> SetSqlSearchingCast()
    {
        Guid.TryParse(SearchingSectionItemId, out Guid itemUid);
        return [PluService.GetItemByUid(itemUid)];
    }
}