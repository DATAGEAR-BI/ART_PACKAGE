using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Data;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.CRP;
using Data.Data.ECM;
using Data.Data.KYC;
using Data.DGAMLCORE;
using Data.DGAMLAC;
using Data.DGECM;
using Data.FCFCORE;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public class MySqlModelCreatingStrategy : IBaseModelCreatingStrategy
    {


        public void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void OnSegmentionModelCreating(ModelBuilder modelBuilder)
        {
            // SEGMENT
            throw new NotImplementedException();
        }
        public void OnARTGOAMLModelCreating(ModelBuilder modelBuilder)
        {
            //GOAML
            modelBuilder.Entity<ArtGoamlReportsDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_goaml_reports_details");

                entity.Property(e => e.Action).HasColumnName("ACTION");

                entity.Property(e => e.Currencycodelocal)
                    .HasMaxLength(255)
                    .HasColumnName("CURRENCYCODELOCAL");

                entity.Property(e => e.Entityreference)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITYREFERENCE");

                entity.Property(e => e.Fiurefnumber)
                    .HasMaxLength(255)
                    .HasColumnName("FIUREFNUMBER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Isvalid)
                    .HasColumnName("ISVALID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.Reason).HasColumnName("REASON");

                entity.Property(e => e.Rentitybranch)
                    .HasMaxLength(255)
                    .HasColumnName("RENTITYBRANCH");

                entity.Property(e => e.Rentityid).HasColumnName("RENTITYID");

                entity.Property(e => e.Reportcloseddate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.Reportcode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCODE");

                entity.Property(e => e.Reportcreatedby)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCREATEDBY");

                entity.Property(e => e.Reportcreateddate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.Reportingpersontype)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTINGPERSONTYPE");

                entity.Property(e => e.Reportrisksignificance)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTRISKSIGNIFICANCE");

                entity.Property(e => e.Reportstatuscode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTSTATUSCODE");

                entity.Property(e => e.Reportuserlockid)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTUSERLOCKID");

                entity.Property(e => e.Reportxml)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTXML");

                entity.Property(e => e.Submissioncode)
                    .HasMaxLength(255)
                    .HasColumnName("SUBMISSIONCODE");

                entity.Property(e => e.Submissiondate)
                    .HasColumnType("date")
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("VERSION");
            });

            modelBuilder.Entity<ArtGoamlReportsIndicator>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_goaml_reports_indicators");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("description");

                entity.Property(e => e.Indicator)
                    .HasMaxLength(255)
                    .HasColumnName("INDICATOR");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");
            });

            modelBuilder.Entity<ArtGoamlReportsSusbectParty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_goaml_reports_susbect_parties");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("ACCOUNT");

                entity.Property(e => e.Activity)
                    .HasMaxLength(12)
                    .HasColumnName("ACTIVITY")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasColumnName("BRANCH");

                entity.Property(e => e.Entityreference)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITYREFERENCE");

                entity.Property(e => e.Fiurefnumber)
                    .HasMaxLength(255)
                    .HasColumnName("FIUREFNUMBER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PartyId)
                    .HasMaxLength(255)
                    .HasColumnName("PARTY_ID");

                entity.Property(e => e.PartyName)
                    .HasColumnType("text")
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.Partynumber)
                    .HasMaxLength(255)
                    .HasColumnName("PARTYNUMBER");

                entity.Property(e => e.Reportcloseddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.Reportcode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCODE");

                entity.Property(e => e.Reportcreateddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.Reportstatuscode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTSTATUSCODE");

                entity.Property(e => e.Submissiondate)
                    .HasColumnType("date")
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Transactionnumber)
                    .HasMaxLength(255)
                    .HasColumnName("TRANSACTIONNUMBER");
            });

            modelBuilder.Entity<ArtHomeGoamlReportsDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_goaml_reports_date");

                entity.Property(e => e.CountOfReportId)
                    .HasPrecision(10)
                    .HasColumnName("COUNT_OF_REPORT_ID");

                entity.Property(e => e.Month)
                    .HasMaxLength(32)
                    .HasColumnName("MONTH");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            modelBuilder.Entity<ArtHomeGoamlReportsPerType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_goaml_reports_per_type");

                entity.Property(e => e.NumberOfReports)
                    .HasPrecision(10)
                    .HasColumnName("NUMBER_OF_REPORTS");

                entity.Property(e => e.ReportType)
                    .HasMaxLength(255)
                    .HasColumnName("REPORT_TYPE");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });
        }

        public void OnARTDGAMLModelCreating(ModelBuilder modelBuilder)
        {
            //DGAML

            modelBuilder.Entity<ArtDgAmlAlertDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_dgaml_alert_detail_view");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .HasColumnName("ACTUAL_VALUES_TEXT");

                entity.Property(e => e.AlarmId).HasColumnName("alarm_id");

                entity.Property(e => e.AlertCategory)
                    .HasColumnType("text")
                    .HasColumnName("alert_category");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_DESCRIPTION")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AlertStatus)
                    .HasColumnType("text")
                    .HasColumnName("alert_status");

                entity.Property(e => e.AlertSubcategory)
                    .HasColumnType("text")
                    .HasColumnName("alert_subcategory");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(100)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .HasColumnName("ALERTED_ENTITY_NUMBER")
                    .HasDefaultValueSql("''");

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
                    .HasColumnName("close_user_Name");

                entity.Property(e => e.ClosedUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Closed_USER_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.InvestigationDays).HasColumnName("Investigation_Days");

                entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasPrecision(10)
                    .HasColumnName("MONEY_LAUNDERING_RISK_SCORE");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Run_Date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ScenarioId)
                    .HasPrecision(12)
                    .HasColumnName("SCENARIO_ID");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .HasColumnName("SCENARIO_NAME");
            });

            modelBuilder.Entity<ArtDgAmlCaseDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_dgaml_case_detail_view");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CaseCategory)
                    .HasColumnType("text")
                    .HasColumnName("CASE_CATEGORY");

                entity.Property(e => e.CaseCategoryCode)
                    .HasMaxLength(32)
                    .HasColumnName("CASE_CATEGORY_CODE");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CasePriority)
                    .HasColumnType("text")
                    .HasColumnName("CASE_PRIORITY");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("text")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseStatusCode)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_STATUS_CODE");

                entity.Property(e => e.CaseSubCategoryCode)
                    .HasMaxLength(32)
                    .HasColumnName("CASE_SUB_CATEGORY_CODE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(60)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.EntityLevel)
                    .HasColumnType("text")
                    .HasColumnName("ENTITY_LEVEL");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(200)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.EntityNumber)
                    .HasColumnType("text")
                    .HasColumnName("ENTITY_NUMBER");
            });

            modelBuilder.Entity<ArtDgAmlCustomerDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_dgaml_customer_detail_view");

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasPrecision(10)
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
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
                    .HasMaxLength(50)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(50)
                    .HasColumnName("EMPLOYEE_NUMBER");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(100)
                    .HasColumnName("EMPLOYER_NAME");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                entity.Property(e => e.GovernorateName)
                    .HasMaxLength(50)
                    .HasColumnName("Governorate_name");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .HasColumnName("industry_desc");

                entity.Property(e => e.IsEmployee)
                    .HasMaxLength(1)
                    .HasColumnName("Is_EMPLOYEE")
                    .IsFixedLength();

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(50)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(50)
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
                    .HasPrecision(10)
                    .HasColumnName("NET_WORTH_AMOUNT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .HasColumnName("non_profit_org_ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(100)
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
                    .HasColumnName("politically_exposed_person_ind")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasPrecision(10)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(100)
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

                entity.ToView("art_dgaml_triage_view");

                entity.Property(e => e.AgeOldestAlert)
                    .HasPrecision(10)
                    .HasColumnName("AGE_OLDEST_ALERT");

                entity.Property(e => e.AggregateAmt)
                    .HasPrecision(15, 3)
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

                entity.Property(e => e.AlertsCntSum)
                    .HasPrecision(10)
                    .HasColumnName("ALERTS_CNT_SUM");

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

            modelBuilder.Entity<ArtExternalCustomerDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_external_customer_detail_view");

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
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                entity.ToView("art_scenario_admin_view");

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

                entity.Property(e => e.ParamCondition).HasColumnName("PARAM_CONDITION");

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
                    .HasMaxLength(500)
                    .HasColumnName("SCENARIO_NAME");

                entity.Property(e => e.ScenarioShortDesc)
                    .HasMaxLength(500)
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

                entity.ToView("art_scenario_history_view");

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
                    .HasMaxLength(500)
                    .HasColumnName("Routine_Name");

                entity.Property(e => e.RoutineShortDesc)
                    .HasMaxLength(500)
                    .HasColumnName("Routine_Short_Desc");
            });

            modelBuilder.Entity<ArtSuspectDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_suspect_detail_view");

                entity.Property(e => e.AgeOfOldestAlert)
                    .HasPrecision(10)
                    .HasColumnName("AGE_OF_OLDEST_ALERT");

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
                    .HasMaxLength(100)
                    .HasColumnName("Empr_Name");

                entity.Property(e => e.NumberOfAlarms)
                    .HasPrecision(10)
                    .HasColumnName("NUMBER_OF_ALARMS");

                entity.Property(e => e.OccupDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Occup_Desc");

                entity.Property(e => e.OwnerUserId)
                    .HasMaxLength(240)
                    .HasColumnName("OWNER_USER_ID");

                entity.Property(e => e.PoliticalExpPrsnInd)
                    .HasMaxLength(1)
                    .HasColumnName("Political_Exp_Prsn_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ProfileRisk)
                    .HasMaxLength(32)
                    .HasColumnName("PROFILE_RISK");

                entity.Property(e => e.RiskClassification)
                    .HasPrecision(10)
                    .HasColumnName("risk_classification");

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

            // DG Home Aml
            modelBuilder.Entity<ArtHomeDgamlAlertsPerDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_dgaml_alerts_per_date");

                entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_Alerts");
            });

            modelBuilder.Entity<ArtHomeDgamlAlertsPerStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_dgaml_alerts_per_status");

                entity.Property(e => e.AlertStatus)
                    .HasColumnType("text")
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertsCount).HasColumnName("ALERTS_COUNT");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_dgaml_number_of_accounts");

                entity.Property(e => e.NumberOfAccounts).HasColumnName("NUMBER_OF_ACCOUNTS");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_dgaml_number_of_customers");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("NUMBER_OF_CUSTOMERS");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfHighRiskCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_dgaml_number_of_high_risk_customers");

                entity.Property(e => e.NumberOfHighRiskCustomers).HasColumnName("NUMBER_OF_HIGH_RISK_CUSTOMERS");
            });

            modelBuilder.Entity<ArtHomeDgamlNumberOfPepCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_home_dgaml_number_of_pep_customers");

                entity.Property(e => e.NumberOfPepCustomers).HasColumnName("NUMBER_OF_PEP_CUSTOMERS");
            });

        }

        public void OnEcmModelCreating(ModelBuilder modelBuilder)
        {
        }

        public void OnSasAmlModelCreating(ModelBuilder modelBuilder)
        {
            //AML
            throw new NotImplementedException();
        }

        public void OnAuditModelCreating(ModelBuilder modelBuilder)
        {
            //AUDIT
            modelBuilder.Entity<ArtGroupsAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_groups_audit_view");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .HasColumnName("action");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .HasColumnName("group_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.MemberUsers)
                    .HasColumnType("text")
                    .HasColumnName("member_users");

                entity.Property(e => e.RoleNames)
                    .HasColumnType("text")
                    .HasColumnName("role_names");

                entity.Property(e => e.SubGroupNames)
                    .HasColumnType("text")
                    .HasColumnName("sub_group_names");
            });

            modelBuilder.Entity<ArtRolesAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_roles_audit_view");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .HasColumnName("action");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupNames)
                    .HasColumnType("text")
                    .HasColumnName("group_names");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.MemberUsers)
                    .HasColumnType("text")
                    .HasColumnName("member_users");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<ArtUsersAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_users_audit_view");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .HasColumnName("action");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.DomainAccounts)
                    .HasColumnType("text")
                    .HasColumnName("domain_accounts");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Enable)
                    .HasColumnType("bit(1)")
                    .HasColumnName("enable");

                entity.Property(e => e.GroupNames)
                    .HasColumnType("text")
                    .HasColumnName("group_names");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleNames)
                    .HasColumnType("text")
                    .HasColumnName("role_names");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<LastLoginPerDayView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("last_login_per_day_view");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .HasColumnName("DEVICE_TYPE");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("IP");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Logindatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGINDATETIME");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<ListGroupsRolesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_groups_roles_summary");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<ListGroupsSubGroupsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_groups_sub_groups_summary");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.SubGroupName)
                    .HasMaxLength(255)
                    .HasColumnName("SUB_GROUP_NAME");
            });

            modelBuilder.Entity<ListOfDeletedUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_deleted_users");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<ListOfGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_groups");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .HasColumnName("group_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("last_updated_date");
            });

            modelBuilder.Entity<ListOfRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_roles");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .HasColumnName("role_type");
            });

            modelBuilder.Entity<ListOfUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_users");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasColumnName("active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock)
                    .HasColumnName("counter_lock")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Enable)
                    .HasColumnType("bit(1)")
                    .HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<ListOfUsersAndGroupsRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_users_and_groups_roles");

                entity.Property(e => e.AccountStatus)
                    .HasColumnType("bit(1)")
                    .HasColumnName("ACCOUNT_STATUS")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("created_date");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.RoleOfGroup)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<ListOfUsersGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_users_groups");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<ListOfUsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("list_of_users_roles");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(255)
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
        }

        public void OnFTIModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnKYCModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtAuditCorporateView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_audit_corporate_view");

                entity.Property(e => e.ActivityAmount)
                    .HasMaxLength(255)
                    .HasColumnName("ACTIVITY_AMOUNT");

                entity.Property(e => e.ActivityAmountCurrency)
                    .HasMaxLength(255)
                    .HasColumnName("ACTIVITY_AMOUNT_CURRENCY");

                entity.Property(e => e.ActivityEndDate)
                    .HasMaxLength(6)
                    .HasColumnName("ACTIVITY_END_DATE");

                entity.Property(e => e.ActivityStartDate)
                    .HasMaxLength(6)
                    .HasColumnName("ACTIVITY_START_DATE");

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(255)
                    .HasColumnName("ACTIVITY_TYPE");

                entity.Property(e => e.ActivityTypeDtls)
                    .HasMaxLength(255)
                    .HasColumnName("ACTIVITY_TYPE_DTLS");

                entity.Property(e => e.ActivityTypeSub)
                    .HasMaxLength(255)
                    .HasColumnName("ACTIVITY_TYPE_SUB");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualNetIncomeCd)
                    .HasMaxLength(255)
                    .HasColumnName("ANNUAL_NET_INCOME_CD");

                entity.Property(e => e.BankingOrCorporate)
                    .HasMaxLength(255)
                    .HasColumnName("BANKING_OR_CORPORATE");

                entity.Property(e => e.BankingOrOtherRef)
                    .HasMaxLength(255)
                    .HasColumnName("BANKING_OR_OTHER_REF");

                entity.Property(e => e.BudgetDate1)
                    .HasMaxLength(6)
                    .HasColumnName("BUDGET_DATE_1");

                entity.Property(e => e.BudgetDate2)
                    .HasMaxLength(6)
                    .HasColumnName("BUDGET_DATE_2");

                entity.Property(e => e.BudgetDate3)
                    .HasMaxLength(6)
                    .HasColumnName("BUDGET_DATE_3");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(255)
                    .HasColumnName("BUSINESS_CODE");

                entity.Property(e => e.CalculateZakahFlag)
                    .HasMaxLength(255)
                    .HasColumnName("CALCULATE_ZAKAH_FLAG");

                entity.Property(e => e.Capital1)
                    .HasMaxLength(255)
                    .HasColumnName("CAPITAL_1");

                entity.Property(e => e.Capital2)
                    .HasMaxLength(255)
                    .HasColumnName("CAPITAL_2");

                entity.Property(e => e.Capital3)
                    .HasMaxLength(255)
                    .HasColumnName("CAPITAL_3");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(255)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CharityDonationsInd)
                    .HasMaxLength(255)
                    .HasColumnName("CHARITY_DONATIONS_IND");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasMaxLength(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(255)
                    .HasColumnName("CLOSING_REASON_ID");

                entity.Property(e => e.CommercialName)
                    .HasMaxLength(255)
                    .HasColumnName("COMMERCIAL_NAME");

                entity.Property(e => e.CommercialNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("COMMERCIAL_NAME_EN");

                entity.Property(e => e.CompanyStock)
                    .HasMaxLength(255)
                    .HasColumnName("COMPANY_STOCK");

                entity.Property(e => e.CompanyStockName)
                    .HasMaxLength(255)
                    .HasColumnName("COMPANY_STOCK_NAME");

                entity.Property(e => e.CorporateName)
                    .HasMaxLength(255)
                    .HasColumnName("CORPORATE_NAME");

                entity.Property(e => e.CorporateNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("CORPORATE_NAME_EN");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_REFERENCE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.DateOfBudget)
                    .HasMaxLength(255)
                    .HasColumnName("DATE_OF_BUDGET");

                entity.Property(e => e.DealAbrdBankDetails)
                    .HasMaxLength(255)
                    .HasColumnName("DEAL_ABRD_BANK_DETAILS");

                entity.Property(e => e.DealtBankDetails)
                    .HasMaxLength(255)
                    .HasColumnName("DEALT_BANK_DETAILS");

                entity.Property(e => e.DefaultBranch)
                    .HasMaxLength(255)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicActivityCode5)
                    .HasMaxLength(255)
                    .HasColumnName("ECONOMIC_ACTIVITY_CODE5");

                entity.Property(e => e.FfiType)
                    .HasMaxLength(255)
                    .HasColumnName("FFI_TYPE");

                entity.Property(e => e.FinancialStartDate)
                    .HasMaxLength(255)
                    .HasColumnName("FINANCIAL_START_DATE");

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(255)
                    .HasColumnName("FOREIGN_CONSULATE_EMBASSY_IND");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.Giin)
                    .HasMaxLength(255)
                    .HasColumnName("GIIN");

                entity.Property(e => e.GovOrgInd)
                    .HasMaxLength(255)
                    .HasColumnName("GOV_ORG_IND");

                entity.Property(e => e.HeadQuarterCountry)
                    .HasMaxLength(255)
                    .HasColumnName("HEAD_QUARTER_COUNTRY");

                entity.Property(e => e.HoldingCorporation)
                    .HasMaxLength(255)
                    .HasColumnName("HOLDING_CORPORATION");

                entity.Property(e => e.HoldingCorporationCd)
                    .HasMaxLength(255)
                    .HasColumnName("HOLDING_CORPORATION_CD");

                entity.Property(e => e.IdIssueCountry)
                    .HasMaxLength(255)
                    .HasColumnName("ID_ISSUE_COUNTRY");

                entity.Property(e => e.IdentExpiryDate)
                    .HasMaxLength(6)
                    .HasColumnName("IDENT_EXPIRY_DATE");

                entity.Property(e => e.IdentIssueDate)
                    .HasMaxLength(6)
                    .HasColumnName("IDENT_ISSUE_DATE");

                entity.Property(e => e.IdentNumber)
                    .HasMaxLength(255)
                    .HasColumnName("IDENT_NUMBER");

                entity.Property(e => e.IdentType)
                    .HasMaxLength(255)
                    .HasColumnName("IDENT_TYPE");

                entity.Property(e => e.IncorporationCountryCode)
                    .HasMaxLength(255)
                    .HasColumnName("INCORPORATION_COUNTRY_CODE");

                entity.Property(e => e.IncorporationDate)
                    .HasMaxLength(6)
                    .HasColumnName("INCORPORATION_DATE");

                entity.Property(e => e.IncorporationLegalForm)
                    .HasMaxLength(255)
                    .HasColumnName("INCORPORATION_LEGAL_FORM");

                entity.Property(e => e.IncorporationState)
                    .HasMaxLength(255)
                    .HasColumnName("INCORPORATION_STATE");

                entity.Property(e => e.Industry)
                    .HasMaxLength(255)
                    .HasColumnName("INDUSTRY");

                entity.Property(e => e.InvestmentBalance)
                    .HasMaxLength(255)
                    .HasColumnName("INVESTMENT_BALANCE");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(255)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastQueryDate)
                    .HasMaxLength(6)
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalFormOthers)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_FORM_OTHERS");

                entity.Property(e => e.LegalFormSub)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_FORM_SUB");

                entity.Property(e => e.LegalStepMainCode)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_STEP_MAIN_CODE");

                entity.Property(e => e.LegalStepSubCode)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_STEP_SUB_CODE");

                entity.Property(e => e.LimitsAmount)
                    .HasPrecision(19)
                    .HasColumnName("LIMITS_AMOUNT");

                entity.Property(e => e.LimitsAmountCurrency)
                    .HasMaxLength(255)
                    .HasColumnName("LIMITS_AMOUNT_CURRENCY");

                entity.Property(e => e.MainLegalForm)
                    .HasMaxLength(255)
                    .HasColumnName("MAIN_LEGAL_FORM");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(255)
                    .HasColumnName("NAME_LANGUAGE");

                entity.Property(e => e.NationalityCountry)
                    .HasMaxLength(255)
                    .HasColumnName("NATIONALITY_COUNTRY");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.NoOfEmployees)
                    .HasMaxLength(255)
                    .HasColumnName("NO_OF_EMPLOYEES");

                entity.Property(e => e.NonProfitOrganization)
                    .HasMaxLength(255)
                    .HasColumnName("NON_PROFIT_ORGANIZATION");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PaidUpCapitalAmount)
                    .HasPrecision(19)
                    .HasColumnName("PAID_UP_CAPITAL_AMOUNT");

                entity.Property(e => e.PaidUpCapitalCurrency)
                    .HasMaxLength(255)
                    .HasColumnName("PAID_UP_CAPITAL_CURRENCY");

                entity.Property(e => e.ReferenceEmployeeId)
                    .HasMaxLength(255)
                    .HasColumnName("REFERENCE_EMPLOYEE_ID");

                entity.Property(e => e.RegExpiryDate)
                    .HasMaxLength(6)
                    .HasColumnName("REG_EXPIRY_DATE");

                entity.Property(e => e.RegNumberCity)
                    .HasMaxLength(255)
                    .HasColumnName("REG_NUMBER_CITY");

                entity.Property(e => e.RegNumberLastDate)
                    .HasMaxLength(6)
                    .HasColumnName("REG_NUMBER_LAST_DATE");

                entity.Property(e => e.RegNumberOffice)
                    .HasMaxLength(255)
                    .HasColumnName("REG_NUMBER_OFFICE");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(255)
                    .HasColumnName("REGISTRATION_NUMBER");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CODE");

                entity.Property(e => e.RiskReason)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_REASON");

                entity.Property(e => e.RiskWeight)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_WEIGHT");

                entity.Property(e => e.SalesBasis)
                    .HasMaxLength(255)
                    .HasColumnName("SALES_BASIS");

                entity.Property(e => e.SalesVolume1)
                    .HasMaxLength(255)
                    .HasColumnName("SALES_VOLUME_1");

                entity.Property(e => e.SalesVolume2)
                    .HasMaxLength(255)
                    .HasColumnName("SALES_VOLUME_2");

                entity.Property(e => e.SalesVolume3)
                    .HasMaxLength(255)
                    .HasColumnName("SALES_VOLUME_3");

                entity.Property(e => e.SizeOfSales)
                    .HasPrecision(19)
                    .HasColumnName("SIZE_OF_SALES");

                entity.Property(e => e.SizeOfTransaction)
                    .HasPrecision(19)
                    .HasColumnName("SIZE_OF_TRANSACTION");

                entity.Property(e => e.TaxIdNum)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_ID_NUM");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("TITLE");

                entity.Property(e => e.TotalNoOfUnits)
                    .HasMaxLength(255)
                    .HasColumnName("TOTAL_NO_OF_UNITS");

                entity.Property(e => e.TradeAddDate)
                    .HasMaxLength(6)
                    .HasColumnName("TRADE_ADD_DATE");

                entity.Property(e => e.TypeOfBusiness)
                    .HasMaxLength(255)
                    .HasColumnName("TYPE_OF_BUSINESS");

                entity.Property(e => e.TypeOfBusinessOther)
                    .HasMaxLength(255)
                    .HasColumnName("TYPE_OF_BUSINESS_OTHER");

                entity.Property(e => e.UnderEstablishment)
                    .HasMaxLength(255)
                    .HasColumnName("UNDER_ESTABLISHMENT");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.WomenShare)
                    .HasMaxLength(255)
                    .HasColumnName("WOMEN_SHARE");

                entity.Property(e => e.WorthCode)
                    .HasMaxLength(255)
                    .HasColumnName("WORTH_CODE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasMaxLength(6)
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            modelBuilder.Entity<ArtAuditIndividualsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_audit_individuals_view");

                entity.Property(e => e.AKA)
                    .HasMaxLength(255)
                    .HasColumnName("A_K_A");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualIncomeCd)
                    .HasMaxLength(255)
                    .HasColumnName("ANNUAL_INCOME_CD");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(255)
                    .HasColumnName("BUSINESS_CODE");

                entity.Property(e => e.BusinessSector)
                    .HasMaxLength(255)
                    .HasColumnName("BUSINESS_SECTOR");

                entity.Property(e => e.BusinessSectorOthers)
                    .HasMaxLength(255)
                    .HasColumnName("BUSINESS_SECTOR_OTHERS");

                entity.Property(e => e.CalculateZakahFlag)
                    .HasMaxLength(255)
                    .HasColumnName("CALCULATE_ZAKAH_FLAG");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskId)
                    .HasMaxLength(255)
                    .HasColumnName("CB_RISK_ID");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(255)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CbRiskRateOther)
                    .HasMaxLength(255)
                    .HasColumnName("CB_RISK_RATE_OTHER");

                entity.Property(e => e.CharityFlag)
                    .HasMaxLength(255)
                    .HasColumnName("CHARITY_FLAG");

                entity.Property(e => e.CitizenOrResident)
                    .HasMaxLength(255)
                    .HasColumnName("CITIZEN_OR_RESIDENT");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasMaxLength(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(255)
                    .HasColumnName("CLOSING_REASON_ID");

                entity.Property(e => e.ClosingReasonIdOther)
                    .HasMaxLength(255)
                    .HasColumnName("CLOSING_REASON_ID_OTHER");

                entity.Property(e => e.CompanySalesAmountPerYear)
                    .HasMaxLength(255)
                    .HasColumnName("COMPANY_SALES_AMOUNT_PER_YEAR");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DealAbrdBankDetails)
                    .HasMaxLength(255)
                    .HasColumnName("DEAL_ABRD_BANK_DETAILS");

                entity.Property(e => e.DealtBankDetails)
                    .HasMaxLength(255)
                    .HasColumnName("DEALT_BANK_DETAILS");

                entity.Property(e => e.DefaultBranch)
                    .HasMaxLength(255)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicMainCode)
                    .HasMaxLength(255)
                    .HasColumnName("ECONOMIC_MAIN_CODE");

                entity.Property(e => e.EconomicSubCode)
                    .HasMaxLength(255)
                    .HasColumnName("ECONOMIC_SUB_CODE");

                entity.Property(e => e.EducationId)
                    .HasMaxLength(255)
                    .HasColumnName("EDUCATION_ID");

                entity.Property(e => e.EducationIdOther)
                    .HasMaxLength(255)
                    .HasColumnName("EDUCATION_ID_OTHER");

                entity.Property(e => e.EmployedOrBusiness)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYED_OR_BUSINESS");

                entity.Property(e => e.EmployeeIndicator)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYEE_INDICATOR");

                entity.Property(e => e.EmployerBusinessAdrs)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_BUSINESS_ADRS");

                entity.Property(e => e.EmployerBusinessCity)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_BUSINESS_CITY");

                entity.Property(e => e.EmployerBusinessCtry)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_BUSINESS_CTRY");

                entity.Property(e => e.EmployerBusinessName)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_BUSINESS_NAME");

                entity.Property(e => e.EmployerBusinessState)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_BUSINESS_STATE");

                entity.Property(e => e.EmployerBusinessTown)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_BUSINESS_TOWN");

                entity.Property(e => e.EmployerCountryPhoneCode)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_COUNTRY_PHONE_CODE");

                entity.Property(e => e.EmployerPhone)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYER_PHONE");

                entity.Property(e => e.EmploymentType)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYMENT_TYPE");

                entity.Property(e => e.ExpenseIsoCurrency)
                    .HasMaxLength(255)
                    .HasColumnName("EXPENSE_ISO_CURRENCY");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.FirstNameEng)
                    .HasMaxLength(255)
                    .HasColumnName("FIRST_NAME_ENG");

                entity.Property(e => e.FullNameAr)
                    .HasMaxLength(255)
                    .HasColumnName("FULL_NAME_AR");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("FULL_NAME_EN");

                entity.Property(e => e.GenderCd)
                    .HasMaxLength(255)
                    .HasColumnName("GENDER_CD");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.HomeCd)
                    .HasMaxLength(255)
                    .HasColumnName("HOME_CD");

                entity.Property(e => e.IncomeIsoCurrency)
                    .HasMaxLength(255)
                    .HasColumnName("INCOME_ISO_CURRENCY");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(255)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LastNameEng)
                    .HasMaxLength(255)
                    .HasColumnName("LAST_NAME_ENG");

                entity.Property(e => e.LastQueryDate)
                    .HasMaxLength(6)
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalMainCode)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_MAIN_CODE");

                entity.Property(e => e.LegalStepDate)
                    .HasMaxLength(6)
                    .HasColumnName("LEGAL_STEP_DATE");

                entity.Property(e => e.LegalStepMainCode)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_STEP_MAIN_CODE");

                entity.Property(e => e.LegalStepSubCode)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_STEP_SUB_CODE");

                entity.Property(e => e.LegalSubCode)
                    .HasMaxLength(255)
                    .HasColumnName("LEGAL_SUB_CODE");

                entity.Property(e => e.MaritalStatusCd)
                    .HasMaxLength(255)
                    .HasColumnName("MARITAL_STATUS_CD");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.MiddleNameEng)
                    .HasMaxLength(255)
                    .HasColumnName("MIDDLE_NAME_ENG");

                entity.Property(e => e.MonthExpense)
                    .HasMaxLength(255)
                    .HasColumnName("MONTH_EXPENSE");

                entity.Property(e => e.MonthIncome)
                    .HasMaxLength(255)
                    .HasColumnName("MONTH_INCOME");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(255)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(255)
                    .HasColumnName("NAME_LANGUAGE");

                entity.Property(e => e.NationalityCode1)
                    .HasMaxLength(255)
                    .HasColumnName("NATIONALITY_CODE1");

                entity.Property(e => e.NationalityCode2)
                    .HasMaxLength(255)
                    .HasColumnName("NATIONALITY_CODE2");

                entity.Property(e => e.NationalityCode3)
                    .HasMaxLength(255)
                    .HasColumnName("NATIONALITY_CODE3");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.NumberOfDependents)
                    .HasMaxLength(255)
                    .HasColumnName("NUMBER_OF_DEPENDENTS");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .HasColumnName("OCCUPATION");

                entity.Property(e => e.OccupationDtl)
                    .HasMaxLength(255)
                    .HasColumnName("OCCUPATION_DTL");

                entity.Property(e => e.OpeningReasonId)
                    .HasMaxLength(255)
                    .HasColumnName("OPENING_REASON_ID");

                entity.Property(e => e.OpeningReasonIdOther)
                    .HasMaxLength(255)
                    .HasColumnName("OPENING_REASON_ID_OTHER");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PepIndicator)
                    .HasMaxLength(255)
                    .HasColumnName("PEP_INDICATOR");

                entity.Property(e => e.PepIndicatorDtls)
                    .HasMaxLength(255)
                    .HasColumnName("PEP_INDICATOR_DTLS");

                entity.Property(e => e.PepIndicatorOth)
                    .HasMaxLength(255)
                    .HasColumnName("PEP_INDICATOR_OTH");

                entity.Property(e => e.RaceId)
                    .HasMaxLength(255)
                    .HasColumnName("RACE_ID");

                entity.Property(e => e.ReferredPersonAddress)
                    .HasMaxLength(255)
                    .HasColumnName("REFERRED_PERSON_ADDRESS");

                entity.Property(e => e.ReferredPersonPhone)
                    .HasMaxLength(255)
                    .HasColumnName("REFERRED_PERSON_PHONE");

                entity.Property(e => e.RelationToBankCode)
                    .HasMaxLength(255)
                    .HasColumnName("RELATION_TO_BANK_CODE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(255)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.ResidenceCountry)
                    .HasMaxLength(255)
                    .HasColumnName("RESIDENCE_COUNTRY");

                entity.Property(e => e.RiskClassValue)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS_VALUE");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CODE");

                entity.Property(e => e.RiskCodeOther)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CODE_OTHER");

                entity.Property(e => e.RiskReason)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_REASON");

                entity.Property(e => e.SectorAnalysesCode)
                    .HasMaxLength(255)
                    .HasColumnName("SECTOR_ANALYSES_CODE");

                entity.Property(e => e.SictorCode)
                    .HasMaxLength(255)
                    .HasColumnName("SICTOR_CODE");

                entity.Property(e => e.SourceOfIncomeCd)
                    .HasMaxLength(255)
                    .HasColumnName("SOURCE_OF_INCOME_CD");

                entity.Property(e => e.SourceOfIncomeOther)
                    .HasMaxLength(255)
                    .HasColumnName("SOURCE_OF_INCOME_OTHER");

                entity.Property(e => e.SpouseBusiness)
                    .HasMaxLength(255)
                    .HasColumnName("SPOUSE_BUSINESS");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(255)
                    .HasColumnName("SPOUSE_NAME");

                entity.Property(e => e.TaxRegulationCtryCd1)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_REGULATION_CTRY_CD1");

                entity.Property(e => e.TaxRegulationCtryCd2)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_REGULATION_CTRY_CD2");

                entity.Property(e => e.TaxRegulationCtryCd3)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_REGULATION_CTRY_CD3");

                entity.Property(e => e.TaxRegulationTin1)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_REGULATION_TIN1");

                entity.Property(e => e.TaxRegulationTin2)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_REGULATION_TIN2");

                entity.Property(e => e.TaxRegulationTin3)
                    .HasMaxLength(255)
                    .HasColumnName("TAX_REGULATION_TIN3");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.VisaExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VISA_EXPIRATION_DATE");

                entity.Property(e => e.VisaType)
                    .HasMaxLength(255)
                    .HasColumnName("VISA_TYPE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasMaxLength(6)
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            modelBuilder.Entity<ArtKycExpiredId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_expired_id");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.IdExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ID_EXPIRE_DATE");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(255)
                    .HasColumnName("ID_NUMBER");
            });

            modelBuilder.Entity<ArtKycHighExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_high_expired");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycHighOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_high_one_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycHighThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_high_three_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycHighTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_high_two_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycLowExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_low_expired");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycLowOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_low_one_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycLowThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_low_three_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycLowTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_low_two_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycMediumExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_medium_expired");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycMediumOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_medium_one_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycMediumThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_medium_three_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycMediumTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_medium_two_month");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasMaxLength(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ArtKycSummaryByRisk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_kyc_summary_by_risk");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.NumberOfNotUpdatedKyc).HasColumnName("NUMBER_OF_NOT_UPDATED_KYC");

                entity.Property(e => e.NumberOfUpdatedKyc).HasColumnName("NUMBER_OF_UPDATED_KYC");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.Property(e => e.Type)
                    .HasMaxLength(9)
                    .HasColumnName("TYPE")
                    .HasDefaultValueSql("''");
            });
        }

        public void OnDGECMModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dgcmgmt");
            modelBuilder.Entity<CaseLive>(entity =>
            {
                entity.HasKey(e => e.CaseRk)
                    .HasName("PRIMARY");

                entity.ToTable("case_live");

                entity.HasIndex(e => e.CaseDesc, "IX_Case_Desc");

                entity.HasIndex(e => e.CaseStatCd, "IX_Case_Live_Case_Stat_Cd");

                entity.HasIndex(e => e.CaseStatCd, "IX_Case_Stat_Cd");

                entity.HasIndex(e => e.ValidFromDate, "IX_Valid_From_Date");

                entity.HasIndex(e => e.ValidToDate, "IX_Valid_To_Date");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(10)
                    .HasColumnName("Case_Rk");


                entity.Property(e => e.AnyBicFieldBic)
                    .HasColumnType("text")
                    .HasColumnName("anyBicFieldBic");

                entity.Property(e => e.ApplicantId)
                    .HasColumnType("text")
                    .HasColumnName("applicantId");

                entity.Property(e => e.ApplicantName)
                    .HasColumnType("text")
                    .HasColumnName("applicantName");

                entity.Property(e => e.ApplicantRef)
                    .HasColumnType("text")
                    .HasColumnName("applicantRef");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("applicationDate");

                entity.Property(e => e.BehalfOfBranch)
                    .HasColumnType("text")
                    .HasColumnName("behalfOfBranch");

                entity.Property(e => e.BeneficiaryAccountNum)
                    .HasMaxLength(100)
                    .HasColumnName("beneficiaryAccountNum");

                entity.Property(e => e.BeneficiaryBirthYear)
                    .HasColumnType("text")
                    .HasColumnName("beneficiaryBirthYear");

                entity.Property(e => e.BeneficiaryCountry)
                    .HasColumnType("text")
                    .HasColumnName("beneficiaryCountry");

                entity.Property(e => e.BeneficiaryIdentity)
                    .HasColumnType("text")
                    .HasColumnName("beneficiaryIdentity");

                entity.Property(e => e.BeneficiaryName)
                    .HasColumnType("text")
                    .HasColumnName("beneficiaryName");

                entity.Property(e => e.BeneficiaryNationality)
                    .HasMaxLength(100)
                    .HasColumnName("beneficiaryNationality");

                entity.Property(e => e.BirthPlace)
                    .HasColumnType("text")
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
                    .HasPrecision(10)
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
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Close_Date");

                entity.Property(e => e.Col1).HasColumnType("text");

                entity.Property(e => e.Col2).HasColumnType("text");

                entity.Property(e => e.Col3).HasColumnType("text");

                entity.Property(e => e.Col4).HasColumnType("text");

                entity.Property(e => e.Col5).HasColumnType("text");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.CreditorAgentBankBic)
                    .HasColumnType("text")
                    .HasColumnName("creditorAgentBankBic");

                entity.Property(e => e.CustFullName)
                    .HasMaxLength(200)
                    .HasColumnName("Cust_Full_Name");

                entity.Property(e => e.CustomerActivityCountry)
                    .HasColumnType("text")
                    .HasColumnName("customer_activity_country");

                entity.Property(e => e.CustomerCreatedBranch)
                    .HasColumnType("text")
                    .HasColumnName("customer_created_branch");

                entity.Property(e => e.CustomerCreatedUser)
                    .HasColumnType("text")
                    .HasColumnName("customer_created_user");

                entity.Property(e => e.CustomerResidency)
                    .HasColumnType("text")
                    .HasColumnName("customer_residency");

                entity.Property(e => e.DebtorAgentBankBic)
                    .HasColumnType("text")
                    .HasColumnName("debtorAgentBankBic");

                entity.Property(e => e.DeleteFlag)
                    .HasMaxLength(1)
                    .HasColumnName("Delete_Flag")
                    .IsFixedLength();

                entity.Property(e => e.DocumentReference).HasMaxLength(100);

                entity.Property(e => e.EcmWorkflow)
                    .HasMaxLength(255)
                    .HasColumnName("Ecm_Workflow");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .HasColumnName("Employee_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EventName)
                    .HasColumnType("text")
                    .HasColumnName("eventName");

                entity.Property(e => e.EventRef)
                    .HasColumnType("text")
                    .HasColumnName("eventRef");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(250)
                    .HasColumnName("hits_count");

                entity.Property(e => e.InputName)
                    .HasColumnType("text")
                    .HasColumnName("inputName");

                entity.Property(e => e.IntermediaryCode)
                    .HasMaxLength(100)
                    .HasColumnName("intermediaryCode");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Investr_User_Id");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("issueDate");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(100)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.MasterRef)
                    .HasColumnType("text")
                    .HasColumnName("masterRef");

                entity.Property(e => e.MaxSensitivityRank).HasColumnName("maxSensitivityRank");

                entity.Property(e => e.Nationality)
                    .HasColumnType("text")
                    .HasColumnName("nationality");

                entity.Property(e => e.OpenDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Open_Date");

                entity.Property(e => e.OthNationality).HasColumnType("text");

                entity.Property(e => e.ParentCaseId)
                    .HasMaxLength(50)
                    .HasColumnName("parentCaseId");

                entity.Property(e => e.ParentCaseRk)
                    .HasPrecision(10)
                    .HasColumnName("parentCaseRk");

                entity.Property(e => e.PartyTypeDesc)
                    .HasColumnType("text")
                    .HasColumnName("partyTypeDesc");

                entity.Property(e => e.PayDestinationCountry)
                    .HasMaxLength(100)
                    .HasColumnName("payDestinationCountry");

                entity.Property(e => e.PayOriginCountry)
                    .HasMaxLength(100)
                    .HasColumnName("payOriginCountry");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(250)
                    .HasColumnName("primary_owner");

                entity.Property(e => e.PriorityCd)
                    .HasMaxLength(32)
                    .HasColumnName("Priority_Cd");

                entity.Property(e => e.Product)
                    .HasColumnType("text")
                    .HasColumnName("product");

                entity.Property(e => e.ProductType)
                    .HasColumnType("text")
                    .HasColumnName("productType");

                entity.Property(e => e.ReceiverBankBic)
                    .HasColumnType("text")
                    .HasColumnName("receiverBankBic");

                entity.Property(e => e.ReceiverBic)
                    .HasColumnType("text")
                    .HasColumnName("receiverBic");

                entity.Property(e => e.ReceiverCtry)
                    .HasColumnType("text")
                    .HasColumnName("receiverCtry");

                entity.Property(e => e.Reference).HasMaxLength(100);

                entity.Property(e => e.ReguRptRqdFlag)
                    .HasMaxLength(1)
                    .HasColumnName("Regu_Rpt_Rqd_Flag")
                    .IsFixedLength();

                entity.Property(e => e.RemitterAccountNum)
                    .HasMaxLength(100)
                    .HasColumnName("remitterAccountNum");

                entity.Property(e => e.RemitterBirthYear)
                    .HasColumnType("text")
                    .HasColumnName("remitterBirthYear");

                entity.Property(e => e.RemitterCountry)
                    .HasColumnType("text")
                    .HasColumnName("remitterCountry");

                entity.Property(e => e.RemitterIdentity)
                    .HasColumnType("text")
                    .HasColumnName("remitterIdentity");

                entity.Property(e => e.RemitterNationality)
                    .HasMaxLength(100)
                    .HasColumnName("remitterNationality");

                entity.Property(e => e.ReopenDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("REOpen_Date");

                entity.Property(e => e.SearchCountry)
                    .HasColumnType("text")
                    .HasColumnName("searchCountry");

                entity.Property(e => e.SearchUnit)
                    .HasColumnType("text")
                    .HasColumnName("searchUnit");

                entity.Property(e => e.SearchUser)
                    .HasColumnType("text")
                    .HasColumnName("searchUser");

                entity.Property(e => e.SenderBankBic)
                    .HasColumnType("text")
                    .HasColumnName("senderBankBic");

                entity.Property(e => e.SenderBic)
                    .HasColumnType("text")
                    .HasColumnName("senderBic");

                entity.Property(e => e.SenderCtry)
                    .HasColumnType("text")
                    .HasColumnName("senderCtry");

                entity.Property(e => e.SenderReceiverAgentCode)
                    .HasMaxLength(100)
                    .HasColumnName("senderReceiverAgentCode");

                entity.Property(e => e.SrcSysCd)
                    .HasMaxLength(32)
                    .HasColumnName("Src_Sys_Cd");

                entity.Property(e => e.SwiftReference)
                    .HasColumnType("text")
                    .HasColumnName("swift_reference");

                entity.Property(e => e.TransactionAmount).HasColumnName("transaction_amount");

                entity.Property(e => e.TransactionBeneficiary)
                    .HasMaxLength(100)
                    .HasColumnName("transaction_beneficiary");

                entity.Property(e => e.TransactionBenificiary)
                    .HasColumnType("text")
                    .HasColumnName("transaction_benificiary");

                entity.Property(e => e.TransactionCurrency)
                    .HasColumnType("text")
                    .HasColumnName("transaction_currency");

                entity.Property(e => e.TransactionDirection)
                    .HasColumnType("text")
                    .HasColumnName("transaction_direction");

                entity.Property(e => e.TransactionReference)
                    .HasMaxLength(100)
                    .HasColumnName("transaction_reference");

                entity.Property(e => e.TransactionRemitter)
                    .HasColumnType("text")
                    .HasColumnName("transaction_remitter");

                entity.Property(e => e.TransactionType)
                    .HasColumnType("text")
                    .HasColumnName("transaction_type");

                entity.Property(e => e.UiDefFileName)
                    .HasMaxLength(100)
                    .HasColumnName("UI_Def_File_Name");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Update_User_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.ValidFromDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Valid_From_Date");

                entity.Property(e => e.ValidToDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Valid_To_Date");

                entity.Property(e => e.VerNo)
                    .HasPrecision(10)
                    .HasColumnName("Ver_No");

                entity.Property(e => e.WasPending)
                    .HasColumnType("text")
                    .HasColumnName("wasPending");

                entity.Property(e => e.WlCategory)
                    .HasColumnType("text")
                    .HasColumnName("WL_CATEGORY");

                entity.Property(e => e.XIdentity)
                    .HasColumnType("text")
                    .HasColumnName("X_IDENTITY");
            });

            modelBuilder.Entity<RefTableVal>(entity =>
            {
                entity.HasKey(e => new { e.RefTableName, e.ValCd })
                    .HasName("PRIMARY");

                entity.ToTable("ref_table_val");

                entity.HasIndex(e => new { e.ParentRefTableName, e.ParentValCd }, "REF_TABLE_VAL_FK1");

                entity.Property(e => e.RefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Ref_Table_Name");

                entity.Property(e => e.ValCd)
                    .HasMaxLength(32)
                    .HasColumnName("Val_Cd");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .HasColumnName("Active_Flg")
                    .IsFixedLength();

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DisplayOrdrNo)
                    .HasPrecision(6)
                    .HasColumnName("Display_Ordr_No");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(20)
                    .HasColumnName("module_Name");

                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Parent_Ref_Table_Name");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(32)
                    .HasColumnName("Parent_Val_Cd");


                entity.Property(e => e.ValDesc)
                    .HasColumnType("text")
                    .HasColumnName("Val_Desc");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => new { d.ParentRefTableName, d.ParentValCd })
                    .HasConstraintName("REF_TABLE_VAL_FK1");
            });
        }
        public void OnDGFATCAModelCreating(ModelBuilder modelBuilder)
        {

            throw new NotImplementedException();
        }


        public void OnDgAMLCOREModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dgamlcore");
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AcctKey)
                    .HasName("PRIMARY");

                entity.ToTable("account");

                entity.HasIndex(e => e.AcctNo, "XIE1ACCOUNT");

                entity.HasIndex(e => e.AcctName, "XIE2ACCOUNT");

                entity.HasIndex(e => e.AcctTaxId, "XIE3ACCOUNT");

                entity.Property(e => e.AcctKey).HasColumnName("ACCT_KEY");

                entity.Property(e => e.AcctCcyCd)
                    .HasMaxLength(6)
                    .HasColumnName("ACCT_CCY_CD");

                entity.Property(e => e.AcctCcyName)
                    .HasMaxLength(200)
                    .HasColumnName("ACCT_CCY_NAME");

                entity.Property(e => e.AcctCloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACCT_CLOSE_DATE");

                entity.Property(e => e.AcctName)
                    .HasColumnType("text")
                    .HasColumnName("ACCT_NAME");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(100)
                    .HasColumnName("ACCT_NO");

                entity.Property(e => e.AcctOpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACCT_OPEN_DATE");

                entity.Property(e => e.AcctPrimBranchName)
                    .HasMaxLength(70)
                    .HasColumnName("ACCT_PRIM_BRANCH_NAME");

                entity.Property(e => e.AcctRegName)
                    .HasColumnType("text")
                    .HasColumnName("ACCT_REG_NAME");

                entity.Property(e => e.AcctRegTypeDesc)
                    .HasMaxLength(70)
                    .HasColumnName("ACCT_REG_TYPE_DESC");

                entity.Property(e => e.AcctStatusDesc)
                    .HasMaxLength(100)
                    .HasColumnName("ACCT_STATUS_DESC");

                entity.Property(e => e.AcctTaxId)
                    .HasMaxLength(70)
                    .HasColumnName("ACCT_TAX_ID");

                entity.Property(e => e.AcctTaxIdTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("ACCT_TAX_ID_TYPE_CD");

                entity.Property(e => e.AcctTaxStateCd)
                    .HasMaxLength(6)
                    .HasColumnName("ACCT_TAX_STATE_CD");

                entity.Property(e => e.AcctTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("ACCT_TYPE_DESC");

                entity.Property(e => e.AltName)
                    .HasColumnType("text")
                    .HasColumnName("ALT_NAME");


                entity.Property(e => e.CashIntsBusInd)
                    .HasMaxLength(1)
                    .HasColumnName("CASH_INTS_BUS_IND");

                entity.Property(e => e.CcyBasedAcctInd)
                    .HasMaxLength(1)
                    .HasColumnName("CCY_BASED_ACCT_IND");

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CHG_BEGIN_DATE");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .HasColumnName("CHG_CURRENT_IND");

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CHG_END_DATE");


                entity.Property(e => e.ColtrlTypeCd)
                    .HasMaxLength(100)
                    .HasColumnName("COLTRL_TYPE_CD");

                entity.Property(e => e.ColtrlTypeDesc)
                    .HasMaxLength(100)
                    .HasColumnName("COLTRL_TYPE_DESC");

    

                entity.Property(e => e.DormInd)
                    .HasMaxLength(1)
                    .HasColumnName("DORM_IND");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .HasColumnName("EMP_IND");

              

                entity.Property(e => e.InstAmt)
                    .HasColumnType("double(15,5)")
                    .HasColumnName("INST_AMT");

                entity.Property(e => e.InsurAmt)
                    .HasColumnType("double(15,5)")
                    .HasColumnName("INSUR_AMT");

                entity.Property(e => e.LeaseTransfer)
                    .HasMaxLength(6)
                    .HasColumnName("LEASETRANSFER");

                entity.Property(e => e.LetterCrOnfileInd)
                    .HasMaxLength(1)
                    .HasColumnName("LETTER_CR_ONFILE_IND");

                entity.Property(e => e.LineBusName)
                    .HasMaxLength(100)
                    .HasColumnName("LINE_BUS_NAME");

                entity.Property(e => e.MailAddr1)
                    .HasColumnType("text")
                    .HasColumnName("MAIL_ADDR_1");

                entity.Property(e => e.MailAddr2)
                    .HasColumnType("text")
                    .HasColumnName("MAIL_ADDR_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(70)
                    .HasColumnName("MAIL_CITY_NAME");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("MAIL_CNTRY_CD");

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(200)
                    .HasColumnName("MAIL_CNTRY_NAME");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .HasColumnName("MAIL_POST_CD");

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("MAIL_STATE_CD");

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(70)
                    .HasColumnName("MAIL_STATE_NAME");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MATURITY_DATE");


                entity.Property(e => e.OrigLoanAmt)
                    .HasColumnType("double(15,5)")
                    .HasColumnName("ORIG_LOAN_AMT");

                entity.Property(e => e.ProdCategName)
                    .HasMaxLength(100)
                    .HasColumnName("PROD_CATEG_NAME");

                entity.Property(e => e.ProdLineName)
                    .HasMaxLength(100)
                    .HasColumnName("PROD_LINE_NAME");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(200)
                    .HasColumnName("PROD_NAME");

                entity.Property(e => e.ProdNo)
                    .HasMaxLength(50)
                    .HasColumnName("PROD_NO");

                entity.Property(e => e.ProdTypeName)
                    .HasMaxLength(100)
                    .HasColumnName("PROD_TYPE_NAME");

                entity.Property(e => e.Tenure)
                    .HasMaxLength(20)
                    .HasColumnName("TENURE");

                entity.Property(e => e.TradeFinInd)
                    .HasMaxLength(1)
                    .HasColumnName("TRADE_FIN_IND");

                entity.Property(e => e.Vinno)
                    .HasMaxLength(100)
                    .HasColumnName("VINNO");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustKey)
                    .HasName("PRIMARY");

                entity.ToTable("customer");

                entity.HasIndex(e => e.CustName, "XIE12CUSTOMER");

                entity.HasIndex(e => e.CustNo, "XIE13CUSTOMER");

                entity.HasIndex(e => e.CustTaxId, "XIE14CUSTOMER");

                entity.HasIndex(e => e.MatchCdMailAddr, "XIE15CUSTOMER");

                entity.HasIndex(e => e.MatchCdAddr, "XIE16CUSTOMER");

                entity.HasIndex(e => e.TelNo1, "XIE17CUSTOMER");

                entity.HasIndex(e => e.TelNo2, "XIE18CUSTOMER");

                entity.HasIndex(e => e.TelNo3, "XIE19CUSTOMER");

                entity.HasIndex(e => e.EmprName, "XIE20CUSTOMER");

                entity.HasIndex(e => e.MatchCdIndv, "XIE21CUSTOMER");

                entity.HasIndex(e => e.MatchCdOrg, "XIE22CUSTOMER");

                entity.HasIndex(e => e.EmprTelNo, "XIE23CUSTOMER");

                entity.HasIndex(e => e.CustLname, "XIE7CUSTOMER");

                entity.Property(e => e.CustKey).HasColumnName("CUST_KEY");

                entity.Property(e => e.Addr1)
                    .HasColumnType("text")
                    .HasColumnName("ADDR_1");

                entity.Property(e => e.Addr2)
                    .HasColumnType("text")
                    .HasColumnName("ADDR_2");

             

                entity.Property(e => e.AnnualIncomeAmt)
                    .HasColumnType("double(22,6)")
                    .HasColumnName("ANNUAL_INCOME_AMT");

         

                entity.Property(e => e.CcyExchInd)
                    .HasMaxLength(1)
                    .HasColumnName("CCY_EXCH_IND");

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(1)
                    .HasColumnName("CHECK_CASHER_IND");

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CHG_BEGIN_DATE");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .HasColumnName("CHG_CURRENT_IND")
                    .HasDefaultValueSql("'Y'");

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CHG_END_DATE");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(6)
                    .HasColumnName("CITIZEN_CNTRY_CD");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(200)
                    .HasColumnName("CITIZEN_CNTRY_NAME");

                entity.Property(e => e.CityName)
                    .HasMaxLength(70)
                    .HasColumnName("CITY_NAME");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(6)
                    .HasColumnName("CNTRY_CD");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(200)
                    .HasColumnName("CNTRY_NAME");

    

                entity.Property(e => e.CustBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUST_BIRTH_DATE");

               

                entity.Property(e => e.CustFname)
                    .HasMaxLength(100)
                    .HasColumnName("CUST_FNAME");

                entity.Property(e => e.CustGen)
                    .HasMaxLength(2)
                    .HasColumnName("CUST_GEN");

                entity.Property(e => e.CustIdCntryCd)
                    .HasMaxLength(100)
                    .HasColumnName("CUST_ID_CNTRY_CD");

                entity.Property(e => e.CustIdStateCd)
                    .HasMaxLength(6)
                    .HasColumnName("CUST_ID_STATE_CD");

                entity.Property(e => e.CustIdentExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUST_IDENT_EXP_DATE");

                entity.Property(e => e.CustIdentId)
                    .HasMaxLength(70)
                    .HasColumnName("CUST_IDENT_ID");

                entity.Property(e => e.CustIdentIssDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUST_IDENT_ISS_DATE");

                entity.Property(e => e.CustIdentTypeDesc)
                    .HasMaxLength(100)
                    .HasColumnName("CUST_IDENT_TYPE_DESC");

                entity.Property(e => e.CustLname)
                    .HasMaxLength(200)
                    .HasColumnName("CUST_LNAME");

                entity.Property(e => e.CustMname)
                    .HasMaxLength(100)
                    .HasColumnName("CUST_MNAME");

                entity.Property(e => e.CustName)
                    .HasColumnType("text")
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.CustNo)
                    .HasMaxLength(100)
                    .HasColumnName("CUST_NO");

                entity.Property(e => e.CustSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUST_SINCE_DATE");

                entity.Property(e => e.CustStatusDesc)
                    .HasMaxLength(200)
                    .HasColumnName("CUST_STATUS_DESC");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(70)
                    .HasColumnName("CUST_TAX_ID");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .HasColumnName("CUST_TAX_ID_TYPE_CD");

                entity.Property(e => e.CustTypeDesc)
                    .HasMaxLength(40)
                    .HasColumnName("CUST_TYPE_DESC");

               

          

                entity.Property(e => e.DoBusAsName)
                    .HasColumnType("text")
                    .HasColumnName("DO_BUS_AS_NAME");

                entity.Property(e => e.EmailAddr)
                    .HasColumnType("text")
                    .HasColumnName("EMAIL_ADDR");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .HasColumnName("EMP_IND");

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(40)
                    .HasColumnName("EMP_NO");

                

                entity.Property(e => e.EmprName)
                    .HasMaxLength(70)
                    .HasColumnName("EMPR_NAME");

                entity.Property(e => e.EmprTelNo)
                    .HasMaxLength(50)
                    .HasColumnName("EMPR_TEL_NO");

          

                entity.Property(e => e.ExtCustInd)
                    .HasMaxLength(1)
                    .HasColumnName("EXT_CUST_IND");

                entity.Property(e => e.FrgnConsulate)
                    .HasMaxLength(1)
                    .HasColumnName("FRGN_CONSULATE");

              

                entity.Property(e => e.IndsCd)
                    .HasMaxLength(20)
                    .HasColumnName("INDS_CD");

                entity.Property(e => e.IndsCdRr)
                    .HasMaxLength(20)
                    .HasColumnName("INDS_CD_RR");

                entity.Property(e => e.IndsDesc)
                    .HasColumnType("text")
                    .HasColumnName("INDS_DESC");

     

                entity.Property(e => e.InternetGmblngInd)
                    .HasMaxLength(1)
                    .HasColumnName("INTERNET_GMBLNG_IND");

               

                entity.Property(e => e.IssBearsSharesInd)
                    .HasMaxLength(1)
                    .HasColumnName("ISS_BEARS_SHARES_IND");

            

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_CONTACT_DATE");

                entity.Property(e => e.LegalObjType)
                    .HasMaxLength(60)
                    .HasColumnName("LEGAL_OBJ_TYPE");

                entity.Property(e => e.LstCashTransReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LST_CASH_TRANS_REPORT_DATE");

                entity.Property(e => e.LstRiskAssmntDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LST_RISK_ASSMNT_DATE");

                entity.Property(e => e.LstSuspActReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LST_SUSP_ACT_REPORT_DATE");

                entity.Property(e => e.LstUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LST_UPDATE_DATE");

                entity.Property(e => e.MachCdMailAddrLine)
                    .HasColumnType("text")
                    .HasColumnName("MACH_CD_MAIL_ADDR_LINE");

                entity.Property(e => e.MailAddr1)
                    .HasColumnType("text")
                    .HasColumnName("MAIL_ADDR_1");

                entity.Property(e => e.MailAddr2)
                    .HasColumnType("text")
                    .HasColumnName("MAIL_ADDR_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(70)
                    .HasColumnName("MAIL_CITY_NAME");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(100)
                    .HasColumnName("MAIL_CNTRY_CD");

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(200)
                    .HasColumnName("MAIL_CNTRY_NAME");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(20)
                    .HasColumnName("MAIL_POST_CD");

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(6)
                    .HasColumnName("MAIL_STATE_CD");

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(70)
                    .HasColumnName("MAIL_STATE_NAME");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(40)
                    .HasColumnName("MARITAL_STATUS_DESC");

                entity.Property(e => e.MatchCdAddr)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_ADDR");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_ADDR_LINE");

                entity.Property(e => e.MatchCdCity)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_CITY");

                entity.Property(e => e.MatchCdCntry)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_CNTRY");

                entity.Property(e => e.MatchCdIndv)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_INDV");

                entity.Property(e => e.MatchCdMailAddr)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_MAIL_ADDR");

                entity.Property(e => e.MatchCdMailCity)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_MAIL_CITY");

                entity.Property(e => e.MatchCdMailCntry)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_MAIL_CNTRY");

                entity.Property(e => e.MatchCdMailState)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_MAIL_STATE");

                entity.Property(e => e.MatchCdOrg)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_ORG");

                entity.Property(e => e.MatchCdState)
                    .HasColumnType("text")
                    .HasColumnName("MATCH_CD_STATE");

                entity.Property(e => e.MoneyOrderInd)
                    .HasMaxLength(1)
                    .HasColumnName("MONEY_ORDER_IND");

                entity.Property(e => e.MoneyServiceBusInd)
                    .HasMaxLength(1)
                    .HasColumnName("MONEY_SERVICE_BUS_IND");

                entity.Property(e => e.MoneyTransmtrInd)
                    .HasMaxLength(1)
                    .HasColumnName("MONEY_TRANSMTR_IND");

         

                entity.Property(e => e.NationalAddr)
                    .HasColumnType("text")
                    .HasColumnName("NATIONAL_ADDR");

              

                entity.Property(e => e.NegtvNewsInd)
                    .HasMaxLength(1)
                    .HasColumnName("NEGTV_NEWS_IND");

                entity.Property(e => e.NetWorthAmt)
                    .HasColumnType("double(22,6)")
                    .HasColumnName("NET_WORTH_AMT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .HasColumnName("NON_PROFIT_ORG_IND");

                entity.Property(e => e.OccupDesc)
                    .HasColumnType("text")
                    .HasColumnName("OCCUP_DESC");

         

                entity.Property(e => e.OrgCntryOfBusCd)
                    .HasMaxLength(6)
                    .HasColumnName("ORG_CNTRY_OF_BUS_CD");

                entity.Property(e => e.OrgCntryOfBusName)
                    .HasMaxLength(200)
                    .HasColumnName("ORG_CNTRY_OF_BUS_NAME");

                entity.Property(e => e.ParentName)
                    .HasColumnType("text")
                    .HasColumnName("PARENT_NAME");


                entity.Property(e => e.PoliticalExpPrsnInd)
                    .HasMaxLength(1)
                    .HasColumnName("POLITICAL_EXP_PRSN_IND");

                entity.Property(e => e.PostCd)
                    .HasMaxLength(20)
                    .HasColumnName("POST_CD");

     

                entity.Property(e => e.PrepCardInd)
                    .HasMaxLength(1)
                    .HasColumnName("PREP_CARD_IND");

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(6)
                    .HasColumnName("RESID_CNTRY_CD");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(200)
                    .HasColumnName("RESID_CNTRY_NAME");


                entity.Property(e => e.RiskClass).HasColumnName("RISK_CLASS");

       

                entity.Property(e => e.StateCd)
                    .HasMaxLength(6)
                    .HasColumnName("STATE_CD");

                entity.Property(e => e.StateName)
                    .HasMaxLength(70)
                    .HasColumnName("STATE_NAME");

               

                entity.Property(e => e.SuspActRptCount).HasColumnName("SUSP_ACT_RPT_COUNT");

         
                entity.Property(e => e.TelNo1)
                    .HasMaxLength(50)
                    .HasColumnName("TEL_NO_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(50)
                    .HasColumnName("TEL_NO_2");

                entity.Property(e => e.TelNo3)
                    .HasMaxLength(50)
                    .HasColumnName("TEL_NO_3");

               

                entity.Property(e => e.TravChekInd)
                    .HasMaxLength(1)
                    .HasColumnName("TRAV_CHEK_IND");



                entity.Property(e => e.TrustAcctInd)
                    .HasMaxLength(1)
                    .HasColumnName("TRUST_ACCT_IND");

     
            });

            modelBuilder.Entity<ExternalCustomer>(entity =>
            {
                entity.HasKey(e => e.ExtCustAcctKey)
                    .HasName("PRIMARY");

                entity.ToTable("external_customer");

                entity.Property(e => e.ExtCustAcctKey).HasColumnName("ext_cust_acct_key");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("acct_no");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(35)
                    .HasColumnName("addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(35)
                    .HasColumnName("addr_2");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("branch_name");

                entity.Property(e => e.BranchNo)
                    .HasMaxLength(25)
                    .HasColumnName("branch_no");

       

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("citizen_cntry_cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("citizen_cntry_name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("city_name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("cntry_cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("cntry_name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("cust_tax_id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .HasColumnName("cust_tax_id_type_cd")
                    .IsFixedLength();

                entity.Property(e => e.ExtBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ext_birth_date");

                entity.Property(e => e.ExtCustNo)
                    .HasMaxLength(100)
                    .HasColumnName("ext_cust_no");

                entity.Property(e => e.ExtCustTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("ext_cust_type_desc");

                entity.Property(e => e.ExtFname)
                    .HasMaxLength(50)
                    .HasColumnName("ext_fname");

                entity.Property(e => e.ExtFullName)
                    .HasMaxLength(200)
                    .HasColumnName("ext_full_name");

            

                entity.Property(e => e.ExtLname)
                    .HasMaxLength(100)
                    .HasColumnName("ext_lname");

                entity.Property(e => e.ExtMname)
                    .HasMaxLength(50)
                    .HasColumnName("ext_mname");

                entity.Property(e => e.FiNo)
                    .HasMaxLength(25)
                    .HasColumnName("fi_no");

                entity.Property(e => e.IdentCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("ident_cntry_cd");

                entity.Property(e => e.IdentCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("ident_cntry_name");

                entity.Property(e => e.IdentId)
                    .HasMaxLength(35)
                    .HasColumnName("ident_id");

                entity.Property(e => e.IdentStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("ident_state_cd");

                entity.Property(e => e.IdentTypeDesc)
                    .HasMaxLength(4)
                    .HasColumnName("ident_type_desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_addr_line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_city");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_indv");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_state");

              

                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("post_cd");

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("resid_cntry_cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("resid_cntry_name");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("state_cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(35)
                    .HasColumnName("state_name");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_2");
            });
        }

        public void OnDgAMLACModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ac");
            //ac

            modelBuilder.Entity<AcLkpTable>(entity =>
            {
                entity.HasKey(e => new { e.LkpName, e.LkpValCd, e.LkpLangDesc })
                    .HasName("PRIMARY");

                entity.ToTable("ac_lkp_table");

                entity.Property(e => e.LkpName)
                    .HasMaxLength(50)
                    .HasColumnName("lkp_name");

                entity.Property(e => e.LkpValCd)
                    .HasMaxLength(100)
                    .HasColumnName("lkp_val_cd");

                entity.Property(e => e.LkpLangDesc)
                    .HasMaxLength(20)
                    .HasColumnName("lkp_lang_desc");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .HasColumnName("active_flg")
                    .IsFixedLength();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .HasColumnName("deleted")
                    .IsFixedLength();

                entity.Property(e => e.DisplayOrdrNo)
                    .HasPrecision(6)
                    .HasColumnName("display_ordr_no");

                entity.Property(e => e.LkpLangDescParent)
                    .HasMaxLength(100)
                    .HasColumnName("lkp_lang_desc_parent");

                entity.Property(e => e.LkpNameParent)
                    .HasMaxLength(50)
                    .HasColumnName("lkp_name_parent");

                entity.Property(e => e.LkpValCdParent)
                    .HasMaxLength(100)
                    .HasColumnName("lkp_val_cd_parent");

                entity.Property(e => e.LkpValDesc)
                    .HasMaxLength(4000)
                    .HasColumnName("lkp_val_desc");
            });

            modelBuilder.Entity<AcRoutine>(entity =>
            {
                entity.HasKey(e => e.RoutineId)
                    .HasName("PRIMARY");

                entity.ToTable("ac_routine");

                entity.Property(e => e.RoutineId).HasColumnName("routine_id");

                entity.Property(e => e.AdminStatusCd)
                    .HasMaxLength(25)
                    .HasColumnName("admin_status_cd");

                entity.Property(e => e.AlarmCategCd)
                    .HasMaxLength(32)
                    .HasColumnName("alarm_categ_cd");

                entity.Property(e => e.AlarmSubcategCd)
                    .HasMaxLength(32)
                    .HasColumnName("alarm_subcateg_cd");

                entity.Property(e => e.AlarmTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("alarm_type_cd");

                entity.Property(e => e.ComparedDateAttribute)
                    .HasMaxLength(255)
                    .HasColumnName("compared_date_attribute");

                entity.Property(e => e.CorrespondingViewNm)
                    .HasMaxLength(1024)
                    .HasColumnName("corresponding_view_nm");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.CurrentInd)
                    .HasMaxLength(1)
                    .HasColumnName("current_ind")
                    .IsFixedLength();

                entity.Property(e => e.DfltSupprDurCount)
                    .HasPrecision(10)
                    .HasColumnName("dflt_suppr_dur_count");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.EndUserId)
                    .HasMaxLength(60)
                    .HasColumnName("end_user_id");

                entity.Property(e => e.ExecProbRate)
                    .HasPrecision(7, 7)
                    .HasColumnName("exec_prob_rate");

                entity.Property(e => e.HeaderId)
                    .HasPrecision(12)
                    .HasColumnName("header_id");

                /*entity.Property(e => e.IsProcedure)
                    .HasMaxLength(1)
                    .HasColumnName("is_procedure")
                    .IsFixedLength();*/

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("last_update_user_id");

                entity.Property(e => e.LogicDelInd)
                    .HasMaxLength(1)
                    .HasColumnName("logic_del_ind")
                    .IsFixedLength();

                entity.Property(e => e.MlBayesWeight)
                    .HasPrecision(15, 5)
                    .HasColumnName("ml_bayes_weight");

                entity.Property(e => e.ObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("obj_level_cd");

                entity.Property(e => e.OrderInHeader)
                    .HasPrecision(10)
                    .HasColumnName("order_in_header");

                /*entity.Property(e => e.OrderParameterBracket)
                    .HasMaxLength(4000)
                    .HasColumnName("order_parameter_bracket");*/

                /*entity.Property(e => e.OrderParameterCondition)
                    .HasMaxLength(4000)
                    .HasColumnName("order_parameter_condition");*/

                entity.Property(e => e.PrimObjNoVarName)
                    .HasMaxLength(32)
                    .HasColumnName("prim_obj_no_var_name");

                /*entity.Property(e => e.ProcedureName)
                    .HasMaxLength(500)
                    .HasColumnName("procedure_name");*/

                entity.Property(e => e.ProdTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("prod_type_cd");

                entity.Property(e => e.RiskFactInd)
                    .HasMaxLength(1)
                    .HasColumnName("risk_fact_ind")
                    .IsFixedLength();

                entity.Property(e => e.RootKey)
                    .HasPrecision(12)
                    .HasColumnName("root_key");

                entity.Property(e => e.RouteGrpId)
                    .HasPrecision(12)
                    .HasColumnName("route_grp_id");

                entity.Property(e => e.RouteUserLongId)
                    .HasMaxLength(60)
                    .HasColumnName("route_user_long_id");

                entity.Property(e => e.RoutineCategCd)
                    .HasMaxLength(50)
                    .HasColumnName("routine_categ_cd");

                entity.Property(e => e.RoutineCdLocDesc)
                    .HasMaxLength(255)
                    .HasColumnName("routine_cd_loc_desc");

                entity.Property(e => e.RoutineDesc)
                    .HasMaxLength(255)
                    .HasColumnName("routine_desc");

                entity.Property(e => e.RoutineDurCount)
                    .HasPrecision(10)
                    .HasColumnName("routine_dur_count");

                entity.Property(e => e.RoutineMsgTxt)
                    .HasMaxLength(255)
                    .HasColumnName("routine_msg_txt");

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(500)
                    .HasColumnName("routine_name");

                entity.Property(e => e.RoutineRunFreqCd)
                    .HasMaxLength(3)
                    .HasColumnName("routine_run_freq_cd");

                entity.Property(e => e.RoutineShortDesc)
                    .HasMaxLength(500)
                    .HasColumnName("routine_short_desc");

                entity.Property(e => e.RoutineStatusCd)
                    .HasMaxLength(3)
                    .HasColumnName("routine_status_cd");

                entity.Property(e => e.RoutineTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("routine_type_cd");

                entity.Property(e => e.SaveTrigTransInd)
                    .HasMaxLength(1)
                    .HasColumnName("save_trig_trans_ind")
                    .IsFixedLength();

                entity.Property(e => e.SkipIfNoTransCcyDayInd)
                    .HasMaxLength(1)
                    .HasColumnName("skip_if_no_trans_ccy_day_ind")
                    .IsFixedLength();

                entity.Property(e => e.TfBayesWeight)
                    .HasPrecision(15, 5)
                    .HasColumnName("tf_bayes_weight");

                entity.Property(e => e.VerNo)
                    .HasPrecision(10)
                    .HasColumnName("ver_no");

                entity.Property(e => e.VsdInstallationName)
                    .HasMaxLength(255)
                    .HasColumnName("vsd_installation_name");

                entity.Property(e => e.VsdWinName)
                    .HasMaxLength(25)
                    .HasColumnName("vsd_win_name");
            });

            modelBuilder.Entity<AcRoutineParameter>(entity =>
            {
                entity.HasKey(e => new { e.RoutineId, e.ParmName })
                    .HasName("PRIMARY");

                entity.ToTable("ac_routine_parameter");

                entity.Property(e => e.RoutineId)
                    .HasPrecision(12)
                    .HasColumnName("routine_id");

                entity.Property(e => e.ParmName)
                    .HasMaxLength(32)
                    .HasColumnName("parm_name");

                entity.Property(e => e.DayType)
                    .HasMaxLength(10)
                    .HasColumnName("day_type");

                /*entity.Property(e => e.LogicOperator)
                    .HasMaxLength(3)
                    .HasColumnName("logic_operator");*/

                entity.Property(e => e.ParamCondition).HasColumnName("param_condition");

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(255)
                    .HasColumnName("parm_desc");

                entity.Property(e => e.ParmTypeDesc)
                    .HasMaxLength(32)
                    .HasColumnName("parm_type_desc");

                entity.Property(e => e.ParmValue)
                    .HasMaxLength(1024)
                    .HasColumnName("parm_value");

                entity.Property(e => e.ValueCate)
                    .HasMaxLength(32)
                    .HasColumnName("value_cate");
            });

            modelBuilder.Entity<AcScenarioEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ac_scenario_event");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("create_user_id");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(255)
                    .HasColumnName("event_desc");

                entity.Property(e => e.EventId)
                    .HasPrecision(12)
                    .HasColumnName("event_id");

                entity.Property(e => e.EventTypeCd)
                    .HasMaxLength(60)
                    .HasColumnName("event_type_cd");

                entity.Property(e => e.ScenarioRootKey)
                    .HasPrecision(12)
                    .HasColumnName("scenario_root_key");
            });

            modelBuilder.Entity<AcSuspectedObject>(entity =>
            {
                entity.HasKey(e => new { e.AlarmedObjLevelCd, e.AlarmedObjNo })
                    .HasName("PRIMARY");

                entity.ToTable("ac_suspected_object");

                entity.Property(e => e.AlarmedObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("alarmed_obj_level_cd");

                entity.Property(e => e.AlarmedObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("alarmed_obj_no");

                entity.Property(e => e.AgeOldAlarm)
                    .HasPrecision(10)
                    .HasColumnName("age_old_alarm");

                entity.Property(e => e.AggAmt)
                    .HasPrecision(15, 3)
                    .HasColumnName("agg_amt");

                entity.Property(e => e.AlarmedObjKey)
                    .HasPrecision(12)
                    .HasColumnName("alarmed_obj_key");

                entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(100)
                    .HasColumnName("alarmed_obj_name");

                entity.Property(e => e.AlarmsCount)
                    .HasPrecision(10)
                    .HasColumnName("alarms_count");

                entity.Property(e => e.Branch)
                    .HasMaxLength(50)
                    .HasColumnName("branch");

                entity.Property(e => e.CreateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("create_timestamp");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .HasColumnName("emp_ind")
                    .IsFixedLength();

                entity.Property(e => e.MlScore)
                    .HasPrecision(10)
                    .HasColumnName("ml_score");

                entity.Property(e => e.OwnerUid)
                    .HasMaxLength(240)
                    .HasColumnName("owner_uid");

                entity.Property(e => e.PoliticalExpPersonInd)
                    .HasMaxLength(1)
                    .HasColumnName("political_exp_person_ind")
                    .IsFixedLength();

                entity.Property(e => e.ProdType)
                    .HasMaxLength(3)
                    .HasColumnName("prod_type");

                /*entity.Property(e => e.RiskClass)
                    .HasPrecision(38)
                    .HasColumnName("risk_class");*/

                entity.Property(e => e.RiskScoreCd)
                    .HasMaxLength(32)
                    .HasColumnName("risk_score_cd");

                entity.Property(e => e.SuspectIdentity)
                    .HasMaxLength(50)
                    .HasColumnName("suspect_identity");

                entity.Property(e => e.SuspectQueue)
                    .HasMaxLength(50)
                    .HasColumnName("suspect_queue");

                entity.Property(e => e.TransCount)
                    .HasPrecision(10)
                    .HasColumnName("trans_count");
            });


            /*/// core 
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AcctKey)
                    .HasName("PRIMARY");

                entity.ToTable("account", "dgamlcore");

                entity.Property(e => e.AcctKey).HasColumnName("acct_key");

                entity.Property(e => e.AcctCcyCd)
                    .HasMaxLength(3)
                    .HasColumnName("acct_ccy_cd");

                entity.Property(e => e.AcctCcyName)
                    .HasMaxLength(100)
                    .HasColumnName("acct_ccy_name");

                entity.Property(e => e.AcctCloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("acct_close_date");

                entity.Property(e => e.AcctName)
                    .HasMaxLength(200)
                    .HasColumnName("acct_name");


                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("acct_no");

                entity.Property(e => e.AcctOpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("acct_open_date");

                entity.Property(e => e.AcctPrimBranchName)
                    .HasMaxLength(35)
                    .HasColumnName("acct_prim_branch_name");

                entity.Property(e => e.AcctRegName)
                    .HasMaxLength(255)
                    .HasColumnName("acct_reg_name");

                entity.Property(e => e.AcctRegTypeDesc)
                    .HasMaxLength(35)
                    .HasColumnName("acct_reg_type_desc");

                entity.Property(e => e.AcctStatusDesc)
                    .HasMaxLength(50)
                    .HasColumnName("acct_status_desc");

                entity.Property(e => e.AcctTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("acct_tax_id");

                entity.Property(e => e.AcctTaxIdTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("acct_tax_id_type_cd")
                    .IsFixedLength();

                entity.Property(e => e.AcctTaxStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("acct_tax_state_cd");

                entity.Property(e => e.AcctTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("acct_type_desc");

                entity.Property(e => e.AltName)
                    .HasMaxLength(200)
                    .HasColumnName("alt_name");

                entity.Property(e => e.CashIntsBusInd)
                    .HasMaxLength(1)
                    .HasColumnName("cash_ints_bus_ind")
                    .IsFixedLength();

                entity.Property(e => e.CcyBasedAcctInd)
                    .HasMaxLength(1)
                    .HasColumnName("ccy_based_acct_ind")
                    .IsFixedLength();

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("chg_begin_date");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .HasColumnName("chg_current_ind")
                    .HasDefaultValueSql("'Y'")
                    .IsFixedLength();

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("chg_end_date")
                    .HasDefaultValueSql("'2000-01-01 00:00:00'");

                entity.Property(e => e.ColtrlTypeCd)
                    .HasMaxLength(50)
                    .HasColumnName("coltrl_type_cd");

                entity.Property(e => e.ColtrlTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("coltrl_type_desc");

                entity.Property(e => e.DormInd)
                    .HasMaxLength(1)
                    .HasColumnName("dorm_ind")
                    .IsFixedLength();

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .HasColumnName("emp_ind")
                    .IsFixedLength();

                entity.Property(e => e.InstAmt)
                    .HasPrecision(15, 5)
                    .HasColumnName("inst_amt");

                entity.Property(e => e.InsurAmt)
                    .HasPrecision(15, 5)
                    .HasColumnName("insur_amt");

                entity.Property(e => e.LetterCrOnfileInd)
                    .HasMaxLength(1)
                    .HasColumnName("letter_cr_onfile_ind")
                    .IsFixedLength();

                entity.Property(e => e.LineBusName)
                    .HasMaxLength(50)
                    .HasColumnName("line_bus_name");

                entity.Property(e => e.MailAddr1)
                    .HasMaxLength(350)
                    .HasColumnName("mail_addr_1");

                entity.Property(e => e.MailAddr2)
                    .HasMaxLength(350)
                    .HasColumnName("mail_addr_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(35)
                    .HasColumnName("mail_city_name");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("mail_cntry_cd")
                    .IsFixedLength();

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("mail_cntry_name");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .HasColumnName("mail_post_cd")
                    .IsFixedLength();

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("mail_state_cd")
                    .IsFixedLength();

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(35)
                    .HasColumnName("mail_state_name");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("maturity_date");

                entity.Property(e => e.OrigLoanAmt)
                    .HasPrecision(15, 5)
                    .HasColumnName("orig_loan_amt");

                entity.Property(e => e.ProdCategName)
                    .HasMaxLength(35)
                    .HasColumnName("prod_categ_name");

                entity.Property(e => e.ProdLineName)
                    .HasMaxLength(35)
                    .HasColumnName("prod_line_name");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(100)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdNo)
                    .HasMaxLength(25)
                    .HasColumnName("prod_no");

                entity.Property(e => e.ProdTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("prod_type_name");

                entity.Property(e => e.Tenure)
                    .HasMaxLength(10)
                    .HasColumnName("tenure");

                entity.Property(e => e.TradeFinInd)
                    .HasMaxLength(1)
                    .HasColumnName("trade_fin_ind")
                    .IsFixedLength();

                entity.Property(e => e.Vinno)
                    .HasMaxLength(50)
                    .HasColumnName("vinno");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustKey)
                    .HasName("PRIMARY");

                entity.ToTable("customer", "dgamlcore");

                entity.Property(e => e.CustKey).HasColumnName("cust_key");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(100)
                    .HasColumnName("addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(100)
                    .HasColumnName("addr_2");

                entity.Property(e => e.AnnualIncomeAmt)
                    .HasPrecision(10)
                    .HasColumnName("annual_income_amt");

                entity.Property(e => e.CcyExchInd)
                    .HasMaxLength(1)
                    .HasColumnName("ccy_exch_ind")
                    .IsFixedLength();

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(1)
                    .HasColumnName("check_casher_ind")
                    .IsFixedLength();

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("chg_begin_date");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .HasColumnName("chg_current_ind")
                    .HasDefaultValueSql("'Y'")
                    .IsFixedLength();

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("chg_end_date")
                    .HasDefaultValueSql("'2000-01-01 00:00:00'");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("citizen_cntry_cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("citizen_cntry_name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasColumnName("city_name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("cntry_cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("cntry_name");

                entity.Property(e => e.CustBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cust_birth_date");

                entity.Property(e => e.CustFname)
                    .HasMaxLength(50)
                    .HasColumnName("cust_fname");

                entity.Property(e => e.CustGen)
                    .HasMaxLength(2)
                    .HasColumnName("cust_gen")
                    .IsFixedLength();

                entity.Property(e => e.CustIdCntryCd)
                    .HasMaxLength(50)
                    .HasColumnName("cust_id_cntry_cd");

                entity.Property(e => e.CustIdStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("cust_id_state_cd");

                entity.Property(e => e.CustIdentExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cust_ident_exp_date");

                entity.Property(e => e.CustIdentId)
                    .HasMaxLength(35)
                    .HasColumnName("cust_ident_id");

                entity.Property(e => e.CustIdentIssDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cust_ident_iss_date");

                entity.Property(e => e.CustIdentTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("cust_ident_type_desc");

                entity.Property(e => e.CustLname)
                    .HasMaxLength(100)
                    .HasColumnName("cust_lname");

                entity.Property(e => e.CustMname)
                    .HasMaxLength(100)
                    .HasColumnName("cust_mname");

                entity.Property(e => e.CustName)
                    .HasMaxLength(200)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustNo)
                    .HasMaxLength(50)
                    .HasColumnName("cust_no");

                entity.Property(e => e.CustSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cust_since_date");

                entity.Property(e => e.CustStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("cust_status_desc");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("cust_tax_id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .HasColumnName("cust_tax_id_type_cd")
                    .IsFixedLength();

                entity.Property(e => e.CustTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("cust_type_desc");

                entity.Property(e => e.DoBusAsName)
                    .HasMaxLength(50)
                    .HasColumnName("do_bus_as_name");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(35)
                    .HasColumnName("email_addr");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .HasColumnName("emp_ind")
                    .IsFixedLength();

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(50)
                    .HasColumnName("emp_no");

                entity.Property(e => e.EmprName)
                    .HasMaxLength(100)
                    .HasColumnName("empr_name");

                entity.Property(e => e.EmprTelNo)
                    .HasMaxLength(25)
                    .HasColumnName("empr_tel_no");

                entity.Property(e => e.ExtCustInd)
                    .HasMaxLength(1)
                    .HasColumnName("ext_cust_ind")
                    .IsFixedLength();

                entity.Property(e => e.FrgnConsulate)
                    .HasMaxLength(1)
                    .HasColumnName("frgn_consulate")
                    .IsFixedLength();

                entity.Property(e => e.IndsCd)
                    .HasMaxLength(10)
                    .HasColumnName("inds_cd");

                entity.Property(e => e.IndsCdRr)
                    .HasMaxLength(10)
                    .HasColumnName("inds_cd_rr");

                entity.Property(e => e.IndsDesc)
                    .HasMaxLength(255)
                    .HasColumnName("inds_desc");

                entity.Property(e => e.InternetGmblngInd)
                    .HasMaxLength(1)
                    .HasColumnName("internet_gmblng_ind")
                    .IsFixedLength();

                entity.Property(e => e.IssBearsSharesInd)
                    .HasMaxLength(1)
                    .HasColumnName("iss_bears_shares_ind")
                    .IsFixedLength();

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_contact_date");

                entity.Property(e => e.LegalObjType)
                    .HasMaxLength(30)
                    .HasColumnName("legal_obj_type");

                entity.Property(e => e.LstCashTransReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lst_cash_trans_report_date");

                entity.Property(e => e.LstRiskAssmntDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lst_risk_assmnt_date");

                entity.Property(e => e.LstSuspActReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lst_susp_act_report_date");

                entity.Property(e => e.LstUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lst_update_date");

                entity.Property(e => e.MachCdMailAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("mach_cd_mail_addr_line");

                entity.Property(e => e.MailAddr1)
                    .HasMaxLength(50)
                    .HasColumnName("mail_addr_1");

                entity.Property(e => e.MailAddr2)
                    .HasMaxLength(50)
                    .HasColumnName("mail_addr_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(50)
                    .HasColumnName("mail_city_name");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(50)
                    .HasColumnName("mail_cntry_cd");

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("mail_cntry_name");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .HasColumnName("mail_post_cd");

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("mail_state_cd");

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(35)
                    .HasColumnName("mail_state_name");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("marital_status_desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_addr_line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_city");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_indv");

                entity.Property(e => e.MatchCdMailAddr)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_mail_addr");

                entity.Property(e => e.MatchCdMailCity)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_mail_city");

                entity.Property(e => e.MatchCdMailCntry)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_mail_cntry");

                entity.Property(e => e.MatchCdMailState)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_mail_state");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_state");

                entity.Property(e => e.MoneyOrderInd)
                    .HasMaxLength(1)
                    .HasColumnName("money_order_ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyServiceBusInd)
                    .HasMaxLength(1)
                    .HasColumnName("money_service_bus_ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyTransmtrInd)
                    .HasMaxLength(1)
                    .HasColumnName("money_transmtr_ind")
                    .IsFixedLength();

                entity.Property(e => e.NationalAddr)
                    .HasMaxLength(250)
                    .HasColumnName("national_addr");

                entity.Property(e => e.NegtvNewsInd)
                    .HasMaxLength(1)
                    .HasColumnName("negtv_news_ind")
                    .IsFixedLength();

                entity.Property(e => e.NetWorthAmt)
                    .HasPrecision(10)
                    .HasColumnName("net_worth_amt");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .HasColumnName("non_profit_org_ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupDesc)
                    .HasMaxLength(100)
                    .HasColumnName("occup_desc");

                entity.Property(e => e.OrgCntryOfBusCd)
                    .HasMaxLength(3)
                    .HasColumnName("org_cntry_of_bus_cd");

                entity.Property(e => e.OrgCntryOfBusName)
                    .HasMaxLength(100)
                    .HasColumnName("org_cntry_of_bus_name");

                entity.Property(e => e.ParentName)
                    .HasMaxLength(50)
                    .HasColumnName("parent_name");

                entity.Property(e => e.PoliticalExpPrsnInd)
                    .HasMaxLength(1)
                    .HasColumnName("political_exp_prsn_ind")
                    .IsFixedLength();

                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("post_cd");

                entity.Property(e => e.PrepCardInd)
                    .HasMaxLength(1)
                    .HasColumnName("prep_card_ind")
                    .IsFixedLength();

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("resid_cntry_cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("resid_cntry_name");

                entity.Property(e => e.RiskClass)
                    .HasPrecision(10)
                    .HasColumnName("risk_class");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("state_cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .HasColumnName("state_name");

                entity.Property(e => e.SuspActRptCount)
                    .HasPrecision(4)
                    .HasColumnName("susp_act_rpt_count");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_2");

                entity.Property(e => e.TelNo3)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_3");

                entity.Property(e => e.TravChekInd)
                    .HasMaxLength(1)
                    .HasColumnName("trav_chek_ind")
                    .IsFixedLength();

                entity.Property(e => e.TrustAcctInd)
                    .HasMaxLength(1)
                    .HasColumnName("trust_acct_ind")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExternalCustomer>(entity =>
            {
                entity.HasKey(e => e.ExtCustAcctKey)
                    .HasName("PRIMARY");

                entity.ToTable("external_customer", "dgamlcore");

                entity.Property(e => e.ExtCustAcctKey).HasColumnName("ext_cust_acct_key");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("acct_no");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(35)
                    .HasColumnName("addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(35)
                    .HasColumnName("addr_2");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("branch_name");

                entity.Property(e => e.BranchNo)
                    .HasMaxLength(25)
                    .HasColumnName("branch_no");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("citizen_cntry_cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("citizen_cntry_name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("city_name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("cntry_cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("cntry_name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("cust_tax_id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .HasColumnName("cust_tax_id_type_cd")
                    .IsFixedLength();

                entity.Property(e => e.ExtBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ext_birth_date");

                entity.Property(e => e.ExtCustNo)
                    .HasMaxLength(100)
                    .HasColumnName("ext_cust_no");

                entity.Property(e => e.ExtCustTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("ext_cust_type_desc");

                entity.Property(e => e.ExtFname)
                    .HasMaxLength(50)
                    .HasColumnName("ext_fname");

                entity.Property(e => e.ExtFullName)
                    .HasMaxLength(200)
                    .HasColumnName("ext_full_name");


                entity.Property(e => e.ExtLname)
                    .HasMaxLength(100)
                    .HasColumnName("ext_lname");

                entity.Property(e => e.ExtMname)
                    .HasMaxLength(50)
                    .HasColumnName("ext_mname");

                entity.Property(e => e.FiNo)
                    .HasMaxLength(25)
                    .HasColumnName("fi_no");

                entity.Property(e => e.IdentCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("ident_cntry_cd");

                entity.Property(e => e.IdentCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("ident_cntry_name");

                entity.Property(e => e.IdentId)
                    .HasMaxLength(35)
                    .HasColumnName("ident_id");

                entity.Property(e => e.IdentStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("ident_state_cd");

                entity.Property(e => e.IdentTypeDesc)
                    .HasMaxLength(4)
                    .HasColumnName("ident_type_desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_addr_line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_city");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_indv");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("match_cd_state");


                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("post_cd");

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("resid_cntry_cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("resid_cntry_name");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("state_cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(35)
                    .HasColumnName("state_name");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("tel_no_2");
            });*/
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
            modelBuilder.HasDefaultSchema("target");
            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.ToTable("lookups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessUnit)
                    .HasMaxLength(255)
                    .HasColumnName("business_unit");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("description");

                entity.Property(e => e.LookupKey)
                    .HasMaxLength(255)
                    .HasColumnName("lookup_key");

                entity.Property(e => e.LookupName)
                    .HasMaxLength(255)
                    .HasColumnName("lookup_name");

                entity.Property(e => e.LookupValue)
                    .HasMaxLength(255)
                    .HasColumnName("lookup_value");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .HasColumnName("modified_by");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.CurrencyCodeLocal)
                    .HasMaxLength(255)
                    .HasColumnName("currencycodelocal");

                entity.Property(e => e.EntityReference)
                    .HasMaxLength(255)
                    .HasColumnName("entityreference");

                entity.Property(e => e.FiuRefNumber)
                    .HasMaxLength(255)
                    .HasColumnName("fiurefnumber");

                entity.Property(e => e.IsValid)
                    .HasColumnName("isvalid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                /*entity.Property(e => e.PrevRejectedRefNumber)
                    .HasMaxLength(255)
                    .HasColumnName("prevrejectedrefnumber");*/

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("priority");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.RentityBranch)
                    .HasMaxLength(255)
                    .HasColumnName("rentitybranch");

                entity.Property(e => e.RentityId).HasColumnName("rentityid");

                entity.Property(e => e.ReportClosedDate)
                    .HasMaxLength(255)
                    .HasColumnName("reportcloseddate");

                entity.Property(e => e.ReportCode)
                    .HasMaxLength(255)
                    .HasColumnName("reportcode");

                entity.Property(e => e.ReportCreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("reportcreatedby");

                entity.Property(e => e.ReportCreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("reportcreateddate");

                /*entity.Property(e => e.ReportDate)
                    .HasMaxLength(255)
                    .HasColumnName("reportdate");*/

                entity.Property(e => e.ReportingPersonType)
                    .HasMaxLength(255)
                    .HasColumnName("reportingpersontype");

                /*entity.Property(e => e.ReportingUserCode)
                    .HasMaxLength(255)
                    .HasColumnName("reportingusercode");*/

                entity.Property(e => e.ReportRiskSignificance)
                    .HasMaxLength(255)
                    .HasColumnName("reportrisksignificance");

                entity.Property(e => e.ReportStatusCode)
                    .HasMaxLength(255)
                    .HasColumnName("reportstatuscode");

                entity.Property(e => e.ReportUserLockId)
                    .HasMaxLength(255)
                    .HasColumnName("reportuserlockid");

                entity.Property(e => e.ReportXml)
                    .HasMaxLength(255)
                    .HasColumnName("reportxml");

                /*entity.Property(e => e.Schemaversion)
                    .HasMaxLength(255)
                    .HasColumnName("schemaversion");*/

                entity.Property(e => e.SubmissionCode)
                    .HasMaxLength(255)
                    .HasColumnName("submissioncode");

                entity.Property(e => e.SubmissionDate)
                    .HasMaxLength(255)
                    .HasColumnName("submissiondate");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<ReportIndicatorType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("reportindicatortype");

                entity.HasIndex(e => e.ReportId, "fk4seph8dn9avanwot531mj3js0");

                entity.Property(e => e.Indicator)
                    .HasMaxLength(255)
                    .HasColumnName("indicator");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk4seph8dn9avanwot531mj3js0");
            });

            modelBuilder.Entity<Taccount>(entity =>
            {
                entity.ToTable("taccount");

                //entity.HasIndex(e => e.AccountRelatedAccountId, "fk_taccount_accountrelatedaccounttype_fk");

                entity.HasIndex(e => e.ReportPartyTypeId, "fkrgcw0f1jedbrws22wjfiaf5x8");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account");

                //entity.Property(e => e.AccountRelatedAccountId).HasColumnName("account_related_account_id");

               /* entity.Property(e => e.AccountCategory)
                    .HasMaxLength(255)
                    .HasColumnName("accountcategory");*/

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .HasColumnName("accountname");

               /* entity.Property(e => e.AccountType)
                    .HasMaxLength(255)
                    .HasColumnName("accounttype");*/

                entity.Property(e => e.Balance)
                    .HasPrecision(30, 5)
                    .HasColumnName("balance");

                entity.Property(e => e.Beneficiary)
                    .HasMaxLength(255)
                    .HasColumnName("beneficiary");

                entity.Property(e => e.BeneficiaryComment)
                    .HasMaxLength(255)
                    .HasColumnName("beneficiarycomment");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasColumnName("branch");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .HasColumnName("clientnumber");

                entity.Property(e => e.Closed)
                    .HasMaxLength(255)
                    .HasColumnName("closed");

                //entity.Property(e => e.CollectionAccount).HasColumnName("collectionaccount");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .HasColumnName("comments");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(255)
                    .HasColumnName("currencycode");

                entity.Property(e => e.DateBalance)
                    .HasMaxLength(255)
                    .HasColumnName("datebalance");

                /*entity.Property(e => e.Dtype)
                    .HasMaxLength(31)
                    .HasColumnName("dtype");*/

                entity.Property(e => e.Iban)
                    .HasMaxLength(255)
                    .HasColumnName("iban");

                entity.Property(e => e.InstitutionCode)
                    .HasMaxLength(255)
                    .HasColumnName("institutioncode");

               /* entity.Property(e => e.InstitutionCountry)
                    .HasMaxLength(255)
                    .HasColumnName("institutioncountry");*/

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(255)
                    .HasColumnName("institutionname");

                entity.Property(e => e.IsReviewed).HasColumnName("is_reviewed");

                entity.Property(e => e.IsEntity).HasColumnName("isentity");

                entity.Property(e => e.NonBankInstitution).HasColumnName("nonbankinstitution");

                entity.Property(e => e.Opened)
                    .HasMaxLength(255)
                    .HasColumnName("opened");

                entity.Property(e => e.PersonalAccountType)
                    .HasMaxLength(255)
                    .HasColumnName("personalaccounttype");

                entity.Property(e => e.ReportPartyTypeId).HasColumnName("reportpartytype_id");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(255)
                    .HasColumnName("statuscode");

                /*entity.Property(e => e.StatusDate)
                    .HasMaxLength(255)
                    .HasColumnName("statusdate");*/

                entity.Property(e => e.Swift)
                    .HasMaxLength(255)
                    .HasColumnName("swift");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");
            });
        }

        public void OnTiZoneModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnDGMGMGModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dgmgmt");
            modelBuilder.Entity<GroupDg>(entity =>
            {
                entity.ToTable("group_dg");

                entity.HasIndex(e => e.Name, "UK_79kwwaf53vdtgfxwsemb2q3au")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(4000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<RoleDg>(entity =>
            {
                entity.ToTable("role_dg");

                entity.HasIndex(e => e.Name, "UK_9dg6bnig1y6lu7h5njsigd013")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(4000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .HasColumnName("role_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<UserDg>(entity =>
            {
                entity.ToTable("user_dg");

                entity.HasIndex(e => e.Name, "UK_user_dgname")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasColumnName("active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock)
                    .HasColumnName("counter_lock")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(4000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Enable)
                    .HasColumnType("bit(1)")
                    .HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");
            });

        }

        public void OnDGMGMGMAUDodelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dgmgmt_audit");
            modelBuilder.Entity<AccountAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PRIMARY");

                entity.ToTable("account_aud");

                entity.HasIndex(e => e.Rev, "FKaexie5n0kol2mjlvo03ii45d0");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.AuthenticationDomain)
                    .HasMaxLength(255)
                    .HasColumnName("authentication_domain");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<GroupDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PRIMARY");

                entity.ToTable("group_dg_aud");

                entity.HasIndex(e => e.Rev, "FK3a7e9ksl1vp5p9yjbw0qv395y");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(4000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<LoggedUserAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PRIMARY");

                entity.ToTable("logged_user_aud");

                entity.HasIndex(e => e.Rev, "FKggnqsx4am1qbxeqktimay3sp2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .HasColumnName("app_name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .HasColumnName("device_name");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .HasColumnName("device_type");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("ip");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<RoleDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PRIMARY");

                entity.ToTable("role_dg_aud");

                entity.HasIndex(e => e.Rev, "FKh1m6sn3f6w7916ub7b56nmrb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(4000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .HasColumnName("role_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<UserDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PRIMARY");

                entity.ToTable("user_dg_aud");

                entity.HasIndex(e => e.Rev, "FKqse7bd285mhgibraikfyv1un1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock).HasColumnName("counter_lock");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(4000)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Enable)
                    .HasColumnType("bit(1)")
                    .HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");
            });
        }

        public void OnCRPModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtCrpConfig>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_crp_config");

                entity.Property(e => e.ActionDetail)
                    .HasColumnType("text")
                    .HasColumnName("Action_Detail");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("case_id");

                entity.Property(e => e.Checker).HasMaxLength(60);

                entity.Property(e => e.CheckerAction)
                    .HasMaxLength(256)
                    .HasColumnName("Checker_Action");

                entity.Property(e => e.CheckerDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Checker_Date");

                entity.Property(e => e.Maker).HasMaxLength(60);

                entity.Property(e => e.MakerDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("Maker_Date");
            });

            modelBuilder.Entity<ArtCrpSystemPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_crp_system_performance");

                entity.Property(e => e.CaseCurrentRate)
                    .HasMaxLength(0)
                    .HasColumnName("CASE_CURRENT_RATE")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("text")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseType)
                    .HasColumnType("text")
                    .HasColumnName("Case_Type");

                entity.Property(e => e.Casetargetrate)
                    .HasMaxLength(0)
                    .HasColumnName("CASETARGETRATE")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.CustomerName)
                    .HasColumnType("mediumtext")
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnType("text")
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.DurationsInDays).HasColumnName("DURATIONS_In_days");

                entity.Property(e => e.DurationsInHours).HasColumnName("DURATIONS_In_hours");

                entity.Property(e => e.DurationsInMinutes).HasColumnName("DURATIONS_In_minutes");

                entity.Property(e => e.DurationsInSeconds).HasColumnName("DURATIONS_In_Seconds");

                entity.Property(e => e.EcmLastStatusDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("ECM_LAST_STATUS_DATE");
            });

            modelBuilder.Entity<ArtCrpUserPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("art_crp_user_performance");

                entity.Property(e => e.Action)
                    .HasMaxLength(256)
                    .HasColumnName("ACTION");

                entity.Property(e => e.ActionUser)
                    .HasMaxLength(60)
                    .HasColumnName("ACTION_USER");

                entity.Property(e => e.AsssignedTime)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("ASSSIGNED_TIME");

                entity.Property(e => e.CaseCurrentRate)
                    .HasMaxLength(0)
                    .HasColumnName("CASE_CURRENT_RATE")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("text")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseType)
                    .HasColumnType("text")
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.Casetargetrate)
                    .HasMaxLength(0)
                    .HasColumnName("CASETARGETRATE")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.CustomerName)
                    .HasColumnType("mediumtext")
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnType("text")
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.DurationsInDays).HasColumnName("DURATIONS_In_days");

                entity.Property(e => e.DurationsInHours).HasColumnName("DURATIONS_In_hours");

                entity.Property(e => e.DurationsInMinutes).HasColumnName("DURATIONS_In_minutes");

                entity.Property(e => e.DurationsInSeconds).HasColumnName("DURATIONS_In_Seconds");

                entity.Property(e => e.ReleasedDate)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("RELEASED_DATE");
            });
        }
        public void OnFATCAModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();

        }

        public void OnTRADE_BASEModelCreating(ModelBuilder modelBuilder)
        {

            throw new NotImplementedException();
        }

        public void OnSasAuditModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
