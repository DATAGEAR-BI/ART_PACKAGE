using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data.Constants.db;
using Data.Contracts;
using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Areas.Identity.Data;

public class CustomReportsContext : TenatDBContext
{
    public virtual DbSet<ArtCustomReport> ArtCustomReports { get; set; } = null!;
    public virtual DbSet<ArtReportsColumns> ArtReportsColumns { get; set; } = null!;
    public virtual DbSet<ArtReportsChart> ArtReportsCharts { get; set; } = null!;
    public virtual DbSet<ReportCategory> ReportCategories { get; set; } = null!;




    public CustomReportsContext(DbContextOptions<CustomReportsContext> options, ITenantService tenantService)
        : base(options, tenantService)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtCustomReport>(e =>
        {
            e.ToTable("ArtCustomReport");
        });
        modelBuilder.Entity<ArtCustomReport>()
            .HasOne(report => report.Category)
            .WithMany(category => category.ArtCustomReports)
            .HasForeignKey(report => report.CategoryId)
            .OnDelete(DeleteBehavior.SetNull); // Adjust delete behavior as needed

        modelBuilder.Entity<ArtReportsColumns>(e =>
            {
                e.HasKey(e => new { e.ReportId, e.Column });
                e.HasOne<ArtCustomReport>(r => r.Report)
                 .WithMany(c => c.Columns)
                 .HasForeignKey(fk => fk.ReportId);
            });
        modelBuilder.Entity<ArtReportsChart>(e =>
        {
            e.HasKey(e => new { e.ReportId, e.Column, e.Type });
            e.HasOne<ArtCustomReport>(r => r.Report)
             .WithMany(c => c.Charts)
             .HasForeignKey(fk => fk.ReportId);
            e.ToTable("ArtReportsChart");
        });
        modelBuilder.Entity<ReportCategory>().ToTable("ReportCategory")
         .HasMany(c => c.Children)
         .WithOne(c => c.Parent)
         .HasForeignKey(c => c.ParentId)
         .OnDelete(DeleteBehavior.Cascade); // Configure the delete behavior if needed


        var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
        modelCreatingStrategy.OnModelCreating(modelBuilder);

        base.OnModelCreating(modelBuilder);

    }
   


}
