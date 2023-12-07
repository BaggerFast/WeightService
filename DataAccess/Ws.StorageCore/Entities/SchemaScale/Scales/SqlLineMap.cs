namespace Ws.StorageCore.Entities.SchemaScale.Scales;

public sealed class SqlLineMap : ClassMapping<SqlLineEntity>
{
    public SqlLineMap()
    {
        Schema(SqlSchemasUtils.DbScales);
        Table(SqlTablesUtils.Scales);

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

        Property(x => x.IsMarked, m =>
        {
            m.Column("Marked");
            m.Type(NHibernateUtil.Boolean);
            m.NotNullable(true);
        });

        Property(x => x.Description, m =>
        {
            m.Column("Description");
            m.Type(NHibernateUtil.String);
            m.Length(150);
        });

        Property(x => x.DeviceComPort, m =>
        {
            m.Column("DeviceComPort");
            m.Type(NHibernateUtil.String);
            m.Length(5);
        });

        Property(x => x.Number, m =>
        {
            m.Column("NUMBER");
            m.Type(NHibernateUtil.Int32);
            m.NotNullable(true);
        });

        Property(x => x.LabelCounter, m =>
        {
            m.Column("COUNTER");
            m.Type(NHibernateUtil.Int32);
            m.NotNullable(true);
        });

        Property(x => x.ClickOnce, m =>
        {
            m.Column("CLICK_ONCE");
            m.Type(NHibernateUtil.String);
            m.NotNullable(true);
        });
        
        Property(x => x.Version, m =>
        {
            m.Column("VerScalesUI");
            m.Type(NHibernateUtil.String);
            m.NotNullable(false);
        });

        ManyToOne(x => x.Printer, m =>
        {
            m.Column("PRINTER_UID");
            m.NotNullable(true);
            m.Lazy(LazyRelation.NoLazy);
        });

        ManyToOne(x => x.WorkShop, m =>
        {
            m.Column("WORKSHOP_UID");
            m.NotNullable(true);
            m.Lazy(LazyRelation.NoLazy);
        });

        ManyToOne(x => x.Host, m =>
        {
            m.Column("HOST_UID");
            m.NotNullable(true);
            m.Lazy(LazyRelation.NoLazy);
        });
    }
}