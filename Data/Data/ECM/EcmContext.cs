using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.ECM
{
    public class EcmContext : DbContext
    {
        //ECM 
        public virtual DbSet<ArtHomeCasesDate> ArtHomeCasesDates { get; set; } = null!;
        public virtual DbSet<ArtHomeCasesStatus> ArtHomeCasesStatuses { get; set; } = null!;
        public virtual DbSet<ArtHomeCasesType> ArtHomeCasesTypes { get; set; } = null!;
        public virtual DbSet<ArtSystemPrefPerDirection> ArtSystemPrefPerDirections { get; set; } = null!;
        public virtual DbSet<ArtSystemPerfPerType> ArtSystemPerfPerTypes { get; set; } = null!;
        public virtual DbSet<ArtUserPerformance> ArtUserPerformances { get; set; } = null!;
        public virtual DbSet<ArtSystemPreformance> ArtSystemPreformances { get; set; } = null!;
        public virtual DbSet<ArtUserPerformancePerActionUser> ArtUserPerformancePerActionUsers { get; set; } = null!;
        public virtual DbSet<ArtUserPerformPerAction> ArtUserPerformPerActions { get; set; } = null!;
        public virtual DbSet<ArtUserPerformPerUserAndAction> ArtUserPerformPerUserAndActions { get; set; } = null!;
        public virtual DbSet<ArtSystemPrefPerStatus> ArtSystemPrefPerStatuses { get; set; } = null!;
        public virtual DbSet<ArtAlertedEntity> ArtAlertedEntities { get; set; } = null!;
        public EcmContext(DbContextOptions<EcmContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnEcmModelCreating(modelBuilder);
        }

    }
}

