﻿using Ws.Domain.Models.Entities.Ref;

namespace Ws.Database.Core.Entities.Ref.PalletMen;

internal sealed class SqlPalletManMap : ClassMapping<PalletManEntity>
{
    public SqlPalletManMap()
    {
        Schema(SqlSchemasUtils.Ref);
        Table(SqlTablesUtils.PalletMan);

        Id(x => x.IdentityValueUid, m => {
            m.Column("UID");
            m.Type(NHibernateUtil.Guid);
            m.Generator(Generators.Identity);
        });

        Property(x => x.Uid1C, m => {
            m.Column("UID_1C");
            m.Type(NHibernateUtil.Guid);
            m.NotNullable(true);
        });

        Property(x => x.CreateDt, m => {
            m.Column("CHANGE_DT");
            m.Type(NHibernateUtil.DateTime);
            m.NotNullable(true);
        });

        Property(x => x.ChangeDt, m => {
            m.Column("CHANGE_DT");
            m.Type(NHibernateUtil.DateTime);
            m.NotNullable(true);
        });

        Property(x => x.Name, m => {
            m.Column("NAME");
            m.Type(NHibernateUtil.String);
            m.Length(64);
        });

        Property(x => x.Surname, m => {
            m.Column("SURNAME");
            m.Type(NHibernateUtil.String);
            m.Length(64);
        });

        Property(x => x.Patronymic, m => {
            m.Column("PATRONYMIC");
            m.Type(NHibernateUtil.String);
            m.Length(64);
        });

        Property(x => x.Password, m => {
            m.Column("PASSWORD");
            m.Type(NHibernateUtil.String);
            m.Length(4);
        });
    }
}