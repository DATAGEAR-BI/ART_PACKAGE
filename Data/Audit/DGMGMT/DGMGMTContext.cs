using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Audit.DGMGMT
{
    public partial class DGMGMTContext : DbContext
    {

        public DGMGMTContext(DbContextOptions<DGMGMTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroupDg> GroupDgs { get; set; } = null!;
        public virtual DbSet<RoleDg> RoleDgs { get; set; } = null!;
        public virtual DbSet<UserDg> UserDgs { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGMGMGModelCreating(modelBuilder);
        }


    }
}
