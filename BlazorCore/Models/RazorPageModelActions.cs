﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Localizations;
using DataCore.Protocols;
using DataCore.Sql.Core;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Environment = System.Environment;

namespace BlazorCore.Models;

public partial class RazorPageModel : LayoutComponentBase
{
    #region Public and private methods

    private void RunActionsInitialized()
    {
        IsActionsInitializedFinished = false;
        RunActionsSafe(string.Empty, LocaleCore.Dialog.DialogResultFail, ActionsInitialized);
        IsActionsInitializedFinished = true;
    }

    private void RunActionsParametersSet()
    {
        IsActionsParametersSetFinished = false;
        RunActionsSafe(string.Empty, LocaleCore.Dialog.DialogResultFail, ActionsParametersSet);
        IsActionsParametersSetFinished = true;
        //StateHasChanged();
    }

    protected void RunActionsSilent(List<Action> actions)
    {
        RunActionsSafe(string.Empty, LocaleCore.Dialog.DialogResultFail, actions);
    }

    private void RunActionsSafe(string success, string fail, List<Action> actions, [CallerMemberName] string memberName = "")
    {
        try
        {
            if (actions.Any())
            {
                foreach (Action action in actions)
                {
                    action.Invoke();
                }
            }
            if (!string.IsNullOrEmpty(success))
                NotificationService.Notify(NotificationSeverity.Success,
                    $"{LocaleCore.Action.ActionMethod}: {memberName}" + Environment.NewLine, success, AppSettingsHelper.Delay);
        }
        catch (Exception ex)
        {
            CatchException(ex, memberName, fail);
        }
    }

    private void RunActionsSafe(string success, string fail, Action action) =>
        RunActionsSafe(success, fail, new List<Action>() { action });

    public void CatchException(Exception ex, string title, string fail)
    {
        // Notify log.
        string msg = ex.Message;
        if (!string.IsNullOrEmpty(ex.InnerException?.Message))
            msg += Environment.NewLine + ex.InnerException.Message;
        if (!string.IsNullOrEmpty(fail))
        {
            if (!string.IsNullOrEmpty(msg))
                NotificationService.Notify(NotificationSeverity.Error, title + Environment.NewLine, fail + Environment.NewLine + msg, AppSettingsHelper.Delay);
            else
                NotificationService.Notify(NotificationSeverity.Error, title + Environment.NewLine, fail, AppSettingsHelper.Delay);
        }
        else
        {
            if (!string.IsNullOrEmpty(msg))
                NotificationService.Notify(NotificationSeverity.Error, title + Environment.NewLine, msg, AppSettingsHelper.Delay);
        }

        // SQL log.
        AppSettings.DataAccess.LogError(ex, NetUtils.GetLocalHostName(false), nameof(BlazorCore));
    }

    private void RunActionsWithQeustion(string title, string success, string fail, string questionAdd, Action action)
    {
        try
        {
            string question = string.IsNullOrEmpty(questionAdd) ? LocaleCore.Dialog.DialogQuestion : questionAdd;
            Task<bool?> dialog = DialogService.Confirm(question, title, GetConfirmOptions());
            bool? result = dialog.Result;
            if (result == true)
            {
                RunActionsSafe(success, fail, action);
            }
        }
        catch (Exception ex)
        {
            CatchException(ex, title, fail);
        }
    }

    public void OnChange() => ActionChange.Invoke();

    private static ConfirmOptions GetConfirmOptions() => new()
    {
        OkButtonText = LocaleCore.Dialog.DialogButtonYes,
        CancelButtonText = LocaleCore.Dialog.DialogButtonCancel
    };

    #endregion
}
