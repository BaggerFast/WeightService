namespace Ws.StorageCore.Models;

/// <summary>
/// DB field Identity model.
/// </summary>
[DebuggerDisplay("{ToString()}")]
public class SqlFieldIdentityModel
{
    #region Public and private fields, properties, constructor

     public virtual SqlEnumFieldIdentity Name { get; }
     public virtual Guid Uid { get; private set; }
     public virtual long Id { get; private set; }
     public virtual bool IsUid => Equals(Name, SqlEnumFieldIdentity.Uid);
     public virtual bool IsId => Equals(Name, SqlEnumFieldIdentity.Id);

    public SqlFieldIdentityModel()
    {
        Name = SqlEnumFieldIdentity.Empty;
        Uid = Guid.Empty;
        Id = 0;
    }

    public SqlFieldIdentityModel(SqlEnumFieldIdentity identityName) : this()
    {
        Name = identityName;
    }

    private SqlFieldIdentityModel(SqlEnumFieldIdentity identityName, long identityId, Guid identityUid) : this(identityName)
    {
        Uid = identityUid;
        Id = identityId;
    }

    public SqlFieldIdentityModel(SqlFieldIdentityModel item)
    {
        Name = item.Name;
        Uid = item.Uid;
        Id = item.Id;
    }

    #endregion

    #region Public and private methods - override

    public override string ToString() =>
        Name.Equals(SqlEnumFieldIdentity.Id) ? $"{Id}" : Name.Equals(SqlEnumFieldIdentity.Uid) ? $"{Uid}" : string.Empty;
    
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SqlFieldIdentityModel)obj);
    }

    public override int GetHashCode() => Name switch
    {
        SqlEnumFieldIdentity.Id => Id.GetHashCode(),
        SqlEnumFieldIdentity.Uid => Uid.GetHashCode(),
        _ => default
    };

    public bool EqualsNew() => Equals(new());

    public bool EqualsDefault() =>
        Equals(Id, (long)0) &&
        Equals(Uid, Guid.Empty);

    #endregion

    #region Public and private methods - virtual

    public virtual bool Equals(SqlFieldIdentityModel item) =>
        ReferenceEquals(this, item) || Equals(Name, item.Name) && //-V3130
        Id.Equals(item.Id) &&
        Uid.Equals(item.Uid);

    public virtual void SetId(long value) => Id = value;

    public virtual void SetUid(Guid value) => Uid = value;

    public virtual bool IsNew => Name switch
    {
        SqlEnumFieldIdentity.Id => Equals(Id, default(long)),
        SqlEnumFieldIdentity.Uid => Equals(Uid, Guid.Empty),
        _ => default
    };

    public virtual bool IsExists => Name switch
    {
        SqlEnumFieldIdentity.Id => !Equals(Id, default(long)),
        SqlEnumFieldIdentity.Uid => !Equals(Uid, Guid.Empty),
        _ => default
    };

    #endregion
}