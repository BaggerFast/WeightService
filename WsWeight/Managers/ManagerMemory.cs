﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows.Forms;
using DataCore.Memory;
using WsLocalization.Models;
using WsWeight.Wpf.Utils;

namespace WsWeight.Managers;
#nullable enable

public class ManagerMemory : ManagerBase
{
    #region Public and private fields and properties

    private Label FieldMemory { get; set; }
    private Label FieldTasks { get; set; }
    private MemorySizeModel MemorySize { get; set; }
    
    #endregion

    #region Constructor and destructor

    public ManagerMemory() : base()
    {
        Init(Close, ReleaseManaged, ReleaseUnmanaged);
    }

    #endregion

    #region Public and private methods

    public void Init(Label fieldMemory, Label fieldTasks)
    {
        try
        {
            Init(TaskType.TaskMemory,
                () =>
                {
                    MemorySize = new();
                    FieldMemory = fieldMemory;
                    FieldTasks = fieldTasks;

                    MDSoft.WinFormsUtils.InvokeControl.SetText(FieldMemory, LocaleCore.Scales.Memory);
                    MDSoft.WinFormsUtils.InvokeControl.SetText(FieldTasks, LocaleCore.Scales.Threads);
                },
                new(waitReopen: 0_250, waitRequest: 0_250, waitResponse: 0_250, waitClose: 0_250, waitException: 0_250));
        }
        catch (Exception ex)
        {
            WpfUtils.CatchException(ex);
        }
    }

    public new void Open()
    {
        try
        {
            Open(MemorySize.Open, null, Response);
        }
        catch (Exception ex)
        {
            WpfUtils.CatchException(ex);
        }
    }

    private void Response()
    {
        MDSoft.WinFormsUtils.InvokeControl.SetText(FieldMemory, 
            $"{LocaleCore.Scales.Memory}" +
            $" | {LocaleCore.Scales.MemoryBusy}: " +
            (MemorySize.PhysicalCurrent is not null ? $"{MemorySize.PhysicalCurrent.MegaBytes:N0} MB" : "- MB") +
            $" | {LocaleCore.Scales.MemoryFree}: " +
            (MemorySize.PhysicalFree is not null ? $"{MemorySize.PhysicalFree.MegaBytes:N0} MB" : "- MB") +
            $" | {LocaleCore.Scales.MemoryAll}: " +
            (MemorySize.PhysicalTotal is not null ? $"{MemorySize.PhysicalTotal.MegaBytes:N0} MB" : "- MB")
        );
        MDSoft.WinFormsUtils.InvokeControl.SetText(FieldTasks, 
            $"{LocaleCore.Scales.Threads}: {Process.GetCurrentProcess().Threads.Count}");
    }

    public new void Close() => base.Close();

    public new void ReleaseManaged()
    {
        MemorySize.Close();
        MemorySize.Dispose(false);

        base.ReleaseManaged();
    }

    public new void ReleaseUnmanaged() => base.ReleaseUnmanaged();

    #endregion
}