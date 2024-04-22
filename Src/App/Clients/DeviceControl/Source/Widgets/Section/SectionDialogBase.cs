using Force.DeepCloner;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace DeviceControl.Source.Widgets.Section;

[CascadingTypeParameter(nameof(TDialogItem))]

public abstract class SectionDialogBase<TDialogItem> : ComponentBase, IDialogContentComponent<SectionDialogContent<TDialogItem>>
{
    [Parameter] public SectionDialogContent<TDialogItem> Content { get; set; } = default!;
    protected TDialogItem DialogItem { get; private set; } = default!;
    protected List<KeyValuePair<Type, string>> TabsList { get; private set; } = [];

    protected override void OnInitialized()
    {
        DialogItem = Content.Item.DeepClone();
        TabsList = InitializeTabList();
    }

    protected abstract List<KeyValuePair<Type, string>> InitializeTabList();
}

public record SectionDialogContent<TDialogItem>
{
    public TDialogItem Item { get; init; } = default!;
    public SectionDialogResultEnum DataAction { get; init; } = SectionDialogResultEnum.Cancel;
}