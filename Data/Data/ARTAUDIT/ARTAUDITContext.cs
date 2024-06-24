using Data.Data.ECM;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.ARTAUDIT
{
    public partial class ARTAUDITContext : DbContext
    {
        public ARTAUDITContext()
        {
        }

        public ARTAUDITContext(DbContextOptions<ARTAUDITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtAuditUserAccessLog> ArtAuditUserAccessLogs { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ArtStHierarchicalWorkFlow>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnART_AUDITModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}