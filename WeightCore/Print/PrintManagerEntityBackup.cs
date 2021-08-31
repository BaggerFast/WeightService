﻿//// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
//// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

//using WeightCore.Print.Tsc;
//using log4net;
//using System;
//using System.Collections.Concurrent;
//using System.Threading;
//using System.Threading.Tasks;
//using Zebra.Sdk.Comm;
//using Zebra.Sdk.Printer;

//namespace WeightCore.Print
//{
//    public class PrintManagerEntity
//    {
//        #region Public and private fields and properties

//        public string Peeler { get; private set; }
//        public int UserLabelCount { get; private set; }
//        public PrinterStatus CurrentStatus { get; private set; }
//        public int CommandThreadTimeOut { get; }
//        public delegate void OnHandler(PrintManagerEntity state);
//        public event OnHandler Notify;
//        private readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        public Connection Con { get; private set; }
//        public ConcurrentQueue<string> CmdQueue { get; } = new ConcurrentQueue<string>();
//        private readonly object _locker = new object();
//        private Thread _sessionSharingThread = null;
//        private bool _isThreadWork = true;
//        public PrintControlEntity PrintControl { get; set; }

//        #endregion

//        #region Constructor and destructor

//        public PrintManagerEntity(Connection connection, string ip, int port, int commandThreadTimeOut = 1_000)
//        {
//            CommandThreadTimeOut = commandThreadTimeOut;
//            Con = connection;
//            PrintControl = new PrintControlEntity(PrintInterface.Ethernet, ip, port);
//        }

//        public PrintManagerEntity(string ip, int port, int commandThreadTimeOut = 1_000)
//        {
//            //var zebraCurrentState = new StateEntity();
//            CommandThreadTimeOut = commandThreadTimeOut;
//            Con = new TcpConnection(ip, port);
//            PrintControl = new PrintControlEntity(PrintInterface.Ethernet, ip, port);
//        }

//        #endregion

//        #region Public and private methods

//        /// <summary>
//        /// Отправить задание в очередь печати.
//        /// </summary>
//        /// <param name="printCmd"></param>
//        public async void SendAsync(string printCmd)
//        {
//            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
//            CmdQueue.Enqueue(printCmd);
//        }

//        public void Open(bool isTscPrinter)
//        {
//            Con.Open();
//            _isThreadWork = true;
//            if (isTscPrinter)
//                OpenTsc();
//            else
//                OpenZebra();
//        }

//        public void OpenZebra()
//        {
//            var printerDevice = ZebraPrinterFactory.GetInstance(Con);
//            _sessionSharingThread = new Thread(t =>
//            {
//                while (_isThreadWork)
//                {
//                    lock (_locker)
//                    {
//                        try
//                        {
//                            CurrentStatus = printerDevice.GetCurrentStatus();
//                            UserLabelCount = int.Parse(SGD.GET("odometer.user_label_count", printerDevice.Connection));
//                            Peeler = SGD.GET("sensor.peeler", printerDevice.Connection);

//                            if (CurrentStatus.isReadyToPrint)
//                            {
//                                if (Peeler == "clear")
//                                {
//                                    if (CmdQueue.TryDequeue(out var request))
//                                    {
//                                        request = request.Replace("|", "\\&");
//                                        printerDevice.SendCommand(request);
//                                    }
//                                }
//                            }
//                            Notify?.Invoke(this);
//                        }
//                        catch (ConnectionException e)
//                        {
//                            _log.Error(e.ToString());
//                        }
//                        catch (ZebraPrinterLanguageUnknownException e)
//                        {
//                            _log.Error(e.ToString());
//                        }
//                        catch (Exception e)
//                        {
//                            _log.Error(e.ToString());
//                        }
//                    }
//                    Thread.Sleep(CommandThreadTimeOut);
//                    System.Windows.Forms.Application.DoEvents();
//                }
//            })
//            { IsBackground = true };
//            _sessionSharingThread.Start();
//            Thread.Sleep(CommandThreadTimeOut);
//        }

//        public void OpenTsc()
//        {
//            _sessionSharingThread = new Thread(t =>
//            {
//                UserLabelCount = 1;
//                while (_isThreadWork)
//                {
//                    lock (_locker)
//                    {
//                        try
//                        {
//                            if (CmdQueue.TryDequeue(out var request))
//                            {
//                                request = request.Replace("|", "\\&");
//                                if (!request.Equals("^XA~JA^XZ") && !request.Contains("odometer.user_label_count"))
//                                {
//                                    var taskPrint = new Task(async () =>
//                                    {
//                                        PrintControl.Cmd.SendCustom(false, request, false);
//                                        await Task.Delay(TimeSpan.FromMilliseconds(CommandThreadTimeOut)).ConfigureAwait(true);
//                                    });
//                                    taskPrint.Start();
//                                }
//                            }
//                            Notify?.Invoke(this);
//                        }
//                        catch (ConnectionException e)
//                        {
//                            _log.Error(e.ToString());
//                        }
//                        catch (ZebraPrinterLanguageUnknownException e)
//                        {
//                            _log.Error(e.ToString());
//                        }
//                        catch (Exception e)
//                        {
//                            _log.Error(e.ToString());
//                        }
//                    }
//                    Thread.Sleep(CommandThreadTimeOut);
//                    System.Windows.Forms.Application.DoEvents();
//                }
//            })
//            { IsBackground = true };
//            _sessionSharingThread.Start();
//            Thread.Sleep(CommandThreadTimeOut);
//        }

//        public void Close()
//        {
//            if (_sessionSharingThread != null && _sessionSharingThread.IsAlive)
//            {
//                _isThreadWork = false;
//                Thread.Sleep(5 * CommandThreadTimeOut);
//                _sessionSharingThread.Join(10);
//                _sessionSharingThread.Abort();
//                _sessionSharingThread = null;
//            }
//            Con.Close();
//        }

//        public void ClearPrintBuffer(bool isTscPrinter)
//        {
//            while (!CmdQueue.IsEmpty)
//            {
//                CmdQueue.TryDequeue(out _);
//            }
//            if (isTscPrinter)
//            {
//                PrintControl.Cmd.ClearBuffer(true);
//            }
//            else
//            {
//                CmdQueue.Enqueue("^XA~JA^XZ");
//            }
//        }

//        public void SetOdometorUserLabel(int value)
//        {
//            CmdQueue.Enqueue($"! U1 setvar \"odometer.user_label_count\" \"{value}\"\r\n");
//        }

//        #endregion
//    }
//}