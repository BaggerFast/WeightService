using DeviceControl.Source.Widgets.Section.Dialogs;
using Ws.Domain.Models.Entities.Ref;
using Ws.Domain.Services.Features.Warehouses;

namespace DeviceControl.Source.Pages.References.Warehouses;

// ReSharper disable ClassNeverInstantiated.Global
public sealed partial class WarehousesPage : SectionDataGridPageBase<Warehouse>
{
    #region Inject

    [Inject] private IStringLocalizer<ApplicationResources> Localizer { get; set; } = default!;
    [Inject] private IStringLocalizer<WsDataResources> WsDataLocalizer { get; set; } = default!;
    [Inject] private IWarehouseService WarehouseService { get; set; } = default!;

    #endregion

    [CascadingParameter] private ProductionSite UserProductionSite { get; set; } = default!;

    private ProductionSite ProductionSite { get; set; } = new();

    protected override void OnInitialized()
    {
        ProductionSite = UserProductionSite;
        base.OnInitialized();
    }

    protected override async Task OpenSectionCreateForm()
        => await DialogService.ShowDialogAsync<WarehousesCreateDialog>(
            new SectionDialogContentWithProductionSite<Warehouse> { Item = new(), ProductionSite = ProductionSite }
            , DialogParameters);

    protected override async Task OpenDataGridEntityModal(Warehouse item)
        => await OpenSectionModal<WarehousesUpdateDialog>(item);

    protected override async Task OpenItemInNewTab(Warehouse item)
        => await OpenLinkInNewTab($"{RouteUtils.SectionWarehouses}/{item.Uid.ToString()}");

    protected override IEnumerable<Warehouse> SetSqlSectionCast() =>
        ProductionSite.IsNew ? [] : WarehouseService.GetAllByProductionSite(ProductionSite);

    protected override IEnumerable<Warehouse> SetSqlSearchingCast()
    {
        Guid.TryParse(SearchingSectionItemId, out Guid itemUid);
        return [WarehouseService.GetItemByUid(itemUid)];
    }

    protected override Task DeleteItemAction(Warehouse item)
    {
        WarehouseService.DeleteById(item.Uid);
        return Task.CompletedTask;
    }
}