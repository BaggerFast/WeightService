﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Components;
using Radzen;
using System.Threading.Tasks;

namespace DeviceControlBlazor.Components
{
    public partial class SqlSettings
    {
        #region Public and private fields and properties

        public DeviceControlCore.DAL.DataAccessEntity DataAccess { get; set; }
        private bool _isDisabled;
        public bool IsDisabled { get => DataAccess.IsDisabled; set => _isDisabled = value; }

        #endregion

        #region Public and private methods

        private void Change(string value, string name)
        {
            StateHasChanged();
        }

        private void ShowTooltipSqlDefault(ElementReference elementReference, TooltipOptions options = null) => Tooltip.Open(elementReference, "Сбросить значения по-умолчанию", options);
        private void ShowTooltipSqlOpen(ElementReference elementReference, TooltipOptions options = null) => Tooltip.Open(elementReference, "Открыть подключение к  SQL-серверу", options);
        private void ShowTooltipSqlClose(ElementReference elementReference, TooltipOptions options = null) => Tooltip.Open(elementReference, "Закрыть подключение к  SQL-серверу", options);
        private void ShowTooltipGenerateException(ElementReference elementReference, TooltipOptions options = null) => Tooltip.Open(elementReference, "Сгенерировать тестовое исключение", options);

        #endregion
    }
}