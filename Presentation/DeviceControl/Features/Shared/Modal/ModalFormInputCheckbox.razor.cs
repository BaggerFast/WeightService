using Microsoft.AspNetCore.Components;

namespace DeviceControl.Features.Shared.Modal;

public sealed partial class ModalFormInputCheckbox: ComponentBase
{
    [Parameter] public bool Value { get; set; }
    [Parameter] public string Description { get; set; } = string.Empty;
    [Parameter] public bool IsDisabled { get; set; }
}