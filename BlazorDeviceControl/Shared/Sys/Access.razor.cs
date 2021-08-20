﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.DAL.TableSystemModels;
using BlazorCore.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDeviceControl.Shared.Sys
{
    public partial class Access
    {
        #region Public and private fields and properties

        public List<AccessEntity> Items { get; set; }

        #endregion

        #region Public and private methods

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);
            RunTasks($"{LocalizationStrings.DeviceControl.Method} {nameof(SetParametersAsync)}", "", LocalizationStrings.Share.DialogResultFail, "",
                new List<Task> {
                    new(async() => {
                        UidItem = null;
                        Items = null;
                        await GuiRefreshWithWaitAsync();

                        object[] objects = AppSettings.DataAccess.GetEntitiesNativeObject(SqlQueries.GetAccess, string.Empty, 0, string.Empty);
                        Items = new List<AccessEntity>();
                        foreach (object obj in objects)
                        {
                            if (obj is object[] { Length: 5 } item)
                            {
                                if (Guid.TryParse(Convert.ToString(item[0]), out Guid uid))
                                {
                                    Items.Add(new AccessEntity()
                                    {
                                        Uid = uid,
                                        CreateDt = Convert.ToDateTime(item[1]),
                                        ChangeDt = Convert.ToDateTime(item[2]),
                                        User = Convert.ToString(item[3]),
                                        Level = item[4] == null ? null : Convert.ToBoolean(item[4]),
                                    });
                                }
                            }
                        }
                        await GuiRefreshWithWaitAsync();
                      }),
                  }, true);
        }

        #endregion
    }
}
