using Ws.Database.EntityFramework.Shared.Extensions;
using Ws.Database.EntityFramework.Shared.Interceptors;
using Ws.Database.EntityFramework.Shared.Models;


namespace Ws.Database.EntityFramework;

public class WsDbContext : DbContext
{
    #region DbSet

    public DbSet<DatabaseTableView> DatabaseTables { get; init; }
    public DbSet<ZplResourceEntity> ZplResources { get; init; }
    public DbSet<PalletManEntity> PalletMen { get; init; }
    public DbSet<BrandEntity> Brands { get; init; }
    public DbSet<ProductionSiteEntity> ProductionSites { get; init; }
    public DbSet<TemplateEntity> Templates { get; init; }
    public DbSet<BoxEntity> Boxes { get; init; }
    public DbSet<ClipEntity> Clips { get; init; }
    public DbSet<BundleEntity> Bundles { get; init; }
    public DbSet<WarehouseEntity> Warehouses { get; init; }
    public DbSet<PrinterEntity> Printers { get; init; }
    public DbSet<UserEntity> Users { get; init; }
    public DbSet<LineEntity> Lines { get; init; }
    public DbSet<PluEntity> Plus { get; init; }
    public DbSet<NestingEntity> Nestings { get; init; }
    public DbSet<CharacteristicEntity> Characteristics { get; init; }
    public DbSet<LabelEntity> Labels { get; init; }
    public DbSet<PalletEntity> Pallets { get; init; }
    public DbSet<LabelZplEntity> LabelZpl { get; init; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlSettingsModel sqlCfg = LoadJsonConfig();

        optionsBuilder.UseSqlServer(sqlCfg.GetConnectionString());
        optionsBuilder.AddInterceptors(new ChangeDtInterceptor());

        if (ConfigurationUtil.IsDevelop && sqlCfg.IsShowSql)
            optionsBuilder.UseLoggerFactory(
                LoggerFactory.Create(builder => builder.AddConsole())
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SetDefaultTypeForString();
        modelBuilder.SetAutoCreateOrChangeDt();

        modelBuilder.UseIpAddressConversion();
        modelBuilder.UseDateTimeConversion();
        modelBuilder.UseEnumStringConversion();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private static SqlSettingsModel LoadJsonConfig()
    {
        IConfigurationRoot sqlConfiguration = new ConfigurationBuilder()
            .AddJsonFile("sql_config.json", optional: false, reloadOnChange: false)
            .Build();

        SqlSettingsModel sqlSettingsModel = new();
        sqlConfiguration.GetSection("SqlSettings").Bind(sqlSettingsModel);
        return sqlSettingsModel;
    }
}