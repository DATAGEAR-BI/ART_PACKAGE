using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.ARTGOAML
{
    public class ArtGoAmlContext : DbContext
    {



        public ArtGoAmlContext(DbContextOptions<ArtGoAmlContext> options)
      : base(options)
        {
        }

        //GOAML
        public virtual DbSet<ArtGoamlReportsIndicator> ArtGoamlReportsIndicators { get; set; } = null!;
        public virtual DbSet<ArtGoamlReportsDetail> ArtGoamlReportsDetails { get; set; } = null!;
        public virtual DbSet<ArtGoamlReportsSusbectParty> ArtGoamlReportsSusbectParties { get; set; } = null!;

        public virtual DbSet<ArtHomeGoamlReportsDate> ArtHomeGoamlReportsDates { get; set; } = null!;
        public virtual DbSet<ArtHomeGoamlReportsPerType> ArtHomeGoamlReportsPerTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //GOAML
            modelBuilder.Entity<ArtStGoAmlReportsPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStGoAmlReportsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStGoAmlReportsPerIndicator>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStGoAmlReportsPerCreator>().HasNoKey().ToView(null);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTGOAMLModelCreating(modelBuilder);
        }
    }
}
