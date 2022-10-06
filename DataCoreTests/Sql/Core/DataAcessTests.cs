﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCoreTests.Sql.Core;

[TestFixture]
internal class DataAcessTests
{
	#region Public and private fields, properties, constructor

	private DataCoreHelper DataCore { get; } = DataCoreHelper.Instance;

	#endregion

	#region Public and private methods

	[Test]
	public void GetFreeHosts_Exec_DoesNotThrow()
	{
		DataCore.AssertAction(() =>
		{
			foreach (long? id in DataCoreEnums.GetLongNullable())
			{
				foreach (bool? isMarked in DataCoreEnums.GetBoolNullable())
				{
					List<HostModel> hosts = DataCore.DataAccess.GetListHostsFree(id, isMarked);
				}
			}
		});
	}

	[Test]
	public void GetBusyHosts_Exec_DoesNotThrow()
	{
		DataCore.AssertAction(() =>
		{
			foreach (int? id in DataCoreEnums.GetIntNullable())
			{
				foreach (bool? isMarked in DataCoreEnums.GetBoolNullable())
				{
					List<HostModel> hosts = DataCore.DataAccess.GetListHostsBusy(id, isMarked);
				}
			}
		});
	}

	#endregion
}
