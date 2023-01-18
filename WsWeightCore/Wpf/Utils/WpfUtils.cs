﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using DataCore.Sql.TableScaleModels.Devices;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using WeightCore.Gui;
using WeightCore.Helpers;
using WsLocalization.Models;

namespace WeightCore.Wpf.Utils;

/// <summary>
/// Show WPF form inside WinForm.
/// </summary>
public static class WpfUtils
{
    #region Public and private fields, properties, constructor

    private static DataAccessHelper DataAccess { get; } = DataAccessHelper.Instance;
    private static WpfPageLoader WpfPage { get; set; } = new();

    #endregion

    #region Public and private methods

    /// <summary>
    /// Show pin-code form.
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public static bool ShowNewPinCode(IWin32Window owner)
    {
        using PasswordForm passwordForm = new();
        DialogResult resultPsw = passwordForm.ShowDialog(owner);
        passwordForm.Close();
        passwordForm.Dispose();
        return resultPsw == DialogResult.OK;
    }

    public static void Dispose()
    {
        WpfPage.Close();
        WpfPage.Dispose();
    }

    /// <summary>
    /// Show new form.
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="caption"></param>
    /// <param name="message"></param>
    /// <param name="visibilitySettings"></param>
    private static DialogResult ShowNew(IWin32Window? owner, string caption, string message,
        VisibilitySettingsModel visibilitySettings)
    {
        Dispose();

        WpfPage = new(PageEnum.MessageBox, false) { Width = 700, Height = 400 };
        WpfPage.MessageBox.Caption = caption;
        WpfPage.MessageBox.Message = message;
        WpfPage.MessageBox.VisibilitySettings = visibilitySettings;
        WpfPage.MessageBox.VisibilitySettings.Localization();
        DialogResult resultWpf = owner is not null ? WpfPage.ShowDialog(owner) : WpfPage.ShowDialog();
        WpfPage.Close();
        WpfPage.Dispose();
        return resultWpf;
    }

    public static DialogResult ShowNewRegistration(string message)
    {
        Dispose();

        WpfPage = new(PageEnum.MessageBox, false) { Width = 700, Height = 400 };
        WpfPage.MessageBox.Caption = LocaleCore.Scales.Registration;
        WpfPage.MessageBox.Message = message;
        WpfPage.MessageBox.VisibilitySettings.ButtonOkVisibility = Visibility.Visible;
        WpfPage.MessageBox.VisibilitySettings.Localization();
        WpfPage.ShowDialog();
        DialogResult result = WpfPage.MessageBox.Result;
        WpfPage.Close();
        WpfPage.Dispose();
        return result;
    }

    /// <summary>
    /// Show new OperationControl form.
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="message"></param>
    /// <param name="isLog"></param>
    /// <param name="logType"></param>
    /// <param name="visibility"></param>
    /// <returns></returns>
    public static DialogResult ShowNewOperationControl(IWin32Window owner, string message, bool isLog,
        LogTypeEnum logType, VisibilitySettingsModel visibility)
    {
        if (isLog)
            ShowNewOperationControlLogType(message, logType);
        return ShowNew(owner, LocaleCore.Scales.OperationControl, message, visibility);
    }

    public static DialogResult ShowNewOperationControl(string message, bool isLog,
        LogTypeEnum logType, VisibilitySettingsModel visibility)
    {
        if (isLog)
            ShowNewOperationControlLogType(message, logType);
        return ShowNew(null, LocaleCore.Scales.OperationControl, message, visibility);
    }

    private static void ShowNewOperationControlLogType(string message, LogTypeEnum logType,
        [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
    {
        switch (logType)
        {
            case LogTypeEnum.None:
                DataAccess.LogInformationFast(message);
                break;
            case LogTypeEnum.Error:
                DataAccess.LogErrorFast(message, filePath, lineNumber, memberName);
                break;
            case LogTypeEnum.Question:
                DataAccess.LogQuestionFast(message);
                break;
            case LogTypeEnum.Warning:
                DataAccess.LogWarningFast(message);
                break;
            case LogTypeEnum.Information:
                DataAccess.LogInformationFast(message);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
        }
    }

    public static DeviceModel SetNewDeviceWithQuestion(string deviceName, string ip, string mac)
    {
        DeviceModel device = DataAccess.GetItemDeviceNotNullable(deviceName);
        if (device.IsNew)
        {
            DialogResult result = ShowNewOperationControl(
                LocaleCore.Scales.HostNotFound(deviceName) + Environment.NewLine + LocaleCore.Scales.QuestionWriteToDb,
                false, LogTypeEnum.Information,
                new() { ButtonYesVisibility = Visibility.Visible, ButtonNoVisibility = Visibility.Visible });
            if (result == DialogResult.Yes)
            {
                device = new()
                {
                    Name = deviceName,
                    PrettyName = deviceName,
                    Ipv4 = ip,
                    MacAddress = new(mac),
                    CreateDt = DateTime.Now,
                    ChangeDt = DateTime.Now,
                    LoginDt = DateTime.Now,
                    IsMarked = false,
                };
                DataAccess.Save(device);
            }
        }
        else
        {
            device.Ipv4 = ip;
            device.MacAddress = new(mac);
            device.ChangeDt = DateTime.Now;
            device.LoginDt = DateTime.Now;
            device.IsMarked = false;
            DataAccess.UpdateForce(device);
        }
        return device;
    }

    /// <summary>
    /// Show new host not found.
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public static DialogResult ShowNewHostNotFound(Guid uid)
    {
        Dispose();

        WpfPage = new(PageEnum.MessageBox, false) { Width = 700, Height = 400 };
        WpfPage.MessageBox.Caption = LocaleCore.Scales.Registration;
        WpfPage.MessageBox.Message = LocaleCore.Scales.RegistrationWarning(uid);
        WpfPage.MessageBox.VisibilitySettings.ButtonOkVisibility = Visibility.Visible;
        WpfPage.MessageBox.VisibilitySettings.Localization();
        WpfPage.ShowDialog();
        DialogResult result = WpfPage.MessageBox.Result;
        WpfPage.Close();
        WpfPage.Dispose();
        return result;
    }

    private static DialogResult CatchExceptionCore(Exception ex, IWin32Window? owner,
        bool isDbLog, bool isShowWindow, string filePath, int lineNumber, string memberName)
    {
        if (isDbLog)
            DataAccess.LogError(ex, UserSessionHelper.Instance.DeviceScaleFk.Device.Name, string.Empty, filePath, lineNumber, memberName);


        if (isShowWindow)
        {
            string message = ex.InnerException is null ? ex.Message : ex.Message + Environment.NewLine + ex.InnerException.Message;
            return ShowNew(owner, LocaleCore.Scales.Exception,
            $"{LocaleCore.Scales.Method}: {memberName}." + Environment.NewLine +
            $"{LocaleCore.Scales.Line}: {lineNumber}." + Environment.NewLine + message,
            new() { ButtonOkVisibility = Visibility.Visible });
        }

        return DialogResult.OK;
    }

    /// <summary>
    /// Show catch exception window..
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="owner"></param>
    /// <param name="isDbLog"></param>
    /// <param name="isShowWindow"></param>
    /// <param name="filePath"></param>
    /// <param name="lineNumber"></param>
    /// <param name="memberName"></param>
    /// <returns></returns>
    public static DialogResult CatchException(Exception ex, IWin32Window owner,
        bool isDbLog = false, bool isShowWindow = false,
        [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "") =>
        CatchExceptionCore(ex, owner, isDbLog, isShowWindow, filePath, lineNumber, memberName);

    /// <summary>
    /// Show catch exception window.
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="isDbLog"></param>
    /// <param name="isShowWindow"></param>
    /// <param name="filePath"></param>
    /// <param name="lineNumber"></param>
    /// <param name="memberName"></param>
    /// <returns></returns>
    public static DialogResult CatchException(Exception ex,
        bool isDbLog = false, bool isShowWindow = false,
        [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "") =>
        CatchExceptionCore(ex, null, isDbLog, isShowWindow, filePath, lineNumber, memberName);

    #endregion
}