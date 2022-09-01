﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "ZebraPrinterType".
/// </summary>
[Serializable]
public class PrinterTypeModel : TableModel, ISerializable, ITableModel
{
	#region Public and private fields, properties, constructor

	[XmlElement] public virtual string Name { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	public PrinterTypeModel() : base(ColumnName.Id)
	{
		Name = string.Empty;
	}

	#endregion

	#region Public and private methods

	public new virtual string ToString() =>
		$"{nameof(IsMarked)}: {IsMarked}. " +
		$"{nameof(Name)}: {Name}. ";

	public virtual bool Equals(PrinterTypeModel item)
	{
		if (ReferenceEquals(this, item)) return true;
		return base.Equals(item) &&
			   Equals(Name, item.Name);
	}

	public new virtual bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((PrinterTypeModel)obj);
	}

	public virtual bool EqualsNew()
	{
		return Equals(new());
	}

	public new virtual bool EqualsDefault()
	{
		return base.EqualsDefault() &&
			   Equals(Name, string.Empty);
	}

	public new virtual int GetHashCode() => base.GetHashCode();

	public new virtual object Clone()
	{
		PrinterTypeModel item = new();
		item.Name = Name;
		item.CloneSetup(base.CloneCast());
		return item;
	}

	public new virtual PrinterTypeModel CloneCast() => (PrinterTypeModel)Clone();

	#endregion
}
