﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCoreTests.Sql.TableScaleModels;

[TestFixture]
internal class NomenclatureGroupValidatorTests
{
	private DataCoreHelper DataCore { get; } = DataCoreHelper.Instance;

	[Test]
	public void Model_Validate_IsFalse()
	{
		// Arrange & Act.
		NomenclatureGroupModel item = DataCore.CreateNewSubstitute<NomenclatureGroupModel>(false);
		// Assert.
		DataCore.AssertSqlValidate(item, false);
	}

	[Test]
	public void Model_Validate_IsTrue()
	{
		// Arrange & Act.
		NomenclatureGroupModel item = DataCore.CreateNewSubstitute<NomenclatureGroupModel>(true);
		// Assert.
		DataCore.AssertSqlValidate(item, true);
	}
}