﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Razors;

namespace BlazorDeviceControl.Razors.Sections;

/// <summary>
/// Section ProductionFacilities.
/// </summary>
public partial class SectionProductionFacilities : RazorPageSectionBase<ProductionFacilityModel>
{
    #region Public and private fields, properties, constructor

    public SectionProductionFacilities()
    {
	    RazorPageConfig.IsShowFilterMarked = true;
    }

    #endregion

    #region Public and private methods

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        RunActionsParametersSet(new()
        {
            () =>
            {
	            ItemsCast = AppSettings.DataAccess.GetListProductionFacilities(RazorPageConfig.IsShowMarked, RazorPageConfig.IsShowOnlyTop, false);

                ButtonSettings = new(true, true, true, true, true, false, false);
            }
        });
    }

    #endregion
}
