namespace DeviceControl.Components.Common;

public class ItemBase<TItem> : RazorComponentBase where TItem : WsSqlEntityBase, new()
{
    [Inject] protected WsJsService JsService { get; private set; } = default!;
    [Inject] protected WsRouteService RouteService { get; set; } = default!;
    [Parameter] public Guid Uid { get; set; }
    [Parameter] public long Id { get; set; }
    protected WsSqlEntityBase? SqlItem { get; private set; }

    #region Public and private fields, properties, constructor

    protected ButtonSettingsModel ButtonSettings { get; set; }

    protected TItem SqlItemCast
    {
        get => SqlItem is null ? new() : (TItem)SqlItem;
        set => SqlItem = value;
    }

    public ItemBase()
    {
        ButtonSettings = ButtonSettingsModel.CreateForItem();
    }

    #endregion

    #region Public and private methods
    
    protected async Task RedirectBackAsync()
    {
        await JsService.RedirectBack();
    }

    protected async Task SqlItemSaveAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        RunActionsWithQuestion(WsLocaleCore.Table.TableSave, WsLocaleCore.Dialog.DialogQuestion, ItemSave);
        
        RouteService.NavigateSectionRoute(SqlItemCast);
    }
    
    protected virtual void ItemSave()
    {
        SqlItemSave(SqlItemCast);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
            GetItemData();
        base.OnAfterRender(firstRender);
    }

    protected void GetItemData()
    {
        RunAction(string.Empty, SetSqlItemCast);
        StateHasChanged();
    }

    protected virtual void SetSqlItemCast()
    {
        SqlItemCast = SqlItemCast.Identity.Name switch
        {
            WsSqlEnumFieldIdentity.Id => ContextManager.SqlCore.GetItemById<TItem>(Id),
            WsSqlEnumFieldIdentity.Uid => ContextManager.SqlCore.GetItemByUid<TItem>(Uid),
            _ => new()
        };
    }

    #endregion
}