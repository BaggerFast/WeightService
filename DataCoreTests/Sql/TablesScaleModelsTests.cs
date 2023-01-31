﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCoreTests.Sql;

[TestFixture]
internal class TablesScaleModelsTests
{
	#region Public and private methods

	[Test]
	public void SqlTableModel_New_EqualsDefault()
	{
		DataCoreTestsUtils.DataCore.AssertAction(() =>
		{
			List<SqlTableBase> sqlTables = DataCoreTestsUtils.DataCore.DataContext.GetTableModels();
			foreach (SqlTableBase sqlTable in sqlTables)
			{
				TestContext.WriteLine(sqlTable.GetType());
				Assert.AreEqual(true, sqlTable.EqualsNew());
				Assert.AreEqual(true, sqlTable.EqualsDefault());
			}
		}, false);
	}
	
	#endregion
}