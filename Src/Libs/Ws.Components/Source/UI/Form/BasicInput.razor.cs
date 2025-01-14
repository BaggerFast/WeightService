using Microsoft.AspNetCore.Components;

namespace Ws.Components.Source.UI.Form;

public abstract class BasicInput<TValue> : ComponentBase
{
    [Parameter] public virtual TValue? Value { get; set; }
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool AutoFocus { get; set; }
    [Parameter] public string Placeholder { get; set; } = string.Empty;
    [Parameter] public bool ReadOnly { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected async Task OnValueChanged() => await ValueChanged.InvokeAsync(Value);
}