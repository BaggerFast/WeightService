namespace WsStorageCore.Entities.SchemaRef.ProductionSites;

/// <summary>
/// Table "ProductionSite".
/// </summary>
[DebuggerDisplay("{ToString()}")]
public class WsSqlProductionSiteEntity : WsSqlEntityBase
{
    #region Public and private fields, properties, constructor

    public virtual string Address { get; set; }
    
    public WsSqlProductionSiteEntity() : base(WsSqlEnumFieldIdentity.Uid)
    {
        Address = string.Empty;
    }

    public WsSqlProductionSiteEntity(WsSqlProductionSiteEntity item) : base(item)
    {
        Address = item.Address;
    }

    #endregion

    #region Public and private methods - override

    public override string ToString() => $"{GetIsMarked()} | {Address}";

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((WsSqlProductionSiteEntity)obj);
    }

    public override int GetHashCode() => base.GetHashCode();

    public override bool EqualsNew() => Equals(new());

    public override bool EqualsDefault() =>
        base.EqualsDefault() &&
        Equals(Address, string.Empty);

    #endregion

    #region Public and private methods - virtual

    public virtual bool Equals(WsSqlProductionSiteEntity item) =>
        ReferenceEquals(this, item) || base.Equals(item) && //-V3130
        Equals(Address, item.Address);

    #endregion
}