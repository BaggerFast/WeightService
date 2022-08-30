﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "CONTRAGENTS_V2".
/// </summary>
[Serializable]
public class ContragentEntity : TableModel, ISerializable, ITableModel
{
    #region Public and private fields, properties, constructor

    [XmlElement] public virtual string Name { get; set; }
    [XmlElement] public virtual string FullName { get; set; }
    [XmlElement] public virtual Guid IdRRef { get; set; }
    public virtual string IdRRefAsString
    {
        get => IdRRef.ToString();
        set => IdRRef = Guid.Parse(value);
    }
    [XmlElement] public virtual int DwhId { get; set; }
    [XmlElement] public virtual string Xml { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
    public ContragentEntity() : base(ColumnName.Uid, Guid.Empty, false)
	{
		Init();
	}

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="identityUid"></param>
	/// <param name="isSetupDates"></param>
	public ContragentEntity(Guid identityUid, bool isSetupDates) : base(ColumnName.Uid, identityUid, isSetupDates)
    {
		Init();
	}

    #endregion

    #region Public and private methods

    public new virtual void Init()
    {
	    base.Init();
	    Name = string.Empty;
		FullName = string.Empty;
		IdRRef = Guid.Empty;
		DwhId = 0;
		Xml = string.Empty;
	}

    public override string ToString() =>
        $"{nameof(IdentityUid)}: {IdentityUid}. " +
        $"{nameof(IsMarked)}: {IsMarked}. " +
        $"{nameof(Name)}: {Name}. " +
        $"{nameof(DwhId)}: {DwhId}. ";

    public virtual bool Equals(ContragentEntity item)
    {
        if (item is null) return false;
        if (ReferenceEquals(this, item)) return true;
        return base.Equals(item) &&
               Equals(Name, item.Name) &&
               Equals(FullName, item.FullName) &&
               Equals(IdRRef, item.IdRRef) &&
               Equals(DwhId, item.DwhId) &&
               Equals(Xml, item.Xml);
    }

    public override bool Equals(object obj)
    {
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((ContragentEntity)obj);
    }

	public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        return base.EqualsDefault() &&
               Equals(Name, string.Empty) &&
               Equals(FullName, string.Empty) &&
               Equals(IdRRef, Guid.Empty) &&
               Equals(DwhId, 0) &&
               Equals(Xml, string.Empty);
    }

    public new virtual object Clone()
    {
        ContragentEntity item = new();
        item.Name = Name;
        item.FullName = FullName;
        item.IdRRef = IdRRef;
        item.DwhId = DwhId;
        item.Xml = Xml;
        item.Setup(((TableModel)this).CloneCast());
        return item;
    }

    public new virtual ContragentEntity CloneCast() => (ContragentEntity)Clone();

    #endregion
}
