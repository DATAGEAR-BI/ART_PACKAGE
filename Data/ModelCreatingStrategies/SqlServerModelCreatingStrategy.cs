using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Data;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.CRP;
using Data.Data.ECM;
using Data.Data.SASAml;
using Data.Data.SASAUDIT;
using Data.Data.Segmentation;
using Data.Data.TRADE_BASE;
using Data.DATA.FATCA;
using Data.DGAML;
using Data.DGECM;
using Data.DGSASAUDIT;
using Data.FCF71;
using Data.FCFCORE;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Microsoft.EntityFrameworkCore;


namespace Data.ModelCreatingStrategies
{
    public class SqlServerModelCreatingStrategy : IBaseModelCreatingStrategy
    {


        public void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public void OnSegmentionModelCreating(ModelBuilder modelBuilder)
        {
            // SEGMENT
            modelBuilder.Entity<ArtAlertsPerSegmentTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALERTS_PER_SEGMENT_TB", "ART_DB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("month_key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_Alerts");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("party_type_desc")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");
                entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("segment_description");
            });

            modelBuilder.Entity<ArtAllSegmentCustCountTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGMENT_CUST_COUNT_TB", "ART_DB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Month_Key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");
                entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("segment_description");
            });

            modelBuilder.Entity<ArtAllSegmentsOutliersTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGMENTS_OUTLIERS_TB", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.Feature)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("FEATURE");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Month_Key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_name")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.UpperOutlierLimit).HasColumnName("Upper_outlier_limit");
            });

            modelBuilder.Entity<ArtAllSegsFeatrsStatcsTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGS_FEATRS_STATCS_TB", "ART_DB");

                entity.Property(e => e.AvgCashCAmt).HasColumnName("AVG_CASH_C_AMT");

                entity.Property(e => e.AvgCashDAmt).HasColumnName("AVG_CASH_D_AMT");

                entity.Property(e => e.AvgCheckDAmt).HasColumnName("AVG_CHECK_D_AMT");

                entity.Property(e => e.AvgFeesDAmt).HasColumnName("AVG_FEES_D_AMT");

                entity.Property(e => e.AvgInternaltransferCAmt).HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.AvgInternaltransferDAmt).HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.AvgMiscCAmt).HasColumnName("AVG_MISC_C_AMT");

                entity.Property(e => e.AvgTotalAmt).HasColumnName("AVG_TOTAL_AMT");

                entity.Property(e => e.AvgTotalCtAmt).HasColumnName("AVG_TOTAL_CT_AMT");

                entity.Property(e => e.AvgTotalDtAmt).HasColumnName("AVG_TOTAL_DT_AMT");

                entity.Property(e => e.AvgWireCAmt).HasColumnName("AVG_WIRE_C_AMT");

                entity.Property(e => e.AvgWireDAmt).HasColumnName("AVG_WIRE_D_AMT");

                entity.Property(e => e.AvgWithdrawalDAmt).HasColumnName("AVG_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MaxCashCAmt).HasColumnName("MAX_CASH_C_AMT");

                entity.Property(e => e.MaxCashDAmt).HasColumnName("MAX_CASH_D_AMT");

                entity.Property(e => e.MaxCheckDAmt).HasColumnName("MAX_CHECK_D_AMT");

                entity.Property(e => e.MaxFeesDAmt).HasColumnName("MAX_FEES_D_AMT");

                entity.Property(e => e.MaxInternaltransferCAmt).HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MaxInternaltransferDAmt).HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MaxMiscCAmt).HasColumnName("MAX_MISC_C_AMT");

                entity.Property(e => e.MaxTotalAmt).HasColumnName("MAX_TOTAL_AMT");

                entity.Property(e => e.MaxTotalCtAmt).HasColumnName("MAX_TOTAL_CT_AMT");

                entity.Property(e => e.MaxTotalDtAmt).HasColumnName("MAX_TOTAL_DT_AMT");

                entity.Property(e => e.MaxWireCAmt).HasColumnName("MAX_WIRE_C_AMT");

                entity.Property(e => e.MaxWireDAmt).HasColumnName("MAX_WIRE_D_AMT");

                entity.Property(e => e.MaxWithdrawalDAmt).HasColumnName("MAX_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MinCashCAmt).HasColumnName("MIN_CASH_C_AMT");

                entity.Property(e => e.MinCashDAmt).HasColumnName("MIN_CASH_D_AMT");

                entity.Property(e => e.MinCheckDAmt).HasColumnName("MIN_CHECK_D_AMT");

                entity.Property(e => e.MinFeesDAmt).HasColumnName("MIN_FEES_D_AMT");

                entity.Property(e => e.MinInternaltransferCAmt).HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MinInternaltransferDAmt).HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MinMiscCAmt).HasColumnName("MIN_MISC_C_AMT");

                entity.Property(e => e.MinTotalAmt).HasColumnName("MIN_TOTAL_AMT");

                entity.Property(e => e.MinTotalCtAmt).HasColumnName("MIN_TOTAL_CT_AMT");

                entity.Property(e => e.MinTotalDtAmt).HasColumnName("MIN_TOTAL_DT_AMT");

                entity.Property(e => e.MinWireCAmt).HasColumnName("MIN_WIRE_C_AMT");

                entity.Property(e => e.MinWireDAmt).HasColumnName("MIN_WIRE_D_AMT");

                entity.Property(e => e.MinWithdrawalDAmt).HasColumnName("MIN_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");
                entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("segment_description");
                entity.Property(e => e.TotalAmount).HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalCashCAmt).HasColumnName("TOTAL_CASH_C_AMT");

                entity.Property(e => e.TotalCashCCnt).HasColumnName("TOTAL_CASH_C_CNT");

                entity.Property(e => e.TotalCashDAmt).HasColumnName("TOTAL_CASH_D_AMT");

                entity.Property(e => e.TotalCashDCnt).HasColumnName("TOTAL_CASH_D_CNT");

                entity.Property(e => e.TotalCheckDAmt).HasColumnName("TOTAL_CHECK_D_AMT");

                entity.Property(e => e.TotalCheckDCnt).HasColumnName("TOTAL_CHECK_D_CNT");

                entity.Property(e => e.TotalCnt).HasColumnName("TOTAL_CNT");

                entity.Property(e => e.TotalCreditAmount).HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalCtCnt).HasColumnName("TOTAL_CT_CNT");

                entity.Property(e => e.TotalDebitAmount).HasColumnName("TOTAL_DEBIT_AMOUNT");

                entity.Property(e => e.TotalDebitCnt).HasColumnName("TOTAL_DEBIT_CNT");

                entity.Property(e => e.TotalFeesDAmt).HasColumnName("TOTAL_FEES_D_AMT");

                entity.Property(e => e.TotalFeesDCnt).HasColumnName("TOTAL_FEES_D_CNT");

                entity.Property(e => e.TotalInternaltransferCAmt).HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.TotalInternaltransferCCnt).HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                entity.Property(e => e.TotalInternaltransferDAmt).HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.TotalInternaltransferDCnt).HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                entity.Property(e => e.TotalMiscCAmt).HasColumnName("TOTAL_MISC_C_AMT");

                entity.Property(e => e.TotalMiscCCnt).HasColumnName("TOTAL_MISC_C_CNT");

                entity.Property(e => e.TotalWireCAmt).HasColumnName("TOTAL_WIRE_C_AMT");

                entity.Property(e => e.TotalWireCCnt).HasColumnName("TOTAL_WIRE_C_CNT");

                entity.Property(e => e.TotalWireDAmt).HasColumnName("TOTAL_WIRE_D_AMT");

                entity.Property(e => e.TotalWireDCnt).HasColumnName("TOTAL_WIRE_D_CNT");

                entity.Property(e => e.TotalWithdrawalDAmt).HasColumnName("TOTAL_WITHDRAWAL_D_AMT");

                entity.Property(e => e.TotalWithdrawalDCnt).HasColumnName("TOTAL_WITHDRAWAL_D_CNT");
            });

            modelBuilder.Entity<ArtAllSegsOutliersLimitTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGS_OUTLIERS_LIMIT_TB", "ART_DB");

                entity.Property(e => e.Feature)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("feature");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("month_key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("party_type_desc")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.UpperOutlierLimit).HasColumnName("Upper_outlier_limit");
            });

            modelBuilder.Entity<ArtChangedSegmentTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_CHANGED_SEGMENT_TB", "ART_DB");

                entity.Property(e => e.CreationDate)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATION_DATE")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.LastSegmentId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LAST_SEGMENT_ID")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASSIFICATION")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED")
                    .UseCollation("Arabic_CI_AI");
            });

            modelBuilder.Entity<ArtIndustrySegmentTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_INDUSTRY_SEGMENT_TB", "ART_DB");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("industry_desc")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("month_key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("party_type_Desc")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.Property(e => e.TotalCreditAmount).HasColumnName("total_credit_amount");

                entity.Property(e => e.TotalDebitAmount).HasColumnName("total_debit_amount");
            });

            modelBuilder.Entity<ArtMebSegmentsV3Tb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_MEB_SEGMENTS_V3_TB", "ART_DB");

                entity.Property(e => e.AlertsCnt).HasColumnName("ALERTS_CNT");

                entity.Property(e => e.AvgCashCAmt).HasColumnName("AVG_CASH_C_AMT");

                entity.Property(e => e.AvgCashDAmt).HasColumnName("AVG_CASH_D_AMT");

                entity.Property(e => e.AvgCheckDAmt).HasColumnName("AVG_CHECK_D_AMT");

                entity.Property(e => e.AvgFeesDAmt).HasColumnName("AVG_FEES_D_AMT");

                entity.Property(e => e.AvgInternaltransferCAmt).HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.AvgInternaltransferDAmt).HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.AvgMiscCAmt).HasColumnName("AVG_MISC_C_AMT");

                entity.Property(e => e.AvgTotalAmt).HasColumnName("AVG_TOTAL_AMT");

                entity.Property(e => e.AvgTotalCtAmt).HasColumnName("AVG_TOTAL_CT_AMT");

                entity.Property(e => e.AvgTotalDtAmt).HasColumnName("AVG_TOTAL_DT_AMT");

                entity.Property(e => e.AvgWireCAmt).HasColumnName("AVG_WIRE_C_AMT");

                entity.Property(e => e.AvgWireDAmt).HasColumnName("AVG_WIRE_D_AMT");

                entity.Property(e => e.AvgWithdrawalDAmt).HasColumnName("AVG_WITHDRAWAL_D_AMT");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.MaxCashCAmt).HasColumnName("MAX_CASH_C_AMT");

                entity.Property(e => e.MaxCashDAmt).HasColumnName("MAX_CASH_D_AMT");

                entity.Property(e => e.MaxCheckDAmt).HasColumnName("MAX_CHECK_D_AMT");

                entity.Property(e => e.MaxFeesDAmt).HasColumnName("MAX_FEES_D_AMT");

                entity.Property(e => e.MaxInternaltransferCAmt).HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MaxInternaltransferDAmt).HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MaxMiscCAmt).HasColumnName("MAX_MISC_C_AMT");

                entity.Property(e => e.MaxMls).HasColumnName("MAX_MLS");

                entity.Property(e => e.MaxTotalAmt).HasColumnName("MAX_TOTAL_AMT");

                entity.Property(e => e.MaxTotalCtAmt).HasColumnName("MAX_TOTAL_CT_AMT");

                entity.Property(e => e.MaxTotalDtAmt).HasColumnName("MAX_TOTAL_DT_AMT");

                entity.Property(e => e.MaxWireCAmt).HasColumnName("MAX_WIRE_C_AMT");

                entity.Property(e => e.MaxWireDAmt).HasColumnName("MAX_WIRE_D_AMT");

                entity.Property(e => e.MaxWithdrawalDAmt).HasColumnName("MAX_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MinCashCAmt).HasColumnName("MIN_CASH_C_AMT");

                entity.Property(e => e.MinCashDAmt).HasColumnName("MIN_CASH_D_AMT");

                entity.Property(e => e.MinCheckDAmt).HasColumnName("MIN_CHECK_D_AMT");

                entity.Property(e => e.MinFeesDAmt).HasColumnName("MIN_FEES_D_AMT");

                entity.Property(e => e.MinInternaltransferCAmt).HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MinInternaltransferDAmt).HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MinMiscCAmt).HasColumnName("MIN_MISC_C_AMT");

                entity.Property(e => e.MinTotalAmt).HasColumnName("MIN_TOTAL_AMT");

                entity.Property(e => e.MinTotalCtAmt).HasColumnName("MIN_TOTAL_CT_AMT");

                entity.Property(e => e.MinTotalDtAmt).HasColumnName("MIN_TOTAL_DT_AMT");

                entity.Property(e => e.MinWireCAmt).HasColumnName("MIN_WIRE_C_AMT");

                entity.Property(e => e.MinWireDAmt).HasColumnName("MIN_WIRE_D_AMT");

                entity.Property(e => e.MinWithdrawalDAmt).HasColumnName("MIN_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASSIFICATION")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.TotalAmount).HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalCashCAmt).HasColumnName("TOTAL_CASH_C_AMT");

                entity.Property(e => e.TotalCashCCnt).HasColumnName("TOTAL_CASH_C_CNT");

                entity.Property(e => e.TotalCashDAmt).HasColumnName("TOTAL_CASH_D_AMT");

                entity.Property(e => e.TotalCashDCnt).HasColumnName("TOTAL_CASH_D_CNT");

                entity.Property(e => e.TotalCheckDAmt).HasColumnName("TOTAL_CHECK_D_AMT");

                entity.Property(e => e.TotalCheckDCnt).HasColumnName("TOTAL_CHECK_D_CNT");

                entity.Property(e => e.TotalCnt).HasColumnName("TOTAL_CNT");

                entity.Property(e => e.TotalCreditAmount).HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalCtCnt).HasColumnName("TOTAL_CT_CNT");

                entity.Property(e => e.TotalDebitAmount).HasColumnName("TOTAL_DEBIT_AMOUNT");

                entity.Property(e => e.TotalDebitCnt).HasColumnName("TOTAL_DEBIT_CNT");

                entity.Property(e => e.TotalFeesDAmt).HasColumnName("TOTAL_FEES_D_AMT");

                entity.Property(e => e.TotalFeesDCnt).HasColumnName("TOTAL_FEES_D_CNT");

                entity.Property(e => e.TotalInternaltransferCAmt).HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.TotalInternaltransferCCnt).HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                entity.Property(e => e.TotalInternaltransferDAmt).HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.TotalInternaltransferDCnt).HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                entity.Property(e => e.TotalMiscCAmt).HasColumnName("TOTAL_MISC_C_AMT");

                entity.Property(e => e.TotalMiscCCnt).HasColumnName("TOTAL_MISC_C_CNT");

                entity.Property(e => e.TotalWireCAmt).HasColumnName("TOTAL_WIRE_C_AMT");

                entity.Property(e => e.TotalWireCCnt).HasColumnName("TOTAL_WIRE_C_CNT");

                entity.Property(e => e.TotalWireDAmt).HasColumnName("TOTAL_WIRE_D_AMT");

                entity.Property(e => e.TotalWireDCnt).HasColumnName("TOTAL_WIRE_D_CNT");

                entity.Property(e => e.TotalWithdrawalDAmt).HasColumnName("TOTAL_WITHDRAWAL_D_AMT");

                entity.Property(e => e.TotalWithdrawalDCnt).HasColumnName("TOTAL_WITHDRAWAL_D_CNT");
            });

            modelBuilder.Entity<ArtSegoutvsallcustTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_SEGOUTVSALLCUST_TB", "ART_DB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Month_Key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_of_Customers");

                entity.Property(e => e.NumberOfOutliers).HasColumnName("Number_of_Outliers");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");
            });

            modelBuilder.Entity<ArtSegoutvsalloutTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_SEGOUTVSALLOUT_TB", "ART_DB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Month_Key")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.NumberOfOutliers).HasColumnName("Number_of_Outliers");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("segment_sorted")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.TotalNumberOfOutliers).HasColumnName("Total_Number_of_Outliers");
            });

            modelBuilder.Entity<ArtCustsPerTypeTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_CUSTS_PER_TYPE_TB", "ART_DB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED")
                    .UseCollation("Arabic_CI_AI");
            });
        }
        public void OnARTGOAMLModelCreating(ModelBuilder modelBuilder)
        {
            //GOAML
            modelBuilder.Entity<ArtGoamlReportsDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GOAML_REPORTS_DETAILS", "ART_DB");

                entity.Property(e => e.Action)
                    .HasColumnName("ACTION")
                    .UseCollation("Arabic_BIN");

                entity.Property(e => e.Currencycodelocal)
                    .HasMaxLength(255)
                    .HasColumnName("CURRENCYCODELOCAL")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Entityreference)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITYREFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Fiurefnumber)
                    .HasMaxLength(255)
                    .HasColumnName("FIUREFNUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Isvalid).HasColumnName("ISVALID");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("LOCATION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("PRIORITY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reason)
                    .HasMaxLength(4000)
                    .HasColumnName("REASON")
                    .UseCollation("Arabic_BIN");

                entity.Property(e => e.Rentitybranch)
                    .HasMaxLength(255)
                    .HasColumnName("RENTITYBRANCH")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Rentityid).HasColumnName("RENTITYID");

                entity.Property(e => e.Reportcloseddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.Reportcode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcreatedby)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCREATEDBY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcreateddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.Reportingpersontype)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTINGPERSONTYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportrisksignificance)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTRISKSIGNIFICANCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportstatuscode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTSTATUSCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportuserlockid)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTUSERLOCKID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportxml)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTXML")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Submissioncode)
                    .HasMaxLength(255)
                    .HasColumnName("SUBMISSIONCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Submissiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("VERSION")
                    .UseCollation("Arabic_100_CI_AI");
            });

            modelBuilder.Entity<ArtGoamlReportsIndicator>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GOAML_REPORTS_INDICATORS", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Indicator)
                    .HasMaxLength(255)
                    .HasColumnName("INDICATOR")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");
            });

            modelBuilder.Entity<ArtGoamlReportsSusbectParty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GOAML_REPORTS_SUSBECT_PARTIES", "ART_DB");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("ACCOUNT")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Activity)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasColumnName("BRANCH")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Entityreference)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITYREFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Fiurefnumber)
                    .HasMaxLength(255)
                    .HasColumnName("FIUREFNUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PartyId)
                    .HasMaxLength(255)
                    .HasColumnName("PARTY_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(765)
                    .HasColumnName("PARTY_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Partynumber)
                    .HasMaxLength(255)
                    .HasColumnName("PARTYNUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcloseddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.Reportcode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcreateddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.Reportstatuscode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTSTATUSCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Submissiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Transactionnumber)
                    .HasMaxLength(255)
                    .HasColumnName("TRANSACTIONNUMBER")
                    .UseCollation("Arabic_100_CI_AI");
            });

            modelBuilder.Entity<ArtHomeGoamlReportsDate>(entity =>
            {
                entity.ToTable("ART_HOME_GOAML_REPORTS_DATE", "ART_DB"); // Specify the view name
                entity.HasNoKey();

                entity.Property(e => e.CountOfReportId)
                    .HasColumnName("COUNT_OF_REPORT_ID")
                    .HasColumnType("decimal(18, 2)") // Adjust precision as needed
                    .HasMaxLength(10) // This may not be necessary for decimal types
                    .IsRequired(false);

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasColumnType("int")
                    .HasMaxLength(10) // This may not be necessary for int types
                    .IsRequired(false);

                entity.Property(e => e.Month)
                    .HasColumnName("MONTH")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(4000)
                    .IsRequired(false);
            });
            modelBuilder.Entity<ArtHomeGoamlReportsPerType>(entity =>
            {
                entity.ToTable("ART_HOME_GOAML_REPORTS_PER_TYPE", "ART_DB"); // Specify the view name
                entity.HasNoKey();

                entity.Property(e => e.ReportType)
                    .HasColumnName("REPORT_TYPE")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(255)
                    .IsRequired(false);

                entity.Property(e => e.NumberOfReports)
                    .HasColumnName("NUMBER_OF_REPORTS")
                    .HasColumnType("decimal(18, 2)") // Adjust precision and scale as needed
                    .IsRequired(false);

                entity.Property(e => e.Year)
               .HasColumnName("YEAR")
               .HasColumnType("int")
               .IsRequired(false);
            });
        }

        public void OnARTDGAMLModelCreating(ModelBuilder modelBuilder)
        {
            //DGAML
            modelBuilder.Entity<ArtDgAmlAlertDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_DGAML_ALERT_DETAIL_VIEW", "ART_DB");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .HasColumnName("ACTUAL_VALUES_TEXT");

                entity.Property(e => e.AlarmId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("alarm_id");

                entity.Property(e => e.AlertCategory)
                    .HasMaxLength(4000)
                    .HasColumnName("alert_category");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_DESCRIPTION");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("alert_status");

                entity.Property(e => e.AlertSubcategory)
                    .HasMaxLength(4000)
                    .HasColumnName("alert_subcategory");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(100)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("close_date");

                entity.Property(e => e.CloseReason)
                    .HasMaxLength(255)
                    .HasColumnName("close_reason");

                entity.Property(e => e.CloseUserName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("close_user_Name");

                entity.Property(e => e.ClosedUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Closed_USER_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.InvestigationDays).HasColumnName("Investigation_Days");

                entity.Property(e => e.MoneyLaunderingRiskScore).HasColumnName("MONEY_LAUNDERING_RISK_SCORE");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Run_Date");

                entity.Property(e => e.ScenarioId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("SCENARIO_ID");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .HasColumnName("SCENARIO_NAME");
            });

            modelBuilder.Entity<ArtDgAmlCustomerDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_DGAML_CUSTOMER_DETAIL_VIEW", "ART_DB");

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("City_name");

                entity.Property(e => e.CustomerDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("customer_date_of_birth");

                entity.Property(e => e.CustomerIdentificationId)
                    .HasMaxLength(35)
                    .HasColumnName("customer_identification_id");

                entity.Property(e => e.CustomerIdentificationType)
                    .HasMaxLength(20)
                    .HasColumnName("customer_identification_type");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(50)
                    .HasColumnName("customer_number");

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUSTOMER_SINCE_DATE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(20)
                    .HasColumnName("Customer_status");

                entity.Property(e => e.CustomerTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Customer_Tax_ID");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(20)
                    .HasColumnName("customer_type");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(35)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .HasColumnName("EMPLOYEE_NUMBER");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(35)
                    .HasColumnName("EMPLOYER_NAME");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                entity.Property(e => e.GovernorateName)
                    .HasMaxLength(35)
                    .HasColumnName("Governorate_name");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .HasColumnName("industry_desc");

                entity.Property(e => e.IsEmployee)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Is_EMPLOYEE")
                    .IsFixedLength();

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(35)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("MAILING_COUNTRY_NAME");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("MAILING_POSTAL_CODE");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("MARITAL_STATUS_DESC");

                entity.Property(e => e.NetWorthAmount)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("NET_WORTH_AMOUNT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("non_profit_org_ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(35)
                    .HasColumnName("occupation_desc");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(25)
                    .HasColumnName("PHONE_NUMBER_2");

                entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(25)
                    .HasColumnName("PHONE_NUMBER_3");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("politically_exposed_person_ind")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification).HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .HasColumnName("STREET_COUNTRY_CODE");

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("STREET_COUNTRY_NAME");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("STREET_POSTAL_CODE");
            });

            modelBuilder.Entity<ArtDgAmlTriageView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_DGAML_TRIAGE_VIEW", "ART_DB");

                entity.Property(e => e.AgeOldestAlert).HasColumnName("AGE_OLDEST_ALERT");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("AGGREGATE_AMT");

                entity.Property(e => e.AlertedEntityLevel)
                    .HasMaxLength(4000)
                    .HasColumnName("ALERTED_ENTITY_LEVEL");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(100)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.AlertsCntSum).HasColumnName("ALERTS_CNT_SUM");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(240)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(50)
                    .HasColumnName("QUEUE_CODE");

                entity.Property(e => e.RiskScore)
                    .HasMaxLength(32)
                    .HasColumnName("RISK_SCORE");
            });

            modelBuilder.Entity<ArtDgAmlCaseDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_DGAML_CASE_DETAIL_VIEW", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CaseCategory)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_CATEGORY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseCategoryCode)
                    .HasMaxLength(32)
                    .HasColumnName("CASE_CATEGORY_CODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CasePriority)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_PRIORITY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatusCode)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_STATUS_CODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseSubCategoryCode)
                    .HasMaxLength(32)
                    .HasColumnName("CASE_SUB_CATEGORY_CODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(60)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EntityLevel)
                    .HasMaxLength(1000)
                    .HasColumnName("ENTITY_LEVEL")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(200)
                    .HasColumnName("ENTITY_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EntityNumber)
                    .HasMaxLength(1000)
                    .HasColumnName("ENTITY_NUMBER")
                    .UseCollation("Arabic_100_CI_AI");
            });

            modelBuilder.Entity<ArtExternalCustomerDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_EXTERNAL_CUSTOMER_DETAIL_VIEW", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("City_name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("customer_date_of_birth");

                entity.Property(e => e.CustomerIdentificationId)
                    .HasMaxLength(35)
                    .HasColumnName("customer_identification_id");

                entity.Property(e => e.CustomerIdentificationType)
                    .HasMaxLength(4)
                    .HasColumnName("customer_identification_type");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(100)
                    .HasColumnName("customer_number");

                entity.Property(e => e.CustomerTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Customer_Tax_ID");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(50)
                    .HasColumnName("customer_type");

                entity.Property(e => e.GovernorateName)
                    .HasMaxLength(35)
                    .HasColumnName("Governorate_name");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(25)
                    .HasColumnName("PHONE_NUMBER_2");

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .HasColumnName("STREET_COUNTRY_CODE");

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("STREET_COUNTRY_NAME");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("STREET_POSTAL_CODE");
            });

            modelBuilder.Entity<ArtScenarioAdminView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SCENARIO_ADMIN_VIEW", "ART_DB");

                entity.Property(e => e.AlarmCategory)
                    .HasMaxLength(4000)
                    .HasColumnName("ALARM_CATEGORY");

                entity.Property(e => e.AlarmSubcategory)
                    .HasMaxLength(4000)
                    .HasColumnName("ALARM_SUBCATEGORY");

                entity.Property(e => e.AlarmType)
                    .HasMaxLength(4000)
                    .HasColumnName("ALARM_TYPE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.DependedData)
                    .HasMaxLength(1024)
                    .HasColumnName("DEPENDED_DATA");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.ObjectLevel)
                    .HasMaxLength(4000)
                    .HasColumnName("OBJECT_LEVEL");

                entity.Property(e => e.ParamCondition)
                    .HasMaxLength(1000)
                    .HasColumnName("PARAM_CONDITION");

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(255)
                    .HasColumnName("PARM_DESC");

                entity.Property(e => e.ParmName)
                    .HasMaxLength(32)
                    .HasColumnName("PARM_NAME");

                entity.Property(e => e.ParmTypeDesc)
                    .HasMaxLength(32)
                    .HasColumnName("PARM_TYPE_DESC");

                entity.Property(e => e.ParmValue)
                    .HasMaxLength(1024)
                    .HasColumnName("PARM_VALUE");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(4000)
                    .HasColumnName("PRODUCT_TYPE");

                entity.Property(e => e.RiskFact)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RISK_FACT")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioCategory)
                    .HasMaxLength(4000)
                    .HasColumnName("SCENARIO_CATEGORY");

                entity.Property(e => e.ScenarioDesc)
                    .HasMaxLength(255)
                    .HasColumnName("SCENARIO_DESC");

                entity.Property(e => e.ScenarioFrequency)
                    .HasMaxLength(4000)
                    .HasColumnName("SCENARIO_FREQUENCY");

                entity.Property(e => e.ScenarioMessage)
                    .HasMaxLength(255)
                    .HasColumnName("SCENARIO_MESSAGE");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(32)
                    .HasColumnName("SCENARIO_NAME");

                entity.Property(e => e.ScenarioShortDesc)
                    .HasMaxLength(100)
                    .HasColumnName("SCENARIO_SHORT_DESC");

                entity.Property(e => e.ScenarioStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("SCENARIO_STATUS");

                entity.Property(e => e.ScenarioType)
                    .HasMaxLength(4000)
                    .HasColumnName("SCENARIO_TYPE");

                entity.Property(e => e.ScorDependAttribute)
                    .HasMaxLength(300)
                    .HasColumnName("SCOR_DEPEND_ATTRIBUTE");

                entity.Property(e => e.ScorParmName)
                    .HasMaxLength(32)
                    .HasColumnName("SCOR_PARM_NAME");
            });

            modelBuilder.Entity<ArtScenarioHistoryView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SCENARIO_HISTORY_VIEW", "ART_DB");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Event_Desc");

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(32)
                    .HasColumnName("Routine_Name");

                entity.Property(e => e.RoutineShortDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Routine_Short_Desc");
            });

            modelBuilder.Entity<ArtSuspectDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SUSPECT_DETAIL_VIEW", "ART_DB");

                entity.Property(e => e.AgeOfOldestAlert).HasColumnName("AGE_OF_OLDEST_ALERT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Citizen_Cntry_Name");

                entity.Property(e => e.CustBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Birth_Date");

                entity.Property(e => e.CustIdentExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Ident_Exp_Date");

                entity.Property(e => e.CustIdentId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Ident_Id");

                entity.Property(e => e.CustIdentIssDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Ident_Iss_Date");

                entity.Property(e => e.CustIdentTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Ident_Type_Desc");

                entity.Property(e => e.CustSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Since_Date");

                entity.Property(e => e.EmprName)
                    .HasMaxLength(35)
                    .HasColumnName("Empr_Name");

                entity.Property(e => e.NumberOfAlarms).HasColumnName("NUMBER_OF_ALARMS");

                entity.Property(e => e.OccupDesc)
                    .HasMaxLength(35)
                    .HasColumnName("Occup_Desc");

                entity.Property(e => e.OwnerUserId)
                    .HasMaxLength(240)
                    .HasColumnName("OWNER_USER_ID");

                entity.Property(e => e.PoliticalExpPrsnInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Political_Exp_Prsn_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ProfileRisk)
                    .HasMaxLength(32)
                    .HasColumnName("PROFILE_RISK");

                entity.Property(e => e.RiskClassification).HasColumnName("risk_classification");

                entity.Property(e => e.SuspectName)
                    .HasMaxLength(100)
                    .HasColumnName("SUSPECT_NAME");

                entity.Property(e => e.SuspectNumber)
                    .HasMaxLength(50)
                    .HasColumnName("SUSPECT_NUMBER");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_1");
            });
            //DGAML HOME
            modelBuilder.Entity<ArtHomeDgamlAlertsPerDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_DGAML_ALERTS_PER_DATE", "ART_DB");

                entity.Property(e => e.Month).HasMaxLength(4000);

                entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_ALerts");
            });

            modelBuilder.Entity<ArtHomeDgamlAlertsPerStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_DGAML_ALERTS_PER_STATUS", "ART_DB");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("ALERT_STATUS");
                entity.Property(e => e.Year).HasColumnName("Year");
                entity.Property(e => e.AlertsCount).HasColumnName("Alerts_Count");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_DGAML_NUMBER_OF_ACCOUNTS", "ART_DB");

                entity.Property(e => e.NumberOfAccounts).HasColumnName("NUMBER_OF_ACCOUNTS");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_DGAML_NUMBER_OF_CUSTOMERS", "ART_DB");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("NUMBER_OF_CUSTOMERS");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfHighRiskCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_DGAML_NUMBER_OF_HIGH_RISK_CUSTOMERS", "ART_DB");

                entity.Property(e => e.NumberOfHighRiskCustomers).HasColumnName("NUMBER_OF_HIGH_RISK_CUSTOMERS");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfPepCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_DGAML_NUMBER_OF_PEP_CUSTOMERS", "ART_DB");

                entity.Property(e => e.NumberOfPepCustomers).HasColumnName("NUMBER_OF_PEP_CUSTOMERS");
            });
        }

        public void OnEcmModelCreating(ModelBuilder modelBuilder)
        {



            //ECM
            modelBuilder.Entity<ArtHomeCasesDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_DATE", "ART_DB");

                entity.Property(e => e.Day)
                    .HasColumnType("int")
                    .HasColumnName("DAY");

                entity.Property(e => e.Month)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("MONTH");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("decimal")
                    .HasColumnName("NUMBER_OF_CASES");

                entity.Property(e => e.Year)
                    .HasColumnType("int")
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<ArtHomeCasesStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_STATUS", "ART_DB");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");
            });

            modelBuilder.Entity<ArtHomeCasesType>(entity =>
            {

                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_TYPES", "ART_DB");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");
            });

            modelBuilder.Entity<ArtUserPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_USER_PERFORMANCE", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(256)
                    .HasColumnName("ACTION");

                entity.Property(e => e.ActionUser)
                    .HasMaxLength(60)
                    .HasColumnName("ACTION_USER");

                entity.Property(e => e.AsssignedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ASSSIGNED_TIME");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_DESC");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("CASE_TYPE_CD");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.DurationsInDays).HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours).HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes).HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds).HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Priority)
                    .HasMaxLength(4000)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.ReleasedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("RELEASED_DATE");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.ValidFromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VALID_FROM_DATE");
            });
            modelBuilder.Entity<ArtAlertedEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ALERTED_ENTITY");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Name)
                    .HasColumnType("CLOB")
                    .HasColumnName("NAME");

                entity.Property(e => e.PepInd)
                    .HasColumnType("CLOB")
                    .HasColumnName("PEP_IND");
            });

            modelBuilder.Entity<ArtSystemPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SYSTEM_PERFORMANCE", "ART_DB");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_DESC")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_TYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(4000)
                    .HasColumnName("CLIENT_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.DurationsInDays)
                    .HasColumnType("int")
                    .HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours)
                    .HasColumnType("int")
                    .HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes)
                    .HasColumnType("int")
                    .HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds)
                    .HasColumnType("int")
                    .HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.EcmLastStatusDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ECM_LAST_STATUS_DATE");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("HITS_COUNT")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.IdentityNum)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("IDENTITY_NUM")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("INVESTR_USER_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .HasColumnName("LOCKED_BY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Priority)
                    .HasMaxLength(4000)
                    .HasColumnName("PRIORITY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT_REFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.TransactionAmount).HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_DIRECTION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("UPDATE_USER_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ValidFromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VALID_FROM_DATE");
                entity.Property(e => e.LastComment)
                   .HasMaxLength(4000)
                   .IsUnicode(false)
                   .HasColumnName("LAST_COMMENT")
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.LastCommentSubject)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("last_comment_subject".ToUpper())
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");
                entity.Property(e => e.CreatedBy)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("CREATED_BY")
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.NumberOfComment)
                    .HasColumnType("int")
                    .HasColumnName("number_of_comments".ToUpper());
                entity.Property(e => e.NumberOfAttachments)
                    .HasColumnType("int")
                    .HasColumnName("number_of_attachments".ToUpper());
            });
            modelBuilder.Entity<ArtCFTConfig>(entity =>
            {
                entity.ToView("ART_CFT_CONFIG", "ART_DB");
                entity.HasNoKey();
                entity.Property(e => e.CaseId)
                 .HasColumnName("case_id")
                 .HasMaxLength(64)
                 .IsRequired();

                entity.Property(e => e.Maker)
                    .HasColumnName("Maker")
                    .HasMaxLength(60);

                entity.Property(e => e.MakerDate)
                    .HasColumnName("Maker_Date")
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Checker)
                    .HasColumnName("Checker")
                    .HasMaxLength(60);

                entity.Property(e => e.CheckerDate)
                    .HasColumnName("Checker_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckerAction)
                    .HasColumnName("Checker_Action")
                    .HasMaxLength(256);

                entity.Property(e => e.ActionDetail)
                    .HasColumnName("Action_Detail")
                    .HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<ArtClearDetect>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CLEAR_DETECT", "ART_DB");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("Case_Id")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUEST_DATE");

                entity.Property(e => e.RequestUid).HasColumnName("REQUEST_UID");

                entity.Property(e => e.SearchMatch)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SEARCH_MATCH");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_TYPE");
            });

            //only for MIDB
            #region ONLY For MIDB
            modelBuilder.Entity<MakerCheckerPerformanceView>(entity =>
            {
                entity.ToView("MAKER_CHECKER_PERFORMANCE_VIEW", "ART_DB");
                entity.HasNoKey();  // Use if the view does not have a primary key

                entity.Property(e => e.CaseId)
                    .HasColumnName("CASE_ID")
                    .HasMaxLength(128)
                    .IsRequired();
                entity.Property(e => e.CaseTypeCd)
                            .HasColumnName("CASE_TYPE_CD")
                            .HasMaxLength(64)
                            .IsRequired(false); // Ensure this matches your DB schema

                entity.Property(e => e.Program)
                    .HasColumnName("Program")
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.NewState)
                    .HasColumnName("NEW_STATE")
                    .HasMaxLength(512)
                    .IsRequired(false);

                entity.Property(e => e.CaseUser)
                    .HasColumnName("CASE_USER")
                    .HasMaxLength(120)
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasMaxLength(7)
                    .IsRequired(false);

                entity.Property(e => e.NewCaseStatus)
                    .HasColumnName("NEW_CASE_STATUS")
                    .HasMaxLength(8000)
                    .IsRequired(false);

                entity.Property(e => e.ReleasedDate)
                    .HasColumnName("RELEASED_DATE");
            });

            // Configure ArtSwiftMessagesView
            modelBuilder.Entity<ArtSwiftMessagesView>(entity =>
            {
                entity.ToView("ART_SWIFT_MESSAGES_VIEW_TB", "ART_DB");
                entity.HasNoKey();  // Use if the view does not have a primary key

                entity.Property(e => e.CaseId)
                    .HasColumnName("CASE_ID")
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("CREATE_USER_ID")
                    .HasMaxLength(120)
                    .IsRequired(false);

                entity.Property(e => e.CaseStatus)
                    .HasColumnName("CASE_STATUS")
                    .HasMaxLength(8000).IsRequired(false);

                entity.Property(e => e.Direction)
                    .HasColumnName("DIRECTION")
                    .HasMaxLength(6).IsRequired(false);

                entity.Property(e => e.SwiftMessage)
                    .HasColumnName("SWIFT_MESSAGE").IsRequired(false)
                   /* .HasMaxLength(8000)*/;  // Assuming -1 for nvarchar(MAX)

                entity.Property(e => e.IncidentsCount)
                    .HasColumnName("INCIDENTS_COUNT")
                    .HasMaxLength(8000).IsRequired(false);

                entity.Property(e => e.IncidentId)
                    .HasColumnName("Incident_ID").IsRequired(false)
                   /* .HasMaxLength(8000)*/;  // Assuming -1 for nvarchar(MAX)

                entity.Property(e => e.IncidentName)
                    .HasColumnName("Incident_Name").IsRequired(false)
                    /*.HasMaxLength(8000)*/;  // Assuming -1 for nvarchar(MAX)

                entity.Property(e => e.Sender)
                    .HasColumnName("Sender")
                    .HasMaxLength(8000).IsRequired(false);

                entity.Property(e => e.Receiver)
                    .HasColumnName("Receiver")
                    .HasMaxLength(8000).IsRequired(false);

                entity.Property(e => e.TransType)
                    .HasColumnName("Trans_Type")
                    .HasMaxLength(8000).IsRequired(false);

                entity.Property(e => e.TransAmount)
                    .HasColumnName("Trans_Amount")
                    .HasMaxLength(8000).IsRequired(false);

                entity.Property(e => e.Maker)
                    .HasColumnName("Maker")
                    .HasMaxLength(120).IsRequired(false);

                entity.Property(e => e.Checker)
                    .HasColumnName("Checker")
                    .HasMaxLength(120).IsRequired(false);
            });

            #endregion
        }

        public void OnSasAmlModelCreating(ModelBuilder modelBuilder)
        {
            //AML
            modelBuilder.Entity<ArtHomeAlertsPerDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_ALERTS_PER_DATE", "ART_DB");

                entity.Property(e => e.Month).HasMaxLength(4000);

                entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_ALerts");
            });

            modelBuilder.Entity<ArtHomeAlertsPerStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_ALERTS_PER_STATUS", "ART_DB");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertsCount).HasColumnName("Alerts_Count");
                entity.Property(e => e.Year).HasColumnName("Year");
            });

            modelBuilder.Entity<ArtHomeNumberOfAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_Number_Of_Accounts", "ART_DB");

                entity.Property(e => e.NumberOfAccounts).HasColumnName("Number_Of_Accounts");
            });

            modelBuilder.Entity<ArtHomeNumberOfCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_NUMBER_OF_CUSTOMERS", "ART_DB");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers");
            });

            modelBuilder.Entity<ArtHomeNumberOfHighRiskCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS", "ART_DB");

                entity.Property(e => e.NumberOfHighRiskCustomers).HasColumnName("Number_Of_High_Risk_Customers");
            });

            modelBuilder.Entity<ArtHomeNumberOfPepCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_NUMBER_OF_PEP_CUSTOMERS", "ART_DB");

                entity.Property(e => e.NumberOfPepCustomers).HasColumnName("Number_Of_PEP_Customers");
            });

            modelBuilder.Entity<ArtAmlAlertDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_ALERT_DETAIL_VIEW", "ART_DB");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .HasColumnName("ACTUAL_VALUES_TEXT");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_DESCRIPTION");

                entity.Property(e => e.AlertId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("ALERT_ID");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertSubCat)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_SUB_CAT");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_TYPE_CD");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(200)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.InvestigationDays).HasColumnName("INVESTIGATION_DAYS");

                entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("MONEY_LAUNDERING_RISK_SCORE");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.ReportCloseRsn)
                    .HasMaxLength(100)
                    .HasColumnName("REPORT_CLOSE_RSN");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("RUN_DATE");

                entity.Property(e => e.ScenarioId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("SCENARIO_ID");
                entity.Property(e => e.Queue)
                    .HasMaxLength(32)
                    .HasColumnName("QUEUE");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_NAME");
                entity.Property(e => e.CasesStatus)
                   .HasMaxLength(100)
                   .HasColumnName("CASE_STATUS");
            });

            modelBuilder.Entity<ArtAmlCaseDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_CASE_DETAILS_VIEW", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CaseCategory)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_CATEGORY");

                entity.Property(e => e.CaseId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CasePriority)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_PRIORITY");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseSubCategory)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_SUB_CATEGORY");

                entity.Property(e => e.ClosedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Closed_Date");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");
                entity.Property(e => e.AlertRunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ALERT_RUN_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.EntityLevel)
                    .HasMaxLength(100)
                    .HasColumnName("ENTITY_LEVEL");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(200)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.EntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NUMBER");

                entity.Property(e => e.Owner)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER");
            });

            modelBuilder.Entity<ArtAmlCustomersDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_CUSTOMERS_DETAILS_VIEW", "ART_DB");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLG")
                    .IsFixedLength();

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("City_name");

                entity.Property(e => e.CustomerDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("customer_date_of_birth");

                entity.Property(e => e.CustomerIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("customer_identification_id");

                entity.Property(e => e.CustomerIdentificationType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_identification_type");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_number");

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUSTOMER_SINCE_DATE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_status");

                entity.Property(e => e.CustomerTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Tax_ID");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_type");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NUMBER");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_NAME");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                entity.Property(e => e.GovernorateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Governorate_name");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("industry_desc");

                entity.Property(e => e.IsEmployee)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Is_EMPLOYEE")
                    .IsFixedLength();

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_COUNTRY_NAME");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_POSTAL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS_DESC");

                entity.Property(e => e.NetWorthAmount)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("NET_WORTH_AMOUNT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("non_profit_org_ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("occupation_desc");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_2");

                entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_3");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("politically_exposed_person_ind")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_NAME");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STREET_POSTAL_CODE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtAmlHighRiskCustView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_HIGH_RISK_CUST_VIEW", "ART_DB");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("PARTY_DATE_OF_BIRTH");

                entity.Property(e => e.PartyIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_ID");

                entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_TYPE_DESC");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TAX_ID");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_CITY_NAME");
            });

            modelBuilder.Entity<ArtRiskAssessmentView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_RISK_ASSESSMENT_VIEW", "ART_DB");

                entity.Property(e => e.AssessmentCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_CATEGORY_CD");

                entity.Property(e => e.AssessmentSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_SUBCATEGORY_CD");

                entity.Property(e => e.AssessmentTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_TYPE_CD");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.OwnerUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USER_LONG_ID");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.ProposedRiskClass)
                    .HasMaxLength(100)
                    .HasColumnName("PROPOSED_RISK_CLASS");

                entity.Property(e => e.RiskAssessmentDuration)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("RISK_ASSESSMENT_DURATION");

                entity.Property(e => e.RiskAssessmentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("RISK_ASSESSMENT_ID");

                entity.Property(e => e.RiskClass)
                    .HasMaxLength(100)
                    .HasColumnName("RISK_CLASS");

                entity.Property(e => e.RiskStatus)
                    .HasMaxLength(100)
                    .HasColumnName("RISK_STATUS");

                entity.Property(e => e.VersionNumber)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("VERSION_NUMBER");
            });

            modelBuilder.Entity<ArtAmlTriageView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_TRIAGE_VIEW", "ART_DB");

                entity.Property(e => e.AgeOldestAlert)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("AGE_OLDEST_ALERT");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("AGGREGATE_AMT");

                entity.Property(e => e.AlertedEntityLevel)
                    .HasMaxLength(100)
                    .HasColumnName("ALERTED_ENTITY_LEVEL");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(200)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.AlertsCnt)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.RiskScore)
                    .HasMaxLength(100)
                    .HasColumnName("RISK_SCORE");
            });

            modelBuilder.Entity<BigData>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BIG_DATA", "ART_DB");
                entity.Property(e => e.EntityWatchListKey)
                .IsRequired()
                .HasColumnName("entity_watch_list_key");

                entity.Property(e => e.EntityWatchListNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("entity_watch_list_number");

                entity.Property(e => e.WatchListName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("watch_list_name");

                entity.Property(e => e.CategoryDesc)
                    .HasMaxLength(2000)
                    .HasColumnName("category_desc"); // Nullable

                entity.Property(e => e.TypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("type_desc"); // Nullable

                entity.Property(e => e.FirstName)
                    .HasMaxLength(350)
                    .HasColumnName("first_name"); // Nullable

                entity.Property(e => e.LastName)
                    .HasMaxLength(350)
                    .HasColumnName("last_name"); // Nullable

                entity.Property(e => e.EntityName)
                    .HasMaxLength(800)
                    .HasColumnName("entity_name"); // Nullable

                entity.Property(e => e.EntityTitle)
                    .HasMaxLength(1000)
                    .HasColumnName("entity_title"); // Nullable

                entity.Property(e => e.OccupationDesc)
                    .HasColumnName("occupation_desc"); // Nullable

                entity.Property(e => e.CityName)
                    .HasMaxLength(4000)
                    .HasColumnName("city_name"); // Nullable

                entity.Property(e => e.StateName)
                    .HasMaxLength(4000)
                    .HasColumnName("state_name"); // Nullable

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(1000)
                    .HasColumnName("country_code"); // Nullable

                entity.Property(e => e.CountryName)
                    .HasMaxLength(4000)
                    .HasColumnName("country_name"); // Nullable

                entity.Property(e => e.FullAddress)
                    .HasColumnName("full_address"); // Nullable

                entity.Property(e => e.NationalityCountryCode)
                    .HasMaxLength(1000)
                    .HasColumnName("nationality_country_code"); // Nullable

                entity.Property(e => e.NationalityCountryName)
                    .HasMaxLength(4000)
                    .HasColumnName("nationality_country_name"); // Nullable

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasColumnName("politically_exposed_person_ind"); // Nullable

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date"); // Nullable

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("update_date"); // Nullable

                entity.Property(e => e.ExcludeInd)
                    .HasMaxLength(1)
                    .HasColumnName("exclude_ind"); // Nullable

                entity.Property(e => e.ChangeBeginDate)
                    .IsRequired()
                    .HasColumnName("change_begin_date");

                entity.Property(e => e.ChangeEndDate)
                    .IsRequired()
                    .HasColumnName("change_end_date");

                entity.Property(e => e.ChangeCurrentInd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("change_current_ind");
            });

        }

        public void OnAuditModelCreating(ModelBuilder modelBuilder)
        {
            //Aduit
            modelBuilder.Entity<ArtGroupsAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GROUPS_AUDIT_VIEW", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.MemberUsers).HasColumnName("member_users");

                entity.Property(e => e.RoleNames).HasColumnName("role_names");

                entity.Property(e => e.SubGroupNames).HasColumnName("sub_group_names");
            });
            modelBuilder.Entity<ArtRolesAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ROLES_AUDIT_VIEW", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupNames).HasColumnName("group_names");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.MemberUsers).HasColumnName("member_users");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });
            modelBuilder.Entity<ArtUsersAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_USERS_AUDIT_VIEW", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.DomainAccounts).HasColumnName("domain_accounts");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.GroupNames).HasColumnName("group_names");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleNames).HasColumnName("role_names");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");
            });
            modelBuilder.Entity<LastLoginPerDayView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LAST_LOGIN_PER_DAY_VIEW", "ART_DB");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_TYPE");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Logindatetime)
                .HasColumnType("datetime")
                .HasColumnName("LOGINDATETIME");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });
            modelBuilder.Entity<ListGroupsRolesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_GROUPS_ROLES_SUMMARY", "ART_DB");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });
            modelBuilder.Entity<ListGroupsSubGroupsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_GROUPS_SUB_GROUPS_SUMMARY", "ART_DB");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.SubGroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUB_GROUP_NAME");
            });
            modelBuilder.Entity<ListOfDeletedUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_DELTED_USERS", "ART_DB");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });
            modelBuilder.Entity<ListOfGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_GROUPS", "ART_DB");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");
            });
            modelBuilder.Entity<ListOfRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_ROLES", "ART_DB");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_type");
            });
            modelBuilder.Entity<ListOfUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS", "ART_DB");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock).HasColumnName("counter_lock");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });
            modelBuilder.Entity<ListOfUsersAndGroupsRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_AND_GROUPS_ROLES", "ART_DB");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.RoleOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date".ToUpper());
                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date".ToUpper());

                entity.Property(e => e.AccountStatus).HasColumnName("ACCOUNT_STATUS");
            });
            modelBuilder.Entity<ListOfUsersGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_GROUPS", "ART_DB");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });
            modelBuilder.Entity<ListOfUsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_ROLES", "ART_DB");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_ROLE");
            });
        }

        public void OnAmlAnalysisModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FskAlert>(entity =>
            {
                entity.HasKey(e => e.AlertId)
                    .HasName("PK_ALERT");

                entity.ToTable("FSK_ALERT", "FCFKC");

                entity.HasIndex(e => e.ScenarioId, "IDX_ALERT_SCENARIO");

                entity.HasIndex(e => e.QueueCode, "XEIQFSK_ALERT");

                entity.HasIndex(e => e.PrimaryEntityKey, "XIE5FSK_ALERT");

                entity.HasIndex(e => e.PrimaryEntityName, "XIE6FSK_ALERT");

                entity.HasIndex(e => e.PrimaryEntityNumber, "XIE9FSK_ALERT");

                entity.Property(e => e.AlertId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("alert_id");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .HasColumnName("actual_values_text");

                entity.Property(e => e.AlertCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("alert_category_cd");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .HasColumnName("alert_description");

                entity.Property(e => e.AlertStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("alert_status_code")
                    .IsFixedLength();

                entity.Property(e => e.AlertSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("alert_subcategory_cd");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("alert_type_cd");

                entity.Property(e => e.AlertedEntityKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("alerted_entity_key");

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("alerted_entity_level_code")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(200)
                    .HasColumnName("alerted_entity_name");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alerted_entity_number");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind")
                    .IsFixedLength();

                entity.Property(e => e.EntitySegmentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("entity_segment_id");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("logical_delete_ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("money_laundering_risk_score");

                entity.Property(e => e.PrimaryEntityKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("primary_entity_key");

                entity.Property(e => e.PrimaryEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("primary_entity_level_code")
                    .IsFixedLength();

                entity.Property(e => e.PrimaryEntityName)
                    .HasMaxLength(200)
                    .HasColumnName("primary_entity_name");

                entity.Property(e => e.PrimaryEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primary_entity_number");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("product_type")
                    .IsFixedLength();

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("queue_code");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("run_date");

                entity.Property(e => e.ScenarioId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("scenario_id");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("scenario_name");

                entity.Property(e => e.SuppressionEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("suppression_end_date");

                entity.Property(e => e.TerrorFinancingRiskScore)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("terror_financing_risk_score");

                entity.Property(e => e.VersionNumber)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("version_number");
            });
            modelBuilder.Entity<FskAlertEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK_ALERT_EVENT");

                entity.ToTable("FSK_ALERT_EVENT", "FCFKC");

                entity.HasIndex(e => e.AlertId, "IDX_ALERT_EVENT_ALERT");

                entity.HasIndex(e => new { e.CreateDate, e.EventTypeCode, e.AlertId }, "XIE1FSK_ALERT_EVENT");

                entity.Property(e => e.EventId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("event_id");

                entity.Property(e => e.AlertId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("alert_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(255)
                    .HasColumnName("event_description");

                entity.Property(e => e.EventTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("event_type_code")
                    .IsFixedLength();

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.FskAlertEvents)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_EVENT_ALERT");
            });
            modelBuilder.Entity<FskAlertedEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FSK_ALERTED_ENTITY", "FCFKC");

                entity.HasIndex(e => new { e.AlertedEntityNumber, e.AlertedEntityLevelCode }, "XAK1FSK_ALERTED_ENTITY")
                    .IsUnique();

                entity.Property(e => e.AgeOldestAlert)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("age_oldest_alert");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("aggregate_amt");

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("alerted_entity_level_code")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(200)
                    .HasColumnName("alerted_entity_name");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alerted_entity_number");

                entity.Property(e => e.AlertedEntitySegmentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("alerted_entity_segment_id");

                entity.Property(e => e.AlertsCnt)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("alerts_cnt");

                entity.Property(e => e.CreatedTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("created_timestamp");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind")
                    .IsFixedLength();

                entity.Property(e => e.LockTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("lock_timestamp");

                entity.Property(e => e.LockUserid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("lock_userid");

                entity.Property(e => e.LstupdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lstupdate_date");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("lstupdate_user_id");

                entity.Property(e => e.MoneyLaunderingScore)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("money_laundering_score");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("politically_exposed_person_ind")
                    .IsFixedLength();

                entity.Property(e => e.RiskScoreCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("risk_Score_code");

                entity.Property(e => e.TransactionsCnt)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("transactions_cnt");
            });
            modelBuilder.Entity<FskComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("XPKFSK_COMMENT");

                entity.ToTable("FSK_COMMENT", "FCFKC");

                entity.HasIndex(e => new { e.ObjectTypeCd, e.ObjectId }, "XIE1FSK_COMMENT");

                entity.Property(e => e.CommentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("comment_id");

                entity.Property(e => e.CommentCategoryCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("comment_category_cd")
                    .IsFixedLength();

                entity.Property(e => e.CommentText)
                    .HasMaxLength(4000)
                    .HasColumnName("comment_text");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("logical_delete_ind")
                    .IsFixedLength();

                entity.Property(e => e.LstupdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lstupdate_date");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("lstupdate_user_id");

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("object_id");

                entity.Property(e => e.ObjectTypeCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("object_type_cd")
                    .IsFixedLength();
            });
            modelBuilder.Entity<FskEntityEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("XPKFSK_ENTITY_EVENT");

                entity.ToTable("FSK_ENTITY_EVENT", "FCFKC");

                entity.HasIndex(e => e.CaseId, "XIE1FSK_ENTITY_EVENT");

                entity.Property(e => e.EventId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("event_id");

                entity.Property(e => e.CaseId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("case_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.EntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("entity_level_code")
                    .IsFixedLength();

                entity.Property(e => e.EntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("entity_number");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(255)
                    .HasColumnName("event_description");

                entity.Property(e => e.EventTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("event_type_code")
                    .IsFixedLength();
            });
            modelBuilder.Entity<FskEntityQueue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FSK_ENTITY_QUEUE", "FCFKC");

                entity.HasIndex(e => new { e.AlertedEntityLevelCode, e.AlertedEntityNumber, e.QueueCode, e.OwnerUserid }, "XEI1FSK_ENTITY_QUEUE");

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("alerted_entity_level_code")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alerted_entity_number");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("owner_userid");

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("queue_code");
            });
            modelBuilder.HasSequence("party_key").StartsAt(3);

        }

        public void OnFcfkcSASAMLModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FskRiskAssessment>(entity =>
            {
                entity.HasKey(e => e.RiskAssessmentId)
                    .HasName("PK_RISK_ASMNT");

                entity.ToTable("FSK_RISK_ASSESSMENT", "FCFKC");

                entity.HasIndex(e => e.PartyKey, "XIE5FSK_RISK_ASMNT");

                entity.HasIndex(e => e.PartyNumber, "XIE9FSK_RISK_ASMNT");

                entity.Property(e => e.RiskAssessmentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("risk_assessment_id");

                entity.Property(e => e.AssessmentCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("assessment_category_cd");

                entity.Property(e => e.AssessmentSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("assessment_subcategory_cd");

                entity.Property(e => e.AssessmentTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("assessment_type_cd");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind")
                    .IsFixedLength();

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("logical_delete_ind")
                    .IsFixedLength();

                entity.Property(e => e.OwnerUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("owner_user_long_id");

                entity.Property(e => e.PartyKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("party_key");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .HasColumnName("party_name");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("party_number");

                entity.Property(e => e.ProposedRiskClassification)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("proposed_risk_classification");

                entity.Property(e => e.RiskAssessmentDuration)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("risk_assessment_duration");

                entity.Property(e => e.RiskAssessmentStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("risk_assessment_status_code")
                    .IsFixedLength();

                entity.Property(e => e.RiskClassification)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("risk_classification");

                entity.Property(e => e.StartingMonthKey)
                    .HasColumnType("decimal(6, 0)")
                    .HasColumnName("starting_month_key");

                entity.Property(e => e.VersionNumber)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("version_number");
            });
            modelBuilder.Entity<FskLov>(entity =>
            {
                entity.HasKey(e => new { e.LovTypeName, e.LovTypeCode, e.LovLanguageDesc })
                    .HasName("PK_LOV");

                entity.ToTable("FSK_LOV", "FCFKC");

                entity.Property(e => e.LovTypeName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("lov_type_name");

                entity.Property(e => e.LovTypeCode)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("lov_type_code");

                entity.Property(e => e.LovLanguageDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lov_language_desc");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active_flg")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength();

                entity.Property(e => e.LovSortPositionNumber).HasColumnName("lov_sort_position_number");

                entity.Property(e => e.LovTypeDesc)
                    .HasMaxLength(100)
                    .HasColumnName("lov_type_desc");
            });
            modelBuilder.Entity<FskScenario>(entity =>
            {
                entity.HasKey(e => e.ScenarioId)
                    .HasName("PK_SCENARIO");

                entity.ToTable("FSK_SCENARIO", "FCFKC");

                entity.HasIndex(e => e.HeaderId, "IDX_SCENARIO_HEADER");

                entity.HasIndex(e => e.RoutingGroupId, "XIF2FSK_SCENARIO");

                entity.Property(e => e.ScenarioId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("scenario_id");

                entity.Property(e => e.AlertCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("alert_category_cd");

                entity.Property(e => e.AlertSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("alert_subcategory_cd");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("alert_type_cd");

                entity.Property(e => e.BtlEnabledInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("btl_enabled_ind")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.CurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("current_ind")
                    .IsFixedLength();

                entity.Property(e => e.DfltSuppressDurationCount)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("dflt_suppress_duration_count");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date")
                    .HasDefaultValueSql("('5999-01-01T00:00:00')");

                entity.Property(e => e.EndUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("end_user_id");

                entity.Property(e => e.EntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("entity_level_code")
                    .IsFixedLength();

                entity.Property(e => e.ExecutionProbabilityRate)
                    .HasColumnType("decimal(7, 7)")
                    .HasColumnName("execution_probability_rate");

                entity.Property(e => e.HeaderId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("header_id");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("logical_delete_ind")
                    .IsFixedLength();

                entity.Property(e => e.LstupdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lstupdate_date");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("lstupdate_user_id");

                entity.Property(e => e.MoneyLaunderingBayesWeight)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("money_laundering_bayes_weight");

                entity.Property(e => e.OrderInHeader)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("order_in_header");

                entity.Property(e => e.PrimaryEntityNumberVarName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("primary_entity_number_var_name");

                entity.Property(e => e.ProductTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("product_type_code")
                    .IsFixedLength();

                entity.Property(e => e.RiskFactorInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("risk_factor_ind")
                    .IsFixedLength();

                entity.Property(e => e.RootKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("root_key");

                entity.Property(e => e.RoutingGroupId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("routing_group_id");

                entity.Property(e => e.RoutingUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("routing_user_long_id");

                entity.Property(e => e.SaveTrigTransInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("save_trig_trans_ind")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioCategoryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("scenario_category_code")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioCodeLocationDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("scenario_code_location_desc");

                entity.Property(e => e.ScenarioDescription)
                    .HasMaxLength(255)
                    .HasColumnName("scenario_description");

                entity.Property(e => e.ScenarioDurationCount)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("scenario_duration_count");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("scenario_name");

                entity.Property(e => e.ScenarioRunFrequencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("scenario_run_frequency_code")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioShortDescription)
                    .HasMaxLength(100)
                    .HasColumnName("scenario_short_description");

                entity.Property(e => e.ScenarioStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("scenario_status_code")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("scenario_type_code")
                    .IsFixedLength();

                entity.Property(e => e.SegmentsEnabledInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("segments_enabled_ind")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.SkipIfNoTransCurrDayInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("skip_if_no_trans_curr_day_ind")
                    .IsFixedLength();

                entity.Property(e => e.TerrorFinancingBayesWeight)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("terror_financing_bayes_weight");

                entity.Property(e => e.VersionNumber)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("version_number");

                entity.Property(e => e.VsdDeploymentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vsd_deployment_name");

                entity.Property(e => e.VsdWindowName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("vsd_window_name");
            });
            modelBuilder.Entity<FskCase>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("XPKFSK_CASE");

                entity.ToTable("FSK_CASE", "FCFKC");

                entity.HasIndex(e => e.QueueCode, "XEIQFSK_CASE");

                entity.Property(e => e.CaseId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("case_id");

                entity.Property(e => e.ActivateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACTIVATE_DATE");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("aggregate_amt");

                entity.Property(e => e.CaseCategoryCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("case_category_code");

                entity.Property(e => e.CaseCloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("case_close_date");

                entity.Property(e => e.CaseCloseReasonCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("case_close_reason_code");

                entity.Property(e => e.CaseDescription)
                    .HasMaxLength(100)
                    .HasColumnName("case_description");

                entity.Property(e => e.CasePriorityCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("case_priority_code");

                entity.Property(e => e.CaseStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("case_status_code");

                entity.Property(e => e.CaseSubCategoryCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("case_sub_category_code");

                entity.Property(e => e.CaseSummary)
                    .HasMaxLength(4000)
                    .HasColumnName("case_summary");

                entity.Property(e => e.CaseTypeCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("case_type_code");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind")
                    .IsFixedLength();

                entity.Property(e => e.FirstTransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("first_transaction_date");

                entity.Property(e => e.LastTransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_transaction_date");

                entity.Property(e => e.LeContactAgency)
                    .HasMaxLength(150)
                    .HasColumnName("le_contact_agency");

                entity.Property(e => e.LeContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("le_contact_date");

                entity.Property(e => e.LeContactName)
                    .HasMaxLength(150)
                    .HasColumnName("le_contact_name");

                entity.Property(e => e.LeContactPhone)
                    .HasMaxLength(16)
                    .HasColumnName("le_contact_phone");

                entity.Property(e => e.LeContactPhoneExt)
                    .HasMaxLength(16)
                    .HasColumnName("le_contact_phone_ext");

                entity.Property(e => e.LeContactedInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("le_contacted_ind")
                    .IsFixedLength();

                entity.Property(e => e.LockTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("lock_timestamp");

                entity.Property(e => e.LockUserid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("lock_userid");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("logical_delete_ind")
                    .IsFixedLength();

                entity.Property(e => e.LstupdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lstupdate_date");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("lstupdate_user_id");

                entity.Property(e => e.ModifiedInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("modified_ind")
                    .IsFixedLength();

                entity.Property(e => e.OpenedInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("opened_ind")
                    .IsFixedLength();

                entity.Property(e => e.OwnerUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("owner_user_long_id");

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("queue_code");

                entity.Property(e => e.VersionNumber)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("version_number");
            });
            modelBuilder.Entity<FskQueue>(entity =>
            {
                entity.ToTable("FSK_QUEUE", "FCFKC");
                // Set primary key
                entity.HasKey(e => e.QueueKey);

                // Set column names for properties
                entity.Property(e => e.QueueKey)
                    .IsRequired()
                    .HasColumnName("queue_key"); // maps to "queue_key"

                entity.Property(e => e.QueueCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("queue_code"); // maps to "queue_code"

                entity.Property(e => e.QueueDescription)
                    .HasMaxLength(100)
                    .HasColumnName("queue_description"); // maps to "queue_description"

                entity.Property(e => e.AccessRoleName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("access_role_name"); // maps to "access_role_name"

                entity.Property(e => e.LastUpdateUser)
                    .HasMaxLength(60)
                    .HasColumnName("lstupdate_user"); // maps to "lstupdate_user"

                entity.Property(e => e.LogicalDeleteIndicator)
                    .HasMaxLength(1)
                    .HasColumnName("logical_delete_ind"); // maps to "logical_delete_ind"

                entity.Property(e => e.ActiveIndicator)
                    .HasMaxLength(1)
                    .HasColumnName("active_ind"); // maps to "active_ind"

                entity.Property(e => e.ChangeBeginDate)
                    .IsRequired()
                    .HasColumnName("change_begin_date"); // maps to "change_begin_date"

                entity.Property(e => e.ChangeEndDate)
                    .IsRequired()
                    .HasColumnName("change_end_date"); // maps to "change_end_date"

                entity.Property(e => e.ChangeCurrentIndicator)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("change_current_ind"); // maps to "change_current_ind"

            });
        }

        public void OnFTIModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnKYCModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnDGECMModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseLive>(entity =>
            {
                entity.HasKey(e => e.CaseRk)
                    .HasName("Case_Pk");

                entity.ToTable("Case_Live", "DGCmgmt");

                entity.HasIndex(e => e.CaseDesc, "IX_Case_Desc");

                entity.HasIndex(e => e.CaseStatCd, "IX_Case_Live_Case_Stat_Cd");

                entity.HasIndex(e => e.CaseStatCd, "IX_Case_Stat_Cd");

                entity.HasIndex(e => e.ValidFromDate, "IX_Valid_From_Date");

                entity.HasIndex(e => e.ValidToDate, "IX_Valid_To_Date");

                entity.Property(e => e.CaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Case_Rk");

                entity.Property(e => e.Amenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("AMENDDATE");

                entity.Property(e => e.AnyBicFieldBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("anyBicFieldBic");

                entity.Property(e => e.ApplicantId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("applicantId");

                entity.Property(e => e.ApplicantName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("applicantName");

                entity.Property(e => e.ApplicantRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("applicantRef");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("applicationDate");

                entity.Property(e => e.BehalfOfBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("behalfOfBranch");

                entity.Property(e => e.BeneficiaryAccountNum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryAccountNum");

                entity.Property(e => e.BeneficiaryBirthYear)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryBirthYear");

                entity.Property(e => e.BeneficiaryCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryCountry");

                entity.Property(e => e.BeneficiaryIdentity)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryIdentity");

                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryName");

                entity.Property(e => e.BeneficiaryNationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryNationality");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("birthPlace");

                entity.Property(e => e.CaseCtgryCd)
                    .HasMaxLength(32)
                    .HasColumnName("Case_Ctgry_Cd");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Desc");

                entity.Property(e => e.CaseDisposCd)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Dispos_Cd");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("Case_Id");

                entity.Property(e => e.CaseLinkSk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Case_Link_Sk");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Stat_Cd");

                entity.Property(e => e.CaseSubCtgryCd)
                    .HasMaxLength(32)
                    .HasColumnName("Case_Sub_Ctgry_Cd");

                entity.Property(e => e.CaseTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("Case_Type_Cd");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Close_Date");

                entity.Property(e => e.Col1)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col2)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col3)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col4)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col5)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.CreditorAgentBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("creditorAgentBankBic");

                entity.Property(e => e.CustFullName)
                    .HasMaxLength(200)
                    .HasColumnName("Cust_Full_Name");

                entity.Property(e => e.CustomerActivityCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_activity_country");

                entity.Property(e => e.CustomerCreatedBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_created_branch");

                entity.Property(e => e.CustomerCreatedUser)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_created_user");

                entity.Property(e => e.CustomerResidency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_residency");

                entity.Property(e => e.DebtorAgentBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("debtorAgentBankBic");

                entity.Property(e => e.DeleteFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Delete_Flag")
                    .IsFixedLength();

                entity.Property(e => e.DocumentReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EcmWorkflow)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Ecm_Workflow");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EventName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("eventName");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("eventRef");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("hits_count");

                entity.Property(e => e.InputName)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("inputName");

                entity.Property(e => e.IntermediaryCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("intermediaryCode");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Investr_User_Id");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issueDate");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("masterRef");

                entity.Property(e => e.MaxSensitivityRank).HasColumnName("maxSensitivityRank");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("nationality");

                entity.Property(e => e.OpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Open_Date");

                entity.Property(e => e.OthNationality)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ParentCaseId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("parentCaseId");

                entity.Property(e => e.ParentCaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("parentCaseRk");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("partyTypeDesc");

                entity.Property(e => e.PayDestinationCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("payDestinationCountry");

                entity.Property(e => e.PayOriginCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("payOriginCountry");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("primary_owner");

                entity.Property(e => e.PriorityCd)
                    .HasMaxLength(32)
                    .HasColumnName("Priority_Cd");

                entity.Property(e => e.Product)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("product");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("productType");

                entity.Property(e => e.ReceiverBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("receiverBankBic");

                entity.Property(e => e.ReceiverBic)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("receiverBic");

                entity.Property(e => e.ReceiverCtry)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("receiverCtry");

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReguRptRqdFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Regu_Rpt_Rqd_Flag")
                    .IsFixedLength();

                entity.Property(e => e.RemitterAccountNum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remitterAccountNum");

                entity.Property(e => e.RemitterBirthYear)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("remitterBirthYear");

                entity.Property(e => e.RemitterCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("remitterCountry");

                entity.Property(e => e.RemitterIdentity)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("remitterIdentity");

                entity.Property(e => e.RemitterNationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remitterNationality");

                entity.Property(e => e.ReopenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REOpen_Date");

                entity.Property(e => e.SearchCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("searchCountry");

                entity.Property(e => e.SearchUnit)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("searchUnit");

                entity.Property(e => e.SearchUser)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("searchUser");

                entity.Property(e => e.SenderBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("senderBankBic");

                entity.Property(e => e.SenderBic)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("senderBic");

                entity.Property(e => e.SenderCtry)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("senderCtry");

                entity.Property(e => e.SenderReceiverAgentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senderReceiverAgentCode");

                entity.Property(e => e.SrcSysCd)
                    .HasMaxLength(32)
                    .HasColumnName("Src_Sys_Cd");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("swift_reference");

                entity.Property(e => e.TransactionAmount).HasColumnName("transaction_amount");

                entity.Property(e => e.TransactionBeneficiary)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("transaction_beneficiary");

                entity.Property(e => e.TransactionBenificiary)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_benificiary");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_currency");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_direction");

                entity.Property(e => e.TransactionReference)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("transaction_reference");

                entity.Property(e => e.TransactionRemitter)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_remitter");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_type");

                entity.Property(e => e.UiDefFileName)
                    .HasMaxLength(100)
                    .HasColumnName("UI_Def_File_Name");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Update_User_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.ValidFromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid_From_Date");

                entity.Property(e => e.ValidToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid_To_Date");

                entity.Property(e => e.VerNo)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Ver_No");

                entity.Property(e => e.WasPending)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("wasPending");

                entity.Property(e => e.WlCategory)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("WL_CATEGORY");

                entity.Property(e => e.XIdentity)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("X_IDENTITY");
            });

            modelBuilder.Entity<RefTableVal>(entity =>
            {
                entity.HasKey(e => new { e.RefTableName, e.ValCd })
                    .HasName("Ref_Table_Val_Pk");

                entity.ToTable("Ref_Table_Val", "DGCmgmt");

                entity.Property(e => e.RefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Ref_Table_Name");

                entity.Property(e => e.ValCd)
                    .HasMaxLength(100)
                    .HasColumnName("Val_Cd");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Active_Flg")
                    .IsFixedLength();

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DisplayOrdrNo)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Display_Ordr_No");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("module_Name");

                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Parent_Ref_Table_Name");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(100)
                    .HasColumnName("Parent_Val_Cd");

                entity.Property(e => e.ValDesc)
                    .HasMaxLength(4000)
                    .HasColumnName("Val_Desc");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => new { d.ParentRefTableName, d.ParentValCd })
                    .HasConstraintName("REF_TABLE_VAL_FK1");
            });
        }
        public void OnDGFATCAModelCreating(ModelBuilder modelBuilder)
        {


        }



        public void OnDgAMLModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcLkpTable>(entity =>
            {
                entity.HasKey(e => new { e.LkpName, e.LkpValCd, e.LkpLangDesc })
                    .HasName("AC_LKP_Table_PK2");

                entity.ToTable("AC_LKP_Table", "AC");

                entity.Property(e => e.LkpName)
                    .HasMaxLength(50)
                    .HasColumnName("LKP_Name");

                entity.Property(e => e.LkpValCd)
                    .HasMaxLength(100)
                    .HasColumnName("LKP_Val_Cd");

                entity.Property(e => e.LkpLangDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LKP_Lang_Desc");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Active_Flg")
                    .IsFixedLength();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DELETED")
                    .IsFixedLength();

                entity.Property(e => e.DisplayOrdrNo)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Display_Ordr_No");

                entity.Property(e => e.LkpLangDescParent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LKP_Lang_Desc_parent");

                entity.Property(e => e.LkpNameParent)
                    .HasMaxLength(50)
                    .HasColumnName("LKP_Name_parent");

                entity.Property(e => e.LkpValCdParent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LKP_Val_Cd_parent");

                entity.Property(e => e.LkpValDesc)
                    .HasMaxLength(4000)
                    .HasColumnName("LKP_Val_Desc");
            });
            modelBuilder.Entity<AcRoutine>(entity =>
            {
                entity.HasKey(e => e.RoutineId);

                entity.ToTable("AC_Routine", "AC");

                entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(12, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Routine_Id");

                entity.Property(e => e.AdminStatusCd)
                    .HasMaxLength(25)
                    .HasColumnName("admin_status_cd");

                entity.Property(e => e.AlarmCategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Categ_Cd");

                entity.Property(e => e.AlarmSubcategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Subcateg_Cd");

                entity.Property(e => e.AlarmTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Type_Cd");

                entity.Property(e => e.ComparedDateAttribute)
                    .HasMaxLength(255)
                    .HasColumnName("Compared_Date_Attribute");

                entity.Property(e => e.CorrespondingViewNm)
                    .HasMaxLength(1024)
                    .HasColumnName("corresponding_view_NM");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.CurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Current_Ind")
                    .IsFixedLength();

                entity.Property(e => e.DfltSupprDurCount).HasColumnName("Dflt_Suppr_Dur_Count");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.EndUserId)
                    .HasMaxLength(60)
                    .HasColumnName("End_User_Id");

                entity.Property(e => e.ExecProbRate)
                    .HasColumnType("numeric(7, 7)")
                    .HasColumnName("Exec_Prob_Rate");

                entity.Property(e => e.HeaderId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("header_id");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Update_Date");

                entity.Property(e => e.LastUpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Last_Update_User_Id");

                entity.Property(e => e.LogicDelInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Logic_Del_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MlBayesWeight)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("ML_Bayes_Weight");

                entity.Property(e => e.ObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Obj_Level_Cd");

                entity.Property(e => e.OrderInHeader).HasColumnName("Order_In_Header");

                entity.Property(e => e.PrimObjNoVarName)
                    .HasMaxLength(32)
                    .HasColumnName("Prim_Obj_No_Var_Name");

                entity.Property(e => e.ProdTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type_Cd");

                entity.Property(e => e.RiskFactInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Risk_Fact_Ind")
                    .IsFixedLength();

                entity.Property(e => e.RootKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("root_key");

                entity.Property(e => e.RouteGrpId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Route_Grp_Id");

                entity.Property(e => e.RouteUserLongId)
                    .HasMaxLength(60)
                    .HasColumnName("Route_User_Long_Id");

                entity.Property(e => e.RoutineCategCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Categ_Cd");

                entity.Property(e => e.RoutineCdLocDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Routine_Cd_Loc_Desc");

                entity.Property(e => e.RoutineDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Routine_Desc");

                entity.Property(e => e.RoutineDurCount).HasColumnName("Routine_Dur_Count");

                entity.Property(e => e.RoutineMsgTxt)
                    .HasMaxLength(255)
                    .HasColumnName("Routine_Msg_Txt");

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(32)
                    .HasColumnName("Routine_Name");

                entity.Property(e => e.RoutineRunFreqCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Run_Freq_Cd");

                entity.Property(e => e.RoutineShortDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Routine_Short_Desc");

                entity.Property(e => e.RoutineStatusCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Status_Cd");

                entity.Property(e => e.RoutineTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Type_Cd");

                entity.Property(e => e.SaveTrigTransInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Save_Trig_Trans_Ind")
                    .IsFixedLength();

                entity.Property(e => e.SkipIfNoTransCcyDayInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Skip_If_No_Trans_Ccy_Day_Ind")
                    .IsFixedLength();

                entity.Property(e => e.TfBayesWeight)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("TF_Bayes_Weight");

                entity.Property(e => e.VerNo).HasColumnName("Ver_No");

                entity.Property(e => e.VsdInstallationName)
                    .HasMaxLength(255)
                    .HasColumnName("VSD_Installation_Name");

                entity.Property(e => e.VsdWinName)
                    .HasMaxLength(25)
                    .HasColumnName("VSD_Win_Name");
            });

            modelBuilder.Entity<AcScenarioEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("AC_Scenario_Event", "AC");

                entity.Property(e => e.EventId)
                    .HasColumnType("numeric(12, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Event_Id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Event_Desc");

                entity.Property(e => e.EventTypeCd)
                    .HasMaxLength(60)
                    .HasColumnName("Event_Type_Cd");

                entity.Property(e => e.ScenarioRootKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Scenario_Root_Key");
            });
            modelBuilder.Entity<AcSuspectedObject>(entity =>
            {
                entity.HasKey(e => new { e.AlarmedObjLevelCd, e.AlarmedObjKey })
                    .HasName("XPKAC_Suspected_Object");

                entity.ToTable("AC_Suspected_Object", "AC");

                entity.Property(e => e.AlarmedObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Alarmed_Obj_level_Cd");

                entity.Property(e => e.AlarmedObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarmed_Obj_Key");

                entity.Property(e => e.AgeOldAlarm).HasColumnName("Age_Old_Alarm");

                entity.Property(e => e.AggAmt)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("Agg_Amt");

                entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Alarmed_Obj_Name");

                entity.Property(e => e.AlarmedObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Alarmed_Obj_No");

                entity.Property(e => e.AlarmsCount).HasColumnName("Alarms_Count");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CreateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Timestamp");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MlScore).HasColumnName("ML_Score");

                entity.Property(e => e.OwnerUid)
                    .HasMaxLength(240)
                    .HasColumnName("Owner_UID");

                entity.Property(e => e.PoliticalExpPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Political_Exp_Person_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ProdType)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type");

                entity.Property(e => e.RiskScoreCd)
                    .HasMaxLength(32)
                    .HasColumnName("Risk_Score_Cd");

                entity.Property(e => e.SuspectIdentity)
                    .HasMaxLength(50)
                    .HasColumnName("Suspect_Identity");

                entity.Property(e => e.SuspectQueue)
                    .HasMaxLength(50)
                    .HasColumnName("Suspect_Queue");

                entity.Property(e => e.TransCount).HasColumnName("Trans_Count");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AcctKey);

                entity.ToTable("Account", "DGAMLCORE");

                entity.Property(e => e.AcctKey).HasColumnName("Acct_Key");

                entity.Property(e => e.AcctCcyCd)
                    .HasMaxLength(3)
                    .HasColumnName("Acct_Ccy_Cd");

                entity.Property(e => e.AcctCcyName)
                    .HasMaxLength(100)
                    .HasColumnName("Acct_Ccy_Name");

                entity.Property(e => e.AcctCloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Acct_Close_Date");

                entity.Property(e => e.AcctName)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_Name");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_No");

                entity.Property(e => e.AcctOpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Acct_Open_Date");

                entity.Property(e => e.AcctPrimBranchName)
                    .HasMaxLength(35)
                    .HasColumnName("Acct_Prim_Branch_Name");

                entity.Property(e => e.AcctRegName)
                    .HasMaxLength(255)
                    .HasColumnName("Acct_Reg_Name");

                entity.Property(e => e.AcctRegTypeDesc)
                    .HasMaxLength(35)
                    .HasColumnName("Acct_Reg_Type_Desc");

                entity.Property(e => e.AcctStatusDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_Status_Desc");

                entity.Property(e => e.AcctTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Acct_Tax_Id");

                entity.Property(e => e.AcctTaxIdTypeCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Acct_Tax_Id_Type_Cd")
                    .IsFixedLength();

                entity.Property(e => e.AcctTaxStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Acct_Tax_State_Cd");

                entity.Property(e => e.AcctTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Acct_Type_Desc");

                entity.Property(e => e.AltName)
                    .HasMaxLength(50)
                    .HasColumnName("Alt_Name");

                entity.Property(e => e.CashIntsBusInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Cash_Ints_Bus_Ind")
                    .IsFixedLength();

                entity.Property(e => e.CcyBasedAcctInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ccy_Based_Acct_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_Begin_Date");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Chg_Current_Ind")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength();

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_End_Date")
                    .HasDefaultValueSql("('5999-01-01 00:00:00.000')");

                entity.Property(e => e.ColtrlTypeCd)
                    .HasMaxLength(50)
                    .HasColumnName("Coltrl_Type_Cd");

                entity.Property(e => e.ColtrlTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Coltrl_Type_Desc");

                entity.Property(e => e.DormInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Dorm_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.InstAmt)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("Inst_Amt");

                entity.Property(e => e.InsurAmt)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("Insur_Amt");

                entity.Property(e => e.LeaseTransfer).HasMaxLength(3);

                entity.Property(e => e.LetterCrOnfileInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Letter_Cr_Onfile_Ind")
                    .IsFixedLength();

                entity.Property(e => e.LineBusName)
                    .HasMaxLength(50)
                    .HasColumnName("Line_Bus_Name");

                entity.Property(e => e.MailAddr1)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_1");

                entity.Property(e => e.MailAddr2)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_City_Name");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Mail_Cntry_Cd")
                    .IsFixedLength();

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Mail_Cntry_Name");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Mail_Post_Cd")
                    .IsFixedLength();

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Mail_State_Cd")
                    .IsFixedLength();

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_State_Name");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Maturity_Date");

                entity.Property(e => e.OrigLoanAmt)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("Orig_Loan_Amt");

                entity.Property(e => e.ProdCategName)
                    .HasMaxLength(35)
                    .HasColumnName("Prod_Categ_Name");

                entity.Property(e => e.ProdLineName)
                    .HasMaxLength(35)
                    .HasColumnName("Prod_Line_Name");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(100)
                    .HasColumnName("Prod_Name");

                entity.Property(e => e.ProdNo)
                    .HasMaxLength(25)
                    .HasColumnName("Prod_No");

                entity.Property(e => e.ProdTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("Prod_Type_Name");

                entity.Property(e => e.Tenure).HasMaxLength(10);

                entity.Property(e => e.TradeFinInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Trade_Fin_Ind")
                    .IsFixedLength();

                entity.Property(e => e.Vinno)
                    .HasMaxLength(50)
                    .HasColumnName("VINNO");
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustKey);

                entity.ToTable("Customer", "DGAMLCORE");

                entity.Property(e => e.CustKey).HasColumnName("Cust_Key");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_2");

                entity.Property(e => e.AnnualIncomeAmt)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Annual_Income_Amt");

                entity.Property(e => e.CcyExchInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ccy_Exch_Ind")
                    .IsFixedLength();

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Check_Casher_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_Begin_Date");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Chg_Current_Ind")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength();

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_End_Date")
                    .HasDefaultValueSql("('5999-01-01 00:00:00.000')");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Citizen_Cntry_Cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Citizen_Cntry_Name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("City_Name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Cntry_Cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Cntry_name");

                entity.Property(e => e.CustBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Birth_Date");

                entity.Property(e => e.CustFname)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_FName");

                entity.Property(e => e.CustGen)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Gen")
                    .IsFixedLength();

                entity.Property(e => e.CustIdCntryCd)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_Id_Cntry_Cd");

                entity.Property(e => e.CustIdStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Cust_Id_State_Cd");

                entity.Property(e => e.CustIdentExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Ident_Exp_Date");

                entity.Property(e => e.CustIdentId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Ident_Id");

                entity.Property(e => e.CustIdentIssDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Ident_Iss_Date");

                entity.Property(e => e.CustIdentTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Ident_Type_Desc");

                entity.Property(e => e.CustLname)
                    .HasMaxLength(100)
                    .HasColumnName("Cust_LName");

                entity.Property(e => e.CustMname)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_MName");

                entity.Property(e => e.CustName)
                    .HasMaxLength(200)
                    .HasColumnName("Cust_Name");

                entity.Property(e => e.CustNo)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_No");

                entity.Property(e => e.CustSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Since_Date");

                entity.Property(e => e.CustStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Status_Desc");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Tax_Id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Tax_Id_Type_Cd")
                    .IsFixedLength();

                entity.Property(e => e.CustTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Type_Desc");

                entity.Property(e => e.DoBusAsName)
                    .HasMaxLength(35)
                    .HasColumnName("Do_Bus_As_Name");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(35)
                    .HasColumnName("Email_Addr");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_No");

                entity.Property(e => e.EmprName)
                    .HasMaxLength(35)
                    .HasColumnName("Empr_Name");

                entity.Property(e => e.EmprTelNo)
                    .HasMaxLength(25)
                    .HasColumnName("Empr_Tel_No");

                entity.Property(e => e.ExtCustInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ext_Cust_Ind")
                    .IsFixedLength();

                entity.Property(e => e.FrgnConsulate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Frgn_Consulate")
                    .IsFixedLength();

                entity.Property(e => e.IndsCd)
                    .HasMaxLength(10)
                    .HasColumnName("Inds_Cd");

                entity.Property(e => e.IndsCdRr)
                    .HasMaxLength(10)
                    .HasColumnName("Inds_Cd_RR");

                entity.Property(e => e.IndsDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Inds_Desc");

                entity.Property(e => e.InternetGmblngInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Internet_Gmblng_Ind")
                    .IsFixedLength();

                entity.Property(e => e.IssBearsSharesInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Iss_Bears_Shares_Ind")
                    .IsFixedLength();

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Contact_Date");

                entity.Property(e => e.LegalObjType)
                    .HasMaxLength(30)
                    .HasColumnName("Legal_Obj_Type");

                entity.Property(e => e.LstCashTransReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Cash_Trans_Report_Date");

                entity.Property(e => e.LstRiskAssmntDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Risk_Assmnt_Date");

                entity.Property(e => e.LstSuspActReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Susp_Act_Report_Date");

                entity.Property(e => e.LstUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Update_Date");

                entity.Property(e => e.MachCdMailAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("Mach_Cd_Mail_Addr_Line");

                entity.Property(e => e.MailAddr1)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_1");

                entity.Property(e => e.MailAddr2)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_City_Name");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(50)
                    .HasColumnName("Mail_Cntry_Cd");

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Mail_Cntry_Name");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .HasColumnName("Mail_Post_Cd");

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Mail_State_Cd");

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_State_Name");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Marital_Status_Desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr_Line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_City");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Indv");

                entity.Property(e => e.MatchCdMailAddr)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_Addr");

                entity.Property(e => e.MatchCdMailCity)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_City");

                entity.Property(e => e.MatchCdMailCntry)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_Cntry");

                entity.Property(e => e.MatchCdMailState)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_State");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_State");

                entity.Property(e => e.MoneyOrderInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Money_Order_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyServiceBusInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Money_Service_Bus_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyTransmtrInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Money_Transmtr_Ind")
                    .IsFixedLength();

                entity.Property(e => e.NationalAddr)
                    .HasMaxLength(250)
                    .HasColumnName("National_Addr");

                entity.Property(e => e.NegtvNewsInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Negtv_News_Ind")
                    .IsFixedLength();

                entity.Property(e => e.NetWorthAmt)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Net_Worth_Amt");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Non_Profit_Org_Ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupDesc)
                    .HasMaxLength(35)
                    .HasColumnName("Occup_Desc");

                entity.Property(e => e.OrgCntryOfBusCd)
                    .HasMaxLength(3)
                    .HasColumnName("Org_Cntry_of_Bus_Cd");

                entity.Property(e => e.OrgCntryOfBusName)
                    .HasMaxLength(100)
                    .HasColumnName("Org_Cntry_of_Bus_Name");

                entity.Property(e => e.ParentName)
                    .HasMaxLength(35)
                    .HasColumnName("Parent_Name");

                entity.Property(e => e.PoliticalExpPrsnInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Political_Exp_Prsn_Ind")
                    .IsFixedLength();

                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("Post_Cd");

                entity.Property(e => e.PrepCardInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Prep_Card_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Resid_Cntry_Cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Resid_Cntry_Name");

                entity.Property(e => e.RiskClass).HasColumnName("Risk_Class");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("State_Cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(35)
                    .HasColumnName("State_Name");

                entity.Property(e => e.SuspActRptCount)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("Susp_Act_RPT_Count");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_2");

                entity.Property(e => e.TelNo3)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_3");

                entity.Property(e => e.TravChekInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Trav_Chek_Ind")
                    .IsFixedLength();

                entity.Property(e => e.TrustAcctInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Trust_Acct_Ind")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ExternalCustomer>(entity =>
            {
                entity.HasKey(e => e.ExtCustAcctKey);

                entity.ToTable("External_Customer", "DGAMLCORE");

                entity.Property(e => e.ExtCustAcctKey).HasColumnName("Ext_Cust_Acct_Key");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_No");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_2");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("Branch_Name");

                entity.Property(e => e.BranchNo)
                    .HasMaxLength(25)
                    .HasColumnName("Branch_No");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Citizen_Cntry_Cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Citizen_Cntry_Name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("City_Name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Cntry_Cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Cntry_Name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Tax_Id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Tax_Id_Type_Cd")
                    .IsFixedLength();

                entity.Property(e => e.ExtBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ext_Birth_Date");

                entity.Property(e => e.ExtCustNo)
                    .HasMaxLength(100)
                    .HasColumnName("Ext_Cust_No");

                entity.Property(e => e.ExtCustTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Ext_Cust_Type_Desc");

                entity.Property(e => e.ExtFname)
                    .HasMaxLength(50)
                    .HasColumnName("Ext_FName");

                entity.Property(e => e.ExtFullName)
                    .HasMaxLength(200)
                    .HasColumnName("Ext_Full_Name");

                entity.Property(e => e.ExtLname)
                    .HasMaxLength(100)
                    .HasColumnName("Ext_LName");

                entity.Property(e => e.ExtMname)
                    .HasMaxLength(50)
                    .HasColumnName("Ext_MName");

                entity.Property(e => e.FiNo)
                    .HasMaxLength(25)
                    .HasColumnName("FI_No");

                entity.Property(e => e.IdentCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Ident_Cntry_Cd");

                entity.Property(e => e.IdentCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Ident_Cntry_Name");

                entity.Property(e => e.IdentId)
                    .HasMaxLength(35)
                    .HasColumnName("Ident_Id");

                entity.Property(e => e.IdentStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Ident_State_Cd");

                entity.Property(e => e.IdentTypeDesc)
                    .HasMaxLength(4)
                    .HasColumnName("Ident_Type_Desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr_Line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_City");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Indv");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_State");

                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("Post_Cd");

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Resid_Cntry_Cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Resid_Cntry_Name");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("State_Cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(35)
                    .HasColumnName("State_Name");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_2");
            });
            modelBuilder.Entity<AcRoutineParameter>(entity =>
            {
                entity.HasKey(e => new { e.RoutineId, e.ParmName });

                entity.ToTable("AC_Routine_Parameter", "AC");

                entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Routine_Id");

                entity.Property(e => e.ParmName)
                    .HasMaxLength(32)
                    .HasColumnName("Parm_Name");

                entity.Property(e => e.DayType)
                    .HasMaxLength(10)
                    .HasColumnName("Day_Type");

                entity.Property(e => e.ParamCondition)
                    .HasMaxLength(1000)
                    .HasColumnName("param_condition");

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Parm_Desc");

                entity.Property(e => e.ParmTypeDesc)
                    .HasMaxLength(32)
                    .HasColumnName("Parm_Type_Desc");

                entity.Property(e => e.ParmValue)
                    .HasMaxLength(1024)
                    .HasColumnName("Parm_Value");

                entity.Property(e => e.ValueCate)
                    .HasMaxLength(32)
                    .HasColumnName("value_cate");
            });

            modelBuilder.HasSequence("hibernate_sequence");

            modelBuilder.HasSequence("sequence_generator_AC_List", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_List_Category", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_List_Element", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Assessment", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier_Category", "AC");
        }

        public void OnFCFCOREModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CI_AI");



            modelBuilder.Entity<FscPartyDim>(entity =>
            {
                entity.HasKey(e => e.PartyKey)
                    .HasName("XPKFSC_PARTY_DIM");

                entity.ToTable("FSC_PARTY_DIM", "FCFCORE");

                entity.HasIndex(e => e.ChangeBeginDate, "CHABEGDATEPARTY_DIM");

                entity.HasIndex(e => e.ChangeCurrentInd, "CHANGE_CURRENT_IND_INDX");

                entity.HasIndex(e => e.PartyStatusDesc, "PARSTATUDESCPARTY_DIM");

                entity.HasIndex(e => e.ScreeningDate, "SCREENINGDATEPARTY_DIM");

                entity.HasIndex(e => e.PartyNumber, "party_num_index");

                entity.Property(e => e.PartyKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("party_key");

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("annual_income_amount");

                entity.Property(e => e.BenOwnExemptInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ben_own_exempt_ind")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

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

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("check_casher_ind")
                    .IsFixedLength();

                entity.Property(e => e.CitizenshipCountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("citizenship_country_code")
                    .IsFixedLength();

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("citizenship_country_name");

                entity.Property(e => e.CurrencyExchangeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("currency_exchange_ind")
                    .IsFixedLength();

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("customer_since_date");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("doing_business_as_name");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .HasColumnName("email_address");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind")
                    .IsFixedLength();

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("employee_number");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("employer_name");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("employer_phone_number");

                entity.Property(e => e.EntitySegmentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("entity_segment_id");

                entity.Property(e => e.Errordesc)
                    .HasMaxLength(4000)
                    .HasColumnName("errordesc");

                entity.Property(e => e.ExternalPartyInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("external_party_ind")
                    .IsFixedLength();

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("foreign_consulate_embassy_ind")
                    .IsFixedLength();

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("industry_code")
                    .IsFixedLength();

                entity.Property(e => e.IndustryCodeRr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("industry_code_rr");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("industry_desc");

                entity.Property(e => e.InternetGamblingInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("internet_gambling_ind")
                    .IsFixedLength();

                entity.Property(e => e.IssuesBearerSharesInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("issues_bearer_shares_ind")
                    .IsFixedLength();

                entity.Property(e => e.LastCashTransRptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_cash_trans_rpt_date");

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_contact_date");

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_risk_assessment_date");

                entity.Property(e => e.LastSuspActvRptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_susp_actv_rpt_date");

                entity.Property(e => e.LegalEntityType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("legal_entity_type");

                entity.Property(e => e.LstUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lst_update_date");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("mailing_address_1");

                entity.Property(e => e.MailingAddress2)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("mailing_address_2");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("mailing_city_name");

                entity.Property(e => e.MailingCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mailing_country_code")
                    .IsFixedLength();

                entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mailing_country_name");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mailing_postal_code")
                    .IsFixedLength();

                entity.Property(e => e.MailingStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mailing_state_code")
                    .IsFixedLength();

                entity.Property(e => e.MailingStateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("mailing_state_name");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("marital_status_desc");

                entity.Property(e => e.MatchCodeIndividual)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("match_code_individual");

                entity.Property(e => e.MatchCodeMailingAddrLines)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_addr_lines");

                entity.Property(e => e.MatchCodeMailingAddress)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_address");

                entity.Property(e => e.MatchCodeMailingCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_city");

                entity.Property(e => e.MatchCodeMailingCountry)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_country");

                entity.Property(e => e.MatchCodeMailingState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_state");

                entity.Property(e => e.MatchCodeOrganization)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("match_code_organization");

                entity.Property(e => e.MatchCodeStreetAddrLines)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_addr_lines");

                entity.Property(e => e.MatchCodeStreetAddress)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_address");

                entity.Property(e => e.MatchCodeStreetCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_city");

                entity.Property(e => e.MatchCodeStreetCountry)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_country");

                entity.Property(e => e.MatchCodeStreetState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_state");

                entity.Property(e => e.MoneyOrdersInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("money_orders_ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyTransmitterInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("money_transmitter_ind")
                    .IsFixedLength();

                entity.Property(e => e.MsbInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("msb_ind")
                    .IsFixedLength();

                entity.Property(e => e.NegativeNewsInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("negative_news_ind")
                    .IsFixedLength();

                entity.Property(e => e.NetWorthAmount)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("net_worth_amount");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("non_profit_org_ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("occupation_desc");

                entity.Property(e => e.OrgCountryOfBusinessCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("org_country_of_business_code")
                    .IsFixedLength();

                entity.Property(e => e.OrgCountryOfBusinessName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("org_country_of_business_name");

                entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("party_date_of_birth");

                entity.Property(e => e.PartyFirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_first_name");

                entity.Property(e => e.PartyIdCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("party_id_country_code")
                    .IsFixedLength();

                entity.Property(e => e.PartyIdStateCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_id_state_code");

                entity.Property(e => e.PartyIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("party_identification_id");

                entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_identification_type_desc");

                entity.Property(e => e.PartyLastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_last_name");

                entity.Property(e => e.PartyMiddleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_middle_name");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_name");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("party_number");

                entity.Property(e => e.PartyStatusDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_status_desc");

                entity.Property(e => e.PartyTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("party_tax_id");

                entity.Property(e => e.PartyTaxIdTypeCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("party_tax_id_type_code")
                    .IsFixedLength();

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_type_desc");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_2");

                entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_3");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("politically_exposed_person_ind")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.PrepaidCardsInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("prepaid_cards_ind")
                    .IsFixedLength();

                entity.Property(e => e.PurgeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("purge_date");

                entity.Property(e => e.ResidenceCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("residence_country_code")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("residence_country_name");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.RiskClassification)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("risk_classification");

                entity.Property(e => e.ScreeningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SCREENING_DATE");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("street_address_2");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("street_city_name");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_country_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
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
                    .IsUnicode(false)
                    .HasColumnName("street_state_name");

                entity.Property(e => e.SuspActvRptCount)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("susp_actv_rpt_count");

                entity.Property(e => e.TravelersChequesInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("travelers_cheques_ind")
                    .IsFixedLength();

                entity.Property(e => e.TrustAccountInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("trust_account_ind")
                    .IsFixedLength();

                entity.Property(e => e.UltimateParentName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ultimate_parent_name");
            });


            modelBuilder.HasSequence("party_key").StartsAt(3);
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
        }

        public void OnGoAmlModelCreating(ModelBuilder modelBuilder)
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
            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.ToTable("LOOKUPS", "target");

                entity.Property(e => e.BusinessUnit)
                    .HasMaxLength(255)
                    .HasColumnName("BUSINESS_UNIT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.LookupKey)
                    .HasMaxLength(255)
                    .HasColumnName("LOOKUP_KEY");

                entity.Property(e => e.LookupName)
                    .HasMaxLength(255)
                    .HasColumnName("LOOKUP_NAME");

                entity.Property(e => e.LookupValue)
                    .HasMaxLength(255)
                    .HasColumnName("LOOKUP_VALUE");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .HasColumnName("MODIFIED_BY");
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
        }

        public void OnTiZoneModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnDGMGMGModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupDg>(entity =>
            {
                entity.ToTable("group_dg", "DGMGMT");

                entity.HasIndex(e => e.Name, "UK_79kwwaf53vdtgfxwsemb2q3au")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });
            modelBuilder.Entity<UserDg>(entity =>
            {
                entity.ToTable("user_dg", "DGMGMT");

                entity.HasIndex(e => e.Name, "UQ__user_dg__72E12F1B0D4D2B7D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock)
                    .HasColumnName("counter_lock")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });
            modelBuilder.Entity<RoleDg>(entity =>
            {
                entity.ToTable("role_dg", "DGMGMT");

                entity.HasIndex(e => e.Name, "UK_9dg6bnig1y6lu7h5njsigd013")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

        }

        public void OnDGMGMGMAUDodelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__account___BE3894F912DD22B1");

                entity.ToTable("account_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.AuthenticationDomain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("authentication_domain");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });
            modelBuilder.Entity<GroupDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__group_dg__BE3894F9084E2C5C");

                entity.ToTable("group_dg_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<LoggedUserAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__logged_u__BE3894F91A94C531");

                entity.ToTable("logged_user_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("app_name");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("device_name");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("device_type");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ip");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<UserDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__user_dg___BE3894F995453541");

                entity.ToTable("user_dg_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock).HasColumnName("counter_lock");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<RoleDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__role_dg___BE3894F923B2EE7A");

                entity.ToTable("role_dg_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });
        }

        public void OnCRPModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtCrpCase>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CRP_CASES", "ART_DB");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("case_id")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("case_rk");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("Case_Status")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Close_Date");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_risk_assessment_date");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_name")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(100)
                    .HasColumnName("Party_Number")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_type_desc")
                    .UseCollation("Arabic_CI_AI");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .HasColumnName("risk_classification")
                    .UseCollation("Arabic_CI_AI");
            });
            modelBuilder.Entity<ArtCrpSystemPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CRP_SYSTEM_PERFORMANCE", "ART_DB");

                entity.Property(e => e.CaseCurrentRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CURRENT_RATE");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(4000)
                    .HasColumnName("Case_Type")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Casetargetrate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CASETARGETRATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(4000)
                    .HasColumnName("CUSTOMER_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.DurationsInDays).HasColumnName("DURATIONS_In_days");

                entity.Property(e => e.DurationsInHours).HasColumnName("DURATIONS_In_hours");

                entity.Property(e => e.DurationsInMinutes).HasColumnName("DURATIONS_In_minutes");

                entity.Property(e => e.DurationsInSeconds).HasColumnName("DURATIONS_In_Seconds");

                entity.Property(e => e.EcmLastStatusDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ECM_LAST_STATUS_DATE");
            });
            modelBuilder.Entity<ArtCrpUserPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CRP_USER_PERFORMANCE", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(256)
                    .HasColumnName("ACTION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ActionUser)
                    .HasMaxLength(60)
                    .HasColumnName("ACTION_USER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.AsssignedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ASSSIGNED_TIME");

                entity.Property(e => e.CaseCurrentRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CURRENT_RATE");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_TYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Casetargetrate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CASETARGETRATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(4000)
                    .HasColumnName("CUSTOMER_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.DurationsInDays).HasColumnName("DURATIONS_In_days");

                entity.Property(e => e.DurationsInHours).HasColumnName("DURATIONS_In_hours");

                entity.Property(e => e.DurationsInMinutes).HasColumnName("DURATIONS_In_minutes");

                entity.Property(e => e.DurationsInSeconds).HasColumnName("DURATIONS_In_Seconds");

                entity.Property(e => e.ReleasedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("RELEASED_DATE");
            });
            modelBuilder.Entity<ArtCrpConfig>(entity =>
            {

                entity.ToView("ART_CRP_CONFIG", "ART_DB");
                entity.Property(e => e.CaseId)
                .HasColumnName("case_id")
                .HasMaxLength(64);
                entity.HasNoKey();

                entity.Property(e => e.Maker)
                    .HasColumnName("Maker")
                    .HasMaxLength(60);

                entity.Property(e => e.MakerDate)
                    .HasColumnName("Maker_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Checker)
                    .HasColumnName("Checker")
                    .HasMaxLength(60);

                entity.Property(e => e.CheckerDate)
                    .HasColumnName("Checker_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckerAction)
                    .HasColumnName("Checker_Action")
                    .HasMaxLength(256);

                entity.Property(e => e.ActionDetail)
                    .HasColumnName("Action_Detail")
                    .HasColumnType("nvarchar(max)");
            });
        }
        public void OnFATCAModelCreating(ModelBuilder modelBuilder)
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

        }

        public void OnTRADE_BASEModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ArtTradeBaseSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TRADE_BASE_SUMMARY", "ART_DB");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.AddedToCase).HasColumnName("ADDED_TO_CASE");

                entity.Property(e => e.Closed).HasColumnName("CLOSED");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(100)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.EntityNumber)
                    .HasMaxLength(50)
                    .HasColumnName("ENTITY_NUMBER");

                entity.Property(e => e.SuppressedAlert).HasColumnName("SUPPRESSED_ALERT");
            });
        }
        public void OnSasAuditModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SasAuditTrailReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_AUDIT_TRAIL_REPORT", "ART_DB");

                entity.Property(e => e.ActionDate)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_DATE");

                entity.Property(e => e.ActionOn)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_ON");

                entity.Property(e => e.ActionType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_TYPE");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ObjectName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("OBJECT_NAME");

                entity.Property(e => e.ObjectType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OBJECT_TYPE");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UserId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<SasListAccessRightPerProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_ACCESS_RIGHT_PER_PROFILE", "ART_DB");

                entity.Property(e => e.CapName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("CAP_NAME");

                entity.Property(e => e.CapabilitiyGroupName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("CAPABILITIY_GROUP_NAME");

                entity.Property(e => e.CapabilityId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CAPABILITY_ID");

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("COMPONENT_NAME");

                entity.Property(e => e.GroupDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_DESCRIPTION");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.Grouptype)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GROUPTYPE");
            });

            modelBuilder.Entity<SasListAccessRightPerRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_ACCESS_RIGHT_PER_ROLE", "ART_DB");

                entity.Property(e => e.CapName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("CAP_NAME");

                entity.Property(e => e.CapabilitiyGroupName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("CAPABILITIY_GROUP_NAME");

                entity.Property(e => e.CapabilityId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CAPABILITY_ID");

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("COMPONENT_NAME");

                entity.Property(e => e.Role)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_DESCRIPTION");
            });

            modelBuilder.Entity<SasListAccessUsersGroupsCap>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_ACCESS_USERS_GROUPS_CAPS", "ART_DB");

                entity.Property(e => e.Capabilities)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Display_Name");

                entity.Property(e => e.Ggroup)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GGroup");

                entity.Property(e => e.Rrole)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RRole");

                entity.Property(e => e.UserName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<SasListGroupsRolesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_GROUPS_ROLES_SUMMARY", "ART_DB");

                entity.Property(e => e.Groups)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GROUPS");

                entity.Property(e => e.Roles)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ROLES");
            });

            modelBuilder.Entity<SasListOfUsersAndGroupsRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_OF_USERS_AND_GROUPS_ROLES", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Display_Name");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.GroupDisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_DISPLAY_NAME");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Job_Title");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.RoleDisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_DISPLAY_NAME");

                entity.Property(e => e.UserId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("User_ROLE");
            });

            modelBuilder.Entity<SasListUsersDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_USERS_DEPARTMENT", "ART_DB");

                entity.Property(e => e.Appname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("APPNAME");

                entity.Property(e => e.Department)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Logindatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGINDATETIME");

                entity.Property(e => e.UserDesccription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_DESCCRIPTION");

                entity.Property(e => e.UserDisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("USER_DISPLAY_NAME");

                entity.Property(e => e.UserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_TITLE");
            });

            modelBuilder.Entity<VaLastLoginView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VA_LAST_LOGIN_VIEW", "ART_DB");

                entity.Property(e => e.Appname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("APPNAME");

                entity.Property(e => e.Logindate)
                    .HasColumnType("date")
                    .HasColumnName("LOGINDATE");

                entity.Property(e => e.Logindatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGINDATETIME");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Username)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<VaLicensedView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VA_LICENSED_VIEW", "ART_DB");

                entity.Property(e => e.AppLebal)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("APP_LEBAL");

                entity.Property(e => e.BeginDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BEGIN_DATE");

                entity.Property(e => e.Diedate)
                    .HasColumnType("date")
                    .HasColumnName("DIEDATE");

                entity.Property(e => e.Fmtname)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("FMTNAME");

                entity.Property(e => e.ProStart)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRO_START");

                entity.Property(e => e.ProType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRO_TYPE");
            });
        }
        public void OnDGSasAuditModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaAuthdomain>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_AUTHDOMAIN", "ART_DB");

                entity.Property(e => e.AuthDomName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("authDomName");

                entity.Property(e => e.AuthDomOutboundOnly).HasColumnName("authDomOutboundOnly");

                entity.Property(e => e.AuthDomTrustedOnly).HasColumnName("authDomTrustedOnly");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");
            });

            modelBuilder.Entity<VaEmail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_EMAIL", "ART_DB");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailAddr");

                entity.Property(e => e.EmailType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("emailType");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");
            });

            modelBuilder.Entity<VaEmailInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_EMAIL_INFO", "ART_DB");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EmailType)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PersonExtIdContext)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Context");

                entity.Property(e => e.PersonExtIdIdentifier)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Identifier");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Person_Id");
            });

            modelBuilder.Entity<VaGroupInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_GROUP_INFO", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ExtIdContext)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ExtId_Context");

                entity.Property(e => e.ExtIdIdentifier)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ExtId_Identifier");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaGrouploginsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_GROUPLOGINS_INFO", "ART_DB");

                entity.Property(e => e.AuthDomExtIdContext)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_ExtId_Context");

                entity.Property(e => e.AuthDomExtIdIdentifier)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_ExtId_Identifier");

                entity.Property(e => e.AuthDomId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_Id");

                entity.Property(e => e.AuthDomName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_Name");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.GroupExtIdContext)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Group_ExtId_Context");

                entity.Property(e => e.GroupExtIdIdentifier)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Group_ExtId_Identifier");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Group_Id");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<VaGroupmemgroupsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_GROUPMEMGROUPS_INFO", "ART_DB");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.MemDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("memDesc");

                entity.Property(e => e.MemId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("memId");

                entity.Property(e => e.MemName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("memName");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaGroupmempersonsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_GROUPMEMPERSONS_INFO", "ART_DB");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.MemDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("memDesc");

                entity.Property(e => e.MemId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("memId");

                entity.Property(e => e.MemName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("memName");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaGrpmem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_GRPMEMS", "ART_DB");

                entity.Property(e => e.Grpkeyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("grpkeyid");

                entity.Property(e => e.Memkeyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("memkeyid");
            });

            modelBuilder.Entity<VaIdgrp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_IDGRPS", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("displayname");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.GrpType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("grpType");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");
            });

            modelBuilder.Entity<VaLicensed>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_LICENSED", "ART_DB");

                entity.Property(e => e.AppLebal)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("APP_LEBAL");

                entity.Property(e => e.BeginDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BEGIN_DATE");

                entity.Property(e => e.Diedate)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIEDATE");

                entity.Property(e => e.Fmtname)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("FMTNAME");

                entity.Property(e => e.ProStart)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRO_START");

                entity.Property(e => e.ProType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRO_TYPE");
            });

            modelBuilder.Entity<VaLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_LOCATION", "ART_DB");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Area)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("locationName");

                entity.Property(e => e.LocationType)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("locationType");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("postalcode");
            });

            modelBuilder.Entity<VaLocationInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_LOCATION_INFO", "ART_DB");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.LocationType)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PersonExtIdContext)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Context");

                entity.Property(e => e.PersonExtIdIdentifier)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Identifier");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Person_Id");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_LOGINS", "ART_DB");

                entity.Property(e => e.Authdomkeyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("authdomkeyid");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Userid)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<VaLoginsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_LOGINS_INFO", "ART_DB");

                entity.Property(e => e.AuthDomExtIdContext)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_ExtId_Context");

                entity.Property(e => e.AuthDomExtIdIdentifier)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_ExtId_Identifier");

                entity.Property(e => e.AuthDomId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_Id");

                entity.Property(e => e.AuthDomName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AuthDom_Name");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PersonExtIdContext)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Context");

                entity.Property(e => e.PersonExtIdIdentifier)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Identifier");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Person_Id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_PERSON", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("displayname");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<VaPersonInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_PERSON_INFO", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ExtIdContext)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ExtId_Context");

                entity.Property(e => e.ExtIdId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("ExtId_Id");

                entity.Property(e => e.ExtIdIdentifier)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ExtId_Identifier");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaPhone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_PHONE", "ART_DB");

                entity.Property(e => e.Externalkey).HasColumnName("externalkey");

                entity.Property(e => e.Keyid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("keyid");

                entity.Property(e => e.Objid)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("objid");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PhoneType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("phoneType");
            });

            modelBuilder.Entity<VaPhoneInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_PHONE_INFO", "ART_DB");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PersonExtIdContext)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Context");

                entity.Property(e => e.PersonExtIdIdentifier)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Person_ExtId_Identifier");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Person_Id");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.PhoneType)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VaUserCapability>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_UserCapability", "ART_DB");

                entity.Property(e => e.CapName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("cap_name");

                entity.Property(e => e.CapabilitiyGroupName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("capabilitiy_group_name");

                entity.Property(e => e.CapabilityId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("capability_id");

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("component_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.MemIdentityType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("mem_identity_type");

                entity.Property(e => e.RoleNm)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("role_nm");

                entity.Property(e => e.UserGroupNm)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("user_group_nm");

                entity.Property(e => e.UserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("user_long_id");
            });
        }
    }
}
