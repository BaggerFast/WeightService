﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore;
using DataProjectsCore;
using DataProjectsCore.Helpers;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using WeightCore.Gui;

namespace WeightCore.Helpers
{
    public class ExceptionHelper
    {
        #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static ExceptionHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static ExceptionHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Constructor and destructor

        public ExceptionHelper() { }

        #endregion

        #region Public and private fields and properties

        private LogHelper Log { get; set; } = LogHelper.Instance;

        #endregion

        #region Public and private methods

        public void Catch(IWin32Window owner, ref Exception ex, bool isShowException,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            lock (WpfPageLoader.Locker)
            {
                Log.Error(ex.Message, filePath, memberName, lineNumber);
                if (ex.InnerException != null)
                    Log.Error(ex.InnerException.Message, filePath, memberName, lineNumber);
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;

                // WPF MessageBox.
                if (isShowException)
                {
                    using WpfPageLoader wpfPageLoader = new(ProjectsEnums.Page.MessageBox, false) { Width = 700, Height = 400 };
                    wpfPageLoader.MessageBox.Caption = LocalizationData.ScalesUI.Exception;
                    wpfPageLoader.MessageBox.Message =
                        @$"{LocalizationData.ScalesUI.Method}: {memberName}." + Environment.NewLine +
                        $"{LocalizationData.ScalesUI.Line}: {lineNumber}." + Environment.NewLine + Environment.NewLine + msg;
                    wpfPageLoader.MessageBox.ButtonOkVisibility = System.Windows.Visibility.Visible;
                    wpfPageLoader.MessageBox.Localization();
                    if (owner != null)
                        wpfPageLoader.ShowDialog(owner);
                    else
                        wpfPageLoader.ShowDialog();
                    wpfPageLoader.Close();
                    wpfPageLoader.Dispose();
                }
            }
        }

        #endregion
    }
}
