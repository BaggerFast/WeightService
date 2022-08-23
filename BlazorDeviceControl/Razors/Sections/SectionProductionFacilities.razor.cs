﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Sections;

/// <summary>
/// Section ProductionFacilities.
/// </summary>
public partial class SectionProductionFacilities : BlazorCore.Models.RazorBase
{
    #region Public and private fields, properties, constructor

    private List<ProductionFacilityEntity> ItemsCast => Items == null ? new() : Items.Select(x => (ProductionFacilityEntity)x).ToList();

    #endregion

    #region Public and private methods

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Table = new TableScaleEntity(ProjectsEnums.TableScale.ProductionFacilities);
        Items = new();
	}

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        RunActions(new()
        {
            () =>
            {
                Items = AppSettings.DataAccess.Crud.GetEntities<ProductionFacilityEntity>(
                    IsShowMarkedItems ? null : new FilterListEntity(new() { new(DbField.IsMarked, DbComparer.Equal, false)}),
                    new(DbField.Name),
                    IsSelectTopRows ? AppSettings.DataAccess.JsonSettingsLocal.SelectTopRowsCount : 0)
                    ?.Where(x => x.IdentityId > 0).ToList<BaseEntity>();
                ButtonSettings = new(true, true, true, true, true, false, false);
            }
        });
    }

    #endregion
}