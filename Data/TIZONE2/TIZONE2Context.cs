using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.TIZONE2
{
    public partial class TIZONE2Context : DbContext
    {
        public TIZONE2Context()
        {
        }

        public TIZONE2Context(DbContextOptions<TIZONE2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Master> Masters { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnTiZoneModelCreating(modelBuilder);
        }


    }
}
