﻿using ART_PACKAGE.Areas.Identity.Data.Configrations;
using Data.Data;
using Data.ModelCreatingStrategies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Areas.Identity.Data;

public class AuthContext : IdentityDbContext<AppUser>
{

    public virtual DbSet<ArtSavedCustomReport> ArtSavedCustomReports { get; set; } = null!;
    public virtual DbSet<ArtSavedReportsColumns> ArtSavedReportsColumns { get; set; } = null!;
    public virtual DbSet<ArtSavedReportsChart> ArtSavedReportsCharts { get; set; } = null!;
    public virtual DbSet<UserReport> UserReports { get; set; } = null!;




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

    }


}
