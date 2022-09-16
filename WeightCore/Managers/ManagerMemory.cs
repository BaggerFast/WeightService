﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Localizations;
using DataCore.Memory;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using DataCore.Models;
using WeightCore.Gui;
using WeightCore.Helpers;

namespace WeightCore.Managers;

public class ManagerMemory : ManagerBase
{
	#region Public and private fields and properties

	private Label FieldMemory { get; set; }
	private Label FieldTasks { get; set; }
	private MemorySizeModel MemorySize { get; set; }
	public DebugHelper Debug { get; } = DebugHelper.Instance;

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
			Init(TaskTypeEnum.MemoryManager,
				() =>
				{
					MemorySize = new();
					FieldMemory = fieldMemory;
					FieldTasks = fieldTasks;

					MDSoft.WinFormsUtils.InvokeControl.SetText(FieldMemory, LocaleCore.Scales.Memory);
					MDSoft.WinFormsUtils.InvokeControl.SetText(FieldTasks, LocaleCore.Scales.Threads);

					if (Debug.IsDebug && !fieldMemory.Visible)
						MDSoft.WinFormsUtils.InvokeControl.SetVisible(FieldMemory, true);
					if (Debug.IsDebug && !fieldTasks.Visible)
						MDSoft.WinFormsUtils.InvokeControl.SetVisible(FieldTasks, true);
				},
				new(waitReopen: 1_000, waitRequest: 0_250, waitResponse: 0_250, waitClose: 0_500, waitException: 0_500));
		}
		catch (Exception ex)
		{
			GuiUtils.WpfForm.CatchException(null, ex, true, false);
		}
	}

	public new void Open()
	{
		try
		{
			Open(
				() =>
				{
					MemorySize.Open();
				},
				null,
				() =>
				{
					Response();
				}
			);
		}
		catch (Exception ex)
		{
			GuiUtils.WpfForm.CatchException(null, ex, true, false);
		}
	}

	private void Response()
	{
		//if (UserSessionHelper.Instance.SqlViewModel.IsTaskEnabled(TaskType.MemoryManager))
		{
			MDSoft.WinFormsUtils.InvokeControl.SetText(FieldMemory,
				$"{LocaleCore.Scales.Memory} | " +
				$"{LocaleCore.Scales.MemoryFree}: " +
				(MemorySize.PhysicalFree != null ? $"{MemorySize.PhysicalFree.MegaBytes:N0} MB" : $"- MB") +
				$" | {LocaleCore.Scales.MemoryBusy}: " + 
				(MemorySize.PhysicalCurrent != null ? $"{MemorySize.PhysicalCurrent.MegaBytes:N0} MB" : $"- MB") +
				$" | {LocaleCore.Scales.MemoryAll}: " +
				(MemorySize.PhysicalTotal != null ? $"{MemorySize.PhysicalTotal.MegaBytes:N0} MB" : $"- MB")
			);
			MDSoft.WinFormsUtils.InvokeControl.SetText(FieldTasks, $"{LocaleCore.Scales.Threads}: {Process.GetCurrentProcess().Threads.Count}");
		}
	}

	public new void Close()
	{
		base.Close();
	}

	public new void ReleaseManaged()
	{
		MDSoft.WinFormsUtils.InvokeControl.SetVisible(FieldMemory, false);
		MDSoft.WinFormsUtils.InvokeControl.SetVisible(FieldTasks, false);

		if (MemorySize != null)
		{
			MemorySize.Close();
			MemorySize.Dispose(false);
			MemorySize = null;
		}
            
		base.ReleaseManaged();
	}

	public new void ReleaseUnmanaged()
	{
		base.ReleaseUnmanaged();
	}

	#endregion
}