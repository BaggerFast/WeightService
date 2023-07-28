﻿namespace WsStorageCore.Tables.TableScaleModels.Organizations;

public class WsSqlOrganizationRepository : WsSqlTableRepositoryBase<WsSqlOrganizationModel>
{
    public List<WsSqlOrganizationModel> GetList(WsSqlCrudConfigModel sqlCrudConfig)
    {
        if (sqlCrudConfig.IsResultOrder)
            sqlCrudConfig.AddOrder(nameof(WsSqlTableBase.Name));
        return SqlCore.GetListNotNullable<WsSqlOrganizationModel>(sqlCrudConfig);
    }
}