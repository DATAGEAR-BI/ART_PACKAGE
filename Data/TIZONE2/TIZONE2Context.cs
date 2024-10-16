using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.TIZONE2
{
    public partial class TIZONE2Context : TenatDBContext
    {

        public TIZONE2Context(DbContextOptions<TIZONE2Context> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        public virtual DbSet<Master> Masters { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "TIZONEContextConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnTiZoneModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }


    }
}
