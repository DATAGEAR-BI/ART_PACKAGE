using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data.Data;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.ModelCreatingStrategies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Areas.Identity.Data;

public class AuthContext : IdentityDbContext<AppUser>
{

    public virtual DbSet<ArtSavedCustomReport> ArtSavedCustomReports { get; set; }
    public virtual DbSet<ArtSavedReportsColumns> ArtSavedReportsColumns { get; set; }
    public virtual DbSet<ArtSavedReportsChart> ArtSavedReportsCharts { get; set; }



    //Aduit
    public virtual DbSet<ArtGroupsAuditView> ArtGroupsAuditViews { get; set; } = null!;
    public virtual DbSet<ArtRolesAuditView> ArtRolesAuditViews { get; set; } = null!;
    public virtual DbSet<ArtUsersAuditView> ArtUsersAuditViews { get; set; } = null!;
    public virtual DbSet<LastLoginPerDayView> LastLoginPerDayViews { get; set; } = null!;
    public virtual DbSet<ListGroupsRolesSummary> ListGroupsRolesSummaries { get; set; } = null!;
    public virtual DbSet<ListGroupsSubGroupsSummary> ListGroupsSubGroupsSummaries { get; set; } = null!;
    public virtual DbSet<ListOfDeletedUser> ListOfDeletedUsers { get; set; } = null!;
    public virtual DbSet<ListOfGroup> ListOfGroups { get; set; } = null!;
    public virtual DbSet<ListOfRole> ListOfRoles { get; set; } = null!;
    public virtual DbSet<ListOfUser> ListOfUsers { get; set; } = null!;
    public virtual DbSet<ListOfUsersAndGroupsRole> ListOfUsersAndGroupsRoles { get; set; } = null!;
    public virtual DbSet<ListOfUsersGroup> ListOfUsersGroups { get; set; } = null!;
    public virtual DbSet<ListOfUsersRole> ListOfUsersRoles { get; set; } = null!;



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
            e.HasOne<AppUser>(e => e.User)
                .WithMany(r => r.Reports)
                .HasForeignKey(x => x.UserId);

        });

        //AML
        modelBuilder.Entity<ArtStAlertPerOwner>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStAlertsPerStatus>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCasesPerCategory>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCasesPerPriority>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCasesPerStatus>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCasesPerSubcat>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCustPerBranch>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCustPerRisk>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStCustPerType>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStAmlPropRiskClass>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStAmlRiskClass>().HasNoKey().ToView(null);



        //GOAML
        modelBuilder.Entity<ArtStGoAmlReportsPerType>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStGoAmlReportsPerStatus>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStGoAmlReportsPerIndicator>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStGoAmlReportsPerCreator>().HasNoKey().ToView(null);

        //DGAML
        modelBuilder.Entity<ArtStDgAmlAlertPerOwner>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlAlertsPerStatus>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlCustomerPerBranch>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlCustomerPerType>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlCasesPerCategory>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlCasesPerPriority>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlCasesPerStatus>().HasNoKey().ToView(null);

        modelBuilder.Entity<ArtStDgAmlExternalCustomerPerBranch>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlExternalCustomerPerType>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlAlertsPerBranch>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStDgAmlAlertsPerScenario>().HasNoKey().ToView(null);

        var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
        modelCreatingStrategy.OnModelCreating(modelBuilder);
    }


}
