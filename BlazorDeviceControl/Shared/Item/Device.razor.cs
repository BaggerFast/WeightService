﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.DAL.DataModels;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorDeviceControl.Shared.Item
{
    public partial class Device
    {
        #region Public and private fields and properties

        private DeviceEntity DeviceItem => IdItem is DeviceEntity idItem ? idItem : null;
        [Parameter] public EventCallback CallbackActionSaveAsync { get; set; }
        [Parameter] public EventCallback CallbackActionCancelAsync { get; set; }

        private string _state = @"Отключено";

        #endregion

        #region Public and private methods

        private void Change<T>(T value, string name) where T : class
        {
            if (name.Equals("State"))
            {
                _state = Convert.ToBoolean(value) ? @"Работает" : @"Отключено";
            }
            StateHasChanged();
        }

        #endregion
    }
}