using Ws.Domain.Models.Entities.Print;
using Ws.Domain.Services.Features.Templates;

namespace DeviceControl.Source.Pages.PrintSettings.Templates;

public sealed partial class TemplatesUpdateForm : SectionFormBase<Template>
{
    #region Inject

    [Inject] private Redirector Redirector { get; set; } = default!;
    [Inject] private IStringLocalizer<WsDataResources> WsDataLocalizer { get; set; } = default!;
    [Inject] private ITemplateService TemplateService { get; set; } = default!;

    #endregion

    protected override Template UpdateItemAction(Template item) =>
        TemplateService.Update(item);

    protected override Task DeleteItemAction(Template item)
    {
        TemplateService.DeleteById(item.Uid);
        return Task.CompletedTask;
    }

    private string GetTemplateTypeName(bool isWeight) =>
        isWeight ? WsDataLocalizer["ColTemplateWeight"] : WsDataLocalizer["ColTemplatePiece"];
}

public class TemplatesUpdateFormValidator : AbstractValidator<Template>
{
    public TemplatesUpdateFormValidator(IStringLocalizer<WsDataResources> wsDataLocalizer)
    {
        RuleFor(item => item.Name).NotEmpty().WithName(wsDataLocalizer["ColName"]);
        RuleFor(item => item.Body).NotEmpty().WithName(wsDataLocalizer["ColData"]);
    }
}