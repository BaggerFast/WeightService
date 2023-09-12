using WsStorageCore.Tables.TableDiagModels.LogsWebs;
namespace DeviceControl.Pages.Menu.Logs.WebServiceLogs;

public sealed partial class ItemWebServiceLog : ItemBase<WsSqlLogWebModel>
{
    #region Public and private fields, properties, constructor

    public ItemWebServiceLog() : base()
    {
        ButtonSettings = ButtonSettingsModel.CreateForStaticItem();
    }

    #endregion
}
