﻿using WsStorageCore.Views.ViewRefModels.PluNestings;

namespace WsStorageCoreTests.Views.ViewRefModels.PluNestings;

public class ViewPluNestingRepositoryTests : ViewRepositoryTests
{
    private IViewPluNestingRepository ViewPluNestingRepository = WsSqlViewPluNestingRepository.Instance;

    [Test]
    public void GetList()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlViewPluNestingModel> items = ViewPluNestingRepository.GetList();
            Assert.That(items.Any(), Is.True);
            WsTestsUtils.DataTests.PrintTopRecords(items, 10);
        }, false, DefaultPublishTypes);
    }
}