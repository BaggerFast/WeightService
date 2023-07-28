﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Tables.TableScaleFkModels.DeviceTypesFks;

public class WsSqlDeviceTypeFkRepository : WsSqlTableRepositoryBase<WsSqlDeviceTypeFkModel>
{
    public WsSqlDeviceTypeFkModel GetItemByDevice(WsSqlDeviceModel device)
    {
        WsSqlCrudConfigModel sqlCrudConfig = WsSqlCrudConfigFactory.GetCrudAll();
        sqlCrudConfig.AddFkIdentityFilter(nameof(WsSqlDeviceTypeFkModel.Device), device);
        return SqlCore.GetItemByCrud<WsSqlDeviceTypeFkModel>(sqlCrudConfig);
    }

    public List<WsSqlDeviceTypeFkModel> GetList(WsSqlCrudConfigModel sqlCrudConfig)
    {
        List<WsSqlDeviceTypeFkModel> result = SqlCore.GetListNotNullable<WsSqlDeviceTypeFkModel>(sqlCrudConfig);
        if (sqlCrudConfig.IsResultOrder)
            result = result
                .OrderBy(item => item.Type.Name)
                .ThenBy(item => item.Device.Name).ToList();
        return result;
    }
}