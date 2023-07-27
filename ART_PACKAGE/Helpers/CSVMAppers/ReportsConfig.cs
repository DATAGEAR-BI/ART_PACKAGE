using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportsConfig
    {
        public static readonly Dictionary<string, ReportConfig> CONFIG = new Dictionary<string, ReportConfig>
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
        };

    }
}

