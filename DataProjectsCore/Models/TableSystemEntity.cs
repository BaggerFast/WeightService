﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataShareCore.Models;

namespace DataProjectsCore.Models
{
    public class TableSystemEntity : TableBase
    {
        public TableSystemEntity(ProjectsEnums.TableSystem value) : base(value.ToString()) { }
    }
}
