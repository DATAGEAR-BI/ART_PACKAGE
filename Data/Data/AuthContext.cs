using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

    //AML
    public virtual DbSet<ArtHomeAlertsPerDate> ArtHomeAlertsPerDates { get; set; } = null!;
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

        //ACM
        modelBuilder.Entity<ArtHomeCasesDate>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_CASES_DATE", schema: "ART_DB");

            entity.Property(e => e.Day)
                .HasColumnType("int")
                .HasColumnName("DAY");

            entity.Property(e => e.Month)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("MONTH");

            entity.Property(e => e.NumberOfCases)
                .HasColumnType("int")
                .HasColumnName("NUMBER_OF_CASES");

            entity.Property(e => e.Year)
                .HasColumnType("int")
                .HasColumnName("YEAR");
        });

        modelBuilder.Entity<ArtHomeCasesStatus>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_CASES_STATUS", schema: "ART_DB");

            entity.Property(e => e.CaseStatus)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("CASE_STATUS");

            entity.Property(e => e.NumberOfCases)
                .HasColumnType("int")
                .HasColumnName("NUMBER_OF_CASES");
        });

        modelBuilder.Entity<ArtHomeCasesType>(entity =>
        {
            
            entity.HasNoKey();

            entity.ToView("ART_HOME_CASES_TYPES", schema: "ART_DB");

            entity.Property(e => e.CaseType)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("CASE_TYPE");

            entity.Property(e => e.NumberOfCases)
                .HasColumnType("int")
                .HasColumnName("NUMBER_OF_CASES");
        });

        //AML
        modelBuilder.Entity<ArtHomeAlertsPerDate>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_ALERTS_PER_DATE", "ART_DB");

            entity.Property(e => e.Month).HasMaxLength(4000);

            entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_ALerts");
        });

        modelBuilder.Entity<ArtHomeAlertsPerStatus>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_ALERTS_PER_STATUS", "ART_DB");

            entity.Property(e => e.AlertStatus)
                .HasMaxLength(100)
                .HasColumnName("ALERT_STATUS");

            entity.Property(e => e.AlertsCount).HasColumnName("Alerts_Count");
        });

        modelBuilder.Entity<ArtHomeNumberOfAccount>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_Number_Of_Accounts", "ART_DB");

            entity.Property(e => e.NumberOfAccounts).HasColumnName("Number_Of_Accounts");
        });

        modelBuilder.Entity<ArtHomeNumberOfCustomer>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_NUMBER_OF_CUSTOMERS", "ART_DB");

            entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers");
        });

        modelBuilder.Entity<ArtHomeNumberOfHighRiskCustomer>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS", "ART_DB");

            entity.Property(e => e.NumberOfHighRiskCustomers).HasColumnName("Number_Of_High_Risk_Customers");
        });

        modelBuilder.Entity<ArtHomeNumberOfPepCustomer>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_HOME_NUMBER_OF_PEP_CUSTOMERS", "ART_DB");

            entity.Property(e => e.NumberOfPepCustomers).HasColumnName("Number_Of_PEP_Customers");
        });
    }
}
