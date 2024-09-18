using Data.Data.SASAml;
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
        public virtual DbSet<ArtGoamlReportsValidationView> ArtGoamlReportsValidationViews { get; set; } = null!;

        public virtual DbSet<ArtHomeGoamlReportsDate> ArtHomeGoamlReportsDates { get; set; } = null!;
        public virtual DbSet<ArtHomeGoamlReportsPerType> ArtHomeGoamlReportsPerTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //GOAML
            modelBuilder.Entity<ArtStGoAmlReportsPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStGoAmlReportsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStGoAmlReportsPerIndicator>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStGoAmlReportsPerCreator>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_AML_PER_SCENARIO                 >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_STAFF_GOAML_AML_PER_CRIME        >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_STAFF_GOAML_AML_PER_PRODUCT      >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_STAFF_GOAML_AML_PER_REGION       >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_PRODUCT >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_REGION  >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_TYPE    >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_TOP_AML_BRANCHES                 >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_TOP_GOAML_BRANCHES               >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_TOP_SANCTION_BRANCHES            >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_UNUSAL_ACTIVITIES                >().HasNoKey().ToView(null);



            modelBuilder.Entity<ART_ST_YEARLY_AML_PER_REGION                  >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_AML_PER_TRRANSACTION_TYPE       >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_BOTTOM_AML_BRANCHES             >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_BOTTOM_GOAML_BRANCHES           >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_BOTTOM_SANCTION_BRANCHES        >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_CRIME   >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_PRODUCT >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_REGION  >().HasNoKey().ToView(null);



            modelBuilder.Entity<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_REGION >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_TYPE   >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_SANCTION_PER_PRODUCT                >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_SANCTION_PER_REGION                 >().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_YEARLY_SANCTION_PER_YEAR                   >().HasNoKey().ToView(null);





            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTGOAMLModelCreating(modelBuilder);
        }
    }
}
