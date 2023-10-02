using WsStorageCore.OrmUtils;

namespace WsStorageCore.Tables.TableDiagModels.Logs;

public sealed class WsSqlLogMap : ClassMap<WsSqlLogModel>
{
    public WsSqlLogMap()
    {
        Schema(WsSqlSchemasUtils.DbScales);
        Table(WsSqlTablesUtils.Logs);
        Not.LazyLoad();
        Id(item => item.IdentityValueUid).CustomSqlType(WsSqlFieldTypeUtils.UniqueIdentifier).Column("UID").Unique().GeneratedBy.Guid().Not.Nullable();
        Map(item => item.CreateDt).CustomSqlType(WsSqlFieldTypeUtils.DateTime).Column("CREATE_DT").Not.Nullable();
        Map(item => item.IsMarked).CustomSqlType(WsSqlFieldTypeUtils.Bit).Column("IS_MARKED").Not.Nullable().Default("0");
        Map(item => item.Version).CustomSqlType(WsSqlFieldTypeUtils.NvarChar).Column("VERSION").Length(12).Nullable();
        Map(item => item.File).CustomSqlType(WsSqlFieldTypeUtils.NvarChar).Column("FILE").Length(40).Not.Nullable();
        Map(item => item.Line).CustomSqlType(WsSqlFieldTypeUtils.Int).Column("LINE").Not.Nullable();
        Map(item => item.Member).CustomSqlType(WsSqlFieldTypeUtils.NvarChar).Column("MEMBER").Length(40).Not.Nullable();
        Map(item => item.Message).CustomSqlType(WsSqlFieldTypeUtils.NvarChar).Column("MESSAGE").Length(1024).Not.Nullable();
        References(item => item.Device).Column("DEVICE_UID").Nullable();
        References(item => item.App).Column("APP_UID").Nullable();
        References(item => item.LogType).Column("LOG_TYPE_UID").Nullable();
    }
}