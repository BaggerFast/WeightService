// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Diagnostics.CodeAnalysis;

namespace WsStorageContextTests.TableConfModels;

[TestFixture]
public sealed class DeviceSettingsContentFkTests
{
    [Test]
    public void Validate_device_settings()
    {
        WsTestsUtils.DataTests.AssertSqlDbContentValidate<WsSqlDeviceSettingsFkModel>(WsSqlEnumIsMarked.ShowAll);
    }

    [Test]
    public void Get_table_devices_settings_fks_show_all()
    {
        WsTestsUtils.DataTests.AssertAction(() =>
        {
            List<WsSqlDeviceSettingsModel> deviceSettings = WsTestsUtils.DataTests.ContextManager.DeviceSettingsRepository.GetList();
            Assert.IsTrue(deviceSettings.Any());
            List<WsSqlDeviceModel> devices = WsTestsUtils.DataTests.ContextManager.DevicesRepository.GetList();
            Assert.IsTrue(devices.Any());
            List<WsSqlDeviceSettingsFkModel> deviceSettingsFks = WsTestsUtils.DataTests.ContextManager.DeviceSettingsFksRepository.GetList();

            // Для всех устройств.
            foreach (WsSqlDeviceModel device in devices)
            {
                // Для всех настроек.
                foreach (WsSqlDeviceSettingsModel setting in deviceSettings)
                {
                    // Поиск настройки устройства.
                    WsSqlDeviceSettingsFkModel? deviceSettingsFk = deviceSettingsFks.Find(
                        x => x.Device.Equals(device) && x.Setting.Equals(setting));
                    if (deviceSettingsFk is null)
                    {
                        // Настройка не найдена - создать.
                        deviceSettingsFk =
                            WsTestsUtils.DataTests.ContextManager.DeviceSettingsFksRepository.GetNewItem();
                        deviceSettingsFk.UpdateProperties(deviceSettingsFk, device, setting);
                        WsTestsUtils.DataTests.ContextManager.DeviceSettingsFksRepository.SaveItemAsync(deviceSettingsFk);
                    }
                }
            }

            // Получить заново список настроек устройств.
            deviceSettingsFks = WsTestsUtils.DataTests.ContextManager.DeviceSettingsFksRepository.GetList();

            Assert.IsTrue(deviceSettingsFks.Any());
            WsTestsUtils.DataTests.PrintTopRecords(deviceSettingsFks, 0);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }
}