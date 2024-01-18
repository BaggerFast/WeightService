using Blazorise;
using Microsoft.AspNetCore.Components;
using ScalesHybrid.Features.Labels.Dialogs;
using ScalesHybrid.Features.Pallet.Dialogs;
using ScalesHybrid.Services;

namespace ScalesHybrid.Features.Labels.Modules;

public sealed partial class LabelConfig : ComponentBase, IDisposable
{
    [Inject] private LineContext LineContext { get; set; } = null!;
    [Inject] private IModalService ModalService { get; set; } = null!;
    
    protected override void OnInitialized() => LineContext.OnStateChanged += StateHasChanged;
    
    private async Task ShowPluSelectDialog() => await ModalService.Show<PluSelect>();
    
    public void Dispose() => LineContext.OnStateChanged -= StateHasChanged;
}