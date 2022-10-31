﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.Core;

public partial class DataAccessHelper
{
	#region Public and private methods

	public T GetNewItem<T>() where T : SqlTableBase, new() =>
		new() { Name = LocaleCore.Table.FieldNull, Description = LocaleCore.Table.FieldNull };

	#endregion
}
