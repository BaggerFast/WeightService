﻿using WsStorageCoreTests.Tables.Common;

namespace WsStorageCoreTests.Tables.TableScaleModels.PluCharacteristics;

[TestFixture]
public sealed class PluCharacteristicsRepositoryTests : TableRepositoryTests
{
    private WsSqlPluCharacteristicRepository PluCharacteristicRepository  { get; set; } = new();
    
    [Test]
    public void GetList()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlPluCharacteristicModel> items = PluCharacteristicRepository.GetList(SqlCrudConfig);
            WsTestsUtils.DataTests.ParseRecords(items);
        }, false, DefaultPublishTypes);
    }
}