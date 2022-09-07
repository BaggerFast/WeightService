﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Sections;

public partial class SectionNomenclatures : RazorPageBase
{
    #region Public and private fields, properties, constructor

    private List<NomenclatureModel> ItemsCast
    {
        get => Items is null ? new() : Items.Select(x => (NomenclatureModel)x).ToList();
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
		        Table = new TableScaleModel(SqlTableScaleEnum.Nomenclatures);
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
	            ItemsCast = AppSettings.DataAccess.GetListNomenclatures(IsShowMarked, IsShowOnlyTop, false);

                ButtonSettings = new(true, true, true, true, true, false, false);
            }
        });
    }

    #endregion
}
