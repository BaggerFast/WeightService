﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentNHibernate.Mapping;

namespace BlazorCore.DAL.TableModels
{
    public class NomenclatureMap : ClassMap<NomenclatureEntity>
    {
        public NomenclatureMap()
        {
            Table("[db_scales].[Nomenclature]");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
            Map(x => x.CreateDate).CustomSqlType("DATETIME").Column("CreateDate").Nullable();
            Map(x => x.ModifiedDate).CustomSqlType("DATETIME").Column("ModifiedDate").Nullable();
            Map(x => x.Code).CustomSqlType("NVARCHAR(30)").Column("Code").Length(30);
            Map(x => x.Name).CustomSqlType("NVARCHAR(300)").Column("Name").Length(300);
            Map(x => x.SerializedRepresentationObject).CustomSqlType("XML").Column("SerializedRepresentationObject").Nullable();
        }
    }
}
