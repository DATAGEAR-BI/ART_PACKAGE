using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.FCFKC.SEG
{
    public partial class SEGFCFKCContext : DbContext
    {


        public SEGFCFKCContext(DbContextOptions<SEGFCFKCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MebSegmentsV3> MebSegmentsV3s { get; set; } = null!;
        public virtual DbSet<MebSegmentsV3Bk> MebSegmentsV3Bks { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSegFcfkcModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
