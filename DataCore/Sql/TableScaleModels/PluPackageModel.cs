﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable VirtualMemberCallInConstructor

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "PLUS_PACKAGES".
/// </summary>
[Serializable]
public class PluPackageModel : SqlTableBase, ICloneable, ISqlDbBase, ISerializable
{
    #region Public and private fields, properties, constructor

    [XmlElement] public virtual bool IsActive { get; set; }
    [XmlElement] public virtual string Name { get; set; }
    [XmlElement] public virtual PackageModel Package { get; set; }
    [XmlElement] public virtual PluModel Plu { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public PluPackageModel() : base(SqlFieldIdentityEnum.Uid)
	{
        IsActive = false;
		Name = string.Empty;
	    Package = new();
	    Plu = new();
	}

	/// <summary>
    /// Constructor for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected PluPackageModel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
	    IsActive = info.GetBoolean(nameof(IsActive));
        Name = info.GetString(nameof(Name));
        Package = (PackageModel)info.GetValue(nameof(Package), typeof(PackageModel));
        Plu = (PluModel)info.GetValue(nameof(Plu), typeof(PluModel));
    }

	#endregion

	#region Public and private methods - override

	public override string ToString() =>
		$"{nameof(IsMarked)}: {IsMarked}. " +
		$"{nameof(IsActive)}: {IsActive}. " +
	    $"{nameof(Name)}: {Name}. " +
	    $"{nameof(Package)}: {Package}. " + 
	    $"{nameof(Plu)}: {Plu}. ";

    public override bool Equals(object obj)
	{
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((PluPackageModel)obj);
    }

    public override int GetHashCode() => (Name, Package, Plu).GetHashCode();

    public override bool EqualsNew() => Equals(new());

    public override bool EqualsDefault()
    {
	    if (!Package.EqualsDefault())
		    return false;
		if (!Plu.EqualsDefault())
			return false;
        return
			base.EqualsDefault() &&
            Equals(IsActive, false) &&
            Equals(Name, string.Empty);
    }

	public override object Clone()
    {
        PluPackageModel item = new();
        item.IsActive = IsActive;
		item.Name = Name;
        item.Package = Package.CloneCast();
        item.Plu = Plu.CloneCast();
        item.CloneSetup(base.CloneCast());
		return item;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(IsActive), IsActive);
        info.AddValue(nameof(Name), Name);
        info.AddValue(nameof(Package), Package);
        info.AddValue(nameof(Plu), Plu);
    }

    public override void FillProperties()
    {
	    base.FillProperties();
        IsActive = false;
		Name = LocaleCore.Sql.SqlItemFieldNesting;
		//Package = new();
		//Plu = new();
    }

	#endregion

	#region Public and private methods - virtual

	public virtual bool Equals(PluPackageModel item)
	{
		if (ReferenceEquals(this, item)) return true;
		if (!Package.Equals(item.Package))
			return false;
		if (!Plu.Equals(item.Plu))
			return false;
		return
			base.Equals(item) &&
            Equals(IsActive, item.IsActive) &&
			Equals(Name, item.Name);
	}

	public new virtual PluPackageModel CloneCast() => (PluPackageModel)Clone();

	#endregion
}
