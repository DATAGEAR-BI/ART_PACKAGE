using Data.Data;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public class OracleModelCreatingStrategy : IModelCreatingStrategy
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART");
            //ECM
            modelBuilder.Entity<ArtHomeCasesDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_DATE");

                entity.Property(e => e.Day)
                    .HasColumnType("int")
                    .HasColumnName("DAY");

                entity.Property(e => e.Month)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("MONTH");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");

                entity.Property(e => e.Year)
                    .HasColumnType("int")
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<ArtHomeCasesStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_STATUS");

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

                entity.ToView("ART_HOME_CASES_TYPES");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");
            });

            modelBuilder.Entity<ArtSystemPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SYSTEM_PERFORMANCE");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DESC");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.ClientName)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

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

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HITS_COUNT");

                entity.Property(e => e.IdentityNum)
                    .IsUnicode(false)
                    .HasColumnName("IDENTITY_NUM");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INVESTR_USER_ID");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Priority)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.SwiftMessage)
                    .HasColumnType("CLOB")
                    .HasColumnName("SWIFT_MESSAGE");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT_REFERENCE");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TRANSACTION_AMOUNT");

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
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");
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

            modelBuilder.Entity<ArtUserPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_USER_PERFORMANCE", "ART");

                entity.Property(e => e.Action)
                    .HasMaxLength(256)
                    .HasColumnName("ACTION");

                entity.Property(e => e.ActionUser)
                    .HasMaxLength(60)
                    .HasColumnName("ACTION_USER");

                entity.Property(e => e.AsssignedTime)

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
                    .HasColumnName("RELEASED_DATE");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.ValidFromDate)

                    .HasColumnName("VALID_FROM_DATE");
            });

            //AML
            modelBuilder.Entity<ArtHomeAlertsPerDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_ALERTS_PER_DATE".ToUpper(), "ART");

                entity.Property(e => e.Month).HasMaxLength(4000);

                entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_ALerts".ToUpper());
                entity.Property(e => e.Day)
                   .HasColumnName("DAY");

                entity.Property(e => e.Month)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("MONTH");

                entity.Property(e => e.NumberOfAlerts)
                    .HasColumnName("NUMBER_OF_ALERTS");
                entity.Property(e => e.Year)
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<ArtHomeAlertsPerStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_ALERTS_PER_STATUS".ToUpper(), "ART");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertsCount).HasColumnName("Alerts_Count".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_Number_Of_Accounts".ToUpper(), "ART");

                entity.Property(e => e.NumberOfAccounts).HasColumnName("Number_Of_Accounts".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_NUMBER_OF_CUSTOMERS".ToUpper(), "ART");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfHighRiskCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_NUMBER_OF_High_Risk_CUSTS".ToUpper(), "ART");

                entity.Property(e => e.NumberOfHighRiskCustomers).HasColumnName("Number_Of_High_Risk_Customers".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfPepCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_NUMBER_OF_PEP_CUSTOMERS".ToUpper(), "ART");

                entity.Property(e => e.NumberOfPepCustomers).HasColumnName("Number_Of_PEP_Customers".ToUpper());
            });

            modelBuilder.Entity<ArtAmlTriageView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_TRIAGE_VIEW");

                entity.Property(e => e.AgeOldestAlert)
                    .HasPrecision(4)
                    .HasColumnName("AGE_OLDEST_ALERT");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("NUMBER(15,3)")
                    .HasColumnName("AGGREGATE_AMT");

                entity.Property(e => e.AlertedEntityLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_LEVEL");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.AlertsCnt)
                    .HasPrecision(4)
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
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
                    .IsUnicode(false)
                    .HasColumnName("RISK_SCORE");
            });
            modelBuilder.Entity<ArtAmlAlertDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_ALERT_DETAIL_VIEW");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTUAL_VALUES_TEXT");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_DESCRIPTION");

                entity.Property(e => e.AlertId)
                    .HasPrecision(12)
                    .HasColumnName("ALERT_ID");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertSubCat)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_SUB_CAT");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_TYPE_CD");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.InvestigationDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INVESTIGATION_DAYS");

                entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasPrecision(3)
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
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND");

                entity.Property(e => e.ReportCloseRsn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_CLOSE_RSN");

                entity.Property(e => e.RunDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_DATE");

                entity.Property(e => e.ScenarioId)
                    .HasPrecision(12)
                    .HasColumnName("SCENARIO_ID");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_NAME");
            });
            modelBuilder.Entity<ArtAmlCustomersDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_CUSTOMERS_DETAILS_VIEW");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLG")
                    .IsFixedLength();

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasPrecision(10)
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
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
                    .HasColumnName("CITY_NAME");

                entity.Property(e => e.CustomerDateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("CUSTOMER_DATE_OF_BIRTH");

                entity.Property(e => e.CustomerIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_IDENTIFICATION_ID");

                entity.Property(e => e.CustomerIdentificationType)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_IDENTIFICATION_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CUSTOMER_SINCE_DATE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.CustomerTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TAX_ID");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NUMBER");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_NAME");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                entity.Property(e => e.GovernorateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GOVERNORATE_NAME");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.IsEmployee)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_EMPLOYEE")
                    .IsFixedLength();

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(35)
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
                    .HasPrecision(10)
                    .HasColumnName("NET_WORTH_AMOUNT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORG_IND")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

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
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

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
            modelBuilder.Entity<ArtAmlCaseDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_CASE_DETAILS_VIEW");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CaseCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CATEGORY");

                entity.Property(e => e.CaseId)
                    .HasPrecision(12)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CasePriority)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_PRIORITY");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseSubCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_SUB_CATEGORY");

                entity.Property(e => e.ClosedDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSED_DATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.EntityLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_LEVEL");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
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
            modelBuilder.Entity<ArtAmlHighRiskCustView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_HIGH_RISK_CUST_VIEW");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
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
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("PARTY_DATE_OF_BIRTH");

                entity.Property(e => e.PartyIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_ID");

                entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_TYPE_DESC")
                    .IsFixedLength();

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
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND");

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
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

                entity.ToView("ART_RISK_ASSESSMENT_VIEW");

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
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
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
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.ProposedRiskClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROPOSED_RISK_CLASS");

                entity.Property(e => e.RiskAssessmentDuration)
                    .HasPrecision(3)
                    .HasColumnName("RISK_ASSESSMENT_DURATION");

                entity.Property(e => e.RiskAssessmentId)
                    .HasPrecision(12)
                    .HasColumnName("RISK_ASSESSMENT_ID");

                entity.Property(e => e.RiskClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS");

                entity.Property(e => e.RiskStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_STATUS");

                entity.Property(e => e.VersionNumber)
                    .HasPrecision(10)
                    .HasColumnName("VERSION_NUMBER");
            });

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

            //for sake for build => toChange when convert to SqlServer
            modelBuilder.Entity<ArtSystemPreformance>(entity =>
            {
                entity.HasNoKey();
            });
        }

        public void OnSegmentionModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
