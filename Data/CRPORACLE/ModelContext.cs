using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.CRPORACLE
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtCrpConfig> ArtCrpConfigs { get; set; } = null!;
        public virtual DbSet<ArtCrpSystemPerformance> ArtCrpSystemPerformances { get; set; } = null!;
        public virtual DbSet<ArtCrpUserPerformance> ArtCrpUserPerformances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=ART;Password=ART1;Data Source=192.168.1.70:1521/orcl;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<ArtCrpConfig>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CRP_CONFIG");

                entity.Property(e => e.ActionDetail)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("ACTION_DETAIL");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.Checker)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CHECKER");

                entity.Property(e => e.CheckerAction)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("CHECKER_ACTION");

                entity.Property(e => e.CheckerDate)
                    .HasPrecision(6)
                    .HasColumnName("CHECKER_DATE");

                entity.Property(e => e.Maker)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MAKER");

                entity.Property(e => e.MakerDate)
                    .HasPrecision(6)
                    .HasColumnName("MAKER_DATE");
            });

            modelBuilder.Entity<ArtCrpSystemPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CRP_SYSTEM_PERFORMANCE");

                entity.Property(e => e.CaseCurrentRate)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CURRENT_RATE")
                    .IsFixedLength();

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseType)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.Casetargetrate)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("CASETARGETRATE")
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.CustomerName)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.DurationsInDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.EcmLastStatusDate)
                    .HasPrecision(6)
                    .HasColumnName("ECM_LAST_STATUS_DATE");
            });

            modelBuilder.Entity<ArtCrpUserPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CRP_USER_PERFORMANCE");

                entity.Property(e => e.Action)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.ActionUser)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_USER");

                entity.Property(e => e.AsssignedTime)
                    .HasPrecision(6)
                    .HasColumnName("ASSSIGNED_TIME");

                entity.Property(e => e.CaseCurrentRate)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CURRENT_RATE")
                    .IsFixedLength();

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseType)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.Casetargetrate)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("CASETARGETRATE")
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.CustomerName)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.DurationsInDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.ReleasedDate)
                    .HasPrecision(6)
                    .HasColumnName("RELEASED_DATE");
            });

            modelBuilder.HasSequence("HF_JOB_ID_SEQ");

            modelBuilder.HasSequence("HF_SEQUENCE");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
