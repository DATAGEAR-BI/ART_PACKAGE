using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Audit
{
    public partial class AuditContext : DbContext
    {
        public AuditContext()
        {
        }

        public AuditContext(DbContextOptions<AuditContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountAud> AccountAuds { get; set; } = null!;
        public virtual DbSet<GroupDg> GroupDgs { get; set; } = null!;
        public virtual DbSet<GroupDgAud> GroupDgAuds { get; set; } = null!;
        public virtual DbSet<LoggedUserAud> LoggedUserAuds { get; set; } = null!;
        public virtual DbSet<RoleDg> RoleDgs { get; set; } = null!;
        public virtual DbSet<RoleDgAud> RoleDgAuds { get; set; } = null!;
        public virtual DbSet<UserDg> UserDgs { get; set; } = null!;
        public virtual DbSet<UserDgAud> UserDgAuds { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDgAuditModelCreating(modelBuilder);
        }


    }
}
