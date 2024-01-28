using Ws.Database.Core.Common.Queries;
using Ws.Domain.Models.Entities.Print;

namespace Ws.Database.Core.Entities.Print.Labels;

public sealed class SqlLabelRepository : IGetItemByUid<LabelEntity>, IGetListByCriteria<LabelEntity>
{
    public LabelEntity GetByUid(Guid uid) => SqlCoreHelper.Instance.GetItemByUid<LabelEntity>(uid);
    
    public IEnumerable<LabelEntity> GetListByCriteria(DetachedCriteria criteria)
    {
        return SqlCoreHelper.Instance.GetEnumerable<LabelEntity>(criteria).ToList();
    }
}