using Data.Data.FTI;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public class KYCContext : TenatDBContext
    {
        //KYC
        public virtual DbSet<ArtAuditCorporateView> ArtAuditCorporateViews { get; set; } = null!;
        public virtual DbSet<ArtAuditIndividualsView> ArtAuditIndividualsViews { get; set; } = null!;
        public virtual DbSet<ArtKycExpiredId> ArtKycExpiredIds { get; set; } = null!;
        public virtual DbSet<ArtKycHighExpired> ArtKycHighExpireds { get; set; } = null!;
        public virtual DbSet<ArtKycHighOneMonth> ArtKycHighOneMonths { get; set; } = null!;
        public virtual DbSet<ArtKycHighThreeMonth> ArtKycHighThreeMonths { get; set; } = null!;
        public virtual DbSet<ArtKycHighTwoMonth> ArtKycHighTwoMonths { get; set; } = null!;
        public virtual DbSet<ArtKycLowExpired> ArtKycLowExpireds { get; set; } = null!;
        public virtual DbSet<ArtKycLowOneMonth> ArtKycLowOneMonths { get; set; } = null!;
        public virtual DbSet<ArtKycLowThreeMonth> ArtKycLowThreeMonths { get; set; } = null!;
        public virtual DbSet<ArtKycLowTwoMonth> ArtKycLowTwoMonths { get; set; } = null!;
        public virtual DbSet<ArtKycMediumExpired> ArtKycMediumExpireds { get; set; } = null!;
        public virtual DbSet<ArtKycMediumOneMonth> ArtKycMediumOneMonths { get; set; } = null!;
        public virtual DbSet<ArtKycMediumThreeMonth> ArtKycMediumThreeMonths { get; set; } = null!;
        public virtual DbSet<ArtKycMediumTwoMonth> ArtKycMediumTwoMonths { get; set; } = null!;
        public virtual DbSet<ArtKycSummaryByRisk> ArtKycSummaryByRisks { get; set; } = null!;
        public KYCContext(DbContextOptions<KYCContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnKYCModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

    }
}
