using Data.Data;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Data.FCF71;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Microsoft.EntityFrameworkCore;


namespace Data.ModelCreatingStrategies
{
    public class SqlServerModelCreatingStrategy : IModelCreatingStrategy
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
                    .UseCollation("Arabic_100_CI_AI");

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
                    .UseCollation("Arabic_100_CI_AI");

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
            //Sanction
            modelBuilder.Entity<ArtSystemPrefPerDirection>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtSystemPrefPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtSystemPerfPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtSystemPerfPerDate>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtUserPerformancePerActionUser>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtUserPerformPerAction>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtUserPerformPerUserAndAction>().HasNoKey().ToView(null);


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
            modelBuilder.Entity<ArtHomeMainCasesMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_MAIN_CASES_MONTH", "ART_DB");

                entity.Property(e => e.Day)
                    .HasColumnType("int")
                    .HasColumnName("DAY");

                entity.Property(e => e.Month)
                    .HasMaxLength(4000)
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
            modelBuilder.Entity<ArtHomeCasesProduct>(entity =>
            {

                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_PRODUCTS", "ART_DB");

                entity.Property(e => e.Product)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");
            });


            modelBuilder.Entity<ArtSystemPreformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SYSTEM_PERFORMANCE", "ART_DB");

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

                entity.Property(e => e.CaseType)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(4000)
                    .HasColumnName("CLIENT_NAME");

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

                entity.Property(e => e.EcmLastStatusDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ECM_LAST_STATUS_DATE");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("HITS_COUNT");

                entity.Property(e => e.IdentityNum)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("IDENTITY_NUM");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("INVESTR_USER_ID");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Priority)
                    .HasMaxLength(4000)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT_REFERENCE");

                entity.Property(e => e.TransactionAmount).HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_DIRECTION");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("UPDATE_USER_ID");




                entity.Property(e => e.ValidFromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VALID_FROM_DATE");
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

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_NAME");
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

        public void OnFcfkcECMModelCreating(ModelBuilder modelBuilder)
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
        }

        public void OnFTIModelCreating(ModelBuilder modelBuilder)
        {
            //ABK 
            modelBuilder.Entity<ArtCasesInitiatedFromBranch>(entity =>
            {

                entity.HasNoKey();

                entity.ToView("ART_CASES_INITIATED_FROM_BRANCH", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CASE_CREATION_DATE");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRY_DATE");
                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Currency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmReference)
                    .HasMaxLength(64)
                    .HasColumnName("ECM_REFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventName)
                    .HasMaxLength(4000)
                    .HasColumnName("EVENT_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.LastActionTakenBy)
                    .HasMaxLength(60)
                    .HasColumnName("LAST_ACTION_TAKEN_BY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Product)
                    .HasMaxLength(4000)
                    .HasColumnName("PRODUCT")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(4000)
                    .HasColumnName("PRODUCT_TYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ApplicantId)
                    .HasMaxLength(4000)
                    .HasColumnName("APPLICANT_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(4000)
                    .HasColumnName("BENEFICIARY_NAME")
                    .UseCollation("Arabic_100_CI_AI");
            });
            modelBuilder.Entity<ArtDgecmActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_DGECM_ACTIVITIES", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");
                entity.Property(e => e.Reference)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ParentCaseId)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_CASE_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseComments)
                    .HasColumnName("CASE_COMMENTS")
                    .IsUnicode(false)
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CASE_CREATION_DATE");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Currency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerCIF)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_CIF")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerClassification)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_CLASSIFICATION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmReference)
                    .HasMaxLength(64)
                    .HasColumnName("ECM_REFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventName)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Product)
                    .HasMaxLength(4000)
                    .HasColumnName("PRODUCT")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(4000)
                    .HasColumnName("PRODUCT_TYPE")
                    .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.Assignee)
                  .HasMaxLength(60)
                  .IsUnicode(false)
                  .HasColumnName("ASSIGNEE")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.AssignedBy)
                  .HasMaxLength(1000)
                  .IsUnicode(false)
                  .HasColumnName("ASSIGNED_BY")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.AssignedTime)
                   .HasColumnType("datetime")
                  .HasColumnName("ASSIGNED_TIME");

                entity.Property(e => e.UnAssignee)
                  .HasMaxLength(60)
                  .IsUnicode(false)
                  .HasColumnName("UNASSIGNEE")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.UnAssignedBy)
                  .HasMaxLength(1000)
                  .IsUnicode(false)
                  .HasColumnName("UNASSIGNED_BY")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.UnAssignedTime)
                   .HasColumnType("datetime")
                  .HasColumnName("UNASSIGNED_TIME");
                entity.Property(e => e.EcmEventStep)
                  .HasMaxLength(256)
                  .IsUnicode(false)
                  .HasColumnName("ECM_EVENT_STEP")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventCreatedBy)
                  .HasMaxLength(255)
                  .IsUnicode(false)
                  .HasColumnName("ECM_EVENT_CREATED_BY")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventCreatedDate)
                   .HasColumnType("datetime")
                  .HasColumnName("ECM_EVENT_CREATED_DATE");
                // Configure StepDifference
                entity.Property(e => e.StepDifference)
                      .HasColumnName("STEP_DIFFERENCE")
                      .HasMaxLength(100); // Adjust the length accordingly

                // Configure StepDifferenceSla
                entity.Property(e => e.StepDifferenceSla)
                      .HasColumnName("STEP_DIFFERENCE_SLA")
                      .HasMaxLength(100); // Adjust the length accordingly

                // Configure AssignDifference
                entity.Property(e => e.AssignDifference)
                      .HasColumnName("ASSIGN_DIFFERENCE")
                      .HasMaxLength(100); // Adjust the length accordingly

                // Configure AssignDifferenceSla
                entity.Property(e => e.AssignDifferenceSla)
                      .HasColumnName("ASSIGN_DIFFERENCE_SLA")
                      .HasMaxLength(100); // Adjust the length accordingly


            });
            modelBuilder.Entity<ArtEcmFtiFullCycle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ECM_FTI_FULL_CYCLE", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");
                entity.Property(e => e.BranchName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.LstModUser)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LAST_MOD_USER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CASE_CREATION_DATE");

                entity.Property(e => e.StartdTime)
                   .HasColumnType("datetime")
                   .HasColumnName("STARTED_TIME");

                entity.Property(e => e.LstModTime)
                   .HasColumnType("datetime")
                   .HasColumnName("LAST_MOD_TIME");

                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EVENT_CREATION_DATE");

                entity.Property(e => e.EcmReference)
                   .HasMaxLength(64)
                   .HasColumnName("ECM_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Product)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("Product")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Name)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("Name")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Currency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Currency")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.LastActionTakenBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LAST_ACTION_TAKEN_BY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.FtiReference)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .HasColumnName("FTI_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventName)
                   .HasMaxLength(60)
                   .IsUnicode(false)
                   .HasColumnName("Event_Name")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventStatus)
                   .HasMaxLength(11)
                   .HasColumnName("Event_Status")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.MasterAssignedTo)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .HasColumnName("Master_Assigned_To")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventSteps)
                   .HasMaxLength(21)
                   .IsUnicode(false)
                   .HasColumnName("Event_Steps")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.StepStatus)
                   .HasMaxLength(9)
                   .IsUnicode(false)
                   .HasColumnName("STEP_STATUS")
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.Assignee)
                 .HasMaxLength(60)
                 .IsUnicode(false)
                 .HasColumnName("ASSIGNEE")
                 .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.AssignedBy)
                  .HasMaxLength(1000)
                  .IsUnicode(false)
                  .HasColumnName("ASSIGNED_BY")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.AssignedTime)
                   .HasColumnType("datetime")
                  .HasColumnName("ASSIGNED_TIME");

                entity.Property(e => e.UnAssignee)
                  .HasMaxLength(60)
                  .IsUnicode(false)
                  .HasColumnName("UNASSIGNEE")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.UnAssignedBy)
                  .HasMaxLength(1000)
                  .IsUnicode(false)
                  .HasColumnName("UNASSIGNED_BY")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.UnAssignedTime)
                   .HasColumnType("datetime")
                  .HasColumnName("UNASSIGNED_TIME");

                entity.Property(e => e.EcmEventStep)
                  .HasMaxLength(256)
                  .IsUnicode(false)
                  .HasColumnName("ECM_EVENT_STEP")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventCreatedBy)
                  .HasMaxLength(255)
                  .IsUnicode(false)
                  .HasColumnName("ECM_EVENT_CREATED_BY")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventCreatedDate)
                   .HasColumnType("datetime")
                  .HasColumnName("ECM_EVENT_CREATED_DATE");
            });
            modelBuilder.Entity<ArtFtiActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FTI_ACTIVITIES", "ART_DB");
                entity.Property(e => e.EcmReference)
                   .HasMaxLength(64)
                   .IsUnicode(false)
                   .HasColumnName("ECM_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Product)
                   .HasMaxLength(4000)
                   .IsUnicode(false)
                   .HasColumnName("PRODUCT")
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EVENT_CREATION_DATE");

                entity.Property(e => e.FtiReference)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .HasColumnName("FTI_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventName)
                   .HasMaxLength(60)
                   .IsUnicode(false)
                   .HasColumnName("Event_Name")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventStatus)
                   .HasMaxLength(11)
                   .IsUnicode(false)
                   .HasColumnName("Event_Status")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.MasterAssignedTo)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .HasColumnName("Master_Assigned_To")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventSteps)
                   .HasMaxLength(21)
                   .IsUnicode(false)
                   .HasColumnName("Event_Steps")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.StepStatus)
                   .HasMaxLength(9)
                   .IsUnicode(false)
                   .HasColumnName("STEP_STATUS")
                   .UseCollation("Arabic_100_CI_AI");
            });
            modelBuilder.Entity<ArtFtiEcmTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FTI_ECM_TRANSACTIONS", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("transaction_amount");
                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EVENT_CREATION_DATE");

                entity.Property(e => e.EcmReference)
                   .HasMaxLength(64)
                   .HasColumnName("ECM_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.TradeInstructions)
                  .HasMaxLength(4000)
                  .IsUnicode(false)
                  .HasColumnName("TRADE_INSTRUCTIONS")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.FirstLineInstructions)
                  .HasMaxLength(4000)
                  .IsUnicode(false)
                  .HasColumnName("FIRST_LINE_INSTRUCTIONS")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Product)
                   .HasMaxLength(4000)
                   .IsUnicode(false)
                   .HasColumnName("Product")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTTYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventName)
                   .HasMaxLength(60)
                   .IsUnicode(false)
                   .HasColumnName("Event_Name")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventStatus)
                   .HasMaxLength(11)
                   .IsUnicode(false)
                   .HasColumnName("Event_Status")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.FtiReference)
                  .HasMaxLength(20)
                  .IsUnicode(false)
                  .HasColumnName("FTI_REFERENCE")
                  .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Currency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_currency")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.FirstLineParty)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_LINE_PARTY")
                    .UseCollation("Arabic_100_CI_AI");
            });




            modelBuilder.Entity<ArtFtiEndToEndSubCases>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FTI_END_TO_END_SUB_CASES", "ART_DB");



                entity.Property(e => e.CustomerClassification)
                   .HasColumnName("CUSTOMER_CLASSIFICATION")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.SubCaseReference)
                   .HasColumnName("SUB_CASE_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.FirtsLineInstructions)
                   .HasColumnName("FIRST_LINE_INSTRUCTIONS")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ParentCaseId)
                   .HasColumnName("PARENT_CASE_ID")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                   .HasColumnName("CASE_STATUS")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.TradeInstructions)
                   .HasColumnName("TRADE_INSTRUCTIONS")
                   .UseCollation("Arabic_100_CI_AI");



                //entity.Property(e => e.CaseCreationDate)
                //    .HasColumnType("datetime")
                //    .HasColumnName("CASE_CREATION_DATE");

                //entity.Property(e => e.EventCreationDate)
                //    .HasColumnType("date")
                //    .HasColumnName("EVENT_CREATION_DATE");



            });
            modelBuilder.Entity<ArtFtiEndToEndEcmEventsWorkflow>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FTI_END_TO_END_ECM_EVENTS_WORKFLOW", "ART_DB");



                entity.Property(e => e.EcmEventTimeDifference)
                        .HasColumnName("ECM_EVENT_TIM_EDIFFERENCE")
                        .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventCreatedBy)
                        .HasColumnName("ECM_EVENT_CREATED_BY")
                        .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventStep)
                        .HasColumnName("ECM_EVENT_STEP")
                        .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmReference)
                        .HasColumnName("ECM_REFERENCE")
                        .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseComments)
                        .HasColumnName("CASE_COMMENTS")
                        .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EcmEventCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ECM_EVENT_CREATED_DATE");



            });


            modelBuilder.Entity<ArtFtiEndToEndFtiEventsWorkflow>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FTI_END_TO_END_FTI_EVENTS_WORKFLOW", "ART_DB");


                entity.Property(e => e.LastModUser)
                           .HasColumnName("LAST_MOD_USER")
                           .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.TimeDifference)
                         .HasColumnName("TIMEDIFFERENCE")
                         .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.StepStatus)
                         .HasColumnName("STEP_STATUS")
                         .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.EventSteps)
                         .HasColumnName("Event_Steps")
                         .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.FtiReference)
                         .HasColumnName("FTI_REFERENCE")
                         .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.EcmReference)
                         .HasColumnName("ECM_REFERENCE")
                         .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.StartedTime)
               .HasColumnType("datetime")
               .HasColumnName("STARTED_TIME");


                entity.Property(e => e.LastModTime)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_MOD_TIME");
                // entity.Property(e => e.)




            });


            modelBuilder.Entity<ArtFtiEndToEndNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FTI_END_TO_END_NEW", "ART_DB");






                //                ECM_REFERENCE
                //CASE_CREATION_DATE
                //BRANCH_NAME
                //CUSTOMER_NAME
                //CUSTOMER_CLASSIFICATION
                //PRODUCT
                //PRODUCT_TYPE
                //Request_Type
                //AMOUNT
                //CURRENCY
                //PRIMARY_OWNER
                //CASE_STATUS
                //LAST_ACTION_TAKEN_BY
                //MASTER_REFERENCE
                //FTI_FIRST_LINE_PARTY
                //TI_EVENT_STATUS
                //FTI_EVENT_CREATION_DATE

                entity.Property(e => e.EcmReference)
                   .HasMaxLength(64)
                   .HasColumnName("ECM_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CustomerClassification)
                   .HasMaxLength(1000)
                   .HasColumnName("CUSTOMER_CLASSIFICATION")
                   .UseCollation("Arabic_100_CI_AI");



                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.CaseCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CASE_CREATION_DATE");

                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("FTI_EVENT_CREATION_DATE");

                entity.Property(e => e.Currency)
                   .HasMaxLength(1000)
                   .IsUnicode(false)
                   .HasColumnName("CURRENCY")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseStatus)
                   .IsUnicode(false)
                   .HasColumnName("CASE_STATUS")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.RequestType)
                   .IsUnicode(false)
                   .HasColumnName("Request_Type")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.LastActionTakenBy)
                   .IsUnicode(false)
                   .HasColumnName("LAST_ACTION_TAKEN_BY")
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.MasterReference)
                   .IsUnicode(false)
                   .HasColumnName("MASTER_REFERENCE")
                   .UseCollation("Arabic_100_CI_AI");
                entity.Property(e => e.FtiFirstLineParty)
                   .IsUnicode(false)
                   .HasColumnName("FTI_FIRST_LINE_PARTY")
                   .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.BranchName)
                  .HasMaxLength(4000)
                  .IsUnicode(false)
                  .HasColumnName("BRANCH_NAME")
                  .UseCollation("Arabic_100_CI_AI");


                entity.Property(e => e.CustomerName)
                  .HasMaxLength(1000)
                  .IsUnicode(false)
                  .HasColumnName("CUSTOMER_NAME")
                  .UseCollation("Arabic_100_CI_AI");


                entity.Property(e => e.Product)
                   .HasMaxLength(4000)
                   .IsUnicode(false)
                   .HasColumnName("PRODUCT")
                   .UseCollation("Arabic_100_CI_AI");


                entity.Property(e => e.ProductType)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE")
                    .UseCollation("Arabic_100_CI_AI");



                entity.Property(e => e.PrimaryOwner)
                   .HasMaxLength(255)
                   .IsUnicode(false)
                   .HasColumnName("PRIMARY_OWNER")
                   .UseCollation("Arabic_100_CI_AI");



                entity.Property(e => e.EventStatus)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("TI_EVENT_STATUS")
                    .UseCollation("Arabic_100_CI_AI");


                // entity.Property(e => e.)




            });

            modelBuilder.Entity<ArtEcmPendingCases>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ECM_PENDING_CASES", "ART_DB");
                entity.Property(e => e.CaseRk)
                    .HasColumnName("case_rk")
                    .HasColumnType("numeric")
                    .IsRequired();
                entity.Property(e => e.ParentCaseId)
            .HasColumnName("PARENT_CASE_ID")
            .HasColumnType("nvarchar(64)")
            .IsRequired();

                entity.Property(e => e.SubCaseId)
                    .HasColumnName("SUB_CASE_ID")
                    .HasColumnType("nvarchar(64)");

                entity
                    .Property(e => e.BranchName)
                    .HasColumnName("BRANCH_NAME")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.CustomerName)
                    .HasColumnName("CUSTOMER_NAME")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.CustomerCIF)
                    .HasColumnName("CUSTOMER_CIF")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("float");

                entity
                    .Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.CaseType)
                    .HasColumnName("CASE_TYPE")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.ProductType)
                    .HasColumnName("PRODUCT_TYPE")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.EventName)
                    .HasColumnName("EVENT_NAME")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.Product)
                    .HasColumnName("PRODUCT")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.ParentCaseStatus)
                    .HasColumnName("PARENT_CASE_STATUS")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime")
                    .IsRequired();

                entity
                    .Property(e => e.CustomerClassification)
                    .HasColumnName("CUSTOMER_CLASSIFICATION")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ParentActionBy)
                    .HasColumnName("PARENT_ACTION_BY")
                    .HasColumnType("nvarchar(60)");

                entity.Property(e => e.ParentLastActionDate)
                    .HasColumnName("PARENT_LAST_ACTION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubLastActionDate)
                    .HasColumnName("SUB_LAST_ACTION_DATE")
                    .HasColumnType("datetime");
                entity.Property(e => e.LastActionTakenDate)
                    .HasColumnName("LAST_ACTION_TAKEN_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MasterReference)
                    .HasColumnName("MASTER_REFERENCE")
                    .HasColumnType("char(20)");

                entity.Property(e => e.TimeDifference)
                    .HasColumnName("TIME_DIFFERENCE")
                    .HasColumnType("nvarchar(100)");//TimeDifferenceSLA
                entity.Property(e => e.TimeDifferenceSLA)
                   .HasColumnName("TIME_DIFFERENCE_SLA")
                   .HasColumnType("nvarchar(100)");
                entity
                    .Property(e => e.SubCaseStatus)
                    .HasColumnName("SUB_CASE_STATUS")
                    .HasColumnType("nvarchar(4000)");

            });

            modelBuilder.Entity<ArtEcmSlaViolatedCasesTb>(entity =>
            {
                entity.HasNoKey();
                entity
           .ToTable("ART_ECM_SLA_VIOLATED_CASES_TB", "ART_DB"); // Replace with your actual table name

                entity
                    .Property(e => e.CaseRk)
                    .HasColumnName("case_rk")
                    .HasColumnType("numeric")
                    .IsRequired();

                entity
                    .Property(e => e.CaseId)
                    .HasColumnName("CASE_ID")
                    .HasColumnType("nvarchar(64)")
                    .IsRequired();

                entity
                    .Property(e => e.RelatedCaseId)
                    .HasColumnName("RELATED_CASE_ID")
                    .HasColumnType("nvarchar(64)");

                entity
                    .Property(e => e.BranchName)
                    .HasColumnName("BRANCH_NAME")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.CustomerName)
                    .HasColumnName("CUSTOMER_NAME")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.CustomerCIF)
                    .HasColumnName("CUSTOMER_CIF")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("float");

                entity
                    .Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.CaseType)
                    .HasColumnName("CASE_TYPE")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.ProductType)
                    .HasColumnName("PRODUCT_TYPE")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.EventName)
                    .HasColumnName("EVENT_NAME")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.Product)
                    .HasColumnName("PRODUCT")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.RequestStatus)
                    .HasColumnName("REQUEST_STATUS")
                    .HasColumnType("nvarchar(4000)");

                entity
                    .Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .IsRequired();

                entity
                    .Property(e => e.CustomerClassification)
                    .HasColumnName("CUSTOMER_CLASSIFICATION")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.LastActionBy)
                    .HasColumnName("LAST_ACTION_BY")
                    .HasColumnType("nvarchar(60)");

                entity
                    .Property(e => e.LastActionDate)
                    .HasColumnName("LAST_ACTION_DATE")
                    .HasColumnType("datetime");

                entity
                    .Property(e => e.MasterReference)
                    .HasColumnName("MASTER_REFERENCE")
                    .HasColumnType("char(20)");

                entity
                    .Property(e => e.ProdCd)
                    .HasColumnName("PROD_CD")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.DisplayName)
                    .HasColumnName("DISPLAY_NAME")
                    .HasColumnType("nvarchar(255)");

                entity
                    .Property(e => e.MlsToEscalation1)
                    .HasColumnName("MLS_TO_ESCALATION1")
                    .HasColumnType("int");

                entity
                    .Property(e => e.FormattedTime)
                    .HasColumnName("FORMATTEDTIME")
                    .HasColumnType("nvarchar(100)");
                entity
                    .Property(e => e.ViolatedTime)
                    .HasColumnName("VIOLATED_TIME")
                    .HasColumnType("nvarchar(100)");

                entity
                    .Property(e => e.TotalTime)
                    .HasColumnName("TOTAL_TIME")
                    .HasColumnType("int");

            });

            modelBuilder.Entity<ArtEcmAssignee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ECM_ASSIGNEE", "ART_DB");

                entity
            .Property(e => e.CaseRk)
            .HasColumnName("Case_Rk")
            .HasColumnType("numeric")
            .IsRequired();
                entity
                    .Property(e => e.CaseId)
                    .HasColumnName("Case_Id")
                    .HasColumnType("varchar(64)");
                entity
                    .Property(e => e.AssignedBy)
                    .HasColumnName("ASSIGNED_BY")
                    .HasColumnType("varchar(1000)");

                entity
                    .Property(e => e.Assignee)
                    .HasColumnName("ASSIGNEE")
                    .HasColumnType("varchar(60)")
                    .IsRequired();

                entity
                    .Property(e => e.AssignedTime)
                    .HasColumnName("ASSIGNED_TIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ArtFtiEndToEnd>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("ART_FTI_END_TO_END", "ART_DB");
            entity.Property(e => e.EcmReference)
               .HasMaxLength(64)
               .HasColumnName("ECM_REFERENCE")
               .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.CustomerClassification)
               .HasMaxLength(1000)
               .HasColumnName("CUSTOMER_CLASSIFICATION")
               .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.Assignee)
              .HasMaxLength(60)
              .IsUnicode(false)
              .HasColumnName("ASSIGNEE")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.AssignedBy)
              .HasMaxLength(1000)
              .IsUnicode(false)
              .HasColumnName("ASSIGNED_BY")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.AssignedTime)
               .HasColumnType("datetime")
              .HasColumnName("ASSIGNED_TIME");

            entity.Property(e => e.UnAssignee)
              .HasMaxLength(60)
              .IsUnicode(false)
              .HasColumnName("UNASSIGNEE")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.UnAssignedBy)
              .HasMaxLength(1000)
              .IsUnicode(false)
              .HasColumnName("UNASSIGNED_BY")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.UnAssignedTime)
               .HasColumnType("datetime")
              .HasColumnName("UNASSIGNED_TIME");

            entity.Property(e => e.EcmEventStep)
              .HasMaxLength(256)
              .IsUnicode(false)
              .HasColumnName("ECM_EVENT_STEP")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.EcmEventCreatedBy)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("ECM_EVENT_CREATED_BY")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.EcmEventCreatedDate)
               .HasColumnType("datetime")
              .HasColumnName("ECM_EVENT_CREATED_DATE");

            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.CaseCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("CASE_CREATION_DATE");
            entity.Property(e => e.EventCreationDate)
                .HasColumnType("date")
                .HasColumnName("EVENT_CREATION_DATE");
            entity.Property(e => e.StartedTime)
               .HasColumnType("datetime2")
               .HasColumnName("STARTED_TIME");
            entity.Property(e => e.LastModTime)
               .HasColumnType("datetime2")
               .HasColumnName("LAST_MOD_TIME");
            entity.Property(e => e.BranchName)
              .HasMaxLength(4000)
              .IsUnicode(false)
              .HasColumnName("BRANCH_NAME")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.CustomerName)
              .HasMaxLength(1000)
              .IsUnicode(false)
              .HasColumnName("CUSTOMER_NAME")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.Product)
               .HasMaxLength(4000)
               .IsUnicode(false)
               .HasColumnName("Product")
               .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.ProductType)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_TYPE")
                .UseCollation("Arabic_100_CI_AI");


            entity.Property(e => e.PrimaryOwner)
               .HasMaxLength(255)
               .IsUnicode(false)
               .HasColumnName("PRIMARY_OWNER")
               .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.FtiReference)
              .HasMaxLength(20)
              .IsUnicode(false)
              .HasColumnName("FTI_REFERENCE")
              .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.Currency)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CURRENCY")
                .UseCollation("Arabic_100_CI_AI");

            entity.Property(e => e.EventName)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("Event_Name")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.EventStatus)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Event_Status")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.MasterAssignedTo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Master_Assigned_To")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.EventSteps)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("Event_Steps")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.StepStatus)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("STEP_STATUS")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.TimeDifference)
                .HasMaxLength(96)
                .IsUnicode(false)
                .HasColumnName("TIMEDIFFERENCE")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.LastModUser)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LAST_MOD_USER")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.FirstLineParty)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FIRST_LINE_PARTY")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.TradeInstructions)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("TRADE_INSTRUCTIONS")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.FirstLineInstructions)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("FIRST_LINE_INSTRUCTIONS")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.CaseComments)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("CASE_COMMENTS")
                .UseCollation("Arabic_100_CI_AI");
            entity.Property(e => e.ParentCaseId)
               .HasMaxLength(4000)
               .IsUnicode(false)
               .HasColumnName("PARENT_CASE_ID")
               .UseCollation("Arabic_100_CI_AI");
        });
        }

        public void OnKYCModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}














