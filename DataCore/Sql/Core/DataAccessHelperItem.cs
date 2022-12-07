﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Models;
using DataCore.Protocols;
using DataCore.Sql.Tables;

namespace DataCore.Sql.Core;

public partial class DataAccessHelper
{
    #region Public and public methods

    public AccessModel? GetItemAccessNullable(string? userName)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(nameof(SqlTableBase.Name), userName, false, false);
        return GetItemNullable<AccessModel>(sqlCrudConfig);
    }

    public ProductSeriesModel? GetItemProductSeriesNullable(ScaleModel scale)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            new List<SqlFieldFilterModel>
            {
                new(nameof(ProductSeriesModel.IsClose), SqlFieldComparerEnum.Equal, false),
                new($"{nameof(ProductSeriesModel.Scale)}.{nameof(ScaleModel.IdentityValueId)}",                     SqlFieldComparerEnum.Equal, scale.IdentityValueId),
            }, false, false);
        return GetItemNullable<ProductSeriesModel>(sqlCrudConfig);
    }

    public TemplateModel? GetItemTemplateNullable(PluScaleModel pluScale)
    {
        if (!pluScale.IdentityIsNotNew || !pluScale.Plu.IdentityIsNotNew) return null;

        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(nameof(SqlTableBase.IdentityValueId), pluScale.Plu.Template.IdentityValueId, false, false);
        return GetItemNullable<TemplateModel>(sqlCrudConfig);
    }

    private AppModel GetItemAppOrCreateNew(string appName)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(nameof(SqlTableBase.Name), appName, false, false);
        AppModel app = GetItemNotNullable<AppModel>(sqlCrudConfig);
        if (app.IdentityIsNew)
        {
            app = new()
            {
                Name = appName,
                CreateDt = DateTime.Now,
                ChangeDt = DateTime.Now,
            };
            Save(app);
        }
        else
        {
            app.ChangeDt = DateTime.Now;
            Update(app);
        }
        return app;
    }

    public AppModel? GetItemAppNullable(string appName)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(nameof(SqlTableBase.Name), appName, false, false);
        return GetItemNullable<AppModel>(sqlCrudConfig);
    }

    private DeviceModel GetItemDeviceOrCreateNew(string name)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            nameof(SqlTableBase.Name), name, true, false);
        DeviceModel device = GetItemNotNullable<DeviceModel>(sqlCrudConfig);
        if (device.IdentityIsNew)
        {
            device = new()
            {
                Name = name,
                PrettyName = name,
                CreateDt = DateTime.Now,
                ChangeDt = DateTime.Now,
                LoginDt = DateTime.Now,
                LogoutDt = DateTime.Now,
                Ipv4 = NetUtils.GetLocalIpAddress(),
            };
            Save(device);
        }
        else
        {
            device.ChangeDt = DateTime.Now;
            device.LoginDt = DateTime.Now;
            Update(device);
        }
        return device;
    }

    private ScaleModel? GetItemScaleNullable(DeviceModel device)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            SqlCrudConfigModel.GetFiltersIdentity($"{nameof(DeviceScaleFkModel.Device)}", device.IdentityValueUid), false, false);
        return GetItemNotNullable<DeviceScaleFkModel>(sqlCrudConfig).Scale;
    }

    public ScaleModel GetItemScaleNotNullable(DeviceModel device) => GetItemScaleNullable(device) ?? new();

    private DeviceModel? GetItemDeviceNullable(string name)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(nameof(SqlTableBase.Name), name, false, false);
        return GetItemNullable<DeviceModel>(sqlCrudConfig);
    }

    public DeviceModel? GetItemDeviceNullable(ScaleModel scale)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            SqlCrudConfigModel.GetFiltersIdentity(nameof(DeviceScaleFkModel.Scale), scale.IdentityValueId), false, false);
        return GetItemNullable<DeviceScaleFkModel>(sqlCrudConfig)?.Device;
    }

    public DeviceModel GetItemDeviceNotNullable(string name) => GetItemDeviceNullable(name) ?? new();

    public DeviceModel GetItemDeviceNotNullable(ScaleModel scale) => GetItemDeviceNullable(scale) ?? new();

    public DeviceTypeModel? GetItemDeviceTypeNullable(string typeName)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            SqlCrudConfigModel.GetFilters(nameof(DeviceTypeModel.Name), typeName), false, false);
        return GetItemNullable<DeviceTypeModel>(sqlCrudConfig);
    }

    public DeviceTypeModel GetItemDeviceTypeNotNullable(string typeName) =>
        GetItemDeviceTypeNullable(typeName) ?? new();

    public DeviceTypeFkModel? GetItemDeviceTypeFkNullable(DeviceModel device)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            SqlCrudConfigModel.GetFiltersIdentity(nameof(DeviceTypeFkModel.Device), device.IdentityValueUid), false, false);
        return GetItemNullable<DeviceTypeFkModel>(sqlCrudConfig);
    }

    public DeviceTypeFkModel GetItemDeviceTypeFkNotNullable(DeviceModel device) =>
        GetItemDeviceTypeFkNullable(device) ?? new();

    public DeviceScaleFkModel? GetItemDeviceScaleFkNullable(DeviceModel device)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            SqlCrudConfigModel.GetFiltersIdentity(nameof(DeviceScaleFkModel.Device), device.IdentityValueUid), false, false);
        return GetItemNullable<DeviceScaleFkModel>(sqlCrudConfig);
    }

    public DeviceScaleFkModel GetItemDeviceScaleFkNotNullable(DeviceModel device) =>
        GetItemDeviceScaleFkNullable(device) ?? new();

    public DeviceScaleFkModel? GetItemDeviceScaleFkNullable(ScaleModel scale)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            SqlCrudConfigModel.GetFiltersIdentity(nameof(DeviceScaleFkModel.Scale), scale.IdentityValueId), false, false);
        return GetItemNullable<DeviceScaleFkModel>(sqlCrudConfig);
    }

    public DeviceScaleFkModel GetItemDeviceScaleFkNotNullable(ScaleModel scale) =>
        GetItemDeviceScaleFkNullable(scale) ?? new();

    public LogTypeModel? GetItemLogTypeNullable(LogTypeEnum logType)
    {
        SqlCrudConfigModel sqlCrudConfig = new(new List<SqlFieldFilterModel>
            { new(nameof(LogTypeModel.Number), SqlFieldComparerEnum.Equal, (byte)logType) },
            true, true, false, false);
        return GetItemNullable<LogTypeModel>(sqlCrudConfig);
    }

    public string GetAccessRightsDescription(AccessRightsEnum? accessRights)
    {
        return accessRights switch
        {
            AccessRightsEnum.Read => LocaleCore.Strings.AccessRightsRead,
            AccessRightsEnum.Write => LocaleCore.Strings.AccessRightsWrite,
            AccessRightsEnum.Admin => LocaleCore.Strings.AccessRightsAdmin,
            _ => LocaleCore.Strings.AccessRightsNone,
        };
    }

    public string GetAccessRightsDescription(byte accessRights) =>
        GetAccessRightsDescription((AccessRightsEnum)accessRights);

    public ScaleModel GetScaleNotNullable(long id)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            nameof(SqlTableBase.IdentityValueId), id, false, false);
        return DataAccessHelper.Instance.GetItemNotNullable<ScaleModel>(sqlCrudConfig);
    }

    public ProductionFacilityModel GetProductionFacilityNotNullable(string name)
    {
        SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
            nameof(ProductionFacilityModel.Name), name, false, false);
        return DataAccessHelper.Instance.GetItemNotNullable<ProductionFacilityModel>(sqlCrudConfig);
    }

    #endregion
}
