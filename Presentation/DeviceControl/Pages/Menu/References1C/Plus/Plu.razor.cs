using WsStorageCore.OrmUtils;
namespace DeviceControl.Pages.Menu.References1C.Plus;

public sealed partial class Plu : SectionBase<WsSqlPluEntity>
{
    #region Public and private fields, properties, constructor
    
    public Plu() : base()
    {
        SqlCrudConfigSection.AddFilter(SqlRestrictions.Equal(nameof(WsSqlPluEntity.IsGroup), false));
        ButtonSettings = ButtonSettingsModel.CreateForStatic1CSection();
    }
    
    protected override void SetSqlSectionCast()
    {
        SqlSectionCast = new WsSqlPluRepository().GetEnumerable(SqlCrudConfigSection).ToList();
    }

    #endregion
}