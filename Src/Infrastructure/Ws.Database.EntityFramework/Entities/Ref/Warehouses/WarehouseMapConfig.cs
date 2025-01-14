namespace Ws.Database.EntityFramework.Entities.Ref.Warehouses;


internal sealed  class WarehouseMapConfig : IEntityTypeConfiguration<WarehouseEntity>
{
    public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
    {
        #region Base

        builder.ToTable(SqlTables.Warehouses, SqlSchemas.Ref);

        builder.HasIndex(e => e.Name)
            .HasDatabaseName($"UQ_{SqlTables.Warehouses}__NAME")
            .IsUnique();

        builder.HasIndex(e => e.Uid1C)
            .HasDatabaseName($"UQ_{SqlTables.Warehouses}__{SqlColumns.Uid1C}")
            .IsUnique();

        #endregion

        #region FK

        builder.HasOne(e => e.ProductionSite)
            .WithMany()
            .HasForeignKey("PRODUCTION_SITE_UID")
            .HasConstraintName($"FK_{SqlTables.Warehouses}__PRODUCTION_SITE")
            .IsRequired();

        #endregion

        builder.Property(e => e.Name)
            .HasColumnName(SqlColumns.Name)
            .HasColumnType("varchar(32)")
            .IsRequired();

        builder.Property(e => e.Uid1C)
            .HasColumnName(SqlColumns.Uid1C)
            .IsRequired();
    }
}