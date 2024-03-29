using DeviceControl2.Source.Shared.Localization;
using DeviceControl2.Source.Widgets.Section;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Ws.Domain.Models.Entities.Ref;
using Ws.Domain.Services.Features.ProductionSite;
using Ws.Domain.Services.Features.Template;
using Ws.Domain.Services.Features.Warehouse;
using Ws.Shared.Resources;

namespace DeviceControl2.Source.Pages.PrintSettings.Templates;

public sealed partial class TemplatesCreateForm: SectionFormBase<TemplateEntity>
{
    #region Inject

    [Inject] private IStringLocalizer<WsDataResources> WsDataLocalizer { get; set; } = default!;
    [Inject] private ITemplateService TemplateService { get; set; } = default!;

    #endregion

    protected override TemplateEntity CreateItemAction(TemplateEntity item) =>
        TemplateService.Create(item);
}

public class TemplatesCreateFormValidator : AbstractValidator<TemplateEntity>
{
    public TemplatesCreateFormValidator()
    {
        RuleFor(item => item.Name).NotEmpty();
        RuleFor(item => item.Body).NotEmpty();
    }
}
