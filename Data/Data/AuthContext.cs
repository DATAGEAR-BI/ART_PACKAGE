using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data;
using Data.Data;
using Data.DGCMGMT;
using Data.FCF71;
using Data.ModelCreatingStrategies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;
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
    public virtual DbSet<ArtSystemPerformance> ArtSystemPerformances { get; set; } = null!;
    public virtual DbSet<ArtUserPerformance> ArtUserPerformances { get; set; } = null!;
    public virtual DbSet<ArtSystemPreformance> ArtSystemPreformances { get; set; } = null!;
    public virtual DbSet<ArtAlertedEntity> ArtAlertedEntities { get; set; } = null!;
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
    public virtual DbSet<ArtAmlTriageView> ArtAmlTriageViews { get; set; } = null!;
    public virtual DbSet<ArtAmlAlertDetailView> ArtAmlAlertDetailViews { get; set; } = null!;
    public virtual DbSet<ArtAmlCustomersDetailsView> ArtAmlCustomersDetailsViews { get; set; } = null!;
    public virtual DbSet<ArtAmlCaseDetailsView> ArtAmlCaseDetailsViews { get; set; } = null!;
    public virtual DbSet<ArtAmlHighRiskCustView> ArtAmlHighRiskCustViews { get; set; } = null!;
    public virtual DbSet<ArtRiskAssessmentView> ArtRiskAssessmentViews { get; set; } = null!;
    public virtual DbSet<ArtGoamlReportsIndicator> ArtGoamlReportsIndicators { get; set; } = null!;
    public virtual DbSet<ArtGoamlReportsDetail> ArtGoamlReportsDetails { get; set; } = null!;
    public virtual DbSet<ArtGoamlReportsSusbectParty> ArtGoamlReportsSusbectParties { get; set; } = null!;
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

        //Sanction
        modelBuilder.Entity<ArtSystemPrefPerDirection>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtSystemPrefPerStatus>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtSystemPerfPerType>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtSystemPerfPerDate>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtUserPerformancePerActionUser>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtUserPerformPerAction>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtUserPerformPerUserAndAction>().HasNoKey().ToView(null);

        //GOAML
        modelBuilder.Entity<ArtStGoAmlReportsPerType>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStGoAmlReportsPerStatus>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStGoAmlReportsPerIndicator>().HasNoKey().ToView(null);
        modelBuilder.Entity<ArtStGoAmlReportsPerCreator>().HasNoKey().ToView(null);

        var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStategyFactory(this).CreateModelCreatingInstance());
        modelCreatingStrategy.OnModelCreating(modelBuilder);
    }
    public IEnumerable<T> ExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
    {
        if (this.Database.IsSqlServer())
            return this.SqlServerExecuteProc<T>(SPName, parameters);
        if (this.Database.IsOracle())
            return this.OracleExecuteProc<T>(SPName, parameters);
        return Enumerable.Empty<T>();
    }

    private IEnumerable<T> SqlServerExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
    {
        var sql = $"EXEC {SPName} {string.Join(", ", parameters.Select(x => x.ParameterName))}";
        return this.Set<T>().FromSqlRaw(sql, parameters).ToList();
    }

    private IEnumerable<T> OracleExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
    {
        var output = parameters.FirstOrDefault(x => x.Direction == ParameterDirection.Output);
        if (output is null)
            throw new NullReferenceException("there is no output parameter");

        var command = this.Database.GetDbConnection().CreateCommand();
        command.CommandText = SPName;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(output);
        foreach (var param in parameters)
        {
            if (param.ParameterName == output.ParameterName)
                continue;

            command.Parameters.Add(param);
        }
        this.Database.OpenConnection();


        using var reader = command.ExecuteReader();
        var result = new List<T>();
        var properties = typeof(T).GetProperties();
        while (reader.Read())
        {
            var item = Activator.CreateInstance<T>();
            foreach (var property in properties)
            {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                {
                    var value = reader[property.Name];
                    property.SetValue(item, value);
                }
            }
            result.Add(item);
        }
        this.Database.CloseConnection();
        return result;

    }

}
