﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore;
using BlazorCore.DAL;
using BlazorCore.DAL.TableModels;
using BlazorCore.Models;
using BlazorCore.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeviceControl.Shared.Item
{
    public partial class PrinterResource
    {
        #region Public and private fields and properties

        public PrinterResourceEntity PrinterResourceItem { get => (PrinterResourceEntity)IdItem; set => SetItem(value); }
        public List<PrinterEntity> PrinterItems { get; set; } = null;
        public List<TemplateResourceEntity> ResourceItems { get; set; } = null;

        #endregion

        #region Public and private methods

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);
            RunTasks($"{LocalizationStrings.DeviceControl.Method} {nameof(SetParametersAsync)}", "", LocalizationStrings.Share.DialogResultFail, "",
                new List<Task> {
                    new(async() => {
                        Table = new TableScaleEntity(EnumTableScale.Printers);
                        PrinterResourceItem = null;
                        PrinterItems = null;
                        ResourceItems = null;
                        await GuiRefreshWithWaitAsync();

                        PrinterResourceItem = AppSettings.DataAccess.PrinterResourcesCrud.GetEntity(new FieldListEntity(new Dictionary<string, object>
                            { { EnumField.Id.ToString(), Id } }), null);
                        PrinterItems = AppSettings.DataAccess.PrintersCrud.GetEntities(null, null).ToList();
                        ResourceItems = AppSettings.DataAccess.TemplateResourcesCrud.GetEntities(null, null).ToList();
                        await GuiRefreshWithWaitAsync();
                    }),
            }, true);
        }

        private void OnChange(object value, string name)
        {
            switch (name)
            {
                case nameof(PrinterEntity):
                    if (value is int idZebraPrinter)
                    {
                        if (idZebraPrinter <= 0)
                            PrinterResourceItem.Printer = null;
                        else
                        {
                            PrinterResourceItem.Printer = AppSettings.DataAccess.PrintersCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idZebraPrinter } }),
                            null);
                        }
                    }
                    break;
                case nameof(TemplateResourceEntity):
                    if (value is int idTemplateResource)
                    {
                        if (idTemplateResource <= 0)
                            PrinterResourceItem.Printer = null;
                        else
                        {
                            PrinterResourceItem.Resource = AppSettings.DataAccess.TemplateResourcesCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idTemplateResource } }),
                            null);
                            if (string.IsNullOrEmpty(PrinterResourceItem.Description))
                            {
                                PrinterResourceItem.Description = PrinterResourceItem.Resource.Name;
                            }
                        }
                    }
                    break;
            }
            StateHasChanged();
        }

        #endregion
    }
}