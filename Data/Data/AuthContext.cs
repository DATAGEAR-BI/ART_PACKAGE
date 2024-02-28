using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data.ModelCreatingStrategies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Areas.Identity.Data;

public class AuthContext : IdentityDbContext<AppUser>
{

    public virtual DbSet<ArtSavedCustomReport> ArtSavedCustomReports { get; set; } = null!;
    public virtual DbSet<ArtSavedReportsColumns> ArtSavedReportsColumns { get; set; } = null!;
    public virtual DbSet<ArtSavedReportsChart> ArtSavedReportsCharts { get; set; } = null!;




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









        var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
        modelCreatingStrategy.OnModelCreating(modelBuilder);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseMySql("Server=192.168.1.182;Database=ART_DB;User=root;Password=P@ssw0rd;", new MySqlServerVersion(new Version(8, 0, 36)));
        }
    }

}
