using DeviceControl.Components.Section;
using WsBlazorCore.Settings;
using WsStorageCore.ViewScaleModels;

namespace DeviceControl.Pages.Menu.Logs.WebServiceLogs;

public sealed partial class WebServiceLogs : SectionBase<LogWebView>
{
    #region Public and private fields, properties, constructor

    public WebServiceLogs() : base()
    {
        SqlCrudConfigSection.IsGuiShowFilterMarked = false;
        SqlCrudConfigSection.IsResultOrder = true;
        ButtonSettings = ButtonSettingsModel.CreateForStaticSection();
    }

    #endregion

    #region Public and private methods

    protected override void SetSqlSectionCast()
    {
        var query = WsSqlQueriesDiags.Tables.Views.GetWebLogs(SqlCrudConfigSection.SelectTopRowsCount);
        object[] objects = ContextManager.AccessManager.AccessList.GetArrayObjectsNotNullable(query);
        List<LogWebView> items = new();
        foreach (var obj in objects)
        {
            if (obj is not object[] { Length: 8 } item)
                continue;

            if (Guid.TryParse(Convert.ToString(item[0]), out var uid))
            {
                items.Add(new LogWebView
                {
                    IdentityValueUid = uid,
                    CreateDt = Convert.ToDateTime(item[1]),
                    RequestUrl = item[2] as string ?? string.Empty,
                    RequestCountAll = Convert.ToInt32(item[3]),
                    ResponseCountSuccess = Convert.ToInt32(item[4]),
                    ResponseCountError = Convert.ToInt32(item[5]),
                    AppVersion = item[7] as string ?? string.Empty
                });
            }
        }

        SqlSectionCast = items;
    }

    #endregion
}