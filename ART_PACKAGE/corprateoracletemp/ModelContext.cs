using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ART_PACKAGE.corprateoracletemp
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

        public virtual DbSet<ArtAuditCorporateView> ArtAuditCorporateViews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=ART;Password=ART1;Data Source=dbsast01.testdr.faisal.com.eg:1521/saslive;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<ArtAuditCorporateView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AUDIT_CORPORATE_VIEW");

                entity.Property(e => e.ActivityAmount)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_AMOUNT");

                entity.Property(e => e.ActivityAmountCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_AMOUNT_CURRENCY");

                entity.Property(e => e.ActivityEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ACTIVITY_END_DATE");

                entity.Property(e => e.ActivityStartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ACTIVITY_START_DATE");

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE");

                entity.Property(e => e.ActivityTypeDtls)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE_DTLS");

                entity.Property(e => e.ActivityTypeSub)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE_SUB");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualNetIncomeCd)
                    .HasPrecision(19)
                    .HasColumnName("ANNUAL_NET_INCOME_CD");

                entity.Property(e => e.BankingOrCorporate)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BANKING_OR_CORPORATE");

                entity.Property(e => e.BankingOrOtherRef)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKING_OR_OTHER_REF");

                entity.Property(e => e.BudgetDate1)
                    .HasColumnType("DATE")
                    .HasColumnName("BUDGET_DATE_1");

                entity.Property(e => e.BudgetDate2)
                    .HasColumnType("DATE")
                    .HasColumnName("BUDGET_DATE_2");

                entity.Property(e => e.BudgetDate3)
                    .HasColumnType("DATE")
                    .HasColumnName("BUDGET_DATE_3");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_CODE");

                entity.Property(e => e.CalculateZakahFlag)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CALCULATE_ZAKAH_FLAG");

                entity.Property(e => e.Capital1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_1");

                entity.Property(e => e.Capital2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_2");

                entity.Property(e => e.Capital3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_3");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CharityDonationsInd)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CHARITY_DONATIONS_IND");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_REASON_ID");

                entity.Property(e => e.CommercialName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIAL_NAME");

                entity.Property(e => e.CommercialNameEn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIAL_NAME_EN");

                entity.Property(e => e.CompanyStock)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_STOCK");

                entity.Property(e => e.CompanyStockName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_STOCK_NAME");

                entity.Property(e => e.CorporateName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CORPORATE_NAME");

                entity.Property(e => e.CorporateNameEn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CORPORATE_NAME_EN");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_REFERENCE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.DateOfBudget)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DATE_OF_BUDGET");

                entity.Property(e => e.DealAbrdBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEAL_ABRD_BANK_DETAILS");

                entity.Property(e => e.DealtBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALT_BANK_DETAILS");

                entity.Property(e => e.DefaultBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicActivityCode5)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_ACTIVITY_CODE5");

                entity.Property(e => e.FfiType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FFI_TYPE");

                entity.Property(e => e.FinancialStartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FINANCIAL_START_DATE");

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FOREIGN_CONSULATE_EMBASSY_IND");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.Giin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GIIN");

                entity.Property(e => e.GovOrgInd)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("GOV_ORG_IND");

                entity.Property(e => e.HeadQuarterCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("HEAD_QUARTER_COUNTRY");

                entity.Property(e => e.HoldingCorporation)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("HOLDING_CORPORATION");

                entity.Property(e => e.HoldingCorporationCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOLDING_CORPORATION_CD");

                entity.Property(e => e.IdIssueCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ID_ISSUE_COUNTRY");

                entity.Property(e => e.IdentExpiryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("IDENT_EXPIRY_DATE");

                entity.Property(e => e.IdentIssueDate)
                    .HasColumnType("DATE")
                    .HasColumnName("IDENT_ISSUE_DATE");

                entity.Property(e => e.IdentNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_NUMBER");

                entity.Property(e => e.IdentType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_TYPE");

                entity.Property(e => e.IncorporationCountryCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_COUNTRY_CODE");

                entity.Property(e => e.IncorporationDate)
                    .HasPrecision(6)
                    .HasColumnName("INCORPORATION_DATE");

                entity.Property(e => e.IncorporationLegalForm)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_LEGAL_FORM");

                entity.Property(e => e.IncorporationState)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_STATE");

                entity.Property(e => e.Industry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY");

                entity.Property(e => e.InvestmentBalance)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INVESTMENT_BALANCE");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastQueryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalFormOthers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_FORM_OTHERS");

                entity.Property(e => e.LegalFormSub)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_FORM_SUB");

                entity.Property(e => e.LegalStepMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_MAIN_CODE");

                entity.Property(e => e.LegalStepSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_SUB_CODE");

                entity.Property(e => e.LimitsAmount)
                    .HasPrecision(19)
                    .HasColumnName("LIMITS_AMOUNT");

                entity.Property(e => e.LimitsAmountCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LIMITS_AMOUNT_CURRENCY");

                entity.Property(e => e.MainLegalForm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MAIN_LEGAL_FORM");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NAME_LANGUAGE");

                entity.Property(e => e.NationalityCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_COUNTRY");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.NoOfEmployees)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NO_OF_EMPLOYEES");

                entity.Property(e => e.NonProfitOrganization)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORGANIZATION");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PaidUpCapitalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAID_UP_CAPITAL_AMOUNT");

                entity.Property(e => e.PaidUpCapitalCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PAID_UP_CAPITAL_CURRENCY");

                entity.Property(e => e.ReferenceEmployeeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE_EMPLOYEE_ID");

                entity.Property(e => e.RegExpiryDate)
                    .HasPrecision(6)
                    .HasColumnName("REG_EXPIRY_DATE");

                entity.Property(e => e.RegNumberCity)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REG_NUMBER_CITY");

                entity.Property(e => e.RegNumberLastDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REG_NUMBER_LAST_DATE");

                entity.Property(e => e.RegNumberOffice)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REG_NUMBER_OFFICE");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRATION_NUMBER");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CODE");

                entity.Property(e => e.RiskReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_REASON");

                entity.Property(e => e.RiskWeight)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_WEIGHT");

                entity.Property(e => e.SalesBasis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_BASIS");

                entity.Property(e => e.SalesVolume1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_1");

                entity.Property(e => e.SalesVolume2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_2");

                entity.Property(e => e.SalesVolume3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_3");

                entity.Property(e => e.SizeOfSales)
                    .HasPrecision(19)
                    .HasColumnName("SIZE_OF_SALES");

                entity.Property(e => e.SizeOfTransaction)
                    .HasPrecision(19)
                    .HasColumnName("SIZE_OF_TRANSACTION");

                entity.Property(e => e.TaxIdNum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID_NUM");

                entity.Property(e => e.Title)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.TotalNoOfUnits)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TOTAL_NO_OF_UNITS");

                entity.Property(e => e.TradeAddDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRADE_ADD_DATE");

                entity.Property(e => e.TypeOfBusiness)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_OF_BUSINESS");

                entity.Property(e => e.TypeOfBusinessOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_OF_BUSINESS_OTHER");

                entity.Property(e => e.UnderEstablishment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNDER_ESTABLISHMENT");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.WomenShare)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("WOMEN_SHARE");

                entity.Property(e => e.WorthCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WORTH_CODE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasColumnType("DATE")
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
