using Data.Data;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;


namespace Data.ModelCreatingStrategies
{
    public class SqlServerModelCreatingStrategy : IModelCreatingStrategy
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
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
            //ABK 
            modelBuilder.Entity<ArtCasesInitiatedFromBranch>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_CASES_INITIATED_FROM_BRANCH", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.CaseCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRY_DATE");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CASE_CREATION_DATE");
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

                entity.Property(e => e.LastActionTokenBy)
                    .HasMaxLength(60)
                    .HasColumnName("LAST_ACTION_TOKEN_BY")
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

                entity.Property(e => e.BranchId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID")
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
            });
            modelBuilder.Entity<ArtEcmFtiFullCycle>(entity => 
            {
                entity.HasNoKey();

                entity.ToView("ART_ECM_FTI_FULL_CYCLE", "ART_DB");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");
                entity.Property(e => e.BranchId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID")
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

                entity.Property(e => e.LastActionTokenBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LAST_ACTION_TOKEN_BY")
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

            //for sake for build => toChange when convert to oracle
            modelBuilder.Entity<ArtSystemPerformance>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
