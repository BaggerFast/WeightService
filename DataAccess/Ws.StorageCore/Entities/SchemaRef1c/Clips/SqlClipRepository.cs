namespace Ws.StorageCore.Entities.SchemaRef1c.Clips;

/// <summary>
/// SQL-контроллер таблицы CLIPS.
/// Клиентский слой доступа к БД.
/// </summary>
public sealed class SqlClipRepository : SqlTableRepositoryBase<SqlClipEntity>
{
    public IEnumerable<SqlClipEntity> GetEnumerable(SqlCrudConfigModel sqlCrudConfig)
    {
        sqlCrudConfig.AddOrder(SqlOrder.NameAsc());
        return SqlCore.GetEnumerable<SqlClipEntity>(sqlCrudConfig);
    }

    public SqlClipEntity GetItemByUid1C(Guid uid1C)
    {
        SqlCrudConfigModel sqlCrudConfig = new();
        sqlCrudConfig.AddFilter(SqlRestrictions.EqualUid1C(uid1C));
        return SqlCore.GetItemByCrud<SqlClipEntity>(sqlCrudConfig);
    }
}