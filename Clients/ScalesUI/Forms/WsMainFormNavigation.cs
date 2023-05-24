// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace ScalesUI.Forms;

public partial class WsMainForm
{
    #region Public and private methods - Возврат из контролов

    /// <summary>
    /// Предзагрузка навигации.
    /// </summary>
    private void PreLoadNavigation()
    {
        // Навигация.
        WsWinFormNavigationUtils.NavigationUserControl.Dock = DockStyle.Fill;
        Controls.Add(WsWinFormNavigationUtils.NavigationUserControl);
        // Ожидание.
        WsWinFormNavigationUtils.WaitUserControl = new();
        WsWinFormNavigationUtils.WaitUserControl.ViewModel.ActionReturnOk = ReturnFromWait;
        WsWinFormNavigationUtils.WaitUserControl.ViewModel.ActionReturnOk += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.WaitUserControl.ViewModel.ActionReturnOk += ActionFinally;
        WsWinFormNavigationUtils.WaitUserControl.ViewModel.ActionReturnCancel = ReturnFromWait;
        WsWinFormNavigationUtils.WaitUserControl.ViewModel.ActionReturnCancel += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.WaitUserControl.ViewModel.ActionReturnCancel += ActionFinally;
        // Замес.
        WsWinFormNavigationUtils.KneadingUserControl = new();
        WsWinFormNavigationUtils.KneadingUserControl.ViewModel.ActionReturnOk = ReturnFromKneading;
        WsWinFormNavigationUtils.KneadingUserControl.ViewModel.ActionReturnOk += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.KneadingUserControl.ViewModel.ActionReturnOk += ActionFinally;
        WsWinFormNavigationUtils.KneadingUserControl.ViewModel.ActionReturnCancel = ReturnFromKneading;
        WsWinFormNavigationUtils.KneadingUserControl.ViewModel.ActionReturnCancel += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.KneadingUserControl.ViewModel.ActionReturnCancel += ActionFinally;
        // Ещё.
        WsWinFormNavigationUtils.MoreUserControl = new();
        WsWinFormNavigationUtils.MoreUserControl.ViewModel.ActionReturnOk = ReturnFromMore;
        WsWinFormNavigationUtils.MoreUserControl.ViewModel.ActionReturnOk += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.MoreUserControl.ViewModel.ActionReturnOk += ActionFinally;
        WsWinFormNavigationUtils.MoreUserControl.ViewModel.ActionReturnCancel = ReturnFromMore;
        WsWinFormNavigationUtils.MoreUserControl.ViewModel.ActionReturnCancel += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.MoreUserControl.ViewModel.ActionReturnCancel += ActionFinally;
        // Смена линии.
        WsWinFormNavigationUtils.LinesUserControl = new();
        WsWinFormNavigationUtils.LinesUserControl.ViewModel.ActionReturnOk = ReturnOkFromLines;
        WsWinFormNavigationUtils.LinesUserControl.ViewModel.ActionReturnOk += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.LinesUserControl.ViewModel.ActionReturnOk += ActionFinally;
        WsWinFormNavigationUtils.LinesUserControl.ViewModel.ActionReturnCancel = ReturnCancelFromLines;
        WsWinFormNavigationUtils.LinesUserControl.ViewModel.ActionReturnCancel += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.LinesUserControl.ViewModel.ActionReturnCancel += ActionFinally;
        // Смена ПЛУ.
        WsWinFormNavigationUtils.PlusLineUserControl = new();
        WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.ActionReturnOk = ReturnOkFromPlusLine;
        WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.ActionReturnOk += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.ActionReturnOk += ActionFinally;
        WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.ActionReturnCancel = ReturnCancelFromPlusLine;
        WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.ActionReturnCancel += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.ActionReturnCancel += ActionFinally;
        // Смена вложенности ПЛУ.
        WsWinFormNavigationUtils.PlusNestingUserControl = new();
        WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.ActionReturnOk = ReturnOkFromPlusNesting;
        WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.ActionReturnOk += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.ActionReturnOk += ActionFinally;
        WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.ActionReturnCancel = ReturnCancelFromPlusNesting;
        WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.ActionReturnCancel += WsWinFormNavigationUtils.ReturnBackFromNavigation;
        WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.ActionReturnCancel += ActionFinally;
    }

    private void ReturnFromWait()
    {
        //
    }

    /// <summary>
    /// Возврат из контрола смены замеса.
    /// </summary>
    private void ReturnFromKneading()
    {
        using WsNumberInputForm numberInputForm = new() { InputValue = 0 };
        DialogResult result = numberInputForm.ShowDialog(this);
        numberInputForm.Close();
        if (result == DialogResult.OK)
            LabelSession.WeighingSettings.Kneading = (byte)numberInputForm.InputValue;
    }

    /// <summary>
    /// Возврат из контрола смены ещё.
    /// </summary>
    private void ReturnFromMore() => UserSession.PluginMassa.Execute();

    /// <summary>
    /// Возврат ОК из контрола смены ПЛУ.
    /// </summary>
    private void ReturnOkFromPlusLine()
    {
        LabelSession.SetPluLine(WsWinFormNavigationUtils.PlusLineUserControl.ViewModel.PluLine);

        LabelSession.WeighingSettings.Kneading = 1;
        LabelSession.ProductDate = DateTime.Now;
        LabelSession.NewPallet();
        MdInvokeControl.SetVisible(labelNettoWeight, LabelSession.PluLine.Plu.IsCheckWeight);
        MdInvokeControl.SetVisible(fieldNettoWeight, LabelSession.PluLine.Plu.IsCheckWeight);
        ActionMore(null, null);
    }

    /// <summary>
    /// Возврат Отмена из контрола смены ПЛУ.
    /// </summary>
    private void ReturnCancelFromPlusLine() =>
        LabelSession.SetPluLine();

    /// <summary>
    /// Возврат ОК из контрола смены вложенности ПЛУ.
    /// </summary>
    private void ReturnOkFromPlusNesting() => 
        LabelSession.SetViewPluNesting(WsWinFormNavigationUtils.PlusNestingUserControl.ViewModel.PluNesting);

    /// <summary>
    /// Возврат Отмена из контрола смены вложенности ПЛУ.
    /// </summary>
    private void ReturnCancelFromPlusNesting()
    {
        //
    }

    /// <summary>
    /// Возврат ОК из контрола смены линии.
    /// </summary>
    private void ReturnOkFromLines()
    {
        LabelSession.SetSessionForLabelPrint(ShowNavigation, 
            WsWinFormNavigationUtils.LinesUserControl.ViewModel.Line.IdentityValueId, 
            WsWinFormNavigationUtils.LinesUserControl.ViewModel.Area);
        ActionMore(null, null);
    }

    /// <summary>
    /// Возврат Отмена из контрола смены линии.
    /// </summary>
    private void ReturnCancelFromLines()
    {
        ActionMore(null, null);
    }

    #endregion

    #region Public and private methods - действия

    private void ActionFinally()
    {
        MdInvokeControl.Select(ButtonPrint);
        // LoadLocalizationDynamic(Lang.Russian);
        LocaleCore.Lang = LocaleData.Lang = Lang.Russian;
        string area = LabelSession.Line.WorkShop is null
            ? LocaleCore.Table.FieldEmpty : LabelSession.Area.Name;
        MdInvokeControl.SetText(ButtonLine, $"{area}{Environment.NewLine}{LocaleCore.Table.Number}: {LabelSession.Line.Number} | {LabelSession.Line.Description}");
        MdInvokeControl.SetText(ButtonPluNestingFk, LabelSession.ViewPluNesting.GetSmartName());
        MdInvokeControl.SetText(fieldPackageWeight, LabelSession.PluLine.IsNotNew
                ? $"{LabelSession.ViewPluNesting.TareWeight:0.000} {LocaleCore.Scales.WeightUnitKg}"
                : $"0,000 {LocaleCore.Scales.WeightUnitKg}");
        // Скрыть навигацию.
        HideNavigation();
    }

    /// <summary>
    /// Отобразить навигацию.
    /// </summary>
    private void ShowNavigation(WsBaseUserControl userControl)
    {
        layoutPanelMain.Visible = false;
        WsWinFormNavigationUtils.NavigationUserControl.Visible = true;
        userControl.Dock = DockStyle.Fill;
        userControl.Visible = true;
        userControl.RefreshAction();
        userControl.Refresh();
        System.Windows.Forms.Application.DoEvents();
    }

    /// <summary>
    /// Скрыть навигацию.
    /// </summary>
    private void HideNavigation()
    {
        WsWinFormNavigationUtils.NavigationUserControl.Visible = false;
        layoutPanelMain.Visible = true;
        layoutPanelMain.Refresh();
        System.Windows.Forms.Application.DoEvents();
    }

    /// <summary>
    /// Закрыть программу.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionClose(object sender, EventArgs e)
    {
        // Redirect into MainForm_FormClosing.
        Close();
    }

    /// <summary>
    /// Сменить линию.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionSwitchLine(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            // Обновить кэш.
            ContextCache.Load(WsSqlTableName.Areas);
            ContextCache.Load(WsSqlTableName.Lines);
            // Навигация.
            WsWinFormNavigationUtils.NavigateToControl(ShowNavigation, WsNavigationPage.Lines,
                LocaleCore.Scales.SwitchLineTitle, "");
        });
    }

    /// <summary>
    /// Проверить наличие ПЛУ.
    /// </summary>
    /// <returns></returns>
    private bool ActionCheckPluIdentityIsNew()
    {
        if (LabelSession.PluLine.Plu.IsNew)
        {
            MdInvokeControl.SetVisible(fieldWarning, true);
            MdInvokeControl.SetText(fieldWarning, LocaleCore.Table.FieldPluIsNotSelected);
            ContextManager.ContextItem.SaveLogError(LocaleCore.Table.FieldPluIsNotSelected);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Запустить ПО.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionScalesTerminal(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation, $"{LocaleCore.Scales.QuestionRunApp} ScalesTerminal?",
                true, WsEnumLogType.Question,
                new() { ButtonYesVisibility = Visibility.Visible, ButtonNoVisibility = Visibility.Visible },
                ActionOk, () => { });
            void ActionOk()
            {
                // Run app.
                if (File.Exists(LocaleData.Paths.ScalesTerminal))
                {
                    UserSession.PluginMassa.Close();
                    Proc.Run(LocaleData.Paths.ScalesTerminal, string.Empty, false, ProcessWindowStyle.Normal, true);
                    UserSession.PluginMassa.Execute();
                }
                else
                {
                    WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation, 
                        LocaleCore.Scales.ProgramNotFound(LocaleData.Paths.ScalesTerminal), true, WsEnumLogType.Warning,
                        new() { ButtonOkVisibility = Visibility.Visible },
                        () => { }, () => { });
                }
            }
        });
    }

    /// <summary>
    /// Инициализировать весовую платформу Масса-К.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionScalesInit(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            if (!LabelSession.PluLine.Plu.IsCheckWeight)
            {
                WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation, LocaleCore.Scales.PluNotSelectWeight, true, WsEnumLogType.Warning,
                    new() { ButtonOkVisibility = Visibility.Visible },
                    () => { }, () => { });
                return;
            }
            if (!UserSession.PluginMassa.MassaDevice.IsOpenPort)
            {
                WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation, LocaleCore.Scales.MassaIsNotRespond, true, WsEnumLogType.Warning,
                    new() { ButtonOkVisibility = Visibility.Visible },
                    () => { }, () => { });
                return;
            }

            WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation,
                LocaleCore.Scales.QuestionPerformOperation, true, WsEnumLogType.Question,
                new() { ButtonYesVisibility = Visibility.Visible, ButtonNoVisibility = Visibility.Visible },
                ActionOk, () => { });
            void ActionOk()
            {
                // Fix negative weight.
                //if (UserSession.PluginMassa.WeightNet < 0)
                //{
                //    UserSession.PluginMassa.ResetMassa();
                //}
                // Проверить наличие весовой платформы Масса-К.
                if (IsSkipDialogs || Debug.IsRelease)
                    UserSession.CheckWeightMassaDeviceExists();
                LabelSession.SetPluLine();

                UserSession.PluginMassa.Execute();
                UserSession.PluginMassa.GetInit();
            }
        });
    }

    /// <summary>
    /// Новая паллета.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionNewPallet(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            LabelSession.NewPallet();
        });
    }

    /// <summary>
    /// Сменить замес.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionKneading(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            WsWinFormNavigationUtils.NavigateToControl(ShowNavigation, WsNavigationPage.More,
                LocaleCore.Scales.SwitchMoreTitle, "");
        });
    }

    /// <summary>
    /// Сменить ПЛУ.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionSwitchPlu(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            MdInvokeControl.SetVisible(labelNettoWeight, false);
            MdInvokeControl.SetVisible(fieldNettoWeight, false);
            LabelSession.SetPluLine();
            // Навигация.
            WsWinFormNavigationUtils.NavigateToControl(ShowNavigation, WsNavigationPage.PlusLine, 
                LocaleCore.Scales.SwitchPluLineTitle, "");
        });
    }

    /// <summary>
    /// Ещё.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionMore(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            if (LabelSession.PluLine.IsNew)
            {
                WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation, LocaleCore.Scales.PluNotSelect, true, WsEnumLogType.Warning,
                    new() { ButtonOkVisibility = Visibility.Visible },
                    () => { }, () => { });
                return;
            }
            // Навигация.
            WsWinFormNavigationUtils.NavigateToControl(ShowNavigation, WsNavigationPage.More, 
                LocaleCore.Scales.SwitchMoreTitle, "");
        });
    }

    /// <summary>
    /// Сброс предупреждения.
    /// </summary>
    private void ResetWarning()
    {
        MdInvokeControl.SetVisible(fieldWarning, false);
        MdInvokeControl.SetText(fieldWarning, string.Empty);
    }

    /// <summary>
    /// Подготовка к печати.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionPreparePrint(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            // Инкремент счётчика этикеток.
            UserSession.AddScaleCounter();
            // Проверить наличие ПЛУ.
            if (!UserSession.CheckPluIsEmpty(fieldWarning)) return;
            // Проверить наличие вложенности ПЛУ.
            if (!UserSession.CheckViewPluNesting(LabelSession.PluLine.Plu, fieldWarning)) return;
            // Проверить наличие весовой платформы Масса-К.
            if (IsSkipDialogs || Debug.IsRelease)
                if (!UserSession.CheckWeightMassaDeviceExists()) return;
            // Проверить стабилизацию весовой платформы Масса-К.
            if (IsSkipDialogs || Debug.IsRelease)
                if (!UserSession.CheckWeightMassaIsStable(fieldWarning)) return;
            // Проверить ГТИН ПЛУ.
            if (!UserSession.CheckPluGtin(fieldWarning)) return;
            // Задать фейк данные веса ПЛУ для режима разработки.
            if (!IsSkipDialogs && Debug.IsDevelop)
                UserSession.SetPluWeighingFakeForDevelop(ShowNavigation);
            // Проверить отрицательный вес.
            if (!UserSession.CheckWeightIsNegative(fieldWarning)) return;
            // Создать новое взвешивание ПЛУ.
            UserSession.NewPluWeighing();
            // Проверить границы веса.
            if (!UserSession.CheckWeightThresholds(fieldWarning)) return;
            // Проверить подключение принтера.
            if (!IsSkipDialogs && Debug.IsDevelop)
            {
                WsWinFormNavigationUtils.NavigateToOperationControl(ShowNavigation,
                    LocaleCore.Print.QuestionPrintCheckAccess, true, WsEnumLogType.Question,
                    new() { ButtonYesVisibility = Visibility.Visible, ButtonNoVisibility = Visibility.Visible },
                    ActionOk, ActionCancel);
                void ActionOk()
                {
                    // Печать этикетки.
                    UserSession.PrintLabel(ShowNavigation, fieldWarning, false);
                }
                void ActionCancel()
                {
                    // Проверить подключение и готовность принтеров.
                    if (ActionPreparePrintCheckPrinters())
                        // Печать этикетки.
                        UserSession.PrintLabel(ShowNavigation, fieldWarning, false);
                }
            }
            else
            {
                // Проверить подключение и готовность принтеров.
                if (ActionPreparePrintCheckPrinters())
                    // Печать этикетки.
                    UserSession.PrintLabel(ShowNavigation, fieldWarning, false);
            }
        });
        UserSession.PluginMassa.IsWeightNetFake = false;
    }

    /// <summary>
    /// Проверить подключение и готовность принтеров.
    /// </summary>
    private bool ActionPreparePrintCheckPrinters()
    {
        // Проверить подключение и готовность основного принтера.
        if (!UserSession.CheckPrintIsConnectAndReady(fieldWarning, LabelSession.PluginPrintMain, true)) 
            return false;
        // Проверить подключение и готовность транспортного принтера.
        if (LabelSession.Line.IsShipping)
            if (!UserSession.CheckPrintIsConnectAndReady(fieldWarning, LabelSession.PluginPrintShipping, false)) 
                return false;
        return true;
    }

    /// <summary>
    /// Сменить вложенность ПЛУ.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActionSwitchPluNesting(object sender, EventArgs e)
    {
        WsWinFormNavigationUtils.ActionTryCatch(this, ShowNavigation, () =>
        {
            // Сброс предупреждения.
            ResetWarning();
            // Проверить наличие ПЛУ.
            if (!ActionCheckPluIdentityIsNew()) return;
            // Обновить кэш.
            ContextCache.Load(WsSqlTableName.ViewPlusNesting);
            // Навигация.
            WsWinFormNavigationUtils.NavigateToControl(ShowNavigation, WsNavigationPage.PlusNesting, 
                LocaleCore.Scales.SwitchPluNestingTitle, "");
        });
    }

    #endregion
}