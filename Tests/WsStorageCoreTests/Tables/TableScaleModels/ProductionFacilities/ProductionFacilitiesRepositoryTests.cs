﻿using WsStorageCoreTests.Tables.Common;

namespace WsStorageCoreTests.Tables.TableScaleModels.ProductionFacilities;

// TODO: ProductionFacilityRepository GetList

[TestFixture]
public sealed class ProductionFacilitiesRepositoryTests : TableRepositoryTests
{
    private WsSqlProductionFacilityRepository ProductionFacilityRepository { get; set; } = new();
    
    [Test]
    public void GetList()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlProductionFacilityModel> items = ProductionFacilityRepository.GetList(SqlCrudConfig);
            WsTestsUtils.DataTests.ParseRecords(items);
        }, false, DefaultPublishTypes);
    }
}