// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsLocalizationCore.Common;

namespace WsLabelCore.Helpers;

/// <summary>
/// Плагин принтера.
/// </summary>
#nullable enable
public class WsPluginPrintModel : WsPluginBaseHelper
{
    #region Public and private fields and properties

    public byte LabelPrintedCount { get; set; }
    protected Label FieldPrint { get; set; } = new();
    protected Label FieldPrintExt { get; set; } = new();
    protected WsEnumPrintModel PrintModel { get; set; }
    protected MdPrinterModel Printer { get; set; }
    protected static WsLabelSessionHelper LabelSession => WsLabelSessionHelper.Instance;
    protected bool IsMain { get; set; }
    public string PrintName { get; set; }

    #endregion

    #region Constructor and destructor

    protected WsPluginPrintModel()
    {
        PluginType = WsEnumPluginType.Print;
        ResponseItem.PluginType = RequestItem.PluginType = ReopenItem.PluginType = PluginType;
        Printer = new();
        LabelPrintedCount = 0;
        PrintName = string.Empty;
    }

    #endregion

    #region Public and private methods

    //private void Request()
    //{
    //    // Метка.
    //    MdInvokeControl.SetText(FieldPrintExt, $"{ReopenCounter} | {RequestCounter} | {ResponseCounter}");

    //    //if (!Printer.PingStatus.Equals(IPStatus.Success)) return;
    //    if (!IsConnected) return;
    //    if (PrintBrand == PrintBrand.Tsc) return;
        
    //    if (PrintBrand == PrintBrand.Zebra)
    //    {
    //        if (ZebraConnection is null)
    //            ZebraConnection = ZebraConnectionBuilder.Build(Printer.Ip);
    //        if (!ZebraConnection.Connected)
    //            ZebraConnection.Open();
    //        if (ZebraDriver is null || ZebraConnection is null || !ZebraConnection.Connected)
    //            ZebraStatus = null;
    //        else
    //        {
    //            try
    //            {
    //                ZebraStatus = ZebraDriver.GetCurrentStatus();
    //            }
    //            catch (Exception ex)
    //            {
    //                WsFormNavigationUtils.CatchExceptionSimple(ex);
    //                SendCmdToZebra(ZplUtils.ZplHostStatusReturn);
    //            }
    //        }
    //    }
    //}

    protected byte GetLabelCount() =>
        IsMain ? LabelSession.WeighingSettings.LabelsCountMain : LabelSession.WeighingSettings.LabelsCountShipping;

    private readonly object _lockWmi = new();
    protected MdWmiWinPrinterModel GetWin32Printer(string name)
    {
        lock (_lockWmi)
        {
            if (string.IsNullOrEmpty(name))
                return new(name, string.Empty, string.Empty, string.Empty, string.Empty, MdWinPrinterStatus.Error);
            // PowerShell: gwmi Win32_Printer | select DriverName, PortName, Status, PrinterState, PrinterStatus
            // PowerShell: gwmi -query "select DriverName, PortName, Status, PrinterState, PrinterStatus from Win32_Printer where Name='SCALES-PRN-DEV'"
            ObjectQuery wql = new($"select DriverName, PortName, Status, PrinterState, PrinterStatus from Win32_Printer where Name = '{name}'");
            ManagementObjectSearcher searcher = new(wql);
            ManagementObjectCollection items = searcher.Get();
            string driverName = string.Empty;
            string portName = string.Empty;
            string status = string.Empty;
            string printerState = string.Empty;
            short printerStatus = -1;
            if (items.Count > 0)
            {
                foreach (ManagementBaseObject item in items)
                {
                    driverName = Convert.ToString(item["DriverName"]);
                    portName = Convert.ToString(item["PortName"]);
                    status = Convert.ToString(item["Status"]);
                    printerState = Convert.ToString(item["PrinterState"]);
                    printerStatus = Convert.ToInt16(item["PrinterStatus"]);
                }
            }
            return new(name, driverName, portName, status, printerState, (MdWinPrinterStatus)printerStatus);
        }
    }

    protected string GetPrinterStatusDescription(WsEnumLanguage lang, MdWinPrinterStatus printerStatus) =>
        lang switch
        {
            WsEnumLanguage.Russian => printerStatus switch
            {
                MdWinPrinterStatus.Idle => "Бездействие",
                MdWinPrinterStatus.Paused => "Пауза",
                MdWinPrinterStatus.Error => "Ошибка",
                MdWinPrinterStatus.PendingDeletion => LocaleCore.Print.StatusPendingDeletion,
                MdWinPrinterStatus.PaperJam => "Застревание бумаги",
                MdWinPrinterStatus.PaperOut => "Выдача бумаги",
                MdWinPrinterStatus.ManualFeed => "Ручная подача",
                MdWinPrinterStatus.PaperProblem => "Проблема с бумагой",
                MdWinPrinterStatus.Offline => "Не в сети",
                MdWinPrinterStatus.IoActive => "Ввод-вывод активен",
                MdWinPrinterStatus.Busy => "Занято",
                MdWinPrinterStatus.Printing => "Печать",
                MdWinPrinterStatus.OutputBinFull => "Выходной лоток полон",
                MdWinPrinterStatus.NotAvailable => "Недоступно",
                MdWinPrinterStatus.Waiting => "Ожидание",
                MdWinPrinterStatus.Processing => "Обработка",
                MdWinPrinterStatus.Initialization => "Инициализация",
                MdWinPrinterStatus.WarmingUp => "Прогрев",
                MdWinPrinterStatus.TonerLow => "Мало тонера",
                MdWinPrinterStatus.NoToner => "Нет тонера",
                MdWinPrinterStatus.PagePunt => "Страница беспечатана",
                MdWinPrinterStatus.UserInterventionRequired => "Требуется вмешательство пользователя",
                MdWinPrinterStatus.OutOfMemory => "Недостаточно памяти",
                MdWinPrinterStatus.DoorOpen => "Открыта дверца",
                MdWinPrinterStatus.ServerUnknown => "Сервер неизвестен",
                MdWinPrinterStatus.PowerSave => "Энергосбережение",
                _ => "Ошибка чтения статуса!",
            },
            _ => printerStatus switch
            {
                MdWinPrinterStatus.Idle => "Idle",
                MdWinPrinterStatus.Paused => "Paused",
                MdWinPrinterStatus.Error => "Error",
                MdWinPrinterStatus.PendingDeletion => "Waiting for connect", // "Pending deletion"
                MdWinPrinterStatus.PaperJam => "Paper jam",
                MdWinPrinterStatus.PaperOut => "Paper out",
                MdWinPrinterStatus.ManualFeed => "Manual feed",
                MdWinPrinterStatus.PaperProblem => "Paper problem",
                MdWinPrinterStatus.Offline => "Offline",
                MdWinPrinterStatus.IoActive => "Io active",
                MdWinPrinterStatus.Busy => "Busy",
                MdWinPrinterStatus.Printing => "Printing",
                MdWinPrinterStatus.OutputBinFull => "Output bin full",
                MdWinPrinterStatus.NotAvailable => "Not available",
                MdWinPrinterStatus.Waiting => "Waiting",
                MdWinPrinterStatus.Processing => "Processing",
                MdWinPrinterStatus.Initialization => "Initialization",
                MdWinPrinterStatus.WarmingUp => "Warming up",
                MdWinPrinterStatus.TonerLow => "Toner low",
                MdWinPrinterStatus.NoToner => "No toner",
                MdWinPrinterStatus.PagePunt => "Page punt",
                MdWinPrinterStatus.UserInterventionRequired => "User intervention required",
                MdWinPrinterStatus.OutOfMemory => "Out of memory",
                MdWinPrinterStatus.DoorOpen => "Door open",
                MdWinPrinterStatus.ServerUnknown => "Server unknown",
                MdWinPrinterStatus.PowerSave => "Power save",
                _ => "Status reading error!",
            },
        };

    #endregion
}