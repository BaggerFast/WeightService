// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows.Forms;
using WsStorageCore.Tables.TableConfModels.DeviceSettingsFks;

namespace ScalesUI.Forms;

public partial class WsMainForm
{
    #region Public and private methods - Настройки устройства

    private void ActionSwitchDeviceSettings(object sender, EventArgs e)
    {
        // Загрузить WinForms-контрол настроек устройства.
        LoadNavigationDeviceSettings();
        WsFormNavigationUtils.ActionTryCatch(this, ShowFormUserControl, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            // Обновить кэш.
            ContextCache.Load(WsSqlEnumTableName.DeviceSettings);
            ContextCache.Load(WsSqlEnumTableName.DeviceSettingsFks);
            // Навигация в контрол линии.
            WsFormNavigationUtils.NavigateToExistsDeviceSettings(ShowFormUserControl);
        });
    }

    /// <summary>
    /// Загрузить WinForms-контрол настроек устройства.
    /// </summary>
    private void LoadNavigationDeviceSettings()
    {
        if (WsFormNavigationUtils.IsLoadDeviceSettings) return;
        WsFormNavigationUtils.IsLoadDeviceSettings = true;

        WsFormNavigationUtils.DeviceSettingsUserControl.SetupUserControl();
        WsFormNavigationUtils.DeviceSettingsUserControl.ViewModel.CmdCancel.AddAction(WsFormNavigationUtils.ActionBackFromNavigation);
        WsFormNavigationUtils.DeviceSettingsUserControl.ViewModel.CmdCancel.AddAction(ActionFinally);
        WsFormNavigationUtils.DeviceSettingsUserControl.ViewModel.CmdYes.AddAction(ReturnOkFromDeviceSettings);
        WsFormNavigationUtils.DeviceSettingsUserControl.ViewModel.CmdYes.AddAction(WsFormNavigationUtils.ActionBackFromNavigation);
        WsFormNavigationUtils.DeviceSettingsUserControl.ViewModel.CmdYes.AddAction(ActionFinally);
    }

    /// <summary>
    /// Возврат ОК из контрола настроек устройства.
    /// </summary>
    // TODO: подумать об универсальном алгоритме для всех настроек
    private void ReturnOkFromDeviceSettings()
    {
        // Настроить устройство ПО `Печать этикеток`.
        LabelSession.SetSessionForLabelPrint();

        //this.SwitchResolution(Debug.IsDevelop ? WsEnumScreenResolution.Value1366x768 : WsEnumScreenResolution.FullScreen);
        bool isFormFullScreen = true;
        foreach (WsSqlDeviceSettingsFkModel deviceSettingsFk in ContextManager.DeviceSettingsFksRepository.GetListByLine(LabelSession.Line))
        {
            switch (deviceSettingsFk.Setting.Name)
            {
                // Отображать кнопку максимизации.
                case "IsShowMaximizeButton":
                    MaximizeBox = deviceSettingsFk.IsEnabled;
                    FormBorderStyle = deviceSettingsFk.IsEnabled ? FormBorderStyle.FixedSingle : FormBorderStyle.None;
                    if (deviceSettingsFk.IsEnabled)
                        isFormFullScreen = false;
                    break;
                // Отображать кнопку минимизации.
                case "IsShowMinimizeButton":
                    MinimizeBox = deviceSettingsFk.IsEnabled;
                    FormBorderStyle = deviceSettingsFk.IsEnabled ? FormBorderStyle.FixedSingle : FormBorderStyle.None;
                    if (deviceSettingsFk.IsEnabled)
                        isFormFullScreen = false;
                    break;
                // Отображать кнопку печати.
                case "IsShowPrintButton":
                    ButtonPrint.Visible = deviceSettingsFk.IsEnabled;
                    break;
            }
        }
        if (isFormFullScreen)
            this.SwitchResolution(WsEnumScreenResolution.FullScreen);
    }

    #endregion
}