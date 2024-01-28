using Ws.Database.Core.Common.Queries;
using Ws.Domain.Models.Entities.Ref;

namespace Ws.Database.Core.Entities.Ref.Warehouses;

public sealed class SqlWarehouseRepository : IGetItemByUid<WarehouseEntity>, IGetAll<WarehouseEntity>
{
    public WarehouseEntity GetByUid(Guid uid) => SqlCoreHelper.Instance.GetItemByUid<WarehouseEntity>(uid);
    
    public IEnumerable<WarehouseEntity> GetAll()
    {
        DetachedCriteria criteria = DetachedCriteria.For<WarehouseEntity>().AddOrder(SqlOrder.NameAsc());
        return SqlCoreHelper.Instance.GetEnumerable<WarehouseEntity>(criteria);
    }
}