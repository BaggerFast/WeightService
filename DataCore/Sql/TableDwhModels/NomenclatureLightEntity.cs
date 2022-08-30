﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableDwhModels;

[Serializable]
public class NomenclatureLightEntity : TableModel, ISerializable, ITableModel
{
    #region Public and private fields, properties, constructor

    public virtual string Code { get; set; }
    public virtual string Name { get; set; }
    public virtual string Parents { get; set; }
    public virtual NomenclatureParentEntity ParentConvert => 
        string.IsNullOrEmpty(Parents) ? null : JsonConvert.DeserializeObject<NomenclatureParentEntity>(Parents);
    public virtual string NameFull { get; set; }
    public virtual bool IsService { get; set; }
    public virtual bool IsProduct { get; set; }
    public virtual InformationSystemEntity InformationSystem { get; set; } = new();
    public virtual short? RelevanceStatus { get; set; }
    public virtual short? NormalizationStatus { get; set; }
    public virtual long? MasterId { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	public NomenclatureLightEntity() : base(ColumnName.Id, 0, false)
    {
	    Init();
    }

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="identityId"></param>
	/// <param name="isSetupDates"></param>
	public NomenclatureLightEntity(long identityId, bool isSetupDates) : base(ColumnName.Id, identityId, false)
    {
	    Init();
    }

	#endregion

	#region Public and private methods

	public new virtual void Init()
	{
		base.Init();
		Code = string.Empty;
		Name = string.Empty;
		Parents = string.Empty;
		NameFull = string.Empty;
		IsService = false;
		IsProduct = false;
		InformationSystem = new();
		RelevanceStatus = null;
		NormalizationStatus = null;
		MasterId = null;
	}

    public override string ToString()
    {
        string strInformationSystem = InformationSystem != null ? InformationSystem.IdentityId.ToString() : "null";
        return base.ToString() +
               $"{nameof(Code)}: {Code}. " +
               $"{nameof(Name)}: {Name}. " +
               $"{nameof(Parents)}: {Parents}. " +
               $"{nameof(NameFull)}: {NameFull}. " +
               $"{nameof(IsService)}: {IsService}. " +
               $"{nameof(IsProduct)}: {IsProduct}. " +
               $"{nameof(InformationSystem)}: {strInformationSystem}. " +
               $"{nameof(RelevanceStatus)}: {RelevanceStatus}. " +
               $"{nameof(NormalizationStatus)}: {NormalizationStatus}. " +
               $"{nameof(MasterId)}: {MasterId}. ";
    }

    public virtual bool Equals(NomenclatureLightEntity item)
    {
        if (item is null) return false;
        if (ReferenceEquals(this, item)) return true;
        if (InformationSystem != null && item.InformationSystem != null && !InformationSystem.Equals(item.InformationSystem))
            return false;
        return base.Equals(item) &&
               Equals(Code, item.Code) &&
               Equals(Name, item.Name) &&
               Equals(Parents, item.Parents) &&
               Equals(NameFull, item.NameFull) &&
               Equals(IsService, item.IsService) &&
               Equals(IsProduct, item.IsProduct) &&
               Equals(RelevanceStatus, item.RelevanceStatus) &&
               Equals(NormalizationStatus, item.NormalizationStatus) &&
               Equals(MasterId, item.MasterId);
    }

    public override bool Equals(object obj)
    {
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((NomenclatureLightEntity)obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        if (InformationSystem != null && !InformationSystem.EqualsDefault())
            return false;
        return base.EqualsDefault() &&
               Equals(Code, string.Empty) &&
               Equals(Name, string.Empty) &&
               Equals(Parents, string.Empty) &&
               Equals(NameFull, string.Empty) &&
               Equals(IsService, false) &&
               Equals(IsProduct, false) &&
               Equals(RelevanceStatus, null) &&
               Equals(NormalizationStatus, null) &&
               Equals(MasterId, null);
    }

    public new virtual object Clone()
    {
        NomenclatureLightEntity item = new();
        item.Code = Code;
        item.Name = Name;
        item.Parents = Parents;
        item.NameFull = NameFull;
        item.IsService = IsService;
        item.IsProduct = IsProduct;
        item.InformationSystem = InformationSystem.CloneCast();
        item.RelevanceStatus = RelevanceStatus;
        item.NormalizationStatus = NormalizationStatus;
        item.MasterId = MasterId;
        item.Setup(((TableModel)this).CloneCast());
        return item;
    }

    public new virtual NomenclatureLightEntity CloneCast() => (NomenclatureLightEntity)Clone();

    #endregion
}
