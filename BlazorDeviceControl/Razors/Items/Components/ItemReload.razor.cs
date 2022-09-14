﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Razors;

namespace BlazorDeviceControl.Razors.Items.Components;

public partial class ItemReload<TItem> : RazorPageItemBase<TItem> where TItem : SqlTableBase, new()
{
	#region Public and private fields, properties, constructor

	public ItemReload()
	{
		RazorPageConfig.IsShowFilterAdditional = false;
	}

	#endregion

	#region Public and private methods

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		RunActionsParametersSet(new()
		{
			//
		});
	}

	#endregion
}
