using Data.Data.FTI;
using Data.Data.SASAml;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public class KYCContext : DbContext
    {
        //KYC

        public virtual DbSet<ArtKycHighExpiredU1> ArtKycHighExpiredU1s { get; set; } = null!;
        public virtual DbSet<ArtKycHighOneMonthU1> ArtKycHighOneMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycHighThreeMonthU1> ArtKycHighThreeMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycHighTwoMonthU1> ArtKycHighTwoMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycLowExpiredU1> ArtKycLowExpiredU1s { get; set; } = null!;
        public virtual DbSet<ArtKycLowOneMonthU1> ArtKycLowOneMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycLowThreeMonthU1> ArtKycLowThreeMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycLowTwoMonthU1> ArtKycLowTwoMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumExpiredU1> ArtKycMediumExpiredU1s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumOneMonthU1> ArtKycMediumOneMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumThreeMonthU1> ArtKycMediumThreeMonthU1s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumTwoMonthU1> ArtKycMediumTwoMonthU1s { get; set; } = null!;
        public virtual DbSet<CustomersWithExpiredDocumentU1> CustomersWithExpiredDocumentU1s { get; set; } = null!;
        public virtual DbSet<CustomersRenewalU1> CustomersRenewalU1s { get; set; } = null!;
        //--------------------------------------------------------------------------------------------------//
        public virtual DbSet<ArtAuditCorporateView> ArtAuditCorporateViews { get; set; } = null!;
        public virtual DbSet<ArtAuditIndividualsView> ArtAuditIndividualsViews { get; set; } = null!;
        public virtual DbSet<ArtKycExpiredId> ArtKycExpiredIds { get; set; } = null!;
        public virtual DbSet<ArtKycHighExpiredU2> ArtKycHighExpiredU2s { get; set; } = null!;
        public virtual DbSet<ArtKycHighOneMonthU2> ArtKycHighOneMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycHighThreeMonthU2> ArtKycHighThreeMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycHighTwoMonthU2> ArtKycHighTwoMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycLowExpiredU2> ArtKycLowExpiredU2s { get; set; } = null!;
        public virtual DbSet<ArtKycLowOneMonthU2> ArtKycLowOneMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycLowThreeMonthU2> ArtKycLowThreeMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycLowTwoMonthU2> ArtKycLowTwoMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumExpiredU2> ArtKycMediumExpiredU2s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumOneMonthU2> ArtKycMediumOneMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumThreeMonthU2> ArtKycMediumThreeMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumTwoMonthU2> ArtKycMediumTwoMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycSummaryByRisk> ArtKycSummaryByRisks { get; set; } = null!;
        public virtual DbSet<CustomersWithExpiredDocumentU2> CustomersWithExpiredDocumentU2s { get; set; } = null!;
        public virtual DbSet<CustomersRenewalU2> CustomersRenewalU2s { get; set; } = null!;
        //--------------------------------------------------------------------------------------------------//
        public virtual DbSet<ArtKycHighExpiredU3> ArtKycHighExpiredU3s { get; set; } = null!;
        public virtual DbSet<ArtKycHighOneMonthU3> ArtKycHighOneMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycHighThreeMonthU3> ArtKycHighThreeMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycHighTwoMonthU3> ArtKycHighTwoMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycLowExpiredU3> ArtKycLowExpiredU3s { get; set; } = null!;
        public virtual DbSet<ArtKycLowOneMonthU3> ArtKycLowOneMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycLowThreeMonthU3> ArtKycLowThreeMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycLowTwoMonthU3> ArtKycLowTwoMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumExpiredU3> ArtKycMediumExpiredU3s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumOneMonthU3> ArtKycMediumOneMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumThreeMonthU3> ArtKycMediumThreeMonthU3s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumTwoMonthU3> ArtKycMediumTwoMonthU3s { get; set; } = null!;
        public virtual DbSet<CustomersRenewalU3> CustomersRenewalU3s { get; set; } = null!;
        public virtual DbSet<CustomersWithExpiredDocumentU3> CustomersWithExpiredDocumentU3s { get; set; } = null!;
        //--------------------------------------------------------------------------------------------------//
        public virtual DbSet<ArtKycHighExpiredU4> ArtKycHighExpiredU4s { get; set; } = null!;
        public virtual DbSet<ArtKycHighOneMonthU4> ArtKycHighOneMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycHighThreeMonthU4> ArtKycHighThreeMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycHighTwoMonthU4> ArtKycHighTwoMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycLowExpiredU4> ArtKycLowExpiredU4s { get; set; } = null!;
        public virtual DbSet<ArtKycLowOneMonthU4> ArtKycLowOneMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycLowThreeMonthU4> ArtKycLowThreeMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycLowTwoMonthU4> ArtKycLowTwoMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumExpiredU4> ArtKycMediumExpiredU4s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumOneMonthU4> ArtKycMediumOneMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumThreeMonthU4> ArtKycMediumThreeMonthU4s { get; set; } = null!;
        public virtual DbSet<ArtKycMediumTwoMonthU4> ArtKycMediumTwoMonthU4s { get; set; } = null!;
        public virtual DbSet<CustomersRenewalU4> CustomersRenewalU4s { get; set; } = null!;
        public virtual DbSet<CustomersWithExpiredDocumentU4> CustomersWithExpiredDocumentU4s { get; set; } = null!;


        public KYCContext(DbContextOptions<KYCContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StCustomersPerCityU1>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersPerCityU2>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersPerCityU3>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersPerCityU4>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersRenewalPerMonthU1>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersRenewalPerMonthU2>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersRenewalPerMonthU3>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersRenewalPerMonthU4>().HasNoKey().ToView(null);

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnKYCModelCreating(modelBuilder);
        }

    }
}
