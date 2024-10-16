using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.AmlAnalysis
{
    public class AmlAnalysisContext : TenatDBContext
    {
        //public virtual DbSet<ArtAlertsStatusCustomer> ArtAlertsStatusCustomers { get; set; } = null!;
        public virtual DbSet<ArtAmlAnalysisView> ArtAmlAnalysisViews { get; set; } = null!;
        public virtual DbSet<ArtAmlAnalysisViewTb> ArtAmlAnalysisViewTbs { get; set; } = null!;
        public virtual DbSet<ArtAmlAnalysisRule> ArtAmlAnalysisRules { get; set; } = null!;

        public virtual DbSet<VaGroupInfo> VaGroupInfos { get; set; } = null!;
        public virtual DbSet<VaPersonInfo> VaPersonInfos { get; set; } = null!;
        public virtual DbSet<LstOfUsersAndGroupsRole> LstOfUsersAndGroupsRoles { get; set; } = null!;



        public AmlAnalysisContext(DbContextOptions<AmlAnalysisContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dbtype = this.Database.IsSqlServer() ? "sqlserver" : this.Database.IsOracle() ? "oracle" : "";
            modelBuilder.ApplyConfiguration(new ArtAmlAnalysisRuleConfigration(dbtype));
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnAmlAnalysisModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }
    }
}
