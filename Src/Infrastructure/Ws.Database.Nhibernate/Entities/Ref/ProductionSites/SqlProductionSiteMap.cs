using Ws.Database.Nhibernate.Utils;
using Ws.Domain.Models.Entities.Ref;

namespace Ws.Database.Nhibernate.Entities.Ref.ProductionSites;

internal class SqlProductionSiteMap : ClassMapping<ProductionSite>
{
    public SqlProductionSiteMap()
    {
        Schema(SqlSchemasUtils.Ref);
        Table(SqlTablesUtils.ProductionSites);

        Id(x => x.Uid, m =>
        {
            m.Column("UID");
            m.Type(NHibernateUtil.Guid);
            m.Generator(Generators.GuidComb);
        });

        Property(x => x.Name, m =>
        {
            m.Column("NAME");
            m.Type(NHibernateUtil.String);
            m.Length(64);
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

        Property(x => x.Address, m =>
        {
            m.Column("ADDRESS");
            m.Type(NHibernateUtil.String);
            m.Length(128);
        });
    }
}