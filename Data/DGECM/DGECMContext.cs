using Microsoft.EntityFrameworkCore;

namespace Data.DGECM
{
    public partial class DGECMContext : DbContext
    {
        public DGECMContext()
        {
        }

        public DGECMContext(DbContextOptions<DGECMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefTableVal> RefTableVals { get; set; } = null!;
        public virtual DbSet<CaseLive> CaseLives { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this.Database.IsSqlServer())
                ModelCreatingConfigurator.DGECMSqlServerOnModelCreating(modelBuilder);

            if (this.Database.IsOracle())
                ModelCreatingConfigurator.DGECMSqlServerOnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

