﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentNHibernate.Mapping;

namespace DataCore.DAL.TableScaleModels
{
    public class BarCodeMapV2 : ClassMap<BarCodeEntityV2>
    {
        public BarCodeMapV2()
        {
            Table("BARCODES_V2");
            Schema("db_scales");
            LazyLoad();
            Id(x => x.IdentityUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
            Map(x => x.CreateDt).CustomSqlType("DATETIME").Column("CREATE_DT").Not.Nullable();
            Map(x => x.ChangeDt).CustomSqlType("DATETIME").Column("CHANGE_DT").Not.Nullable();
            Map(x => x.IsMarked).CustomSqlType("BIT").Column("MARKED").Not.Nullable().Default("0");
            Map(x => x.Value).CustomSqlType("NVARCHAR").Column("VALUE").Length(150).Not.Nullable();
            References(x => x.BarcodeType).Column("BARCODE_TYPE_UID").Nullable();
        }
    }
}
