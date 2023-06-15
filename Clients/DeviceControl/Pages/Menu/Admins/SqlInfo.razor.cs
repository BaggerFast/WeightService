// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsStorageCore.Helpers;
using WsStorageCore.ViewDiagModels;

namespace DeviceControl.Pages.Menu.Admins;

public sealed partial class SqlInfo : LayoutComponentBase
{
    #region Public and private fields, properties, constructor
    
    private List<WsSqlDbFileSizeInfoModel> DbFiles { get; set; }
    private List<WsSqlViewTableSizeModel> DbTables { get; set; }
    private static WsSqlContextManagerHelper ContextManager => WsSqlContextManagerHelper.Instance;
    
    private string SqlConnectionString => $"{ContextManager.JsonSettings.Local.Sql.DataSource} \\ " +
                                          $"{ContextManager.JsonSettings.Local.Sql.InitialCatalog} \\ " +
                                          $"{ContextManager.JsonSettings.Local.Sql.UserId}";
    
    public SqlInfo()
    {
        DbFiles = new();
        DbTables = new();
    }
    
    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender)
        {
            base.OnAfterRender(firstRender);
            return;
        }
        GetSectionData();
    }

    private void GetSectionData()
    {
        DbFiles = ContextManager.GetDbFileSizeInfos();
        DbTables = WsSqlContextViewHelper.Instance.GetListViewTablesSizes();
        foreach (WsSqlDbFileSizeInfoModel dbFile in DbFiles)
        {
            dbFile.Tables.AddRange(DbTables.Where(table => table.FileName == dbFile.FileName));
        }
        
        StateHasChanged();
    }
    
    private static void RowRender(RowRenderEventArgs<WsSqlDbFileSizeInfoModel> args)
    {
        args.Expandable = args.Data.Tables.Count > 0;
    }
    

    #endregion
}