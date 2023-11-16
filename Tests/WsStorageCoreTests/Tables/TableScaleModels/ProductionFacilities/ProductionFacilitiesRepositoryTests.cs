﻿using WsStorageCore.Entities.SchemaRef.ProductionSites;

namespace WsStorageCoreTests.Tables.TableScaleModels.ProductionFacilities;

[TestFixture]
public sealed class ProductionFacilitiesRepositoryTests : TableRepositoryTests
{
    private SqlProductionSiteRepository ProductionSiteRepository { get; set; } = new();

    [Test]
    public void GetList()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            IEnumerable<SqlProductionSiteEntity> items = ProductionSiteRepository.GetEnumerable(SqlCrudConfig);
            ParseRecords(items);
        }, false);
    }
}