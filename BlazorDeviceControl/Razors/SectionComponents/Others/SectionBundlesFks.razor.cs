﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Razors;
using DataCore.Sql.TableScaleFkModels.BundlesFks;

namespace BlazorDeviceControl.Razors.SectionComponents.Others;

public partial class SectionBundlesFks : RazorComponentSectionBase<BundleFkModel, SqlTableBase>
{
	#region Public and private fields, properties, constructor

	public SectionBundlesFks()
	{
		SqlCrudConfigSection.IsGuiShowItemsCount = true;
		SqlCrudConfigSection.IsGuiShowFilterMarked = true;
	}

	#endregion

	#region Public and private methods

	protected override void OnParametersSet()
	{
		RunActionsParametersSet(new()
		{
			() =>
			{
				SqlSectionCast = DataContext.GetListNotNullable<BundleFkModel>(SqlCrudConfigSection);

				ButtonSettings = new(true, true, true, true, true, false, false);
			}
		});
	}

	#endregion
}