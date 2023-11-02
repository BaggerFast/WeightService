using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WsStorageCore.OrmUtils;
namespace WsStorageCore.Entities.SchemaScale.PlusStorageMethods;

public sealed class WsSqlPluStorageMethodMap : ClassMapping<WsSqlPluStorageMethodEntity>
{
    public WsSqlPluStorageMethodMap()
    {
        Schema(WsSqlSchemasUtils.DbScales);
        Table(WsSqlTablesUtils.PlusStorageMethods);

        Id(x => x.IdentityValueUid, m =>
        {
            m.Column("UID");
            m.Type(NHibernateUtil.Guid);
            m.Generator(Generators.Guid);
        });

        Property(x => x.CreateDt, m =>
        {
            m.Column("CREATE_DT");
            m.Type(NHibernateUtil.DateTime);
            m.NotNullable(true);
        });

        Property(x => x.ChangeDt, m =>
        {
            m.Column("CHANGE_DT");
            m.Type(NHibernateUtil.DateTime);
            m.NotNullable(true);
        });

        Property(x => x.IsMarked, m =>
        {
            m.Column("IS_MARKED");
            m.Type(NHibernateUtil.Boolean);
            m.NotNullable(true);
        });

        Property(x => x.Name, m =>
        {
            m.Column("NAME");
            m.Type(NHibernateUtil.String);
            m.Length(64);
            m.NotNullable(true);
        });

        Property(x => x.MinTemp, m =>
        {
            m.Column("MIN_TEMP");
            m.Type(NHibernateUtil.Int16);
            m.NotNullable(true);
        });

        Property(x => x.MaxTemp, m =>
        {
            m.Column("MAX_TEMP");
            m.Type(NHibernateUtil.Int16);
            m.NotNullable(true);
        });
    }
}