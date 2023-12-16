using Microsoft.AspNetCore.Components;

namespace DeviceControl.Features.Shared.Form;

public sealed partial class SectionFormInputText: SectionFormInputBase
{
    [Parameter] public bool IsDisabled { get; set; }
    [Parameter] public string Value { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public bool IsFullWidth { get; set; }
    [Parameter] public bool IsTall { get; set; }

    private async Task HandleValueChange(string arg)
    {
        Value = arg;
        await ValueChanged.InvokeAsync(Value);
    }
}