namespace WsStorageCore.Tables.TableScaleFkModels.PrintersResourcesFks;

public class WsSqlPrinterResourceFkRepository : WsSqlTableRepositoryBase<WsSqlPrinterResourceFkModel>
{
    public IList<WsSqlPrinterResourceFkModel> GetList(WsSqlCrudConfigModel sqlCrudConfig)
    {
        //if (sqlCrudConfig.IsResultOrder)
        //    sqlCrudConfig.AddOrders(new(nameof(WsSqlTableBase.Name), SqlOrderDirection.Asc));
        IEnumerable<WsSqlPrinterResourceFkModel> items = SqlCore.GetEnumerable<WsSqlPrinterResourceFkModel>(sqlCrudConfig);
        if (sqlCrudConfig.IsResultOrder)
            items = items
                .OrderBy(item => item.Printer.Name)
                .ThenBy(item => item.TemplateResource.Name);
        return items.ToList();
    }
}