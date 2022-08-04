﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table map "ZebraPrinterType".
/// </summary>
public class PrinterTypeMap : ClassMap<PrinterTypeEntity>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PrinterTypeMap()
    {
        Schema("db_scales");
        Table("ZebraPrinterType");
        LazyLoad();
        Id(x => x.IdentityId).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
        Map(x => x.Name).CustomSqlType("NVARCHAR").Column("Name").Length(100).Nullable();
        Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
    }
}
