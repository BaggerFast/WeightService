﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdmControlBlazor.Utils;
using MdmControlCore;
using MdmControlCore.DAL;
using MdmControlCore.DAL.TableModels;
using Microsoft.AspNetCore.Components;
using Radzen;
using Toolbelt.Blazor.HotKeys;

namespace MdmControlBlazor.Components
{
    public partial class NomenclatureMaster
    {
        #region Public and private fields and properties

        [Parameter]
        public int? ItemId { get; set; }
        private NomenclatureEntity _includeEntity;
        public NomenclatureEntity IncludeEntity
        {
            get => _includeEntity;
            set
            {
                _includeEntity = value;
                ObjectIncludeEntity = _includeEntity;
            }
        }
        public object ObjectIncludeEntity { get; set; }
        public IEnumerable<NomenclatureEntity> IncludeEntities { get; set; }
        public string IncludeEntitiesCount => $"{LocalizationStrings.TableRowsCount}: {IncludeEntities?.Count()}";

        #endregion

        #region Public and private methods - Hotkeys

        private async Task HotKeysTabAsync()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        }

        #endregion

        #region Public and private methods

        private async Task GuiRefreshAsync()
        {
            await InvokeAsync(StateHasChanged).ConfigureAwait(false);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync().ConfigureAwait(true);

            HotKeysItem = HotKeys.CreateContext()
                .Add(ModKeys.None, Keys.Tab, HotKeysTabAsync, LocalizationStrings.TableTab)
            ;
            BlazorSettings.Setup(JsonAppSettings, Notification, Dialog, Navigation, Tooltip, JsRuntime);
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            ItemId ??= 0;
            await GetDataAsync().ConfigureAwait(false);
        }

        private void GetData()
        {
            IncludeEntities = BlazorSettings.SqlDataAccess.NomenclatureCrud.GetEntitiesAsIEnumerable(new FieldListEntity(new Dictionary<string, object> {
            //{ EnumField.IsProduct.ToString(), true },
            { EnumField.MasterId.ToString(), ItemId },
        }),
                new FieldOrderEntity(EnumField.Name, EnumOrderDirection.Asc), 0);
            IncludeEntities = IncludeEntities.Select(x => x).Where(x => x.MasterId != x.Id && x.InformationSystem.Id != 7).ToArray();
        }

        private async Task GetDataAsync()
        {
            Task task = new Task(GetData);
            await BlazorSettings.RunTasks(LocalizationStrings.TableRead,
                "", LocalizationStrings.DialogResultFail, "",
            new List<Task> { task }, GuiRefreshAsync).ConfigureAwait(false);
        }

        private void OnChange(object value, string name)
        {
            StateHasChanged();
        }

        private void RowSelect(NomenclatureEntity entity)
        {
            IncludeEntity = entity;
        }

        private async Task RowSelectAsync(NomenclatureEntity entity)
        {
            Task task = new Task(() => RowSelect(entity));
            await BlazorSettings.RunTasks(LocalizationStrings.TableSelect, "", LocalizationStrings.DialogResultFail, "",
                new List<Task> { task }, GuiRefreshAsync).ConfigureAwait(false);
        }

        private async Task RowDoubleClickAsync(NomenclatureEntity entity, bool isNewWindow)
        {
            Task task = new Task(() => ActionEditAsync(entity, isNewWindow).ConfigureAwait(false));
            await BlazorSettings.RunTasks(LocalizationStrings.TableEdit, "", LocalizationStrings.DialogResultFail, LocalizationStrings.DialogResultCancel,
                new List<Task> { task }, GuiRefreshAsync).ConfigureAwait(false);
        }

        private void ActionEdit(EnumTable table, NomenclatureEntity entity, string page, bool isNewWindow)
        {
            if (entity == null || entity.EqualsDefault())
                return;
            BlazorSettings.ActionAsync(table, EnumTableAction.Edit, entity, page, isNewWindow).ConfigureAwait(true);
        }

        private async Task ActionEditAsync(NomenclatureEntity entity, bool isNewWindow)
        {
            Task task = new Task(() => { ActionEdit(EnumTable.Nomenclature, entity, LocalizationStrings.UriRouteNomenclature, isNewWindow); });
            await BlazorSettings.RunTasksWithQeustion(LocalizationStrings.TableEdit,
                LocalizationStrings.DialogResultSuccess, LocalizationStrings.DialogResultFail, LocalizationStrings.DialogResultCancel,
                new List<Task> { task }, GuiRefreshAsync, entity?.Name).ConfigureAwait(false);
        }

        private void ExcludeEntity(NomenclatureEntity entity)
        {
            if (entity == null || entity.EqualsDefault())
                return;
            BlazorSettings.SqlDataAccess.NomenclatureCrud.ExecQueryNative(
                "execute [MDM].[NomenclatureSetNotRelevance] :Id",
                new Dictionary<string, object> { { "Id", entity.Id } });

            GetDataAsync().ConfigureAwait(true);
        }

        private async Task ExcludeEntityAsync(NomenclatureEntity entity)
        {
            Task task = new Task(() => { ExcludeEntity(entity); });
            await BlazorSettings.RunTasksWithQeustion(LocalizationStrings.TableMasterExclude,
                LocalizationStrings.DialogResultSuccess, LocalizationStrings.DialogResultFail, LocalizationStrings.DialogResultCancel,
                new List<Task> { task }, GuiRefreshAsync, entity?.Name).ConfigureAwait(false);
        }

        #endregion
    }
}