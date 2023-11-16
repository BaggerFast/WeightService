﻿using WsStorageCore.Views.ViewRefModels.PluNestings;

namespace WsStorageCoreTests.Views.ViewRefModels.PluNestings;

public class ViewPluNestingRepositoryTests : ViewRepositoryTests
{
    private IViewPluNestingRepository ViewPluNestingRepository { get; } = new SqlViewPluNestingRepository();

    protected override IResolveConstraint SortOrderValue => Is
        .Ordered.By(nameof(SqlViewPluNestingModel.PluNumber)).Ascending
        .Then.By(nameof(SqlViewPluNestingModel.PluName)).Ascending;

    [Test]
    public void GetList()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            IEnumerable<SqlViewPluNestingModel> items = ViewPluNestingRepository.GetEnumerable();
            PrintViewRecords(items);
        }, false);
    }
}