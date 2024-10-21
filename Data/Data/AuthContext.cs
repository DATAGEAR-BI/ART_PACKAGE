using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data.Constants.db;
using Data.Contracts;
using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Areas.Identity.Data;

public class AuthContext : IdentityDbContext<AppUser>
{

    public string TenantId { get; set; }
    private readonly ITenantService _tenantService;




    public virtual DbSet<ArtSavedCustomReport> ArtSavedCustomReports { get; set; } = null!;
    public virtual DbSet<ArtSavedReportsColumns> ArtSavedReportsColumns { get; set; } = null!;
    public virtual DbSet<ArtSavedReportsChart> ArtSavedReportsCharts { get; set; } = null!;
    public virtual DbSet<UserReport> UserReports { get; set; } = null!;




    public AuthContext(DbContextOptions<AuthContext> options,ITenantService tenantService)
        : base(options)
    {

        _tenantService = tenantService;
        TenantId = _tenantService.GetCurrentTenant()?.TId;
    }
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        contextBuilder(optionsBuilder);
    }*/
    public void ChangeConnectionString(string tenantId)
    {
        var connectionString = _tenantService.GetConnectionString();
        Database.GetDbConnection().ConnectionString = connectionString;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        modelBuilder.ApplyConfiguration(new RolesConfigration());
        modelBuilder.ApplyConfiguration(new UserConfigration());
        modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
        modelBuilder.Entity<ArtSavedReportsColumns>(

            e =>
            {
                e.HasKey(e => new { e.ReportId, e.Column });
                e.HasOne<ArtSavedCustomReport>(r => r.Report)
                 .WithMany(c => c.Columns)
                 .HasForeignKey(fk => fk.ReportId);
            });

        modelBuilder.Entity<ArtSavedReportsChart>(e =>
        {
            e.HasKey(e => new { e.ReportId, e.Column, e.Type });
            e.HasOne<ArtSavedCustomReport>(r => r.Report)
             .WithMany(c => c.Charts)
             .HasForeignKey(fk => fk.ReportId);
            e.ToTable("ArtSavedReportsChart");
        });


        modelBuilder.Entity<ArtSavedCustomReport>(e =>
        {
            e.ToTable("ArtSavedCustomReport");

            e.HasMany<AppUser>(e => e.Users)
                .WithMany(r => r.Reports)
                .UsingEntity<UserReport>(ur =>
                {
                    ur.HasKey(i => new { i.ReportId, i.UserId, i.SharedFromId });
                    ur.HasOne<AppUser>(e => e.User).WithMany(e => e.UserReports).HasForeignKey(e => e.UserId);
                    ur.HasOne<ArtSavedCustomReport>(e => e.Report).WithMany(e => e.UserReports).HasForeignKey(e => e.ReportId);
                });
        });

        modelBuilder.Entity<UserReport>(e =>
        {
            e.ToTable("UserReport");
        });







        var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
        modelCreatingStrategy.OnModelCreating(modelBuilder);

        base.OnModelCreating(modelBuilder);

    }
    protected void contextBuilder(DbContextOptionsBuilder options, string conn = "AuthContextConnection")
    {

        int commandTimeOut = _tenantService.GetCommendTimeOut() ?? 120;
        var tenantConnectionString = _tenantService.GetConnectionString(conn);
        if (!string.IsNullOrWhiteSpace(tenantConnectionString))
        {
            string dbType = _tenantService.GetDatabaseProvider();
            _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    conn,
                    x => { _ = x.MigrationsAssembly("SqlServerMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                    ),
                DbTypes.Oracle => options.UseOracle(
                    conn,
                    x => { _ = x.MigrationsAssembly("OracleMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                    ),
                DbTypes.MySql => options.UseMySQL(
                conn,
                x => { _ = x.MigrationsAssembly("MySqlMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            };
        }
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().Where(e => e.State == EntityState.Added))
        {
            entry.Entity.TenantId = TenantId;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
