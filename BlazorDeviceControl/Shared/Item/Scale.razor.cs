﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore;
using BlazorCore.DAL;
using BlazorCore.DAL.DataModels;
using BlazorCore.DAL.TableModels;
using BlazorCore.Models;
using BlazorCore.Utils;
using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazorDeviceControl.Shared.Item
{
    public partial class Scale
    {
        #region Public and private fields and properties

        [Parameter] public int Id { get; set; }
        private ScalesEntity ScalesItem { get; set; }
        public string PluTitle { get; set; }
        public PluEntity PluItem { get; set; }
        public List<PluEntity> PluItems { get; set; } = null;
        public List<ZebraPrinterEntity> PrinterItems { get; set; } = null;
        public List<TemplatesEntity> TemplatesDefaultItems { get; set; } = null;
        public List<TemplatesEntity> TemplatesSeriesItems { get; set; } = null;
        public List<WorkshopEntity> WorkshopItems { get; set; } = null;
        public List<TypeEntity<string>> ComPorts { get; set; }
        public List<HostsEntity> HostItems { get; set; } = null;

        #endregion

        #region Public and private methods

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters).ConfigureAwait(true);

            RunTasks($"{LocalizationStrings.DeviceControl.Method} {nameof(SetParametersAsync)}", "", LocalizationStrings.Share.DialogResultFail, "",
                new List<Task> {
                    new(async() => {
                        Item = null;
                        ScalesItem = null;
                        ScalesItem = AppSettings.DataAccess.ScalesCrud.GetEntity(new FieldListEntity(new Dictionary<string, object> {
                            { EnumField.Id.ToString(), Id },
                        }), null);
                        // ComPorts
                        ComPorts = new List<TypeEntity<string>>();
                        for (int i = 1; i < 256; i++)
                        {
                            ComPorts.Add(new TypeEntity<string>($"COM{i}", $"COM{i}"));
                        }
                        // ScaleFactor
                        ScalesItem.ScaleFactor ??= 1000;
                        // PLU.
                        PluTitle = $"{LocalizationStrings.DeviceControl.SectionPlus}  [{LocalizationStrings.Share.DataLoading}]";
                        PluItems = AppSettings.DataAccess.PluCrud.GetEntities(new FieldListEntity(new Dictionary<string, object> {
                            { EnumField.Marked.ToString(), false },
                            { "Scale.Id", ScalesItem.Id },
                        }), new FieldOrderEntity(EnumField.Plu, EnumOrderDirection.Asc)).ToList();
                        PluTitle = $"{LocalizationStrings.DeviceControl.SectionPlus}  [{PluItems.Count} {LocalizationStrings.DeviceControl.DataRecords}]";
                        // Other.
                        TemplatesDefaultItems = AppSettings.DataAccess.TemplatesCrud.GetEntities(
                            new FieldListEntity(new Dictionary<string, object> { { EnumField.Marked.ToString(), false } }),
                            null).ToList();
                        TemplatesSeriesItems = AppSettings.DataAccess.TemplatesCrud.GetEntities(
                            new FieldListEntity(new Dictionary<string, object> { { EnumField.Marked.ToString(), false } }),
                            null).ToList();
                        WorkshopItems = AppSettings.DataAccess.WorkshopCrud.GetEntities(
                            new FieldListEntity(new Dictionary<string, object> { { EnumField.Marked.ToString(), false } }),
                            null).ToList();
                        PrinterItems = AppSettings.DataAccess.ZebraPrinterCrud.GetEntities(
                            new FieldListEntity(new Dictionary<string, object> { { EnumField.Marked.ToString(), false } }),
                            null).ToList();
                        HostItems = AppSettings.DataAccess.HostsCrud.GetFreeHosts(ScalesItem.Host?.Id);
                        await GuiRefreshAsync(false).ConfigureAwait(false);
                    }),
                }, true);
        }

        private async Task RowSelectAsync(BaseIdEntity entity,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
            try
            {
                if (entity is PluEntity pluEntity)
                {
                    PluItem = pluEntity;
                }
            }
            catch (Exception ex)
            {
                NotificationMessage msg = new()
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Ошибка метода [{memberName}]!",
                    Detail = ex.Message,
                    Duration = AppSettingsEntity.Delay
                };
                Notification.Notify(msg);
                Console.WriteLine(msg.Detail);
                AppSettings.DataAccess.LogExceptionToSql(ex, filePath, lineNumber, memberName);
            }
        }

        private async Task RowDoubleClickAsync(BaseIdEntity entity,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
            try
            {
                if (entity is PluEntity pluEntity)
                {
                    PluItem = pluEntity;
                    //await EntityActions.ActionEditAsync(EnumTable.Plu, PluItem, ScalesItem).ConfigureAwait(true);
                    Action(EnumTableScales.Plu, EnumTableAction.Edit, (BaseEntity)ScalesItem, LocalizationStrings.DeviceControl.UriRouteItemScale, false, (BaseEntity)PluItem);
                    await SetParametersAsync(new ParameterView()).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                NotificationMessage msg = new()
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Ошибка метода [{memberName}]!",
                    Detail = ex.Message,
                    Duration = AppSettingsEntity.Delay
                };
                Notification.Notify(msg);
                Console.WriteLine(msg.Detail);
                AppSettings.DataAccess.LogExceptionToSql(ex, filePath, lineNumber, memberName);
            }
        }

        private void OnChange(object value, string name)
        {
            switch (name)
            {
                case "DeviceComPort":
                    if (value is string strValue)
                    {
                        ScalesItem.DeviceComPort = strValue;
                    }
                    break;
                case "TemplatesDefault":
                    if (value is int idDefault)
                    {
                        if (idDefault <= 0)
                            ScalesItem.TemplateDefault = null;
                        else
                        {
                            ScalesItem.TemplateDefault = AppSettings.DataAccess.TemplatesCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idDefault } }),
                                null);
                        }
                    }
                    break;
                case "TemplatesSeries":
                    if (value is int idSeries)
                    {
                        if (idSeries <= 0)
                            ScalesItem.TemplateSeries = null;
                        else
                        {
                            ScalesItem.TemplateSeries = AppSettings.DataAccess.TemplatesCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idSeries } }),
                                null);
                        }
                    }
                    break;
                case "WorkShops":
                    if (value is int idWorkShop)
                    {
                        if (idWorkShop <= 0)
                            ScalesItem.WorkShop = null;
                        else
                        {
                            ScalesItem.WorkShop = AppSettings.DataAccess.WorkshopCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idWorkShop } }),
                                null);
                        }
                    }
                    break;
                case "Printers":
                    if (value is int idPrinter)
                    {
                        if (idPrinter <= 0)
                            ScalesItem.Printer = null;
                        else
                        {
                            ScalesItem.Printer = AppSettings.DataAccess.ZebraPrinterCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idPrinter } }),
                                null);
                        }
                    }
                    break;
                case "Hosts":
                    if (value is int idHost)
                    {
                        if (idHost <= 0)
                            ScalesItem.Host = null;
                        else
                        {
                            ScalesItem.Host = AppSettings.DataAccess.HostsCrud.GetEntity(
                                new FieldListEntity(new Dictionary<string, object> { { EnumField.Id.ToString(), idHost } }),
                                null);
                        }
                    }
                    break;
            }
            StateHasChanged();
        }

        #endregion
    }
}