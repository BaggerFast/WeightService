﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// table map "Scales".
/// </summary>
public class ScaleMap : ClassMap<ScaleEntity>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ScaleMap()
    {
        Schema("db_scales");
        Table("Scales");
        LazyLoad();
        Id(x => x.IdentityId).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
        Map(x => x.CreateDt).CustomSqlType("DATETIME").Column("CreateDate").Not.Nullable();
        Map(x => x.ChangeDt).CustomSqlType("DATETIME").Column("ModifiedDate").Not.Nullable();
        Map(x => x.IsMarked).CustomSqlType("BIT").Column("Marked").Not.Nullable().Default("0");
        Map(x => x.Description).CustomSqlType("NVARCHAR").Column("Description").Length(150);
        Map(x => x.DeviceIp).CustomSqlType("VARCHAR").Column("DeviceIP").Length(15);
        Map(x => x.DevicePort).CustomSqlType("SMALLINT").Column("DevicePort");
        Map(x => x.DeviceMac).CustomSqlType("VARCHAR").Column("DeviceMAC").Length(35);
        Map(x => x.DeviceSendTimeout).CustomSqlType("SMALLINT").Column("DeviceSendTimeout");
        Map(x => x.DeviceReceiveTimeout).CustomSqlType("SMALLINT").Column("DeviceReceiveTimeout");
        Map(x => x.DeviceComPort).CustomSqlType("VARCHAR").Column("DeviceComPort").Length(5);
        Map(x => x.ZebraIp).CustomSqlType("VARCHAR").Column("ZebraIP").Length(15);
        Map(x => x.ZebraPort).CustomSqlType("SMALLINT").Column("ZebraPort");
        Map(x => x.IsOrder).CustomSqlType("SMALLINT").Column("UseOrder").Default("0").Nullable();
        Map(x => x.Number).CustomSqlType("INT").Column("NUMBER").Not.Nullable();
        Map(x => x.Counter).CustomSqlType("INT").Column("COUNTER").Not.Nullable();
        Map(x => x.ScaleFactor).CustomSqlType("INT").Column("ScaleFactor").Default("1000");
        Map(x => x.IsShipping).CustomSqlType("BIT").Column("IS_SHIPPING").Not.Nullable().Default("0");
        Map(x => x.ShippingLength).CustomSqlType("INT").Column("SHIPPING_LEN").Not.Nullable().Default("0");
        Map(x => x.IsKneading).CustomSqlType("BIT").Column("IS_KNEADING").Not.Nullable().Default("0");
        References(x => x.TemplateDefault).Column("TemplateIdDefault").Nullable();
        References(x => x.TemplateSeries).Column("TemplateIdSeries").Nullable();
        References(x => x.PrinterMain).Column("ZebraPrinterId").Nullable();
        References(x => x.PrinterShipping).Column("SHIPPING_PRINTER_ID").Nullable();
        References(x => x.Host).Column("HostId").Nullable();
        References(x => x.WorkShop).Column("WorkShopId").Nullable();
    }
}
