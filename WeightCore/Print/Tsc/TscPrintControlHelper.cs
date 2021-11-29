﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MvvmHelpers;
using System.Threading;
using WeightCore.Zpl;

namespace WeightCore.Print.Tsc
{
    public class TscPrintControlHelper : BaseViewModel
    {
        #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static TscPrintControlHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static TscPrintControlHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public and private fields and properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _ipAddress;
        public string IpAddress
        {
            get => _ipAddress;
            set
            {
                _ipAddress = value;
                OnPropertyChanged();
            }
        }
        private int _port;
        public int Port
        {
            get => _port;
            set
            {
                _port = value;
                OnPropertyChanged();
            }
        }
        private PrintLabelSize _size;
        public PrintLabelSize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }
        private PrintDpi _dpi;
        public PrintDpi Dpi
        {
            get => _dpi;
            set
            {
                _dpi = value;
                OnPropertyChanged();
            }
        }
        private ushort _feedMm;
        public ushort FeedMm
        {
            get => _feedMm;
            set
            {
                _feedMm = value;
                OnPropertyChanged();
            }
        }
        private readonly TscPrintSetupHelper TscPrintSetup = TscPrintSetupHelper.Instance;
        private int _cutterValue;
        public int CutterValue
        {
            get => _cutterValue;
            set
            {
                _cutterValue = value;
                OnPropertyChanged();
            }
        }
        private bool _isClearBuffer;
        public bool IsClearBuffer
        {
            get => _isClearBuffer;
            set
            {
                _isClearBuffer = value;
                OnPropertyChanged();
            }
        }

        private string _textPrepare;
        public string TextPrepare
        {
            get => _textPrepare;
            set
            {
                _textPrepare = value;
                OnPropertyChanged();
            }
        }
        private string _cmd;
        public string Cmd
        {
            get => _cmd;
            set
            {
                _cmd = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public void Init(string name, string ip, int port = 9100, PrintLabelSize size = PrintLabelSize.Size80x100, PrintDpi dpi = PrintDpi.Dpi300)
        {
            Name = name;
            IpAddress = ip;
            Port = port;
            Size = size;
            Dpi = dpi;
            TscPrintSetup.Init(Size);
            IsClearBuffer = true;
        }

        #endregion

        #region Public and private methods - Base

        //public void SetupHardware(PrintLabelSize size, bool isResetGap)
        public void SetupHardware(PrintLabelSize size)
        {
            if (string.IsNullOrEmpty(Name))
                return;
            //TSCSDK.driver tscDriver = new();
            //if (!tscDriver.openport(Name))
            //    return;
            //tscDriver.clearbuffer();

            TscPrintSetup.Init(size);
            //if (isResetGap)
            //    CmdSetGap();

            //tscDriver.setup(
            //    TscPrintSetup.Width,
            //    TscPrintSetup.Height,
            //    TscPrintSetup.Speed,
            //    TscPrintSetup.Density,
            //    TscPrintSetup.Sensor,
            //    TscPrintSetup.Vertical,
            //    TscPrintSetup.Offset);

            //tscDriver.closeport();
        }

        #endregion

        #region Public and private methods - Commented

        //public PrintStatus GetStatusAsEnum(byte? value)
        //{
        //    return value switch
        //    {
        //        // Normal
        //        0x00 => 0x00,
        //        // Head opened
        //        0x01 => (PrintStatus)0x01,
        //        // Paper Jam
        //        0x02 => (PrintStatus)0x02,
        //        // Paper Jam and head opened
        //        0x03 => (PrintStatus)0x03,
        //        // Out of paper
        //        0x04 => (PrintStatus)0x04,
        //        // Out of paper and head opened
        //        0x05 => (PrintStatus)0x05,
        //        // Out of ribbon
        //        0x08 => (PrintStatus)0x08,
        //        // Out of ribbon and head opened
        //        0x09 => (PrintStatus)0x09,
        //        // Out of ribbon and paper jam
        //        0x0A => (PrintStatus)0x0A,
        //        // Out of ribbon, paper jam and head opened
        //        0x0B => (PrintStatus)0x0B,
        //        // Out of ribbon and out of paper
        //        0x0C => (PrintStatus)0x0C,
        //        // Out of ribbon, out of paper and head opened
        //        0x0D => (PrintStatus)0x0D,
        //        // Pause
        //        0x10 => (PrintStatus)0x10,
        //        // Printing
        //        0x20 => (PrintStatus)0x20,
        //        _ => PrintStatus.HundredTwentyEight,
        //    };
        //}

        //public bool GetDriverStatus(Callback callbackPrintManagerClose)
        //{
        //    TSCSDK.driver tscDriver = new();
        //    bool result = tscDriver.driver_status(Name);

        //    tscDriver.closeport();
        //    callbackPrintManagerClose?.Invoke();
        //    return result;
        //}

        //public string GetStatusAsStringRus(byte? value) => value switch
        //{
        //    // Normal
        //    0x00 => "Нормальный",
        //    // Head opened
        //    0x01 => "Голова открыта",
        //    // Paper Jam
        //    0x02 => "Замятие бумаги",
        //    // Paper Jam and head opened
        //    0x03 => "Замятие бумаги и открыта голова",
        //    // Out of paper
        //    0x04 => "Нет бумаги",
        //    // Out of paper and head opened
        //    0x05 => "Нет бумаги и голова открыта",
        //    // Out of ribbon
        //    0x08 => "Нет ленты",
        //    // Out of ribbon and head opened
        //    0x09 => "Нет ленты и голова открыта",
        //    // Out of ribbon and paper jam
        //    0x0A => "Закончилась лента и застряла бумага",
        //    // Out of ribbon, paper jam and head opened
        //    0x0B => "Закончилась лента, застряла бумага и голова открыта",
        //    // Out of ribbon and out of paper
        //    0x0C => "Нет ленты и нет бумаги",
        //    // Out of ribbon, out of paper and head opened
        //    0x0D => "Нет ленты, нет бумаги и голова открыта",
        //    // Pause
        //    0x10 => "Пауза",
        //    // Printing
        //    0x20 => "Печать",
        //    _ => "Другая ошибка",
        //};

        //public string GetStatusAsStringEng(byte? value) => value switch
        //{
        //    // Normal
        //    0x00 => "Normal",
        //    // Head opened
        //    0x01 => "Head opened",
        //    // Paper Jam
        //    0x02 => "Paper Jam",
        //    // Paper Jam and head opened
        //    0x03 => "Paper Jam and head opened",
        //    // Out of paper
        //    0x04 => "Out of paper",
        //    // Out of paper and head opened
        //    0x05 => "Out of paper and head opened",
        //    // Out of ribbon
        //    0x08 => "Out of ribbon",
        //    // Out of ribbon and head opened
        //    0x09 => "Out of ribbon and head opened",
        //    // Out of ribbon and paper jam
        //    0x0A => "Out of ribbon and paper jam",
        //    // Out of ribbon, paper jam and head opened
        //    0x0B => "Out of ribbon, paper jam and head opened",
        //    // Out of ribbon and out of paper
        //    0x0C => "Out of ribbon and out of paper",
        //    // Out of ribbon, out of paper and head opened
        //    0x0D => "Out of ribbon, out of paper and head opened",
        //    // Pause
        //    0x10 => "Pause",
        //    // Printing
        //    0x20 => "Printing",
        //    _ => "Other error",
        //};

        //public void CmdSetGap(double gapSize = 3.5, double gapOffset = 0.0)
        //{
        //    string strGapSize = $"{gapSize}".Replace(',', '.');
        //    string strGapOffset = $"{gapOffset}".Replace(',', '.');
        //    CmdSendCustom($"GAP {strGapSize} mm, {strGapOffset} mm");
        //}

        //public void CmdSetCutter(int value)
        //{
        //    if (value >= 0)
        //        CmdSendCustom($"SET CUTTER {value}");
        //}

        #endregion

        #region Public and private methods

        public void SendCmd(string cmd)
        {
            if (string.IsNullOrEmpty(Name))
                return;
            Cmd = cmd;

            TSCSDK.driver tscDriver = new();
            if (!tscDriver.openport(Name))
                return;
            tscDriver.clearbuffer();

            if (!string.IsNullOrEmpty(Cmd))
                tscDriver.sendcommand(Cmd);

            tscDriver.closeport();
        }

        public void CmdConvertZpl(bool isUsePicReplace)
        {
            Cmd = ZplPipeUtils.ToCodePoints(TextPrepare);
            if (isUsePicReplace)
            {
                Cmd = Cmd.Replace("[EAC_107x109_090]", ZplSamples.GetEac);
                Cmd = Cmd.Replace("[FISH_94x115_000]", ZplSamples.GetFish);
                Cmd = Cmd.Replace("[TEMP6_116x113_090]", ZplSamples.GetTemp6);
            }
        }

        #endregion
    }
}
