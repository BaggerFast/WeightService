﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentNHibernate.Mapping;

namespace DataCore.Sql.TableScaleModels
{
    public class TaskTypeMap : ClassMap<TaskTypeEntity>
    {
        public TaskTypeMap()
        {
            Table("[db_scales].[TASKS_TYPES]");
            LazyLoad();
            Id(x => x.IdentityUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
            Map(x => x.Name).CustomSqlType("NVARCHAR").Column("Name").Length(32).Not.Nullable();
            Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
        }
    }
}