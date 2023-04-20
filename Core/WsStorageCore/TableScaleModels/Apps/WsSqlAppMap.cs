// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleModels.Apps;

/// <summary>
/// Table map "APPS".
/// </summary>
public sealed class WsSqlAppMap : ClassMap<WsSqlAppModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WsSqlAppMap()
    {
        Schema(WsSqlSchemasUtils.DbScales);
        Table(WsSqlTablesUtils.Apps);
        LazyLoad();
        Id(x => x.IdentityValueUid).CustomSqlType("UNIQUEIDENTIFIER").Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(x => x.Name).CustomSqlType("NVARCHAR").Column("NAME").Length(32).Not.Nullable();
        Map(x => x.IsMarked).CustomSqlType("BIT").Column("IS_MARKED").Not.Nullable().Default("0");
    }
}