using Ws.Domain.Models.Entities.Ref;
using Ws.Domain.Services.Features.ProductionSites;

namespace DeviceControl.Source.Pages.References.ProductionSites;

public sealed partial class ProductionSitesCreateForm : SectionFormBase<ProductionSite>
{
    # region Injects

    [Inject] private IStringLocalizer<WsDataResources> WsDataLocalizer { get; set; } = default!;
    [Inject] private IProductionSiteService ProductionSiteService { get; set; } = default!;

    # endregion

    protected override ProductionSite CreateItemAction(ProductionSite item) =>
        ProductionSiteService.Create(item);
}

public class ProductionSitesCreateFormValidator : AbstractValidator<ProductionSite>
{
    public ProductionSitesCreateFormValidator(IStringLocalizer<WsDataResources> wsDataLocalizer)
    {
        RuleFor(item => item.Name).NotEmpty().WithName(wsDataLocalizer["ColName"]);
        RuleFor(item => item.Address).NotEmpty().WithName(wsDataLocalizer["ColAddress"]);
    }
}