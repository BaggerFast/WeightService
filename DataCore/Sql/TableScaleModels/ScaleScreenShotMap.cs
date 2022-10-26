﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table map "SCALES_SCREENSHOTS".
/// </summary>
public class ScaleScreenShotMap : ClassMap<ScaleScreenShotModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ScaleScreenShotMap()
    {
        Schema("db_scales");
        Table("SCALES_SCREENSHOTS");
        LazyLoad();
        Id(x => x.IdentityValueUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(x => x.CreateDt).CustomSqlType("DATETIME").Column("CREATE_DT").Not.Nullable();
        Map(x => x.ChangeDt).CustomSqlType("DATETIME").Column("CHANGE_DT").Not.Nullable();
        Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
		Map(x => x.ScreenShot).CustomSqlType("VARBINARY").Length(int.MaxValue).Column("SCREENSHOT").Not.Nullable().Default($"{0x00}");
        References(x => x.Scale).Column("SCALE_ID").Not.Nullable();
    }
}