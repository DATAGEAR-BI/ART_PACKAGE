using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.Audit;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportsConfig
    {
        public static readonly Dictionary<string, ReportConfig> CONFIG = new()
        {


            { nameof(AlertDetailsController).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                    "Val",
                    "AlertsNotesFlag"
                },
               DisplayNames = new Dictionary<string, DisplayNameAndFormat>
            {
                    {"AlertId",new DisplayNameAndFormat { DisplayName ="Alert ID"}},
                    {"AlertedEntityName",new DisplayNameAndFormat { DisplayName ="Alerted Entity Name"}},
                    {"AlertedEntityNumber",new DisplayNameAndFormat { DisplayName ="Alerted Entity Number"}},
                    {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                    {"PartyTypeDesc",new DisplayNameAndFormat { DisplayName ="Party Type"}},
                    {"PoliticallyExposedPersonInd",new DisplayNameAndFormat { DisplayName ="PEP"}},
                    {"RunDate",new DisplayNameAndFormat { DisplayName ="Run Date"}},
                    {"CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                    {"CloseDate",new DisplayNameAndFormat { DisplayName ="Closed Date"}},
                    {"MoneyLaunderingRiskScore",new DisplayNameAndFormat { DisplayName ="Money Laundering RiskScore"}},
                    {"AlertTypeCd",new DisplayNameAndFormat { DisplayName ="Alert Type"}},
                    {"AlertSubCat",new DisplayNameAndFormat { DisplayName ="Alert Sub-Category"}},
                    {"AlertStatus",new DisplayNameAndFormat { DisplayName ="Alert Status"}},
                    {"AlertDescription",new DisplayNameAndFormat { DisplayName ="Alert Description"}},
                    {"ScenarioName",new DisplayNameAndFormat { DisplayName ="Scenario Name"}},
                    {"ReportCloseRsn",new DisplayNameAndFormat { DisplayName ="Report Close Reason"}},
                    {"ActualValuesText",new DisplayNameAndFormat { DisplayName ="Scenario Description"}},
                    {"OwnerUserid",new DisplayNameAndFormat { DisplayName ="Owner "}},
                    {"InvestigationDays",new DisplayNameAndFormat { DisplayName ="Investigation Days"}}

            }
               }
            },
            {
                nameof(ReportController).ToLower(),new ReportConfig
                {
                   SkipList =  new List<string>()
            {
                  nameof(ArtSavedCustomReport.User),
                  nameof(ArtSavedCustomReport.UserId),
                nameof(ArtSavedCustomReport.Schema),
                nameof(ArtSavedCustomReport.Columns),
                nameof(ArtSavedCustomReport.Charts),

            }
    }
            },
            {
                nameof(AlertedEntitiesController).ToLower(),new ReportConfig
                {
                   SkipList =  new List<string>()
            {


            }
    }
            },
            { nameof(SystemPerformanceController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                    { "CaseId", new DisplayNameAndFormat { DisplayName = "Case ID"}},
                    { "CaseType", new DisplayNameAndFormat { DisplayName = "Case Type"}},
                    { "CaseDesc", new DisplayNameAndFormat { DisplayName = "Case Description"}},
                    { "CaseStatus", new DisplayNameAndFormat { DisplayName = "Case Status"}},
                    { "Priority", new DisplayNameAndFormat { DisplayName = "Priority"}},
                    { "HitsCount", new DisplayNameAndFormat { DisplayName = "Hits Count"}},
                    { "TransactionDirection", new DisplayNameAndFormat { DisplayName = "Transaction Direction"}},
                    { "TransactionType", new DisplayNameAndFormat { DisplayName = "Transaction Type"}},
                    { "TransactionAmount", new DisplayNameAndFormat { DisplayName = "Transaction Amount"}},
                    { "TransactionCurrency", new DisplayNameAndFormat { DisplayName = "Transaction Currency"}},
                    { "SwiftReference", new DisplayNameAndFormat { DisplayName = "Swift Reference"}},
                    { "ClientName", new DisplayNameAndFormat { DisplayName = "Party Name"}},
                    { "IdentityNum", new DisplayNameAndFormat { DisplayName = "Party Number"}},
                    { "LockedBy", new DisplayNameAndFormat { DisplayName = "Locked By"}},
                    { "InvestrUserId", new DisplayNameAndFormat { DisplayName = "Investigator"}},
                    { "CreateDate", new DisplayNameAndFormat { DisplayName = "Create Date"}},
                    { "UpdateUserId", new DisplayNameAndFormat { DisplayName = "Updated By"}},
                    { "EcmLastStatusDate", new DisplayNameAndFormat { DisplayName = "Ecm Last Status Date"}},
                    { "DurationsInSeconds", new DisplayNameAndFormat { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new DisplayNameAndFormat { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new DisplayNameAndFormat { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new DisplayNameAndFormat { DisplayName = "Durations In Days"}}
            },
                SkipList = new List<string>
            {
                    "CaseRk",
                "ValidFromDate",
            }
            }
            },
            { nameof(UserPerformanceController).ToLower(),
                new ReportConfig{
                                        SkipList = new List<string>(){   "CaseRk","ValidFromDate","CreateUserId" } ,
                                        DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                                                        {
                                                                { "CaseId", new DisplayNameAndFormat { DisplayName = "Case ID"}},
                                                                { "CaseTypeCd", new DisplayNameAndFormat { DisplayName = "Case Type"}},
                                                                { "CaseDesc", new DisplayNameAndFormat { DisplayName = "Case Description"}},
                                                                { "CaseStatus", new DisplayNameAndFormat { DisplayName = "Case Status"}},
                                                                { "Priority", new DisplayNameAndFormat { DisplayName = "Priority"}},
                                                                { "LockedBy", new DisplayNameAndFormat { DisplayName = "Locked By"}},
                                                                { "CreateDate", new DisplayNameAndFormat { DisplayName = "Create Date"}},
                                                                { "UpdateUserId", new DisplayNameAndFormat { DisplayName = "Updated By"}},
                                                                { "AsssignedTime", new DisplayNameAndFormat { DisplayName = "Assigned Time"}},
                                                                { "ActionUser", new DisplayNameAndFormat { DisplayName = "Action User"}},
                                                                { "Action", new DisplayNameAndFormat { DisplayName = "Action"}},
                                                                { "ReleasedDate", new DisplayNameAndFormat { DisplayName = "Released Date"}},
                                                                { "DurationsInSeconds", new DisplayNameAndFormat { DisplayName = "Durations In Seconds"}},
                                                                { "DurationsInMinutes", new DisplayNameAndFormat { DisplayName = "Durations In Minutes"}},
                                                                { "DurationsInHours", new DisplayNameAndFormat { DisplayName = "Durations In Hours"}},
                                                                { "DurationsInDays", new DisplayNameAndFormat { DisplayName = "Durations In Days"}}
                                                        }
                                }
            }
            ,
            {
                nameof(GOAMLReportsSuspectController).ToLower(),new ReportConfig{
                    SkipList=new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                                 {"Id", new DisplayNameAndFormat { DisplayName = "Report ID"}},
                                 {"Reportcode", new DisplayNameAndFormat { DisplayName = "Report Type"}},
                                 {"Reportstatuscode", new DisplayNameAndFormat { DisplayName = "Report Status"}},
                                 {"Reportcreateddate", new DisplayNameAndFormat { DisplayName = "Create Date"}},
                                 {"Transactionnumber", new DisplayNameAndFormat { DisplayName = "Transaction Number"}},
                                 {"Submissiondate", new DisplayNameAndFormat { DisplayName = "Submission Date"}},
                                 {"Entityreference", new DisplayNameAndFormat { DisplayName = "Entity Reference"}},
                                 {"Fiurefnumber", new DisplayNameAndFormat { DisplayName = "FUI Reference Number"}},
                                 {"Account", new DisplayNameAndFormat { DisplayName = "Account"}},
                                 {"PartyId", new DisplayNameAndFormat { DisplayName = "Party ID"}},
                                 {"PartyName", new DisplayNameAndFormat { DisplayName = "Party Name"}},
                                 {"Partynumber", new DisplayNameAndFormat { DisplayName = "Party Number"}},
                                 {"Activity", new DisplayNameAndFormat { DisplayName = "Activity"}},
                                 {"Reportcloseddate", new DisplayNameAndFormat { DisplayName = "Close Date"}},
                                 {"Branch", new DisplayNameAndFormat { DisplayName = "Branch"}}
                    }
                }
            },
            {
                nameof(GOAMLReportsDetailsController).ToLower(),new ReportConfig{
                    SkipList = new List<string>
                    {
                              "Version",
                              "Isvalid",
                              "Location",
                              "Rentityid",
                              "Reportcloseddate",
                              "Reportrisksignificance",
                              "Reportxml",
                              "Submissioncode",
                    },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                                 {"Id", new DisplayNameAndFormat { DisplayName = "Report ID"}},
                                 {"Reportcode", new DisplayNameAndFormat { DisplayName = "Report Type"}},
                                 {"Reportstatuscode", new DisplayNameAndFormat { DisplayName = "Report Status"}},
                                 {"Reportcreateddate", new DisplayNameAndFormat { DisplayName = "Create Date"}},
                                 {"Submissiondate", new DisplayNameAndFormat { DisplayName = "Submission Date"}},
                                 {"Priority", new DisplayNameAndFormat { DisplayName = "Priority"}},
                                 {"Reportuserlockid", new DisplayNameAndFormat { DisplayName = "Locked By"}},
                                 {"Reportcreatedby", new DisplayNameAndFormat { DisplayName = "Created By"}},
                                 {"Action", new DisplayNameAndFormat { DisplayName = "Action"}},
                                 {"Currencycodelocal", new DisplayNameAndFormat { DisplayName = "Currency"}},
                                 {"LastUpdatedDate", new DisplayNameAndFormat { DisplayName = "Last Updated Date"}},
                                 {"Entityreference", new DisplayNameAndFormat { DisplayName = "Entity Reference"}},
                                 {"Fiurefnumber", new DisplayNameAndFormat { DisplayName = "FUI Reference Number"}},
                                 {"Rentitybranch", new DisplayNameAndFormat { DisplayName = "Branch"}},
                                 {"Reportingpersontype", new DisplayNameAndFormat { DisplayName = "Reporting Person Type"}},
                                 {"Reason", new DisplayNameAndFormat { DisplayName = "Reason"}}
                    }
                }
            },
            {
                nameof(GOAMLReportIndicatorDetailsController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                               {"ReportId", new DisplayNameAndFormat { DisplayName = "Report ID"}},
                               {"Indicator", new DisplayNameAndFormat { DisplayName = "Indicator Code"}},
                               {"Description", new DisplayNameAndFormat { DisplayName = "Description"}}
                    }
                }
            },

            {
                nameof(AuditGroupsController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {

                                {"GroupName", new DisplayNameAndFormat { DisplayName = "Group Name"}},
                                {"Action", new DisplayNameAndFormat { DisplayName = "Action"}},
                                {"Description", new DisplayNameAndFormat { DisplayName = "Description"}},
                                {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                                {"CreatedBy", new DisplayNameAndFormat { DisplayName = "Created By"}},
                                {"CreatedDate", new DisplayNameAndFormat { DisplayName = "Created Date"}},
                                {"LastUpdatedBy", new DisplayNameAndFormat { DisplayName = "Last Updated By"}},
                                {"LastUpdatedDate", new DisplayNameAndFormat { DisplayName = "Last Updated Date"}},
                                {"SubGroupNames", new DisplayNameAndFormat { DisplayName = "SubGroup Names"}},
                                {"RoleNames", new DisplayNameAndFormat { DisplayName = "Role Names"}},
                                {"MemberUsers", new DisplayNameAndFormat { DisplayName = "Member Users"}},

                    }
                }
            },
            {
                nameof(AuditRolesController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {

                                {"RoleName", new DisplayNameAndFormat { DisplayName = "Role Name"}},
                                {"Action", new DisplayNameAndFormat { DisplayName = "Action"}},
                                {"Description", new DisplayNameAndFormat { DisplayName = "Description"}},
                                {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                                {"CreatedBy", new DisplayNameAndFormat { DisplayName = "Created By"}},
                                {"CreatedDate", new DisplayNameAndFormat { DisplayName = "Created Date"}},
                                {"LastUpdatedBy", new DisplayNameAndFormat { DisplayName = "Last Updated By"}},
                                {"LastUpdatedDate", new DisplayNameAndFormat { DisplayName = "Last Updated Date"}},
                                {"GroupNames", new DisplayNameAndFormat { DisplayName = "Group Names"}},
                                {"MemberUsers", new DisplayNameAndFormat { DisplayName = "Member Users"}},

                    }
                }
            },
            {
                nameof(AuditUsersController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {

                                {"UserName", new DisplayNameAndFormat { DisplayName = "User Name"}},
                                {"Action", new DisplayNameAndFormat { DisplayName = "Action"}},
                                {"Address", new DisplayNameAndFormat { DisplayName = "Address"}},
                                {"Description", new DisplayNameAndFormat { DisplayName = "Description"}},
                                {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                                {"Email", new DisplayNameAndFormat { DisplayName = "Email"}},
                                {"Phone", new DisplayNameAndFormat { DisplayName = "Phone"}},
                                {"Status", new DisplayNameAndFormat { DisplayName = "Status"}},
                                {"CreatedBy", new DisplayNameAndFormat { DisplayName = "Created By"}},
                                {"CreatedDate", new DisplayNameAndFormat { DisplayName = "Created Date"}},
                                {"LastUpdatedBy", new DisplayNameAndFormat { DisplayName = "Last Updated By"}},
                                {"LastUpdatedDate", new DisplayNameAndFormat { DisplayName = "Last Updated Date"}},
                                {"LastLoginDate", new DisplayNameAndFormat { DisplayName = "Last Login Date"}},
                                {"LastFailedLogin", new DisplayNameAndFormat { DisplayName = "Last Failed Login"}},
                                {"Enable", new DisplayNameAndFormat { DisplayName = "Enable"}},
                                {"GroupNames", new DisplayNameAndFormat { DisplayName = "Group Names"}},
                                {"MemberUsers", new DisplayNameAndFormat { DisplayName = "Member Users"}},
                                {"DomainAccounts", new DisplayNameAndFormat { DisplayName = "Domain Accounts"}}

                    }
                }
            },
            {
                nameof(ListOfUsersRolesController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                               {"UserName", new DisplayNameAndFormat { DisplayName = "User Name"}},
                               {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                               {"Email", new DisplayNameAndFormat { DisplayName = "Email"}},
                               {"UserRole", new DisplayNameAndFormat { DisplayName = "User Role"}},
                    }
                }
            },
            {
                nameof(ListOfUsersGroupController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                               {"UserName", new DisplayNameAndFormat { DisplayName = "User Name"}},
                               {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                               {"Email", new DisplayNameAndFormat { DisplayName = "Email"}},
                               {"MemberOfGroup", new DisplayNameAndFormat { DisplayName = "Member Of Group"}},
                    }
                }
            },
            {
                nameof(ListOfUsersAndGroupsRoleController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                               {"UserName", new DisplayNameAndFormat { DisplayName = "User Name"}},
                               {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                               {"Email", new DisplayNameAndFormat { DisplayName = "Email"}},
                               {"MemberOfGroup", new DisplayNameAndFormat { DisplayName = "Member Of Group"}},
                               {"RoleOfGroup", new DisplayNameAndFormat { DisplayName = "Role Of Group"}},
                    }
                }
            },
            { nameof(ListGroupsSubGroupsSummaryController).ToLower() , new ReportConfig {
                DisplayNames = new Dictionary<string , DisplayNameAndFormat>
                {
                    { nameof(ListGroupsSubGroupsSummary.SubGroupName) , new DisplayNameAndFormat { DisplayName =  "Sub Group Name" } },
                    { nameof(ListGroupsRolesSummary.GroupName) , new DisplayNameAndFormat { DisplayName =  "Group Name" } }
                        }
                }
            },
            { nameof(ListGroupsRolesSummaryController).ToLower() , new ReportConfig {
                DisplayNames = new Dictionary<string , DisplayNameAndFormat>
                {
                    { nameof(ListGroupsRolesSummary.RoleName) , new DisplayNameAndFormat { DisplayName =  "Role Name" } },
                    { nameof(ListGroupsRolesSummary.GroupName) , new DisplayNameAndFormat { DisplayName =  "Group Name" } }
                        }
                }
            },{ nameof(ListOfGroupsController).ToLower() , new ReportConfig {
                DisplayNames = new Dictionary<string , DisplayNameAndFormat>
                {   { nameof(ListOfGroup.GroupName) , new DisplayNameAndFormat { DisplayName =  "Group Name" } },
                    { nameof(ListOfGroup.GroupType) , new DisplayNameAndFormat { DisplayName =  "Group Type" } },
                    { nameof(ListOfGroup.CreatedBy) , new DisplayNameAndFormat { DisplayName =  "Created By" } },
                    { nameof(ListOfGroup.CreatedDate) , new DisplayNameAndFormat { DisplayName =  "Created Date" } },
                    { nameof(ListOfGroup.DisplayName) , new DisplayNameAndFormat { DisplayName =  "Display Name" } },
                    { nameof(ListOfGroup.LastUpdatedBy) , new DisplayNameAndFormat { DisplayName =  "Last Updated By" } },
                    { nameof(ListOfGroup.LastUpdatedDate) , new DisplayNameAndFormat { DisplayName =  "Last Updated Date" } }, }
                }
            },
            { nameof(ListOfDeletedUsersController).ToLower() , new ReportConfig {
                DisplayNames = new Dictionary<string , DisplayNameAndFormat>
                {
                    { nameof(ListOfDeletedUser.UserType) , new DisplayNameAndFormat { DisplayName =  "User Type" } },
                    { nameof(ListOfDeletedUser.UserName) , new DisplayNameAndFormat { DisplayName =  "User Name" } },
                    { nameof(ListOfDeletedUser.CreatedBy) , new DisplayNameAndFormat { DisplayName =  "Created By" } },
                    { nameof(ListOfDeletedUser.CreatedDate) , new DisplayNameAndFormat { DisplayName =  "Created Date" } },
                    { nameof(ListOfDeletedUser.DisplayName) , new DisplayNameAndFormat { DisplayName =  "Display Name" } },
                    { nameof(ListOfDeletedUser.LastFailedLogin) , new DisplayNameAndFormat { DisplayName =  "Last Failed Login" } },
                    { nameof(ListOfDeletedUser.LastLoginDate) , new DisplayNameAndFormat { DisplayName =  "Last Login Date" } },
                        }
                }
            },
            { nameof(LastLoginPerDayController).ToLower() , new ReportConfig {
                DisplayNames = new Dictionary<string , DisplayNameAndFormat>
                {
                    { nameof(LastLoginPerDayView.AppName) , new DisplayNameAndFormat { DisplayName =  "App Name" } },
                    { nameof(LastLoginPerDayView.UserName) , new DisplayNameAndFormat { DisplayName =  "User Name" } },
                    { nameof(LastLoginPerDayView.DeviceName) , new DisplayNameAndFormat { DisplayName =  "Device Name" } },
                    { nameof(LastLoginPerDayView.DeviceType) , new DisplayNameAndFormat { DisplayName =  "Device Type" } },
                    { nameof(LastLoginPerDayView.Logindatetime) , new DisplayNameAndFormat { DisplayName =  "Login Date" } }
                        }
                }
            },

            {
                nameof(ListOfUserController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                               {"UserName", new DisplayNameAndFormat { DisplayName = "User Name"}},
                               {"Address", new DisplayNameAndFormat { DisplayName = "Address"}},
                               {"Description", new DisplayNameAndFormat { DisplayName = "Description"}},
                               {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                               {"Email", new DisplayNameAndFormat { DisplayName = "Email"}},
                               {"Phone", new DisplayNameAndFormat { DisplayName = "Phone"}},
                               {"UserType", new DisplayNameAndFormat { DisplayName = "User Type"}},
                               {"CreatedBy", new DisplayNameAndFormat { DisplayName = "Created By"}},
                               {"CreatedDate", new DisplayNameAndFormat { DisplayName = "Created Date"}},
                               {"LastUpdatedBy", new DisplayNameAndFormat { DisplayName = "Last Updated By"}},
                               {"LastUpdatedDate", new DisplayNameAndFormat { DisplayName = "Last Updated Date"}},
                               {"LastLoginDate", new DisplayNameAndFormat { DisplayName = "Last Login Date"}},
                               {"LastFailedLogin", new DisplayNameAndFormat { DisplayName = "Last Failed Login"}},
                               {"CounterLock", new DisplayNameAndFormat { DisplayName = "Counter Lock"}},
                               {"Active", new DisplayNameAndFormat { DisplayName = "Active"}},
                               {"Enable", new DisplayNameAndFormat { DisplayName = "Enable"}},
                    }
                }
            },
            {
                nameof(ListOfRoleController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                               {"RoleName", new DisplayNameAndFormat { DisplayName = "Role Name"}},
                               {"Description", new DisplayNameAndFormat { DisplayName = "Description"}},
                               {"DisplayName", new DisplayNameAndFormat { DisplayName = "Display Name"}},
                               {"RoleType", new DisplayNameAndFormat { DisplayName = "Role Type"}},
                               {"CreatedDate", new DisplayNameAndFormat { DisplayName = "Created Date"}},
                               {"CreatedBy", new DisplayNameAndFormat { DisplayName = "Created By"}},
                               {"LastUpdatedBy", new DisplayNameAndFormat { DisplayName = "Last Updated By"}},
                               {"LastUpdatedDate", new DisplayNameAndFormat { DisplayName = "Last Updated Date"}},

                    }
                }
            },
              {
                nameof(CasesDetailsController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>
                    {
                               "BranchNumber"
                    },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                    {"CaseId",new DisplayNameAndFormat { DisplayName ="Case ID"}},
                    {"EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                    {"EntityNumber",new DisplayNameAndFormat { DisplayName ="Entity Number"}},
                    {"CaseStatus",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                    {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                    {"CasePriority",new DisplayNameAndFormat { DisplayName ="Case Priority"}},
                    {"CaseCategory",new DisplayNameAndFormat { DisplayName ="Case Category"}},
                    {"CaseSubCategory",new DisplayNameAndFormat { DisplayName ="Case Sub-Category"}},
                    {"EntityLevel",new DisplayNameAndFormat { DisplayName ="Entity Level"}},
                    {"CreatedBy",new DisplayNameAndFormat { DisplayName ="Created By"}},
                    {"Owner",new DisplayNameAndFormat { DisplayName ="Owner"}},
                    {"CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                    {"ClosedDate",new DisplayNameAndFormat { DisplayName ="Closed Date"}}
                    }
                }
            },
               {
                nameof(CustomersController).ToLower(),new ReportConfig
                {
                    SkipList = new List<string>
                    {
                     "CustomerTaxId",
                     "DoingBusinessAsName",
                     "GovernorateName",
                     "CustomerStatus",
                     "StreetPostalCode",
                     "StreetCountryCode",
                     "StreetCountryName",
                     "MailingAddress1",
                     "MailingCityName",
                     "MailingPostalCode",
                     "MailingCountryName",
                     "IsEmployee",
                     "EmployeeNumber",
                     "EmployerName",
                     "EmployerPhoneNumber",
                     "EmailAddress",
                     "PhoneNumber1",
                     "PhoneNumber2",
                     "PhoneNumber3",
                     "AnnualIncomeAmount",
                     "NetWorthAmount",
                     "LastRiskAssessmentDate",
                     "ActiveFlg",
                    },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                    {
                                  {"CustomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                                  {"CustomerNumber",new DisplayNameAndFormat { DisplayName ="Customer Number"}},
                                  {"CustomerSinceDate",new DisplayNameAndFormat { DisplayName ="Customer Since Date"}},
                                  {"CustomerType",new DisplayNameAndFormat { DisplayName ="Customer Type"}},
                                  {"NonProfitOrgInd",new DisplayNameAndFormat { DisplayName ="Non Profit Org Ind"}},
                                  {"PoliticallyExposedPersonInd",new DisplayNameAndFormat { DisplayName ="PEP"}},
                                  {"CharityDonationsInd",new DisplayNameAndFormat { DisplayName ="Charity Donations Ind"}},
                                  {"RiskClassification",new DisplayNameAndFormat { DisplayName ="Risk Classification"}},
                                  {"ResidenceCountryName",new DisplayNameAndFormat { DisplayName ="Residence Country"}},
                                  {"CitizenshipCountryName",new DisplayNameAndFormat { DisplayName ="Citizenship Country"}},
                                  {"StreetAddress1",new DisplayNameAndFormat { DisplayName ="Street Address"}},
                                  {"CityName",new DisplayNameAndFormat { DisplayName ="City Name"}},
                                  {"CustomerDateOfBirth",new DisplayNameAndFormat { DisplayName ="Customer Date Of Birth"}},
                                  {"OccupationDesc",new DisplayNameAndFormat { DisplayName ="Occupation Description"}},
                                  {"MaritalStatusDesc",new DisplayNameAndFormat { DisplayName ="Marital Status"}},
                                  {"IndustryDesc",new DisplayNameAndFormat { DisplayName ="Industry Description"}},
                                  {"BranchNumber",new DisplayNameAndFormat { DisplayName ="Branch Number"}},
                                  {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                                  {"CustomerIdentificationId",new DisplayNameAndFormat { DisplayName ="Customer Identification ID"}},
                                  {"CustomerIdentificationType",new DisplayNameAndFormat { DisplayName ="Customer Identification Type"}}
                    }
                }
            },

               {
                nameof(HighRiskController).ToLower(),new ReportConfig{
                    SkipList = new List<string>(),
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                                {"PartyName",new DisplayNameAndFormat { DisplayName ="Party Name"}},
                                {"PartyNumber",new DisplayNameAndFormat { DisplayName ="Party Number"}},
                                {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                                {"BranchNumber",new DisplayNameAndFormat { DisplayName ="Branch Number"}},
                                {"PartyDateOfBirth",new DisplayNameAndFormat { DisplayName ="Party Date Of Birth", Format =  "{0:MMM/dd/yyyy}"}},
                                {"PartyIdentificationId",new DisplayNameAndFormat { DisplayName ="Party Identification ID"}},
                                {"PhoneNumber1",new DisplayNameAndFormat { DisplayName ="Phone Number"}},
                                {"PartyTaxId",new DisplayNameAndFormat { DisplayName ="Party Tax ID"}},
                                {"MailingAddress1",new DisplayNameAndFormat { DisplayName ="Mailing Address"}},
                                {"StreetAddress1",new DisplayNameAndFormat { DisplayName ="Street Address"}},
                                {"StreetCityName",new DisplayNameAndFormat { DisplayName ="Street City Name"}},
                                {"ResidenceCountryName",new DisplayNameAndFormat { DisplayName ="Residence Country"}},
                                {"CitizenshipCountryName",new DisplayNameAndFormat { DisplayName ="Citizenship Country"}},
                                {"PartyIdentificationTypeDesc",new DisplayNameAndFormat { DisplayName ="Party Identification Type"}},
                                {"PoliticallyExposedPersonInd",new DisplayNameAndFormat { DisplayName ="PEP"}},
                                {"PartyTypeDesc",new DisplayNameAndFormat { DisplayName ="Party Type"}},
                                {"RiskClassification",new DisplayNameAndFormat { DisplayName ="Risk Classification"}},
                                {"MailingCityName",new DisplayNameAndFormat { DisplayName ="Mailing City Name"}}
                    }
                  }
            },
               {
                nameof(RiskAssessmentController).ToLower(),new ReportConfig{
                    SkipList = new List<string>{
                        "RiskAssessmentDuration",
                        "VersionNumber",
                        "AssessmentCategoryCd",
                        "AssessmentSubcategoryCd",
                    },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {"CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                        {"PartyNumber",new DisplayNameAndFormat { DisplayName ="Party Number"}},
                        {"PartyName",new DisplayNameAndFormat { DisplayName ="Party Name"}},
                        {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {"AssessmentTypeCd",new DisplayNameAndFormat { DisplayName ="Assessment Type"}},
                        {"RiskAssessmentId",new DisplayNameAndFormat { DisplayName ="Risk Assessment ID"}},
                        {"OwnerUserLongId",new DisplayNameAndFormat { DisplayName ="Owner"}},
                        {"CreateUserId",new DisplayNameAndFormat { DisplayName ="Create By"}},
                        {"RiskStatus",new DisplayNameAndFormat { DisplayName ="Risk Status"}},
                        {"RiskClass",new DisplayNameAndFormat { DisplayName ="Risk Classification"}},
                        {"ProposedRiskClass",new DisplayNameAndFormat { DisplayName ="Proposed Risk Classification"}}
                    }
                }
            },
                {
                nameof(TriageController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                                "AlertedEntityLevel"
                                //"Outstamt",
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "AlertedEntityName",new DisplayNameAndFormat { DisplayName ="Alerted Entity Name"}},
                        {  "AlertedEntityNumber",new DisplayNameAndFormat { DisplayName ="Alerted Entity Number"}},
                        {  "BranchNumber",new DisplayNameAndFormat { DisplayName ="Branch Number"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {  "RiskScore",new DisplayNameAndFormat { DisplayName ="Risk Score"}},
                        {  "OwnerUserid",new DisplayNameAndFormat { DisplayName ="Owner"}},
                        {  "AggregateAmt",new DisplayNameAndFormat { DisplayName ="Aggregate Amount"}},
                        {  "AgeOldestAlert",new DisplayNameAndFormat { DisplayName ="Alert Age"}},
                        {  "AlertsCntSum",new DisplayNameAndFormat { DisplayName ="Alerts Count"}},

                    }
                }
            },
            {
                nameof(DGAMLArtExternalCustomerDetailsController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                        "CustomerTaxId",
                        "GovernorateName",
                        "StreetPostalCode",
                        "StreetCountryCode",
                        "StreetCountryName",
                        "PhoneNumber1",
                        "PhoneNumber2"
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "CustomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                        {  "CustomerNumber",new DisplayNameAndFormat { DisplayName ="Customer Number"}},
                        {  "CustomerType",new DisplayNameAndFormat { DisplayName ="Customer Type"}},
                        {  "CustomerIdentificationId",new DisplayNameAndFormat { DisplayName ="Customer Identification ID"}},
                        {  "CustomerIdentificationType",new DisplayNameAndFormat { DisplayName ="Customer Identification Type"}},
                        {  "CustomerDateOfBirth",new DisplayNameAndFormat { DisplayName ="Customer Date Of Birth"}},
                        {  "StreetAddress1",new DisplayNameAndFormat { DisplayName ="Street Address"}},
                        {  "CityName",new DisplayNameAndFormat { DisplayName ="City Name"}},
                        {  "ResidenceCountryName",new DisplayNameAndFormat { DisplayName = "Residence Country"}},
                        {  "CitizenshipCountryName",new DisplayNameAndFormat { DisplayName ="Citizenship Country"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},

                    }
                }
            },
            {
                nameof(DGAMLArtScenarioAdminController).ToLower(),new ReportConfig{
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "ScenarioName",new DisplayNameAndFormat { DisplayName ="Name"}},
                        {  "ScenarioShortDesc",new DisplayNameAndFormat { DisplayName ="Short Description"}},
                        {  "ScenarioDesc",new DisplayNameAndFormat { DisplayName ="Scenario Description"}},
                        {  "ScenarioStatus",new DisplayNameAndFormat { DisplayName ="Scenario Status"}},
                        {  "ScenarioCategory",new DisplayNameAndFormat { DisplayName ="Scenario Category"}},
                        {  "ProductType",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                        {  "RiskFact",new DisplayNameAndFormat { DisplayName ="Risk Fact"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                        {  "EndDate",new DisplayNameAndFormat { DisplayName ="End Date"}},
                        {  "CreateUserId",new DisplayNameAndFormat { DisplayName ="Create User ID"}},
                        {  "ScenarioType",new DisplayNameAndFormat { DisplayName = "Scenario Type"}},
                        {  "ScenarioFrequency",new DisplayNameAndFormat { DisplayName ="Scenario Frequency"}},
                        {  "ScenarioMessage",new DisplayNameAndFormat { DisplayName ="Scenario Message"}},
                        {  "ObjectLevel",new DisplayNameAndFormat { DisplayName ="Object Level"}},
                        {  "AlarmType",new DisplayNameAndFormat { DisplayName ="Alarm Type"}},
                        {  "AlarmCategory",new DisplayNameAndFormat { DisplayName ="Alarm Category"}},
                        {  "AlarmSubcategory",new DisplayNameAndFormat { DisplayName ="Alarm Subcategory"}},
                        {  "DependedData",new DisplayNameAndFormat { DisplayName ="Depended Data"}},
                        {  "ParmName",new DisplayNameAndFormat { DisplayName ="Parameter Name"}},
                        {  "ParmValue",new DisplayNameAndFormat { DisplayName ="Parameter Value"}},
                        {  "ParmDesc",new DisplayNameAndFormat { DisplayName ="Parameter Desc"}},
                        {  "ParmTypeDesc",new DisplayNameAndFormat { DisplayName ="Parameter Type Desc"}},
                        {  "ParamCondition",new DisplayNameAndFormat { DisplayName ="Parameter Condition"}},
                        {  "ScorParmName",new DisplayNameAndFormat { DisplayName ="Score Parameter Name"}},
                        {  "ScorDependAttribute",new DisplayNameAndFormat { DisplayName ="Score Depend Attribute"}},

                    }
                }
            },
            {
                nameof(DGAMLArtScenarioHistoryController).ToLower(),new ReportConfig{
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "RoutineName",new DisplayNameAndFormat { DisplayName ="Scenario Name"}},
                        {  "RoutineShortDesc",new DisplayNameAndFormat { DisplayName ="Scenario Short Description"}},
                        {  "EventDesc",new DisplayNameAndFormat { DisplayName ="Event Description"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                        {  "CreateUserId",new DisplayNameAndFormat { DisplayName ="Create User Id"}},
                    }
                }
            },
            {
                nameof(DGAMLArtSuspectDetailsController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                        "CustIdentExpDate",
                        "CustIdentIssDate",
                        "EmprName",
                        "TelNo1"
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "SuspectNumber",new DisplayNameAndFormat { DisplayName ="Suspect Number"}},
                        {  "SuspectName",new DisplayNameAndFormat { DisplayName ="Suspect Name"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {  "ProfileRisk",new DisplayNameAndFormat { DisplayName ="Profile Risk"}},
                        {  "NumberOfAlarms",new DisplayNameAndFormat { DisplayName ="Number Of Alerts"}},
                        {  "AgeOfOldestAlert",new DisplayNameAndFormat { DisplayName ="Age Of Oldest Alert"}},
                        {  "OwnerUserId",new DisplayNameAndFormat { DisplayName ="Owner User Id"}},
                        {  "CustBirthDate",new DisplayNameAndFormat { DisplayName ="Customer Birth Of Date"}},
                        {  "PoliticalExpPrsnInd",new DisplayNameAndFormat { DisplayName ="PEP"}},
                        {  "RiskClassification",new DisplayNameAndFormat { DisplayName ="Risk Classification"}},
                        {  "CitizenCntryName",new DisplayNameAndFormat { DisplayName ="Citizenship Country"}},
                        {  "CustIdentId",new DisplayNameAndFormat { DisplayName ="Customer Identification ID"}},
                        {  "CustIdentTypeDesc",new DisplayNameAndFormat { DisplayName ="Customer Identification Type"}},
                        {  "OccupDesc",new DisplayNameAndFormat { DisplayName ="Occupation Description"}},
                        {  "CustSinceDate",new DisplayNameAndFormat { DisplayName ="Customer Since Date"}},
                    }
                }
            },
            {
                nameof(DGAMLTriageController).ToLower(),new ReportConfig{
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "AlertedEntityName",new DisplayNameAndFormat { DisplayName ="Alerted Entity Name"}},
                        {  "AlertedEntityNumber",new DisplayNameAndFormat { DisplayName ="Alerted Entity Number"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {  "RiskScore",new DisplayNameAndFormat { DisplayName ="Risk Score"}},
                        {  "QueueCode",new DisplayNameAndFormat { DisplayName ="Queue Code"}},
                        {  "OwnerUserid",new DisplayNameAndFormat { DisplayName ="Owner User ID"}},
                        {  "AlertedEntityLevel",new DisplayNameAndFormat { DisplayName ="Alerted Entity Level"}},
                        {  "AggregateAmt",new DisplayNameAndFormat { DisplayName ="Aggregate Amount"}},
                        {  "AgeOldestAlert",new DisplayNameAndFormat { DisplayName ="Age Oldest Alert"}},
                        {  "AlertsCntSum",new DisplayNameAndFormat { DisplayName ="Alerts Count Sum"}},
                    }
                }
            },
            {
                nameof(DGAMLAlertDetailsController).ToLower(),new ReportConfig{
                    SkipList=new List<string>()
                    {
                        "ActualValuesText"
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "AlarmId",new DisplayNameAndFormat { DisplayName ="Alert ID"}},
                        {  "AlertedEntityNumber",new DisplayNameAndFormat { DisplayName ="Alerted Entity Number"}},
                        {  "AlertedEntityName",new DisplayNameAndFormat { DisplayName ="Alerted Entity Name"}},
                        {  "AlertDescription",new DisplayNameAndFormat { DisplayName ="Alert Description"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {  "ScenarioId",new DisplayNameAndFormat { DisplayName ="Scenario ID"}},
                        {  "ScenarioName",new DisplayNameAndFormat { DisplayName ="Scenario Name"}},
                        {  "MoneyLaunderingRiskScore",new DisplayNameAndFormat { DisplayName ="Money Laundering Risk Score"}},
                        {  "AlertCategory",new DisplayNameAndFormat { DisplayName ="Alert Category"}},
                        {  "AlertSubcategory",new DisplayNameAndFormat { DisplayName ="Alert Sub Category"}},
                        {  "AlertStatus",new DisplayNameAndFormat { DisplayName ="Alert Status"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                        {  "RunDate",new DisplayNameAndFormat { DisplayName ="Run Date"}},
                        {  "PoliticallyExposedPersonInd",new DisplayNameAndFormat { DisplayName ="PEP"}},
                        {  "EmpInd",new DisplayNameAndFormat { DisplayName ="Emp Indication"}},
                        {  "ClosedUserId",new DisplayNameAndFormat { DisplayName ="Closed User ID"}},
                        {  "CloseUserName",new DisplayNameAndFormat { DisplayName ="Close User Name"}},
                        {  "CloseDate",new DisplayNameAndFormat { DisplayName ="Close Date"}},
                        {  "CloseReason",new DisplayNameAndFormat { DisplayName ="Close Reason"}},
                        {  "InvestigationDays",new DisplayNameAndFormat { DisplayName ="Investigation Days"}},
                    }
                }
            },
            {
                nameof(DGAMLCasesDetailsController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                        "CaseStatusCode",
                        "CaseCategoryCode",
                        "CaseSubCategoryCode"
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "CaseId",new DisplayNameAndFormat { DisplayName ="Case ID"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "EntityNumber",new DisplayNameAndFormat { DisplayName ="Entity Number"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                        {  "CasePriority",new DisplayNameAndFormat { DisplayName ="Case Priority"}},
                        {  "CaseStatus",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                        {  "CaseCategory",new DisplayNameAndFormat { DisplayName ="Case Category"}},
                        {  "EntityLevel",new DisplayNameAndFormat { DisplayName ="Entity Level"}},
                        {  "CreatedBy",new DisplayNameAndFormat { DisplayName ="Created By"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                    }
                }
            },
            {
                nameof(DGAMLCustomersDetailsController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                        "CustomerTaxId",
                        "GovernorateName",
                        "DoingBusinessAsName",
                        "CustomerStatus",
                        "StreetPostalCode",
                        "StreetCountryCode",
                        "StreetCountryName",
                        "MailingAddress1",
                        "MailingCityName",
                        "MailingPostalCode",
                        "MailingCountryName",
                        "IsEmployee",
                        "EmployeeNumber",
                        "EmployerName",
                        "EmployerPhoneNumber",
                        "EmailAddress",
                        "PhoneNumber1",
                        "PhoneNumber2",
                        "PhoneNumber3",
                        "AnnualIncomeAmount",
                        "NetWorthAmount",
                        "LastRiskAssessmentDate"
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "CustomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                        {  "CustomerNumber",new DisplayNameAndFormat { DisplayName ="Customer Number"}},
                        {  "CustomerType",new DisplayNameAndFormat { DisplayName ="Customer Type"}},
                        {  "CustomerIdentificationId",new DisplayNameAndFormat { DisplayName ="Customer Identification ID"}},
                        {  "CustomerIdentificationType",new DisplayNameAndFormat { DisplayName ="Customer Identification Type"}},
                        {  "CustomerDateOfBirth",new DisplayNameAndFormat { DisplayName ="Customer Date Of Birth"}},
                        {  "RiskClassification",new DisplayNameAndFormat { DisplayName ="Risk Classification"}},
                        {  "StreetAddress1",new DisplayNameAndFormat { DisplayName ="Street Address"}},
                        {  "CityName",new DisplayNameAndFormat { DisplayName ="City Name"}},
                        {  "ResidenceCountryName",new DisplayNameAndFormat { DisplayName = "Residence Country"}},
                        {  "CitizenshipCountryName",new DisplayNameAndFormat { DisplayName ="Citizenship Country"}},
                        {  "OccupationDesc",new DisplayNameAndFormat { DisplayName ="Occupation Description"}},
                        {  "IndustryDesc",new DisplayNameAndFormat { DisplayName ="Industry Description"}},
                        {  "MaritalStatusDesc",new DisplayNameAndFormat { DisplayName ="Marital Status"}},
                        {  "CustomerSinceDate",new DisplayNameAndFormat { DisplayName ="Customer Since Date"}},
                        {  "NonProfitOrgInd",new DisplayNameAndFormat { DisplayName ="Non Profit Org IND"}},
                        {  "PoliticallyExposedPersonInd",new DisplayNameAndFormat { DisplayName ="PEP"}},
                        {  "BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},

                    }
                }
            },



                        {
                 nameof(ACPostingsAccountController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                    //Customer/System Parameter/Charge Code
                {"EventRef",            new DisplayNameAndFormat { DisplayName = "Event Reference"}},
                {"MasterRef",           new DisplayNameAndFormat { DisplayName = "Master Reference"}},
                {"AcctNo",              new DisplayNameAndFormat { DisplayName = "Account Number"}},
                {"AccountType",         new DisplayNameAndFormat { DisplayName = "Account Type"}},
                {"Shortname",           new DisplayNameAndFormat { DisplayName = "Short Name"}},
                {"DrCrFlg",             new DisplayNameAndFormat { DisplayName = "Dr/Cr"}},
                {"PostAmount",          new DisplayNameAndFormat { DisplayName = "Amount",Format = "{0:n2}"}},
                {"Ccy",                 new DisplayNameAndFormat { DisplayName = "Currency"}},
                {"PostAmountEgp",       new DisplayNameAndFormat { DisplayName = "Amount Egp",Format = "{0:n2}"}},
                {"Valuedate",           new DisplayNameAndFormat { DisplayName = "Value Date" , Format="{0:dd/MM/yyyy}"}},
                {"CusMnm",              new DisplayNameAndFormat { DisplayName = "CusMnm"}},
                {"Spsk",                new DisplayNameAndFormat { DisplayName = "Customer/System Parameter/Charge Code"}},
                {"Mainbanking",         new DisplayNameAndFormat { DisplayName = "Main Banking Entity"}},
                {"BranchName",          new DisplayNameAndFormat { DisplayName = "Branch Name"}},
            },
                SkipList = new List<string>{}
            }
            },
            { nameof(ACPostingsCustomersController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"EventRef",            new DisplayNameAndFormat { DisplayName = "Event Reference"}},
                {"MasterRef",           new DisplayNameAndFormat { DisplayName = "Master Reference"}},
                {"AcctNo",              new DisplayNameAndFormat { DisplayName = "Account Number"}},
                {"AccountType",         new DisplayNameAndFormat { DisplayName = "Account Type"}},
                {"Shortname",           new DisplayNameAndFormat { DisplayName = "Short Name"}},
                {"DrCrFlg",             new DisplayNameAndFormat { DisplayName = "Dr/Cr"}},
                {"PostAmount",          new DisplayNameAndFormat { DisplayName = "Amount",Format = "{0:n2}"}},
                {"Ccy",                 new DisplayNameAndFormat { DisplayName = "Currency"}},
                {"PostAmountEgp",       new DisplayNameAndFormat { DisplayName = "Amount Egp",Format = "{0:n2}"}},
                {"Valuedate",           new DisplayNameAndFormat { DisplayName = "Value Date" , Format = "{0:dd/MM/yyyy}"}},
                {"CusMnm",              new DisplayNameAndFormat { DisplayName = "CusMnm"}},
                {"Spsk",                new DisplayNameAndFormat { DisplayName = "Customer/System Parameter/Charge Code"}},
                {"Mainbanking",         new DisplayNameAndFormat { DisplayName = "Main Banking Entity"}},
                {"BranchName",          new DisplayNameAndFormat { DisplayName = "Branch Name"}},
            },
                SkipList = new List<string>
            {

            }
    }
            },
            { nameof(ActivityController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                {"Team",new DisplayNameAndFormat { DisplayName ="Team"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"Sovalue",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"EventRef",new DisplayNameAndFormat { DisplayName ="Event Reference"}},
                {"EventStatus",new DisplayNameAndFormat { DisplayName ="Event Status"}},
                {"StartDate",new DisplayNameAndFormat { DisplayName ="Event Start Date" ,Format = "{0:dd/MM/yyyy}"}},
                {"StartTime",new DisplayNameAndFormat { DisplayName ="Event Start Time"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
                {"Address12",new DisplayNameAndFormat { DisplayName ="Non principal Party"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Event Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Amount Egp",Format = "{0:n2}"}},
                {"Lstmoduser",new DisplayNameAndFormat { DisplayName ="User ID"}},
                {"Shortname",new DisplayNameAndFormat { DisplayName ="Event"}},


                {"Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Touched",new DisplayNameAndFormat { DisplayName ="Touched"}},
                {"Relmstrref",new DisplayNameAndFormat { DisplayName ="Relmstrref"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"Gfcun12",new DisplayNameAndFormat { DisplayName ="Gfcun12"}},
                {"CusMnm12",new DisplayNameAndFormat { DisplayName ="CusMnm12"}},
                {"SwBank12",new DisplayNameAndFormat { DisplayName ="SwBank12"}},
                {"SwCtr12",new DisplayNameAndFormat { DisplayName ="SwCtr12"}},
                {"SwLoc12",new DisplayNameAndFormat { DisplayName ="SwLoc12"}},
                {"SwBranch12",new DisplayNameAndFormat { DisplayName ="SwBranch12"}},
                {"CcyCed",new DisplayNameAndFormat { DisplayName ="CcyCed"}},
                {"Relmstrref12",new DisplayNameAndFormat { DisplayName ="Relmstrref12"}},
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"Started",new DisplayNameAndFormat { DisplayName ="Started"}},
                {"StartedFilter",new DisplayNameAndFormat { DisplayName ="StartedFilter"}},
                {"Language",new DisplayNameAndFormat { DisplayName ="Language"}},
                {"BaseStatus",new DisplayNameAndFormat { DisplayName ="BaseStatus"}},
                {"Stepdescr",new DisplayNameAndFormat { DisplayName ="Stepdescr"}},
            },
                SkipList = new List<string>
            {
                "Product",
                "Touched",
                "Relmstrref",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "CusMnm",
                "Gfcun",
                "Gfcun12",
                "CusMnm12",
                "SwBank12",
                "SwCtr12",
                "SwLoc12",
                "SwBranch12",
                "CcyCed",
                "Relmstrref12",
                "BhalfBrn",
                "Started",
                "StartedFilter",
                "Language",
                "Stepdescr",
                "BaseStatus",
            }
            }
            },
            { nameof(AmortizationController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>(),
                SkipList = new List<string>()
            }
            },
            { nameof(OurChargesByCustomerController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Hvbad1",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Charge Party" }},
                {"Longname",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"TotoalPeriodicBilledChgDue",new DisplayNameAndFormat { DisplayName ="Periodic/Billed"}},
                {"TotoalBilledChgDue",new DisplayNameAndFormat { DisplayName ="Billed"}},
                {"TotoalPaidChgDue",new DisplayNameAndFormat { DisplayName ="Paid",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
                {"TotoalClaimedChgDue",new DisplayNameAndFormat { DisplayName ="Claimed",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
                {"TotoalOutstandingChgDue",new DisplayNameAndFormat { DisplayName ="Outstanding",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
                {"TotoalWaivedChgDue",new DisplayNameAndFormat { DisplayName ="Waived",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
             },
                SkipList = new List<string>
            {

            }
    }
            },
            { nameof(OurChargesByMasterController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
               {"Hvbad1",new DisplayNameAndFormat { DisplayName ="Branch"}},
               {"Longname",new DisplayNameAndFormat { DisplayName ="Product"}},
               {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
               {"TotoalPeriodicBilledChgDue",new DisplayNameAndFormat { DisplayName ="Periodic/Billed"}},
               {"TotoalBilledChgDue",new DisplayNameAndFormat { DisplayName ="Billed"}},
               {"TotoalPaidChgDue",new DisplayNameAndFormat { DisplayName ="Paid",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
               {"TotoalClaimedChgDue",new DisplayNameAndFormat { DisplayName ="Claimed",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
               {"TotoalOutstandingChgDue",new DisplayNameAndFormat { DisplayName ="Outstanding",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
               {"TotoalWaivedChgDue",new DisplayNameAndFormat { DisplayName ="Waived",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
            },
                SkipList = new List<string>
            {

            }
    }
            },
            { nameof(OurChargesDetailsController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Hvbad1",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Longname",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Customer"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},
                {"Descr",new DisplayNameAndFormat { DisplayName ="Type"}},
                {"ParticChg",new DisplayNameAndFormat { DisplayName ="Share with Principal"}},
                {"EventRef",new DisplayNameAndFormat { DisplayName ="Event Reference"}},
                {"Action",new DisplayNameAndFormat { DisplayName ="Action"}},
                {"CgbasAmt",new DisplayNameAndFormat { DisplayName ="Basis Amount",Format = "{0:n2}"}},
                {"ChgbasCcy",new DisplayNameAndFormat { DisplayName ="Basis Amount Currency"}},
                {"ChgbasAmtEgp",new DisplayNameAndFormat { DisplayName ="Basis Amount EGP",Format = "{0:n2}"}},
                {"SchAmt",new DisplayNameAndFormat { DisplayName ="Charge Amount",Format = "{0:n2}"}},
                {"SchCcy",new DisplayNameAndFormat { DisplayName ="Charge Amount Currency"}},
                {"SchAmtEgp",new DisplayNameAndFormat { DisplayName ="Charge Amount EGP",Format = "{0:n2}"}},
                {"SchRate",new DisplayNameAndFormat { DisplayName ="Rate"}},
                {"ChgDue",new DisplayNameAndFormat { DisplayName ="Amount to Collect",Format = "{0:n2}"}},
                {"ChgCcy",new DisplayNameAndFormat { DisplayName ="Amount to Collect Currency"}},
                {"ChgDueEgp",new DisplayNameAndFormat { DisplayName ="Amount to Collect EGP",Format = "{0:n2}"}},

                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"Reduction",new DisplayNameAndFormat { DisplayName ="Reduction"}},
                {"TaxAmt",new DisplayNameAndFormat { DisplayName ="TaxAmt"}},
                {"TaxCcy",new DisplayNameAndFormat { DisplayName ="TaxCcy"}},
                {"TaxFor",new DisplayNameAndFormat { DisplayName ="TaxFor"}},
                {"RefnoPfix1",new DisplayNameAndFormat { DisplayName ="RefnoPfix1"}},
                {"RefnoSerl1",new DisplayNameAndFormat { DisplayName ="RefnoSerl1"}},
                {"StartDate",new DisplayNameAndFormat { DisplayName ="StartDate"}},
                {"StartTime",new DisplayNameAndFormat { DisplayName ="StartTime"}},
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"SchCcySpt",new DisplayNameAndFormat { DisplayName ="SchCcySpt"}},
                {"SchCcySei",new DisplayNameAndFormat { DisplayName ="SchCcySei"}},
            },
                SkipList = new List<string>
            {
                    "Gfcun",
                "CusMnm",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "Reduction",
                "TaxAmt",
                "TaxCcy",
                "TaxFor",
                "RefnoPfix1",
                "RefnoSerl1",
                "StartDate",
                "StartTime",
                "BhalfBrn",
                "SchCcySpt",
                "SchCcySei",
            }
    }
            },
            { nameof(DiaryExceptionsController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"Sovaluedesc",new DisplayNameAndFormat { DisplayName ="Product Name"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Principal"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},
                {"BranchCode",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Full Name"}},
                {"Team",new DisplayNameAndFormat { DisplayName ="Team"}},
                {"CtrctDate",new DisplayNameAndFormat { DisplayName ="Ctrct Date"}},
                {"Outstamt",new DisplayNameAndFormat { DisplayName ="Outstamt"}},
                {"Outccyced",new DisplayNameAndFormat { DisplayName ="Outccyced"}},
                {"Outstccy",new DisplayNameAndFormat { DisplayName ="Outstccy"}},
                {"OutstamtEgp",new DisplayNameAndFormat { DisplayName ="OutstamtEgp"}},
                {"Relmstrref",new DisplayNameAndFormat { DisplayName ="Relmstrref"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Amount Egp",Format = "{0:n2}"}},
                {"CreatedAt",new DisplayNameAndFormat { DisplayName ="CreatedAt"}},
                {"NoteText",new DisplayNameAndFormat { DisplayName ="Reason"}},
                {"RefnoPfix",new DisplayNameAndFormat { DisplayName ="RefnoPfix"}},
                {"RefnoSerl",new DisplayNameAndFormat { DisplayName ="RefnoSerl"}},
                {"ExpiryDat",new DisplayNameAndFormat { DisplayName ="Expiry Date"}},
                {"CcyCed",new DisplayNameAndFormat { DisplayName ="CcyCed"}},

                {"Sovaluecode",new DisplayNameAndFormat { DisplayName ="Sovaluecode"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"Active",new DisplayNameAndFormat { DisplayName ="Active"}},
            },
                SkipList = new List<string>
            {
                    "Product",
                "Sovaluecode",
                "Gfcun",
                "CusMnm",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "Active",
                "CtrctDate",
                "Outstamt",
                "Outccyced",
                "Outstccy",
                "OutstamtEgp",
                "Relmstrref",
                "CcyCed",
                "CreatedAt",
                "RefnoPfix",
                "RefnoSerl",
            }
    }
            },
            { nameof(EcmTransactionsController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>{

                {"CaseId",new DisplayNameAndFormat { DisplayName ="EcmReference"}},
                {"Behalfofbranch",new DisplayNameAndFormat { DisplayName ="Branch ID"}},
                {"CreateDate",new DisplayNameAndFormat { DisplayName ="Case Creation Date"}},
                {"Applicantname",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                {"Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Producttype",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                {"Eventname",new DisplayNameAndFormat { DisplayName ="Event"}},
                {"TransactionAmount",new DisplayNameAndFormat { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"TransactionCurrency",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                {"PrimaryOwner",new DisplayNameAndFormat { DisplayName ="Primary Owner"}},
                {"CaseStatCd",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                {"UpdateUserId",new DisplayNameAndFormat { DisplayName ="Last Action taken by"}}
            }
            ,
                SkipList = new List<string>
            {

            }
            }
            },
            { nameof(InterfaceDetailsController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"CorrelationId",new DisplayNameAndFormat { DisplayName ="Correlation ID"}},
                {"DrSeq",new DisplayNameAndFormat { DisplayName ="Dr Seq"}},
                {"CrSeq",new DisplayNameAndFormat { DisplayName ="Cr Seq"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},
                {"Error",new DisplayNameAndFormat { DisplayName ="Error"}},
                {"Xref",new DisplayNameAndFormat { DisplayName ="X Reference"}},
                {"MstRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"EvtRef",new DisplayNameAndFormat { DisplayName ="Event Reference"}},
                {"ValueDate",new DisplayNameAndFormat { DisplayName ="Value Date"        ,Format = "{0:dd/MM/yyyy}"       }},
                {"FromType",new DisplayNameAndFormat { DisplayName ="From Type"}},
                {"ToType",new DisplayNameAndFormat { DisplayName ="To Type"}},
                {"FromCcy",new DisplayNameAndFormat { DisplayName ="From Ccy"}},
                {"ToCcy",new DisplayNameAndFormat { DisplayName ="To Ccy"}},
                {"FromAmount",new DisplayNameAndFormat { DisplayName ="From Amount",Format = "{0:n2}"}},
                {"ToAmount",new DisplayNameAndFormat { DisplayName ="To Amount",Format = "{0:n2}"}},
                {"FromAccount",new DisplayNameAndFormat { DisplayName ="From Account"}},
                {"ToAccount",new DisplayNameAndFormat { DisplayName ="To Account"}},
                {"FromBranch",new DisplayNameAndFormat { DisplayName ="From Branch"}},
                {"ToBranch",new DisplayNameAndFormat { DisplayName ="To Branch"}},
            },
                SkipList = new List<string>
            {
                //    "Gzh97nacc",
                //"Gzh97nboacc",
                //"Trfile",
                //"Gzh97nca2",
                //"Gzh97nean1",
                //"Gzh97nactc",
                //"Gzcus1",
                //"Gzh97nctp1",
                //"Gzg461tprd",
                //"Gzg461pccy",
                //"Gzg461ext",
                //"Gzg461tsld",
                //"Gzg331purd",
                //"Gzg331pccy",
                //"Gzg331ext",
                //"Gzg331sled",
                //"Gzg331psd1",
                //"Gzh97nrecn",
                //"Gzg461psd1",
                //"Gz361mdt",
                //"Tretxt",
                //"Gz361rat",
                //"Gz361sdt",
                //"Gzh97nnr1",
                //"Gzh97nnr2",
                //"Gzh97nnr3",
                //"Gzh97nnr4",
                //"Gz361ncd",
                //"Gzg891dte",
                //"Gzg891acc",
                //"Gzg891ccy",
                //"Trtype",
                //"Gzg331sccy",
                //"Gzg461sccy",
                //"Gzg461tsam",
                //"Gzg461sced",
                //"Gzg331sam",
                //"Gzg331sced",
                //"Trseq",
                //"Trstat",
                //"Gzh97nuc1",
                //"Gzh97nuc2",
                //"Gzh97nsrc",
                //"Gzh97npc",
                //"Gz361d1f",
                //"Gzg361ced",
                //"Gzg331pam",
                //"Gzg331pced",
                //"Gzg891ced",
                //"Gzh97nced",
                //"Gzg461tpam",
                //"Gzg461pced",
                //"Gzh97nnegp",
            }
            }
            },
            { nameof(MasterEventHistoryController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                   {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"Shortname",new DisplayNameAndFormat { DisplayName ="Event"}},
                {"EventRef",new DisplayNameAndFormat { DisplayName ="Event Reference"}},
                {"Stepdescr",new DisplayNameAndFormat { DisplayName ="Event Steps"}},
                {"StartedFilter",new DisplayNameAndFormat { DisplayName ="Event Start Date"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Master Status"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Principal Name"}},
                {"StatusEv",new DisplayNameAndFormat { DisplayName ="Action"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Amount Egp" ,Format = "{0:n2}"}},
                {"Bookoffdat",new DisplayNameAndFormat { DisplayName ="Book Off Date"}},
                {"ExpiryDat",new DisplayNameAndFormat { DisplayName ="Expiry Date"}},
                {"DeactDate",new DisplayNameAndFormat { DisplayName ="Deactivation Date"}},

                {"Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Outstamt",new DisplayNameAndFormat { DisplayName ="Outstamt"}},
                {"Outstccy",new DisplayNameAndFormat { DisplayName ="Outstccy"}},
                {"OutstamtEgp",new DisplayNameAndFormat { DisplayName ="OutstamtEgp"}},
                {"Started",new DisplayNameAndFormat { DisplayName ="Started"}},
                {"CrossRef",new DisplayNameAndFormat { DisplayName ="CrossRef"}},
                {"StepStatus",new DisplayNameAndFormat { DisplayName ="StepStatus"}},
                {"BranchCode",new DisplayNameAndFormat { DisplayName ="BranchCode"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"Team",new DisplayNameAndFormat { DisplayName ="Team"}},
                {"Extrainfo",new DisplayNameAndFormat { DisplayName ="Extrainfo"}},
                {"Language",new DisplayNameAndFormat { DisplayName ="Language"}},
                {"Isfinished",new DisplayNameAndFormat { DisplayName ="Isfinished"}},
                {"Stepkey",new DisplayNameAndFormat { DisplayName ="Stepkey"}},
            },
                SkipList = new List<string>
            {
                    "Product",
                "Outstamt",
                "Outstccy",
                "OutstamtEgp",
                "Started",
                "CrossRef",
                "StepStatus",
                "BranchCode",
                "Gfcun",
                "CusMnm",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "Team",
                "Extrainfo",
                "Language",
                "Isfinished",
                "Stepkey",
            }
            }
            },
             { nameof(OSLiabilityController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Customer"}},
                {"Sovalue",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"LiabCcy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"Totliabamt",new DisplayNameAndFormat { DisplayName ="Total Per Customer",Format = "{0:n2}"}},
                {"TotliabamtEgp",new DisplayNameAndFormat { DisplayName ="Total Per Customer Egp",Format = "{0:n2}"}},
            },
                SkipList = new List<string>
            {

            }
    }
            },
             { nameof(OSTransactionsAwaitiApprlController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Fullname",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Descri56",new DisplayNameAndFormat { DisplayName ="Team"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"EventReference",new DisplayNameAndFormat { DisplayName ="Event Reference"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Event Status"}},
                {"Started",new DisplayNameAndFormat { DisplayName ="Event Started"}},
                {"PcpAddress1",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
                {"Touched",new DisplayNameAndFormat { DisplayName ="Last Amended"}},
                {"NpcpAddress1",new DisplayNameAndFormat { DisplayName ="Non Principal Party"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Amount Egp",Format = "{0:n2}"}},
                {"Lstmoduser",new DisplayNameAndFormat { DisplayName ="User ID"}},

                {"RefnoPfix",new DisplayNameAndFormat { DisplayName ="RefnoPfix"}},
                {"RefnoSerl",new DisplayNameAndFormat { DisplayName ="RefnoSerl"}},
                {"Workgroup",new DisplayNameAndFormat { DisplayName ="Workgroup"}},
                {"CcyCed",new DisplayNameAndFormat { DisplayName ="CcyCed"}},
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"PcpGfcun",new DisplayNameAndFormat { DisplayName ="PcpGfcun"}},
                {"PcpCusMnm",new DisplayNameAndFormat { DisplayName ="PcpCusMnm"}},
                {"PcpSwBank",new DisplayNameAndFormat { DisplayName ="PcpSwBank"}},
                {"PcpSwCtr",new DisplayNameAndFormat { DisplayName ="PcpSwCtr"}},
                {"PcpSwLoc",new DisplayNameAndFormat { DisplayName ="PcpSwLoc"}},
                {"PcpSwBranch",new DisplayNameAndFormat { DisplayName ="PcpSwBranch"}},
                {"NpcpGfcun",new DisplayNameAndFormat { DisplayName ="NpcpGfcun"}},
                {"NpcpCusMnm",new DisplayNameAndFormat { DisplayName ="NpcpCusMnm"}},
                {"NpcpSwBank",new DisplayNameAndFormat { DisplayName ="NpcpSwBank"}},
                {"NpcpSwCtr",new DisplayNameAndFormat { DisplayName ="NpcpSwCtr"}},
                {"NpcpSwLoc",new DisplayNameAndFormat { DisplayName ="NpcpSwLoc"}},
                {"NpcpSwBranch",new DisplayNameAndFormat { DisplayName ="NpcpSwBranch"}},
                {"Language",new DisplayNameAndFormat { DisplayName ="Language"}},
                {"Shortname",new DisplayNameAndFormat { DisplayName ="Shortname"}},
                {"Isfinished",new DisplayNameAndFormat { DisplayName ="Isfinished"}},
                {"Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                {"Descr",new DisplayNameAndFormat { DisplayName ="Descr"}},
            },
                SkipList = new List<string>
            {
                    "RefnoPfix",
                "RefnoSerl",
                "Workgroup",
                "CcyCed",
                "BhalfBrn",
                "PcpGfcun",
                "PcpCusMnm",
                "PcpSwBank",
                "PcpSwCtr",
                "PcpSwLoc",
                "PcpSwBranch",
                "NpcpGfcun",
                "NpcpCusMnm",
                "NpcpSwBank",
                "NpcpSwCtr",
                "NpcpSwLoc",
                "NpcpSwBranch",
                "Language",
                "Shortname",
                "Isfinished",
                "Type",
                "Descr",
            }
    }
            },
            { nameof(OSTransactionsByGatewayController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Fullname",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Gateway Party"}},
                {"Sovalue",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Reference"}},
                {"Partptd",new DisplayNameAndFormat { DisplayName ="Participated?"}},
                {"Revolving",new DisplayNameAndFormat { DisplayName ="Revlolving?"}},
                {"Outstamt",new DisplayNameAndFormat { DisplayName ="Available Amount",Format = "{0:n2}"}},
                {"Outstccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"OutstamtEgp",new DisplayNameAndFormat { DisplayName ="Available Amount EGP",Format = "{0:n2}"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Transaction Amount EGP",Format = "{0:n2}"}},
                {"CtrctDate",new DisplayNameAndFormat { DisplayName ="Contract Issue Date"}},
                {"RevNext",new DisplayNameAndFormat { DisplayName ="Next Revolve Date"}},
                {"ExpiryDat",new DisplayNameAndFormat { DisplayName ="Expiry Date"}},

                {"Descrip",new DisplayNameAndFormat { DisplayName ="Descrip"}},
                {"Outccysei",new DisplayNameAndFormat { DisplayName ="Outccysei"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"Country",new DisplayNameAndFormat { DisplayName ="Country"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},
                {"Relmstrref",new DisplayNameAndFormat { DisplayName ="Relmstrref"}},
                {"Prodcode",new DisplayNameAndFormat { DisplayName ="Prodcode"}},
                {"Sovalue1",new DisplayNameAndFormat { DisplayName ="Sovalue1"}},
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"Typeflag",new DisplayNameAndFormat { DisplayName ="Typeflag"}},
            },
                SkipList = new List<string>
            {
                    "Descrip",
                "Outccysei",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "CusMnm",
                "Gfcun",
                "Country",
                "Status",
                "Relmstrref",
                "Prodcode",
                "Sovalue1",
                "BhalfBrn",
                "Typeflag",
            }
    }
            },
             { nameof(OSTransactionsByNonPriController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="Behalf Of Branch"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Non-Principal Party"}},
                {"Sovalue",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Descrip",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"Partptd",new DisplayNameAndFormat { DisplayName ="Participated?"}},
                {"Revolving",new DisplayNameAndFormat { DisplayName ="Revolving?"}},
                {"Outstamt",new DisplayNameAndFormat { DisplayName ="Available Amount",Format = "{0:n2}"}},
                {"Outstccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"OutstamtEgp",new DisplayNameAndFormat { DisplayName ="Available Amount Egp",Format = "{0:n2}"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Transaction Amount Egp",Format = "{0:n2}"}},
                {"CtrctDate",new DisplayNameAndFormat { DisplayName ="Contrace Issue Date"}},
                {"RevNext",new DisplayNameAndFormat { DisplayName ="Next Revolve Date"}},
                {"ExpiryDat",new DisplayNameAndFormat { DisplayName ="Expiry Date"}},

                {"Code79",new DisplayNameAndFormat { DisplayName ="Code79"}},
                {"Outccysei",new DisplayNameAndFormat { DisplayName ="Outccysei"}},
                {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"Country",new DisplayNameAndFormat { DisplayName ="Country"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},
                {"Relmstrref",new DisplayNameAndFormat { DisplayName ="Relmstrref"}},
                {"Sovalue1",new DisplayNameAndFormat { DisplayName ="Sovalue1"}},
                {"Typeflag",new DisplayNameAndFormat { DisplayName ="Typeflag"}},
            },
                SkipList = new List<string>
            {
                    "Code79",
                "Outccysei",
                "BranchName",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "CusMnm",
                "Gfcun",
                "Country",
                "Status",
                "Relmstrref",
                "Sovalue1",
                "Typeflag",
            }
            }
            },
            { nameof(OSTransactionsByPrincipalController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
               {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="Behalf Of Branch"}},
               {"Address1",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
               {"Sovalue",new DisplayNameAndFormat { DisplayName ="Product"}},
               {"Descrip",new DisplayNameAndFormat { DisplayName ="Product Type"}},
               {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
               {"Partptd",new DisplayNameAndFormat { DisplayName ="Participated?"}},
               {"Revolving",new DisplayNameAndFormat { DisplayName ="Revolving?"}},
               {"Outstamt",new DisplayNameAndFormat { DisplayName ="Avaialble Amount",Format = "{0:n2}"}},
               {"Outstccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
               {"OutstamtEgp",new DisplayNameAndFormat { DisplayName ="Avaialble Amount Egp",Format = "{0:n2}"}},
               {"Amount",new DisplayNameAndFormat { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
               {"Ccy",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
               {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Transaction Amount Egp",Format = "{0:n2}"}},
               {"CtrctDate",new DisplayNameAndFormat { DisplayName ="Contrace Issue Date"}},
               {"RevNext",new DisplayNameAndFormat { DisplayName ="Next Revolve Date"}},
               {"ExpiryDat",new DisplayNameAndFormat { DisplayName ="Expiry Date"}},

               {"Code79",new DisplayNameAndFormat { DisplayName ="Code79"}},
               {"Outccyspt",new DisplayNameAndFormat { DisplayName ="Outccyspt"}},
               {"Outccysei",new DisplayNameAndFormat { DisplayName ="Outccysei"}},
               {"Fullname",new DisplayNameAndFormat { DisplayName ="Full Name"}},
               {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
               {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
               {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
               {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
               {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
               {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
               {"Country",new DisplayNameAndFormat { DisplayName ="Country"}},
               {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},
               {"Outccyced",new DisplayNameAndFormat { DisplayName ="Outccyced"}},
               {"CcyCed",new DisplayNameAndFormat { DisplayName ="CcyCed"}},
               {"Relmstrref",new DisplayNameAndFormat { DisplayName ="Relmstrref"}},
               {"Sovalue1",new DisplayNameAndFormat { DisplayName ="Sovalue1"}},
               {"Typeflag",new DisplayNameAndFormat { DisplayName ="Typeflag"}},
            },
                SkipList = new List<string>
            {
                    "Code79",
                "Outccyspt",
                "Outccysei",
                "Fullname",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "CusMnm",
                "Gfcun",
                "Country",
                "Status",
                "Outccyced",
                "CcyCed",
                "Relmstrref",
                "Sovalue1",
                "Typeflag",
            }
    }
            },
             { nameof(PeriodicCHRGSPaymentController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Fullname",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Sovalue",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Descr",new DisplayNameAndFormat { DisplayName ="Charge Type"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"PcpAddress1",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
                {"Payrec",new DisplayNameAndFormat { DisplayName ="Pay/Receive"}},
                //{"AdvArr",new DisplayNameAndFormat { DisplayName ="Accrue/Amortise"}},
                {"Outstamt",new DisplayNameAndFormat { DisplayName ="Current Available Amount",Format = "{0:n2}"}},
                {"Outstccy",new DisplayNameAndFormat { DisplayName ="Current Available Amount Currency"}},
                {"OutstamtEgp",new DisplayNameAndFormat { DisplayName ="Current Available Amount Egp",Format = "{0:n2}"}},
                {"NpcpAddress1",new DisplayNameAndFormat { DisplayName ="Non-Principal Party"}},
                {"SchAmt",new DisplayNameAndFormat { DisplayName ="Projected Total Charges",Format = "{0:n2}"}},
                {"SchCcy",new DisplayNameAndFormat { DisplayName ="Projected Total Charges Currency"}},
                {"SchAmtEgp",new DisplayNameAndFormat { DisplayName ="Projected Total Charges EGP",Format = "{0:n2}"}},
                {"AccrueAmt",new DisplayNameAndFormat { DisplayName ="Total Accrued/Amortized Amount to date",Format = "{0:n2}"}},
                {"AccrueCcy",new DisplayNameAndFormat { DisplayName ="Total Accrued/Amortized Amount to date Currency"}},
                {"AccrueAmtEgp",new DisplayNameAndFormat { DisplayName ="Total Accrued/Amortized Amount to date EGP",Format = "{0:n2}"}},
                {"Descr1",new DisplayNameAndFormat { DisplayName ="Commission Type"}},


                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"NpcpGfcun",new DisplayNameAndFormat { DisplayName ="NpcpGfcun"}},
                {"NpcpCusMnm",new DisplayNameAndFormat { DisplayName ="NpcpCusMnm"}},
                {"NpcpSwBank",new DisplayNameAndFormat { DisplayName ="NpcpSwBank"}},
                {"NpcpSwCtr",new DisplayNameAndFormat { DisplayName ="NpcpSwCtr"}},
                {"NpcpSwLoc",new DisplayNameAndFormat { DisplayName ="NpcpSwLoc"}},
                {"NpcpSwBranch",new DisplayNameAndFormat { DisplayName ="NpcpSwBranch"}},
                {"NpcpAddress11",new DisplayNameAndFormat { DisplayName ="NpcpAddress11"}},
                {"ChgGfcun1",new DisplayNameAndFormat { DisplayName ="ChgGfcun1"}},
                {"ChgCusMnm1",new DisplayNameAndFormat { DisplayName ="ChgCusMnm1"}},
                {"ChgSwBank1",new DisplayNameAndFormat { DisplayName ="ChgSwBank1"}},
                {"ChgSwCtr1",new DisplayNameAndFormat { DisplayName ="ChgSwCtr1"}},
                {"ChgSwLoc1",new DisplayNameAndFormat { DisplayName ="ChgSwLoc1"}},
                {"ChgSwBranch1",new DisplayNameAndFormat { DisplayName ="ChgSwBranch1"}},
                {"PcpGfcun",new DisplayNameAndFormat { DisplayName ="PcpGfcun"}},
                {"PcpCusMnm",new DisplayNameAndFormat { DisplayName ="PcpCusMnm"}},
                {"PcpSwBank",new DisplayNameAndFormat { DisplayName ="PcpSwBank"}},
                {"PcpSwCtr",new DisplayNameAndFormat { DisplayName ="PcpSwCtr"}},
                {"PcpSwLoc",new DisplayNameAndFormat { DisplayName ="PcpSwLoc"}},
                {"PcpSwBranch",new DisplayNameAndFormat { DisplayName ="PcpSwBranch"}},
                {"Outccyced",new DisplayNameAndFormat { DisplayName ="Outccyced"}},
                {"Relmstrref",new DisplayNameAndFormat { DisplayName ="Relmstrref"}},
                {"Id",new DisplayNameAndFormat { DisplayName ="Id"}},
                {"SuppAcc",new DisplayNameAndFormat { DisplayName ="SuppAcc"}},
                {"EndDat",new DisplayNameAndFormat { DisplayName ="End Date"}},
                {"StartDat",new DisplayNameAndFormat { DisplayName ="Start Date"}},
                {"Firststart",new DisplayNameAndFormat { DisplayName ="First start"}},
                {"Chgpextraday",new DisplayNameAndFormat { DisplayName ="Chgpextraday"}},
                {"Workgroup",new DisplayNameAndFormat { DisplayName ="Team"}},

                {"Ddate",new DisplayNameAndFormat { DisplayName ="Ddate"}},
                //{"ChargeAmt",new DisplayNameAndFormat { DisplayName ="ChargeAmt"}},
                { "ChargeCcy",new DisplayNameAndFormat { DisplayName ="ChargeCcy",Format = "{0:n2}"}},
                { "ChargeAmtEgp",new DisplayNameAndFormat { DisplayName ="ChargeAmtEgp",Format = "{0:n2}"} }
            },
                SkipList = new List<string>
            {
                    "BhalfBrn",
                "NpcpGfcun",
                "NpcpCusMnm",
                "NpcpSwBank",
                "NpcpSwCtr",
                "NpcpSwLoc",
                "NpcpSwBranch",
                "NpcpAddress11",
                "ChgGfcun1",
                "ChgCusMnm1",
                "ChgSwBank1",
                "ChgSwCtr1",
                "ChgSwLoc1",
                "ChgSwBranch1",
                "PcpGfcun",
                "PcpCusMnm",
                "PcpSwBank",
                "PcpSwCtr",
                "PcpSwLoc",
                "PcpSwBranch",
                "Outccyced",
                "Relmstrref",
                "Id",
                "SuppAcc",
                "EndDat",
                "StartDat",
                "Firststart",
                "Chgpextraday",
                "Workgroup",
                "Ddate",
                "ChargeAmt",
                 "ChargeCcy",
                 "ChargeAmtEgp",
            }
    }
            },
            { nameof(SystemTailoringController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
               {"Paramsetdescr",new DisplayNameAndFormat { DisplayName ="Parameter Set"}},
               {"Prodlongname",new DisplayNameAndFormat { DisplayName ="Product"}},
               {"Eventlongname",new DisplayNameAndFormat { DisplayName ="Event"}},
               {"Attachment",new DisplayNameAndFormat { DisplayName ="Attachment"}},
               {"Mappingtype",new DisplayNameAndFormat { DisplayName ="Mapping Type"}},
               {"Templateid",new DisplayNameAndFormat { DisplayName ="Template ID"}},
               {"Optional",new DisplayNameAndFormat { DisplayName ="Option"}},
               {"Templatedescr",new DisplayNameAndFormat { DisplayName ="Rules"}},

               {"Typeflag",new DisplayNameAndFormat { DisplayName ="Typeflag"}},
               {"Operat44",new DisplayNameAndFormat { DisplayName ="Operat44"}},
               {"Seq97",new DisplayNameAndFormat { DisplayName ="Seq97"}},
               {"Canamdbas",new DisplayNameAndFormat { DisplayName ="Canamdbas"}},
               {"Amendchg",new DisplayNameAndFormat { DisplayName ="Amendchg"}},
               {"Autoprint",new DisplayNameAndFormat { DisplayName ="Autoprint"}},
               {"Severity",new DisplayNameAndFormat { DisplayName ="Severity"}},
               {"ErrorText",new DisplayNameAndFormat { DisplayName ="ErrorText"}},
               {"Deadlinedays",new DisplayNameAndFormat { DisplayName ="Deadlinedays"}},
               {"Deadlinedate",new DisplayNameAndFormat { DisplayName ="Deadlinedate"}},
               {"Deadlinetime",new DisplayNameAndFormat { DisplayName ="Deadlinetime"}},
               {"Deadlinersecs",new DisplayNameAndFormat { DisplayName ="Deadlinersecs"}},
               {"Useevtfm",new DisplayNameAndFormat { DisplayName ="Useevtfm"}},
               {"Username",new DisplayNameAndFormat { DisplayName ="User Name"}},
               {"Teamcode",new DisplayNameAndFormat { DisplayName ="Team Code"}},
               {"Obsolete",new DisplayNameAndFormat { DisplayName ="Obsolete"}},
               {"Relevmapkey",new DisplayNameAndFormat { DisplayName ="Relevmapkey"}},
               {"Steptype",new DisplayNameAndFormat { DisplayName ="Steptype"}},
               {"Amberdays",new DisplayNameAndFormat { DisplayName ="Amberdays"}},
               {"Amberdate",new DisplayNameAndFormat { DisplayName ="Amberdate"}},
               {"Ambertime",new DisplayNameAndFormat { DisplayName ="Ambertime"}},
               {"Amberrsecs",new DisplayNameAndFormat { DisplayName ="Amberrsecs"}},
               {"Reddays",new DisplayNameAndFormat { DisplayName ="Reddays"}},
               {"Reddate",new DisplayNameAndFormat { DisplayName ="Red Date"}},
               {"Redtime",new DisplayNameAndFormat { DisplayName ="Red Time"}},
               {"Redrsecs",new DisplayNameAndFormat { DisplayName ="Redrsecs"}},
               {"Paramsetid",new DisplayNameAndFormat { DisplayName ="Paramsetid"}},
               {"Mappingid",new DisplayNameAndFormat { DisplayName ="Mappingid"}},
               {"Inuse",new DisplayNameAndFormat { DisplayName ="Inuse"}},
               {"Intinitstepid",new DisplayNameAndFormat { DisplayName ="Intinitstepid"}},
               {"Swinitstepid",new DisplayNameAndFormat { DisplayName ="Swinitstepid"}},
               {"Btinitstepid",new DisplayNameAndFormat { DisplayName ="Btinitstepid"}},
               {"Gwinitstepid",new DisplayNameAndFormat { DisplayName ="Gwinitstepid"}},
               {"Swrejstepid",new DisplayNameAndFormat { DisplayName ="Swrejstepid"}},
               {"Btrejstepid",new DisplayNameAndFormat { DisplayName ="Btrejstepid"}},
               {"Gwrejstepid",new DisplayNameAndFormat { DisplayName ="Gwrejstepid"}},
               {"Mapstepid",new DisplayNameAndFormat { DisplayName ="Mapstepid"}},
               {"StepTime",new DisplayNameAndFormat { DisplayName ="Step Time"}},
               {"AvailType",new DisplayNameAndFormat { DisplayName ="Avail Type"}},
               {"Teamdescr",new DisplayNameAndFormat { DisplayName ="Teamdescr"}},
               {"Mappingsubid",new DisplayNameAndFormat { DisplayName ="Mappingsubid"}},
               {"Debitcredit",new DisplayNameAndFormat { DisplayName ="Debitcredit"}},
               {"Trancode",new DisplayNameAndFormat { DisplayName ="Trancode"}},
               {"RevPstngs",new DisplayNameAndFormat { DisplayName ="RevPstngs"}},
               {"InternAcc",new DisplayNameAndFormat { DisplayName ="InternAcc"}},
               {"Contingent",new DisplayNameAndFormat { DisplayName ="Contingent"}},
               {"Liability",new DisplayNameAndFormat { DisplayName ="Liability"}},
               {"ChkLimit",new DisplayNameAndFormat { DisplayName ="ChkLimit"}},
               {"Postingtyp",new DisplayNameAndFormat { DisplayName ="Postingtyp"}},
               {"Margin",new DisplayNameAndFormat { DisplayName ="Margin"}},
               {"Trcrsdliab",new DisplayNameAndFormat { DisplayName ="Trcrsdliab"}},
               {"TransAcc",new DisplayNameAndFormat { DisplayName ="TransAcc"}},
               {"Projection",new DisplayNameAndFormat { DisplayName ="Projection"}},
               {"Sequence",new DisplayNameAndFormat { DisplayName ="Sequence"}},
               {"Rejstepid",new DisplayNameAndFormat { DisplayName ="Rejstepid"}},
               {"ActualAmt",new DisplayNameAndFormat { DisplayName ="Actual Amount"}},
               {"AmtCcy",new DisplayNameAndFormat { DisplayName ="Amount Currency"}},
               {"Mapstepdescr",new DisplayNameAndFormat { DisplayName ="Mapstepdescr"}},
               {"Rejstepdescr",new DisplayNameAndFormat { DisplayName ="Rejstepdescr"}},
               {"Intinitstepdescr",new DisplayNameAndFormat { DisplayName ="Intinitstepdescr"}},
               {"Swinitstepdescr",new DisplayNameAndFormat { DisplayName ="Swinitstepdescr"}},
               {"Btinitstepdescr",new DisplayNameAndFormat { DisplayName ="Btinitstepdescr"}},
               {"Gwinitstepdescr",new DisplayNameAndFormat { DisplayName ="Gwinitstepdescr"}},
               {"Swrejstepdescr",new DisplayNameAndFormat { DisplayName ="Swrejstepdescr"}},
               {"Btrejstepdescr",new DisplayNameAndFormat { DisplayName ="Btrejstepdescr"}},
               {"Gwrejstepdescr",new DisplayNameAndFormat { DisplayName ="Gwrejstepdescr"}},
               {"Domtype",new DisplayNameAndFormat { DisplayName ="Domtype"}},
               {"Dombehaviour",new DisplayNameAndFormat { DisplayName ="Dombehaviour"}},
               {"Domname",new DisplayNameAndFormat { DisplayName ="Domname"}},
               {"Domdefault",new DisplayNameAndFormat { DisplayName ="Domdefault"}},
               {"Domlinkcode",new DisplayNameAndFormat { DisplayName ="Domlinkcode"}},
               {"Domlinkname",new DisplayNameAndFormat { DisplayName ="Domlinkname"}},
               {"Domcode",new DisplayNameAndFormat { DisplayName ="Domcode"}},
               {"Nextstepid",new DisplayNameAndFormat { DisplayName ="Nextstepid"}},
               {"Nextstepdescr",new DisplayNameAndFormat { DisplayName ="Nextstepdescr"}},
               {"Fromstepid",new DisplayNameAndFormat { DisplayName ="Fromstepid"}},
               {"Fromstepdescr",new DisplayNameAndFormat { DisplayName ="Fromstepdescr"}},
               {"AmtField",new DisplayNameAndFormat { DisplayName ="AmtField"}},
               {"Liabamttyp",new DisplayNameAndFormat { DisplayName ="Liabamttyp"}},
               {"Bsparamsetid",new DisplayNameAndFormat { DisplayName ="Bsparamsetid"}},
               {"Bsparamsetdescr",new DisplayNameAndFormat { DisplayName ="Bsparamsetdescr"}},
               {"Field2Src",new DisplayNameAndFormat { DisplayName ="Field2Src"}},
               {"Amount43",new DisplayNameAndFormat { DisplayName ="Amount43"}},
               {"Curren64",new DisplayNameAndFormat { DisplayName ="Curren64"}},
               {"Type24",new DisplayNameAndFormat { DisplayName ="Type24"}},
               {"Relati29",new DisplayNameAndFormat { DisplayName ="Relati29"}},
               {"Dateab63",new DisplayNameAndFormat { DisplayName ="Dateab63"}},
               {"Date71",new DisplayNameAndFormat { DisplayName ="Date71"}},
               {"DateType",new DisplayNameAndFormat { DisplayName ="Date Type"}},
               {"RelDate",new DisplayNameAndFormat { DisplayName ="Rel Date"}},
               {"Intege18",new DisplayNameAndFormat { DisplayName ="Intege18"}},
               {"AccSrc",new DisplayNameAndFormat { DisplayName ="AccSrc"}},
            },
                SkipList = new List<string>
            {
                    "Typeflag",
                "Operat44",
                "Seq97",
                "Canamdbas",
                "Amendchg",
                "Autoprint",
                "Severity",
                "ErrorText",
                "Deadlinedays",
                "Deadlinedate",
                "Deadlinetime",
                "Deadlinersecs",
                "Useevtfm",
                "Username",
                "Teamcode",
                "Obsolete",
                "Relevmapkey",
                "Steptype",
                "Amberdays",
                "Amberdate",
                "Ambertime",
                "Amberrsecs",
                "Reddays",
                "Reddate",
                "Redtime",
                "Redrsecs",
                "Paramsetid",
                "Mappingid",
                "Inuse",
                "Intinitstepid",
                "Swinitstepid",
                "Btinitstepid",
                "Gwinitstepid",
                "Swrejstepid",
                "Btrejstepid",
                "Gwrejstepid",
                "Mapstepid",
                "StepTime",
                "AvailType",
                "Teamdescr",
                "Mappingsubid",
                "Debitcredit",
                "Trancode",
                "RevPstngs",
                "InternAcc",
                "Contingent",
                "Liability",
                "ChkLimit",
                "Postingtyp",
                "Margin",
                "Trcrsdliab",
                "TransAcc",
                "Projection",
                "Sequence",
                "Rejstepid",
                "ActualAmt",
                "AmtCcy",
                "Mapstepdescr",
                "Rejstepdescr",
                "Intinitstepdescr",
                "Swinitstepdescr",
                "Btinitstepdescr",
                "Gwinitstepdescr",
                "Swrejstepdescr",
                "Btrejstepdescr",
                "Gwrejstepdescr",
                "Domtype",
                "Dombehaviour",
                "Domname",
                "Domdefault",
                "Domlinkcode",
                "Domlinkname",
                "Domcode",
                "Nextstepid",
                "Nextstepdescr",
                "Fromstepid",
                "Fromstepdescr",
                "AmtField",
                "Liabamttyp",
                "Bsparamsetid",
                "Bsparamsetdescr",
                "Field2Src",
                "Amount43",
                "Curren64",
                "Type24",
                "Relati29",
                "Dateab63",
                "Date71",
                "DateType",
                "RelDate",
                "Intege18",
                "AccSrc",
            }
    }
            },
            { nameof(WatchlistOSCheckController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Fullname",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Descri56",new DisplayNameAndFormat { DisplayName ="Team"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Referance"}},
                {"Pcpaddress1",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
                {"Npcpaddress1",new DisplayNameAndFormat { DisplayName ="Non-Principal Party"}},
                {"Longna85",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Shortname",new DisplayNameAndFormat { DisplayName ="Event"}},
                {"Started",new DisplayNameAndFormat { DisplayName ="Event Started"}},
                {"Descr",new DisplayNameAndFormat { DisplayName ="Step"}},
                {"Status",new DisplayNameAndFormat { DisplayName ="Status"}},

                {"RefnoPfix",new DisplayNameAndFormat { DisplayName ="RefnoPfix"}},
                {"RefnoSerl",new DisplayNameAndFormat { DisplayName ="RefnoSerl"}},
                {"Touched",new DisplayNameAndFormat { DisplayName ="Touched"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Amount"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Ccy"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="AmountEgp"}},
                {"Workgroup",new DisplayNameAndFormat { DisplayName ="Workgroup"}},
                {"CcyCed",new DisplayNameAndFormat { DisplayName ="CcyCed"}},
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"Pcpgfcun",new DisplayNameAndFormat { DisplayName ="Pcpgfcun"}},
                {"PcpcusMnm",new DisplayNameAndFormat { DisplayName ="PcpcusMnm"}},
                {"PcpswBank",new DisplayNameAndFormat { DisplayName ="PcpswBank"}},
                {"PcpswCtr",new DisplayNameAndFormat { DisplayName ="PcpswCtr"}},
                {"PcpswLoc",new DisplayNameAndFormat { DisplayName ="PcpswLoc"}},
                {"PcpswBranch",new DisplayNameAndFormat { DisplayName ="PcpswBranch"}},
                {"Npcpgfcun",new DisplayNameAndFormat { DisplayName ="Npcpgfcun"}},
                {"NpcpcusMnm",new DisplayNameAndFormat { DisplayName ="NpcpcusMnm"}},
                {"NpcpswBank",new DisplayNameAndFormat { DisplayName ="NpcpswBank"}},
                {"NpcpswCtr",new DisplayNameAndFormat { DisplayName ="NpcpswCtr"}},
                {"NpcpswLoc",new DisplayNameAndFormat { DisplayName ="NpcpswLoc"}},
                {"NpcpswBranch",new DisplayNameAndFormat { DisplayName ="NpcpswBranch"}},
                {"Language",new DisplayNameAndFormat { DisplayName ="Language"}},
                {"Isfinished",new DisplayNameAndFormat { DisplayName ="Isfinished"}},
                {"Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                {"Lstmoduser",new DisplayNameAndFormat { DisplayName ="Lstmoduser"}},
            },
                SkipList = new List<string>
            {
                    "RefnoPfix",
             "RefnoSerl",
             "Touched",
             "Amount",
             "Ccy",
             "AmountEgp",
             "Workgroup",
             "CcyCed",
             "BhalfBrn",
             "Pcpgfcun",
             "PcpcusMnm",
             "PcpswBank",
             "PcpswCtr",
             "PcpswLoc",
             "PcpswBranch",
             "Npcpgfcun",
             "NpcpcusMnm",
             "NpcpswBank",
             "NpcpswCtr",
             "NpcpswLoc",
             "NpcpswBranch",
             "Language",
             "Isfinished",
             "Type",
             "Lstmoduser",
            }
            }
            },
             { nameof(OSActivityController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"Team",new DisplayNameAndFormat { DisplayName ="Team"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="MasterRef"}},
                {"Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Descrip",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
                {"Amount",new DisplayNameAndFormat { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"AmountEgp",new DisplayNameAndFormat { DisplayName ="Amount Egp",Format = "{0:n2}"}},
            },
                SkipList = new List<string>
            {

            }
    }
            },
             { nameof(FinancingInterestAccrualsController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"BranchName",new DisplayNameAndFormat { DisplayName ="Branch Name"}},
                {"MasterRef",new DisplayNameAndFormat { DisplayName ="Master Reference"}},
                {"Startdate",new DisplayNameAndFormat { DisplayName ="Start Date"}},
                {"Maturity",new DisplayNameAndFormat { DisplayName ="Maturity Date"}},
                {"Prodcut",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"AmtOS",new DisplayNameAndFormat { DisplayName ="Outstanding Amount",Format = "{0:n2}"}},
                {"Recccy",new DisplayNameAndFormat { DisplayName ="Currency"}},
                {"AmtOSEgp",new DisplayNameAndFormat { DisplayName ="Outstanding Amount Egp",Format = "{0:n2}"}},
                {"Inttypeid",new DisplayNameAndFormat { DisplayName ="Inttypeid"}},
                {"Calcdte",new DisplayNameAndFormat { DisplayName ="Calc Date"}},
                {"EarlyDate",new DisplayNameAndFormat { DisplayName ="Early Date"}},
                {"RecamtPd",new DisplayNameAndFormat { DisplayName ="RecamtPd"}},
                {"RecccyPd",new DisplayNameAndFormat { DisplayName ="RecccyPd"}},
                {"RecamtPdEgp",new DisplayNameAndFormat { DisplayName ="RecamtPdEgp"}},
                {"Address1",new DisplayNameAndFormat { DisplayName ="Principal"}},
                {"InterestRateType",new DisplayNameAndFormat { DisplayName ="Interest Rate and Type"}},
                {"Gfcun",new DisplayNameAndFormat { DisplayName ="Gfcun"}},
                {"CusMnm",new DisplayNameAndFormat { DisplayName ="CusMnm"}},
                {"SwBank",new DisplayNameAndFormat { DisplayName ="SwBank"}},
                {"SwCtr",new DisplayNameAndFormat { DisplayName ="SwCtr"}},
                {"SwLoc",new DisplayNameAndFormat { DisplayName ="SwLoc"}},
                {"SwBranch",new DisplayNameAndFormat { DisplayName ="SwBranch"}},
                {"Recamt",new DisplayNameAndFormat { DisplayName ="Recamt"}},
                {"DealCcy",new DisplayNameAndFormat { DisplayName ="DealCcy"}},
                {"IntpAmt",new DisplayNameAndFormat { DisplayName ="IntpAmt"}},
                {"IntpCcy",new DisplayNameAndFormat { DisplayName ="IntpCcy"}},
                {"IntpAmtEgp",new DisplayNameAndFormat { DisplayName ="IntpAmtEgp"}},
                {"Cycleend",new DisplayNameAndFormat { DisplayName ="Cycleend"}},
                {"Pastduedte",new DisplayNameAndFormat { DisplayName ="Pastduedte"}},
                {"Extraday",new DisplayNameAndFormat { DisplayName ="Extraday"}},
                {"IntType",new DisplayNameAndFormat { DisplayName ="IntType"}},
                {"RateType",new DisplayNameAndFormat { DisplayName ="RateType"}},
                {"PartpnRef",new DisplayNameAndFormat { DisplayName ="PartpnRef"}},
                {"Ptnshare",new DisplayNameAndFormat { DisplayName ="Ptnshare"}},
                {"Prodtypename",new DisplayNameAndFormat { DisplayName ="Prodtypename"}},
                {"Idb",new DisplayNameAndFormat { DisplayName ="Idb"}},
                {"Intperunit",new DisplayNameAndFormat { DisplayName ="Intperunit"}},
                {"Intpernum",new DisplayNameAndFormat { DisplayName ="Intpernum"}},
                {"Intperday",new DisplayNameAndFormat { DisplayName ="Intperday"}},
                {"CcySpt",new DisplayNameAndFormat { DisplayName ="CcySpt"}},
                {"CcySei",new DisplayNameAndFormat { DisplayName ="CcySei"}},
                {"BhalfBrn",new DisplayNameAndFormat { DisplayName ="BhalfBrn"}},
                {"Sovalue",new DisplayNameAndFormat { DisplayName ="Sovalue"}},
                {"CcyCed",new DisplayNameAndFormat { DisplayName ="CcyCed"}},
                {"CalcdtePd",new DisplayNameAndFormat { DisplayName ="CalcdtePd"}},
                {"Calcrate",new DisplayNameAndFormat { DisplayName ="Calcrate"}},
                {"Actualrate",new DisplayNameAndFormat { DisplayName ="Actualrate"}},
                {"Prodtypedesc",new DisplayNameAndFormat { DisplayName ="Prodtypedesc"}},
                {"BaseRate2",new DisplayNameAndFormat { DisplayName ="BaseRate2"}},
                {"DiffRate2",new DisplayNameAndFormat { DisplayName ="DiffRate2"}},
                {"GroupRate2",new DisplayNameAndFormat { DisplayName ="GroupRate2"}},
                {"BalancAmt",new DisplayNameAndFormat { DisplayName ="BalancAmt"}},
                {"SplitTier",new DisplayNameAndFormat { DisplayName ="SplitTier"}},
                {"TierNum",new DisplayNameAndFormat { DisplayName ="TierNum"}},
                {"TierAmt",new DisplayNameAndFormat { DisplayName ="TierAmt"}},
                {"Pedoramt",new DisplayNameAndFormat { DisplayName ="Pedoramt"}},
                {"TierPnum",new DisplayNameAndFormat { DisplayName ="TierPnum"}},
                {"TierPunit",new DisplayNameAndFormat { DisplayName ="TierPunit"}},
                {"TierBase",new DisplayNameAndFormat { DisplayName ="TierBase"}},
                {"TierDiff",new DisplayNameAndFormat { DisplayName ="TierDiff"}},
                {"TierSprd",new DisplayNameAndFormat { DisplayName ="TierSprd"}},
                {"TierRate",new DisplayNameAndFormat { DisplayName ="TierRate"}},
                {"GroupCode",new DisplayNameAndFormat { DisplayName ="GroupCode"}},
                {"Schratetype",new DisplayNameAndFormat { DisplayName ="Schratetype"}},
                {"Calcrate1",new DisplayNameAndFormat { DisplayName ="Calcrate1"}},
                {"Interp",new DisplayNameAndFormat { DisplayName ="Interp"}},
                {"Interprate",new DisplayNameAndFormat { DisplayName ="Interprate"}},
                {"Commitamt",new DisplayNameAndFormat { DisplayName ="Commitamt"}},
                {"AmtOrPct",new DisplayNameAndFormat { DisplayName ="AmtOrPct"}},
            },
                SkipList = new List<string>
            {
                    "Inttypeid",
                "Calcdte",
                "EarlyDate",
                "RecamtPd",
                "RecccyPd",
                "RecamtPdEgp",
                "Gfcun",
                "CusMnm",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "Recamt",
                "DealCcy",
                "IntpAmt",
                "IntpCcy",
                "IntpAmtEgp",
                "Cycleend",
                "Pastduedte",
                "Extraday",
                "IntType",
                "RateType",
                "PartpnRef",
                "Ptnshare",
                "Prodtypename",
                "Idb",
                "Intperunit",
                "Intpernum",
                "Intperday",
                "CcySpt",
                "CcySei",
                "BhalfBrn",
                "Sovalue",
                "CcyCed",
                "CalcdtePd",
                "Calcrate",
                "Actualrate",
                "Prodtypedesc",
                "BaseRate2",
                "DiffRate2",
                "GroupRate2",
                "BalancAmt",
                "SplitTier",
                "TierNum",
                "TierAmt",
                "Pedoramt",
                "TierPnum",
                "TierPunit",
                "TierBase",
                "TierDiff",
                "TierSprd",
                "TierRate",
                "GroupCode",
                "Schratetype",
                "Calcrate1",
                "Interp",
                "Interprate",
                "Commitamt",
                "AmtOrPct",
            }
    }
            },
             { nameof(AdvancePaymentUtilizationController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Branch",new DisplayNameAndFormat { DisplayName ="Branch"}},
                {"AdvReference",new DisplayNameAndFormat { DisplayName ="Advance Reference"}},
                {"PrincipalParty",new DisplayNameAndFormat { DisplayName ="Principal Party"}},
                {"NonPrincipalParty",new DisplayNameAndFormat { DisplayName ="Non Principal Party"}},
                {"CreationDate",new DisplayNameAndFormat { DisplayName ="CreationDate",Format="{0:dd/MM/yyyy}"}},
                {"ExpiryDate",new DisplayNameAndFormat { DisplayName ="Expiry Date",Format="{0:dd/MM/yyyy}"}},
                {"UtilizationTrn",new DisplayNameAndFormat { DisplayName ="Utilization Transaction"}},
                {"AdvAmount",new DisplayNameAndFormat { DisplayName ="Advance Amount",Format = "{0:n2}"}},
                {"AdvCurrency",new DisplayNameAndFormat { DisplayName ="Advance Currency"}},
                {"UtilizationAmount",new DisplayNameAndFormat { DisplayName ="Utilization Amount",Format="{0:n2}"}},
                {"UtilizationCurrency",new DisplayNameAndFormat { DisplayName ="Utilization Currency"}},
                {"OutstandingAmount",new DisplayNameAndFormat { DisplayName ="Outstanding Amount",Format="{0:n2}"}},
            },
                SkipList = new List<string>
            {

            }
    }
            },
            { nameof(FullJournalController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"Dataitem",new DisplayNameAndFormat { DisplayName ="Data Item"}},
                {"Username",new DisplayNameAndFormat { DisplayName ="User Name"}},
                {"MtceType",new DisplayNameAndFormat { DisplayName ="Mode"}},
                {"Mcmtcetype",new DisplayNameAndFormat { DisplayName ="Mcmtcetype"}},
                {"Mcusername",new DisplayNameAndFormat { DisplayName ="Mcusername"}},
                {"AreaCode",new DisplayNameAndFormat { DisplayName ="AreaCode"}},
                {"Area",new DisplayNameAndFormat { DisplayName ="Type"}},
                {"Jkey",new DisplayNameAndFormat { DisplayName ="Jkey"}},
                {"Datetime",new DisplayNameAndFormat { DisplayName ="Date"}},
                {"Mcowner",new DisplayNameAndFormat { DisplayName ="Mcowner"}},
                {"Entrytimeutc",new DisplayNameAndFormat { DisplayName ="Entrytimeutc"}},
                {"Mcaction",new DisplayNameAndFormat { DisplayName ="Mcaction"}},
                {"Mcnote",new DisplayNameAndFormat { DisplayName ="Mcnote"}},
                {"DataAfter",new DisplayNameAndFormat { DisplayName ="Details After" , isLargeText = true}},
                {"Databefore",new DisplayNameAndFormat { DisplayName ="Details Before" , isLargeText = true}},
            },
                SkipList = new List<string>
            {
                    "Mcmtcetype",
                "Mcusername",
                "AreaCode",
                "Jkey",
                "Mcowner",
                "Entrytimeutc",
                "Mcaction",
                "Mcnote",
            }
    }
            },
            { nameof(EcmWorkflowProgController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                {"EcmReference",new DisplayNameAndFormat { DisplayName ="ECM Reference"}},
                {"EcmCaseCreationDate",new DisplayNameAndFormat { DisplayName ="ECM Case Creation Date"}},
                {"BranchId",new DisplayNameAndFormat { DisplayName ="Branch ID"}},
                {"CutomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                {"Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"ProductType",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                {"EcmEvent",new DisplayNameAndFormat { DisplayName ="ECM Event"}},
                {"TransactionAmount",new DisplayNameAndFormat { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"TransactionCurrency",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                {"PrimaryOwner",new DisplayNameAndFormat { DisplayName ="Primary Owner"}},
                {"CaseStatCd",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                {"UpdateUserId",new DisplayNameAndFormat { DisplayName ="Last Action taken by"}},
                //{"Comments",new DisplayNameAndFormat { DisplayName ="Comments"}},
                {"EcmRejectionType",new DisplayNameAndFormat { DisplayName ="ECM Rejection Reason"}},
                {"EcmRejectionReason",new DisplayNameAndFormat { DisplayName ="ECM Rejection Description"}},
                {"FtiReference",new DisplayNameAndFormat { DisplayName ="FTI Reference"}},
                {"EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                {"EventStatus",new DisplayNameAndFormat { DisplayName ="Event Status"}},
                {"EventCreationDate",new DisplayNameAndFormat { DisplayName ="Event Creation Date"}},
                {"AssignedTo",new DisplayNameAndFormat { DisplayName ="Assigned To"}},
                {"AssignmentType",new DisplayNameAndFormat { DisplayName ="Assignment Type"}},
                {"EventSteps",new DisplayNameAndFormat { DisplayName ="Event Steps"}},
                {"StepStatus",new DisplayNameAndFormat { DisplayName ="Step Status"}},
                {"Lstmodtime",new DisplayNameAndFormat { DisplayName ="Last Modification Time"}},
                {"Lstmoduser",new DisplayNameAndFormat { DisplayName ="Last Modification By"}},
                {"WarningOverridden",new DisplayNameAndFormat { DisplayName ="Warning Overridden"}},
                {"RejectionReason",new DisplayNameAndFormat { DisplayName ="Rejection Reason", isLargeText = true}},
                {"SlaDeadline",new DisplayNameAndFormat { DisplayName ="SLA Deadline"}},
                {"InputStepTime",new DisplayNameAndFormat { DisplayName ="Input Step Time"}},
                {"InputSlaStatus",new DisplayNameAndFormat { DisplayName ="Input SLA Status"}},
                {"InputMaxTime",new DisplayNameAndFormat { DisplayName ="Input Max Time"}},
                {"ExternalReviewStepTime",new DisplayNameAndFormat { DisplayName ="External Review Step Time"}},
                {"ExternalReviewSlaStatus",new DisplayNameAndFormat { DisplayName ="External Review SLA Status"}},
                {"ReviewStepTime",new DisplayNameAndFormat { DisplayName ="Review Step Time"}},
                {"ReviewSlaStatus",new DisplayNameAndFormat { DisplayName ="Review SLA Status"}},
                {"AuthorizeStepTime",new DisplayNameAndFormat { DisplayName ="Authorize Step Time"}},
                {"AuthorizeSlaStatus",new DisplayNameAndFormat { DisplayName ="Authorize SLA Status"}},
                {"SlaDashboardAmber",new DisplayNameAndFormat { DisplayName ="SLA Dashboard Amber"}},
                {"SlaDashboardRed",new DisplayNameAndFormat { DisplayName ="SLA Dashboard Red"}},
                {"SlaRemainingTime",new DisplayNameAndFormat { DisplayName ="SLA Remaining TIme"}},
            },
                SkipList = new List<string>
            {
                "Comments",
                "Product",
                "Sovaluecode",
                "Gfcun",
                "CusMnm",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "Active",
                "CtrctDate",
                "Outstamt",
                "Outccyced",
                "Outstccy",
                "OutstamtEgp",
                "Relmstrref",
                "CcyCed",
                "CreatedAt",
                "RefnoPfix",
                "RefnoSerl"
            }
    }
            },
            { nameof(EcmAuditTrialController).ToLower() , new ReportConfig
            {
                DisplayNames =  new Dictionary<string, DisplayNameAndFormat>
            {
                 {"EcmReference",new DisplayNameAndFormat { DisplayName ="ECM Reference"}},
                {"BranchId",new DisplayNameAndFormat { DisplayName ="Branch ID"}},
                {"EcmCaseCreationDate",new DisplayNameAndFormat { DisplayName ="ECM Case Creation Date"}},
                {"CutomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                {"Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                {"Producttype",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                {"EcmEvent",new DisplayNameAndFormat { DisplayName ="Ecm Event"}},
                {"TransactionAmount",new DisplayNameAndFormat { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"TransactionCurrency",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                {"PrimaryOwner",new DisplayNameAndFormat { DisplayName ="Primary Owner"}},
                {"CaseStatCd",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                {"UpdateUserId",new DisplayNameAndFormat { DisplayName ="Last Action taken by"}},
                {"Comments",new DisplayNameAndFormat { DisplayName ="Comments"}},
                {"FtiReference",new DisplayNameAndFormat { DisplayName ="Fti Reference"}},
                {"EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                {"EventStatus",new DisplayNameAndFormat { DisplayName ="Event Status"}},
                {"EventCreationDate",new DisplayNameAndFormat { DisplayName ="Event Creation Date"}},
                {"MasterAssignedTo",new DisplayNameAndFormat { DisplayName ="Master Assigned To"}},
                {"EventSteps",new DisplayNameAndFormat { DisplayName ="Event Steps"}},
                {"StepStatus",new DisplayNameAndFormat { DisplayName ="Step Status"}},
            },
                SkipList = new List<string>
            {
                    "Product",
                "Sovaluecode",
                "Gfcun",
                "CusMnm",
                "SwBank",
                "SwCtr",
                "SwLoc",
                "SwBranch",
                "Active",
                "CtrctDate",
                "Outstamt",
                "Outccyced",
                "Outstccy",
                "OutstamtEgp",
                "Relmstrref",
                "CcyCed",
                "CreatedAt",
                "RefnoPfix",
                "RefnoSerl",
            }
    }
            },
            



//KYC
            {
                nameof(ArtAuditCorporateController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "CaseRk",new DisplayNameAndFormat { DisplayName ="Case Rk"}},
                        {  "BankingOrCorporate",new DisplayNameAndFormat { DisplayName ="Banking Or Corporate"}},
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "NameLanguage",new DisplayNameAndFormat { DisplayName ="Name Language"}},
                        {  "CorporateName",new DisplayNameAndFormat { DisplayName ="Corporate Name"}},
                        {  "CommercialName",new DisplayNameAndFormat { DisplayName ="Commercial Name"}},
                        {  "CorporateNameEn",new DisplayNameAndFormat { DisplayName ="Corporate Name En"}},
                        {  "CommercialNameEn",new DisplayNameAndFormat { DisplayName ="Commercial Name En"}},
                        {  "Title",new DisplayNameAndFormat { DisplayName ="Title"}},
                        {  "DefaultBranch",new DisplayNameAndFormat { DisplayName ="Default Branch"}},
                        {  "Industry",new DisplayNameAndFormat { DisplayName ="Industry"}},
                        {  "AmlRiskCd",new DisplayNameAndFormat { DisplayName ="Aml Risk CD"}},
                        {  "KycStatus",new DisplayNameAndFormat { DisplayName ="Kyc Status"}},
                        {  "TypeOfBusiness",new DisplayNameAndFormat { DisplayName ="Type Of Business"}},
                        {  "TypeOfBusinessOther",new DisplayNameAndFormat { DisplayName ="Type Of Business Other"}},
                        {  "IdentType",new DisplayNameAndFormat { DisplayName ="Identity Type"}},
                        {  "IdentNumber",new DisplayNameAndFormat { DisplayName ="Identity Number"}},
                        {  "IdIssueCountry",new DisplayNameAndFormat { DisplayName ="ID Issue Country"}},
                        {  "IdentIssueDate",new DisplayNameAndFormat { DisplayName ="Identity Issue Date"}},
                        {  "IdentExpiryDate",new DisplayNameAndFormat { DisplayName ="Identity Expiry Date"}},
                        {  "RegNumberCity",new DisplayNameAndFormat { DisplayName ="Reg Number City"}},
                        {  "RegNumberOffice",new DisplayNameAndFormat { DisplayName ="Reg Number Office"}},
                        {  "RegistrationNumber",new DisplayNameAndFormat { DisplayName ="Registration Number"}},
                        {  "RegExpiryDate",new DisplayNameAndFormat { DisplayName ="Reg Expiry Date"}},
                        {  "RegNumberLastDate",new DisplayNameAndFormat { DisplayName ="Reg Number Last Date"}},
                        {  "HeadQuarterCountry",new DisplayNameAndFormat { DisplayName ="Head Quarter Country"}},
                        {  "TaxIdNum",new DisplayNameAndFormat { DisplayName ="Tax ID Number"}},
                        {  "NationalityCountry",new DisplayNameAndFormat { DisplayName ="Nationality Country"}},
                        {  "IncorporationCountryCode",new DisplayNameAndFormat { DisplayName ="Incorporation Country Code"}},
                        {  "IncorporationDate",new DisplayNameAndFormat { DisplayName ="Incorporation Date"}},
                        {  "IncorporationLegalForm",new DisplayNameAndFormat { DisplayName ="Incorporation Legal Form"}},
                        {  "IncorporationState",new DisplayNameAndFormat { DisplayName ="Incorporation State"}},
                        {  "LegalFormOthers",new DisplayNameAndFormat { DisplayName ="Legal Form Others"}},
                        {  "LegalFormSub",new DisplayNameAndFormat { DisplayName ="Legal Form Sub"}},
                        {  "RiskReason",new DisplayNameAndFormat { DisplayName ="Risk Reason"}},
                        {  "RiskCode",new DisplayNameAndFormat { DisplayName ="Risk Code"}},
                        {  "CbRiskRate",new DisplayNameAndFormat { DisplayName ="Cb Risk Rate"}},
                        {  "ClosingReasonId",new DisplayNameAndFormat { DisplayName ="Closing Reason ID"}},
                        {  "CloseDate",new DisplayNameAndFormat { DisplayName ="Close Date"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                        {  "CreatedBy",new DisplayNameAndFormat { DisplayName ="Created By"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},
                        {  "UpdateDate",new DisplayNameAndFormat { DisplayName ="Update Date"}},
                        {  "UpdatedBy",new DisplayNameAndFormat { DisplayName ="Updated By"}},
                        {  "ActivityTypeSub",new DisplayNameAndFormat { DisplayName ="Activity Type Sub"}},
                        {  "BudgetDate1",new DisplayNameAndFormat { DisplayName ="Budget Date1"}},
                        {  "BudgetDate2",new DisplayNameAndFormat { DisplayName ="Budget Date2"}},
                        {  "BudgetDate3",new DisplayNameAndFormat { DisplayName ="Budget Date3"}},
                        {  "FfiType",new DisplayNameAndFormat { DisplayName ="Ffi Type"}},
                        {  "Giin",new DisplayNameAndFormat { DisplayName ="Giin"}},
                        {  "SalesVolume1",new DisplayNameAndFormat { DisplayName ="Sales Volume1"}},
                        {  "SalesVolume2",new DisplayNameAndFormat { DisplayName ="Sales Volume2"}},
                        {  "SalesVolume3",new DisplayNameAndFormat { DisplayName ="Sales Volume3"}},
                        {  "ActivityAmount",new DisplayNameAndFormat { DisplayName ="Activity Amount"}},
                        {  "ActivityAmountCurrency",new DisplayNameAndFormat { DisplayName ="Activity Amount Currency"}},
                        {  "ActivityEndDate",new DisplayNameAndFormat { DisplayName ="Activity End Date"}},
                        {  "ActivityStartDate",new DisplayNameAndFormat { DisplayName ="Activity Start Date"}},
                        {  "ActivityType",new DisplayNameAndFormat { DisplayName ="Activity Type"}},
                        {  "ActivityTypeDtls",new DisplayNameAndFormat { DisplayName ="Activity Type Dtls"}},
                        {  "CharityDonationsInd",new DisplayNameAndFormat { DisplayName ="Charity Donations Ind"}},
                        {  "FinancialStartDate",new DisplayNameAndFormat { DisplayName ="Financial Start Date"}},
                        {  "ForeignConsulateEmbassyInd",new DisplayNameAndFormat { DisplayName ="Foreign Consulate Embassy Ind"}},
                        {  "GovOrgInd",new DisplayNameAndFormat { DisplayName ="Gov Org Ind"}},
                        {  "WomenShare",new DisplayNameAndFormat { DisplayName ="Women Share"}},
                        {  "DateOfBudget",new DisplayNameAndFormat { DisplayName ="Date Of Budget"}},
                        {  "NoOfEmployees",new DisplayNameAndFormat { DisplayName ="No Of Employees"}},
                        {  "SizeOfSales",new DisplayNameAndFormat { DisplayName ="Size Of Sales"}},
                        {  "SizeOfTransaction",new DisplayNameAndFormat { DisplayName ="Size Of Transaction"}},
                        {  "ReferenceEmployeeId",new DisplayNameAndFormat { DisplayName ="Reference Employee ID"}},
                        {  "CustomerReference",new DisplayNameAndFormat { DisplayName ="Customer Reference"}},
                        {  "BankingOrOtherRef",new DisplayNameAndFormat { DisplayName ="Banking Or Other Ref"}},
                        {  "LimitsAmount",new DisplayNameAndFormat { DisplayName ="Limits Amount"}},
                        {  "LimitsAmountCurrency",new DisplayNameAndFormat { DisplayName ="Limits Amount Currency"}},
                        {  "GeoCode",new DisplayNameAndFormat { DisplayName ="Geo Code"}},
                        {  "BusinessCode",new DisplayNameAndFormat { DisplayName ="Business Code"}},
                        {  "CalculateZakahFlag",new DisplayNameAndFormat { DisplayName ="Calculate Zakah Flag"}},
                        {  "CustomerStatus",new DisplayNameAndFormat { DisplayName ="Customer Status"}},
                        {  "InvestmentBalance",new DisplayNameAndFormat { DisplayName ="Investment Balance"}},
                        {  "SalesBasis",new DisplayNameAndFormat { DisplayName ="Sales Basis"}},
                        {  "LegalStepMainCode",new DisplayNameAndFormat { DisplayName ="Legal Step Main Code"}},
                        {  "LegalStepSubCode",new DisplayNameAndFormat { DisplayName ="Legal Step Sub Code"}},
                        {  "MainLegalForm",new DisplayNameAndFormat { DisplayName ="Main Legal Form"}},
                        {  "UnderEstablishment",new DisplayNameAndFormat { DisplayName ="Under Establishment"}},
                        {  "TotalNoOfUnits",new DisplayNameAndFormat { DisplayName ="Total No Of Units"}},
                        {  "RiskWeight",new DisplayNameAndFormat { DisplayName ="Risk Weight"}},
                        {  "WorthCode",new DisplayNameAndFormat { DisplayName ="Worth Code"}},
                        {  "LastQueryDate",new DisplayNameAndFormat { DisplayName ="Last Query Date"}},
                        {  "TradeAddDate",new DisplayNameAndFormat { DisplayName ="Trade Add Date"}},
                        {  "WorthLastCalcDate",new DisplayNameAndFormat { DisplayName ="Worth Last Calc Date"}},
                        {  "EconomicActivityCode5",new DisplayNameAndFormat { DisplayName ="Economic Activity Code5"}},
                        {  "PaidUpCapitalAmount",new DisplayNameAndFormat { DisplayName ="Paid Up Capital Amount"}},
                        {  "PaidUpCapitalCurrency",new DisplayNameAndFormat { DisplayName ="Paid Up Capital Currency"}},
                        {  "DealtBankDetails",new DisplayNameAndFormat { DisplayName ="Dealt Bank Details"}},
                        {  "DealAbrdBankDetails",new DisplayNameAndFormat { DisplayName ="Deal Abrd Bank Details"}},
                        {  "OtherBankAccounts",new DisplayNameAndFormat { DisplayName ="Other Bank Accounts"}},
                        {  "Capital1",new DisplayNameAndFormat { DisplayName ="Capital1"}},
                        {  "Capital2",new DisplayNameAndFormat { DisplayName ="Capital2"}},
                        {  "Capital3",new DisplayNameAndFormat { DisplayName ="Capital3"}},
                        {  "AnnualNetIncomeCd",new DisplayNameAndFormat { DisplayName ="Annual Net Income CD"}},
                        {  "NonProfitOrganization",new DisplayNameAndFormat { DisplayName ="Non Profit Organization"}},
                        {  "CompanyStock",new DisplayNameAndFormat { DisplayName ="Company Stock"}},
                        {  "CompanyStockName",new DisplayNameAndFormat { DisplayName ="Company Stock Name"}},
                        {  "HoldingCorporation",new DisplayNameAndFormat { DisplayName ="Holding Corporation"}},
                        {  "HoldingCorporationCd",new DisplayNameAndFormat { DisplayName ="Holding Corporation CD"}},
                    }
                }
            },
            {
                nameof(ArtAuditIndividualsController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "CaseRk",new DisplayNameAndFormat { DisplayName ="Case Rk"}},
                        {  "AKA",new DisplayNameAndFormat { DisplayName ="AKA"}},
                        {  "OpeningReasonId",new DisplayNameAndFormat { DisplayName ="Opening Reason ID"}},
                        {  "AmlRiskCd",new DisplayNameAndFormat { DisplayName ="Aml Risk CD"}},
                        {  "CitizenOrResident",new DisplayNameAndFormat { DisplayName ="Citizen Or Resident"}},
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "CloseDate",new DisplayNameAndFormat { DisplayName ="Close Date"}},
                        {  "ClosingReasonId",new DisplayNameAndFormat { DisplayName ="Closing Reason ID"}},
                        {  "CreateDate",new DisplayNameAndFormat { DisplayName ="Create Date"}},
                        {  "CreatedBy",new DisplayNameAndFormat { DisplayName ="Created By"}},
                        {  "RiskClassValue",new DisplayNameAndFormat { DisplayName ="Risk Class Value"}},
                        {  "CustomerType",new DisplayNameAndFormat { DisplayName ="Customer Type"}},
                        {  "DefaultBranch",new DisplayNameAndFormat { DisplayName ="Default Branch"}},
                        {  "NumberOfDependents",new DisplayNameAndFormat { DisplayName ="Number Of Dependents"}},
                        {  "FirstName",new DisplayNameAndFormat { DisplayName ="First Name"}},
                        {  "FullNameAr",new DisplayNameAndFormat { DisplayName ="Full Name AR"}},
                        {  "FullNameEn",new DisplayNameAndFormat { DisplayName ="Full Name EN"}},
                        {  "GenderCd",new DisplayNameAndFormat { DisplayName ="Gender CD"}},
                        {  "EducationId",new DisplayNameAndFormat { DisplayName ="Education ID"}},
                        {  "CbRiskId",new DisplayNameAndFormat { DisplayName ="Cb Risk ID"}},
                        {  "KycStatus",new DisplayNameAndFormat { DisplayName ="Kyc Status"}},
                        {  "RaceId",new DisplayNameAndFormat { DisplayName ="Race ID"}},
                        {  "LastName",new DisplayNameAndFormat { DisplayName ="Last Name"}},
                        {  "MaritalStatusCd",new DisplayNameAndFormat { DisplayName ="Marital Status CD"}},
                        {  "MiddleName",new DisplayNameAndFormat { DisplayName ="Middle Name"}},
                        {  "MotherName",new DisplayNameAndFormat { DisplayName ="Mother Name"}},
                        {  "NationalityCode1",new DisplayNameAndFormat { DisplayName ="Nationality Code1"}},
                        {  "NationalityCode2",new DisplayNameAndFormat { DisplayName ="Nationality Code2"}},
                        {  "NationalityCode3",new DisplayNameAndFormat { DisplayName ="Nationality Code3"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},
                        {  "CbRiskRate",new DisplayNameAndFormat { DisplayName ="Cb Risk Rate"}},
                        {  "Religion",new DisplayNameAndFormat { DisplayName ="Religion"}},
                        {  "ResidenceCountry",new DisplayNameAndFormat { DisplayName ="Residence Country"}},
                        {  "RiskReason",new DisplayNameAndFormat { DisplayName ="Risk Reason"}},
                        {  "RiskCode",new DisplayNameAndFormat { DisplayName ="Risk Code"}},
                        {  "SictorCode",new DisplayNameAndFormat { DisplayName ="Sictor Code"}},
                        {  "Title",new DisplayNameAndFormat { DisplayName ="Title"}},
                        {  "UpdateDate",new DisplayNameAndFormat { DisplayName ="Update Date"}},
                        {  "UpdatedBy",new DisplayNameAndFormat { DisplayName ="Updated By"}},
                        {  "VisaType",new DisplayNameAndFormat { DisplayName ="Visa Type"}},
                        {  "FirstNameEng",new DisplayNameAndFormat { DisplayName ="First Name EN"}},
                        {  "LastNameEng",new DisplayNameAndFormat { DisplayName ="Last Name EN"}},
                        {  "MiddleNameEng",new DisplayNameAndFormat { DisplayName ="Middle Name EN"}},
                        {  "NameLanguage",new DisplayNameAndFormat { DisplayName ="Name Language"}},
                        {  "EmployeeIndicator",new DisplayNameAndFormat { DisplayName ="Employee Indicator"}},
                        {  "EducationIdOther",new DisplayNameAndFormat { DisplayName ="Education ID Other"}},
                        {  "SpouseBusiness",new DisplayNameAndFormat { DisplayName ="Spouse Business"}},
                        {  "SpouseName",new DisplayNameAndFormat { DisplayName ="Spouse Name"}},
                        {  "VisaExpirationDate",new DisplayNameAndFormat { DisplayName ="Visa Expiration Date"}},
                        {  "CbRiskRateOther",new DisplayNameAndFormat { DisplayName ="Cb Risk Rate Other"}},
                        {  "ClosingReasonIdOther",new DisplayNameAndFormat { DisplayName ="Closing Reason ID Other"}},
                        {  "OpeningReasonIdOther",new DisplayNameAndFormat { DisplayName ="Opening Reason ID Other"}},
                        {  "RiskCodeOther",new DisplayNameAndFormat { DisplayName ="Risk Code Other"}},
                        {  "EmploymentType",new DisplayNameAndFormat { DisplayName ="Employment Type"}},
                        {  "EmployedOrBusiness",new DisplayNameAndFormat { DisplayName ="Employed Or Business"}},
                        {  "EmployerBusinessName",new DisplayNameAndFormat { DisplayName ="Employer Business Name"}},
                        {  "EmployerBusinessAdrs",new DisplayNameAndFormat { DisplayName ="Employer Business Address"}},
                        {  "EmployerBusinessCity",new DisplayNameAndFormat { DisplayName ="Employer Business City"}},
                        {  "EmployerBusinessCtry",new DisplayNameAndFormat { DisplayName ="Employer Business Country"}},
                        {  "EmployerBusinessState",new DisplayNameAndFormat { DisplayName ="Employer Business State"}},
                        {  "EmployerBusinessTown",new DisplayNameAndFormat { DisplayName ="Employer Business Town"}},
                        {  "EmployerPhone",new DisplayNameAndFormat { DisplayName ="Employer Phone"}},
                        {  "EmployerCountryPhoneCode",new DisplayNameAndFormat { DisplayName ="Employer Country Phone Code"}},
                        {  "Occupation",new DisplayNameAndFormat { DisplayName ="Occupation"}},
                        {  "OccupationDtl",new DisplayNameAndFormat { DisplayName ="Occupation Dtl"}},
                        {  "BusinessSector",new DisplayNameAndFormat { DisplayName ="Business Sector"}},
                        {  "BusinessSectorOthers",new DisplayNameAndFormat { DisplayName ="Business Sector Others"}},
                        {  "PepIndicator",new DisplayNameAndFormat { DisplayName ="PEP Indicator"}},
                        {  "PepIndicatorDtls",new DisplayNameAndFormat { DisplayName ="PEP Indicator Dtls"}},
                        {  "PepIndicatorOth",new DisplayNameAndFormat { DisplayName ="PEP Indicator Other"}},
                        {  "SourceOfIncomeCd",new DisplayNameAndFormat { DisplayName ="Source Of Income CD"}},
                        {  "SourceOfIncomeOther",new DisplayNameAndFormat { DisplayName ="Source Of Income Other"}},
                        {  "AnnualIncomeCd",new DisplayNameAndFormat { DisplayName ="Annual Income CD"}},
                        {  "MonthIncome",new DisplayNameAndFormat { DisplayName ="Month Income"}},
                        {  "IncomeIsoCurrency",new DisplayNameAndFormat { DisplayName ="Income ISO Currency"}},
                        {  "MonthExpense",new DisplayNameAndFormat { DisplayName ="Month Expense"}},
                        {  "ExpenseIsoCurrency",new DisplayNameAndFormat { DisplayName ="Expense ISO Currency"}},
                        {  "HomeCd",new DisplayNameAndFormat { DisplayName ="Home CD"}},
                        {  "TaxRegulationCtryCd1",new DisplayNameAndFormat { DisplayName ="Tax Regulation Country CD1"}},
                        {  "TaxRegulationCtryCd2",new DisplayNameAndFormat { DisplayName ="Tax Regulation Country CD2"}},
                        {  "TaxRegulationCtryCd3",new DisplayNameAndFormat { DisplayName ="Tax Regulation Country CD3"}},
                        {  "TaxRegulationTin1",new DisplayNameAndFormat { DisplayName ="Tax Regulation Tin1"}},
                        {  "TaxRegulationTin2",new DisplayNameAndFormat { DisplayName ="Tax Regulation Tin2"}},
                        {  "TaxRegulationTin3",new DisplayNameAndFormat { DisplayName ="Tax Regulation Tin3"}},
                        {  "RelationToBankCode",new DisplayNameAndFormat { DisplayName ="Relation To Bank Code"}},
                        {  "OtherBankAccounts",new DisplayNameAndFormat { DisplayName ="Other Bank Accounts"}},
                        {  "DealtBankDetails",new DisplayNameAndFormat { DisplayName ="Dealt Bank Details"}},
                        {  "DealAbrdBankDetails",new DisplayNameAndFormat { DisplayName ="Deal Abrd Bank Details"}},
                        {  "BusinessCode",new DisplayNameAndFormat { DisplayName ="Business Code"}},
                        {  "CalculateZakahFlag",new DisplayNameAndFormat { DisplayName ="Calculate Zakah Flag"}},
                        {  "CharityFlag",new DisplayNameAndFormat { DisplayName ="Charity Flag"}},
                        {  "CompanySalesAmountPerYear",new DisplayNameAndFormat { DisplayName ="Company Sales Amount Per Year"}},
                        {  "CustomerStatus",new DisplayNameAndFormat { DisplayName ="Customer Status"}},
                        {  "EconomicMainCode",new DisplayNameAndFormat { DisplayName ="Economic Main Code"}},
                        {  "EconomicSubCode",new DisplayNameAndFormat { DisplayName ="Economic Sub Code"}},
                        {  "GeoCode",new DisplayNameAndFormat { DisplayName ="Geo Code"}},
                        {  "LastQueryDate",new DisplayNameAndFormat { DisplayName ="Last Query Date"}},
                        {  "LegalMainCode",new DisplayNameAndFormat { DisplayName ="Legal Main Code"}},
                        {  "LegalStepDate",new DisplayNameAndFormat { DisplayName ="Legal Step Date"}},
                        {  "LegalStepMainCode",new DisplayNameAndFormat { DisplayName ="Legal Step Main Code"}},
                        {  "LegalStepSubCode",new DisplayNameAndFormat { DisplayName ="Legal Step Sub Code"}},
                        {  "LegalSubCode",new DisplayNameAndFormat { DisplayName ="Legal Sub Code"}},
                        {  "ReferredPersonAddress",new DisplayNameAndFormat { DisplayName ="Referred Person Address"}},
                        {  "ReferredPersonPhone",new DisplayNameAndFormat { DisplayName ="Referred Person Phone"}},
                        {  "SectorAnalysesCode",new DisplayNameAndFormat { DisplayName ="Sector Analyses Code"}},
                        {  "WorthLastCalcDate",new DisplayNameAndFormat { DisplayName ="Worth Last Calcualte Date"}},

                    }
                }
            },
             {
                nameof(ArtKycExpiredIdController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "IdNumber",new DisplayNameAndFormat { DisplayName ="ID Number"}},
                        {  "IdExpireDate",new DisplayNameAndFormat { DisplayName ="ID Expire Date"}},

                    }
                }
            },
             {
                nameof(ArtKycHighExpiredController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycHighOneMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},
                    }
                }
            },
             {
                nameof(ArtKycHighThreeMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                         "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycHighTwoMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycLowExpiredController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycLowOneMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycLowThreeMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycLowTwoMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
            },
             {
                nameof(ArtKycMediumExpiredController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
             },
             {
                nameof(ArtKycMediumOneMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
             },
             {
                nameof(ArtKycMediumThreeMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
             },
             {
                nameof(ArtKycMediumTwoMonthController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                        "Month"
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ClientNumber",new DisplayNameAndFormat { DisplayName ="Client Number"}},
                        {  "EntityName",new DisplayNameAndFormat { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new DisplayNameAndFormat { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new DisplayNameAndFormat { DisplayName ="Next Update Date"}},

                    }
                }
             },
             {
                nameof(ArtKycSummaryByRiskController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "AmlRisk",new DisplayNameAndFormat { DisplayName ="AML Risk"}},
                        {  "Type",new DisplayNameAndFormat { DisplayName ="Type"}},
                        {  "NumberOfUpdatedKyc",new DisplayNameAndFormat { DisplayName ="Number Of Updated KYC"}},
                        {  "NumberOfNotUpdatedKyc",new DisplayNameAndFormat { DisplayName ="Number Of Not Updated KYC"}},
                        {  "Total",new DisplayNameAndFormat { DisplayName ="Total"}},

                    }
                }
             },

             {
                nameof(UserPerformPerActionController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "action",new DisplayNameAndFormat { DisplayName ="Action"}},
                        {  "Total_Number_Of_Cases",new DisplayNameAndFormat { DisplayName ="Total Number Of Cases"}},
                        {  "durations_in_seconds",new DisplayNameAndFormat { DisplayName ="Durations In Seconds"}},
                        {  "AVG_durations_in_seconds",new DisplayNameAndFormat { DisplayName ="AVG Durations In Seconds"}},
                        {  "durations_in_minutes",new DisplayNameAndFormat { DisplayName ="Durations In Minutes"}},
                        {  "AVG_durations_in_minutes",new DisplayNameAndFormat { DisplayName ="AVG Durations In Minutes"}},
                        {  "durations_in_hours",new DisplayNameAndFormat { DisplayName ="Durations In Hours"}},
                        {  "AVG_durations_in_hours",new DisplayNameAndFormat { DisplayName ="AVG Durations In Hours"}},
                        {  "durations_in_days",new DisplayNameAndFormat { DisplayName ="Durations In Days"}},
                        {  "AVG_durations_in_days",new DisplayNameAndFormat { DisplayName ="AVG Durations In Days"}},
                    }
                }
             },
             {
                nameof(UserPerformancePerUserAndActionController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                         {  "ACTION",new DisplayNameAndFormat { DisplayName ="Action"}},
                        {  "ACTION_USER",new DisplayNameAndFormat { DisplayName ="Action User"}},
                        {  "TOTAL_NUMBER_OF_CASES",new DisplayNameAndFormat { DisplayName ="Total Number Of Cases"}},
                        {  "DURATIONS_IN_SECONDS",new DisplayNameAndFormat { DisplayName ="Durations In Seconds"}},
                        {  "AVG_DURATIONS_IN_SECONDS",new DisplayNameAndFormat { DisplayName ="AVG Durations In Seconds"}},
                        {  "DURATIONS_IN_MINUTES",new DisplayNameAndFormat { DisplayName ="Durations In Minutes"}},
                        {  "AVG_DURATIONS_IN_MINUTES",new DisplayNameAndFormat { DisplayName ="AVG Durations In Minutes"}},
                        {  "DURATIONS_IN_HOURS",new DisplayNameAndFormat { DisplayName ="Durations In Hours"}},
                        {  "AVG_DURATIONS_IN_HOURS",new DisplayNameAndFormat { DisplayName ="AVG Durations In Hours"}},
                        {  "DURATIONS_IN_DAYS",new DisplayNameAndFormat { DisplayName ="Durations In Days"}},
                        {  "AVG_DURATIONS_IN_DAYS",new DisplayNameAndFormat { DisplayName ="AVG Durations In Days"}},
                    }
                }
             },
             {
                nameof(UserPerformancePerActionUserController).ToLower(),new ReportConfig{
                    SkipList = new List<string> {
                            },
                    DisplayNames = new Dictionary<string, DisplayNameAndFormat>{
                        {  "ACTION",new DisplayNameAndFormat { DisplayName ="Action"}},
                        {  "ACTION_USER",new DisplayNameAndFormat { DisplayName ="Action User"}},
                        {  "TOTAL_NUMBER_OF_CASES",new DisplayNameAndFormat { DisplayName ="Total Number Of Cases"}},
                        {  "DURATIONS_IN_SECONDS",new DisplayNameAndFormat { DisplayName ="Durations In Seconds"}},
                        {  "AVG_DURATIONS_IN_SECONDS",new DisplayNameAndFormat { DisplayName ="AVG Durations In Seconds"}},
                        {  "DURATIONS_IN_MINUTES",new DisplayNameAndFormat { DisplayName ="Durations In Minutes"}},
                        {  "AVG_DURATIONS_IN_MINUTES",new DisplayNameAndFormat { DisplayName ="AVG Durations In Minutes"}},
                        {  "DURATIONS_IN_HOURS",new DisplayNameAndFormat { DisplayName ="Durations In Hours"}},
                        {  "AVG_DURATIONS_IN_HOURS",new DisplayNameAndFormat { DisplayName ="AVG Durations In Hours"}},
                        {  "DURATIONS_IN_DAYS",new DisplayNameAndFormat { DisplayName ="Durations In Days"}},
                        {  "AVG_DURATIONS_IN_DAYS",new DisplayNameAndFormat { DisplayName ="AVG Durations In Days"}},
                    }
                }
             },
        };

    }
}

