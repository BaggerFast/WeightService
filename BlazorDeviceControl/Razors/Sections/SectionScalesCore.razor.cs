﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Core;

namespace BlazorDeviceControl.Razors.Sections;

public partial class SectionScalesCore : RazorPageBase
{
    #region Public and private fields, properties, constructor

    [Parameter] public bool IsPluNew { get; set; }
    private List<ScaleModel> ItemsCast
    {
        get => Items == null ? new() : Items.Select(x => (ScaleModel)x).ToList();
        set => Items = !value.Any() ? null : new(value);
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
		        Table = new TableScaleModel(SqlTableScaleEnum.Scales);
		        IsShowMarkedFilter = true;
				ItemsCast = new();
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
	            ItemsCast = AppSettings.DataAccess.GetListScales(IsShowMarked, IsShowOnlyTop, false);

                ButtonSettings = new(true, true, true, true, true, false, false);
            }
        });
    }

    #endregion
}
