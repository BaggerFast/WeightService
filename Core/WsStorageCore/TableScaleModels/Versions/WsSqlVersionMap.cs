// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleModels.Versions;

/// <summary>
/// Table map "VERSIONS".
/// </summary>
public sealed class WsSqlVersionMap : ClassMap<WsSqlVersionModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WsSqlVersionMap()
    {
        Schema(WsSqlSchemasUtils.DbScales);
        Table(WsSqlTablesUtils.Versions);
        LazyLoad();
        Id(item => item.IdentityValueUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(item => item.CreateDt).CustomSqlType("DATETIME").Column("CREATE_DT").Not.Nullable();
        Map(item => item.ChangeDt).CustomSqlType("DATETIME").Column("CHANGE_DT").Not.Nullable();
        Map(item => item.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
        Map(item => item.ReleaseDt).CustomSqlType("DATE").Column("RELEASE_DT").Not.Nullable();
        Map(item => item.Name).CustomSqlType("NVARCHAR").Column("NAME").Length(256).Not.Nullable();
        Map(item => item.Description).CustomSqlType("NVARCHAR").Column("DESCRIPTION").Length(256).Not.Nullable().Default("");
        Map(item => item.Version).CustomSqlType("SMALLINT").Column("VERSION").Not.Nullable();
    }
}
