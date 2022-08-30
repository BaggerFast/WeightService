﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.QueriesModels;

[Serializable]
public class WeithingFactSummaryModel : TableModel, ISerializable, ITableModel
{
    #region Public and private fields, properties, constructor

    public virtual DateTime WeithingDate { get; set; }
    public virtual int Count { get; set; }
    public virtual string Scale { get; set; }
    public virtual string Host { get; set; }
    public virtual string Printer { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	public WeithingFactSummaryModel() : base(ColumnName.Id, 0, false)
    {
	    Init();
    }

	public WeithingFactSummaryModel(long identityId, bool isSetupDates) : base(ColumnName.Id, identityId, isSetupDates)
    {
	    Init();
    }

    #endregion

    #region Public and private methods

    public new virtual void Init()
    {
	    base.Init();
        WeithingDate = DateTime.MinValue;
        Count = 0;
        Scale = string.Empty;
        Host = string.Empty;
        Printer = string.Empty;
    }

    public override string ToString() =>
        base.ToString() +
        $"{nameof(WeithingDate)}: {WeithingDate}. " +
        $"{nameof(Count)}: {Count}. " +
        $"{nameof(Scale)}: {Scale}. " +
        $"{nameof(Host)}: {Host}. " +
        $"{nameof(Printer)}: {Printer}. ";

    public virtual bool Equals(WeithingFactSummaryModel item)
    {
        if (item is null) return false;
        if (ReferenceEquals(this, item)) return true;
        return base.Equals(item) &&
               Equals(WeithingDate, item.WeithingDate) &&
               Equals(Count, item.Count) &&
               Equals(Scale, item.Scale) &&
               Equals(Host, item.Host) &&
               Equals(Printer, item.Printer);
    }

    public override bool Equals(object obj)
    {
	    if (ReferenceEquals(null, obj)) return false;
	    if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((WeithingFactSummaryModel)obj);
    }

    public override int GetHashCode() => base.GetHashCode();

    public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        return base.EqualsDefault() &&
               Equals(WeithingDate, DateTime.MinValue) &&
               Equals(Count, 0) &&
               Equals(Scale, string.Empty) &&
               Equals(Host, string.Empty) &&
               Equals(Printer, string.Empty);
    }

    public new virtual object Clone()
    {
        WeithingFactSummaryModel item = new();
        item.WeithingDate = WeithingDate;
        item.Count = Count;
        item.Scale = Scale;
        item.Host = Host;
        item.Printer = Printer;
        item.Setup(((TableModel)this).CloneCast());
        return item;
    }

    public new virtual WeithingFactSummaryModel CloneCast() => (WeithingFactSummaryModel)Clone();

    #endregion
}