﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore;
using BlazorCore.DAL;
using BlazorCore.DAL.TableModels;
using BlazorCore.Models;
using BlazorCore.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDeviceControl.Shared.Item
{
    public partial class Template
    {
        #region Public and private fields and properties

        public TemplateEntity TemplateItem { get => (TemplateEntity)IdItem; set => SetItem(value); }
        public List<TypeEntity<string>> TemplateCategories { get; set; }

        #endregion

        #region Public and private methods

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);
            RunTasks($"{LocalizationStrings.DeviceControl.Method} {nameof(SetParametersAsync)}", "", LocalizationStrings.Share.DialogResultFail, "",
                new List<Task> {
                    new(async() => {
                        Table = new TableScaleEntity(EnumTableScale.Templates);
                        TemplateItem = null;
                        TemplateCategories = null;
                        await GuiRefreshWithWaitAsync();

                        TemplateItem = AppSettings.DataAccess.TemplatesCrud.GetEntity(new FieldListEntity(new Dictionary<string, object>
                            { { EnumField.Id.ToString(), Id } }), null);
                        TemplateCategories = AppSettings.DataSource.GetTemplateCategories();
                        await GuiRefreshWithWaitAsync();
                    }),
                }, true);
        }

        private void OnChange(object value, string name)
        {
            switch (name)
            {
                case "TemlateCategories":
                    if (value is string strValue)
                    {
                        TemplateItem.CategoryId = strValue;
                    }
                    break;
            }
            StateHasChanged();
        }

        #endregion
    }
}