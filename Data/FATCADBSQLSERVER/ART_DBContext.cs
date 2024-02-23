using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.FATCADBSQLSERVER
{
    public partial class ART_DBContext : DbContext
    {
        public ART_DBContext()
        {
        }

        public ART_DBContext(DbContextOptions<ART_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtFatcaAlert> ArtFatcaAlerts { get; set; } = null!;
        public virtual DbSet<ArtFatcaCace> ArtFatcaCaces { get; set; } = null!;
        public virtual DbSet<ArtFatcaCustomer> ArtFatcaCustomers { get; set; } = null!;
        public virtual DbSet<ArtFatcaDormantAccountsSummary> ArtFatcaDormantAccountsSummaries { get; set; } = null!;
        public virtual DbSet<ArtFatcaIrsReport> ArtFatcaIrsReports { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.45;Initial Catalog=ART_DB;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtFatcaAlert>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_ALERTS", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("branch_name")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("case_id")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_ID")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_Name")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.IncidentId)
                    .HasMaxLength(64)
                    .HasColumnName("Incident_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Type)
                    .HasMaxLength(4000)
                    .UseCollation("Arabic_100_CI_AI");
            });

            modelBuilder.Entity<ArtFatcaCace>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_CACES", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("branch_name")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("case_id")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("case_status")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(4000)
                    .HasColumnName("case_type")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_ID")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_Name")
                    .UseCollation("Arabic_CI_AS");
            });

            modelBuilder.Entity<ArtFatcaCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_CUSTOMERS", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("branch_name")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("case_id")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("case_status")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustClsFlag)
                    .HasMaxLength(10)
                    .HasColumnName("CUST_CLS_FLAG")
                    .IsFixedLength()
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.CustKey).HasColumnName("cust_key");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_ID")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_Name")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.MainNationality)
                    .HasMaxLength(4000)
                    .HasColumnName("Main_Nationality")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.SignW8)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W8")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.SignW9)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W9")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.W8SignDate)
                    .HasColumnType("datetime")
                    .HasColumnName("W8_SIGN_DATE");

                entity.Property(e => e.W9SignDate)
                    .HasColumnType("datetime")
                    .HasColumnName("W9_SIGN_DATE");
            });

            modelBuilder.Entity<ArtFatcaDormantAccountsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_DORMANT_ACCOUNTS_SUMMARY", "ART_DB");

                entity.Property(e => e.AmountInUsd)
                    .HasColumnType("numeric(38, 6)")
                    .HasColumnName("AMOUNT_IN_USD");

                entity.Property(e => e.NumberOfAccounts).HasColumnName("NUMBER_OF_ACCOUNTS");
            });

            modelBuilder.Entity<ArtFatcaIrsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_IRS_REPORT", "ART_DB");

                entity.Property(e => e.Accountbalance).HasColumnName("ACCOUNTBALANCE");

                entity.Property(e => e.Accountclosed)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCLOSED");

                entity.Property(e => e.AccountcountFatca201)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA201");

                entity.Property(e => e.AccountcountFatca202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA202");

                entity.Property(e => e.AccountcountFatca203).HasColumnName("ACCOUNTCOUNT_FATCA203");

                entity.Property(e => e.AccountcountFatca204)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA204");

                entity.Property(e => e.AccountcountFatca205)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA205");

                entity.Property(e => e.AccountcountFatca206)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA206");

                entity.Property(e => e.Accountholdertype)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTHOLDERTYPE");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(200)
                    .HasColumnName("ACCOUNTNUMBER")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Accounttype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTTYPE");

                entity.Property(e => e.AddressfreeE)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESSFREE_E")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.AddressfreeI)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESSFREE_I")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Birthdate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Countrycode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYCODE")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Countrycodeadd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYCODEADD")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(200)
                    .HasColumnName("FIRSTNAME")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(200)
                    .HasColumnName("LASTNAME")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(200)
                    .HasColumnName("MIDDLENAME")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(200)
                    .HasColumnName("NATIONALITY")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.OwnerAddress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_ADDRESS");

                entity.Property(e => e.OwnerFirstName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_FIRST_NAME");

                entity.Property(e => e.OwnerLastName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_LAST_NAME");

                entity.Property(e => e.OwnerResCountryCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_RES_COUNTRY_CODE");

                entity.Property(e => e.OwnerTin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_TIN");

                entity.Property(e => e.Paymentamnt501).HasColumnName("PAYMENTAMNT_501");

                entity.Property(e => e.Paymentamnt502).HasColumnName("PAYMENTAMNT_502");

                entity.Property(e => e.Paymentamnt503).HasColumnName("PAYMENTAMNT_503");

                entity.Property(e => e.Paymentamnt504).HasColumnName("PAYMENTAMNT_504");

                entity.Property(e => e.PoolbalanceFatca201)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA201");

                entity.Property(e => e.PoolbalanceFatca202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA202");

                entity.Property(e => e.PoolbalanceFatca203).HasColumnName("POOLBALANCE_FATCA203");

                entity.Property(e => e.PoolbalanceFatca204)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA204");

                entity.Property(e => e.PoolbalanceFatca205)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA205");

                entity.Property(e => e.PoolbalanceFatca206)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA206");

                entity.Property(e => e.SignW8)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W8")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.SignW9)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W9")
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIN")
                    .UseCollation("Arabic_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
