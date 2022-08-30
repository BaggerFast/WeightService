﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Sections.Plus;

public partial class SectionPlusScales : BlazorCore.Models.RazorBase
{
	#region Public and private fields, properties, constructor

	[Parameter] public List<PluScaleEntity> ItemsCast
	{
		get => Items == null ? new() : Items.Select(x => (PluScaleEntity)x).ToList();
		set => Items = value.Cast<TableModel>().ToList();
	}
	private ScaleEntity ItemFilterCast
	{
		get => ItemFilter == null ? new() : (ScaleEntity)ItemFilter;
		set => ItemFilter = value;
	}

	#endregion

	#region Public and private methods

	protected override void OnInitialized()
	{
		base.OnInitialized();

		Table = new TableScaleEntity(ProjectsEnums.TableScale.PlusScales);
		IsShowAdditionalFilter = true;
		Items = new();
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		RunActions(new()
		{
			() =>
			{
				ItemsCast = AppSettings.DataAccess.Crud.GetListPluScales(IsShowMarked, IsShowOnlyTop, ItemFilter);

				ButtonSettings = new(true, true, true, true, true, true, false);
			}
		});
	}

	#endregion
}