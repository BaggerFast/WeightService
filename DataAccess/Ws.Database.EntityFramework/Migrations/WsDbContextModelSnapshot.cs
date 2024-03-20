﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ws.Database.EntityFramework;

#nullable disable

namespace Ws.Database.EntityFramework.Migrations
{
    [DbContext(typeof(WsDbContext))]
    partial class WsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("USERS_СLAIMS_FK", b =>
                {
                    b.Property<Guid>("CLAIM_UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("USER_UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CLAIM_UID", "USER_UID");

                    b.HasIndex("USER_UID");

                    b.ToTable("USERS_СLAIMS_FK");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Box", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("Uid1C")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID_1C");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(4,3)")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_BOXES_NAME")
                        .IsUnique();

                    b.HasIndex(new[] { "Uid1C" }, "UQ_BOXES_UID_1C")
                        .IsUnique();

                    b.ToTable("BOXES");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("Uid1C")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID_1C");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_BRANDS_NAME")
                        .IsUnique();

                    b.HasIndex(new[] { "Uid1C" }, "UQ_BRANDS_UID_1C")
                        .IsUnique();

                    b.ToTable("BRANDS");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Bundle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("Uid1C")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID_1C");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(4,3)")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_BUNDLES_NAME")
                        .IsUnique();

                    b.HasIndex(new[] { "Uid1C" }, "UQ_BUNDLES_UID_1C")
                        .IsUnique();

                    b.ToTable("BUNDLES");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Claim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_CLAIMS_NAME")
                        .IsUnique();

                    b.ToTable("CLAIMS");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Clip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("Uid1C")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID_1C");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(4,3)")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_CLIPS_NAME")
                        .IsUnique();

                    b.HasIndex(new[] { "Uid1C" }, "UQ_CLIPS_UID_1C")
                        .IsUnique();

                    b.ToTable("CLIPS");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.PalletMan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("PATRONYMIC");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("SURNAME");

                    b.Property<Guid>("Uid1C")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID_1C");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name", "Surname", "Patronymic" }, "UQ_PALLET_MEN_FIO")
                        .IsUnique();

                    b.HasIndex(new[] { "Uid1C" }, "UQ_PALLET_MEN_UID_1C")
                        .IsUnique();

                    b.ToTable("PALLET_MEN");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Printer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("IP_V4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("PRODUCTION_SITE_UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("TYPE");

                    b.HasKey("Id");

                    b.HasIndex("PRODUCTION_SITE_UID");

                    b.HasIndex(new[] { "Ip" }, "UQ_PRINTERS_IP_V4")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "UQ_PRINTERS_NAME")
                        .IsUnique();

                    b.ToTable("PRINTERS");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.ProductionSite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("ADDRESS");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Address" }, "UQ_PRODUCTION_SITES_ADDRESS")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "UQ_PRODUCTION_SITES_NAME")
                        .IsUnique();

                    b.ToTable("PRODUCTION_SITES");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.StorageMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<string>("Zpl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnName("DESCRIPTION");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_STORAGE_METHODS_NAME")
                        .IsUnique();

                    b.HasIndex(new[] { "Zpl" }, "UQ_STORAGE_METHODS_ZPL")
                        .IsUnique();

                    b.ToTable("STORAGE_METHODS");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(10240)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BODY");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_TEMPLATES_NAME")
                        .IsUnique();

                    b.ToTable("TEMPLATES");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<DateTime>("LoginDt")
                        .HasColumnType("datetime2")
                        .HasColumnName("LOGIN_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<Guid?>("PRODUCTION_SITE_UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PRODUCTION_SITE_UID");

                    b.HasIndex(new[] { "Name" }, "UQ_USERS_NAME")
                        .IsUnique();

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("PRODUCTION_SITE_UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PRODUCTION_SITE_UID");

                    b.HasIndex(new[] { "Name" }, "UQ_WAREHOUSES_NAME")
                        .IsUnique();

                    b.ToTable("WAREHOUSES");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.ZplResource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UID");

                    b.Property<DateTime>("ChangeDt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_DT");

                    b.Property<DateTime>("CreateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("NAME");

                    b.Property<string>("Zpl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnName("ZPL");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_ZPL_RESOURCES_NAME")
                        .IsUnique();

                    b.ToTable("ZPL_RESOURCES");
                });

            modelBuilder.Entity("USERS_СLAIMS_FK", b =>
                {
                    b.HasOne("Ws.Database.EntityFramework.Models.Ready.Claim", null)
                        .WithMany()
                        .HasForeignKey("CLAIM_UID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ws.Database.EntityFramework.Models.Ready.User", null)
                        .WithMany()
                        .HasForeignKey("USER_UID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Printer", b =>
                {
                    b.HasOne("Ws.Database.EntityFramework.Models.Ready.ProductionSite", "ProductionSite")
                        .WithMany()
                        .HasForeignKey("PRODUCTION_SITE_UID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionSite");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.User", b =>
                {
                    b.HasOne("Ws.Database.EntityFramework.Models.Ready.ProductionSite", "ProductionSite")
                        .WithMany()
                        .HasForeignKey("PRODUCTION_SITE_UID");

                    b.Navigation("ProductionSite");
                });

            modelBuilder.Entity("Ws.Database.EntityFramework.Models.Ready.Warehouse", b =>
                {
                    b.HasOne("Ws.Database.EntityFramework.Models.Ready.ProductionSite", "ProductionSite")
                        .WithMany()
                        .HasForeignKey("PRODUCTION_SITE_UID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionSite");
                });
#pragma warning restore 612, 618
        }
    }
}
