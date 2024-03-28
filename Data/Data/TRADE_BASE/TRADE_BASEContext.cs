using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.TRADE_BASE
{
    public partial class TRADE_BASEContext : DbContext
    {
        public TRADE_BASEContext()
        {
        }

        public TRADE_BASEContext(DbContextOptions<TRADE_BASEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtTradeBaseSummary> ArtTradeBaseSummaries { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            OnModelCreatingPartial(modelBuilder);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnTRADE_BASEModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
