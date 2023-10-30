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
        public virtual DbSet<ArtAuditCorporateView> ArtAuditCorporateViews { get; set; } = null!;
        public virtual DbSet<ArtAuditIndividualsView> ArtAuditIndividualsViews { get; set; } = null!;
        public virtual DbSet<ArtKycExpiredId> ArtKycExpiredIds { get; set; } = null!;
        public virtual DbSet<ArtKycHighExpiredU2> ArtKycHighExpiredU2s { get; set; } = null!;
        public virtual DbSet<ArtKycHighOneMonthU2> ArtKycHighOneMonthU2s { get; set; } = null!;
        public virtual DbSet<ArtKycHighThreeMonthU2> ArtKycHighThreeU2Months { get; set; } = null!;
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


        public KYCContext(DbContextOptions<KYCContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StCustomersPerCityU2>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersPerCityU3>().HasNoKey().ToView(null);
            modelBuilder.Entity<StCustomersRenewalPerMonthU2>().HasNoKey().ToView(null);

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnKYCModelCreating(modelBuilder);
        }

    }
}
