﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace WeightCore.Managers
{
    /// <summary>
    /// Task memory.
    /// </summary>
    public class DeviceManagerEntity
    {
        #region Public and private fields and properties - Manager

        public int WaitWhileMiliSeconds { get; private set; }
        public int WaitExceptionMiliSeconds { get; private set; }
        public int WaitCloseMiliSeconds { get; private set; }
        public string ExceptionMsg { get; private set; }
        public delegate Task CallbackAsync(int wait);
        public bool IsExecute { get; set; }
        private LogUtils _logUtils = LogUtils.Instance;

        #endregion

        #region Constructor and destructor

        public DeviceManagerEntity(int waitWhileMiliSeconds, int waitExceptionMiliSeconds, int waitCloseMiliSeconds)
        {
            // Manager.
            WaitWhileMiliSeconds = waitWhileMiliSeconds;
            WaitExceptionMiliSeconds = waitExceptionMiliSeconds;
            WaitCloseMiliSeconds = waitCloseMiliSeconds;
            IsExecute = false;
        }

        #endregion

        #region Public and private methods - Manager

        public void Open(CallbackAsync callback, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            IsExecute = true;
            while (IsExecute)
            {
                try
                {
                    OpenJob();
                    callback(WaitWhileMiliSeconds).ConfigureAwait(true);
                    Thread.Sleep(TimeSpan.FromMilliseconds(WaitWhileMiliSeconds));
                }
                catch (TaskCanceledException)
                {
                    // Console.WriteLine(tcex.Message);
                    // Not the problem.
                }
                catch (Exception ex)
                {
                    ExceptionMsg = ex.Message;
                    if (!string.IsNullOrEmpty(ex.InnerException?.Message))
                        ExceptionMsg += Environment.NewLine + ex.InnerException.Message;
                    _logUtils.Error(ExceptionMsg, filePath, memberName, lineNumber);
                    Thread.Sleep(TimeSpan.FromMilliseconds(WaitExceptionMiliSeconds));
                    throw;
                }
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public void Close([CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            try
            {
                IsExecute = false;
                CloseJob();
            }
            catch (Exception ex)
            {
                ExceptionMsg = ex.Message;
                if (!string.IsNullOrEmpty(ex.InnerException?.Message))
                    ExceptionMsg += Environment.NewLine + ex.InnerException.Message;
                _logUtils.Error(ExceptionMsg, filePath, memberName, lineNumber);
            }
        }

        #endregion

        #region Public and private methods

        public void OpenJob()
        {
            //
        }

        public void CloseJob()
        {
            //
        }

        #endregion
    }
}