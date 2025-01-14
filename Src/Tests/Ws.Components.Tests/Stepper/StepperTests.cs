using AngleSharp.Dom;
using Ws.Components.Source.UI.Stepper;

namespace Ws.Components.Tests.Stepper;

public class StepperTests : TestContext
{
    [Fact]
    public void Stepper_Component_Initializes_With_Correct_Current_Index()
    {
        using TestContext ctx = new();
        IRenderedComponent<Source.UI.Stepper.Stepper> cut = ctx.RenderComponent<Source.UI.Stepper.Stepper>();

        cut.Instance.CurrentIndex.Should().Be(1);
    }

    [Fact]
    public async Task Stepper_Component_Can_Change_Current_Index()
    {
        using TestContext ctx = new();
        IRenderedComponent<Source.UI.Stepper.Stepper> cut = ctx.RenderComponent<Source.UI.Stepper.Stepper>();

        await cut.Instance.SetCurrentIndex(2);

        cut.Instance.CurrentIndex.Should().Be(2);
    }

    [Fact]
    public void Stepper_Component_Indexes_Items_Correctly()
    {
        using TestContext ctx = new();
        const short itemsCount = 3;
        IRenderedComponent<StepperComponent> cut = ctx.RenderComponent<StepperComponent>();

        IReadOnlyList<IRenderedComponent<StepperItem>> items = cut.FindComponents<StepperItem>();

        items.Count.Should().Be(itemsCount);
        for (int i = 0; i < items.Count; i++)
            items[i].Instance.Index.Should().Be(i + 1);
        items[^1].Instance.Index.Should().Be(itemsCount);
    }

    [Fact]
    public void First_StepperItem_Is_Clickable_And_Last_StepperItem_Is_Disabled()
    {
        using TestContext ctx = new();
        IRenderedComponent<StepperComponent> cut = ctx.RenderComponent<StepperComponent>();

        IReadOnlyList<IRenderedComponent<StepperItem>> items = cut.FindComponents<StepperItem>();
        IRenderedComponent<StepperItem> firstItem = items[0];
        IRenderedComponent<StepperItem> lastItem = items[^1];

        firstItem.Instance.Disabled.Should().BeFalse();
        IElement firstButton = firstItem.Find("button");
        firstButton.IsDisabled().Should().BeFalse();

        lastItem.Instance.Disabled.Should().BeTrue();
        IElement secondButton = lastItem.WaitForElement("button");
        secondButton.IsDisabled().Should().BeTrue();
    }

    [Fact]
    public async Task Changing_CurrentStepIndex_Manually_Updates_Current_Content_And_Active_StepperItem()
    {
        using TestContext ctx = new();
        IRenderedComponent<StepperComponent> cut = ctx.RenderComponent<StepperComponent>();

        IRenderedComponent<Source.UI.Stepper.Stepper> stepper = cut.FindComponent<Source.UI.Stepper.Stepper>();

        await cut.InvokeAsync(() => stepper.Instance.SetCurrentIndex(3));

        stepper.Instance.CurrentIndex.Should().Be(3);
        cut.Find("p").TextContent.Should().Be("Third step");
    }
}