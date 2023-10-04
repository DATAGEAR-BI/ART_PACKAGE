using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Audit.DGMGMT_AUD
{
    public class DGMGMTAUDContext : DbContext
    {
        public virtual DbSet<AccountAud> AccountAuds { get; set; } = null!;
        public virtual DbSet<GroupDgAud> GroupDgAuds { get; set; } = null!;
        public virtual DbSet<LoggedUserAud> LoggedUserAuds { get; set; } = null!;
        public virtual DbSet<RoleDgAud> RoleDgAuds { get; set; } = null!;
        public virtual DbSet<UserDgAud> UserDgAuds { get; set; } = null!;
        public DGMGMTAUDContext(DbContextOptions<DGMGMTAUDContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGMGMGMAUDodelCreating(modelBuilder);
        }
    }
}
