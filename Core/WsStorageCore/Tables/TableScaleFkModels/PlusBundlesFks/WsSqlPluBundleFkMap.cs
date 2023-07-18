// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Tables.TableScaleFkModels.PlusBundlesFks;

/// <summary>
/// Table map "PLUS_BUNDLES_FK".
/// </summary>
public sealed class WsSqlPluBundleFkMap : ClassMap<WsSqlPluBundleFkModel>
{   
    /// <summary>
    /// Constructor.
    /// </summary>
    public WsSqlPluBundleFkMap()
    {
        Schema(WsSqlSchemasUtils.DbScales);
        Table(WsSqlTablesUtils.PlusBundlesFks);
        LazyLoad();
        Id(item => item.IdentityValueUid).CustomSqlType(WsSqlFieldTypeUtils.UniqueIdentifier).Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(item => item.CreateDt).CustomSqlType(WsSqlFieldTypeUtils.DateTime).Column("CREATE_DT").Not.Nullable();
        Map(item => item.ChangeDt).CustomSqlType(WsSqlFieldTypeUtils.DateTime).Column("CHANGE_DT").Not.Nullable();
        Map(item => item.IsMarked).CustomSqlType(WsSqlFieldTypeUtils.Bit).Column("IS_MARKED").Not.Nullable().Default("0");
        References(item => item.Bundle).Column("BUNDLE_UID").Not.Nullable();
        References(item => item.Plu).Column("PLU_UID").Unique().Not.Nullable();
    }
}