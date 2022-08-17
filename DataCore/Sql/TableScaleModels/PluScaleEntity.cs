﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable VirtualMemberCallInConstructor

using static DataCore.Sql.SqlQueries.DbScales.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "PLUS_SCALES".
/// </summary>
[Serializable]
public class PluScaleEntity : BaseEntity, ISerializable, IBaseEntity
{
	#region Public and private fields, properties, constructor

	/// <summary>
	/// Identity name.
	/// </summary>
	[XmlElement] public static ColumnName IdentityName => ColumnName.Uid;

    [XmlElement] public virtual bool IsActive { get; set; }
    [XmlElement] public virtual PluEntity Plu { get; set; }
    [XmlElement] public virtual ScaleEntity Scale { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	public PluScaleEntity() : base(0, false)
	{
		Init();
	}

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="identityId"></param>
	/// <param name="isSetupDates"></param>
	public PluScaleEntity(long identityId, bool isSetupDates) : base(identityId, isSetupDates)
    {
		Init();
	}

	/// <summary>
	/// Constructor for serialization.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
    protected PluScaleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
    {
	    Plu = (PluEntity)info.GetValue(nameof(Plu), typeof(PluEntity));
	    Scale = (ScaleEntity)info.GetValue(nameof(Scale), typeof(ScaleEntity));
    }

    #endregion

    #region Public and private methods

    public new virtual void Init()
    {
	    base.Init();
	    IsActive = false;
	    Plu = new();
        Scale = new();
	}

    public override string ToString()
    {
	    return
		    $"{nameof(IdentityUid)}: {IdentityUid}. " +
		    $"{nameof(IsMarked)}: {IsMarked}. " +
		    $"{nameof(IsActive)}: {IsActive}. " +
		    $"{nameof(Plu)}: {Plu.Name}. " +
		    $"{nameof(Scale)}: {Scale.Description}. ";
    }

    public virtual bool Equals(PluScaleEntity item)
    {
        //if (item is null) return false;
        if (ReferenceEquals(this, item)) return true;
        if (!Plu.Equals(item.Plu))
            return false;
        if (!Scale.Equals(item.Scale))
            return false;
        return 
	        base.Equals(item) &&
			Equals(IsActive, item.IsActive) &&
			Equals(Plu, item.Plu) &&
			Equals(Scale, item.Scale);
    }

    public override bool Equals(object obj)
    {
        //if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((PluScaleEntity)obj);
    }

	public override int GetHashCode() => IdentityUid.GetHashCode();

	public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        if (!Plu.EqualsDefault())
            return false;
        if (!Scale.EqualsDefault())
            return false;
        return 
			base.EqualsDefault();
    }

    public new virtual object Clone()
    {
        PluScaleEntity item = new();
        item.IsActive = IsActive;
        item.Plu = Plu.CloneCast();
        item.Scale = Scale.CloneCast();
        item.Setup(((BaseEntity)this).CloneCast());
        return item;
    }

    public new virtual PluScaleEntity CloneCast() => (PluScaleEntity)Clone();

    public new virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(IsActive), IsActive);
        info.AddValue(nameof(Plu), Plu);
        info.AddValue(nameof(Scale), Scale);
    }
    
    #endregion
}