// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageContextTests.Tables;

[TestFixture]
public sealed class GetListTablesTests
{
    [Test]
    public void Get_table_access_show_all()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlAccessModel> items = WsTestsUtils.DataTests.ContextManager.ContextAccess.GetList(WsSqlIsMarked.ShowAll);
            Assert.IsTrue(items.Any());
            WsTestsUtils.DataTests.PrintTopRecords(items, 0);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

    [Test]
    public void Get_table_access_show_only_actual()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlAccessModel> items = WsTestsUtils.DataTests.ContextManager.ContextAccess.GetList(WsSqlIsMarked.ShowOnlyActual);
            Assert.IsTrue(items.Any());
            WsTestsUtils.DataTests.PrintTopRecords(items, 0);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

    [Test]
    public void Get_table_access_show_only_hide()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlAccessModel> items = WsTestsUtils.DataTests.ContextManager.ContextAccess.GetList(WsSqlIsMarked.ShowOnlyHide);
            Assert.IsTrue(items.Any());
            WsTestsUtils.DataTests.PrintTopRecords(items, 0);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }
}