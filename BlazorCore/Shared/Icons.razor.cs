﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorCore.Shared
{
    public partial class Icons
    {
        #region Public and private fields and properties

        [Parameter] public List<string> ListIcons { get; set; }

        #endregion

        #region Public and private methods

        public Icons()
        {
            ListIcons = new List<string>();
        }

        #endregion
    }
}