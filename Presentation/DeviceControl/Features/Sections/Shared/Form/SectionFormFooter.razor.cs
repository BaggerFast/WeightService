using Blazorise;
using DeviceControl.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

namespace DeviceControl.Features.Sections.Shared.Form;

public sealed partial class SectionFormFooter: ComponentBase
{
    [Inject] private IModalService ModalService { get; set; } = null!;
    [Inject] private IStringLocalizer<ApplicationResources> Localizer { get; set; } = null!;
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;
    
    [Parameter] public DateTime? CreateDate { get; set; }
    [Parameter] public DateTime? ChangeDate { get; set; }
    [Parameter] public EventCallback OnSubmitAction { get; set; }

    private bool IsSubmitDisabled { get; set; } = false;

    private async Task CloseModal() => await ModalService.Hide();

    private async Task ExecuteSubmitWithTimeout()
    {
        IsSubmitDisabled = true;
        StateHasChanged();
        await Task.Delay(2000);
        await OnSubmitAction.InvokeAsync(null);
        IsSubmitDisabled = false;
        StateHasChanged();
    }
}