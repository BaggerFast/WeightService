﻿//This is an independent project of an individual developer. Dear PVS-Studio, please check it.
//PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels.NomenclaturesCharacteristics;

/// <summary>
/// Table map "NOMENCLATURES_CHARACTERISTICS".
/// </summary>
public class NomenclaturesCharacteristicsMap : ClassMap<NomenclaturesCharacteristicsModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public NomenclaturesCharacteristicsMap()
    {
        Schema("db_scales");
        Table("NOMENCLATURES_CHARACTERISTICS");
        LazyLoad();
        Id(x => x.IdentityValueUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(x => x.CreateDt).CustomSqlType("DATETIME").Column("CREATE_DT").Not.Nullable();
        Map(x => x.ChangeDt).CustomSqlType("DATETIME").Column("CHANGE_DT").Not.Nullable();
        Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
        Map(x => x.Name).CustomSqlType("NVARCHAR").Column("NAME").Length(128).Not.Nullable();
        Map(x => x.AttachmentsCount).CustomSqlType("DECIMAL").Column("ATTACHMENTS_COUNT").Scale(10).Precision(3).Not.Nullable();
    }
}