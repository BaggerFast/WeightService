﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore;
using DataCore.DAL.Models;
using DataCore.DAL.TableScaleModels;
using DataCore.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DataCore.ShareEnums;

namespace BlazorDeviceControl.Shared.Item
{
    public partial class ItemTaskModule
    {
        #region Public and private fields and properties

        public TaskEntity ItemCast { get => Item == null ? new() : (TaskEntity)Item; set => Item = value; }

        #endregion

        #region Constructor and destructor

        public ItemTaskModule() : base()
        {
            //
        }

        #endregion

        #region Public and private methods

        private void Default()
        {
            IsLoaded = false;
            Table = new TableSystemEntity(ProjectsEnums.TableSystem.Tasks);
            ItemCast = new();
            ButtonSettings = new();
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(SetParametersAsync)}", "", LocalizationCore.Strings.DialogResultFail, "",
                new Task(async () =>
                {
                    Default();
                    await GuiRefreshWithWaitAsync();

                    ItemCast = AppSettings.DataAccess.Crud.GetEntity<TaskEntity>(
                        new FieldListEntity(new Dictionary<string, object?> {{ DbField.IdentityUid.ToString(), IdentityUid },
                    }), null);
                    if (IdentityId != null && TableAction == DbTableAction.New)
                        ItemCast.IdentityId = (long)IdentityId;
                    ButtonSettings = new(false, false, false, false, false, true, true);
                    IsLoaded = true;
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        #endregion
    }
}