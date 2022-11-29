﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Models;
using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "BRANDS".
/// </summary>
[XmlRoot("Brand", Namespace = "", IsNullable = false)]
public class BrandModel : SqlTableBase, ICloneable, ISqlDbBase, ISerializable
{
    #region Public and private fields, properties, constructor
    
	[XmlAttribute] public virtual string Code { get; set; }
	[XmlIgnore] public virtual ParseResultModel ParseResult { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public BrandModel() : base(SqlFieldIdentityEnum.Uid)
	{
		Code = string.Empty;
		ParseResult = new();
    }

	/// <summary>
	/// Constructor for serialization.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	private BrandModel(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		Code = info.GetString(nameof(Code));
        ParseResult = (ParseResultModel)info.GetValue(nameof(ParseResult), typeof(ParseResultModel));
    }

	#endregion

	#region Public and private methods - override

	/// <summary>
	/// To string.
	/// </summary>
	/// <returns></returns>
	public override string ToString() =>
		$"{nameof(IsMarked)}: {IsMarked}. " +
		$"{nameof(Name)}: {Name}. " + 
		$"{nameof(Code)}: {Code}. ";

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((BrandModel)obj);
	}

	public override int GetHashCode() => base.GetHashCode();

	public override bool EqualsNew() => Equals(new());

	public override bool EqualsDefault() =>
		base.EqualsDefault() &&
		Equals(Code, string.Empty) &&
        ParseResult.EqualsDefault();

	public override object Clone()
	{
		BrandModel item = new();
		item.Code = Code;
		item.ParseResult = ParseResult.CloneCast();
        item.CloneSetup(base.CloneCast());
		return item;
	}

	/// <summary>
	/// Get object data for serialization info.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(nameof(Code), Code);
		info.AddValue(nameof(ParseResult), ParseResult);
	}

	public override void FillProperties()
	{
		base.FillProperties();
		Code = LocaleCore.Sql.SqlItemFieldCode;
	}

	#endregion

	#region Public and private methods - virtual

	public virtual bool Equals(BrandModel item) =>
		ReferenceEquals(this, item) || base.Equals(item) && //-V3130
		Equals(Code, item.Code) &&
		Equals(ParseResult, item.ParseResult);

	public new virtual BrandModel CloneCast() => (BrandModel)Clone();

    public virtual void UpdateProperties(BrandModel brand)
    {
		base.UpdateProperties(brand);
        Code = brand.Code;
        ParseResult = brand.ParseResult.CloneCast();
    }
    
	#endregion
}
