using Data.Data.CRP;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGSupport
{
    public partial class ARTDGSupportContext:DbContext
    {
        public virtual DbSet<ArtHomeTicketsPerAge> ArtHomeTicketsPerAges { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerClient> ArtHomeTicketsPerClients { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerDate> ArtHomeTicketsPerDates { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerModule> ArtHomeTicketsPerModules { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerProduct> ArtHomeTicketsPerProducts { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerStatus> ArtHomeTicketsPerStatuses { get; set; } = null!;
        public virtual DbSet<ArtTicketDetail> ArtTicketDetails { get; set; } = null!;

        public ARTDGSupportContext(DbContextOptions<ARTDGSupportContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ArtStTicketsPerAge>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStTicketsPerModule>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStTicketsPerProduct>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStTicketsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStTicketsPerClient>().HasNoKey().ToView(null);
            /*  modelBuilder.Entity<ART_ST_CRP_PER_STATUS>().HasNoKey().ToView(null);
              modelBuilder.Entity<ART_ST_CRP_PER_RISK>().HasNoKey().ToView(null);
              modelBuilder.Entity<ART_ST_CRP_CASES_PER_RATE>().HasNoKey().ToView(null);*/


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTDGSupportModelCreating(modelBuilder);
        }
    }
}
