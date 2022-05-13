﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentNHibernate.Mapping;

namespace DataCore.Sql.TableScaleModels
{
    public class LabelMap : ClassMap<LabelEntity>
    {
        public LabelMap()
        {
            Table("[db_scales].[Labels]");
            LazyLoad();
            Id(x => x.IdentityId).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
            Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
            References(x => x.WeithingFact).Column("WeithingFactId").Not.Nullable();
            Map(x => x.Label).CustomSqlType("VARBINARY(MAX)").Column("Label").Nullable();
            Map(x => x.CreateDt).CustomSqlType("DATETIME").Column("CreateDate").Not.Nullable();
            Map(x => x.Zpl).CustomSqlType("NVARCHAR(MAX)").Column("ZPL").Nullable();
        }
    }
}