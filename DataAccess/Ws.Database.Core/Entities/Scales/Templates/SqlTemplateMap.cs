using Ws.Domain.Models.Entities.Scale;

namespace Ws.Database.Core.Entities.Scales.Templates;

internal sealed class SqlTemplateMap : ClassMapping<TemplateEntity>
{
    public SqlTemplateMap()
    {
        Schema(SqlSchemasUtils.DbScales);
        Table(SqlTablesUtils.Templates);
        
        Id(x => x.IdentityValueId, m =>
        {
            m.Column("Id");
            m.Type(NHibernateUtil.Int64);
            m.Generator(Generators.Identity);
        });

        Property(x => x.CreateDt, m =>
        {
            m.Column("CreateDate");
            m.Type(NHibernateUtil.DateTime);
            m.NotNullable(true);
        });

        Property(x => x.ChangeDt, m =>
        {
            m.Column("ModifiedDate");
            m.Type(NHibernateUtil.DateTime);
            m.NotNullable(true);
        });

        Property(x => x.Title, m =>
        {
            m.Column("Title");
            m.Type(NHibernateUtil.String);
            m.Length(250);
        });

        Property(x => x.Data, m =>
        {
            m.Column("DATA");
            m.Type(NHibernateUtil.String);
            m.NotNullable(true);
        });
    }
}