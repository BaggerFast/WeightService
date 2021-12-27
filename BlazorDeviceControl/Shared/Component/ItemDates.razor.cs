﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore.DAL.TableScaleModels;
using DataShareCore;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorDeviceControl.Shared.Component
{
    public partial class ItemDates
    {
        #region Public and private fields and properties

        //[Parameter] public int Id { get; set; }
        //[Parameter] public Guid Uid { get; set; }
        [Parameter] public string DtCreate { get; set; }
        [Parameter] public string DtModify { get; set; }

        #endregion

        #region Public and private methods

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(SetParametersAsync)}", "", LocalizationCore.Strings.DialogResultFail, "",
                new Task(async() => {
                    switch (Item)
                    {
                        case ScaleEntity scaleEntity:
                            DtCreate = scaleEntity.CreateDate.ToString();
                            DtModify = scaleEntity.ModifiedDate.ToString();
                            break;
                        case PrinterEntity printerEntity:
                            DtCreate = printerEntity.CreateDate.ToString();
                            DtModify = printerEntity.ModifiedDate.ToString();
                        break;
                    }
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        #endregion
    }
}
