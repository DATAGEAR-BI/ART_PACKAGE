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
        public virtual DbSet<Taccount> Taccounts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_100_CI_AI");

            modelBuilder.Entity<Taccount>(entity =>
            {
                entity.ToTable("TAccount", "target");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .HasColumnName("accountName");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(30, 5)")
                    .HasColumnName("balance");

                entity.Property(e => e.Beneficiary)
                    .HasMaxLength(255)
                    .HasColumnName("beneficiary");

                entity.Property(e => e.BeneficiaryComment)
                    .HasMaxLength(255)
                    .HasColumnName("beneficiaryComment");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasColumnName("branch");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("clientNumber");

                entity.Property(e => e.Closed)
                    .HasMaxLength(255)
                    .HasColumnName("closed");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .HasColumnName("comments");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(255)
                    .HasColumnName("currencyCode");

                entity.Property(e => e.DateBalance)
                    .HasMaxLength(255)
                    .HasColumnName("dateBalance");

                entity.Property(e => e.Iban)
                    .HasMaxLength(255)
                    .HasColumnName("iban");

                entity.Property(e => e.InstitutionCode)
                    .HasMaxLength(255)
                    .HasColumnName("institutionCode");

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(255)
                    .HasColumnName("institutionName");

                entity.Property(e => e.IsEntity).HasColumnName("isEntity");

                entity.Property(e => e.IsReviewed).HasColumnName("is_reviewed");

                entity.Property(e => e.NonBankInstitution).HasColumnName("nonBankInstitution");

                entity.Property(e => e.Opened)
                    .HasMaxLength(255)
                    .HasColumnName("opened");

                entity.Property(e => e.PersonalAccountType)
                    .HasMaxLength(255)
                    .HasColumnName("personalAccountType");

                entity.Property(e => e.ReportPartyTypeId).HasColumnName("reportPartyType_id");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(255)
                    .HasColumnName("statusCode");

                entity.Property(e => e.Swift)
                    .HasMaxLength(255)
                    .HasColumnName("swift");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");
            });

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
