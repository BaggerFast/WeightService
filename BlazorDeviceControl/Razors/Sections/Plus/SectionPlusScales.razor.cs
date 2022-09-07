﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Sections.Plus;

public partial class SectionPlusScales : RazorPageBase
{
	#region Public and private fields, properties, constructor

	[Parameter] public List<PluScaleModel> ItemsCast
	{
		get => Items is null ? new() : Items.Select(x => (PluScaleModel)x).ToList();
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
				Table = new TableScaleModel(SqlTableScaleEnum.PlusScales);
				IsShowAdditionalFilter = true;
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
				ItemsCast = AppSettings.DataAccess.GetListPluScales(IsShowMarked, IsShowOnlyTop, Item);

				ButtonSettings = new(true, true, true, true, true, true, false);
			}
		});
	}

	#endregion
}
