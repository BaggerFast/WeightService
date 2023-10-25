// ReSharper disable VirtualMemberCallInConstructor

namespace WsStorageCore.Entities.SchemaScale.PlusStorageMethods;

[Serializable]
[DebuggerDisplay("{ToString()}")]
public class WsSqlPluStorageMethodEntity : WsSqlEntityBase
{
    #region Public and private fields, properties, constructor

    public virtual short MinTemp { get; set; }
    public virtual short MaxTemp { get; set; }
    
    public WsSqlPluStorageMethodEntity() : base(WsSqlEnumFieldIdentity.Uid)
    {
        MinTemp = default;
        MaxTemp = default;
    }

    public WsSqlPluStorageMethodEntity(WsSqlPluStorageMethodEntity item) : base(item)
    {
        MinTemp = item.MinTemp;
        MaxTemp = item.MaxTemp;
    }

    #endregion

    #region Public and private methods - override

    public override string ToString() =>
        $"{GetIsMarked()} | " +
        $"{nameof(Name)}: {Name}. " +
        $"{nameof(MinTemp)}: {MinTemp}. " +
        $"{nameof(MaxTemp)}: {MaxTemp}.";

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((WsSqlPluStorageMethodEntity)obj);
    }

    public override int GetHashCode() => IdentityValueUid.GetHashCode();

    public override bool EqualsNew() => Equals(new());

    public override bool EqualsDefault() =>
        base.EqualsDefault() &&
        Equals(MinTemp, default(short)) &&
        Equals(MaxTemp, default(short));
    
    #endregion

    #region Public and private methods - virtual

    public virtual bool Equals(WsSqlPluStorageMethodEntity item) =>
        ReferenceEquals(this, item) || base.Equals(item) && //-V3130
        Equals(MinTemp, item.MinTemp) &&
        Equals(MaxTemp, item.MaxTemp);

    #endregion
}