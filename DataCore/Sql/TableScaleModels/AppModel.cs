﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "APPS".
/// </summary>
[Serializable]
public class AppModel : TableBase, ICloneable, ISqlDbBase, ISerializable
{
	#region Public and private fields, properties, constructor

	[XmlElement] public virtual string Name { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	public AppModel() : base(SqlFieldIdentityEnum.Uid)
	{
		Name = string.Empty;
	}

	/// <summary>
	/// Constructor for serialization.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
    protected AppModel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Name = info.GetString(nameof(Name));
    }

	#endregion

	#region Public and private methods - override

	public override string ToString() =>
		$"{nameof(IsMarked)}: {IsMarked}. " +
        $"{nameof(Name)}: {Name}. ";

    public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((AppModel)obj);
    }

    public override int GetHashCode() => base.GetHashCode();

    public override bool EqualsNew() => Equals(new());

    public override bool EqualsDefault() =>
	    base.EqualsDefault() &&
	    Equals(Name, string.Empty);

    public override object Clone()
    {
        AppModel item = new();
        item.Name = Name;
		item.CloneSetup(base.CloneCast());
		return item;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(Name), Name);
    }

	#endregion

	#region Public and private methods - virtual

	public virtual bool Equals(AppModel item)
	{
		if (ReferenceEquals(this, item)) return true;
		return base.Equals(item) &&
		       Equals(Name, item.Name);
	}

	public new virtual AppModel CloneCast() => (AppModel)Clone();

	#endregion
}
