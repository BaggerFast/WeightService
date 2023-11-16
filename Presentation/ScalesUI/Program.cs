namespace ScalesUI;

internal static class Program
{
    private static WsAppVersionHelper AppVersion => WsAppVersionHelper.Instance;
    private static SqlContextManagerHelper ContextManager => SqlContextManagerHelper.Instance;
    private static WsLabelSessionHelper LabelSession => WsLabelSessionHelper.Instance;
    private static SqlCoreHelper SqlCore => SqlCoreHelper.Instance;
    
    [STAThread]
    internal static void Main()
    {
        // В первую очередь.
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Проверить каталог и файлы локализации.
        WsLocalizationUtils.CheckDirectoryWithFiles();
        // Настройка.
        SqlCore.SetSessionFactory(WsDebugHelper.Instance.IsDevelop);
        ContextManager.SetupJsonScales(Directory.GetCurrentDirectory(), typeof(Program).Assembly.GetName().Name);
        AppVersion.Setup(Assembly.GetExecutingAssembly(), LabelSession.Localization.LabelPrint.App);

        // Запуск.
        Application.Run(new WsMainForm());
    }
}
