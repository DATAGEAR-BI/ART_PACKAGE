using Data.Data;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //KYC

            modelBuilder.Entity<ArtAuditCorporateView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AUDIT_CORPORATE_VIEW");

                entity.Property(e => e.ActivityAmount)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_AMOUNT");

                entity.Property(e => e.ActivityAmountCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_AMOUNT_CURRENCY");

                entity.Property(e => e.ActivityEndDate)
                    .HasPrecision(6)
                    .HasColumnName("ACTIVITY_END_DATE");

                entity.Property(e => e.ActivityStartDate)
                    .HasPrecision(6)
                    .HasColumnName("ACTIVITY_START_DATE");

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE");

                entity.Property(e => e.ActivityTypeDtls)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE_DTLS");

                entity.Property(e => e.ActivityTypeSub)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE_SUB");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualNetIncomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ANNUAL_NET_INCOME_CD");

                entity.Property(e => e.BankingOrCorporate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKING_OR_CORPORATE");

                entity.Property(e => e.BankingOrOtherRef)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKING_OR_OTHER_REF");

                entity.Property(e => e.BudgetDate1)
                    .HasPrecision(6)
                    .HasColumnName("BUDGET_DATE_1");

                entity.Property(e => e.BudgetDate2)
                    .HasPrecision(6)
                    .HasColumnName("BUDGET_DATE_2");

                entity.Property(e => e.BudgetDate3)
                    .HasPrecision(6)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_1");

                entity.Property(e => e.Capital2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_2");

                entity.Property(e => e.Capital3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_3");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CharityDonationsInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITY_DONATIONS_IND");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicActivityCode5)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_ACTIVITY_CODE5");

                entity.Property(e => e.FfiType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FFI_TYPE");

                entity.Property(e => e.FinancialStartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FINANCIAL_START_DATE");

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FOREIGN_CONSULATE_EMBASSY_IND");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.Giin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GIIN");

                entity.Property(e => e.GovOrgInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GOV_ORG_IND");

                entity.Property(e => e.HeadQuarterCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HEAD_QUARTER_COUNTRY");

                entity.Property(e => e.HoldingCorporation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOLDING_CORPORATION");

                entity.Property(e => e.HoldingCorporationCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOLDING_CORPORATION_CD");

                entity.Property(e => e.IdIssueCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID_ISSUE_COUNTRY");

                entity.Property(e => e.IdentExpiryDate)
                    .HasPrecision(6)
                    .HasColumnName("IDENT_EXPIRY_DATE");

                entity.Property(e => e.IdentIssueDate)
                    .HasPrecision(6)
                    .HasColumnName("IDENT_ISSUE_DATE");

                entity.Property(e => e.IdentNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_NUMBER");

                entity.Property(e => e.IdentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_TYPE");

                entity.Property(e => e.IncorporationCountryCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_COUNTRY_CODE");

                entity.Property(e => e.IncorporationDate)
                    .HasPrecision(6)
                    .HasColumnName("INCORPORATION_DATE");

                entity.Property(e => e.IncorporationLegalForm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_LEGAL_FORM");

                entity.Property(e => e.IncorporationState)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_STATE");

                entity.Property(e => e.Industry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY");

                entity.Property(e => e.InvestmentBalance)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INVESTMENT_BALANCE");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastQueryDate)
                    .HasPrecision(6)
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalFormOthers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_FORM_OTHERS");

                entity.Property(e => e.LegalFormSub)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LIMITS_AMOUNT_CURRENCY");

                entity.Property(e => e.MainLegalForm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MAIN_LEGAL_FORM");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORGANIZATION");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PaidUpCapitalAmount)
                    .HasPrecision(19)
                    .HasColumnName("PAID_UP_CAPITAL_AMOUNT");

                entity.Property(e => e.PaidUpCapitalCurrency)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REG_NUMBER_CITY");

                entity.Property(e => e.RegNumberLastDate)
                    .HasPrecision(6)
                    .HasColumnName("REG_NUMBER_LAST_DATE");

                entity.Property(e => e.RegNumberOffice)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REG_NUMBER_OFFICE");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRATION_NUMBER");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_1");

                entity.Property(e => e.SalesVolume2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_2");

                entity.Property(e => e.SalesVolume3)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.TotalNoOfUnits)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TOTAL_NO_OF_UNITS");

                entity.Property(e => e.TradeAddDate)
                    .HasPrecision(6)
                    .HasColumnName("TRADE_ADD_DATE");

                entity.Property(e => e.TypeOfBusiness)
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WOMEN_SHARE");

                entity.Property(e => e.WorthCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WORTH_CODE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasPrecision(6)
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            modelBuilder.Entity<ArtAuditIndividualsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AUDIT_INDIVIDUALS_VIEW");

                entity.Property(e => e.AKA)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("A_K_A");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualIncomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ANNUAL_INCOME_CD");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_CODE");

                entity.Property(e => e.BusinessSector)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_SECTOR");

                entity.Property(e => e.BusinessSectorOthers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_SECTOR_OTHERS");

                entity.Property(e => e.CalculateZakahFlag)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CALCULATE_ZAKAH_FLAG");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_ID");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CbRiskRateOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE_OTHER");

                entity.Property(e => e.CharityFlag)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITY_FLAG");

                entity.Property(e => e.CitizenOrResident)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CITIZEN_OR_RESIDENT");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_REASON_ID");

                entity.Property(e => e.ClosingReasonIdOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_REASON_ID_OTHER");

                entity.Property(e => e.CompanySalesAmountPerYear)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_SALES_AMOUNT_PER_YEAR");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DealAbrdBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEAL_ABRD_BANK_DETAILS");

                entity.Property(e => e.DealtBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALT_BANK_DETAILS");

                entity.Property(e => e.DefaultBranch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_MAIN_CODE");

                entity.Property(e => e.EconomicSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_SUB_CODE");

                entity.Property(e => e.EducationId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDUCATION_ID");

                entity.Property(e => e.EducationIdOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDUCATION_ID_OTHER");

                entity.Property(e => e.EmployedOrBusiness)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYED_OR_BUSINESS");

                entity.Property(e => e.EmployeeIndicator)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_INDICATOR");

                entity.Property(e => e.EmployerBusinessAdrs)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_ADRS");

                entity.Property(e => e.EmployerBusinessCity)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_CITY");

                entity.Property(e => e.EmployerBusinessCtry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_CTRY");

                entity.Property(e => e.EmployerBusinessName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_NAME");

                entity.Property(e => e.EmployerBusinessState)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_STATE");

                entity.Property(e => e.EmployerBusinessTown)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_TOWN");

                entity.Property(e => e.EmployerCountryPhoneCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_COUNTRY_PHONE_CODE");

                entity.Property(e => e.EmployerPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE");

                entity.Property(e => e.EmploymentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYMENT_TYPE");

                entity.Property(e => e.ExpenseIsoCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXPENSE_ISO_CURRENCY");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.FirstNameEng)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME_ENG");

                entity.Property(e => e.FullNameAr)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME_AR");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME_EN");

                entity.Property(e => e.GenderCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GENDER_CD");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.HomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOME_CD");

                entity.Property(e => e.IncomeIsoCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCOME_ISO_CURRENCY");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LastNameEng)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME_ENG");

                entity.Property(e => e.LastQueryDate)
                    .HasPrecision(6)
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_MAIN_CODE");

                entity.Property(e => e.LegalStepDate)
                    .HasPrecision(6)
                    .HasColumnName("LEGAL_STEP_DATE");

                entity.Property(e => e.LegalStepMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_MAIN_CODE");

                entity.Property(e => e.LegalStepSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_SUB_CODE");

                entity.Property(e => e.LegalSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_SUB_CODE");

                entity.Property(e => e.MaritalStatusCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS_CD");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.MiddleNameEng)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME_ENG");

                entity.Property(e => e.MonthExpense)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_EXPENSE");

                entity.Property(e => e.MonthIncome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_INCOME");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME_LANGUAGE");

                entity.Property(e => e.NationalityCode1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_CODE1");

                entity.Property(e => e.NationalityCode2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_CODE2");

                entity.Property(e => e.NationalityCode3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_CODE3");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.NumberOfDependents)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMBER_OF_DEPENDENTS");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION");

                entity.Property(e => e.OccupationDtl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DTL");

                entity.Property(e => e.OpeningReasonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPENING_REASON_ID");

                entity.Property(e => e.OpeningReasonIdOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPENING_REASON_ID_OTHER");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PepIndicator)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PEP_INDICATOR");

                entity.Property(e => e.PepIndicatorDtls)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PEP_INDICATOR_DTLS");

                entity.Property(e => e.PepIndicatorOth)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PEP_INDICATOR_OTH");

                entity.Property(e => e.RaceId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RACE_ID");

                entity.Property(e => e.ReferredPersonAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERRED_PERSON_ADDRESS");

                entity.Property(e => e.ReferredPersonPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERRED_PERSON_PHONE");

                entity.Property(e => e.RelationToBankCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELATION_TO_BANK_CODE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.ResidenceCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY");

                entity.Property(e => e.RiskClassValue)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS_VALUE");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CODE");

                entity.Property(e => e.RiskCodeOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CODE_OTHER");

                entity.Property(e => e.RiskReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_REASON");

                entity.Property(e => e.SectorAnalysesCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SECTOR_ANALYSES_CODE");

                entity.Property(e => e.SictorCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SICTOR_CODE");

                entity.Property(e => e.SourceOfIncomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_OF_INCOME_CD");

                entity.Property(e => e.SourceOfIncomeOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_OF_INCOME_OTHER");

                entity.Property(e => e.SpouseBusiness)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSE_BUSINESS");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSE_NAME");

                entity.Property(e => e.TaxRegulationCtryCd1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_CTRY_CD1");

                entity.Property(e => e.TaxRegulationCtryCd2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_CTRY_CD2");

                entity.Property(e => e.TaxRegulationCtryCd3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_CTRY_CD3");

                entity.Property(e => e.TaxRegulationTin1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_TIN1");

                entity.Property(e => e.TaxRegulationTin2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_TIN2");

                entity.Property(e => e.TaxRegulationTin3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_TIN3");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.VisaExpirationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VISA_EXPIRATION_DATE");

                entity.Property(e => e.VisaType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VISA_TYPE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasPrecision(6)
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            modelBuilder.Entity<ArtKycExpiredId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_EXPIRED_ID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.IdExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ID_EXPIRE_DATE");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");
            });

            modelBuilder.Entity<ArtKycHighExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_EXPIRED");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycHighOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_ONE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycHighThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_THREE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycHighTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_TWO_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_EXPIRED");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_ONE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_THREE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_TWO_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_EXPIRED");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_ONE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_THREE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_TWO_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycSummaryByRisk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_SUMMARY_BY_RISK");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.NumberOfNotUpdatedKyc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_NOT_UPDATED_KYC");

                entity.Property(e => e.NumberOfUpdatedKyc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_UPDATED_KYC");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Type)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });
            //FTI
            modelBuilder.Entity<ArtTiAcpostingsAccReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ACPOSTINGS_ACC_REPORT");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_TYPE");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_NO")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM");

                entity.Property(e => e.DrCrFlg)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DR_CR_FLG")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.Mainbanking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MAINBANKING")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.PostAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT");

                entity.Property(e => e.PostAmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT_EGP");

                entity.Property(e => e.Shortname)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Spsk)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SPSK");

                entity.Property(e => e.Valuedate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUEDATE");
            });

            modelBuilder.Entity<ArtTiAcpostingsCustReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ACPOSTINGS_CUST_REPORT");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_TYPE");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_NO")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DrCrFlg)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DR_CR_FLG")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.Mainbanking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MAINBANKING")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.PostAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT");

                entity.Property(e => e.PostAmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT_EGP");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME")
                    .IsFixedLength();

                entity.Property(e => e.Spsk)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SPSK");

                entity.Property(e => e.Valuedate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUEDATE");
            });

            modelBuilder.Entity<ArtTiActivityReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ACTIVITY_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Address12)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS12")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BaseStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BASE_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm12)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM12")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.EventStatus)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STATUS");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Gfcun12)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN12")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref12)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF12")
                    .IsFixedLength();

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("START_TIME")
                    .IsFixedLength();

                entity.Property(e => e.Started)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("STARTED");

                entity.Property(e => e.StartedFilter)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTED_FILTER");

                entity.Property(e => e.Stepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STEPDESCR");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBank12)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK12")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch12)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH12")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr12)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR12")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc12)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC12")
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("TEAM");

                entity.Property(e => e.Touched)
                    .HasColumnType("DATE")
                    .HasColumnName("TOUCHED");
            });

            modelBuilder.Entity<ArtTiAmortizationReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_Amortization_Report");

                entity.Property(e => e.AccPeriod)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ACC_PERIOD");

                entity.Property(e => e.AccrueAmt)
                    .HasPrecision(15)
                    .HasColumnName("ACCRUE_AMT");

                entity.Property(e => e.AccrueCcy)
                    .IsUnicode(false)
                    .HasColumnName("ACCRUE_CCY");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.C8ced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("C8CED")
                    .IsFixedLength();

                entity.Property(e => e.ChargeAmt)
                    .HasPrecision(15)
                    .HasColumnName("CHARGE_AMT");

                entity.Property(e => e.ChargeCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Chgpextraday)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("CHGPEXTRADAY");

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DailyAcc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DAILY_ACC");

                entity.Property(e => e.Descr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.EndDat)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DAT");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(43)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Firststart)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTSTART")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.PeriodChg)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PERIOD_CHG");

                entity.Property(e => e.Periodic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PERIODIC")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF");

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDat)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DAT");

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiChargesByCustReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_CHARGES_BY_CUST_REPORT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Hvbad1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("HVBAD1");

                entity.Property(e => e.Longname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LONGNAME");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.TotoalBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalClaimedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_CLAIMED_CHG_DUE");

                entity.Property(e => e.TotoalOutstandingChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_OUTSTANDING_CHG_DUE");

                entity.Property(e => e.TotoalPaidChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PAID_CHG_DUE");

                entity.Property(e => e.TotoalPeriodicBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PERIODIC_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalWaivedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_WAIVED_CHG_DUE");
            });

            modelBuilder.Entity<ArtTiChargesByMasterReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_CHARGES_BY_MASTER_REPORT");

                entity.Property(e => e.Hvbad1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("HVBAD1");

                entity.Property(e => e.Longname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LONGNAME");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.TotoalBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalClaimedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_CLAIMED_CHG_DUE");

                entity.Property(e => e.TotoalOutstandingChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_OUTSTANDING_CHG_DUE");

                entity.Property(e => e.TotoalPaidChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PAID_CHG_DUE");

                entity.Property(e => e.TotoalPeriodicBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PERIODIC_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalWaivedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_WAIVED_CHG_DUE");
            });

            modelBuilder.Entity<ArtTiChargesDetailsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_CHARGES_DETAILS_REPORT");

                entity.Property(e => e.Action)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.ChgCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHG_CCY")
                    .IsFixedLength();

                entity.Property(e => e.ChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHG_DUE");

                entity.Property(e => e.ChgDueEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHG_DUE_EGP");

                entity.Property(e => e.ChgbasAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHGBAS_AMT");

                entity.Property(e => e.ChgbasAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHGBAS_AMT_EGP");

                entity.Property(e => e.ChgbasCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHGBAS_CCY")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Hvbad1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("HVBAD1");

                entity.Property(e => e.Longname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LONGNAME");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.ParticChg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTIC_CHG")
                    .IsFixedLength();

                entity.Property(e => e.Reduction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REDUCTION")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX1")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL1");

                entity.Property(e => e.SchAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT");

                entity.Property(e => e.SchAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT_EGP");

                entity.Property(e => e.SchCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCH_CCY")
                    .IsFixedLength();

                entity.Property(e => e.SchCcySei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SCH_CCY_SEI")
                    .IsFixedLength();

                entity.Property(e => e.SchCcySpt)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("SCH_CCY_SPT");

                entity.Property(e => e.SchRate)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("SCH_RATE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("START_TIME")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.TaxAmt)
                    .HasPrecision(15)
                    .HasColumnName("TAX_AMT");

                entity.Property(e => e.TaxCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TAX_CCY")
                    .IsFixedLength();

                entity.Property(e => e.TaxFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TAX_FOR")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiDiaryExceptionsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_DIARY_EXCEPTIONS_REPORT");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_CODE")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NoteText)
                    .IsUnicode(false)
                    .HasColumnName("NOTE_TEXT");

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.Sovaluecode)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUECODE");

                entity.Property(e => e.Sovaluedesc)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUEDESC");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEAM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiEcmTransactionsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ECM_TRANSACTIONS_REPORT");

                entity.Property(e => e.Applicantname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTNAME");

                entity.Property(e => e.Behalfofbranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BEHALFOFBRANCH");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STAT_CD");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Eventname)
                    .IsUnicode(false)
                    .HasColumnName("EVENTNAME");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER");

                entity.Property(e => e.Product)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Producttype)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTTYPE");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");
            });

            modelBuilder.Entity<ArtTiInterfaceDetailsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_INTERFACE_DETAILS_REPORT");

                entity.Property(e => e.Gz361d1f)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZ361D1F")
                    .IsFixedLength();

                entity.Property(e => e.Gz361mdt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361MDT");

                entity.Property(e => e.Gz361ncd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361NCD");

                entity.Property(e => e.Gz361rat)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361RAT");

                entity.Property(e => e.Gz361sdt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361SDT");

                entity.Property(e => e.Gzamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZAMT");

                entity.Property(e => e.GzamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZAMT_EGP");

                entity.Property(e => e.Gzbrnm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GZBRNM")
                    .IsFixedLength();

                entity.Property(e => e.Gzccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZCCY");

                entity.Property(e => e.Gzcus1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GZCUS1");

                entity.Property(e => e.Gzdlp)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZDLP")
                    .IsFixedLength();

                entity.Property(e => e.Gzg331ext)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331EXT");

                entity.Property(e => e.Gzg331pam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331PAM");

                entity.Property(e => e.Gzg331pccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG331PCCY");

                entity.Property(e => e.Gzg331pced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG331PCED");

                entity.Property(e => e.Gzg331psd1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZG331PSD1");

                entity.Property(e => e.Gzg331purd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331PURD");

                entity.Property(e => e.Gzg331sam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331SAM");

                entity.Property(e => e.Gzg331sccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG331SCCY");

                entity.Property(e => e.Gzg331sced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG331SCED");

                entity.Property(e => e.Gzg331sled)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331SLED");

                entity.Property(e => e.Gzg361ced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG361CED")
                    .IsFixedLength();

                entity.Property(e => e.Gzg461ext)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461EXT");

                entity.Property(e => e.Gzg461pccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG461PCCY");

                entity.Property(e => e.Gzg461pced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG461PCED");

                entity.Property(e => e.Gzg461psd1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZG461PSD1");

                entity.Property(e => e.Gzg461sccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG461SCCY");

                entity.Property(e => e.Gzg461sced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG461SCED");

                entity.Property(e => e.Gzg461tpam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TPAM");

                entity.Property(e => e.Gzg461tprd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TPRD");

                entity.Property(e => e.Gzg461tsam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TSAM");

                entity.Property(e => e.Gzg461tsld)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TSLD");

                entity.Property(e => e.Gzg891acc)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZG891ACC");

                entity.Property(e => e.Gzg891ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG891CCY");

                entity.Property(e => e.Gzg891ced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG891CED");

                entity.Property(e => e.Gzg891dte)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG891DTE");

                entity.Property(e => e.Gzh97nacc)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NACC");

                entity.Property(e => e.Gzh97nact)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NACT");

                entity.Property(e => e.Gzh97nactc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NACTC");

                entity.Property(e => e.Gzh97nanmd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NANMD");

                entity.Property(e => e.Gzh97nboacc)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NBOACC");

                entity.Property(e => e.Gzh97nca2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NCA2");

                entity.Property(e => e.Gzh97nced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NCED");

                entity.Property(e => e.Gzh97nctp1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NCTP1");

                entity.Property(e => e.Gzh97nean1)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NEAN1");

                entity.Property(e => e.Gzh97nean2)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NEAN2");

                entity.Property(e => e.Gzh97nnegp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNEGP");

                entity.Property(e => e.Gzh97nnr1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR1");

                entity.Property(e => e.Gzh97nnr2)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR2");

                entity.Property(e => e.Gzh97nnr3)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR3");

                entity.Property(e => e.Gzh97nnr4)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR4");

                entity.Property(e => e.Gzh97npc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NPC");

                entity.Property(e => e.Gzh97nrecn)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NRECN");

                entity.Property(e => e.Gzh97nsrc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NSRC");

                entity.Property(e => e.Gzh97ntcd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NTCD");

                entity.Property(e => e.Gzh97nuc1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NUC1");

                entity.Property(e => e.Gzh97nuc2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NUC2");

                entity.Property(e => e.Reference)
                    .HasMaxLength(27)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.Tranid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("TRANID")
                    .IsFixedLength();

                entity.Property(e => e.Tretxt)
                    .HasMaxLength(132)
                    .IsUnicode(false)
                    .HasColumnName("TRETXT");

                entity.Property(e => e.Trfile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRFILE")
                    .IsFixedLength();

                entity.Property(e => e.Trseq)
                    .HasPrecision(7)
                    .HasColumnName("TRSEQ");

                entity.Property(e => e.Trstat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRSTAT")
                    .IsFixedLength();

                entity.Property(e => e.Trtype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRTYPE")
                    .IsFixedLength();

                entity.Property(e => e.UserCodes)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("USER_CODES");

                entity.Property(e => e.UserOptions)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("USER_OPTIONS");

                entity.Property(e => e.ValueDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUE_DATE");
            });

            modelBuilder.Entity<ArtTiMasterEventHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_MASTER_EVENT_HISTORY");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.Bookoffdat)
                    .HasColumnType("DATE")
                    .HasColumnName("BOOKOFFDAT");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_CODE")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .IsUnicode(false)
                    .HasColumnName("CCY");

                entity.Property(e => e.CrossRef)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CROSS_REF")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DeactDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEACT_DATE");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Extrainfo)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EXTRAINFO");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Isfinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFINISHED")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Started)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("STARTED");

                entity.Property(e => e.StartedFilter)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTED_FILTER");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.StatusEv)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_EV")
                    .IsFixedLength();

                entity.Property(e => e.StepStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STEP_STATUS");

                entity.Property(e => e.Stepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STEPDESCR");

                entity.Property(e => e.Stepkey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("STEPKEY");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEAM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiMastevehistProdFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_MASTEVEHIST_PROD_FILTER");

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiMastevehistStatusFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_MASTEVEHIST_STATUS_FILTER");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiOsActivityReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_ACTIVITY_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Team)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("TEAM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiOsLiabilityReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_LIABILITY_REPORT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.LiabCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("LIAB_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Totliabamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTLIABAMT");

                entity.Property(e => e.TotliabamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTLIABAMT_EGP");
            });

            modelBuilder.Entity<ArtTiOsTransAwaitiApprlReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_AWAITI_APPRL_REPORT");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.Descr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.EventReference)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REFERENCE");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isfinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFINISHED")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NpcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.NpcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.NpcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.PcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.PcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.PcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Started)
                    .HasPrecision(9)
                    .HasColumnName("STARTED");

                entity.Property(e => e.Status)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Touched)
                    .HasColumnType("DATE")
                    .HasColumnName("TOUCHED");

                entity.Property(e => e.Type)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiOsTransByGatewayReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_BY_GATEWAY_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccysei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYSEI")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Partptd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTPTD")
                    .IsFixedLength();

                entity.Property(e => e.Prodcode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PRODCODE")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RevNext)
                    .HasColumnType("DATE")
                    .HasColumnName("REV_NEXT");

                entity.Property(e => e.Revolving)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REVOLVING")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Sovalue1)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE1");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");
            });

            modelBuilder.Entity<ArtTiOsTransByNonpriReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_BY_NONPRI_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.Code79)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CODE79")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccysei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYSEI")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Partptd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTPTD")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RevNext)
                    .HasColumnType("DATE")
                    .HasColumnName("REV_NEXT");

                entity.Property(e => e.Revolving)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REVOLVING")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Sovalue1)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE1");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");
            });

            modelBuilder.Entity<ArtTiOsTransByPrincipalReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_BY_PRINCIPAL_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.Code79)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CODE79")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outccysei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYSEI")
                    .IsFixedLength();

                entity.Property(e => e.Outccyspt)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("OUTCCYSPT");

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Partptd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTPTD")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RevNext)
                    .HasColumnType("DATE")
                    .HasColumnName("REV_NEXT");

                entity.Property(e => e.Revolving)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REVOLVING")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Sovalue1)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE1");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");
            });

            modelBuilder.Entity<ArtTiPeriodicChrgsPayReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_PERIODIC_CHRGS_PAY_REPORT");

                entity.Property(e => e.AccrueAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT");

                entity.Property(e => e.AccrueAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT_EGP");

                entity.Property(e => e.AccrueCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ACCRUE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.ChargeAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT");

                entity.Property(e => e.ChargeAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT_EGP");

                entity.Property(e => e.ChargeCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.ChgCusMnm1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHG_CUS_MNM1")
                    .IsFixedLength();

                entity.Property(e => e.ChgGfcun1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CHG_GFCUN1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwBank1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_BANK1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwBranch1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_BRANCH1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwCtr1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_CTR1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwLoc1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_LOC1")
                    .IsFixedLength();

                entity.Property(e => e.Chgpextraday)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("CHGPEXTRADAY");

                entity.Property(e => e.Ddate)
                    .HasColumnType("DATE")
                    .HasColumnName("DDATE");

                entity.Property(e => e.Descr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descr1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR1")
                    .IsFixedLength();

                entity.Property(e => e.EndDat)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DAT");

                entity.Property(e => e.Firststart)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTSTART")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NpcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.NpcpAddress11)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_ADDRESS11")
                    .IsFixedLength();

                entity.Property(e => e.NpcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.NpcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Payrec)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("PAYREC");

                entity.Property(e => e.PcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.PcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.PcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.SchAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT");

                entity.Property(e => e.SchAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT_EGP");

                entity.Property(e => e.SchCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCH_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDat)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DAT");

                entity.Property(e => e.SuppAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUPP_ACC")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiPeriodicChrgsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_PERIODIC_CHRGS_REPORT");

                entity.Property(e => e.AccrueAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT");

                entity.Property(e => e.AccrueAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT_EGP");

                entity.Property(e => e.AccrueCcy)
                    .IsUnicode(false)
                    .HasColumnName("ACCRUE_CCY");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.AdvArr)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ADV_ARR");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.ChargeAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT");

                entity.Property(e => e.ChargeAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT_EGP");

                entity.Property(e => e.ChargeCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Chgpextraday)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("CHGPEXTRADAY");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DailyAcc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DAILY_ACC");

                entity.Property(e => e.Descr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.EndDat)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DAT");

                entity.Property(e => e.Firststart)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTSTART")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Payrec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAYREC")
                    .IsFixedLength();

                entity.Property(e => e.Periodic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PERIODIC")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF");

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDat)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DAT");

                entity.Property(e => e.SuppAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUPP_ACC")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiSystemTailoringReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_SYSTEM_TAILORING_REPORT");

                entity.Property(e => e.AccSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACC_SRC");

                entity.Property(e => e.ActualAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACTUAL_AMT");

                entity.Property(e => e.Amberdate)
                    .HasColumnType("DATE")
                    .HasColumnName("AMBERDATE");

                entity.Property(e => e.Amberdays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMBERDAYS");

                entity.Property(e => e.Amberrsecs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMBERRSECS");

                entity.Property(e => e.Ambertime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AMBERTIME");

                entity.Property(e => e.Amendchg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AMENDCHG")
                    .IsFixedLength();

                entity.Property(e => e.Amount43)
                    .HasPrecision(15)
                    .HasColumnName("AMOUNT43");

                entity.Property(e => e.AmtCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("AMT_CCY");

                entity.Property(e => e.AmtField)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AMT_FIELD");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(27)
                    .IsUnicode(false)
                    .HasColumnName("ATTACHMENT");

                entity.Property(e => e.Autoprint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AUTOPRINT");

                entity.Property(e => e.AvailType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AVAIL_TYPE");

                entity.Property(e => e.Bsparamsetdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BSPARAMSETDESCR")
                    .IsFixedLength();

                entity.Property(e => e.Bsparamsetid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BSPARAMSETID")
                    .IsFixedLength();

                entity.Property(e => e.Btinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BTINITSTEPDESCR");

                entity.Property(e => e.Btinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BTINITSTEPID");

                entity.Property(e => e.Btrejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BTREJSTEPDESCR");

                entity.Property(e => e.Btrejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BTREJSTEPID");

                entity.Property(e => e.Canamdbas)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANAMDBAS")
                    .IsFixedLength();

                entity.Property(e => e.ChkLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_LIMIT");

                entity.Property(e => e.Contingent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CONTINGENT");

                entity.Property(e => e.Curren64)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CURREN64")
                    .IsFixedLength();

                entity.Property(e => e.Date71)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE71");

                entity.Property(e => e.DateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DATE_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Dateab63)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DATEAB63")
                    .IsFixedLength();

                entity.Property(e => e.Deadlinedate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEADLINEDATE");

                entity.Property(e => e.Deadlinedays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEADLINEDAYS");

                entity.Property(e => e.Deadlinersecs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEADLINERSECS");

                entity.Property(e => e.Deadlinetime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEADLINETIME");

                entity.Property(e => e.Debitcredit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEBITCREDIT");

                entity.Property(e => e.Dombehaviour)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOMBEHAVIOUR");

                entity.Property(e => e.Domcode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DOMCODE");

                entity.Property(e => e.Domdefault)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOMDEFAULT");

                entity.Property(e => e.Domlinkcode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DOMLINKCODE");

                entity.Property(e => e.Domlinkname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DOMLINKNAME");

                entity.Property(e => e.Domname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DOMNAME");

                entity.Property(e => e.Domtype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOMTYPE");

                entity.Property(e => e.ErrorText)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ERROR_TEXT");

                entity.Property(e => e.Eventlongname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EVENTLONGNAME")
                    .IsFixedLength();

                entity.Property(e => e.Field2Src)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIELD2_SRC")
                    .IsFixedLength();

                entity.Property(e => e.Fromstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("FROMSTEPDESCR");

                entity.Property(e => e.Fromstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FROMSTEPID");

                entity.Property(e => e.Gwinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GWINITSTEPDESCR");

                entity.Property(e => e.Gwinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GWINITSTEPID");

                entity.Property(e => e.Gwrejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GWREJSTEPDESCR");

                entity.Property(e => e.Gwrejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GWREJSTEPID");

                entity.Property(e => e.Intege18)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTEGE18");

                entity.Property(e => e.InternAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERN_ACC");

                entity.Property(e => e.Intinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("INTINITSTEPDESCR");

                entity.Property(e => e.Intinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("INTINITSTEPID");

                entity.Property(e => e.Inuse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INUSE");

                entity.Property(e => e.Liabamttyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIABAMTTYP");

                entity.Property(e => e.Liability)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIABILITY");

                entity.Property(e => e.Mappingid)
                    .HasMaxLength(43)
                    .IsUnicode(false)
                    .HasColumnName("MAPPINGID");

                entity.Property(e => e.Mappingsubid)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("MAPPINGSUBID");

                entity.Property(e => e.Mappingtype)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("MAPPINGTYPE");

                entity.Property(e => e.Mapstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAPSTEPDESCR");

                entity.Property(e => e.Mapstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MAPSTEPID");

                entity.Property(e => e.Margin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MARGIN");

                entity.Property(e => e.Nextstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NEXTSTEPDESCR");

                entity.Property(e => e.Nextstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NEXTSTEPID");

                entity.Property(e => e.Obsolete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OBSOLETE");

                entity.Property(e => e.Operat44)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OPERAT44")
                    .IsFixedLength();

                entity.Property(e => e.Optional)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OPTIONAL");

                entity.Property(e => e.Paramsetdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARAMSETDESCR")
                    .IsFixedLength();

                entity.Property(e => e.Paramsetid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PARAMSETID")
                    .IsFixedLength();

                entity.Property(e => e.Postingtyp)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("POSTINGTYP");

                entity.Property(e => e.Prodlongname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("PRODLONGNAME");

                entity.Property(e => e.Projection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PROJECTION");

                entity.Property(e => e.Reddate)
                    .HasColumnType("DATE")
                    .HasColumnName("REDDATE");

                entity.Property(e => e.Reddays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REDDAYS");

                entity.Property(e => e.Redrsecs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REDRSECS");

                entity.Property(e => e.Redtime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REDTIME");

                entity.Property(e => e.Rejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("REJSTEPDESCR");

                entity.Property(e => e.Rejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("REJSTEPID");

                entity.Property(e => e.RelDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REL_DATE")
                    .IsFixedLength();

                entity.Property(e => e.Relati29)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RELATI29")
                    .IsFixedLength();

                entity.Property(e => e.Relevmapkey)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RELEVMAPKEY");

                entity.Property(e => e.RevPstngs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REV_PSTNGS");

                entity.Property(e => e.Seq97)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQ97");

                entity.Property(e => e.Sequence)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQUENCE");

                entity.Property(e => e.Severity)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEVERITY");

                entity.Property(e => e.StepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STEP_TIME");

                entity.Property(e => e.Steptype)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("STEPTYPE");

                entity.Property(e => e.Swinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SWINITSTEPDESCR");

                entity.Property(e => e.Swinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SWINITSTEPID");

                entity.Property(e => e.Swrejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SWREJSTEPDESCR");

                entity.Property(e => e.Swrejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SWREJSTEPID");

                entity.Property(e => e.Teamcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEAMCODE");

                entity.Property(e => e.Teamdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("TEAMDESCR");

                entity.Property(e => e.Templatedescr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TEMPLATEDESCR");

                entity.Property(e => e.Templateid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEMPLATEID");

                entity.Property(e => e.Trancode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TRANCODE");

                entity.Property(e => e.TransAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_ACC");

                entity.Property(e => e.Trcrsdliab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRCRSDLIAB");

                entity.Property(e => e.Type24)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TYPE24")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");

                entity.Property(e => e.Useevtfm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USEEVTFM");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });
            modelBuilder.Entity<ArtTiFinanInterAccrual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_FINAN_INTER_ACCRUALS");

                entity.Property(e => e.Actualrate)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("ACTUALRATE");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.AmtOS)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMT_O_S");

                entity.Property(e => e.AmtOSEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMT_O_S_EGP");

                entity.Property(e => e.AmtOrPct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AMT_OR_PCT")
                    .IsFixedLength();

                entity.Property(e => e.BalancAmt)
                    .HasPrecision(15)
                    .HasColumnName("BALANC_AMT");

                entity.Property(e => e.BaseRate2)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("BASE_RATE2");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Calcdte)
                    .HasColumnType("DATE")
                    .HasColumnName("CALCDTE");

                entity.Property(e => e.CalcdtePd)
                    .HasColumnType("DATE")
                    .HasColumnName("CALCDTE_PD");

                entity.Property(e => e.Calcrate)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("CALCRATE");

                entity.Property(e => e.Calcrate1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CALCRATE1");

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.CcySei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_SEI")
                    .IsFixedLength();

                entity.Property(e => e.CcySpt)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("CCY_SPT");

                entity.Property(e => e.Commitamt)
                    .HasPrecision(15)
                    .HasColumnName("COMMITAMT");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Cycleend)
                    .HasColumnType("DATE")
                    .HasColumnName("CYCLEEND");

                entity.Property(e => e.DealCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DEAL_CCY")
                    .IsFixedLength();

                entity.Property(e => e.DiffRate2)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("DIFF_RATE2");

                entity.Property(e => e.EarlyDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EARLY_DATE");

                entity.Property(e => e.Extraday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRADAY")
                    .IsFixedLength();

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_CODE")
                    .IsFixedLength();

                entity.Property(e => e.GroupRate2)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GROUP_RATE2");

                entity.Property(e => e.Idb)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDB")
                    .IsFixedLength();

                entity.Property(e => e.InterestRateType)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("INTEREST_RATE_TYPE");

                entity.Property(e => e.Interp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERP")
                    .IsFixedLength();

                entity.Property(e => e.Interprate)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("INTERPRATE");

                entity.Property(e => e.IntpAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTP_AMT");

                entity.Property(e => e.IntpAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTP_AMT_EGP");

                entity.Property(e => e.IntpCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("INTP_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Intperday)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTPERDAY");

                entity.Property(e => e.Intpernum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTPERNUM");

                entity.Property(e => e.Intperunit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTPERUNIT")
                    .IsFixedLength();

                entity.Property(e => e.Inttypeid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INTTYPEID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Maturity)
                    .HasColumnType("DATE")
                    .HasColumnName("MATURITY");

                entity.Property(e => e.PartpnRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTPN_REF")
                    .IsFixedLength();

                entity.Property(e => e.Pastduedte)
                    .HasColumnType("DATE")
                    .HasColumnName("PASTDUEDTE");

                entity.Property(e => e.Pedoramt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PEDORAMT")
                    .IsFixedLength();

                entity.Property(e => e.Prodcut)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODCUT")
                    .IsFixedLength();

                entity.Property(e => e.Prodtypedesc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRODTYPEDESC")
                    .IsFixedLength();

                entity.Property(e => e.Prodtypename)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRODTYPENAME")
                    .IsFixedLength();

                entity.Property(e => e.Ptnshare)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PTNSHARE");

                entity.Property(e => e.RateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RATE_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Recamt)
                    .HasPrecision(15)
                    .HasColumnName("RECAMT");

                entity.Property(e => e.RecamtPd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECAMT_PD");

                entity.Property(e => e.RecamtPdEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECAMT_PD_EGP");

                entity.Property(e => e.Recccy)
                    .IsUnicode(false)
                    .HasColumnName("RECCCY");

                entity.Property(e => e.RecccyPd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("RECCCY_PD")
                    .IsFixedLength();

                entity.Property(e => e.Schratetype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SCHRATETYPE")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.SplitTier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SPLIT_TIER")
                    .IsFixedLength();

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.TierAmt)
                    .HasPrecision(15)
                    .HasColumnName("TIER_AMT");

                entity.Property(e => e.TierBase)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TIER_BASE")
                    .IsFixedLength();

                entity.Property(e => e.TierDiff)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIER_DIFF")
                    .IsFixedLength();

                entity.Property(e => e.TierNum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TIER_NUM");

                entity.Property(e => e.TierPnum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TIER_PNUM");

                entity.Property(e => e.TierPunit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIER_PUNIT")
                    .IsFixedLength();

                entity.Property(e => e.TierSprd)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("TIER_SPRD");
            });

            modelBuilder.Entity<ArtTiWatchlistOsCheckReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_WATCHLIST_OS_CHECK_REPORT");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.Descr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isfinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFINISHED")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.Longna85)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LONGNA85")
                    .IsFixedLength();

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Npcpaddress1)
                    .IsUnicode(false)
                    .HasColumnName("NPCPADDRESS1");

                entity.Property(e => e.NpcpcusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPCPCUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Npcpgfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCPGFCUN")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Pcpaddress1)
                    .IsUnicode(false)
                    .HasColumnName("PCPADDRESS1");

                entity.Property(e => e.PcpcusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PCPCUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Pcpgfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCPGFCUN")
                    .IsFixedLength();

                entity.Property(e => e.PcpswBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.PcpswBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.PcpswCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.PcpswLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Started)
                    .HasPrecision(9)
                    .HasColumnName("STARTED");

                entity.Property(e => e.Status)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Touched)
                    .HasColumnType("DATE")
                    .HasColumnName("TOUCHED");

                entity.Property(e => e.Type)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ArtTiAdvancePaymentUtilizationReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ADVANCE_PAYMENT_UTILIZATION_REPORT");

                entity.Property(e => e.AdvAmount)
                    .HasPrecision(15)
                    .HasColumnName("ADV_AMOUNT");

                entity.Property(e => e.AdvCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ADV_CURRENCY")
                    .IsFixedLength();

                entity.Property(e => e.AdvReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADV_REFERENCE")
                    .IsFixedLength();

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DATE");

                entity.Property(e => e.NonPrincipalParty)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NON_PRINCIPAL_PARTY")
                    .IsFixedLength();

                entity.Property(e => e.OutstandingAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTANDING_AMOUNT");

                entity.Property(e => e.PrincipalParty)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRINCIPAL_PARTY")
                    .IsFixedLength();

                entity.Property(e => e.UtilizationAmount)
                    .HasPrecision(15)
                    .HasColumnName("UTILIZATION_AMOUNT");

                entity.Property(e => e.UtilizationCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("UTILIZATION_CURRENCY")
                    .IsFixedLength();

                entity.Property(e => e.UtilizationTrn)
                    .IsUnicode(false)
                    .HasColumnName("UTILIZATION_TRN");
            });
            //for sake for build => toChange when convert to SqlServer
            modelBuilder.Entity<ArtSystemPreformance>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
