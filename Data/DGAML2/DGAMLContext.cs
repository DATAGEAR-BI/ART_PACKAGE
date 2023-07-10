using System;
using System.Collections.Generic;
using Data.DGAML;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DGAML2
{
    public partial class DGAMLContext : DbContext
    {
        public DGAMLContext()
        {
        }

        public DGAMLContext(DbContextOptions<DGAMLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.45;Database=DGAML;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.HasSequence("hibernate_sequence");

            modelBuilder.HasSequence("sequence_generator_AC_List", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_List_Category", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_List_Element", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Assessment", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier_Category", "AC");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
