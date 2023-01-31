﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.ProductionFacilities;

namespace DataCoreTests.Sql.TableScaleModels.ProductionFacilities;

[TestFixture]
internal class ProductionFacilityValidatorTests
{
    [Test]
    public void Model_Validate_IsFalse()
    {
        ProductionFacilityModel item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<ProductionFacilityModel>(false);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        ProductionFacilityModel item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<ProductionFacilityModel>(true);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, true);
    }
}