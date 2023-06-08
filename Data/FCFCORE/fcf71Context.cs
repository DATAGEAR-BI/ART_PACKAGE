using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.FCFCORE
{
    public partial class fcf71Context : DbContext
    {
        public fcf71Context()
        {
        }

        public fcf71Context(DbContextOptions<fcf71Context> options)
            : base(options)
        {
        }

        public virtual DbSet<FscBranchDim> FscBranchDims { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.195;Database=fcf71;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FscBranchDim>(entity =>
            {
                entity.HasKey(e => e.BranchKey)
                    .HasName("XPKFSC_BRANCH_DIM");

                entity.ToTable("FSC_BRANCH_DIM", "FCFCORE");

                entity.Property(e => e.BranchKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("branch_key");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("branch_name");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("branch_number");

                entity.Property(e => e.BranchTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("branch_type_desc");

                entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_begin_date");

                entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("change_current_ind")
                    .IsFixedLength();

                entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_end_date")
                    .HasDefaultValueSql("('5999-01-01T00:00:00')");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(35)
                    .HasColumnName("street_address_2");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .HasColumnName("street_city_name");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_country_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("street_country_name");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("street_postal_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_state_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateName)
                    .HasMaxLength(35)
                    .HasColumnName("street_state_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
