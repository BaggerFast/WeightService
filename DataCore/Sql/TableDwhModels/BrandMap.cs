﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableDwhModels;

public class BrandMap : ClassMap<BrandEntity>
{
    public BrandMap()
    {
	    Schema("DW");
        Table("DimBrands");
        LazyLoad();
        Id(x => x.IdentityId).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
        Map(x => x.CreateDt).CustomSqlType("DATETIME").Column("CreateDate").Not.Nullable();
        Map(x => x.ChangeDt).CustomSqlType("DATETIME").Column("DLM").Not.Nullable();
        Map(x => x.Code).CustomSqlType("NVARCHAR").Length(15).Column("Code").Nullable();
        Map(x => x.Name).CustomSqlType("NVARCHAR").Length(150).Column("Name").Nullable();
        Map(x => x.StatusId).CustomSqlType("INT").Column("StatusID").Not.Nullable();
        Map(x => x.CodeInIs).CustomSqlType("VARBINARY").Length(16).Column("CodeInIS").Not.Nullable();
        References(x => x.InformationSystem).Column("InformationSystemID").Not.Nullable();
    }
}
