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
        public virtual DbSet<Art6MonthTransaction> Art6MonthTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlAllTransactionsWithReason> ArtDgamlAllTransactionsWithReasons { get; set; } = null!;
        public virtual DbSet<ArtDgamlCrossedLimitTransaction> ArtDgamlCrossedLimitTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlEWalletRepeatedTransaction> ArtDgamlEWalletRepeatedTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlIpnTransaction> ArtDgamlIpnTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlStaffToStaffDailyTransaction> ArtDgamlStaffToStaffDailyTransactions { get; set; } = null!;
        public virtual DbSet<ArtDgamlAlertDetailView> ArtDgAmlAlertDetailViews { get; set; } = null!;
        public virtual DbSet<ArtSystemPerformance> ArtSystemPerformances { get; set; } = null!;
        public virtual DbSet<ArtUserPerformance> ArtUserPerformances { get; set; } = null!;
        public virtual DbSet<ArtDgamlCasesTransactionsDetailPopUpWindow> ArtDgamlCasesTransactionsDetailPopUpWindows { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtDgamlCasesTransactions>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgamlAllTransAmountVsDivision>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgamlAllTransVsCased>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtDgamlCasesTransactionsDetail>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtDgamlAllTransaction>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtDgamlHierarchicalTransaction>().HasNoKey().ToView(null);

            modelBuilder.Entity<ArtStDgAmlAlertPerOwner>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlAlertsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlAlertsPerBranch>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlAlertsPerScenario>().HasNoKey().ToView(null);


            modelBuilder.Entity<ArtStDgAmlCasePerPriority>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCasePerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCasePerStatus>().HasNoKey().ToView(null);



            modelBuilder.Entity<ArtUserPerformancePerActionUser>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtUserPerformPerAction>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtUserPerformPerUserAndAction>().HasNoKey().ToView(null);


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGINTFRAUDModelCreating(modelBuilder);
        }

    }
}
