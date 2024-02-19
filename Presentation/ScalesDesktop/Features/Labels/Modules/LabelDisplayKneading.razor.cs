using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using ScalesDesktop.Features.Labels.Modals;
using ScalesDesktop.Features.Labels.Resources;
using ScalesDesktop.Features.Shared;
using ScalesDesktop.Services;
using Ws.SharedUI.Resources;

namespace ScalesDesktop.Features.Labels.Modules;

public sealed partial class LabelDisplayKneading : ComponentBase, IDisposable
{
    [Inject] private IStringLocalizer<LabelsResources> LabelsLocalizer { get; set; } = null!;
    [Inject] private IStringLocalizer<WsDataResources> WsDataLocalizer { get; set; } = null!;
    [Inject] private IModalService ModalService { get; set; } = null!;

    [Inject] private LabelContext LabelContext { get; set; } = null!;

    protected override void OnInitialized() => LabelContext.OnStateChanged += StateHasChanged;

    private void SetNewKneading(int newKneading)
    {
        LabelContext.KneadingModel.KneadingCount = newKneading;
        StateHasChanged();
    }

    private async Task ShowNumericKeyboard() => await ModalService.Show<NumericKeyboardDialog>(p =>
        p.Add(x => x.CallbackFunction, SetNewKneading), new() { Size = ModalSize.Default });

    public void Dispose() => LabelContext.OnStateChanged -= StateHasChanged;
}