﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentNHibernate.Mapping;

namespace BlazorCore.DAL.TableModels
{
    public class TemplateMap : ClassMap<TemplateEntity>
    {
        public TemplateMap()
        {
            Table("[db_scales].[Templates]");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("INT").Column("Id").Unique().GeneratedBy.Identity().Not.Nullable();
            Map(x => x.CreateDate).CustomSqlType("DATETIME").Column("CreateDate").Not.Nullable();
            Map(x => x.ModifiedDate).CustomSqlType("DATETIME").Column("ModifiedDate").Not.Nullable();
            Map(x => x.CategoryId).CustomSqlType("NVARCHAR(150)").Column("CategoryID").Length(150).Not.Nullable();
            Map(x => x.IdRRef).CustomSqlType("UNIQUEIDENTIFIER").Column("IdRRef").Nullable();
            Map(x => x.Title).CustomSqlType("NVARCHAR(250)").Column("Title").Length(250).Nullable();
            Map(x => x.ImageData).CustomSqlType("VARBINARY(MAX)").Column("ImageData").Nullable().Length(int.MaxValue);
            Map(x => x.Marked).CustomSqlType("BIT").Column("Marked").Not.Nullable().Default("0");
        }
    }
}