﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;
using NHibernate;

namespace DataCore.Sql.Core;

public partial class DataAccessHelper
{
	#region Public and private methods

	private T[] GetItemsCore<T>(ISession session, SqlCrudConfigModel sqlCrudConfig) where T : SqlTableBase, new()
	{
		ICriteria criteria = GetCriteria<T>(session, sqlCrudConfig);
		return criteria.List<T>().ToArray();
	}

	public T[]? GetItems<T>(SqlCrudConfigModel sqlCrudConfig) where T : SqlTableBase, new()
	{
		T[]? items = null;
		ExecuteSelect(session =>
		{
			items = GetItemsCore<T>(session, sqlCrudConfig);
			foreach (T item in items)
			{
				FillReferences(item);
			}
		});
		return items;
	}

	public T[]? GetItems<T>(string query) where T : SqlTableBase, new()
	{
		T[]? result = null;
		ExecuteSelect(session =>
		{
			ISQLQuery? sqlQuery = GetSqlQuery(session, query);
			if (sqlQuery is not null)
			{
				sqlQuery.AddEntity(typeof(T));
				result = sqlQuery.List<T>().ToArray();
			}
		});
		return result;
	}

	public List<T> GetList<T>(SqlCrudConfigModel sqlCrudConfig) where T : SqlTableBase, new()
	{
		T[]? items = GetItems<T>(sqlCrudConfig);
		if (items is not null && items.Length > 0)
			return items.ToList();
		return new();
	}

	public object[] GetObjects(string query)
	{
		object[] result = Array.Empty<object>();
		ExecuteSelect(session =>
		{
			ISQLQuery? sqlQuery = GetSqlQuery(session, query);
			if (sqlQuery is not null)
			{
				System.Collections.IList? listEntities = sqlQuery.List();
				result = new object[listEntities.Count];
				for (int i = 0; i < result.Length; i++)
				{
					if (listEntities[i] is object[] records)
						result[i] = records;
					else
						result[i] = listEntities[i];
				}
			}
		});
		return result;
	}

	#endregion
}
