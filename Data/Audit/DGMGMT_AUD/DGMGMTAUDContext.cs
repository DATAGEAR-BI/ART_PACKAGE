using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.Audit.DGMGMT_AUD
{
    public class DGMGMTAUDContext : TenatDBContext
    {
        public virtual DbSet<AccountAud> AccountAuds { get; set; } = null!;
        public virtual DbSet<GroupDgAud> GroupDgAuds { get; set; } = null!;
        public virtual DbSet<LoggedUserAud> LoggedUserAuds { get; set; } = null!;
        public virtual DbSet<RoleDgAud> RoleDgAuds { get; set; } = null!;
        public virtual DbSet<UserDgAud> UserDgAuds { get; set; } = null!;
        public DGMGMTAUDContext(DbContextOptions<DGMGMTAUDContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "DGMGMTAUDContextConnection");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGMGMGMAUDodelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }
    }
}
