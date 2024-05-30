using System;
using System.Collections.Generic;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Data.DGINTFRAUD
{
    public partial class DGINTFRAUDContext : DbContext
    {
        public DGINTFRAUDContext()
        {
        }

        public DGINTFRAUDContext(DbContextOptions<DGINTFRAUDContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ArtHomeAlertsPerDate> ArtHomeAlertsPerDates { get; set; } = null!;

        public virtual DbSet<ArtHomeAlertsPerStatus> ArtHomeAlertsPerStatuses { get; set; } = null!;
        public virtual DbSet<ArtDgamlAchTransaction> ArtDgamlAchTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlAllTransaction> ArtDgamlAllTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlAllTransactionsWithReason> ArtDgamlAllTransactionsWithReasons { get; set; } = null!;
        public virtual DbSet<ArtDgamlCasesTransactionsDetail> ArtDgamlCasesTransactionsDetails { get; set; } = null!;
        public virtual DbSet<ArtDgamlCrossedLimitTransaction> ArtDgamlCrossedLimitTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlEWalletRepeatedTransaction> ArtDgamlEWalletRepeatedTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlIpnTransaction> ArtDgamlIpnTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlStaffToStaffDailyTransaction> ArtDgamlStaffToStaffDailyTransactions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtDgamlCasesTransactions>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgamlAllTransAmountVsDivision>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgamlAllTransVsCased>().HasNoKey().ToView(null);

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGINTFRAUDModelCreating(modelBuilder);
        }

    }
}
