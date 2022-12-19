﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Organizations;

namespace DataCoreTests.Sql.TableScaleModels.Organizations;

[TestFixture]
internal class OrganizationValidatorTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

    [Test]
    public void Model_Validate_IsFalse()
    {
        // Arrange & Act.
        OrganizationModel item = DataCore.CreateNewSubstitute<OrganizationModel>(false);
        // Assert.
        DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        // Arrange & Act.
        OrganizationModel item = DataCore.CreateNewSubstitute<OrganizationModel>(true);
        // Assert.
        DataCore.AssertSqlValidate(item, true);
    }
}