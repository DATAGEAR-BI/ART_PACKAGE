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
        };

    }
}

