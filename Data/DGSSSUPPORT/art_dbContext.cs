using System;
using System.Collections.Generic;
using Data.Data.ARTDGSupport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DGSSSUPPORT
{
    public partial class art_dbContext : DbContext
    {
        public art_dbContext()
        {
        }

        public art_dbContext(DbContextOptions<art_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtHomeTicketsPerAge> ArtHomeTicketsPerAges { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerClient> ArtHomeTicketsPerClients { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerDate> ArtHomeTicketsPerDates { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerModule> ArtHomeTicketsPerModules { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerProduct> ArtHomeTicketsPerProducts { get; set; } = null!;
        public virtual DbSet<ArtHomeTicketsPerStatus> ArtHomeTicketsPerStatuses { get; set; } = null!;
        public virtual DbSet<ArtTicketDetail> ArtTicketDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=167.86.75.118;Database=art_db;User=itop;Password=P@ssw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
