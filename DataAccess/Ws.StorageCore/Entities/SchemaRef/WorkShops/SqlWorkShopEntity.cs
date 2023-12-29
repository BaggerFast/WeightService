// ReSharper disable VirtualMemberCallInConstructor, ClassWithVirtualMembersNeverInherited.Global
namespace Ws.StorageCore.Entities.SchemaRef.WorkShops;

[DebuggerDisplay("{ToString()}")]
public class SqlWorkShopEntity : SqlEntityBase
{
    public virtual SqlProductionSiteEntity ProductionSite { get; set; }

    public SqlWorkShopEntity() : base(SqlEnumFieldIdentity.Uid)
    {
        ProductionSite = new();
    }

    public SqlWorkShopEntity(SqlWorkShopEntity item) : base(item)
    {
        ProductionSite = new(item.ProductionSite);
    }

    public override string ToString() =>
        $"{nameof(Name)}: {Name}. " +
        $"{nameof(ProductionSite)}: {ProductionSite}. ";

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SqlWorkShopEntity)obj);
    }

    public override int GetHashCode() => base.GetHashCode();
    
    public virtual bool Equals(SqlWorkShopEntity item) =>
        ReferenceEquals(this, item) || base.Equals(item) &&
        ProductionSite.Equals(item.ProductionSite);
}
