﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Sections.Plus;

public partial class SectionPlus : RazorPageBase
{
	#region Public and private fields, properties, constructor

	[Parameter] public List<PluModel> ItemsCast
	{
		get => Items is null ? new() : Items.Select(x => (PluModel)x).ToList();
		set => Items = value.Cast<TableBaseModel>().ToList();
	}

	#endregion

	#region Public and private methods

	protected override void OnInitialized()
	{
		base.OnInitialized();

		RunActionsInitialized(new()
		{
			() =>
			{
				Table = new TableScaleModel(SqlTableScaleEnum.Plus);
				IsShowMarkedFilter = true;
				Items = new();
			}
		});
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		RunActionsParametersSet(new()
		{
			() =>
			{
				ItemsCast = AppSettings.DataAccess.GetListPlus(IsShowMarked, IsShowOnlyTop, false);

				ButtonSettings = new(false, false, true, true, false, false, false);
			}
		});
	}

	#endregion
}
