﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.PlusWeighings;

namespace BlazorDeviceControl.Razors.SectionComponents.Plus;

public partial class SectionPluWeightings : RazorComponentSectionBase<PluWeighingModel, SqlTableBase>
{
	#region Public and private fields, properties, constructor

	public SectionPluWeightings() : base()
	{
        ButtonSettings = new(false, true, false, true, false, false, false);
    }

	#endregion

	#region Public and private methods

	protected override void OnParametersSet()
	{
		RunActionsParametersSet(new()
		{
			() =>
			{
				SqlSectionCast = DataContext.GetListNotNullable<PluWeighingModel>(SqlCrudConfigSection);
            }
		});
	}

	#endregion
}