﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "TASKS".
/// </summary>
[Serializable]
public class TaskEntity : TableModel, ISerializable, ITableModel
{
	#region Public and private fields, properties, constructor

	[XmlElement] public virtual TaskTypeEntity TaskType { get; set; }
	[XmlElement] public virtual ScaleEntity Scale { get; set; }
	[XmlElement] public virtual bool Enabled { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
    public TaskEntity() : base(ColumnName.Uid, Guid.Empty, false)
	{
		Init();
	}

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="identityUid"></param>
	/// <param name="isSetupDates"></param>
	public TaskEntity(Guid identityUid, bool isSetupDates) : base(ColumnName.Uid, identityUid, isSetupDates)
    {
	    Init();
    }

    #endregion

    #region Public and private methods

    public new virtual void Init()
    {
		base.Init();
        TaskType = new();
        Scale = new();
        Enabled = false;
    }

    public override string ToString()
    {
        string strTaskType = TaskType != null ? TaskType.IdentityUid.ToString() : "null";
        string strScale = Scale != null ? Scale.IdentityId.ToString() : "null";
        return
			$"{nameof(IdentityUid)}: {IdentityUid}. " + 
            $"{nameof(IsMarked)}: {IsMarked}. " +
            $"{nameof(TaskType)}: {strTaskType}. " +
            $"{nameof(Scale)}: {strScale}. " +
            $"{nameof(Enabled)}: {Enabled}. ";
    }

    public virtual bool Equals(TaskEntity item)
    {
        if (item is null) return false;
        if (ReferenceEquals(this, item)) return true;
        if (TaskType != null && item.TaskType != null && !TaskType.Equals(item.TaskType))
            return false;
        if (Scale != null && item.Scale != null && !Scale.Equals(item.Scale))
            return false;
        return base.Equals(item) &&
            Equals(Enabled, item.Enabled);
    }

    public override bool Equals(object obj)
    {
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
        return Equals((TaskEntity)obj);
    }

	public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        return base.EqualsDefault() &&
               Equals(Enabled, false);
    }

    public new virtual object Clone()
    {
        TaskEntity item = new();
        item.TaskType = TaskType.CloneCast();
        item.Scale = Scale.CloneCast();
        item.Enabled = Enabled;
        item.Setup(((TableModel)this).CloneCast());
        return item;
    }

    public new virtual TaskEntity CloneCast() => (TaskEntity)Clone();

    #endregion
}
