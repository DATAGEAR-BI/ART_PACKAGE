using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.GOAML
{
    public partial class GoAmlContext : DbContext
    {
        public GoAmlContext()
        {
        }

        public GoAmlContext(DbContextOptions<GoAmlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<ReportIndicatorType> ReportIndicatorTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.45;Database=DGGOAML_NEW;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_100_CI_AI");

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report", "target");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.CurrencyCodeLocal)
                    .HasMaxLength(255)
                    .HasColumnName("currencyCodeLocal");

                entity.Property(e => e.EntityReference)
                    .HasMaxLength(255)
                    .HasColumnName("entityReference");

                entity.Property(e => e.FiuRefNumber)
                    .HasMaxLength(255)
                    .HasColumnName("fiuRefNumber");

                entity.Property(e => e.IsValid)
                    .HasColumnName("isValid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("priority");

                entity.Property(e => e.Reason)
                    .HasMaxLength(4000)
                    .HasColumnName("reason");

                entity.Property(e => e.RentityBranch)
                    .HasMaxLength(255)
                    .HasColumnName("rentityBranch");

                entity.Property(e => e.RentityId).HasColumnName("rentityId");

                entity.Property(e => e.ReportClosedDate)
                    .HasMaxLength(255)
                    .HasColumnName("reportClosedDate");

                entity.Property(e => e.ReportCode)
                    .HasMaxLength(255)
                    .HasColumnName("reportCode");

                entity.Property(e => e.ReportCreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("reportCreatedBy");

                entity.Property(e => e.ReportCreatedDate)
                    .HasMaxLength(4000)
                    .HasColumnName("reportCreatedDate");

                entity.Property(e => e.ReportRiskSignificance)
                    .HasMaxLength(255)
                    .HasColumnName("reportRiskSignificance");

                entity.Property(e => e.ReportStatusCode)
                    .HasMaxLength(255)
                    .HasColumnName("reportStatusCode");

                entity.Property(e => e.ReportUserLockId)
                    .HasMaxLength(255)
                    .HasColumnName("reportUserLockId");

                entity.Property(e => e.ReportXml)
                    .HasMaxLength(255)
                    .HasColumnName("reportXml");

                entity.Property(e => e.ReportingPersonType)
                    .HasMaxLength(255)
                    .HasColumnName("reportingPersonType");

                entity.Property(e => e.SubmissionCode)
                    .HasMaxLength(255)
                    .HasColumnName("submissionCode");

                entity.Property(e => e.SubmissionDate)
                    .HasMaxLength(255)
                    .HasColumnName("submissionDate");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<ReportIndicatorType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ReportIndicatorType", "target");

                entity.Property(e => e.Indicator)
                    .HasMaxLength(255)
                    .HasColumnName("indicator");

                entity.Property(e => e.ReportId).HasColumnName("Report_ID");

                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK4seph8dn9avanwot531mj3js0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
