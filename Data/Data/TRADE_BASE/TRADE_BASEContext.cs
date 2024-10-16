using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.TRADE_BASE
{
    public partial class TRADE_BASEContext : TenatDBContext
    {
   
        public TRADE_BASEContext(DbContextOptions<TRADE_BASEContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        public virtual DbSet<ArtTradeBaseSummary> ArtTradeBaseSummaries { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            OnModelCreatingPartial(modelBuilder);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnTRADE_BASEModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
