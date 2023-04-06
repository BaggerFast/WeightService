// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Core.Utils;

namespace DataCore.Sql.TableScaleModels.TasksTypes;

/// <summary>
/// Table map "TASKS_TYPES".
/// </summary>
public sealed class TaskTypeMap : ClassMap<TaskTypeModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public TaskTypeMap()
    {
        Schema(WsSqlSchemaNamesUtils.DbScales);
        Table(WsSqlTableNamesUtils.TasksTypes);
        LazyLoad();
        Id(x => x.IdentityValueUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(x => x.Name).CustomSqlType("NVARCHAR").Column("Name").Length(32).Not.Nullable();
        Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
    }
}
