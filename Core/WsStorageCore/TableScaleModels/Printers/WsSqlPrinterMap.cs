// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleModels.Printers;

/// <summary>
/// Table map "ZebraPrinter".
/// </summary>
public sealed class WsSqlPrinterMap : ClassMap<WsSqlPrinterModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WsSqlPrinterMap()
    {
        Schema(WsSqlSchemasUtils.DbScales);
        Table(WsSqlTablesUtils.Printers);
        LazyLoad();
        Id(item => item.IdentityValueId).CustomSqlType(WsSqlFieldTypeUtils.Int).Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
        Map(item => item.CreateDt).CustomSqlType(WsSqlFieldTypeUtils.DateTime).Column("CreateDate").Not.Nullable();
        Map(item => item.ChangeDt).CustomSqlType(WsSqlFieldTypeUtils.DateTime).Column("ModifiedDate").Not.Nullable();
        Map(item => item.IsMarked).CustomSqlType(WsSqlFieldTypeUtils.Bit).Column("Marked").Not.Nullable().Default("0");
        Map(item => item.Name).CustomSqlType(WsSqlFieldTypeUtils.NvarChar).Column("Name").Length(100).Nullable();
        Map(item => item.Ip).CustomSqlType(WsSqlFieldTypeUtils.VarChar).Length(15).Column("IP").Nullable();
        Map(item => item.Port).CustomSqlType(WsSqlFieldTypeUtils.SmallInt).Column("Port").Nullable();
        Map(item => item.Password).CustomSqlType(WsSqlFieldTypeUtils.VarChar).Length(15).Column("Password").Nullable();
        Map(item => item.MacAddressValue).CustomSqlType(WsSqlFieldTypeUtils.VarChar).Column("Mac").Length(20).Nullable();
        Map(item => item.PeelOffSet).CustomSqlType(WsSqlFieldTypeUtils.Bit).Column("PeelOffSet").Not.Nullable().Default("0");
        Map(item => item.DarknessLevel).CustomSqlType(WsSqlFieldTypeUtils.SmallInt).Column("DarknessLevel").Nullable();
        References(item => item.PrinterType).Column("PrinterTypeId").Not.Nullable();
    }
}
