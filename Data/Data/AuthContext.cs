using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data;
using Data.Data;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ART_PACKAGE.Areas.Identity.Data;

public class AuthContext : IdentityDbContext<AppUser>
{
    public virtual DbSet<ArtSavedCustomReport> ArtSavedCustomReports { get; set; }
    public virtual DbSet<ArtSavedReportsColumns> ArtSavedReportsColumns { get; set; }
    public virtual DbSet<ArtSavedReportsChart> ArtSavedReportsCharts { get; set; }
    //ACM 
    public virtual DbSet<ArtHomeCasesDate> ArtHomeCasesDates { get; set; }
    public virtual DbSet<ArtHomeCasesStatus> ArtHomeCasesStatuses { get; set; }
    public virtual DbSet<ArtHomeCasesType> ArtHomeCasesTypes { get; set; }
    public virtual DbSet<ArtSystemPrefPerDirection> ArtSystemPrefPerDirections { get; set; } = null!;
    public virtual DbSet<ArtSystemPerfPerType> ArtSystemPerfPerTypes { get; set; } = null!;
    public virtual DbSet<ArtSystemPreformance> ArtSystemPerformances { get; set; } = null!;
    public virtual DbSet<ArtUserPerformance> ArtUserPerformances { get; set; } = null!;
    public virtual DbSet<ArtUserPerformancePerActionUser> ArtUserPerformancePerActionUsers { get; set; } = null!;
    public virtual DbSet<ArtUserPerformPerAction> ArtUserPerformPerActions { get; set; } = null!;
    public virtual DbSet<ArtUserPerformPerUserAndAction> ArtUserPerformPerUserAndActions { get; set; } = null!;
    //AML
    public virtual DbSet<ArtHomeAlertsPerDate> ArtHomeAlertsPerDates { get; set; } = null!;
    public virtual DbSet<ArtSystemPrefPerStatus> ArtSystemPrefPerStatuses { get; set; } = null!;
    public virtual DbSet<ArtHomeAlertsPerStatus> ArtHomeAlertsPerStatuses { get; set; } = null!;
    public virtual DbSet<ArtHomeNumberOfAccount> ArtHomeNumberOfAccounts { get; set; } = null!;
    public virtual DbSet<ArtHomeNumberOfCustomer> ArtHomeNumberOfCustomers { get; set; } = null!;
    public virtual DbSet<ArtHomeNumberOfHighRiskCustomer> ArtHomeNumberOfHighRiskCustomers { get; set; } = null!;
    public virtual DbSet<ArtHomeNumberOfPepCustomer> ArtHomeNumberOfPepCustomers { get; set; } = null!;


    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
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

        modelBuilder.Entity<ArtSavedReportsChart>(

            e =>
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
            e.HasOne<AppUser>(e => e.User)
                .WithMany(r => r.Reports)
                .HasForeignKey(x => x.UserId);

        });
        if (this.Database.IsSqlServer())
            ModelCreatingConfigurator.SqlServerOnModelCreating(modelBuilder);

        if (this.Database.IsOracle())
            ModelCreatingConfigurator.OracleOnModelCreating(modelBuilder);


    }


    public IEnumerable<T> ExecuteProc<T>(string SPName, params SqlParameter[] parameters) where T : class
    {
        var sql = $"EXEC {SPName} {string.Join(", ", parameters.Select(x => x.ParameterName))}";
        return this.Set<T>().FromSqlRaw(sql, parameters).ToList();
    }
}
