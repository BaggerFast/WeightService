﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "BARCODES_V2".
/// </summary>
[Serializable]
public class BarCodeModel : TableModel, ISerializable, ITableModel
{
	#region Public and private fields, properties, constructor

	[XmlElement] public virtual string Value { get; set; }
    [XmlElement] public virtual BarCodeTypeModel? BarcodeType { get; set; }
	[XmlElement] public virtual ContragentModel? Contragent { get; set; }
	[XmlElement] public virtual NomenclatureModel? Nomenclature { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
    public BarCodeModel()
	{
		Value = string.Empty;
		BarcodeType = new();
		Contragent = new();
		Nomenclature = new();
	}

	/// <summary>
	/// Constructor for serialization.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
    protected BarCodeModel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Value = info.GetString(nameof(Value));
        BarcodeType = (BarCodeTypeModel)info.GetValue(nameof(BarcodeType), typeof(BarCodeTypeModel));
        Contragent = (ContragentModel)info.GetValue(nameof(Contragent), typeof(ContragentModel));
        Nomenclature = (NomenclatureModel)info.GetValue(nameof(Nomenclature), typeof(NomenclatureModel));
    }

	#endregion

	#region Public and private methods

	public new virtual string ToString() =>
		$"{nameof(IsMarked)}: {IsMarked}. " +
	    $"{nameof(Value)}: {Value}. " +
	    $"{nameof(BarcodeType)}: {BarcodeType?.ToString() ?? "null"}. " +
	    $"{nameof(Contragent)}: {Contragent?.ToString() ?? "null"}. " +
	    $"{nameof(Nomenclature)}: {Nomenclature?.ToString() ?? "null"}. ";

    public virtual bool Equals(BarCodeModel item)
    {
        if (ReferenceEquals(this, item)) return true;
        if (BarcodeType != null && item.BarcodeType != null && !BarcodeType.Equals(item.BarcodeType))
            return false;
        if (Contragent != null && item.Contragent != null && !Contragent.Equals(item.Contragent))
            return false;
        if (Nomenclature != null && item.Nomenclature != null && !Nomenclature.Equals(item.Nomenclature))
            return false;
        return base.Equals(item) &&
            Equals(Value, item.Value);
    }

	public new virtual bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((BarCodeModel)obj);
    }

	public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        if (BarcodeType != null && !BarcodeType.EqualsDefault())
            return false;
        if (Contragent != null && !Contragent.EqualsDefault())
            return false;
        if (Nomenclature != null && !Nomenclature.EqualsDefault())
            return false;
        return base.EqualsDefault() &&
            Equals(Value, string.Empty);
    }

    public new virtual int GetHashCode() => base.GetHashCode();

	public new virtual object Clone()
    {
        BarCodeModel item = new();
        item.Value = Value;
        item.BarcodeType = BarcodeType?.CloneCast();
        item.Contragent = Contragent?.CloneCast();
        item.Nomenclature = Nomenclature?.CloneCast();
		item.CloneSetup(base.CloneCast());
		return item;
    }

    public new virtual BarCodeModel CloneCast() => (BarCodeModel)Clone();

    public new virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(Value), Value);
        info.AddValue(nameof(BarcodeType), BarcodeType);
        info.AddValue(nameof(Contragent), Contragent);
        info.AddValue(nameof(Nomenclature), Nomenclature);
    }

    #endregion
}