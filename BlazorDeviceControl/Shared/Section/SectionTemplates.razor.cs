﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Models;
using DataCore;
using DataCore.Sql.Models;
using DataCore.Sql.TableScaleModels;
using DataCore.Localizations;
using DataCore.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataCore.ShareEnums;

namespace BlazorDeviceControl.Shared.Section
{
    public partial class SectionTemplates
    {
        #region Public and private fields and properties

        private List<TypeEntity<string>>? TemplateCategories { get; set; }
        private string? TemplateCategory { get; set; } = string.Empty;
        private List<TemplateEntity> ItemsCast => Items == null ? new() : Items.Select(x => (TemplateEntity)x).ToList();

        #endregion

        #region Constructor and destructor

        public SectionTemplates() : base()
        {
            //
        }

        #endregion

        #region Public and private methods

        private void Default()
        {
            IsLoaded = false;
            Table = new TableScaleEntity(ProjectsEnums.TableScale.Templates);
            TemplateCategories = DataSourceDicsEntity.GetTemplateCategories();
            TemplateCategory = null;
            Items = new();
            ButtonSettings = new();
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);
            RunTasks($"{LocaleCore.Action.ActionMethod} {nameof(SetParametersAsync)}", "", LocaleCore.Dialog.DialogResultFail, "",
                new Task(async () =>
                {
                    Default();
                    await GuiRefreshWithWaitAsync();

                    if (string.IsNullOrEmpty(TemplateCategory))
                    {
                        TemplateCategory = TemplateCategories.FirstOrDefault()?.Value;
                        Items = AppSettings.DataAccess.Crud.GetEntities<TemplateEntity>(
                            (IsShowMarkedItems == true) ? null
                                : new FieldListEntity(new Dictionary<DbField, object?> { { DbField.IsMarked, false } }),
                            new FieldOrderEntity(DbField.CategoryId, DbOrderDirection.Asc),
                            IsSelectTopRows ? AppSettings.DataAccess.JsonSettingsLocal.SelectTopRowsCount : 0)
                            ?.ToList<BaseEntity>();
                    }
                    else
                    {
                        Items = AppSettings.DataAccess.Crud.GetEntities<TemplateEntity>(
                            (IsShowMarkedItems == true)
                                ? new FieldListEntity(new Dictionary<DbField, object?> { { DbField.CategoryId, TemplateCategory } })
                                : new FieldListEntity(new Dictionary<DbField, object?> { { DbField.IsMarked, false }, { DbField.CategoryId, TemplateCategory } }),
                            new FieldOrderEntity(DbField.CategoryId, DbOrderDirection.Asc),
                            IsSelectTopRows ? AppSettings.DataAccess.JsonSettingsLocal.SelectTopRowsCount : 0)
                            ?.ToList<BaseEntity>();
                    }
                    ButtonSettings = new(true, true, true, true, true, false, false);
                    IsLoaded = true;
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        #endregion
    }
}
