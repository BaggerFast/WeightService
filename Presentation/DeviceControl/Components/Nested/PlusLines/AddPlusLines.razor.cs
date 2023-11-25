using Ws.StorageCore.OrmUtils;

namespace DeviceControl.Components.Nested.PlusLines;

public sealed partial class AddPlusLines
{
    private SqlCoreHelper SqlCore => SqlCoreHelper.Instance;
    
    [Inject] protected IJSRuntime JsRuntime { get; set; } = default!;
    
    [Parameter] public SqlLineEntity Line { get; set; }
    
    private List<SqlPluEntity> Plus { get; set; }
    
    private List<SqlPluEntity> SelectedPlus { get; set; }
    
    public ButtonSettingsModel ButtonSettings { get; set; }
    
    public AddPlusLines()
    {
        Plus = new();
        SelectedPlus = new();
        ButtonSettings = ButtonSettingsModel.CreateForItem();
    }
    
    #region Public and private methods

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            SqlCrudConfigModel sqlCrud = SqlCrudConfigFactory.GetCrudActual();
            sqlCrud.AddFilters(new() {
                SqlRestrictions.EqualFk(nameof(SqlPluScaleEntity.Line), Line),
                SqlRestrictions.Equal(nameof(SqlPluScaleEntity.IsActive), true)
            });
            List<short> pluNumbersActive = new SqlPluLineRepository().GetList(sqlCrud).Select(plusScale => plusScale.Plu.Number).ToList();
            
            sqlCrud = SqlCrudConfigFactory.GetCrudActual();
            sqlCrud.AddFilters(new() {
                SqlRestrictions.Equal(nameof(SqlPluEntity.IsGroup), false),
                SqlRestrictions.NotIn(nameof(SqlPluEntity.Number),  pluNumbersActive.Cast<object>().ToList())
            });
            Plus = new SqlPluRepository().GetEnumerable(sqlCrud).ToList();
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }
    
    private void ReloadPage()
    {
        JsRuntime.InvokeVoidAsync("location.reload");
    }
    
    private void SaveItem()
    {
        foreach (SqlPluEntity plu in SelectedPlus)
        {
            SqlPluScaleEntity pluScale = new SqlPluLineRepository().GetItemByLinePlu(Line, plu);
            pluScale.IsActive = true;
            if (pluScale.IsNew)
            {
                pluScale.Line = Line;
                pluScale.Plu = plu;
            }
            else
            {
                SqlCore.Update(pluScale);
            }
            SqlCore.Save(pluScale);
        }
        ReloadPage();
    }
    
    #endregion
}
