﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore;
using DataCore.DAL.Models;
using DataCore.DAL.TableScaleModels;
using DataCore.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static DataCore.ShareEnums;

namespace BlazorCore.Models
{
    public class RazorBase : LayoutComponentBase
    {
        #region Public and private fields and properties - Inject

        [Inject] public DialogService DialogService { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public NotificationService NotificationService { get; set; }
        [Inject] public TooltipService TooltipService { get; set; }

        #endregion

        #region Public and private fields and properties - Parameter

        [Parameter] public long? Id { get; set; } = null;
        [Parameter] public Guid? Uid { get; set; } = null;
        [Parameter] public string UidStr
        {
            get => Item == null ? string.Empty : Item.Uid.ToString();
            set => Uid = string.IsNullOrEmpty(value) ? null : Guid.Parse(value);
        }
        [Parameter] public RazorBase? ParentRazor { get; set; } = null;
        public BaseEntity? Item { get; set; } = null;
        [Parameter] public List<BaseEntity>? Items { get; set; } = null;
        [Parameter] public TableBase Table { get; set; } = new TableBase(string.Empty);
        [Parameter] public DbTableAction TableAction { get; set; } = DbTableAction.Default;
        [Parameter]
        public string TableActionString
        {
            get => TableAction.ToString().ToLower();
            set => TableAction = !string.IsNullOrEmpty(value) && Enum.TryParse(value, out DbTableAction dbTableAction)
                ? dbTableAction : DbTableAction.Default;
        }
        [Parameter] public ButtonSettingsEntity ButtonSettings { get; set; } = new ButtonSettingsEntity();
        [Parameter] public bool IsShowMarkedItems { get; set; } = false;
        [Parameter] public bool IsShowMarkedFilter { get; set; } = false;

        #endregion

        #region Public and private fields and properties

        public AppSettingsHelper AppSettings { get; private set; } = AppSettingsHelper.Instance;
        public UserSettingsHelper UserSettings { get; private set; } = UserSettingsHelper.Instance;
        private ItemSaveCheckEntity ItemSaveCheck { get; set; } = new ItemSaveCheckEntity();
        private readonly object _locker = new();

        #endregion

        #region Constructor and destructor

        //public RazorBase()
        //{
        //    //
        //}

        #endregion

        #region Public and private methods

        public void OnChangeCheckBox(object value, string name)
        {
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(OnChange)}", "", LocalizationCore.Strings.DialogResultFail, "",
                new Task(async () =>
                {
                    lock (_locker)
                    {
                        switch (name)
                        {
                            case nameof(IsShowMarkedItems):
                                if (value is bool isShowMarkedItems)
                                    IsShowMarkedItems = isShowMarkedItems;
                                break;
                        }
                    }
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        public void OnChange(object value, TableBase table, BaseEntity? item)
        {
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(OnChange)}", "", LocalizationCore.Strings.DialogResultFail, "",
                new Task(async () =>
                {
                    lock (_locker)
                    {
                        switch (table)
                        {
                            case TableSystemEntity:
                                OnChangeForTableSystem(value, table);
                                break;
                            case TableScaleEntity:
                                OnChangeForTableScale(value, table);
                                break;
                            case TableDwhEntity:
                                OnChangeForTableDwh(table);
                                break;
                        }
                    }
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        private void OnChangeForTableSystem(object value, TableBase table)
        {
            switch (ProjectsEnums.GetTableSystem(table.Name))
            {
                case ProjectsEnums.TableSystem.Default:
                    break;
                case ProjectsEnums.TableSystem.Accesses:
                    if (Item is AccessEntity access)
                    {
                        if (value is AccessRights rights)
                        {
                            access.Rights = (byte)rights;
                        }
                    }
                    break;
                case ProjectsEnums.TableSystem.Errors:
                    break;
                case ProjectsEnums.TableSystem.Logs:
                    break;
                case ProjectsEnums.TableSystem.LogTypes:
                    break;
                case ProjectsEnums.TableSystem.Tasks:
                    if (value is Guid uidTask)
                    {
                        //PluItem.Scale = AppSettings.DataAccess.ScalesCrud.GetEntity(
                        //    new FieldListEntity(new Dictionary<string, object?> { { ShareEnums.DbField.Id.ToString(), idScale } }),
                        //    null);
                    }
                    break;
                case ProjectsEnums.TableSystem.TasksTypes:
                    break;
                default:
                    break;
            }
        }

        private void OnChangeForTableScale(object value, TableBase table)
        {
            switch (ProjectsEnums.GetTableScale(table.Name))
            {
                case ProjectsEnums.TableScale.Default:
                    break;
                case ProjectsEnums.TableScale.Nomenclatures:
                    if (value is long idNomenclature)
                    {
                        //PluItem.Nomenclature = AppSettings.DataAccess.NomenclaturesCrud.GetEntity(
                        //    new FieldListEntity(new Dictionary<string, object?> { { ShareEnums.DbField.Id.ToString(), idNomenclature } }),
                        //    null);
                    }
                    break;
                case ProjectsEnums.TableScale.PrintersTypes:
                    if (Item is PrinterEntity printerItem)
                    {
                        if (value is long id)
                        {
                            if (id <= 0)
                                printerItem.PrinterType = new();
                            else
                            {
                                printerItem.PrinterType = AppSettings.DataAccess.Crud.GetEntity<PrinterTypeEntity>(
                                    new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), id } }),
                                null);
                            }
                        }
                    }
                    break;
                case ProjectsEnums.TableScale.Scales:
                    if (value is long idScale)
                    {
                        //PluItem.Scale = AppSettings.DataAccess.ScalesCrud.GetEntity(
                        //    new FieldListEntity(new Dictionary<string, object?> { { ShareEnums.DbField.Id.ToString(), idScale } }),
                        //    null);
                    }
                    break;
                case ProjectsEnums.TableScale.Templates:
                    if (value is long idTemplate)
                    {
                        //if (idTemplate <= 0)
                        //    PluItem.Templates = null;
                        //else
                        //{
                        //    PluItem.Templates = AppSettings.DataAccess.TemplatesCrud.GetEntity(
                        //        new FieldListEntity(new Dictionary<string, object?> { { ShareEnums.DbField.Id.ToString(), idTemplate } }),
                        //        null);
                        //}
                    }
                    break;
                case ProjectsEnums.TableScale.BarcodesTypes:
                    break;
                case ProjectsEnums.TableScale.Contragents:
                    break;
                case ProjectsEnums.TableScale.Hosts:
                    break;
                case ProjectsEnums.TableScale.Labels:
                    break;
                case ProjectsEnums.TableScale.Orders:
                    break;
                case ProjectsEnums.TableScale.OrdersStatuses:
                    break;
                case ProjectsEnums.TableScale.OrdersTypes:
                    break;
                case ProjectsEnums.TableScale.Organizations:
                    break;
                case ProjectsEnums.TableScale.Plus:
                    break;
                case ProjectsEnums.TableScale.Printers:
                    break;
                case ProjectsEnums.TableScale.PrintersResources:
                    break;
                case ProjectsEnums.TableScale.ProductionFacilities:
                    break;
                case ProjectsEnums.TableScale.ProductSeries:
                    break;
                case ProjectsEnums.TableScale.TemplatesResources:
                    break;
                case ProjectsEnums.TableScale.WeithingFacts:
                    break;
                case ProjectsEnums.TableScale.Workshops:
                    if (Item is WorkshopEntity workshop)
                    {
                        if (value is long id)
                        {
                            if (id <= 0)
                                workshop.ProductionFacility = new();
                            else
                            {
                                workshop.ProductionFacility = AppSettings.DataAccess.Crud.GetEntity<ProductionFacilityEntity>(
                                    new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), id } }),
                                null);
                            }
                        }
                    }
                    break;
            }
        }

        private void OnChangeForTableDwh(TableBase table)
        {
            switch (ProjectsEnums.GetTableDwh(table.Name))
            {
                default:
                    break;
            }
        }

        public async Task ItemSelectAsync(BaseEntity item)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(ItemSelectAsync)}", "", LocalizationCore.Strings.DialogResultFail, "",
                new Task(async () =>
                {
                    lock (_locker)
                    {
                        Item = item;
                        Id = item.Id;
                        Uid = item.Uid;
                    }
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        public async Task GuiRefreshAsync(bool continueOnCapturedContext)
        {
            await InvokeAsync(StateHasChanged).ConfigureAwait(continueOnCapturedContext);
            await Task.Delay(TimeSpan.FromMilliseconds(1000)).ConfigureAwait(true);
        }

        public async Task GuiRefreshWithWaitAsync(bool continueOnCapturedContext = true, int millisecondsTimeout = 1000)
        {
            await InvokeAsync(StateHasChanged).ConfigureAwait(continueOnCapturedContext);
            await Task.Delay(TimeSpan.FromMilliseconds(millisecondsTimeout)).ConfigureAwait(continueOnCapturedContext);
        }

        public async Task GetDataAsync(Task task, bool continueOnCapturedContext)
        {
            await RunTasksAsync(LocalizationCore.Strings.TableRead, "", LocalizationCore.Strings.DialogResultFail, "",
                new List<Task> { task }, continueOnCapturedContext).ConfigureAwait(false);
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.Equals(new ParameterView()))
                return;
            await base.SetParametersAsync(parameters).ConfigureAwait(true);

            AppSettings.FontSize = parameters.TryGetValue("FontSize", out int fontSize) ? fontSize : 14;
            AppSettings.FontSizeHeader = parameters.TryGetValue("FontSizeHeader", out int fontSizeHeader) ? fontSizeHeader : 20;

            if (Id == null && ParentRazor?.Id != null)
                Id = ParentRazor.Id;
            if (Uid == null && ParentRazor?.Uid != null)
                Uid = ParentRazor.Uid;
            if (Table == null || string.IsNullOrEmpty(Table.Name))
            {
                if (ParentRazor != null)
                {
                    if (ParentRazor.Table != null)
                        Table = ParentRazor.Table;
                }
            }
            if (TableAction == DbTableAction.Default)
            {
                if (ParentRazor != null)
                {
                    if (ParentRazor.TableAction != DbTableAction.Default)
                        TableAction = ParentRazor.TableAction;
                }
            }

            switch (Table)
            {
                case TableSystemEntity:
                    SetParametersForTableSystem(parameters, ProjectsEnums.GetTableSystem(Table.Name));
                    break;
                case TableScaleEntity:
                    SetParametersForTableScale(parameters, ProjectsEnums.GetTableScale(Table.Name));
                    break;
                case TableDwhEntity:
                    SetParametersForTableDwh(parameters, ProjectsEnums.GetTableDwh(Table.Name));
                    break;
            }
        }

        private void SetParametersForTableSystem(ParameterView parameters, ProjectsEnums.TableSystem table)
        {
            switch (table)
            {
                case ProjectsEnums.TableSystem.Default:
                    break;
                case ProjectsEnums.TableSystem.Accesses:
                    if (parameters.TryGetValue(DbField.Uid.ToString(), out Guid? uidAccess))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<AccessEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Uid.ToString(), uidAccess }, }), null);
                    }
                    break;
                case ProjectsEnums.TableSystem.Logs:
                    if (parameters.TryGetValue(DbField.Uid.ToString(), out Guid? uidLog))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<LogEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Uid.ToString(), uidLog }, }), null);
                    }
                    break;
                case ProjectsEnums.TableSystem.Errors:
                    break;
                case ProjectsEnums.TableSystem.LogTypes:
                    break;
                case ProjectsEnums.TableSystem.Tasks:
                    break;
                case ProjectsEnums.TableSystem.TasksTypes:
                    break;
            }
        }

        private void SetParametersForTableScale(ParameterView parameters, ProjectsEnums.TableScale table)
        {
            switch (table)
            {
                case ProjectsEnums.TableScale.Default:
                    break;
                case ProjectsEnums.TableScale.BarcodesTypes:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idBarcodeType))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<BarcodeTypeEntityV2>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idBarcodeType }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Contragents:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idContragent))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<ContragentEntityV2>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idContragent }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Hosts:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idHost))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<HostEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idHost }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Labels:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idLabel))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<LabelEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idLabel }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Nomenclatures:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idNomenclature))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<NomenclatureEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idNomenclature }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Orders:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idOrder))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<OrderEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idOrder }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.OrdersStatuses:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idOrderStatus))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<OrderStatusEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idOrderStatus }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.OrdersTypes:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idOrderType))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<OrderTypeEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idOrderType }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Organizations:
                    break;
                case ProjectsEnums.TableScale.Plus:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idPlu))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<PluEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idPlu }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.Printers:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idPrinter))
                    {
                        Item = AppSettings.DataAccess.Crud.GetEntity<PrinterEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idPrinter }, }), null);
                    }
                    break;
                case ProjectsEnums.TableScale.PrintersResources:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idPrinterResource))
                    {
                        PrinterResourceEntity printerResourceEntity = AppSettings.DataAccess.Crud.GetEntity<PrinterResourceEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idPrinterResource }, }), null);
                        Item = printerResourceEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.PrintersTypes:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idPrinterType))
                    {
                        PrinterTypeEntity printerTypeEntity = AppSettings.DataAccess.Crud.GetEntity<PrinterTypeEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idPrinterType }, }), null);
                        Item = printerTypeEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.ProductSeries:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idProductSeries))
                    {
                        ProductSeriesEntity productSeriesEntity = AppSettings.DataAccess.Crud.GetEntity<ProductSeriesEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idProductSeries }, }), null);
                        Item = productSeriesEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.ProductionFacilities:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idProductionFacility))
                    {
                        ProductionFacilityEntity productionFacilityEntity = AppSettings.DataAccess.Crud.GetEntity<ProductionFacilityEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idProductionFacility }, }), null);
                        Item = productionFacilityEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.Scales:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idScale))
                    {
                        ScaleEntity scaleEntity = AppSettings.DataAccess.Crud.GetEntity<ScaleEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idScale }, }), null);
                        Item = scaleEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.TemplatesResources:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idTemplateResource))
                    {
                        TemplateResourceEntity templateResourceEntity = AppSettings.DataAccess.Crud.GetEntity<TemplateResourceEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idTemplateResource }, }), null);
                        Item = templateResourceEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.Templates:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idTemplate))
                    {
                        TemplateEntity templateEntity = AppSettings.DataAccess.Crud.GetEntity<TemplateEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idTemplate }, }), null);
                        Item = templateEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.WeithingFacts:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idWeithingFact))
                    {
                        WeithingFactEntity weithingFactEntity = AppSettings.DataAccess.Crud.GetEntity<WeithingFactEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idWeithingFact }, }), null);
                        Item = weithingFactEntity;
                    }
                    break;
                case ProjectsEnums.TableScale.Workshops:
                    if (parameters.TryGetValue(DbField.Id.ToString(), out long? idWorkshop))
                    {
                        WorkshopEntity workshopEntity = AppSettings.DataAccess.Crud.GetEntity<WorkshopEntity>(
                            new FieldListEntity(new Dictionary<string, object?> { { DbField.Id.ToString(), idWorkshop }, }), null);
                        Item = workshopEntity;
                    }
                    break;
            }
        }

        private void SetParametersForTableDwh(ParameterView parameters, ProjectsEnums.TableDwh table)
        {
            switch (table)
            {
                case ProjectsEnums.TableDwh.Default:
                    break;
                case ProjectsEnums.TableDwh.InformationSystem:
                    break;
                case ProjectsEnums.TableDwh.Nomenclature:
                    break;
                case ProjectsEnums.TableDwh.NomenclatureMaster:
                    break;
                case ProjectsEnums.TableDwh.NomenclatureNonNormalize:
                    break;
            }
        }

        public async Task HotKeysMenuRoot()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
            NavigationManager.NavigateTo(LocalizationData.DeviceControl.UriRouteSection.Root);
        }

        public static ConfirmOptions GetConfirmOptions() => new()
        {
            OkButtonText = LocalizationCore.Strings.DialogButtonYes,
            CancelButtonText = LocalizationCore.Strings.DialogButtonCancel,
            //    ShowTitle = true,
            //    ShowClose = true,
            //    Bottom = null,
            //    ChildContent = null,
            //    Height = null,
            //    Left = null,
            //    Style = null,
            //    Top = null,
            //    Width = null,
        };

        public async Task RunTasksAsync(string title, string detailSuccess, string detailFail, string detailCancel, List<Task> tasks,
            bool continueOnCapturedContext,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);

            RunTasks(title, detailSuccess, detailFail, detailCancel, tasks, continueOnCapturedContext, filePath, lineNumber, memberName);
        }

        public void RunTasks(string title, string detailSuccess, string detailFail, string detailCancel, List<Task> tasks, bool continueOnCapturedContext,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            try
            {
                RunTasksCore(title, detailSuccess, detailCancel, tasks, continueOnCapturedContext);
            }
            catch (Exception ex)
            {
                RunTasksCatch(ex, title, detailFail, filePath, lineNumber, memberName);
            }
        }

        public void RunTasks(string title, string detailSuccess, string detailFail, string detailCancel, Task task, bool continueOnCapturedContext,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            RunTasks(title, detailSuccess, detailFail, detailCancel, new List<Task> { task }, continueOnCapturedContext, filePath, lineNumber, memberName);
        }

        private void RunTasksCore(string title, string detailSuccess, string detailCancel, List<Task> tasks, bool continueOnCapturedContext)
        {
            if (tasks != null)
            {
                foreach (Task task in tasks)
                {
                    if (task != null)
                    {
                        task.Start();
                        task.ConfigureAwait(continueOnCapturedContext);
                    }
                }
            }
            if (!string.IsNullOrEmpty(detailSuccess))
                NotificationService.Notify(NotificationSeverity.Success, title + Environment.NewLine, detailSuccess, AppSettingsHelper.Delay);
            else
            {
                if (!string.IsNullOrEmpty(detailCancel))
                    NotificationService.Notify(NotificationSeverity.Info, title + Environment.NewLine, detailCancel, AppSettingsHelper.Delay);
            }
        }

        private void RunTasksCatch(Exception ex, string title, string detailFail, string filePath, int lineNumber, string memberName)
        {
            // User log.
            string msg = ex.Message;
            if (!string.IsNullOrEmpty(ex.InnerException?.Message))
                msg += Environment.NewLine + ex.InnerException.Message;
            if (!string.IsNullOrEmpty(detailFail))
            {
                if (!string.IsNullOrEmpty(msg))
                    NotificationService.Notify(NotificationSeverity.Error, title + Environment.NewLine, detailFail + Environment.NewLine + msg, AppSettingsHelper.Delay);
                else
                    NotificationService.Notify(NotificationSeverity.Error, title + Environment.NewLine, detailFail, AppSettingsHelper.Delay);
            }
            else
            {
                if (!string.IsNullOrEmpty(msg))
                    NotificationService.Notify(NotificationSeverity.Error, title + Environment.NewLine, msg, AppSettingsHelper.Delay);
            }
            // SQL log.
            AppSettings.DataAccess.Crud.LogExceptionToSql(ex, filePath, lineNumber, memberName);
        }

        public void RunTasksWithQeustion(string title, string detailSuccess, string detailFail, string detailCancel,
            string questionAdd, Task task, bool continueOnCapturedContext,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            try
            {
                string question = string.IsNullOrEmpty(questionAdd)
                    ? LocalizationCore.Strings.DialogQuestion
                    : questionAdd;
                Task<bool?> dialog = DialogService.Confirm(question, title, GetConfirmOptions());
                bool? result = dialog.Result;
                if (result == true)
                {
                    RunTasks(title, detailSuccess, detailFail, detailCancel, task, continueOnCapturedContext);
                }
            }
            catch (Exception ex)
            {
                RunTasksCatch(ex, title, detailFail, filePath, lineNumber, memberName);
            }
        }

        #endregion

        #region Public and private methods - Actions

        public void RouteItemNavigate(bool isNewWindow, BaseEntity? item)
        {
            string page = RouteItemNavigatePage();
            if (string.IsNullOrEmpty(page))
                return;

            if (!isNewWindow)
            {
                RouteItemNavigatePrepareForNew();
                RouteItemNavigateForItem(item, page);
            }
            else
            {
                RouteItemNavigateUsingJsRuntime(page);
            }
        }

        private string RouteItemNavigatePage()
        {
            string page = string.Empty;
            if (Table == null || string.IsNullOrEmpty(Table.Name))
                if (ParentRazor != null)
                    Table = ParentRazor.Table;
            switch (Table)
            {
                case TableSystemEntity:
                    switch (ProjectsEnums.GetTableSystem(Table.Name))
                    {
                        case ProjectsEnums.TableSystem.Default:
                            break;
                        case ProjectsEnums.TableSystem.Logs:
                            page = LocalizationData.DeviceControl.UriRouteItem.Log;
                            break;
                        case ProjectsEnums.TableSystem.Accesses:
                            page = LocalizationData.DeviceControl.UriRouteItem.Access;
                            break;
                        case ProjectsEnums.TableSystem.Errors:
                            page = LocalizationData.DeviceControl.UriRouteItem.Error;
                            break;
                        case ProjectsEnums.TableSystem.LogTypes:
                            page = LocalizationData.DeviceControl.UriRouteItem.LogType;
                            break;
                        case ProjectsEnums.TableSystem.Tasks:
                            page = LocalizationData.DeviceControl.UriRouteItem.TaskModule;
                            break;
                        case ProjectsEnums.TableSystem.TasksTypes:
                            page = LocalizationData.DeviceControl.UriRouteItem.TaskTypeModule;
                            break;
                    }
                    break;
                case TableScaleEntity:
                    switch (ProjectsEnums.GetTableScale(Table.Name))
                    {
                        case ProjectsEnums.TableScale.BarcodesTypes:
                            page = LocalizationData.DeviceControl.UriRouteItem.BarCodeType;
                            break;
                        case ProjectsEnums.TableScale.Contragents:
                            page = LocalizationData.DeviceControl.UriRouteItem.Contragent;
                            break;
                        case ProjectsEnums.TableScale.Hosts:
                            page = LocalizationData.DeviceControl.UriRouteItem.Host;
                            break;
                        case ProjectsEnums.TableScale.Labels:
                            page = LocalizationData.DeviceControl.UriRouteItem.Label;
                            break;
                        case ProjectsEnums.TableScale.Nomenclatures:
                            page = LocalizationData.DeviceControl.UriRouteItem.Nomenclature;
                            break;
                        case ProjectsEnums.TableScale.Plus:
                            page = LocalizationData.DeviceControl.UriRouteItem.Plu;
                            break;
                        case ProjectsEnums.TableScale.PrintersResources:
                            page = LocalizationData.DeviceControl.UriRouteItem.PrinterResource;
                            break;
                        case ProjectsEnums.TableScale.Printers:
                            page = LocalizationData.DeviceControl.UriRouteItem.Printer;
                            break;
                        case ProjectsEnums.TableScale.PrintersTypes:
                            page = LocalizationData.DeviceControl.UriRouteItem.PrinterType;
                            break;
                        case ProjectsEnums.TableScale.ProductionFacilities:
                            page = LocalizationData.DeviceControl.UriRouteItem.ProductionFacility;
                            break;
                        case ProjectsEnums.TableScale.Scales:
                            page = LocalizationData.DeviceControl.UriRouteItem.Scale;
                            break;
                        case ProjectsEnums.TableScale.TemplatesResources:
                            page = LocalizationData.DeviceControl.UriRouteItem.TemplateResource;
                            break;
                        case ProjectsEnums.TableScale.Templates:
                            page = LocalizationData.DeviceControl.UriRouteItem.Template;
                            break;
                        case ProjectsEnums.TableScale.WeithingFacts:
                            page = LocalizationData.DeviceControl.UriRouteItem.WeithingFact;
                            break;
                        case ProjectsEnums.TableScale.Workshops:
                            page = LocalizationData.DeviceControl.UriRouteItem.Workshop;
                            break;
                    }
                    break;
            }
            return page;
        }

        private void RouteItemNavigatePrepareForNew()
        {
            if (TableAction == DbTableAction.New)
            {
                switch (Table)
                {
                    case TableSystemEntity:
                        switch (ProjectsEnums.GetTableSystem(Table.Name))
                        {
                            case ProjectsEnums.TableSystem.Default:
                                break;
                            case ProjectsEnums.TableSystem.Accesses:
                                Uid = Guid.NewGuid();
                                break;
                            case ProjectsEnums.TableSystem.Errors:
                                Id = AppSettings.DataAccess.Crud.GetEntity<ErrorEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                break;
                            case ProjectsEnums.TableSystem.Logs:
                                Uid = Guid.NewGuid();
                                break;
                            case ProjectsEnums.TableSystem.LogTypes:
                                Uid = Guid.NewGuid();
                                break;
                            case ProjectsEnums.TableSystem.Tasks:
                                Uid = Guid.NewGuid();
                                break;
                            case ProjectsEnums.TableSystem.TasksTypes:
                                Uid = Guid.NewGuid();
                                break;
                        }
                        break;
                    case TableScaleEntity:
                        {
                            switch (ProjectsEnums.GetTableScale(Table.Name))
                            {
                                case ProjectsEnums.TableScale.BarcodesTypes:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<BarcodeTypeEntityV2>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.Hosts:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<HostEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.Plus:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<PluEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.Printers:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<PrinterEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.PrintersResources:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<PrinterResourceEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.PrintersTypes:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<PrinterTypeEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.ProductionFacilities:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<ProductionFacilityEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.ProductSeries:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<ProductSeriesEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.Scales:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<ScaleEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.TemplatesResources:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<TemplateResourceEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.Templates:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<TemplateEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                case ProjectsEnums.TableScale.Workshops:
                                    Id = AppSettings.DataAccess.Crud.GetEntity<WorkshopEntity>(null, new FieldOrderEntity(DbField.Id, DbOrderDirection.Desc)).Id + 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    case TableDwhEntity:
                        switch (ProjectsEnums.GetTableDwh(Table.Name))
                        {
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        private void RouteItemNavigateForItem(BaseEntity? item, string page)
        {
            if (item == null)
                return;
            if (TableAction == DbTableAction.New)
            {
                if (item.PrimaryColumn.Name == ColumnName.Id)
                    NavigationManager.NavigateTo($"{page}/{Id}/{TableAction}");
                else if (item.PrimaryColumn.Name == ColumnName.Uid)
                    NavigationManager.NavigateTo($"{page}/{Uid}/{TableAction}");
            }
            else
            {
                if (item.PrimaryColumn.Name == ColumnName.Id)
                    NavigationManager.NavigateTo($"{page}/{Id}");
                else if (item.PrimaryColumn.Name == ColumnName.Uid)
                    NavigationManager.NavigateTo($"{page}/{Uid}");
            }
        }

        private void RouteItemNavigateUsingJsRuntime(string page)
        {
            _ = Task.Run(async () =>
            {
                if (Uid != null && Uid != Guid.Empty)
                    await JsRuntime.InvokeAsync<object>("open", $"{page}/{Uid}", "_blank").ConfigureAwait(false);
                else if (Id != null)
                    await JsRuntime.InvokeAsync<object>("open", $"{page}/{Id}", "_blank").ConfigureAwait(false);
            }).ConfigureAwait(true);
        }

        public void RouteSectionNavigate(bool isNewWindow)
        {
            string page = RouteSectionNavigatePage();
            if (string.IsNullOrEmpty(page))
                return;

            if (!isNewWindow)
            {
                NavigationManager.NavigateTo(page);
            }
            else
            {
                _ = Task.Run(async () =>
                {
                    await JsRuntime.InvokeAsync<object>("open", $"{page}", "_blank").ConfigureAwait(false);
                }).ConfigureAwait(true);
            }
        }

        private string RouteSectionNavigatePage()
        {
            string page = string.Empty;
            switch (Table)
            {
                case TableSystemEntity:
                    switch (ProjectsEnums.GetTableSystem(Table.Name))
                    {
                        case ProjectsEnums.TableSystem.Default:
                            break;
                        case ProjectsEnums.TableSystem.Accesses:
                            page = LocalizationData.DeviceControl.UriRouteSection.Access;
                            break;
                        case ProjectsEnums.TableSystem.Logs:
                            page = LocalizationData.DeviceControl.UriRouteSection.Logs;
                            break;
                        case ProjectsEnums.TableSystem.LogTypes:
                            page = LocalizationData.DeviceControl.UriRouteSection.LogTypes;
                            break;
                        case ProjectsEnums.TableSystem.Errors:
                            page = LocalizationData.DeviceControl.UriRouteSection.Errors;
                            break;
                        case ProjectsEnums.TableSystem.Tasks:
                            page = LocalizationData.DeviceControl.UriRouteSection.TaskModules;
                            break;
                        case ProjectsEnums.TableSystem.TasksTypes:
                            page = LocalizationData.DeviceControl.UriRouteSection.TaskTypeModules;
                            break;
                    }
                    break;
                case TableScaleEntity:
                    switch (ProjectsEnums.GetTableScale(Table.Name))
                    {
                        case ProjectsEnums.TableScale.BarcodesTypes:
                            page = LocalizationData.DeviceControl.UriRouteSection.BarCodeTypes;
                            break;
                        case ProjectsEnums.TableScale.Contragents:
                            page = LocalizationData.DeviceControl.UriRouteSection.Contragents;
                            break;
                        case ProjectsEnums.TableScale.Hosts:
                            page = LocalizationData.DeviceControl.UriRouteSection.Hosts;
                            break;
                        case ProjectsEnums.TableScale.Labels:
                            page = LocalizationData.DeviceControl.UriRouteSection.Labels;
                            break;
                        case ProjectsEnums.TableScale.Nomenclatures:
                            page = LocalizationData.DeviceControl.UriRouteSection.Nomenclatures;
                            break;
                        case ProjectsEnums.TableScale.Plus:
                            page = LocalizationData.DeviceControl.UriRouteSection.Plus;
                            break;
                        case ProjectsEnums.TableScale.PrintersResources:
                            page = LocalizationData.DeviceControl.UriRouteSection.Printers;
                            break;
                        case ProjectsEnums.TableScale.Printers:
                            page = LocalizationData.DeviceControl.UriRouteSection.Printers;
                            break;
                        case ProjectsEnums.TableScale.PrintersTypes:
                            page = LocalizationData.DeviceControl.UriRouteSection.PrinterTypes;
                            break;
                        case ProjectsEnums.TableScale.ProductionFacilities:
                            page = LocalizationData.DeviceControl.UriRouteSection.ProductionFacilities;
                            break;
                        case ProjectsEnums.TableScale.Scales:
                            page = LocalizationData.DeviceControl.UriRouteSection.Scales;
                            break;
                        case ProjectsEnums.TableScale.TemplatesResources:
                            page = LocalizationData.DeviceControl.UriRouteSection.TemplateResources;
                            break;
                        case ProjectsEnums.TableScale.Templates:
                            page = LocalizationData.DeviceControl.UriRouteSection.Templates;
                            break;
                        case ProjectsEnums.TableScale.WeithingFacts:
                            page = LocalizationData.DeviceControl.UriRouteSection.WeithingFacts;
                            break;
                        case ProjectsEnums.TableScale.Workshops:
                            page = LocalizationData.DeviceControl.UriRouteSection.Workshops;
                            break;
                    }
                    break;
                case TableDwhEntity:
                    break;
            }
            return page;
        }

        public async Task ItemCancelAsync(bool isNewWindow)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(ItemCancelAsync)}", LocalizationCore.Strings.DialogResultSuccess,
                LocalizationCore.Strings.DialogResultFail, LocalizationCore.Strings.DialogResultCancel,
                new Task(() =>
                {
                    RouteSectionNavigate(isNewWindow);
                }), false);
        }

        private string GetQuestionAdd()
        {
            if (ParentRazor?.Item != null)
            {
                if (ParentRazor.Item.PrimaryColumn.Name == ColumnName.Id)
                    return LocalizationCore.Strings.DialogQuestion + Environment.NewLine + $"ID: {ParentRazor.Item.Id}";
                else if (ParentRazor.Item.PrimaryColumn.Name == ColumnName.Uid)
                    return LocalizationCore.Strings.DialogQuestion + Environment.NewLine + $"UID: {ParentRazor.Item.Uid}";
            }
            return string.Empty;
        }

        private void ItemSystemSave(ProjectsEnums.TableSystem tableSystem)
        {
            switch (tableSystem)
            {
                case ProjectsEnums.TableSystem.Default:
                    break;
                case ProjectsEnums.TableSystem.Accesses:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Access(NotificationService, (AccessEntity)ParentRazor.Item, Uid, TableAction);
                    break;
                case ProjectsEnums.TableSystem.Logs:
                    break;
                case ProjectsEnums.TableSystem.Errors:
                    break;
                case ProjectsEnums.TableSystem.LogTypes:
                    break;
                case ProjectsEnums.TableSystem.Tasks:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Task(NotificationService, (TaskEntity)ParentRazor.Item, Uid, TableAction);
                    break;
                case ProjectsEnums.TableSystem.TasksTypes:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.TaskType(NotificationService, (TaskTypeEntity)ParentRazor.Item, Uid, TableAction);
                    break;
            }
        }

        private void ItemScaleSave(ProjectsEnums.TableScale tableScale)
        {
            switch (tableScale)
            {
                case ProjectsEnums.TableScale.Default:
                    break;
                case ProjectsEnums.TableScale.BarcodesTypes:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.BarcodeType(NotificationService, (BarcodeTypeEntityV2)ParentRazor.Item, Uid, TableAction);
                    break;
                case ProjectsEnums.TableScale.Contragents:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Contragent(NotificationService, (ContragentEntityV2)ParentRazor.Item, Uid, TableAction);
                    break;
                case ProjectsEnums.TableScale.Hosts:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Host(NotificationService, (HostEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.Labels:
                    break;
                case ProjectsEnums.TableScale.Nomenclatures:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Nomenclature(NotificationService, (NomenclatureEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.Orders:
                    break;
                case ProjectsEnums.TableScale.OrdersStatuses:
                    break;
                case ProjectsEnums.TableScale.OrdersTypes:
                    break;
                case ProjectsEnums.TableScale.Organizations:
                    break;
                case ProjectsEnums.TableScale.Plus:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Plu(NotificationService, (PluEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.PrintersResources:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.PrinterResource(NotificationService, (PrinterResourceEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.Printers:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Printer(NotificationService, (PrinterEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.PrintersTypes:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.PrinterType(NotificationService, (PrinterTypeEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.ProductionFacilities:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.ProductionFacility(NotificationService, (ProductionFacilityEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.ProductSeries:
                    break;
                case ProjectsEnums.TableScale.Scales:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Scale(NotificationService, (ScaleEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.TemplatesResources:
                    break;
                case ProjectsEnums.TableScale.Templates:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Template(NotificationService, (TemplateEntity)ParentRazor.Item, Id, TableAction);
                    break;
                case ProjectsEnums.TableScale.WeithingFacts:
                    break;
                case ProjectsEnums.TableScale.Workshops:
                    if (ParentRazor?.Item != null)
                        ItemSaveCheck.Workshop(NotificationService, (WorkshopEntity)ParentRazor.Item, Id, TableAction);
                    break;
            }
        }

        private void ItemDwhSave(ProjectsEnums.TableDwh tableDwh)
        {
            switch (tableDwh)
            {
                case ProjectsEnums.TableDwh.Default:
                    break;
                case ProjectsEnums.TableDwh.InformationSystem:
                    break;
                case ProjectsEnums.TableDwh.Nomenclature:
                    break;
                case ProjectsEnums.TableDwh.NomenclatureMaster:
                    break;
                case ProjectsEnums.TableDwh.NomenclatureNonNormalize:
                    break;
            }
        }

        public async Task ItemSaveAsync(bool continueOnCapturedContext, bool isNewWindow)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
            RunTasksWithQeustion(LocalizationCore.Strings.TableSave, LocalizationCore.Strings.DialogResultSuccess,
                LocalizationCore.Strings.DialogResultFail, LocalizationCore.Strings.DialogResultCancel, GetQuestionAdd(),
                new Task(async () =>
                {
                    lock (_locker)
                    {
                        switch (Table)
                        {
                            case TableSystemEntity:
                                ItemSystemSave(ProjectsEnums.GetTableSystem(Table.Name));
                                break;
                            case TableScaleEntity:
                                ItemScaleSave(ProjectsEnums.GetTableScale(Table.Name));
                                break;
                            case TableDwhEntity:
                                ItemDwhSave(ProjectsEnums.GetTableDwh(Table.Name));
                                break;
                        }
                        RouteSectionNavigate(isNewWindow);
                    }
                    await GuiRefreshWithWaitAsync();
                }), continueOnCapturedContext);
        }

        public async Task ActionAsync(UserSettingsHelper userSettings, DbTableAction tableAction, bool isNewWindow, bool isParentRazor)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);

            if ((byte)userSettings.Identity.AccessRights < (byte)AccessRights.Write)
                return;
            switch (TableAction = tableAction)
            {
                case DbTableAction.Delete:
                    ActionAsyncDelete();
                    break;
                default:
                    ActionAsyncDefault(userSettings, tableAction, isNewWindow, isParentRazor);
                    break;
            }
        }

        private void ActionAsyncDelete()
        {
            RunTasksWithQeustion(LocalizationCore.Strings.TableDelete, LocalizationCore.Strings.DialogResultSuccess,
                LocalizationCore.Strings.DialogResultFail, LocalizationCore.Strings.DialogResultCancel, GetQuestionAdd(),
                new Task(async () =>
                {
                    if (ParentRazor?.Item == null) return;
                    AppSettings.DataAccess.Crud.DeleteEntity(ParentRazor.Item);
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        private void ActionAsyncDefault(UserSettingsHelper userSettings, DbTableAction tableAction, bool isNewWindow, bool isParentRazor)
        {
            RunTasks($"{LocalizationCore.Strings.Method} {nameof(ActionAsync)}", "", LocalizationCore.Strings.DialogResultFail, "",
                new Task(async () =>
                {
                    BaseEntity? item = isParentRazor ? ParentRazor?.Item : Item;
                    if ((byte)userSettings.Identity.AccessRights < (byte)AccessRights.Write)
                        return;
                    switch (tableAction)
                    {
                        case DbTableAction.Default:
                            break;
                        case DbTableAction.New:
                            TableAction = DbTableAction.New;
                            Id = null;
                            Uid = null;
                            RouteItemNavigate(isNewWindow, item);
                            break;
                        case DbTableAction.Edit:
                        case DbTableAction.Copy:
                            RouteItemNavigate(isNewWindow, item);
                            break;
                        case DbTableAction.Mark:
                            if (item != null)
                                AppSettings.DataAccess.Crud.MarkedEntity(item);
                            break;
                        case DbTableAction.Save:
                            if (ParentRazor?.Item == null) return;
                            break;
                        case DbTableAction.Cancel:
                            break;
                        case DbTableAction.Reload:
                            break;
                        case DbTableAction.Delete:
                            break;
                    }
                    await GuiRefreshWithWaitAsync();
                }), true);
        }

        #endregion
    }
}