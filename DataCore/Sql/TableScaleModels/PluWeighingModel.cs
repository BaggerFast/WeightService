﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable VirtualMemberCallInConstructor

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "PLUS_WEIGHINGS".
/// </summary>
[Serializable]
public class PluWeighingModel : TableModel, ISerializable, ITableModel
{
    #region Public and private fields, properties, constructor

    [XmlElement] public virtual PluScaleModel PluScale { get; set; }
    [XmlElement] public virtual ProductSeriesModel Series { get; set; }
    [XmlElement] public virtual short Kneading { get; set; }
    [XmlElement] public virtual string Sscc { get; set; }
    [XmlElement] public virtual decimal NettoWeight { get; set; }
    [XmlElement] public virtual decimal TareWeight { get; set; }
    [XmlElement] public virtual DateTime ProductDt { get; set; }
    [XmlElement] public virtual int RegNum { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public PluWeighingModel()
    {
	    PluScale = new();
	    Series = new();
	    Kneading = 0;
	    Sscc = string.Empty;
	    NettoWeight = 0;
	    TareWeight = 0;
	    ProductDt = DateTime.MinValue;
	    RegNum = 0;
    }

	/// <summary>
	/// Constructor for serialization.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected PluWeighingModel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        PluScale = (PluScaleModel)info.GetValue(nameof(PluScale), typeof(PluScaleModel));
        Series = (ProductSeriesModel)info.GetValue(nameof(Series), typeof(ProductSeriesModel));
        Kneading = info.GetInt16(nameof(Kneading));
		Sscc = info.GetString(nameof(Sscc));
        NettoWeight = info.GetDecimal(nameof(NettoWeight));
        TareWeight = info.GetDecimal(nameof(TareWeight));
        ProductDt = info.GetDateTime(nameof(ProductDt));
        RegNum = info.GetInt32(nameof(RegNum));
    }

	#endregion

	#region Public and private methods

	public new virtual string ToString() =>
		$"{nameof(IsMarked)}: {IsMarked}. " +
	    $"{nameof(Kneading)}: {Kneading}. " +
	    $"{nameof(PluScale)}: {PluScale}. " + 
	    $"{nameof(Series)}: {Series}. ";

    public virtual bool Equals(PluWeighingModel item)
    {
        if (ReferenceEquals(this, item)) return true;
        if (!PluScale.Equals(item.PluScale))
            return false;
        return
            base.Equals(item) &&
            Equals(Kneading, item.Kneading) &&
            Equals(PluScale, item.PluScale) &&
            Equals(Sscc, item.Sscc) &&
            Equals(NettoWeight, item.NettoWeight) &&
            Equals(TareWeight, item.TareWeight) &&
            Equals(ProductDt, item.ProductDt) &&
            Equals(RegNum, item.RegNum);
    }

	public new virtual bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((PluWeighingModel)obj);
    }

    public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        if (!PluScale.EqualsDefault())
            return false;
        if (!Series.EqualsDefault())
            return false;
        return
            base.EqualsDefault() &&
            Equals(Kneading, default(short)) &&
            Equals(Sscc, string.Empty) &&
            Equals(NettoWeight, default(decimal)) &&
            Equals(TareWeight, default(decimal)) &&
            Equals(ProductDt, DateTime.MinValue) &&
            Equals(RegNum, default(int));
    }

    public new virtual int GetHashCode() => base.GetHashCode();

	public new virtual object Clone()
    {
        PluWeighingModel item = new();
        item.Kneading = Kneading;
        item.PluScale = PluScale.CloneCast();
        item.Sscc = Sscc;
        item.NettoWeight = NettoWeight;
        item.TareWeight = TareWeight;
        item.ProductDt = ProductDt;
        item.RegNum = RegNum;
        item.CloneSetup(base.CloneCast());
		return item;
    }

    public new virtual PluWeighingModel CloneCast() => (PluWeighingModel)Clone();

    public new virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(PluScale), PluScale);
        info.AddValue(nameof(Series), Series);
        info.AddValue(nameof(Kneading), Kneading);
        info.AddValue(nameof(Sscc), Sscc);
        info.AddValue(nameof(NettoWeight), NettoWeight);
        info.AddValue(nameof(TareWeight), TareWeight);
        info.AddValue(nameof(ProductDt), ProductDt);
        info.AddValue(nameof(RegNum), RegNum);
    }

    #endregion
}
