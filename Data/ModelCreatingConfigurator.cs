using Data.Data;
using Data.DGCMGMT;
using Data.DGECM;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ModelCreatingConfigurator
    {
        public static void SqlServerOnModelCreating(ModelBuilder modelBuilder)
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
                    .HasColumnType("int")
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

                //entity.Property(e => e.CreateUserId)
                //    .HasMaxLength(60)
                //    .HasColumnName("CREATE_USER_ID");

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


                //entity.Property(e => e.ValidFromDate)
                //    .HasColumnType("datetime")
                //    .HasColumnName("VALID_FROM_DATE");
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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

                entity.Property(e => e.Logindatetime).HasColumnName("LOGINDATETIME");

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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
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

            //for sake for build => toChange when convert to oracle
            modelBuilder.Entity<ArtSystemPerformance>(entity =>
            {
                entity.HasNoKey();
            });
        }

        public static void DGECMSqlServerOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_100_CI_AI");
            modelBuilder.Entity<RefTableVal>(entity =>
            {
                entity.HasKey(e => new { e.RefTableName, e.ValCd })
                    .HasName("Ref_Table_Val_Pk");

                entity.ToTable("Ref_Table_Val", "DGCmgmt");

                entity.Property(e => e.RefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Ref_Table_Name");

                entity.Property(e => e.ValCd)
                    .HasMaxLength(32)
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

                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Parent_Ref_Table_Name");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(32)
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


        public static void DGECMOracleOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DGCMGMT");

            modelBuilder.Entity<RefTableVal>(entity =>
            {
                entity.HasKey(e => new { e.RefTableName, e.ValCd })
                    .HasName("REF_TABLE_VAL_PK");

                entity.ToTable("REF_TABLE_VAL");

                entity.HasIndex(e => new { e.ParentRefTableName, e.ParentValCd }, "REF_TABLE_VAL_FK1");

                entity.Property(e => e.RefTableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("REF_TABLE_NAME");

                entity.Property(e => e.ValCd)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("VAL_CD");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLG")
                    .IsFixedLength();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DELETED")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.DisplayOrdrNo)
                    .HasPrecision(6)
                    .HasColumnName("DISPLAY_ORDR_NO");



                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_REF_TABLE_NAME");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_VAL_CD");

                entity.Property(e => e.ValDesc)
                    .IsUnicode(false)
                    .HasColumnName("VAL_DESC");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => new { d.ParentRefTableName, d.ParentValCd })
                    .HasConstraintName("REF_TABLE_VAL_FK1");
            });

            modelBuilder.HasSequence("CASE_RK_SEQ");

            modelBuilder.HasSequence("CUST_RK_SEQ");

            modelBuilder.HasSequence("EVENT_RK_SEQ");

            modelBuilder.HasSequence("OCCS_RK_SEQ");

            modelBuilder.HasSequence("USER_AUTH_DOMAIN_SEQUENCE");
        }
        public static void OracleOnModelCreating(ModelBuilder modelBuilder)
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



            //for sake for build => toChange when convert to SqlServer
            modelBuilder.Entity<ArtSystemPreformance>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
