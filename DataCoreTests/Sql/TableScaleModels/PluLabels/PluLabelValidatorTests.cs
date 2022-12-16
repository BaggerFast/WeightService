﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.PlusLabels;

namespace DataCoreTests.Sql.TableScaleModels.PluLabels;

[TestFixture]
internal class PluLabelValidatorTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

    [Test]
    public void Model_Validate_IsFalse()
    {
        // Arrange & Act.
        PluLabelModel item = DataCore.CreateNewSubstitute<PluLabelModel>(false);
        // Assert.
        DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        // Arrange & Act.
        PluLabelModel item = DataCore.CreateNewSubstitute<PluLabelModel>(true);
        // Assert.
        DataCore.AssertSqlValidate(item, true);
    }
}
