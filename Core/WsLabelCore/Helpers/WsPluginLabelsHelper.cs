// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsLabelCore.Helpers;

public sealed class WsPluginLabelsHelper : WsPluginHelperBase
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static WsPluginLabelsHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static WsPluginLabelsHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields and properties

    private Label FieldKneading { get; set; }
    private Label FieldPlu { get; set; }
    private Label FieldProductDate { get; set; }
    private WsLabelSessionHelper LabelSession => WsLabelSessionHelper.Instance;
    
    #endregion

    #region Constructor and destructor

    public WsPluginLabelsHelper()
    {
        TskType = WsEnumTaskType.TaskLabel;
    }

    #endregion

    #region Public and private methods

    public void Init(WsConfigModel configReopen, WsConfigModel configRequest, WsConfigModel configResponse,
        Label fieldPlu, Label fieldProductDate, Label fieldKneading)
    {
        base.Init();
        ReopenItem.Config = configReopen;
        RequestItem.Config = configRequest;
        ResponseItem.Config = configResponse;
        WsWinFormNavigationUtils.ActionTryCatch(() =>
        {
            FieldPlu = fieldPlu;
            FieldProductDate = fieldProductDate;
            FieldKneading = fieldKneading;
            MdInvokeControl.SetText(FieldPlu, LocaleCore.Scales.Plu);
            //MdInvokeControl.SetText(FieldSscc, LocaleCore.Scales.FieldSscc);
            MdInvokeControl.SetText(FieldProductDate, LocaleCore.Scales.FieldDate);
            MdInvokeControl.SetText(FieldKneading, string.Empty);
        });
    }

    public override void Execute()
    {
        base.Execute();
        ReopenItem.Execute(Reopen);
        RequestItem.Execute(Request);
    }

    private void Reopen()
    {
        //MdInvokeControl.SetText(FieldSscc, $"{LocaleCore.Scales.FieldSscc}: {WsUserSessionHelper.Instance.ProductSeries.Sscc.Sscc}");
        MdInvokeControl.SetVisible(FieldKneading, LabelSession.Scale.IsKneading);
    }

    private void Request()
    {
        if (LabelSession.PluScale.IsNew)
            MdInvokeControl.SetText(FieldPlu, LocaleCore.Scales.Plu);
        else
            MdInvokeControl.SetText(FieldPlu,
                LabelSession.PluScale.Plu.IsCheckWeight
                    ? $"{LocaleCore.Scales.PluWeight}: {LabelSession.PluScale.Plu.Number} | {LabelSession.PluScale.Plu.Name}"
                    : $"{LocaleCore.Scales.PluCount}: {LabelSession.PluScale.Plu.Number} | {LabelSession.PluScale.Plu.Name}");
        MdInvokeControl.SetText(FieldProductDate, $"{LabelSession.ProductDate:dd.MM.yyyy}");
        MdInvokeControl.SetText(FieldKneading, $"{LabelSession.WeighingSettings.Kneading}");
    }

    #endregion
}