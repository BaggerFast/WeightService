﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataShareCore.Models;

namespace DataProjectsCore.Models
{
    public class TableScaleEntity : TableBase
    {
        public TableScaleEntity(ProjectsEnums.TableScale value) : base(value.ToString()) { }
    }
}
