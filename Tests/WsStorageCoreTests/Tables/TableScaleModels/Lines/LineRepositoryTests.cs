﻿using WsStorageCoreTests.Tables.Common;

namespace WsStorageCoreTests.Tables.TableScaleModels.Lines;

[TestFixture]
public sealed class LineRepositoryTests : TableRepositoryTests
{
    private WsSqlLineRepository LineRepository { get; set; } = new();

    private WsSqlScaleModel GetFirstLineModel()
    {
        return LineRepository.GetList(SqlCrudConfig).First();
    }
    
    [Test, Order(1)]
    public void GetList()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlScaleModel> items = LineRepository.GetList(SqlCrudConfig);
            Assert.That(items.Any(), Is.True);
            WsTestsUtils.DataTests.PrintTopRecords(items, 10);
        }, false, DefaultPublishTypes);
    }
    
    [Test, Order(3)]
    public void GetById()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            WsSqlScaleModel oldLine = GetFirstLineModel();
            WsSqlScaleModel lineById = LineRepository.GetItemById(oldLine.IdentityValueId);
            
            Assert.That(lineById.IsExists, Is.True);
            Assert.That(lineById.IdentityValueId, Is.EqualTo(oldLine.IdentityValueId));

            TestContext.WriteLine($"Get item success: {lineById.Description}: {lineById.IdentityValueId}");
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

    [Test, Order(4)]
    public void GetItemByDevice()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            SqlCrudConfig.SelectTopRowsCount = 1;
            WsSqlDeviceScaleFkModel devicesScale = WsSqlDeviceLineFkRepository.Instance.GetList(SqlCrudConfig).First();
            WsSqlDeviceModel device = devicesScale.Device;
            WsSqlScaleModel oldLine = devicesScale.Scale;
            
            WsSqlScaleModel lineByDevice = LineRepository.GetItemByDevice(device);

            Assert.That(lineByDevice.IsNotNew, Is.True);
            Assert.That(lineByDevice, Is.EqualTo(oldLine));
            
            TestContext.WriteLine(lineByDevice);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

}