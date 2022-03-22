﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentNHibernate.Mapping;

namespace DataCore.DAL.TableScaleModels
{
    public class ProductionFacilityMap : ClassMap<ProductionFacilityEntity>
    {
        public ProductionFacilityMap()
        {
            Table("[db_scales].[ProductionFacility]");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
            Map(x => x.CreateDate).CustomSqlType("DATETIME").Column("CreateDate").Nullable();
            Map(x => x.ModifiedDate).CustomSqlType("DATETIME").Column("ModifiedDate").Nullable();
            Map(x => x.Name).CustomSqlType("NVARCHAR").Column("Name").Length(150).Nullable();
            Map(x => x.IdRRef).CustomSqlType("UNIQUEIDENTIFIER").Column("IdRRef").Nullable();
            Map(x => x.Marked).CustomSqlType("BIT").Column("Marked").Not.Nullable().Default("0");
        }
    }
}
