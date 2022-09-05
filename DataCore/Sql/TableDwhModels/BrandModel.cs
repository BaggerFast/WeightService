﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableDwhModels;

[Serializable]
public class BrandModel : TableModel, ISerializable, ITableModel
{
    #region Public and private fields, properties, constructor

    public virtual string Name { get; set; }
    public virtual string Code { get; set; }
    public virtual int StatusId { get; set; }
    public virtual InformationSystemModel InformationSystem { get; set; }
    public virtual byte[] CodeInIs { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	public BrandModel() : base(ColumnName.Id)
	{
		Name = string.Empty;
		Code = string.Empty;
		StatusId = 0;
		InformationSystem = new();
		CodeInIs = new byte[0];
	}

	#endregion

	#region Public and private methods

	public new virtual string ToString() =>
		$"{nameof(Code)}: {Code}. " +
		$"{nameof(Name)}: {Name}. " +
		$"{nameof(StatusId)}: {StatusId}. ";

	public virtual bool Equals(BrandModel item)
    {
        if (ReferenceEquals(this, item)) return true;
        if (!InformationSystem.Equals(item.InformationSystem))
            return false;
        return 
	        base.Equals(item) &&
            Equals(Code, item.Code) &&
            Equals(Name, item.Name) &&
            Equals(StatusId, item.StatusId) &&
            Equals(CodeInIs, item.CodeInIs);
    }

	public new virtual bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((BrandModel)obj);
    }

    public new virtual int GetHashCode() => base.GetHashCode();

    public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        if (!InformationSystem.EqualsDefault())
            return false;
        return base.EqualsDefault() &&
               Equals(Code, string.Empty) &&
               Equals(Name, string.Empty) &&
               Equals(StatusId, 0) &&
               Equals(CodeInIs, new byte[0]);
    }

    public new virtual object Clone()
    {
        BrandModel item = new();
        item.Code = Code;
        item.Name = Name;
        item.StatusId = StatusId;
        item.InformationSystem = InformationSystem.CloneCast();
        item.CodeInIs = DataUtils.ByteClone(CodeInIs);
		item.CloneSetup(base.CloneCast());
		return item;
    }

    public new virtual BrandModel CloneCast() => (BrandModel)Clone();

    #endregion
}