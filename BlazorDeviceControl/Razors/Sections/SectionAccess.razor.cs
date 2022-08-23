﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Sections;

public partial class SectionAccess : BlazorCore.Models.RazorBase
{
    #region Public and private fields, properties, constructor

    private List<AccessEntity> ItemsCast => Items == null ? new() : Items.Select(x => (AccessEntity)x).ToList();

    #endregion

    #region Public and private methods

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Table = new TableSystemEntity(ProjectsEnums.TableSystem.Accesses);
        Items = new();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        RunActions(new()
        {
            () =>
            {
                Items = AppSettings.DataAccess.Crud.GetEntities<AccessEntity>(
                        IsShowMarkedItems ? null
                            : new FilterListEntity(new() { new(DbField.IsMarked, DbComparer.Equal, false) }),
                        new(DbField.User),
                        IsSelectTopRows ? AppSettings.DataAccess.JsonSettingsLocal.SelectTopRowsCount : 0)
                    ?.ToList<BaseEntity>();
                ButtonSettings = new(true, false, true, true, true, false, false);
            }
        });
    }

    public void RowRender(RowRenderEventArgs<AccessEntity> args)
    {
        args.Attributes.Add("class", UserSettings.Identity.GetColorAccessRights(args.Data.Rights));
        //RowCounter += 1;
    }

    #endregion
}