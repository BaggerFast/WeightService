﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.PlusScales;

namespace DataCoreTests.Sql.TableScaleModels.PluScales;

[TestFixture]
internal class PluScaleValidatorTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

    [Test]
    public void Model_Validate_IsFalse()
    {
        // Arrange & Act.
        PluScaleModel item = DataCore.CreateNewSubstitute<PluScaleModel>(false);
        // Assert.
        DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        // Arrange & Act.
        PluScaleModel item = DataCore.CreateNewSubstitute<PluScaleModel>(true);
        // Assert.
        DataCore.AssertSqlValidate(item, true);
    }
}