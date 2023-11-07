using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.SEGMODEL
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

        public virtual DbSet<ArtAlertsPerSegmentTb> ArtAlertsPerSegmentTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegmentCustCountTb> ArtAllSegmentCustCountTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegmentsOutliersTb> ArtAllSegmentsOutliersTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegsFeatrsStatcsTb> ArtAllSegsFeatrsStatcsTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegsOutliersLimitTb> ArtAllSegsOutliersLimitTbs { get; set; } = null!;
        public virtual DbSet<ArtCustsPerTypeTb> ArtCustsPerTypeTbs { get; set; } = null!;
        public virtual DbSet<ArtIndustrySegmentTb> ArtIndustrySegmentTbs { get; set; } = null!;
        public virtual DbSet<ArtMebSegmentsV3Tb> ArtMebSegmentsV3Tbs { get; set; } = null!;
        public virtual DbSet<ArtSegoutvsallcustTb> ArtSegoutvsallcustTbs { get; set; } = null!;
        public virtual DbSet<ArtSegoutvsalloutTb> ArtSegoutvsalloutTbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                _ = optionsBuilder.UseOracle("User Id=ART;Password=ART1;Data Source=SAS-OracleT-test:1521/amltestdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.HasDefaultSchema("ART");

            _ = modelBuilder.Entity<ArtAlertsPerSegmentTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_ALERTS_PER_SEGMENT_TB");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfAlerts)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_ALERTS");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_DESCRIPTION");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            _ = modelBuilder.Entity<ArtAllSegmentCustCountTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_ALL_SEGMENT_CUST_COUNT_TB");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_DESCRIPTION");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            _ = modelBuilder.Entity<ArtAllSegmentsOutliersTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_ALL_SEGMENTS_OUTLIERS_TB");

                _ = entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                _ = entity.Property(e => e.BranchName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                _ = entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                _ = entity.Property(e => e.Feature)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("FEATURE");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                _ = entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                _ = entity.Property(e => e.UpperOutlierLimit)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UPPER_OUTLIER_LIMIT");
            });

            _ = modelBuilder.Entity<ArtAllSegsFeatrsStatcsTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_ALL_SEGS_FEATRS_STATCS_TB");

                _ = entity.Property(e => e.AvgCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_C_AMT");

                _ = entity.Property(e => e.AvgCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_D_AMT");

                _ = entity.Property(e => e.AvgCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_C_AMT");

                _ = entity.Property(e => e.AvgCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_D_AMT");

                _ = entity.Property(e => e.AvgInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.AvgInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.AvgLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.AvgLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.AvgMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_C_AMT");

                _ = entity.Property(e => e.AvgMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_D_AMT");

                _ = entity.Property(e => e.AvgTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_AMT");

                _ = entity.Property(e => e.AvgTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_CT_AMT");

                _ = entity.Property(e => e.AvgTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_DT_AMT");

                _ = entity.Property(e => e.AvgWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_C_AMT");

                _ = entity.Property(e => e.AvgWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_D_AMT");

                _ = entity.Property(e => e.MaxCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_C_AMT");

                _ = entity.Property(e => e.MaxCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_D_AMT");

                _ = entity.Property(e => e.MaxCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_C_AMT");

                _ = entity.Property(e => e.MaxCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_D_AMT");

                _ = entity.Property(e => e.MaxInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.MaxInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.MaxLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.MaxLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.MaxMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_C_AMT");

                _ = entity.Property(e => e.MaxMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_D_AMT");

                _ = entity.Property(e => e.MaxTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_AMT");

                _ = entity.Property(e => e.MaxTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_CT_AMT");

                _ = entity.Property(e => e.MaxTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_DT_AMT");

                _ = entity.Property(e => e.MaxWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_C_AMT");

                _ = entity.Property(e => e.MaxWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_D_AMT");

                _ = entity.Property(e => e.MinCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_C_AMT");

                _ = entity.Property(e => e.MinCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_D_AMT");

                _ = entity.Property(e => e.MinCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_C_AMT");

                _ = entity.Property(e => e.MinCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_D_AMT");

                _ = entity.Property(e => e.MinInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.MinInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.MinLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.MinLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.MinMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_C_AMT");

                _ = entity.Property(e => e.MinMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_D_AMT");

                _ = entity.Property(e => e.MinTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_AMT");

                _ = entity.Property(e => e.MinTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_CT_AMT");

                _ = entity.Property(e => e.MinTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_DT_AMT");

                _ = entity.Property(e => e.MinWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_C_AMT");

                _ = entity.Property(e => e.MinWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_D_AMT");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_DESCRIPTION");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                _ = entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                _ = entity.Property(e => e.TotalCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_AMT");

                _ = entity.Property(e => e.TotalCashCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_CNT");

                _ = entity.Property(e => e.TotalCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_AMT");

                _ = entity.Property(e => e.TotalCashDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_CNT");

                _ = entity.Property(e => e.TotalCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_C_AMT");

                _ = entity.Property(e => e.TotalCheckCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_C_CNT");

                _ = entity.Property(e => e.TotalCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_AMT");

                _ = entity.Property(e => e.TotalCheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_CNT");

                _ = entity.Property(e => e.TotalCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CNT");

                _ = entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                _ = entity.Property(e => e.TotalCtCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CT_CNT");

                _ = entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");

                _ = entity.Property(e => e.TotalDebitCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_CNT");

                _ = entity.Property(e => e.TotalInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.TotalInternaltransferCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                _ = entity.Property(e => e.TotalInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.TotalInternaltransferDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                _ = entity.Property(e => e.TotalLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.TotalLcBlClcnCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_CNT");

                _ = entity.Property(e => e.TotalLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.TotalLcBlClcnDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_CNT");

                _ = entity.Property(e => e.TotalMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_AMT");

                _ = entity.Property(e => e.TotalMiscCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_CNT");

                _ = entity.Property(e => e.TotalMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_AMT");

                _ = entity.Property(e => e.TotalMiscDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_CNT");

                _ = entity.Property(e => e.TotalWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_AMT");

                _ = entity.Property(e => e.TotalWireCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_CNT");

                _ = entity.Property(e => e.TotalWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_AMT");

                _ = entity.Property(e => e.TotalWireDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_CNT");
            });

            _ = modelBuilder.Entity<ArtAllSegsOutliersLimitTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_ALL_SEGS_OUTLIERS_LIMIT_TB");

                _ = entity.Property(e => e.Feature)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("FEATURE");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                _ = entity.Property(e => e.UpperOutlierLimit)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UPPER_OUTLIER_LIMIT");
            });

            _ = modelBuilder.Entity<ArtCustsPerTypeTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_CUSTS_PER_TYPE_TB");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            _ = modelBuilder.Entity<ArtIndustrySegmentTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_INDUSTRY_SEGMENT_TB");

                _ = entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                _ = entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                _ = entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                _ = entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");
            });

            _ = modelBuilder.Entity<ArtMebSegmentsV3Tb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_MEB_SEGMENTS_V3_TB");

                _ = entity.Property(e => e.AlertsCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ALERTS_CNT");

                _ = entity.Property(e => e.AvgCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_C_AMT");

                _ = entity.Property(e => e.AvgCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_D_AMT");

                _ = entity.Property(e => e.AvgCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_C_AMT");

                _ = entity.Property(e => e.AvgCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_D_AMT");

                _ = entity.Property(e => e.AvgInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.AvgInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.AvgLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.AvgLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.AvgMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_C_AMT");

                _ = entity.Property(e => e.AvgMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_D_AMT");

                _ = entity.Property(e => e.AvgTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_AMT");

                _ = entity.Property(e => e.AvgTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_CT_AMT");

                _ = entity.Property(e => e.AvgTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_DT_AMT");

                _ = entity.Property(e => e.AvgWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_C_AMT");

                _ = entity.Property(e => e.AvgWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_D_AMT");

                _ = entity.Property(e => e.IndustryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE")
                    .IsFixedLength();

                _ = entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                _ = entity.Property(e => e.MaxCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_C_AMT");

                _ = entity.Property(e => e.MaxCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_D_AMT");

                _ = entity.Property(e => e.MaxCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_C_AMT");

                _ = entity.Property(e => e.MaxCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_D_AMT");

                _ = entity.Property(e => e.MaxInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.MaxInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.MaxLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.MaxLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.MaxMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_C_AMT");

                _ = entity.Property(e => e.MaxMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_D_AMT");

                _ = entity.Property(e => e.MaxMls)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MLS");

                _ = entity.Property(e => e.MaxTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_AMT");

                _ = entity.Property(e => e.MaxTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_CT_AMT");

                _ = entity.Property(e => e.MaxTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_DT_AMT");

                _ = entity.Property(e => e.MaxWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_C_AMT");

                _ = entity.Property(e => e.MaxWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_D_AMT");

                _ = entity.Property(e => e.MinCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_C_AMT");

                _ = entity.Property(e => e.MinCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_D_AMT");

                _ = entity.Property(e => e.MinCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_C_AMT");

                _ = entity.Property(e => e.MinCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_D_AMT");

                _ = entity.Property(e => e.MinInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.MinInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.MinLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.MinLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.MinMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_C_AMT");

                _ = entity.Property(e => e.MinMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_D_AMT");

                _ = entity.Property(e => e.MinTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_AMT");

                _ = entity.Property(e => e.MinTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_CT_AMT");

                _ = entity.Property(e => e.MinTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_DT_AMT");

                _ = entity.Property(e => e.MinWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_C_AMT");

                _ = entity.Property(e => e.MinWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_D_AMT");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfLocations)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_LOCATIONS");

                _ = entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                _ = entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.RiskClassification)
                    .HasPrecision(1)
                    .HasColumnName("RISK_CLASSIFICATION");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                _ = entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                _ = entity.Property(e => e.TotalCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_AMT");

                _ = entity.Property(e => e.TotalCashCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_CNT");

                _ = entity.Property(e => e.TotalCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_AMT");

                _ = entity.Property(e => e.TotalCashDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_CNT");

                _ = entity.Property(e => e.TotalCheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_C_AMT");

                _ = entity.Property(e => e.TotalCheckCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_C_CNT");

                _ = entity.Property(e => e.TotalCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_AMT");

                _ = entity.Property(e => e.TotalCheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_CNT");

                _ = entity.Property(e => e.TotalCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CNT");

                _ = entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                _ = entity.Property(e => e.TotalCtCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CT_CNT");

                _ = entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");

                _ = entity.Property(e => e.TotalDebitCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_CNT");

                _ = entity.Property(e => e.TotalInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                _ = entity.Property(e => e.TotalInternaltransferCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                _ = entity.Property(e => e.TotalInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                _ = entity.Property(e => e.TotalInternaltransferDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                _ = entity.Property(e => e.TotalLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_AMT");

                _ = entity.Property(e => e.TotalLcBlClcnCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_CNT");

                _ = entity.Property(e => e.TotalLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_AMT");

                _ = entity.Property(e => e.TotalLcBlClcnDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_CNT");

                _ = entity.Property(e => e.TotalMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_AMT");

                _ = entity.Property(e => e.TotalMiscCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_CNT");

                _ = entity.Property(e => e.TotalMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_AMT");

                _ = entity.Property(e => e.TotalMiscDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_CNT");

                _ = entity.Property(e => e.TotalWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_AMT");

                _ = entity.Property(e => e.TotalWireCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_CNT");

                _ = entity.Property(e => e.TotalWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_AMT");

                _ = entity.Property(e => e.TotalWireDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_CNT");
            });

            _ = modelBuilder.Entity<ArtSegoutvsallcustTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_SEGOUTVSALLCUST_TB");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                _ = entity.Property(e => e.NumberOfOutliers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_OUTLIERS");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            _ = modelBuilder.Entity<ArtSegoutvsalloutTb>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("ART_SEGOUTVSALLOUT_TB");

                _ = entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                _ = entity.Property(e => e.NumberOfOutliers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_OUTLIERS");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                _ = entity.Property(e => e.TotalNumberOfOutliers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_NUMBER_OF_OUTLIERS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
