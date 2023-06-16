// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsStorageCore.TableRefModels.Plus1CFk;
using WsStorageCore.TableScaleModels.Plus;

namespace WsWebApiCoreTests.Common;

[TestFixture]
public class WsServiceControllerBaseTests
{
    [Test]
    public void Fill_plus_1c_fks()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            if (WsTestsUtils.ContextManager.SqlCore.SessionFactory is null) 
                throw new ArgumentException(nameof(WsTestsUtils.ContextManager.SqlCore.SessionFactory));
            WsServiceControllerBase wsServiceController = new(WsTestsUtils.ContextManager.SqlCore.SessionFactory);
            // Заполнить таблицу связей разрешённых для загрузки ПЛУ из 1С.
            List<Exception> exceptions = wsServiceController.FillPlus1CFksDb();
            if (exceptions.Any())
                TestContext.WriteLine(string.Join(Environment.NewLine, exceptions));
            else
                TestContext.WriteLine("FillPlus1CFksDb is ok.");
            Assert.IsTrue(!exceptions.Any());

            Assert.IsTrue(wsServiceController.CheckExistsAllPlus1CFksDb());
            WsTestsUtils.DataTests.PrintTopRecords(WsTestsUtils.ContextManager.ContextPlu1CFk.GetList(), 5);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

    [Test]
    public void Fill_plus_1c_fks_next_check_all_exists()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            if (WsTestsUtils.ContextManager.SqlCore.SessionFactory is null)
                throw new ArgumentException(nameof(WsTestsUtils.ContextManager.SqlCore.SessionFactory));
            WsServiceControllerBase wsServiceController = new(WsTestsUtils.ContextManager.SqlCore.SessionFactory);
            // Проверить наличие всех связей разрешённых для загрузки ПЛУ из 1С.
            bool flag = wsServiceController.CheckExistsAllPlus1CFksDb();
            if (!flag)
                TestContext.WriteLine($"Run {nameof(Fill_plus_1c_fks)} first!");
            Assert.IsTrue(flag);
            WsTestsUtils.DataTests.PrintTopRecords(WsTestsUtils.ContextManager.ContextPlu1CFk.GetList(), 0);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }
    
    [Test]
    public void Get_list_plus_1c_fks()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            if (WsTestsUtils.ContextManager.SqlCore.SessionFactory is null)
                throw new ArgumentException(nameof(WsTestsUtils.ContextManager.SqlCore.SessionFactory));
            WsServiceControllerBase wsServiceController = new(WsTestsUtils.ContextManager.SqlCore.SessionFactory);
            WsSqlPluModel plu301 = WsTestsUtils.ContextManager.ContextPlus.GetItemByNumber(301);
            TestContext.WriteLine($"{nameof(plu301)}: {plu301}");
            // Получить список связей обмена ПЛУ 1С по GUID_1C.
            List<WsSqlPlu1CFkModel> plus1CFks = wsServiceController.GetPlus1CFksByGuid1C(plu301.Uid1C);
            Assert.IsTrue(plus1CFks.Any());
            WsTestsUtils.DataTests.PrintTopRecords(plus1CFks, 0);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }
}