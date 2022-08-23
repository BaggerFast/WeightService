﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Items.Measurements;

public partial class ItemLabel : BlazorCore.Models.RazorBase
{
    #region Public and private fields, properties, constructor

    private LabelEntity ItemCast { get => Item == null ? new() : (LabelEntity)Item; set => Item = value; }

    #endregion

    #region Public and private methods

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Table = new TableScaleEntity(ProjectsEnums.TableScale.Labels);
        ItemCast = new();
	}

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        RunActions(new()
        {
            () =>
            {
                switch (TableAction)
                {
                    case DbTableAction.New:
                        ItemCast = new();
                        ItemCast.ChangeDt = ItemCast.CreateDt = DateTime.Now;
                        break;
                    default:
                        ItemCast = AppSettings.DataAccess.Crud.GetEntity<LabelEntity>(
                            new(new() { new(DbField.IdentityId, DbComparer.Equal, IdentityId) }));
                        break;
                }
                ButtonSettings = new(false, false, false, false, false, false, true);
            }
        });
    }

    #endregion
}