using ART_PACKAGE.Controllers.CRP;
using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.DGAUDIT;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Controllers.TRADE_BASE;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.SASAml;
using Data.Data.TRADE_BASE;
using Data.Services.Grid;
using GridAggregateType = Data.Services.Grid.GridAggregateType;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportsConfigm
    {
        public static readonly Dictionary<string, ReportConfig> CONFIG = new()
        {

            //ECM
            { nameof(AlertDetailsController).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                    "Val",
                    "AlertsNotesFlag"
                },
               DisplayNames = new Dictionary<string,GridColumnConfiguration>
            {
                    {"AlertId",new GridColumnConfiguration { DisplayName ="Alert ID"}},
                    {"AlertedEntityName",new GridColumnConfiguration { DisplayName ="Alerted Entity Name"}},
                    {"AlertedEntityNumber",new GridColumnConfiguration { DisplayName ="Alerted Entity Number"}},
                    {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                    {"PartyTypeDesc",new GridColumnConfiguration { DisplayName ="Party Type"}},
                    {"PoliticallyExposedPersonInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                    {"RunDate",new GridColumnConfiguration { DisplayName ="Run Date"}},
                    {"CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                    {"CloseDate",new GridColumnConfiguration { DisplayName ="Closed Date"}},
                    {"MoneyLaunderingRiskScore",new GridColumnConfiguration { DisplayName ="Money Laundering RiskScore"}},
                    {"AlertTypeCd",new GridColumnConfiguration { DisplayName ="Alert Type"}},
                    {"AlertSubCat",new GridColumnConfiguration { DisplayName ="Alert Sub-Category"}},
                    {"AlertStatus",new GridColumnConfiguration { DisplayName ="Alert Status"}},
                    {"AlertDescription",new GridColumnConfiguration { DisplayName ="Alert Description"}},
                    {"ScenarioName",new GridColumnConfiguration { DisplayName ="Scenario Name"}},
                    {"ReportCloseRsn",new GridColumnConfiguration { DisplayName ="Report Close Reason"}},
                    {"ActualValuesText",new GridColumnConfiguration { DisplayName ="Scenario Description"}},
                    {"OwnerUserid",new GridColumnConfiguration { DisplayName ="Owner "}},
                    {"InvestigationDays",new GridColumnConfiguration { DisplayName ="Investigation Days"}}

            }
               }
            },

            { nameof(ArtUserPerformPerUserAndAction).ToLower(), new ReportConfig {

               DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    { "ACTION_USER", new GridColumnConfiguration { DisplayName = "Action User" } },
                    { "ACTION", new GridColumnConfiguration { DisplayName = "Action" } },
                    { "TOTAL_NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Total Number Of Cases" } },
                    { "DURATIONS_IN_SECONDS", new GridColumnConfiguration { DisplayName = "Durations In Seconds" } },
                    { "AVG_DURATIONS_IN_SECONDS", new GridColumnConfiguration { DisplayName = "Avg Durations In Seconds" } },
                    { "DURATIONS_IN_MINUTES", new GridColumnConfiguration { DisplayName = "Durations In Minutes" } },
                    { "AVG_DURATIONS_IN_MINUTES", new GridColumnConfiguration { DisplayName = "Avg Durations In Minutes" } },
                    { "DURATIONS_IN_HOURS", new GridColumnConfiguration { DisplayName = "Durations In Hours" } },
                    { "AVG_DURATIONS_IN_HOURS", new GridColumnConfiguration { DisplayName = "Avg Durations In Hours" } },
                    { "DURATIONS_IN_DAYS", new GridColumnConfiguration { DisplayName = "Durations In Days" } },
                    { "AVG_DURATIONS_IN_DAYS", new GridColumnConfiguration { DisplayName = "Avg Durations In Days" } }
                }
    }
},
            { nameof(ArtUserPerformPerAction).ToLower(), new ReportConfig {

               DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    //{ "ACTION_USER", new GridColumnConfiguration { DisplayName = "Action User" } },
                    { "action", new GridColumnConfiguration { DisplayName = "Action" } },
                    { "Total_Number_Of_Cases", new GridColumnConfiguration { DisplayName = "Total Number Of Cases" } },
                    { "durations_in_seconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds" } },
                    { "AVG_durations_in_seconds", new GridColumnConfiguration { DisplayName = "Avg Durations In Seconds" } },
                    { "durations_in_minutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes" } },
                    { "AVG_durations_in_minutes", new GridColumnConfiguration { DisplayName = "Avg Durations In Minutes" } },
                    { "durations_in_hours", new GridColumnConfiguration { DisplayName = "Durations In Hours" } },
                    { "AVG_durations_in_hours", new GridColumnConfiguration { DisplayName = "Avg Durations In Hours" } },
                    { "durations_in_days", new GridColumnConfiguration { DisplayName = "Durations In Days" } },
                    { "AVG_durations_in_days", new GridColumnConfiguration { DisplayName = "Avg Durations In Days" } }
                }
    }
},

            { nameof(ArtUserPerformancePerActionUser).ToLower(), new ReportConfig {

               DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    { "ACTION_USER", new GridColumnConfiguration { DisplayName = "Action User" } },
                    //{ "ACTION", new GridColumnConfiguration { DisplayName = "Action" } },
                    { "TOTAL_NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Total Number Of Cases" } },
                    { "DURATIONS_IN_SECONDS", new GridColumnConfiguration { DisplayName = "Durations In Seconds" } },
                    { "AVG_DURATIONS_IN_SECONDS", new GridColumnConfiguration { DisplayName = "Avg Durations In Seconds" } },
                    { "DURATIONS_IN_MINUTES", new GridColumnConfiguration { DisplayName = "Durations In Minutes" } },
                    { "AVG_DURATIONS_IN_MINUTES", new GridColumnConfiguration { DisplayName = "Avg Durations In Minutes" } },
                    { "DURATIONS_IN_HOURS", new GridColumnConfiguration { DisplayName = "Durations In Hours" } },
                    { "AVG_DURATIONS_IN_HOURS", new GridColumnConfiguration { DisplayName = "Avg Durations In Hours" } },
                    { "DURATIONS_IN_DAYS", new GridColumnConfiguration { DisplayName = "Durations In Days" } },
                    { "AVG_DURATIONS_IN_DAYS", new GridColumnConfiguration { DisplayName = "Avg Durations In Days" } }
                }
    }
},
            {
    nameof(AlertedEntitiesController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>()
        {


        }
    }
            },
            {
    nameof(SystemPerformanceController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                    { "CaseDesc", new GridColumnConfiguration { DisplayName = "Case Description"}},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                    { "Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                    { "HitsCount", new GridColumnConfiguration { DisplayName = "Hits Count"}},
                    { "TransactionDirection", new GridColumnConfiguration { DisplayName = "Transaction Direction"}},
                    { "TransactionType", new GridColumnConfiguration { DisplayName = "Transaction Type"}},
                    { "TransactionAmount", new GridColumnConfiguration { DisplayName = "Transaction Amount"}},
                    { "TransactionCurrency", new GridColumnConfiguration { DisplayName = "Transaction Currency"}},
                    { "SwiftReference", new GridColumnConfiguration { DisplayName = "Swift Reference"}},
                    { "ClientName", new GridColumnConfiguration { DisplayName = "Party Name"}},
                    { "IdentityNum", new GridColumnConfiguration { DisplayName = "Party Number"}},
                    { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                    { "InvestrUserId", new GridColumnConfiguration { DisplayName = "Investigator"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "UpdateUserId", new GridColumnConfiguration { DisplayName = "Updated By"}},
                    { "EcmLastStatusDate", new GridColumnConfiguration { DisplayName = "Ecm Last Status Date"}},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}},
                    { "NumberOfComment", new GridColumnConfiguration { DisplayName = "Number of Comments"}},
                    { "NumberOfAttachments", new GridColumnConfiguration { DisplayName = "Number Of Attachments"}},
                    { "UpdatedDate", new GridColumnConfiguration { DisplayName = "Updated Date"}},
                    { "CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                    { "LastComment", new GridColumnConfiguration { DisplayName = "Last Comment"}},
                    { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User Id"}},
            },
        SkipList = new List<string>
            {  "CaseRk",
    "ValidFromDate",
    "LastCommentSubject"
            }
    }
            },
            {
    nameof(UserPerformanceController).ToLower(),
                new ReportConfig
                {
                    SkipList = new List<string>() { "CaseRk", "ValidFromDate", "Priority" },
                    DisplayNames = new Dictionary<string, GridColumnConfiguration>
                                                        {
                                                                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                                                                { "CaseTypeCd", new GridColumnConfiguration { DisplayName = "Case Type"}},
                                                                { "CaseDesc", new GridColumnConfiguration { DisplayName = "Case Description"}},
                                                                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                                                                { "Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                                                                { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                                                                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                                                                { "UpdateUserId", new GridColumnConfiguration { DisplayName = "Updated By"}},
                                                                { "AsssignedTime", new GridColumnConfiguration { DisplayName = "Assigned Time"}},
                                                                { "ActionUser", new GridColumnConfiguration { DisplayName = "Action User"}},
                                                                { "Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                                                { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date"}},
                                                                { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                                                                { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                                                                { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                                                                { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}},
                                                                { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User"}},
                                                        }
                }
            }
            ,
            {
    nameof(GOAMLReportsSuspectController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                                 {"Id", new GridColumnConfiguration { DisplayName = "Report ID"}},
                                 {"Reportcode", new GridColumnConfiguration { DisplayName = "Report Type"}},
                                 {"Reportstatuscode", new GridColumnConfiguration { DisplayName = "Report Status"}},
                                 {"Reportcreateddate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                                 {"Transactionnumber", new GridColumnConfiguration { DisplayName = "Transaction Number"}},
                                 {"Submissiondate", new GridColumnConfiguration { DisplayName = "Submission Date"}},
                                 {"Entityreference", new GridColumnConfiguration { DisplayName = "Entity Reference"}},
                                 {"Fiurefnumber", new GridColumnConfiguration { DisplayName = "FUI Reference Number"}},
                                 {"Account", new GridColumnConfiguration { DisplayName = "Account"}},
                                 {"PartyId", new GridColumnConfiguration { DisplayName = "Party ID"}},
                                 {"PartyName", new GridColumnConfiguration { DisplayName = "Party Name"}},
                                 {"Partynumber", new GridColumnConfiguration { DisplayName = "Party Number"}},
                                 {"Activity", new GridColumnConfiguration { DisplayName = "Activity"}},
                                 {"Reportcloseddate", new GridColumnConfiguration { DisplayName = "Close Date"}},
                                 {"Branch", new GridColumnConfiguration { DisplayName = "Branch"}}
                    }
    }
            },
            {
    nameof(GOAMLReportsDetailsController).ToLower(),new ReportConfig
    {
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
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                                 {"Id", new GridColumnConfiguration { DisplayName = "Report ID"}},
                                 {"Reportcode", new GridColumnConfiguration { DisplayName = "Report Type"}},
                                 {"Reportstatuscode", new GridColumnConfiguration { DisplayName = "Report Status"}},
                                 {"Reportcreateddate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                                 {"Submissiondate", new GridColumnConfiguration { DisplayName = "Submission Date"}},
                                 {"Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                                 {"Reportuserlockid", new GridColumnConfiguration { DisplayName = "Locked By"}},
                                 {"Reportcreatedby", new GridColumnConfiguration { DisplayName = "Created By"}},
                                 {"Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                 {"Currencycodelocal", new GridColumnConfiguration { DisplayName = "Currency"}},
                                 {"LastUpdatedDate", new GridColumnConfiguration { DisplayName = "Last Updated Date"}},
                                 {"Entityreference", new GridColumnConfiguration { DisplayName = "Entity Reference"}},
                                 {"Fiurefnumber", new GridColumnConfiguration { DisplayName = "FUI Reference Number"}},
                                 {"Rentitybranch", new GridColumnConfiguration { DisplayName = "Branch"}},
                                 {"Reportingpersontype", new GridColumnConfiguration { DisplayName = "Reporting Person Type"}},
                                 {"Reason", new GridColumnConfiguration { DisplayName = "Reason"}}
                    }
    }
            },
            {
    nameof(GOAMLReportIndicatorDetailsController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                               {"ReportId", new GridColumnConfiguration { DisplayName = "Report ID"}},
                               {"Indicator", new GridColumnConfiguration { DisplayName = "Indicator Code"}},
                               {"Description", new GridColumnConfiguration { DisplayName = "Description"}}
                    }
    }
            },

            {
    nameof(AuditGroupsController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {

                                {"GroupName", new GridColumnConfiguration { DisplayName = "Group Name"}},
                                {"Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                {"Description", new GridColumnConfiguration { DisplayName = "Description"}},
                                {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                                {"CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                                {"CreatedDate", new GridColumnConfiguration { DisplayName = "Created Date"}},
                                {"LastUpdatedBy", new GridColumnConfiguration { DisplayName = "Last Updated By"}},
                                {"LastUpdatedDate", new GridColumnConfiguration { DisplayName = "Last Updated Date"}},
                                {"SubGroupNames", new GridColumnConfiguration { DisplayName = "SubGroup Names"}},
                                {"RoleNames", new GridColumnConfiguration { DisplayName = "Role Names"}},
                                {"MemberUsers", new GridColumnConfiguration { DisplayName = "Member Users"}},

                    }
    }
            },
            {
    nameof(AuditRolesController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {

                                {"RoleName", new GridColumnConfiguration { DisplayName = "Role Name"}},
                                {"Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                {"Description", new GridColumnConfiguration { DisplayName = "Description"}},
                                {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                                {"CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                                {"CreatedDate", new GridColumnConfiguration { DisplayName = "Created Date"}},
                                {"LastUpdatedBy", new GridColumnConfiguration { DisplayName = "Last Updated By"}},
                                {"LastUpdatedDate", new GridColumnConfiguration { DisplayName = "Last Updated Date"}},
                                {"GroupNames", new GridColumnConfiguration { DisplayName = "Group Names"}},
                                {"MemberUsers", new GridColumnConfiguration { DisplayName = "Member Users"}},

                    }
    }
            },
            {
    nameof(AuditUsersController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {

                                {"UserName", new GridColumnConfiguration { DisplayName = "User Name"}},
                                {"Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                {"Address", new GridColumnConfiguration { DisplayName = "Address"}},
                                {"Description", new GridColumnConfiguration { DisplayName = "Description"}},
                                {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                                {"Email", new GridColumnConfiguration { DisplayName = "Email"}},
                                {"Phone", new GridColumnConfiguration { DisplayName = "Phone"}},
                                {"Status", new GridColumnConfiguration { DisplayName = "Status"}},
                                {"CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                                {"CreatedDate", new GridColumnConfiguration { DisplayName = "Created Date"}},
                                {"LastUpdatedBy", new GridColumnConfiguration { DisplayName = "Last Updated By"}},
                                {"LastUpdatedDate", new GridColumnConfiguration { DisplayName = "Last Updated Date"}},
                                {"LastLoginDate", new GridColumnConfiguration { DisplayName = "Last Login Date"}},
                                {"LastFailedLogin", new GridColumnConfiguration { DisplayName = "Last Failed Login"}},
                                {"Enable", new GridColumnConfiguration { DisplayName = "Enable"}},
                                {"GroupNames", new GridColumnConfiguration { DisplayName = "Group Names"}},
                                {"MemberUsers", new GridColumnConfiguration { DisplayName = "Member Users"}},
                                {"DomainAccounts", new GridColumnConfiguration { DisplayName = "Domain Accounts"}}

                    }
    }
            },
            {
    nameof(ListOfUsersRolesController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                               {"UserName", new GridColumnConfiguration { DisplayName = "User Name"}},
                               {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                               {"Email", new GridColumnConfiguration { DisplayName = "Email"}},
                               {"UserRole", new GridColumnConfiguration { DisplayName = "User Role"}},
                    }
    }
            },
            {
    nameof(ListOfUsersGroupController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                               {"UserName", new GridColumnConfiguration { DisplayName = "User Name"}},
                               {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                               {"Email", new GridColumnConfiguration { DisplayName = "Email"}},
                               {"MemberOfGroup", new GridColumnConfiguration { DisplayName = "Member Of Group"}},
                    }
    }
            },
            {
    nameof(ListOfUsersAndGroupsRoleController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                               {"UserName", new GridColumnConfiguration { DisplayName = "User Name"}},
                               {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                               {"Email", new GridColumnConfiguration { DisplayName = "Email"}},
                               {"MemberOfGroup", new GridColumnConfiguration { DisplayName = "Member Of Group"}},
                               {"RoleOfGroup", new GridColumnConfiguration { DisplayName = "Role Of Group"}},
                               {"CreatedDate", new GridColumnConfiguration { DisplayName = "Created Date"}},
                               {"LastLoginDate", new GridColumnConfiguration { DisplayName = "Last Login Date"}},
                               {"AccountStatus", new GridColumnConfiguration { DisplayName = "Account Status"}},
                    }
    }
            },
            {
    nameof(ListGroupsSubGroupsSummaryController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    { nameof(ListGroupsSubGroupsSummary.SubGroupName) , new GridColumnConfiguration { DisplayName =  "Sub Group Name" } },
                    { nameof(ListGroupsRolesSummary.GroupName) , new GridColumnConfiguration { DisplayName =  "Group Name" } }
                        }
    }
            },
            {
    nameof(ListGroupsRolesSummaryController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    { nameof(ListGroupsRolesSummary.RoleName) , new GridColumnConfiguration { DisplayName =  "Role Name" } },
                    { nameof(ListGroupsRolesSummary.GroupName) , new GridColumnConfiguration { DisplayName =  "Group Name" } }
                        }
    }
            },{
    nameof(ListOfGroupsController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {   { nameof(ListOfGroup.GroupName) , new GridColumnConfiguration { DisplayName =  "Group Name" } },
                    { nameof(ListOfGroup.GroupType) , new GridColumnConfiguration { DisplayName =  "Group Type" } },
                    { nameof(ListOfGroup.CreatedBy) , new GridColumnConfiguration { DisplayName =  "Created By" } },
                    { nameof(ListOfGroup.CreatedDate) , new GridColumnConfiguration { DisplayName =  "Created Date" } },
                    { nameof(ListOfGroup.DisplayName) , new GridColumnConfiguration { DisplayName =  "Display Name" } },
                    { nameof(ListOfGroup.LastUpdatedBy) , new GridColumnConfiguration { DisplayName =  "Last Updated By" } },
                    { nameof(ListOfGroup.LastUpdatedDate) , new GridColumnConfiguration { DisplayName =  "Last Updated Date" } }, }
    }
            },
            {
    nameof(ListOfDeletedUsersController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    { nameof(ListOfDeletedUser.UserType) , new GridColumnConfiguration { DisplayName =  "User Type" } },
                    { nameof(ListOfDeletedUser.UserName) , new GridColumnConfiguration { DisplayName =  "User Name" } },
                    { nameof(ListOfDeletedUser.CreatedBy) , new GridColumnConfiguration { DisplayName =  "Created By" } },
                    { nameof(ListOfDeletedUser.CreatedDate) , new GridColumnConfiguration { DisplayName =  "Created Date" } },
                    { nameof(ListOfDeletedUser.DisplayName) , new GridColumnConfiguration { DisplayName =  "Display Name" } },
                    { nameof(ListOfDeletedUser.LastFailedLogin) , new GridColumnConfiguration { DisplayName =  "Last Failed Login" } },
                    { nameof(ListOfDeletedUser.LastLoginDate) , new GridColumnConfiguration { DisplayName =  "Last Login Date" } },
                        }
    }
            },
            {
    nameof(LastLoginPerDayController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                {
                    { nameof(LastLoginPerDayView.AppName) , new GridColumnConfiguration { DisplayName =  "App Name" } },
                    { nameof(LastLoginPerDayView.UserName) , new GridColumnConfiguration { DisplayName =  "User Name" } },
                    { nameof(LastLoginPerDayView.DeviceName) , new GridColumnConfiguration { DisplayName =  "Device Name" } },
                    { nameof(LastLoginPerDayView.DeviceType) , new GridColumnConfiguration { DisplayName =  "Device Type" } },
                    { nameof(LastLoginPerDayView.Logindatetime) , new GridColumnConfiguration { DisplayName =  "Login Date" } }
                        }
    }
            },

            {
    nameof(ListOfUserController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                               {"UserName", new GridColumnConfiguration { DisplayName = "User Name"}},
                               {"Address", new GridColumnConfiguration { DisplayName = "Address"}},
                               {"Description", new GridColumnConfiguration { DisplayName = "Description"}},
                               {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                               {"Email", new GridColumnConfiguration { DisplayName = "Email"}},
                               {"Phone", new GridColumnConfiguration { DisplayName = "Phone"}},
                               {"UserType", new GridColumnConfiguration { DisplayName = "User Type"}},
                               {"CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                               {"CreatedDate", new GridColumnConfiguration { DisplayName = "Created Date"}},
                               {"LastUpdatedBy", new GridColumnConfiguration { DisplayName = "Last Updated By"}},
                               {"LastUpdatedDate", new GridColumnConfiguration { DisplayName = "Last Updated Date"}},
                               {"LastLoginDate", new GridColumnConfiguration { DisplayName = "Last Login Date"}},
                               {"LastFailedLogin", new GridColumnConfiguration { DisplayName = "Last Failed Login"}},
                               {"CounterLock", new GridColumnConfiguration { DisplayName = "Counter Lock"}},
                               {"Active", new GridColumnConfiguration { DisplayName = "Active"}},
                               {"Enable", new GridColumnConfiguration { DisplayName = "Enable"}},
                    }
    }
            },
            {
    nameof(ListOfRoleController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                               {"RoleName", new GridColumnConfiguration { DisplayName = "Role Name"}},
                               {"Description", new GridColumnConfiguration { DisplayName = "Description"}},
                               {"DisplayName", new GridColumnConfiguration { DisplayName = "Display Name"}},
                               {"RoleType", new GridColumnConfiguration { DisplayName = "Role Type"}},
                               {"CreatedDate", new GridColumnConfiguration { DisplayName = "Created Date"}},
                               {"CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                               {"LastUpdatedBy", new GridColumnConfiguration { DisplayName = "Last Updated By"}},
                               {"LastUpdatedDate", new GridColumnConfiguration { DisplayName = "Last Updated Date"}},

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
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                    {"CaseId",new GridColumnConfiguration { DisplayName ="Case ID"}},
                    {"EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                    {"EntityNumber",new GridColumnConfiguration { DisplayName ="Entity Number"}},
                    {"CaseStatus",new GridColumnConfiguration { DisplayName ="Case Status"}},
                    {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                    {"CasePriority",new GridColumnConfiguration { DisplayName ="Case Priority"}},
                    {"CaseCategory",new GridColumnConfiguration { DisplayName ="Case Category"}},
                    {"CaseSubCategory",new GridColumnConfiguration { DisplayName ="Case Sub-Category"}},
                    {"EntityLevel",new GridColumnConfiguration { DisplayName ="Entity Level"}},
                    {"CreatedBy",new GridColumnConfiguration { DisplayName ="Created By"}},
                    {"Owner",new GridColumnConfiguration { DisplayName ="Owner"}},
                    {"CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                    {"ClosedDate",new GridColumnConfiguration { DisplayName ="Closed Date"}}
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
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
                    {
                                  {"CustomerName",new GridColumnConfiguration { DisplayName ="Customer Name"}},
                                  {"CustomerNumber",new GridColumnConfiguration { DisplayName ="Customer Number"}},
                                  {"CustomerSinceDate",new GridColumnConfiguration { DisplayName ="Customer Since Date"}},
                                  {"CustomerType",new GridColumnConfiguration { DisplayName ="Customer Type"}},
                                  {"NonProfitOrgInd",new GridColumnConfiguration { DisplayName ="Non Profit Org Ind"}},
                                  {"PoliticallyExposedPersonInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                                  {"CharityDonationsInd",new GridColumnConfiguration { DisplayName ="Charity Donations Ind"}},
                                  {"RiskClassification",new GridColumnConfiguration { DisplayName ="Risk Classification"}},
                                  {"ResidenceCountryName",new GridColumnConfiguration { DisplayName ="Residence Country"}},
                                  {"CitizenshipCountryName",new GridColumnConfiguration { DisplayName ="Citizenship Country"}},
                                  {"StreetAddress1",new GridColumnConfiguration { DisplayName ="Street Address"}},
                                  {"CityName",new GridColumnConfiguration { DisplayName ="City Name"}},
                                  {"CustomerDateOfBirth",new GridColumnConfiguration { DisplayName ="Customer Date Of Birth"}},
                                  {"OccupationDesc",new GridColumnConfiguration { DisplayName ="Occupation Description"}},
                                  {"MaritalStatusDesc",new GridColumnConfiguration { DisplayName ="Marital Status"}},
                                  {"IndustryDesc",new GridColumnConfiguration { DisplayName ="Industry Description"}},
                                  {"BranchNumber",new GridColumnConfiguration { DisplayName ="Branch Number"}},
                                  {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                                  {"CustomerIdentificationId",new GridColumnConfiguration { DisplayName ="Customer Identification ID"}},
                                  {"CustomerIdentificationType",new GridColumnConfiguration { DisplayName ="Customer Identification Type"}}
                    }
    }
            },

               {
    nameof(HighRiskController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>(),
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                                {"PartyName",new GridColumnConfiguration { DisplayName ="Party Name"}},
                                {"PartyNumber",new GridColumnConfiguration { DisplayName ="Party Number"}},
                                {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                                {"BranchNumber",new GridColumnConfiguration { DisplayName ="Branch Number"}},
                                {"PartyDateOfBirth",new GridColumnConfiguration { DisplayName ="Party Date Of Birth", Format =  "{0:MMM/dd/yyyy}"}},
                                {"PartyIdentificationId",new GridColumnConfiguration { DisplayName ="Party Identification ID"}},
                                {"PhoneNumber1",new GridColumnConfiguration { DisplayName ="Phone Number"}},
                                {"PartyTaxId",new GridColumnConfiguration { DisplayName ="Party Tax ID"}},
                                {"MailingAddress1",new GridColumnConfiguration { DisplayName ="Mailing Address"}},
                                {"StreetAddress1",new GridColumnConfiguration { DisplayName ="Street Address"}},
                                {"StreetCityName",new GridColumnConfiguration { DisplayName ="Street City Name"}},
                                {"ResidenceCountryName",new GridColumnConfiguration { DisplayName ="Residence Country"}},
                                {"CitizenshipCountryName",new GridColumnConfiguration { DisplayName ="Citizenship Country"}},
                                {"PartyIdentificationTypeDesc",new GridColumnConfiguration { DisplayName ="Party Identification Type"}},
                                {"PoliticallyExposedPersonInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                                {"PartyTypeDesc",new GridColumnConfiguration { DisplayName ="Party Type"}},
                                {"RiskClassification",new GridColumnConfiguration { DisplayName ="Risk Classification"}},
                                {"MailingCityName",new GridColumnConfiguration { DisplayName ="Mailing City Name"}}
                    }
    }
            },
               {
    nameof(RiskAssessmentController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>{
                        "RiskAssessmentDuration",
                        "VersionNumber",
                        "AssessmentCategoryCd",
                        "AssessmentSubcategoryCd",
                    },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {"CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                        {"PartyNumber",new GridColumnConfiguration { DisplayName ="Party Number"}},
                        {"PartyName",new GridColumnConfiguration { DisplayName ="Party Name"}},
                        {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {"AssessmentTypeCd",new GridColumnConfiguration { DisplayName ="Assessment Type"}},
                        {"RiskAssessmentId",new GridColumnConfiguration { DisplayName ="Risk Assessment ID"}},
                        {"OwnerUserLongId",new GridColumnConfiguration { DisplayName ="Owner"}},
                        {"CreateUserId",new GridColumnConfiguration { DisplayName ="Create By"}},
                        {"RiskStatus",new GridColumnConfiguration { DisplayName ="Risk Status"}},
                        {"RiskClass",new GridColumnConfiguration { DisplayName ="Risk Classification"}},
                        {"ProposedRiskClass",new GridColumnConfiguration { DisplayName ="Proposed Risk Classification"}}
                    }
    }
            },
                {
    nameof(TriageController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                                "AlertedEntityLevel"
                                //"Outstamt",
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "AlertedEntityName",new GridColumnConfiguration { DisplayName ="Alerted Entity Name"}},
                        {  "AlertedEntityNumber",new GridColumnConfiguration { DisplayName ="Alerted Entity Number"}},
                        {  "BranchNumber",new GridColumnConfiguration { DisplayName ="Branch Number"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {  "RiskScore",new GridColumnConfiguration { DisplayName ="Risk Score"}},
                        {  "OwnerUserid",new GridColumnConfiguration { DisplayName ="Owner"}},
                        {  "AggregateAmt",new GridColumnConfiguration { DisplayName ="Aggregate Amount"}},
                        {  "AgeOldestAlert",new GridColumnConfiguration { DisplayName ="Alert Age"}},
                        {  "AlertsCntSum",new GridColumnConfiguration { DisplayName ="Alerts Count"}},

                    }
    }
            },
            {
    nameof(DGAMLArtExternalCustomerDetailsController).ToLower(),new ReportConfig
    {
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
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "CustomerName",new GridColumnConfiguration { DisplayName ="Customer Name"}},
                        {  "CustomerNumber",new GridColumnConfiguration { DisplayName ="Customer Number"}},
                        {  "CustomerType",new GridColumnConfiguration { DisplayName ="Customer Type"}},
                        {  "CustomerIdentificationId",new GridColumnConfiguration { DisplayName ="Customer Identification ID"}},
                        {  "CustomerIdentificationType",new GridColumnConfiguration { DisplayName ="Customer Identification Type"}},
                        {  "CustomerDateOfBirth",new GridColumnConfiguration { DisplayName ="Customer Date Of Birth"}},
                        {  "StreetAddress1",new GridColumnConfiguration { DisplayName ="Street Address"}},
                        {  "CityName",new GridColumnConfiguration { DisplayName ="City Name"}},
                        {  "ResidenceCountryName",new GridColumnConfiguration { DisplayName = "Residence Country"}},
                        {  "CitizenshipCountryName",new GridColumnConfiguration { DisplayName ="Citizenship Country"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},

                    }
    }
            },
            {
    nameof(DGAMLArtScenarioAdminController).ToLower(),new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ScenarioName",new GridColumnConfiguration { DisplayName ="Name"}},
                        {  "ScenarioShortDesc",new GridColumnConfiguration { DisplayName ="Short Description"}},
                        {  "ScenarioDesc",new GridColumnConfiguration { DisplayName ="Scenario Description"}},
                        {  "ScenarioStatus",new GridColumnConfiguration { DisplayName ="Scenario Status"}},
                        {  "ScenarioCategory",new GridColumnConfiguration { DisplayName ="Scenario Category"}},
                        {  "ProductType",new GridColumnConfiguration { DisplayName ="Product Type"}},
                        {  "RiskFact",new GridColumnConfiguration { DisplayName ="Risk Fact"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                        {  "EndDate",new GridColumnConfiguration { DisplayName ="End Date"}},
                        {  "CreateUserId",new GridColumnConfiguration { DisplayName ="Create User ID"}},
                        {  "ScenarioType",new GridColumnConfiguration { DisplayName = "Scenario Type"}},
                        {  "ScenarioFrequency",new GridColumnConfiguration { DisplayName ="Scenario Frequency"}},
                        {  "ScenarioMessage",new GridColumnConfiguration { DisplayName ="Scenario Message"}},
                        {  "ObjectLevel",new GridColumnConfiguration { DisplayName ="Object Level"}},
                        {  "AlarmType",new GridColumnConfiguration { DisplayName ="Alarm Type"}},
                        {  "AlarmCategory",new GridColumnConfiguration { DisplayName ="Alarm Category"}},
                        {  "AlarmSubcategory",new GridColumnConfiguration { DisplayName ="Alarm Subcategory"}},
                        {  "DependedData",new GridColumnConfiguration { DisplayName ="Depended Data"}},
                        {  "ParmName",new GridColumnConfiguration { DisplayName ="Parameter Name"}},
                        {  "ParmValue",new GridColumnConfiguration { DisplayName ="Parameter Value"}},
                        {  "ParmDesc",new GridColumnConfiguration { DisplayName ="Parameter Desc"}},
                        {  "ParmTypeDesc",new GridColumnConfiguration { DisplayName ="Parameter Type Desc"}},
                        {  "ParamCondition",new GridColumnConfiguration { DisplayName ="Parameter Condition"}},
                        {  "ScorParmName",new GridColumnConfiguration { DisplayName ="Score Parameter Name"}},
                        {  "ScorDependAttribute",new GridColumnConfiguration { DisplayName ="Score Depend Attribute"}},

                    }
    }
            },
            {
    nameof(DGAMLArtScenarioHistoryController).ToLower(),new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "RoutineName",new GridColumnConfiguration { DisplayName ="Scenario Name"}},
                        {  "RoutineShortDesc",new GridColumnConfiguration { DisplayName ="Scenario Short Description"}},
                        {  "EventDesc",new GridColumnConfiguration { DisplayName ="Event Description"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                        {  "CreateUserId",new GridColumnConfiguration { DisplayName ="Create User Id"}},
                    }
    }
            },
            {
    nameof(DGAMLArtSuspectDetailsController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>()
                    {
                        "CustIdentExpDate",
                        "CustIdentIssDate",
                        "EmprName",
                        "TelNo1"
                    },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "SuspectNumber",new GridColumnConfiguration { DisplayName ="Suspect Number"}},
                        {  "SuspectName",new GridColumnConfiguration { DisplayName ="Suspect Name"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {  "ProfileRisk",new GridColumnConfiguration { DisplayName ="Profile Risk"}},
                        {  "NumberOfAlarms",new GridColumnConfiguration { DisplayName ="Number Of Alerts"}},
                        {  "AgeOfOldestAlert",new GridColumnConfiguration { DisplayName ="Age Of Oldest Alert"}},
                        {  "OwnerUserId",new GridColumnConfiguration { DisplayName ="Owner User Id"}},
                        {  "CustBirthDate",new GridColumnConfiguration { DisplayName ="Customer Birth Of Date"}},
                        {  "PoliticalExpPrsnInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                        {  "RiskClassification",new GridColumnConfiguration { DisplayName ="Risk Classification"}},
                        {  "CitizenCntryName",new GridColumnConfiguration { DisplayName ="Citizenship Country"}},
                        {  "CustIdentId",new GridColumnConfiguration { DisplayName ="Customer Identification ID"}},
                        {  "CustIdentTypeDesc",new GridColumnConfiguration { DisplayName ="Customer Identification Type"}},
                        {  "OccupDesc",new GridColumnConfiguration { DisplayName ="Occupation Description"}},
                        {  "CustSinceDate",new GridColumnConfiguration { DisplayName ="Customer Since Date"}},
                    }
    }
            },
            {
    nameof(DGAMLTriageController).ToLower(),new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "AlertedEntityName",new GridColumnConfiguration { DisplayName ="Alerted Entity Name"}},
                        {  "AlertedEntityNumber",new GridColumnConfiguration { DisplayName ="Alerted Entity Number"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {  "RiskScore",new GridColumnConfiguration { DisplayName ="Risk Score"}},
                        {  "QueueCode",new GridColumnConfiguration { DisplayName ="Queue Code"}},
                        {  "OwnerUserid",new GridColumnConfiguration { DisplayName ="Owner User ID"}},
                        {  "AlertedEntityLevel",new GridColumnConfiguration { DisplayName ="Alerted Entity Level"}},
                        {  "AggregateAmt",new GridColumnConfiguration { DisplayName ="Aggregate Amount"}},
                        {  "AgeOldestAlert",new GridColumnConfiguration { DisplayName ="Age Oldest Alert"}},
                        {  "AlertsCntSum",new GridColumnConfiguration { DisplayName ="Alerts Count Sum"}},
                    }
    }
            },
            {
    nameof(DGAMLAlertDetailsController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>()
                    {
                        "ActualValuesText"
                    },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "AlarmId",new GridColumnConfiguration { DisplayName ="Alert ID"}},
                        {  "AlertedEntityNumber",new GridColumnConfiguration { DisplayName ="Alerted Entity Number"}},
                        {  "AlertedEntityName",new GridColumnConfiguration { DisplayName ="Alerted Entity Name"}},
                        {  "AlertDescription",new GridColumnConfiguration { DisplayName ="Alert Description"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {  "ScenarioId",new GridColumnConfiguration { DisplayName ="Scenario ID"}},
                        {  "ScenarioName",new GridColumnConfiguration { DisplayName ="Scenario Name"}},
                        {  "MoneyLaunderingRiskScore",new GridColumnConfiguration { DisplayName ="Money Laundering Risk Score"}},
                        {  "AlertCategory",new GridColumnConfiguration { DisplayName ="Alert Category"}},
                        {  "AlertSubcategory",new GridColumnConfiguration { DisplayName ="Alert Sub Category"}},
                        {  "AlertStatus",new GridColumnConfiguration { DisplayName ="Alert Status"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                        {  "RunDate",new GridColumnConfiguration { DisplayName ="Run Date"}},
                        {  "PoliticallyExposedPersonInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                        {  "EmpInd",new GridColumnConfiguration { DisplayName ="Emp Indication"}},
                        {  "ClosedUserId",new GridColumnConfiguration { DisplayName ="Closed User ID"}},
                        {  "CloseUserName",new GridColumnConfiguration { DisplayName ="Close User Name"}},
                        {  "CloseDate",new GridColumnConfiguration { DisplayName ="Close Date"}},
                        {  "CloseReason",new GridColumnConfiguration { DisplayName ="Close Reason"}},
                        {  "InvestigationDays",new GridColumnConfiguration { DisplayName ="Investigation Days"}},
                    }
    }
            },
            {
    nameof(DGAMLCasesDetailsController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>()
                    {
                        "CaseStatusCode",
                        "CaseCategoryCode",
                        "CaseSubCategoryCode"
                    },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "CaseId",new GridColumnConfiguration { DisplayName ="Case ID"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "EntityNumber",new GridColumnConfiguration { DisplayName ="Entity Number"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                        {  "CasePriority",new GridColumnConfiguration { DisplayName ="Case Priority"}},
                        {  "CaseStatus",new GridColumnConfiguration { DisplayName ="Case Status"}},
                        {  "CaseCategory",new GridColumnConfiguration { DisplayName ="Case Category"}},
                        {  "EntityLevel",new GridColumnConfiguration { DisplayName ="Entity Level"}},
                        {  "CreatedBy",new GridColumnConfiguration { DisplayName ="Created By"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                    }
    }
            },
            {
    nameof(DGAMLCustomersDetailsController).ToLower(),new ReportConfig
    {
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
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "CustomerName",new GridColumnConfiguration { DisplayName ="Customer Name"}},
                        {  "CustomerNumber",new GridColumnConfiguration { DisplayName ="Customer Number"}},
                        {  "CustomerType",new GridColumnConfiguration { DisplayName ="Customer Type"}},
                        {  "CustomerIdentificationId",new GridColumnConfiguration { DisplayName ="Customer Identification ID"}},
                        {  "CustomerIdentificationType",new GridColumnConfiguration { DisplayName ="Customer Identification Type"}},
                        {  "CustomerDateOfBirth",new GridColumnConfiguration { DisplayName ="Customer Date Of Birth"}},
                        {  "RiskClassification",new GridColumnConfiguration { DisplayName ="Risk Classification"}},
                        {  "StreetAddress1",new GridColumnConfiguration { DisplayName ="Street Address"}},
                        {  "CityName",new GridColumnConfiguration { DisplayName ="City Name"}},
                        {  "ResidenceCountryName",new GridColumnConfiguration { DisplayName = "Residence Country"}},
                        {  "CitizenshipCountryName",new GridColumnConfiguration { DisplayName ="Citizenship Country"}},
                        {  "OccupationDesc",new GridColumnConfiguration { DisplayName ="Occupation Description"}},
                        {  "IndustryDesc",new GridColumnConfiguration { DisplayName ="Industry Description"}},
                        {  "MaritalStatusDesc",new GridColumnConfiguration { DisplayName ="Marital Status"}},
                        {  "CustomerSinceDate",new GridColumnConfiguration { DisplayName ="Customer Since Date"}},
                        {  "NonProfitOrgInd",new GridColumnConfiguration { DisplayName ="Non Profit Org IND"}},
                        {  "PoliticallyExposedPersonInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                        {  "BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},

                    }
    }
            },



                        {
    nameof(ACPostingsAccountController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    //Customer/System Parameter/Charge Code
                {"EventRef",            new GridColumnConfiguration { DisplayName = "Event Reference"}},
                {"MasterRef",           new GridColumnConfiguration { DisplayName = "Master Reference"}},
                {"AcctNo",              new GridColumnConfiguration { DisplayName = "Account Number"}},
                {"AccountType",         new GridColumnConfiguration { DisplayName = "Account Type"}},
                {"Shortname",           new GridColumnConfiguration { DisplayName = "Short Name"}},
                {"DrCrFlg",             new GridColumnConfiguration { DisplayName = "Dr/Cr"}},
                {"PostAmount",          new GridColumnConfiguration { DisplayName = "Amount",Format = "{0:n2}"}},
                {"Ccy",                 new GridColumnConfiguration { DisplayName = "Currency"}},
                {"PostAmountEgp",       new GridColumnConfiguration { DisplayName = "Amount Egp",Format = "{0:n2}"}},
                {"Valuedate",           new GridColumnConfiguration { DisplayName = "Value Date" , Format="{0:dd/MM/yyyy}"}},
                {"CusMnm",              new GridColumnConfiguration { DisplayName = "CusMnm"}},
                {"Spsk",                new GridColumnConfiguration { DisplayName = "Customer/System Parameter/Charge Code"}},
                {"Mainbanking",         new GridColumnConfiguration { DisplayName = "Main Banking Entity"}},
                {"BranchName",          new GridColumnConfiguration { DisplayName = "Branch Name"}},
            },
        SkipList = new List<string> { }
    }
            },
            {
    nameof(ACPostingsCustomersController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"EventRef",            new GridColumnConfiguration { DisplayName = "Event Reference"}},
                {"MasterRef",           new GridColumnConfiguration { DisplayName = "Master Reference"}},
                {"AcctNo",              new GridColumnConfiguration { DisplayName = "Account Number"}},
                {"AccountType",         new GridColumnConfiguration { DisplayName = "Account Type"}},
                {"Shortname",           new GridColumnConfiguration { DisplayName = "Short Name"}},
                {"DrCrFlg",             new GridColumnConfiguration { DisplayName = "Dr/Cr"}},
                {"PostAmount",          new GridColumnConfiguration { DisplayName = "Amount",Format = "{0:n2}"}},
                {"Ccy",                 new GridColumnConfiguration { DisplayName = "Currency"}},
                {"PostAmountEgp",       new GridColumnConfiguration { DisplayName = "Amount Egp",Format = "{0:n2}"}},
                {"Valuedate",           new GridColumnConfiguration { DisplayName = "Value Date" , Format = "{0:dd/MM/yyyy}"}},
                {"CusMnm",              new GridColumnConfiguration { DisplayName = "CusMnm"}},
                {"Spsk",                new GridColumnConfiguration { DisplayName = "Customer/System Parameter/Charge Code"}},
                {"Mainbanking",         new GridColumnConfiguration { DisplayName = "Main Banking Entity"}},
                {"BranchName",          new GridColumnConfiguration { DisplayName = "Branch Name"}},
            },
        SkipList = new List<string>
        {

        }
    }
            },
            {
    nameof(ActivityController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                {"Team",new GridColumnConfiguration { DisplayName ="Team"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"Sovalue",new GridColumnConfiguration { DisplayName ="Product"}},
                {"EventRef",new GridColumnConfiguration { DisplayName ="Event Reference"}},
                {"EventStatus",new GridColumnConfiguration { DisplayName ="Event Status"}},
                {"StartDate",new GridColumnConfiguration { DisplayName ="Event Start Date" ,Format = "{0:dd/MM/yyyy}"}},
                {"StartTime",new GridColumnConfiguration { DisplayName ="Event Start Time"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Principal Party"}},
                {"Address12",new GridColumnConfiguration { DisplayName ="Non principal Party"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Event Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Amount Egp",Format = "{0:n2}"}},
                {"Lstmoduser",new GridColumnConfiguration { DisplayName ="User ID"}},
                {"Shortname",new GridColumnConfiguration { DisplayName ="Event"}},


                {"Product",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Touched",new GridColumnConfiguration { DisplayName ="Touched"}},
                {"Relmstrref",new GridColumnConfiguration { DisplayName ="Relmstrref"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"Gfcun12",new GridColumnConfiguration { DisplayName ="Gfcun12"}},
                {"CusMnm12",new GridColumnConfiguration { DisplayName ="CusMnm12"}},
                {"SwBank12",new GridColumnConfiguration { DisplayName ="SwBank12"}},
                {"SwCtr12",new GridColumnConfiguration { DisplayName ="SwCtr12"}},
                {"SwLoc12",new GridColumnConfiguration { DisplayName ="SwLoc12"}},
                {"SwBranch12",new GridColumnConfiguration { DisplayName ="SwBranch12"}},
                {"CcyCed",new GridColumnConfiguration { DisplayName ="CcyCed"}},
                {"Relmstrref12",new GridColumnConfiguration { DisplayName ="Relmstrref12"}},
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"Started",new GridColumnConfiguration { DisplayName ="Started"}},
                {"StartedFilter",new GridColumnConfiguration { DisplayName ="StartedFilter"}},
                {"Language",new GridColumnConfiguration { DisplayName ="Language"}},
                {"BaseStatus",new GridColumnConfiguration { DisplayName ="BaseStatus"}},
                {"Stepdescr",new GridColumnConfiguration { DisplayName ="Stepdescr"}},
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
            {
    nameof(AmortizationController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>(),
        SkipList = new List<string>()
    }
            },
            {
    nameof(OurChargesByCustomerController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Hvbad1",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Charge Party" }},
                {"Longname",new GridColumnConfiguration { DisplayName ="Product"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"TotoalPeriodicBilledChgDue",new GridColumnConfiguration { DisplayName ="Periodic/Billed"}},
                {"TotoalBilledChgDue",new GridColumnConfiguration { DisplayName ="Billed"}},
                {"TotoalPaidChgDue",new GridColumnConfiguration { DisplayName ="Paid",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
                {"TotoalClaimedChgDue",new GridColumnConfiguration { DisplayName ="Claimed",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
                {"TotoalOutstandingChgDue",new GridColumnConfiguration { DisplayName ="Outstanding",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
                {"TotoalWaivedChgDue",new GridColumnConfiguration { DisplayName ="Waived",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
             },
        SkipList = new List<string>
        {

        }
    }
            },
            {
    nameof(OurChargesByMasterController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
               {"Hvbad1",new GridColumnConfiguration { DisplayName ="Branch"}},
               {"Longname",new GridColumnConfiguration { DisplayName ="Product"}},
               {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
               {"TotoalPeriodicBilledChgDue",new GridColumnConfiguration { DisplayName ="Periodic/Billed"}},
               {"TotoalBilledChgDue",new GridColumnConfiguration { DisplayName ="Billed"}},
               {"TotoalPaidChgDue",new GridColumnConfiguration { DisplayName ="Paid",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
               {"TotoalClaimedChgDue",new GridColumnConfiguration { DisplayName ="Claimed",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
               {"TotoalOutstandingChgDue",new GridColumnConfiguration { DisplayName ="Outstanding",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
               {"TotoalWaivedChgDue",new GridColumnConfiguration { DisplayName ="Waived",Format = "{0:n2}",AggType=GridAggregateType.sum , AggText = "TotalCharges  "}},
            },
        SkipList = new List<string>
        {

        }
    }
            },
            {
    nameof(OurChargesDetailsController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Hvbad1",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Longname",new GridColumnConfiguration { DisplayName ="Product"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Customer"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Status"}},
                {"Descr",new GridColumnConfiguration { DisplayName ="Type"}},
                {"ParticChg",new GridColumnConfiguration { DisplayName ="Share with Principal"}},
                {"EventRef",new GridColumnConfiguration { DisplayName ="Event Reference"}},
                {"Action",new GridColumnConfiguration { DisplayName ="Action"}},
                {"CgbasAmt",new GridColumnConfiguration { DisplayName ="Basis Amount",Format = "{0:n2}"}},
                {"ChgbasCcy",new GridColumnConfiguration { DisplayName ="Basis Amount Currency"}},
                {"ChgbasAmtEgp",new GridColumnConfiguration { DisplayName ="Basis Amount EGP",Format = "{0:n2}"}},
                {"SchAmt",new GridColumnConfiguration { DisplayName ="Charge Amount",Format = "{0:n2}"}},
                {"SchCcy",new GridColumnConfiguration { DisplayName ="Charge Amount Currency"}},
                {"SchAmtEgp",new GridColumnConfiguration { DisplayName ="Charge Amount EGP",Format = "{0:n2}"}},
                {"SchRate",new GridColumnConfiguration { DisplayName ="Rate"}},
                {"ChgDue",new GridColumnConfiguration { DisplayName ="Amount to Collect",Format = "{0:n2}"}},
                {"ChgCcy",new GridColumnConfiguration { DisplayName ="Amount to Collect Currency"}},
                {"ChgDueEgp",new GridColumnConfiguration { DisplayName ="Amount to Collect EGP",Format = "{0:n2}"}},

                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"Reduction",new GridColumnConfiguration { DisplayName ="Reduction"}},
                {"TaxAmt",new GridColumnConfiguration { DisplayName ="TaxAmt"}},
                {"TaxCcy",new GridColumnConfiguration { DisplayName ="TaxCcy"}},
                {"TaxFor",new GridColumnConfiguration { DisplayName ="TaxFor"}},
                {"RefnoPfix1",new GridColumnConfiguration { DisplayName ="RefnoPfix1"}},
                {"RefnoSerl1",new GridColumnConfiguration { DisplayName ="RefnoSerl1"}},
                {"StartDate",new GridColumnConfiguration { DisplayName ="StartDate"}},
                {"StartTime",new GridColumnConfiguration { DisplayName ="StartTime"}},
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"SchCcySpt",new GridColumnConfiguration { DisplayName ="SchCcySpt"}},
                {"SchCcySei",new GridColumnConfiguration { DisplayName ="SchCcySei"}},
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
            {
    nameof(DiaryExceptionsController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"Sovaluedesc",new GridColumnConfiguration { DisplayName ="Product Name"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Principal"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Status"}},
                {"BranchCode",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Full Name"}},
                {"Team",new GridColumnConfiguration { DisplayName ="Team"}},
                {"CtrctDate",new GridColumnConfiguration { DisplayName ="Ctrct Date"}},
                {"Outstamt",new GridColumnConfiguration { DisplayName ="Outstamt"}},
                {"Outccyced",new GridColumnConfiguration { DisplayName ="Outccyced"}},
                {"Outstccy",new GridColumnConfiguration { DisplayName ="Outstccy"}},
                {"OutstamtEgp",new GridColumnConfiguration { DisplayName ="OutstamtEgp"}},
                {"Relmstrref",new GridColumnConfiguration { DisplayName ="Relmstrref"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Amount Egp",Format = "{0:n2}"}},
                {"CreatedAt",new GridColumnConfiguration { DisplayName ="CreatedAt"}},
                {"NoteText",new GridColumnConfiguration { DisplayName ="Reason"}},
                {"RefnoPfix",new GridColumnConfiguration { DisplayName ="RefnoPfix"}},
                {"RefnoSerl",new GridColumnConfiguration { DisplayName ="RefnoSerl"}},
                {"ExpiryDat",new GridColumnConfiguration { DisplayName ="Expiry Date"}},
                {"CcyCed",new GridColumnConfiguration { DisplayName ="CcyCed"}},

                {"Sovaluecode",new GridColumnConfiguration { DisplayName ="Sovaluecode"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"Active",new GridColumnConfiguration { DisplayName ="Active"}},
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
            {
    nameof(EcmTransactionsController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{

                {"CaseId",new GridColumnConfiguration { DisplayName ="EcmReference"}},
                {"Behalfofbranch",new GridColumnConfiguration { DisplayName ="Branch ID"}},
                {"CreateDate",new GridColumnConfiguration { DisplayName ="Case Creation Date"}},
                {"Applicantname",new GridColumnConfiguration { DisplayName ="Customer Name"}},
                {"Product",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Producttype",new GridColumnConfiguration { DisplayName ="Product Type"}},
                {"Eventname",new GridColumnConfiguration { DisplayName ="Event"}},
                {"TransactionAmount",new GridColumnConfiguration { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"TransactionCurrency",new GridColumnConfiguration { DisplayName ="Transaction Currency"}},
                {"PrimaryOwner",new GridColumnConfiguration { DisplayName ="Primary Owner"}},
                {"CaseStatCd",new GridColumnConfiguration { DisplayName ="Case Status"}},
                {"UpdateUserId",new GridColumnConfiguration { DisplayName ="Last Action taken by"}}
            }
            ,
        SkipList = new List<string>
        {

        }
    }
            },
            {
    nameof(InterfaceDetailsController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"CorrelationId",new GridColumnConfiguration { DisplayName ="Correlation ID"}},
                {"DrSeq",new GridColumnConfiguration { DisplayName ="Dr Seq"}},
                {"CrSeq",new GridColumnConfiguration { DisplayName ="Cr Seq"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Status"}},
                {"Error",new GridColumnConfiguration { DisplayName ="Error"}},
                {"Xref",new GridColumnConfiguration { DisplayName ="X Reference"}},
                {"MstRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"EvtRef",new GridColumnConfiguration { DisplayName ="Event Reference"}},
                {"ValueDate",new GridColumnConfiguration { DisplayName ="Value Date"        ,Format = "{0:dd/MM/yyyy}"       }},
                {"FromType",new GridColumnConfiguration { DisplayName ="From Type"}},
                {"ToType",new GridColumnConfiguration { DisplayName ="To Type"}},
                {"FromCcy",new GridColumnConfiguration { DisplayName ="From Ccy"}},
                {"ToCcy",new GridColumnConfiguration { DisplayName ="To Ccy"}},
                {"FromAmount",new GridColumnConfiguration { DisplayName ="From Amount",Format = "{0:n2}"}},
                {"ToAmount",new GridColumnConfiguration { DisplayName ="To Amount",Format = "{0:n2}"}},
                {"FromAccount",new GridColumnConfiguration { DisplayName ="From Account"}},
                {"ToAccount",new GridColumnConfiguration { DisplayName ="To Account"}},
                {"FromBranch",new GridColumnConfiguration { DisplayName ="From Branch"}},
                {"ToBranch",new GridColumnConfiguration { DisplayName ="To Branch"}},
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
            {
    nameof(MasterEventHistoryController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                   {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"Shortname",new GridColumnConfiguration { DisplayName ="Event"}},
                {"EventRef",new GridColumnConfiguration { DisplayName ="Event Reference"}},
                {"Stepdescr",new GridColumnConfiguration { DisplayName ="Event Steps"}},
                {"StartedFilter",new GridColumnConfiguration { DisplayName ="Event Start Date"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Master Status"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Principal Name"}},
                {"StatusEv",new GridColumnConfiguration { DisplayName ="Action"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Amount Egp" ,Format = "{0:n2}"}},
                {"Bookoffdat",new GridColumnConfiguration { DisplayName ="Book Off Date"}},
                {"ExpiryDat",new GridColumnConfiguration { DisplayName ="Expiry Date"}},
                {"DeactDate",new GridColumnConfiguration { DisplayName ="Deactivation Date"}},

                {"Product",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Outstamt",new GridColumnConfiguration { DisplayName ="Outstamt"}},
                {"Outstccy",new GridColumnConfiguration { DisplayName ="Outstccy"}},
                {"OutstamtEgp",new GridColumnConfiguration { DisplayName ="OutstamtEgp"}},
                {"Started",new GridColumnConfiguration { DisplayName ="Started"}},
                {"CrossRef",new GridColumnConfiguration { DisplayName ="CrossRef"}},
                {"StepStatus",new GridColumnConfiguration { DisplayName ="StepStatus"}},
                {"BranchCode",new GridColumnConfiguration { DisplayName ="BranchCode"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"Team",new GridColumnConfiguration { DisplayName ="Team"}},
                {"Extrainfo",new GridColumnConfiguration { DisplayName ="Extrainfo"}},
                {"Language",new GridColumnConfiguration { DisplayName ="Language"}},
                {"Isfinished",new GridColumnConfiguration { DisplayName ="Isfinished"}},
                {"Stepkey",new GridColumnConfiguration { DisplayName ="Stepkey"}},
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
             {
    nameof(OSLiabilityController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Customer"}},
                {"Sovalue",new GridColumnConfiguration { DisplayName ="Product"}},
                {"LiabCcy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"Totliabamt",new GridColumnConfiguration { DisplayName ="Total Per Customer",Format = "{0:n2}"}},
                {"TotliabamtEgp",new GridColumnConfiguration { DisplayName ="Total Per Customer Egp",Format = "{0:n2}"}},
            },
        SkipList = new List<string>
        {

        }
    }
            },
             {
    nameof(OSTransactionsAwaitiApprlController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Fullname",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Descri56",new GridColumnConfiguration { DisplayName ="Team"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"EventReference",new GridColumnConfiguration { DisplayName ="Event Reference"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Event Status"}},
                {"Started",new GridColumnConfiguration { DisplayName ="Event Started"}},
                {"PcpAddress1",new GridColumnConfiguration { DisplayName ="Principal Party"}},
                {"Touched",new GridColumnConfiguration { DisplayName ="Last Amended"}},
                {"NpcpAddress1",new GridColumnConfiguration { DisplayName ="Non Principal Party"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Amount Egp",Format = "{0:n2}"}},
                {"Lstmoduser",new GridColumnConfiguration { DisplayName ="User ID"}},

                {"RefnoPfix",new GridColumnConfiguration { DisplayName ="RefnoPfix"}},
                {"RefnoSerl",new GridColumnConfiguration { DisplayName ="RefnoSerl"}},
                {"Workgroup",new GridColumnConfiguration { DisplayName ="Workgroup"}},
                {"CcyCed",new GridColumnConfiguration { DisplayName ="CcyCed"}},
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"PcpGfcun",new GridColumnConfiguration { DisplayName ="PcpGfcun"}},
                {"PcpCusMnm",new GridColumnConfiguration { DisplayName ="PcpCusMnm"}},
                {"PcpSwBank",new GridColumnConfiguration { DisplayName ="PcpSwBank"}},
                {"PcpSwCtr",new GridColumnConfiguration { DisplayName ="PcpSwCtr"}},
                {"PcpSwLoc",new GridColumnConfiguration { DisplayName ="PcpSwLoc"}},
                {"PcpSwBranch",new GridColumnConfiguration { DisplayName ="PcpSwBranch"}},
                {"NpcpGfcun",new GridColumnConfiguration { DisplayName ="NpcpGfcun"}},
                {"NpcpCusMnm",new GridColumnConfiguration { DisplayName ="NpcpCusMnm"}},
                {"NpcpSwBank",new GridColumnConfiguration { DisplayName ="NpcpSwBank"}},
                {"NpcpSwCtr",new GridColumnConfiguration { DisplayName ="NpcpSwCtr"}},
                {"NpcpSwLoc",new GridColumnConfiguration { DisplayName ="NpcpSwLoc"}},
                {"NpcpSwBranch",new GridColumnConfiguration { DisplayName ="NpcpSwBranch"}},
                {"Language",new GridColumnConfiguration { DisplayName ="Language"}},
                {"Shortname",new GridColumnConfiguration { DisplayName ="Shortname"}},
                {"Isfinished",new GridColumnConfiguration { DisplayName ="Isfinished"}},
                {"Type",new GridColumnConfiguration { DisplayName ="Type"}},
                {"Descr",new GridColumnConfiguration { DisplayName ="Descr"}},
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
            {
    nameof(OSTransactionsByGatewayController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Fullname",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Gateway Party"}},
                {"Sovalue",new GridColumnConfiguration { DisplayName ="Product"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Reference"}},
                {"Partptd",new GridColumnConfiguration { DisplayName ="Participated?"}},
                {"Revolving",new GridColumnConfiguration { DisplayName ="Revlolving?"}},
                {"Outstamt",new GridColumnConfiguration { DisplayName ="Available Amount",Format = "{0:n2}"}},
                {"Outstccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"OutstamtEgp",new GridColumnConfiguration { DisplayName ="Available Amount EGP",Format = "{0:n2}"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Transaction Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Transaction Amount EGP",Format = "{0:n2}"}},
                {"CtrctDate",new GridColumnConfiguration { DisplayName ="Contract Issue Date"}},
                {"RevNext",new GridColumnConfiguration { DisplayName ="Next Revolve Date"}},
                {"ExpiryDat",new GridColumnConfiguration { DisplayName ="Expiry Date"}},

                {"Descrip",new GridColumnConfiguration { DisplayName ="Descrip"}},
                {"Outccysei",new GridColumnConfiguration { DisplayName ="Outccysei"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"Country",new GridColumnConfiguration { DisplayName ="Country"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Status"}},
                {"Relmstrref",new GridColumnConfiguration { DisplayName ="Relmstrref"}},
                {"Prodcode",new GridColumnConfiguration { DisplayName ="Prodcode"}},
                {"Sovalue1",new GridColumnConfiguration { DisplayName ="Sovalue1"}},
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"Typeflag",new GridColumnConfiguration { DisplayName ="Typeflag"}},
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
             {
    nameof(OSTransactionsByNonPriController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="Behalf Of Branch"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Non-Principal Party"}},
                {"Sovalue",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Descrip",new GridColumnConfiguration { DisplayName ="Product Type"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"Partptd",new GridColumnConfiguration { DisplayName ="Participated?"}},
                {"Revolving",new GridColumnConfiguration { DisplayName ="Revolving?"}},
                {"Outstamt",new GridColumnConfiguration { DisplayName ="Available Amount",Format = "{0:n2}"}},
                {"Outstccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"OutstamtEgp",new GridColumnConfiguration { DisplayName ="Available Amount Egp",Format = "{0:n2}"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Transaction Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Transaction Amount Egp",Format = "{0:n2}"}},
                {"CtrctDate",new GridColumnConfiguration { DisplayName ="Contrace Issue Date"}},
                {"RevNext",new GridColumnConfiguration { DisplayName ="Next Revolve Date"}},
                {"ExpiryDat",new GridColumnConfiguration { DisplayName ="Expiry Date"}},

                {"Code79",new GridColumnConfiguration { DisplayName ="Code79"}},
                {"Outccysei",new GridColumnConfiguration { DisplayName ="Outccysei"}},
                {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"Country",new GridColumnConfiguration { DisplayName ="Country"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Status"}},
                {"Relmstrref",new GridColumnConfiguration { DisplayName ="Relmstrref"}},
                {"Sovalue1",new GridColumnConfiguration { DisplayName ="Sovalue1"}},
                {"Typeflag",new GridColumnConfiguration { DisplayName ="Typeflag"}},
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
            {
    nameof(OSTransactionsByPrincipalController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
               {"BhalfBrn",new GridColumnConfiguration { DisplayName ="Behalf Of Branch"}},
               {"Address1",new GridColumnConfiguration { DisplayName ="Principal Party"}},
               {"Sovalue",new GridColumnConfiguration { DisplayName ="Product"}},
               {"Descrip",new GridColumnConfiguration { DisplayName ="Product Type"}},
               {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
               {"Partptd",new GridColumnConfiguration { DisplayName ="Participated?"}},
               {"Revolving",new GridColumnConfiguration { DisplayName ="Revolving?"}},
               {"Outstamt",new GridColumnConfiguration { DisplayName ="Avaialble Amount",Format = "{0:n2}"}},
               {"Outstccy",new GridColumnConfiguration { DisplayName ="Currency"}},
               {"OutstamtEgp",new GridColumnConfiguration { DisplayName ="Avaialble Amount Egp",Format = "{0:n2}"}},
               {"Amount",new GridColumnConfiguration { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
               {"Ccy",new GridColumnConfiguration { DisplayName ="Transaction Currency"}},
               {"AmountEgp",new GridColumnConfiguration { DisplayName ="Transaction Amount Egp",Format = "{0:n2}"}},
               {"CtrctDate",new GridColumnConfiguration { DisplayName ="Contrace Issue Date"}},
               {"RevNext",new GridColumnConfiguration { DisplayName ="Next Revolve Date"}},
               {"ExpiryDat",new GridColumnConfiguration { DisplayName ="Expiry Date"}},

               {"Code79",new GridColumnConfiguration { DisplayName ="Code79"}},
               {"Outccyspt",new GridColumnConfiguration { DisplayName ="Outccyspt"}},
               {"Outccysei",new GridColumnConfiguration { DisplayName ="Outccysei"}},
               {"Fullname",new GridColumnConfiguration { DisplayName ="Full Name"}},
               {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
               {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
               {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
               {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
               {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
               {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
               {"Country",new GridColumnConfiguration { DisplayName ="Country"}},
               {"Status",new GridColumnConfiguration { DisplayName ="Status"}},
               {"Outccyced",new GridColumnConfiguration { DisplayName ="Outccyced"}},
               {"CcyCed",new GridColumnConfiguration { DisplayName ="CcyCed"}},
               {"Relmstrref",new GridColumnConfiguration { DisplayName ="Relmstrref"}},
               {"Sovalue1",new GridColumnConfiguration { DisplayName ="Sovalue1"}},
               {"Typeflag",new GridColumnConfiguration { DisplayName ="Typeflag"}},
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
             {
    nameof(PeriodicCHRGSPaymentController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Fullname",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Sovalue",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Descr",new GridColumnConfiguration { DisplayName ="Charge Type"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"PcpAddress1",new GridColumnConfiguration { DisplayName ="Principal Party"}},
                {"Payrec",new GridColumnConfiguration { DisplayName ="Pay/Receive"}},
                //{"AdvArr",new GridColumnConfiguration { DisplayName ="Accrue/Amortise"}},
                {"Outstamt",new GridColumnConfiguration { DisplayName ="Current Available Amount",Format = "{0:n2}"}},
                {"Outstccy",new GridColumnConfiguration { DisplayName ="Current Available Amount Currency"}},
                {"OutstamtEgp",new GridColumnConfiguration { DisplayName ="Current Available Amount Egp",Format = "{0:n2}"}},
                {"NpcpAddress1",new GridColumnConfiguration { DisplayName ="Non-Principal Party"}},
                {"SchAmt",new GridColumnConfiguration { DisplayName ="Projected Total Charges",Format = "{0:n2}"}},
                {"SchCcy",new GridColumnConfiguration { DisplayName ="Projected Total Charges Currency"}},
                {"SchAmtEgp",new GridColumnConfiguration { DisplayName ="Projected Total Charges EGP",Format = "{0:n2}"}},
                {"AccrueAmt",new GridColumnConfiguration { DisplayName ="Total Accrued/Amortized Amount to date",Format = "{0:n2}"}},
                {"AccrueCcy",new GridColumnConfiguration { DisplayName ="Total Accrued/Amortized Amount to date Currency"}},
                {"AccrueAmtEgp",new GridColumnConfiguration { DisplayName ="Total Accrued/Amortized Amount to date EGP",Format = "{0:n2}"}},
                {"Descr1",new GridColumnConfiguration { DisplayName ="Commission Type"}},


                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"NpcpGfcun",new GridColumnConfiguration { DisplayName ="NpcpGfcun"}},
                {"NpcpCusMnm",new GridColumnConfiguration { DisplayName ="NpcpCusMnm"}},
                {"NpcpSwBank",new GridColumnConfiguration { DisplayName ="NpcpSwBank"}},
                {"NpcpSwCtr",new GridColumnConfiguration { DisplayName ="NpcpSwCtr"}},
                {"NpcpSwLoc",new GridColumnConfiguration { DisplayName ="NpcpSwLoc"}},
                {"NpcpSwBranch",new GridColumnConfiguration { DisplayName ="NpcpSwBranch"}},
                {"NpcpAddress11",new GridColumnConfiguration { DisplayName ="NpcpAddress11"}},
                {"ChgGfcun1",new GridColumnConfiguration { DisplayName ="ChgGfcun1"}},
                {"ChgCusMnm1",new GridColumnConfiguration { DisplayName ="ChgCusMnm1"}},
                {"ChgSwBank1",new GridColumnConfiguration { DisplayName ="ChgSwBank1"}},
                {"ChgSwCtr1",new GridColumnConfiguration { DisplayName ="ChgSwCtr1"}},
                {"ChgSwLoc1",new GridColumnConfiguration { DisplayName ="ChgSwLoc1"}},
                {"ChgSwBranch1",new GridColumnConfiguration { DisplayName ="ChgSwBranch1"}},
                {"PcpGfcun",new GridColumnConfiguration { DisplayName ="PcpGfcun"}},
                {"PcpCusMnm",new GridColumnConfiguration { DisplayName ="PcpCusMnm"}},
                {"PcpSwBank",new GridColumnConfiguration { DisplayName ="PcpSwBank"}},
                {"PcpSwCtr",new GridColumnConfiguration { DisplayName ="PcpSwCtr"}},
                {"PcpSwLoc",new GridColumnConfiguration { DisplayName ="PcpSwLoc"}},
                {"PcpSwBranch",new GridColumnConfiguration { DisplayName ="PcpSwBranch"}},
                {"Outccyced",new GridColumnConfiguration { DisplayName ="Outccyced"}},
                {"Relmstrref",new GridColumnConfiguration { DisplayName ="Relmstrref"}},
                {"Id",new GridColumnConfiguration { DisplayName ="Id"}},
                {"SuppAcc",new GridColumnConfiguration { DisplayName ="SuppAcc"}},
                {"EndDat",new GridColumnConfiguration { DisplayName ="End Date"}},
                {"StartDat",new GridColumnConfiguration { DisplayName ="Start Date"}},
                {"Firststart",new GridColumnConfiguration { DisplayName ="First start"}},
                {"Chgpextraday",new GridColumnConfiguration { DisplayName ="Chgpextraday"}},
                {"Workgroup",new GridColumnConfiguration { DisplayName ="Team"}},

                {"Ddate",new GridColumnConfiguration { DisplayName ="Ddate"}},
                //{"ChargeAmt",new GridColumnConfiguration { DisplayName ="ChargeAmt"}},
                { "ChargeCcy",new GridColumnConfiguration { DisplayName ="ChargeCcy",Format = "{0:n2}"}},
                { "ChargeAmtEgp",new GridColumnConfiguration { DisplayName ="ChargeAmtEgp",Format = "{0:n2}"} }
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
            {
    nameof(SystemTailoringController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
               {"Paramsetdescr",new GridColumnConfiguration { DisplayName ="Parameter Set"}},
               {"Prodlongname",new GridColumnConfiguration { DisplayName ="Product"}},
               {"Eventlongname",new GridColumnConfiguration { DisplayName ="Event"}},
               {"Attachment",new GridColumnConfiguration { DisplayName ="Attachment"}},
               {"Mappingtype",new GridColumnConfiguration { DisplayName ="Mapping Type"}},
               {"Templateid",new GridColumnConfiguration { DisplayName ="Template ID"}},
               {"Optional",new GridColumnConfiguration { DisplayName ="Option"}},
               {"Templatedescr",new GridColumnConfiguration { DisplayName ="Rules"}},

               {"Typeflag",new GridColumnConfiguration { DisplayName ="Typeflag"}},
               {"Operat44",new GridColumnConfiguration { DisplayName ="Operat44"}},
               {"Seq97",new GridColumnConfiguration { DisplayName ="Seq97"}},
               {"Canamdbas",new GridColumnConfiguration { DisplayName ="Canamdbas"}},
               {"Amendchg",new GridColumnConfiguration { DisplayName ="Amendchg"}},
               {"Autoprint",new GridColumnConfiguration { DisplayName ="Autoprint"}},
               {"Severity",new GridColumnConfiguration { DisplayName ="Severity"}},
               {"ErrorText",new GridColumnConfiguration { DisplayName ="ErrorText"}},
               {"Deadlinedays",new GridColumnConfiguration { DisplayName ="Deadlinedays"}},
               {"Deadlinedate",new GridColumnConfiguration { DisplayName ="Deadlinedate"}},
               {"Deadlinetime",new GridColumnConfiguration { DisplayName ="Deadlinetime"}},
               {"Deadlinersecs",new GridColumnConfiguration { DisplayName ="Deadlinersecs"}},
               {"Useevtfm",new GridColumnConfiguration { DisplayName ="Useevtfm"}},
               {"Username",new GridColumnConfiguration { DisplayName ="User Name"}},
               {"Teamcode",new GridColumnConfiguration { DisplayName ="Team Code"}},
               {"Obsolete",new GridColumnConfiguration { DisplayName ="Obsolete"}},
               {"Relevmapkey",new GridColumnConfiguration { DisplayName ="Relevmapkey"}},
               {"Steptype",new GridColumnConfiguration { DisplayName ="Steptype"}},
               {"Amberdays",new GridColumnConfiguration { DisplayName ="Amberdays"}},
               {"Amberdate",new GridColumnConfiguration { DisplayName ="Amberdate"}},
               {"Ambertime",new GridColumnConfiguration { DisplayName ="Ambertime"}},
               {"Amberrsecs",new GridColumnConfiguration { DisplayName ="Amberrsecs"}},
               {"Reddays",new GridColumnConfiguration { DisplayName ="Reddays"}},
               {"Reddate",new GridColumnConfiguration { DisplayName ="Red Date"}},
               {"Redtime",new GridColumnConfiguration { DisplayName ="Red Time"}},
               {"Redrsecs",new GridColumnConfiguration { DisplayName ="Redrsecs"}},
               {"Paramsetid",new GridColumnConfiguration { DisplayName ="Paramsetid"}},
               {"Mappingid",new GridColumnConfiguration { DisplayName ="Mappingid"}},
               {"Inuse",new GridColumnConfiguration { DisplayName ="Inuse"}},
               {"Intinitstepid",new GridColumnConfiguration { DisplayName ="Intinitstepid"}},
               {"Swinitstepid",new GridColumnConfiguration { DisplayName ="Swinitstepid"}},
               {"Btinitstepid",new GridColumnConfiguration { DisplayName ="Btinitstepid"}},
               {"Gwinitstepid",new GridColumnConfiguration { DisplayName ="Gwinitstepid"}},
               {"Swrejstepid",new GridColumnConfiguration { DisplayName ="Swrejstepid"}},
               {"Btrejstepid",new GridColumnConfiguration { DisplayName ="Btrejstepid"}},
               {"Gwrejstepid",new GridColumnConfiguration { DisplayName ="Gwrejstepid"}},
               {"Mapstepid",new GridColumnConfiguration { DisplayName ="Mapstepid"}},
               {"StepTime",new GridColumnConfiguration { DisplayName ="Step Time"}},
               {"AvailType",new GridColumnConfiguration { DisplayName ="Avail Type"}},
               {"Teamdescr",new GridColumnConfiguration { DisplayName ="Teamdescr"}},
               {"Mappingsubid",new GridColumnConfiguration { DisplayName ="Mappingsubid"}},
               {"Debitcredit",new GridColumnConfiguration { DisplayName ="Debitcredit"}},
               {"Trancode",new GridColumnConfiguration { DisplayName ="Trancode"}},
               {"RevPstngs",new GridColumnConfiguration { DisplayName ="RevPstngs"}},
               {"InternAcc",new GridColumnConfiguration { DisplayName ="InternAcc"}},
               {"Contingent",new GridColumnConfiguration { DisplayName ="Contingent"}},
               {"Liability",new GridColumnConfiguration { DisplayName ="Liability"}},
               {"ChkLimit",new GridColumnConfiguration { DisplayName ="ChkLimit"}},
               {"Postingtyp",new GridColumnConfiguration { DisplayName ="Postingtyp"}},
               {"Margin",new GridColumnConfiguration { DisplayName ="Margin"}},
               {"Trcrsdliab",new GridColumnConfiguration { DisplayName ="Trcrsdliab"}},
               {"TransAcc",new GridColumnConfiguration { DisplayName ="TransAcc"}},
               {"Projection",new GridColumnConfiguration { DisplayName ="Projection"}},
               {"Sequence",new GridColumnConfiguration { DisplayName ="Sequence"}},
               {"Rejstepid",new GridColumnConfiguration { DisplayName ="Rejstepid"}},
               {"ActualAmt",new GridColumnConfiguration { DisplayName ="Actual Amount"}},
               {"AmtCcy",new GridColumnConfiguration { DisplayName ="Amount Currency"}},
               {"Mapstepdescr",new GridColumnConfiguration { DisplayName ="Mapstepdescr"}},
               {"Rejstepdescr",new GridColumnConfiguration { DisplayName ="Rejstepdescr"}},
               {"Intinitstepdescr",new GridColumnConfiguration { DisplayName ="Intinitstepdescr"}},
               {"Swinitstepdescr",new GridColumnConfiguration { DisplayName ="Swinitstepdescr"}},
               {"Btinitstepdescr",new GridColumnConfiguration { DisplayName ="Btinitstepdescr"}},
               {"Gwinitstepdescr",new GridColumnConfiguration { DisplayName ="Gwinitstepdescr"}},
               {"Swrejstepdescr",new GridColumnConfiguration { DisplayName ="Swrejstepdescr"}},
               {"Btrejstepdescr",new GridColumnConfiguration { DisplayName ="Btrejstepdescr"}},
               {"Gwrejstepdescr",new GridColumnConfiguration { DisplayName ="Gwrejstepdescr"}},
               {"Domtype",new GridColumnConfiguration { DisplayName ="Domtype"}},
               {"Dombehaviour",new GridColumnConfiguration { DisplayName ="Dombehaviour"}},
               {"Domname",new GridColumnConfiguration { DisplayName ="Domname"}},
               {"Domdefault",new GridColumnConfiguration { DisplayName ="Domdefault"}},
               {"Domlinkcode",new GridColumnConfiguration { DisplayName ="Domlinkcode"}},
               {"Domlinkname",new GridColumnConfiguration { DisplayName ="Domlinkname"}},
               {"Domcode",new GridColumnConfiguration { DisplayName ="Domcode"}},
               {"Nextstepid",new GridColumnConfiguration { DisplayName ="Nextstepid"}},
               {"Nextstepdescr",new GridColumnConfiguration { DisplayName ="Nextstepdescr"}},
               {"Fromstepid",new GridColumnConfiguration { DisplayName ="Fromstepid"}},
               {"Fromstepdescr",new GridColumnConfiguration { DisplayName ="Fromstepdescr"}},
               {"AmtField",new GridColumnConfiguration { DisplayName ="AmtField"}},
               {"Liabamttyp",new GridColumnConfiguration { DisplayName ="Liabamttyp"}},
               {"Bsparamsetid",new GridColumnConfiguration { DisplayName ="Bsparamsetid"}},
               {"Bsparamsetdescr",new GridColumnConfiguration { DisplayName ="Bsparamsetdescr"}},
               {"Field2Src",new GridColumnConfiguration { DisplayName ="Field2Src"}},
               {"Amount43",new GridColumnConfiguration { DisplayName ="Amount43"}},
               {"Curren64",new GridColumnConfiguration { DisplayName ="Curren64"}},
               {"Type24",new GridColumnConfiguration { DisplayName ="Type24"}},
               {"Relati29",new GridColumnConfiguration { DisplayName ="Relati29"}},
               {"Dateab63",new GridColumnConfiguration { DisplayName ="Dateab63"}},
               {"Date71",new GridColumnConfiguration { DisplayName ="Date71"}},
               {"DateType",new GridColumnConfiguration { DisplayName ="Date Type"}},
               {"RelDate",new GridColumnConfiguration { DisplayName ="Rel Date"}},
               {"Intege18",new GridColumnConfiguration { DisplayName ="Intege18"}},
               {"AccSrc",new GridColumnConfiguration { DisplayName ="AccSrc"}},
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
            {
    nameof(WatchlistOSCheckController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Fullname",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Descri56",new GridColumnConfiguration { DisplayName ="Team"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Referance"}},
                {"Pcpaddress1",new GridColumnConfiguration { DisplayName ="Principal Party"}},
                {"Npcpaddress1",new GridColumnConfiguration { DisplayName ="Non-Principal Party"}},
                {"Longna85",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Shortname",new GridColumnConfiguration { DisplayName ="Event"}},
                {"Started",new GridColumnConfiguration { DisplayName ="Event Started"}},
                {"Descr",new GridColumnConfiguration { DisplayName ="Step"}},
                {"Status",new GridColumnConfiguration { DisplayName ="Status"}},

                {"RefnoPfix",new GridColumnConfiguration { DisplayName ="RefnoPfix"}},
                {"RefnoSerl",new GridColumnConfiguration { DisplayName ="RefnoSerl"}},
                {"Touched",new GridColumnConfiguration { DisplayName ="Touched"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Amount"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Ccy"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="AmountEgp"}},
                {"Workgroup",new GridColumnConfiguration { DisplayName ="Workgroup"}},
                {"CcyCed",new GridColumnConfiguration { DisplayName ="CcyCed"}},
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"Pcpgfcun",new GridColumnConfiguration { DisplayName ="Pcpgfcun"}},
                {"PcpcusMnm",new GridColumnConfiguration { DisplayName ="PcpcusMnm"}},
                {"PcpswBank",new GridColumnConfiguration { DisplayName ="PcpswBank"}},
                {"PcpswCtr",new GridColumnConfiguration { DisplayName ="PcpswCtr"}},
                {"PcpswLoc",new GridColumnConfiguration { DisplayName ="PcpswLoc"}},
                {"PcpswBranch",new GridColumnConfiguration { DisplayName ="PcpswBranch"}},
                {"Npcpgfcun",new GridColumnConfiguration { DisplayName ="Npcpgfcun"}},
                {"NpcpcusMnm",new GridColumnConfiguration { DisplayName ="NpcpcusMnm"}},
                {"NpcpswBank",new GridColumnConfiguration { DisplayName ="NpcpswBank"}},
                {"NpcpswCtr",new GridColumnConfiguration { DisplayName ="NpcpswCtr"}},
                {"NpcpswLoc",new GridColumnConfiguration { DisplayName ="NpcpswLoc"}},
                {"NpcpswBranch",new GridColumnConfiguration { DisplayName ="NpcpswBranch"}},
                {"Language",new GridColumnConfiguration { DisplayName ="Language"}},
                {"Isfinished",new GridColumnConfiguration { DisplayName ="Isfinished"}},
                {"Type",new GridColumnConfiguration { DisplayName ="Type"}},
                {"Lstmoduser",new GridColumnConfiguration { DisplayName ="Lstmoduser"}},
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
             {
    nameof(OSActivityController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"BranchName",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"Team",new GridColumnConfiguration { DisplayName ="Team"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="MasterRef"}},
                {"Product",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Descrip",new GridColumnConfiguration { DisplayName ="Product Type"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Principal Party"}},
                {"Amount",new GridColumnConfiguration { DisplayName ="Amount",Format = "{0:n2}"}},
                {"Ccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"AmountEgp",new GridColumnConfiguration { DisplayName ="Amount Egp",Format = "{0:n2}"}},
            },
        SkipList = new List<string>
        {

        }
    }
            },
             {
    nameof(FinancingInterestAccrualsController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                {"MasterRef",new GridColumnConfiguration { DisplayName ="Master Reference"}},
                {"Startdate",new GridColumnConfiguration { DisplayName ="Start Date"}},
                {"Maturity",new GridColumnConfiguration { DisplayName ="Maturity Date"}},
                {"Prodcut",new GridColumnConfiguration { DisplayName ="Product"}},
                {"AmtOS",new GridColumnConfiguration { DisplayName ="Outstanding Amount",Format = "{0:n2}"}},
                {"Recccy",new GridColumnConfiguration { DisplayName ="Currency"}},
                {"AmtOSEgp",new GridColumnConfiguration { DisplayName ="Outstanding Amount Egp",Format = "{0:n2}"}},
                {"Inttypeid",new GridColumnConfiguration { DisplayName ="Inttypeid"}},
                {"Calcdte",new GridColumnConfiguration { DisplayName ="Calc Date"}},
                {"EarlyDate",new GridColumnConfiguration { DisplayName ="Early Date"}},
                {"RecamtPd",new GridColumnConfiguration { DisplayName ="RecamtPd"}},
                {"RecccyPd",new GridColumnConfiguration { DisplayName ="RecccyPd"}},
                {"RecamtPdEgp",new GridColumnConfiguration { DisplayName ="RecamtPdEgp"}},
                {"Address1",new GridColumnConfiguration { DisplayName ="Principal"}},
                {"InterestRateType",new GridColumnConfiguration { DisplayName ="Interest Rate and Type"}},
                {"Gfcun",new GridColumnConfiguration { DisplayName ="Gfcun"}},
                {"CusMnm",new GridColumnConfiguration { DisplayName ="CusMnm"}},
                {"SwBank",new GridColumnConfiguration { DisplayName ="SwBank"}},
                {"SwCtr",new GridColumnConfiguration { DisplayName ="SwCtr"}},
                {"SwLoc",new GridColumnConfiguration { DisplayName ="SwLoc"}},
                {"SwBranch",new GridColumnConfiguration { DisplayName ="SwBranch"}},
                {"Recamt",new GridColumnConfiguration { DisplayName ="Recamt"}},
                {"DealCcy",new GridColumnConfiguration { DisplayName ="DealCcy"}},
                {"IntpAmt",new GridColumnConfiguration { DisplayName ="IntpAmt"}},
                {"IntpCcy",new GridColumnConfiguration { DisplayName ="IntpCcy"}},
                {"IntpAmtEgp",new GridColumnConfiguration { DisplayName ="IntpAmtEgp"}},
                {"Cycleend",new GridColumnConfiguration { DisplayName ="Cycleend"}},
                {"Pastduedte",new GridColumnConfiguration { DisplayName ="Pastduedte"}},
                {"Extraday",new GridColumnConfiguration { DisplayName ="Extraday"}},
                {"IntType",new GridColumnConfiguration { DisplayName ="IntType"}},
                {"RateType",new GridColumnConfiguration { DisplayName ="RateType"}},
                {"PartpnRef",new GridColumnConfiguration { DisplayName ="PartpnRef"}},
                {"Ptnshare",new GridColumnConfiguration { DisplayName ="Ptnshare"}},
                {"Prodtypename",new GridColumnConfiguration { DisplayName ="Prodtypename"}},
                {"Idb",new GridColumnConfiguration { DisplayName ="Idb"}},
                {"Intperunit",new GridColumnConfiguration { DisplayName ="Intperunit"}},
                {"Intpernum",new GridColumnConfiguration { DisplayName ="Intpernum"}},
                {"Intperday",new GridColumnConfiguration { DisplayName ="Intperday"}},
                {"CcySpt",new GridColumnConfiguration { DisplayName ="CcySpt"}},
                {"CcySei",new GridColumnConfiguration { DisplayName ="CcySei"}},
                {"BhalfBrn",new GridColumnConfiguration { DisplayName ="BhalfBrn"}},
                {"Sovalue",new GridColumnConfiguration { DisplayName ="Sovalue"}},
                {"CcyCed",new GridColumnConfiguration { DisplayName ="CcyCed"}},
                {"CalcdtePd",new GridColumnConfiguration { DisplayName ="CalcdtePd"}},
                {"Calcrate",new GridColumnConfiguration { DisplayName ="Calcrate"}},
                {"Actualrate",new GridColumnConfiguration { DisplayName ="Actualrate"}},
                {"Prodtypedesc",new GridColumnConfiguration { DisplayName ="Prodtypedesc"}},
                {"BaseRate2",new GridColumnConfiguration { DisplayName ="BaseRate2"}},
                {"DiffRate2",new GridColumnConfiguration { DisplayName ="DiffRate2"}},
                {"GroupRate2",new GridColumnConfiguration { DisplayName ="GroupRate2"}},
                {"BalancAmt",new GridColumnConfiguration { DisplayName ="BalancAmt"}},
                {"SplitTier",new GridColumnConfiguration { DisplayName ="SplitTier"}},
                {"TierNum",new GridColumnConfiguration { DisplayName ="TierNum"}},
                {"TierAmt",new GridColumnConfiguration { DisplayName ="TierAmt"}},
                {"Pedoramt",new GridColumnConfiguration { DisplayName ="Pedoramt"}},
                {"TierPnum",new GridColumnConfiguration { DisplayName ="TierPnum"}},
                {"TierPunit",new GridColumnConfiguration { DisplayName ="TierPunit"}},
                {"TierBase",new GridColumnConfiguration { DisplayName ="TierBase"}},
                {"TierDiff",new GridColumnConfiguration { DisplayName ="TierDiff"}},
                {"TierSprd",new GridColumnConfiguration { DisplayName ="TierSprd"}},
                {"TierRate",new GridColumnConfiguration { DisplayName ="TierRate"}},
                {"GroupCode",new GridColumnConfiguration { DisplayName ="GroupCode"}},
                {"Schratetype",new GridColumnConfiguration { DisplayName ="Schratetype"}},
                {"Calcrate1",new GridColumnConfiguration { DisplayName ="Calcrate1"}},
                {"Interp",new GridColumnConfiguration { DisplayName ="Interp"}},
                {"Interprate",new GridColumnConfiguration { DisplayName ="Interprate"}},
                {"Commitamt",new GridColumnConfiguration { DisplayName ="Commitamt"}},
                {"AmtOrPct",new GridColumnConfiguration { DisplayName ="AmtOrPct"}},
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
             {
    nameof(AdvancePaymentUtilizationController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Branch",new GridColumnConfiguration { DisplayName ="Branch"}},
                {"AdvReference",new GridColumnConfiguration { DisplayName ="Advance Reference"}},
                {"PrincipalParty",new GridColumnConfiguration { DisplayName ="Principal Party"}},
                {"NonPrincipalParty",new GridColumnConfiguration { DisplayName ="Non Principal Party"}},
                {"CreationDate",new GridColumnConfiguration { DisplayName ="CreationDate",Format="{0:dd/MM/yyyy}"}},
                {"ExpiryDate",new GridColumnConfiguration { DisplayName ="Expiry Date",Format="{0:dd/MM/yyyy}"}},
                {"UtilizationTrn",new GridColumnConfiguration { DisplayName ="Utilization Transaction"}},
                {"AdvAmount",new GridColumnConfiguration { DisplayName ="Advance Amount",Format = "{0:n2}"}},
                {"AdvCurrency",new GridColumnConfiguration { DisplayName ="Advance Currency"}},
                {"UtilizationAmount",new GridColumnConfiguration { DisplayName ="Utilization Amount",Format="{0:n2}"}},
                {"UtilizationCurrency",new GridColumnConfiguration { DisplayName ="Utilization Currency"}},
                {"OutstandingAmount",new GridColumnConfiguration { DisplayName ="Outstanding Amount",Format="{0:n2}"}},
            },
        SkipList = new List<string>
        {

        }
    }
            },
            {
    nameof(FullJournalController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"Dataitem",new GridColumnConfiguration { DisplayName ="Data Item"}},
                {"Username",new GridColumnConfiguration { DisplayName ="User Name"}},
                {"MtceType",new GridColumnConfiguration { DisplayName ="Mode"}},
                {"Mcmtcetype",new GridColumnConfiguration { DisplayName ="Mcmtcetype"}},
                {"Mcusername",new GridColumnConfiguration { DisplayName ="Mcusername"}},
                {"AreaCode",new GridColumnConfiguration { DisplayName ="AreaCode"}},
                {"Area",new GridColumnConfiguration { DisplayName ="Type"}},
                {"Jkey",new GridColumnConfiguration { DisplayName ="Jkey"}},
                {"Datetime",new GridColumnConfiguration { DisplayName ="Date"}},
                {"Mcowner",new GridColumnConfiguration { DisplayName ="Mcowner"}},
                {"Entrytimeutc",new GridColumnConfiguration { DisplayName ="Entrytimeutc"}},
                {"Mcaction",new GridColumnConfiguration { DisplayName ="Mcaction"}},
                {"Mcnote",new GridColumnConfiguration { DisplayName ="Mcnote"}},
                {"DataAfter",new GridColumnConfiguration { DisplayName ="Details After" , isLargeText = true}},
                {"Databefore",new GridColumnConfiguration { DisplayName ="Details Before" , isLargeText = true}},
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
            {
    nameof(EcmWorkflowProgController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                {"EcmReference",new GridColumnConfiguration { DisplayName ="ECM Reference"}},
                {"EcmCaseCreationDate",new GridColumnConfiguration { DisplayName ="ECM Case Creation Date"}},
                {"BranchId",new GridColumnConfiguration { DisplayName ="Branch ID"}},
                {"CutomerName",new GridColumnConfiguration { DisplayName ="Customer Name"}},
                {"Product",new GridColumnConfiguration { DisplayName ="Product"}},
                {"ProductType",new GridColumnConfiguration { DisplayName ="Product Type"}},
                {"EcmEvent",new GridColumnConfiguration { DisplayName ="ECM Event"}},
                {"TransactionAmount",new GridColumnConfiguration { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"TransactionCurrency",new GridColumnConfiguration { DisplayName ="Transaction Currency"}},
                {"PrimaryOwner",new GridColumnConfiguration { DisplayName ="Primary Owner"}},
                {"CaseStatCd",new GridColumnConfiguration { DisplayName ="Case Status"}},
                {"UpdateUserId",new GridColumnConfiguration { DisplayName ="Last Action taken by"}},
                //{"Comments",new GridColumnConfiguration { DisplayName ="Comments"}},
                {"EcmRejectionType",new GridColumnConfiguration { DisplayName ="ECM Rejection Reason"}},
                {"EcmRejectionReason",new GridColumnConfiguration { DisplayName ="ECM Rejection Description"}},
                {"FtiReference",new GridColumnConfiguration { DisplayName ="FTI Reference"}},
                {"EventName",new GridColumnConfiguration { DisplayName ="Event Name"}},
                {"EventStatus",new GridColumnConfiguration { DisplayName ="Event Status"}},
                {"EventCreationDate",new GridColumnConfiguration { DisplayName ="Event Creation Date"}},
                {"AssignedTo",new GridColumnConfiguration { DisplayName ="Assigned To"}},
                {"AssignmentType",new GridColumnConfiguration { DisplayName ="Assignment Type"}},
                {"EventSteps",new GridColumnConfiguration { DisplayName ="Event Steps"}},
                {"StepStatus",new GridColumnConfiguration { DisplayName ="Step Status"}},
                {"Lstmodtime",new GridColumnConfiguration { DisplayName ="Last Modification Time"}},
                {"Lstmoduser",new GridColumnConfiguration { DisplayName ="Last Modification By"}},
                {"WarningOverridden",new GridColumnConfiguration { DisplayName ="Warning Overridden"}},
                {"RejectionReason",new GridColumnConfiguration { DisplayName ="Rejection Reason", isLargeText = true}},
                {"SlaDeadline",new GridColumnConfiguration { DisplayName ="SLA Deadline"}},
                {"InputStepTime",new GridColumnConfiguration { DisplayName ="Input Step Time"}},
                {"InputSlaStatus",new GridColumnConfiguration { DisplayName ="Input SLA Status"}},
                {"InputMaxTime",new GridColumnConfiguration { DisplayName ="Input Max Time"}},
                {"ExternalReviewStepTime",new GridColumnConfiguration { DisplayName ="External Review Step Time"}},
                {"ExternalReviewSlaStatus",new GridColumnConfiguration { DisplayName ="External Review SLA Status"}},
                {"ReviewStepTime",new GridColumnConfiguration { DisplayName ="Review Step Time"}},
                {"ReviewSlaStatus",new GridColumnConfiguration { DisplayName ="Review SLA Status"}},
                {"AuthorizeStepTime",new GridColumnConfiguration { DisplayName ="Authorize Step Time"}},
                {"AuthorizeSlaStatus",new GridColumnConfiguration { DisplayName ="Authorize SLA Status"}},
                {"SlaDashboardAmber",new GridColumnConfiguration { DisplayName ="SLA Dashboard Amber"}},
                {"SlaDashboardRed",new GridColumnConfiguration { DisplayName ="SLA Dashboard Red"}},
                {"SlaRemainingTime",new GridColumnConfiguration { DisplayName ="SLA Remaining TIme"}},
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
            {
    nameof(EcmAuditTrialController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                 {"EcmReference",new GridColumnConfiguration { DisplayName ="ECM Reference"}},
                {"BranchId",new GridColumnConfiguration { DisplayName ="Branch ID"}},
                {"EcmCaseCreationDate",new GridColumnConfiguration { DisplayName ="ECM Case Creation Date"}},
                {"CutomerName",new GridColumnConfiguration { DisplayName ="Customer Name"}},
                {"Product",new GridColumnConfiguration { DisplayName ="Product"}},
                {"Producttype",new GridColumnConfiguration { DisplayName ="Product Type"}},
                {"EcmEvent",new GridColumnConfiguration { DisplayName ="Ecm Event"}},
                {"TransactionAmount",new GridColumnConfiguration { DisplayName ="Transaction Amount",Format = "{0:n2}"}},
                {"TransactionCurrency",new GridColumnConfiguration { DisplayName ="Transaction Currency"}},
                {"PrimaryOwner",new GridColumnConfiguration { DisplayName ="Primary Owner"}},
                {"CaseStatCd",new GridColumnConfiguration { DisplayName ="Case Status"}},
                {"UpdateUserId",new GridColumnConfiguration { DisplayName ="Last Action taken by"}},
                {"Comments",new GridColumnConfiguration { DisplayName ="Comments"}},
                {"FtiReference",new GridColumnConfiguration { DisplayName ="Fti Reference"}},
                {"EventName",new GridColumnConfiguration { DisplayName ="Event Name"}},
                {"EventStatus",new GridColumnConfiguration { DisplayName ="Event Status"}},
                {"EventCreationDate",new GridColumnConfiguration { DisplayName ="Event Creation Date"}},
                {"MasterAssignedTo",new GridColumnConfiguration { DisplayName ="Master Assigned To"}},
                {"EventSteps",new GridColumnConfiguration { DisplayName ="Event Steps"}},
                {"StepStatus",new GridColumnConfiguration { DisplayName ="Step Status"}},
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
    nameof(ArtAuditCorporateController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "CaseRk",new GridColumnConfiguration { DisplayName ="Case Rk"}},
                        {  "BankingOrCorporate",new GridColumnConfiguration { DisplayName ="Banking Or Corporate"}},
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "NameLanguage",new GridColumnConfiguration { DisplayName ="Name Language"}},
                        {  "CorporateName",new GridColumnConfiguration { DisplayName ="Corporate Name"}},
                        {  "CommercialName",new GridColumnConfiguration { DisplayName ="Commercial Name"}},
                        {  "CorporateNameEn",new GridColumnConfiguration { DisplayName ="Corporate Name En"}},
                        {  "CommercialNameEn",new GridColumnConfiguration { DisplayName ="Commercial Name En"}},
                        {  "Title",new GridColumnConfiguration { DisplayName ="Title"}},
                        {  "DefaultBranch",new GridColumnConfiguration { DisplayName ="Default Branch"}},
                        {  "Industry",new GridColumnConfiguration { DisplayName ="Industry"}},
                        {  "AmlRiskCd",new GridColumnConfiguration { DisplayName ="Aml Risk CD"}},
                        {  "KycStatus",new GridColumnConfiguration { DisplayName ="Kyc Status"}},
                        {  "TypeOfBusiness",new GridColumnConfiguration { DisplayName ="Type Of Business"}},
                        {  "TypeOfBusinessOther",new GridColumnConfiguration { DisplayName ="Type Of Business Other"}},
                        {  "IdentType",new GridColumnConfiguration { DisplayName ="Identity Type"}},
                        {  "IdentNumber",new GridColumnConfiguration { DisplayName ="Identity Number"}},
                        {  "IdIssueCountry",new GridColumnConfiguration { DisplayName ="ID Issue Country"}},
                        {  "IdentIssueDate",new GridColumnConfiguration { DisplayName ="Identity Issue Date"}},
                        {  "IdentExpiryDate",new GridColumnConfiguration { DisplayName ="Identity Expiry Date"}},
                        {  "RegNumberCity",new GridColumnConfiguration { DisplayName ="Reg Number City"}},
                        {  "RegNumberOffice",new GridColumnConfiguration { DisplayName ="Reg Number Office"}},
                        {  "RegistrationNumber",new GridColumnConfiguration { DisplayName ="Registration Number"}},
                        {  "RegExpiryDate",new GridColumnConfiguration { DisplayName ="Reg Expiry Date"}},
                        {  "RegNumberLastDate",new GridColumnConfiguration { DisplayName ="Reg Number Last Date"}},
                        {  "HeadQuarterCountry",new GridColumnConfiguration { DisplayName ="Head Quarter Country"}},
                        {  "TaxIdNum",new GridColumnConfiguration { DisplayName ="Tax ID Number"}},
                        {  "NationalityCountry",new GridColumnConfiguration { DisplayName ="Nationality Country"}},
                        {  "IncorporationCountryCode",new GridColumnConfiguration { DisplayName ="Incorporation Country Code"}},
                        {  "IncorporationDate",new GridColumnConfiguration { DisplayName ="Incorporation Date"}},
                        {  "IncorporationLegalForm",new GridColumnConfiguration { DisplayName ="Incorporation Legal Form"}},
                        {  "IncorporationState",new GridColumnConfiguration { DisplayName ="Incorporation State"}},
                        {  "LegalFormOthers",new GridColumnConfiguration { DisplayName ="Legal Form Others"}},
                        {  "LegalFormSub",new GridColumnConfiguration { DisplayName ="Legal Form Sub"}},
                        {  "RiskReason",new GridColumnConfiguration { DisplayName ="Risk Reason"}},
                        {  "RiskCode",new GridColumnConfiguration { DisplayName ="Risk Code"}},
                        {  "CbRiskRate",new GridColumnConfiguration { DisplayName ="Cb Risk Rate"}},
                        {  "ClosingReasonId",new GridColumnConfiguration { DisplayName ="Closing Reason ID"}},
                        {  "CloseDate",new GridColumnConfiguration { DisplayName ="Close Date"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                        {  "CreatedBy",new GridColumnConfiguration { DisplayName ="Created By"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},
                        {  "UpdateDate",new GridColumnConfiguration { DisplayName ="Update Date"}},
                        {  "UpdatedBy",new GridColumnConfiguration { DisplayName ="Updated By"}},
                        {  "ActivityTypeSub",new GridColumnConfiguration { DisplayName ="Activity Type Sub"}},
                        {  "BudgetDate1",new GridColumnConfiguration { DisplayName ="Budget Date1"}},
                        {  "BudgetDate2",new GridColumnConfiguration { DisplayName ="Budget Date2"}},
                        {  "BudgetDate3",new GridColumnConfiguration { DisplayName ="Budget Date3"}},
                        {  "FfiType",new GridColumnConfiguration { DisplayName ="Ffi Type"}},
                        {  "Giin",new GridColumnConfiguration { DisplayName ="Giin"}},
                        {  "SalesVolume1",new GridColumnConfiguration { DisplayName ="Sales Volume1"}},
                        {  "SalesVolume2",new GridColumnConfiguration { DisplayName ="Sales Volume2"}},
                        {  "SalesVolume3",new GridColumnConfiguration { DisplayName ="Sales Volume3"}},
                        {  "ActivityAmount",new GridColumnConfiguration { DisplayName ="Activity Amount"}},
                        {  "ActivityAmountCurrency",new GridColumnConfiguration { DisplayName ="Activity Amount Currency"}},
                        {  "ActivityEndDate",new GridColumnConfiguration { DisplayName ="Activity End Date"}},
                        {  "ActivityStartDate",new GridColumnConfiguration { DisplayName ="Activity Start Date"}},
                        {  "ActivityType",new GridColumnConfiguration { DisplayName ="Activity Type"}},
                        {  "ActivityTypeDtls",new GridColumnConfiguration { DisplayName ="Activity Type Dtls"}},
                        {  "CharityDonationsInd",new GridColumnConfiguration { DisplayName ="Charity Donations Ind"}},
                        {  "FinancialStartDate",new GridColumnConfiguration { DisplayName ="Financial Start Date"}},
                        {  "ForeignConsulateEmbassyInd",new GridColumnConfiguration { DisplayName ="Foreign Consulate Embassy Ind"}},
                        {  "GovOrgInd",new GridColumnConfiguration { DisplayName ="Gov Org Ind"}},
                        {  "WomenShare",new GridColumnConfiguration { DisplayName ="Women Share"}},
                        {  "DateOfBudget",new GridColumnConfiguration { DisplayName ="Date Of Budget"}},
                        {  "NoOfEmployees",new GridColumnConfiguration { DisplayName ="No Of Employees"}},
                        {  "SizeOfSales",new GridColumnConfiguration { DisplayName ="Size Of Sales"}},
                        {  "SizeOfTransaction",new GridColumnConfiguration { DisplayName ="Size Of Transaction"}},
                        {  "ReferenceEmployeeId",new GridColumnConfiguration { DisplayName ="Reference Employee ID"}},
                        {  "CustomerReference",new GridColumnConfiguration { DisplayName ="Customer Reference"}},
                        {  "BankingOrOtherRef",new GridColumnConfiguration { DisplayName ="Banking Or Other Ref"}},
                        {  "LimitsAmount",new GridColumnConfiguration { DisplayName ="Limits Amount"}},
                        {  "LimitsAmountCurrency",new GridColumnConfiguration { DisplayName ="Limits Amount Currency"}},
                        {  "GeoCode",new GridColumnConfiguration { DisplayName ="Geo Code"}},
                        {  "BusinessCode",new GridColumnConfiguration { DisplayName ="Business Code"}},
                        {  "CalculateZakahFlag",new GridColumnConfiguration { DisplayName ="Calculate Zakah Flag"}},
                        {  "CustomerStatus",new GridColumnConfiguration { DisplayName ="Customer Status"}},
                        {  "InvestmentBalance",new GridColumnConfiguration { DisplayName ="Investment Balance"}},
                        {  "SalesBasis",new GridColumnConfiguration { DisplayName ="Sales Basis"}},
                        {  "LegalStepMainCode",new GridColumnConfiguration { DisplayName ="Legal Step Main Code"}},
                        {  "LegalStepSubCode",new GridColumnConfiguration { DisplayName ="Legal Step Sub Code"}},
                        {  "MainLegalForm",new GridColumnConfiguration { DisplayName ="Main Legal Form"}},
                        {  "UnderEstablishment",new GridColumnConfiguration { DisplayName ="Under Establishment"}},
                        {  "TotalNoOfUnits",new GridColumnConfiguration { DisplayName ="Total No Of Units"}},
                        {  "RiskWeight",new GridColumnConfiguration { DisplayName ="Risk Weight"}},
                        {  "WorthCode",new GridColumnConfiguration { DisplayName ="Worth Code"}},
                        {  "LastQueryDate",new GridColumnConfiguration { DisplayName ="Last Query Date"}},
                        {  "TradeAddDate",new GridColumnConfiguration { DisplayName ="Trade Add Date"}},
                        {  "WorthLastCalcDate",new GridColumnConfiguration { DisplayName ="Worth Last Calc Date"}},
                        {  "EconomicActivityCode5",new GridColumnConfiguration { DisplayName ="Economic Activity Code5"}},
                        {  "PaidUpCapitalAmount",new GridColumnConfiguration { DisplayName ="Paid Up Capital Amount"}},
                        {  "PaidUpCapitalCurrency",new GridColumnConfiguration { DisplayName ="Paid Up Capital Currency"}},
                        {  "DealtBankDetails",new GridColumnConfiguration { DisplayName ="Dealt Bank Details"}},
                        {  "DealAbrdBankDetails",new GridColumnConfiguration { DisplayName ="Deal Abrd Bank Details"}},
                        {  "OtherBankAccounts",new GridColumnConfiguration { DisplayName ="Other Bank Accounts"}},
                        {  "Capital1",new GridColumnConfiguration { DisplayName ="Capital1"}},
                        {  "Capital2",new GridColumnConfiguration { DisplayName ="Capital2"}},
                        {  "Capital3",new GridColumnConfiguration { DisplayName ="Capital3"}},
                        {  "AnnualNetIncomeCd",new GridColumnConfiguration { DisplayName ="Annual Net Income CD"}},
                        {  "NonProfitOrganization",new GridColumnConfiguration { DisplayName ="Non Profit Organization"}},
                        {  "CompanyStock",new GridColumnConfiguration { DisplayName ="Company Stock"}},
                        {  "CompanyStockName",new GridColumnConfiguration { DisplayName ="Company Stock Name"}},
                        {  "HoldingCorporation",new GridColumnConfiguration { DisplayName ="Holding Corporation"}},
                        {  "HoldingCorporationCd",new GridColumnConfiguration { DisplayName ="Holding Corporation CD"}},
                    }
    }
            },
            {
    nameof(ArtAuditIndividualsController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "CaseRk",new GridColumnConfiguration { DisplayName ="Case Rk"}},
                        {  "AKA",new GridColumnConfiguration { DisplayName ="AKA"}},
                        {  "OpeningReasonId",new GridColumnConfiguration { DisplayName ="Opening Reason ID"}},
                        {  "AmlRiskCd",new GridColumnConfiguration { DisplayName ="Aml Risk CD"}},
                        {  "CitizenOrResident",new GridColumnConfiguration { DisplayName ="Citizen Or Resident"}},
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "CloseDate",new GridColumnConfiguration { DisplayName ="Close Date"}},
                        {  "ClosingReasonId",new GridColumnConfiguration { DisplayName ="Closing Reason ID"}},
                        {  "CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                        {  "CreatedBy",new GridColumnConfiguration { DisplayName ="Created By"}},
                        {  "RiskClassValue",new GridColumnConfiguration { DisplayName ="Risk Class Value"}},
                        {  "CustomerType",new GridColumnConfiguration { DisplayName ="Customer Type"}},
                        {  "DefaultBranch",new GridColumnConfiguration { DisplayName ="Default Branch"}},
                        {  "NumberOfDependents",new GridColumnConfiguration { DisplayName ="Number Of Dependents"}},
                        {  "FirstName",new GridColumnConfiguration { DisplayName ="First Name"}},
                        {  "FullNameAr",new GridColumnConfiguration { DisplayName ="Full Name AR"}},
                        {  "FullNameEn",new GridColumnConfiguration { DisplayName ="Full Name EN"}},
                        {  "GenderCd",new GridColumnConfiguration { DisplayName ="Gender CD"}},
                        {  "EducationId",new GridColumnConfiguration { DisplayName ="Education ID"}},
                        {  "CbRiskId",new GridColumnConfiguration { DisplayName ="Cb Risk ID"}},
                        {  "KycStatus",new GridColumnConfiguration { DisplayName ="Kyc Status"}},
                        {  "RaceId",new GridColumnConfiguration { DisplayName ="Race ID"}},
                        {  "LastName",new GridColumnConfiguration { DisplayName ="Last Name"}},
                        {  "MaritalStatusCd",new GridColumnConfiguration { DisplayName ="Marital Status CD"}},
                        {  "MiddleName",new GridColumnConfiguration { DisplayName ="Middle Name"}},
                        {  "MotherName",new GridColumnConfiguration { DisplayName ="Mother Name"}},
                        {  "NationalityCode1",new GridColumnConfiguration { DisplayName ="Nationality Code1"}},
                        {  "NationalityCode2",new GridColumnConfiguration { DisplayName ="Nationality Code2"}},
                        {  "NationalityCode3",new GridColumnConfiguration { DisplayName ="Nationality Code3"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},
                        {  "CbRiskRate",new GridColumnConfiguration { DisplayName ="Cb Risk Rate"}},
                        {  "Religion",new GridColumnConfiguration { DisplayName ="Religion"}},
                        {  "ResidenceCountry",new GridColumnConfiguration { DisplayName ="Residence Country"}},
                        {  "RiskReason",new GridColumnConfiguration { DisplayName ="Risk Reason"}},
                        {  "RiskCode",new GridColumnConfiguration { DisplayName ="Risk Code"}},
                        {  "SictorCode",new GridColumnConfiguration { DisplayName ="Sictor Code"}},
                        {  "Title",new GridColumnConfiguration { DisplayName ="Title"}},
                        {  "UpdateDate",new GridColumnConfiguration { DisplayName ="Update Date"}},
                        {  "UpdatedBy",new GridColumnConfiguration { DisplayName ="Updated By"}},
                        {  "VisaType",new GridColumnConfiguration { DisplayName ="Visa Type"}},
                        {  "FirstNameEng",new GridColumnConfiguration { DisplayName ="First Name EN"}},
                        {  "LastNameEng",new GridColumnConfiguration { DisplayName ="Last Name EN"}},
                        {  "MiddleNameEng",new GridColumnConfiguration { DisplayName ="Middle Name EN"}},
                        {  "NameLanguage",new GridColumnConfiguration { DisplayName ="Name Language"}},
                        {  "EmployeeIndicator",new GridColumnConfiguration { DisplayName ="Employee Indicator"}},
                        {  "EducationIdOther",new GridColumnConfiguration { DisplayName ="Education ID Other"}},
                        {  "SpouseBusiness",new GridColumnConfiguration { DisplayName ="Spouse Business"}},
                        {  "SpouseName",new GridColumnConfiguration { DisplayName ="Spouse Name"}},
                        {  "VisaExpirationDate",new GridColumnConfiguration { DisplayName ="Visa Expiration Date"}},
                        {  "CbRiskRateOther",new GridColumnConfiguration { DisplayName ="Cb Risk Rate Other"}},
                        {  "ClosingReasonIdOther",new GridColumnConfiguration { DisplayName ="Closing Reason ID Other"}},
                        {  "OpeningReasonIdOther",new GridColumnConfiguration { DisplayName ="Opening Reason ID Other"}},
                        {  "RiskCodeOther",new GridColumnConfiguration { DisplayName ="Risk Code Other"}},
                        {  "EmploymentType",new GridColumnConfiguration { DisplayName ="Employment Type"}},
                        {  "EmployedOrBusiness",new GridColumnConfiguration { DisplayName ="Employed Or Business"}},
                        {  "EmployerBusinessName",new GridColumnConfiguration { DisplayName ="Employer Business Name"}},
                        {  "EmployerBusinessAdrs",new GridColumnConfiguration { DisplayName ="Employer Business Address"}},
                        {  "EmployerBusinessCity",new GridColumnConfiguration { DisplayName ="Employer Business City"}},
                        {  "EmployerBusinessCtry",new GridColumnConfiguration { DisplayName ="Employer Business Country"}},
                        {  "EmployerBusinessState",new GridColumnConfiguration { DisplayName ="Employer Business State"}},
                        {  "EmployerBusinessTown",new GridColumnConfiguration { DisplayName ="Employer Business Town"}},
                        {  "EmployerPhone",new GridColumnConfiguration { DisplayName ="Employer Phone"}},
                        {  "EmployerCountryPhoneCode",new GridColumnConfiguration { DisplayName ="Employer Country Phone Code"}},
                        {  "Occupation",new GridColumnConfiguration { DisplayName ="Occupation"}},
                        {  "OccupationDtl",new GridColumnConfiguration { DisplayName ="Occupation Dtl"}},
                        {  "BusinessSector",new GridColumnConfiguration { DisplayName ="Business Sector"}},
                        {  "BusinessSectorOthers",new GridColumnConfiguration { DisplayName ="Business Sector Others"}},
                        {  "PepIndicator",new GridColumnConfiguration { DisplayName ="PEP Indicator"}},
                        {  "PepIndicatorDtls",new GridColumnConfiguration { DisplayName ="PEP Indicator Dtls"}},
                        {  "PepIndicatorOth",new GridColumnConfiguration { DisplayName ="PEP Indicator Other"}},
                        {  "SourceOfIncomeCd",new GridColumnConfiguration { DisplayName ="Source Of Income CD"}},
                        {  "SourceOfIncomeOther",new GridColumnConfiguration { DisplayName ="Source Of Income Other"}},
                        {  "AnnualIncomeCd",new GridColumnConfiguration { DisplayName ="Annual Income CD"}},
                        {  "MonthIncome",new GridColumnConfiguration { DisplayName ="Month Income"}},
                        {  "IncomeIsoCurrency",new GridColumnConfiguration { DisplayName ="Income ISO Currency"}},
                        {  "MonthExpense",new GridColumnConfiguration { DisplayName ="Month Expense"}},
                        {  "ExpenseIsoCurrency",new GridColumnConfiguration { DisplayName ="Expense ISO Currency"}},
                        {  "HomeCd",new GridColumnConfiguration { DisplayName ="Home CD"}},
                        {  "TaxRegulationCtryCd1",new GridColumnConfiguration { DisplayName ="Tax Regulation Country CD1"}},
                        {  "TaxRegulationCtryCd2",new GridColumnConfiguration { DisplayName ="Tax Regulation Country CD2"}},
                        {  "TaxRegulationCtryCd3",new GridColumnConfiguration { DisplayName ="Tax Regulation Country CD3"}},
                        {  "TaxRegulationTin1",new GridColumnConfiguration { DisplayName ="Tax Regulation Tin1"}},
                        {  "TaxRegulationTin2",new GridColumnConfiguration { DisplayName ="Tax Regulation Tin2"}},
                        {  "TaxRegulationTin3",new GridColumnConfiguration { DisplayName ="Tax Regulation Tin3"}},
                        {  "RelationToBankCode",new GridColumnConfiguration { DisplayName ="Relation To Bank Code"}},
                        {  "OtherBankAccounts",new GridColumnConfiguration { DisplayName ="Other Bank Accounts"}},
                        {  "DealtBankDetails",new GridColumnConfiguration { DisplayName ="Dealt Bank Details"}},
                        {  "DealAbrdBankDetails",new GridColumnConfiguration { DisplayName ="Deal Abrd Bank Details"}},
                        {  "BusinessCode",new GridColumnConfiguration { DisplayName ="Business Code"}},
                        {  "CalculateZakahFlag",new GridColumnConfiguration { DisplayName ="Calculate Zakah Flag"}},
                        {  "CharityFlag",new GridColumnConfiguration { DisplayName ="Charity Flag"}},
                        {  "CompanySalesAmountPerYear",new GridColumnConfiguration { DisplayName ="Company Sales Amount Per Year"}},
                        {  "CustomerStatus",new GridColumnConfiguration { DisplayName ="Customer Status"}},
                        {  "EconomicMainCode",new GridColumnConfiguration { DisplayName ="Economic Main Code"}},
                        {  "EconomicSubCode",new GridColumnConfiguration { DisplayName ="Economic Sub Code"}},
                        {  "GeoCode",new GridColumnConfiguration { DisplayName ="Geo Code"}},
                        {  "LastQueryDate",new GridColumnConfiguration { DisplayName ="Last Query Date"}},
                        {  "LegalMainCode",new GridColumnConfiguration { DisplayName ="Legal Main Code"}},
                        {  "LegalStepDate",new GridColumnConfiguration { DisplayName ="Legal Step Date"}},
                        {  "LegalStepMainCode",new GridColumnConfiguration { DisplayName ="Legal Step Main Code"}},
                        {  "LegalStepSubCode",new GridColumnConfiguration { DisplayName ="Legal Step Sub Code"}},
                        {  "LegalSubCode",new GridColumnConfiguration { DisplayName ="Legal Sub Code"}},
                        {  "ReferredPersonAddress",new GridColumnConfiguration { DisplayName ="Referred Person Address"}},
                        {  "ReferredPersonPhone",new GridColumnConfiguration { DisplayName ="Referred Person Phone"}},
                        {  "SectorAnalysesCode",new GridColumnConfiguration { DisplayName ="Sector Analyses Code"}},
                        {  "WorthLastCalcDate",new GridColumnConfiguration { DisplayName ="Worth Last Calcualte Date"}},

                    }
    }
            },
             {
    nameof(ArtKycExpiredIdController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "IdNumber",new GridColumnConfiguration { DisplayName ="ID Number"}},
                        {  "IdExpireDate",new GridColumnConfiguration { DisplayName ="ID Expire Date"}},

                    }
    }
            },
             {
    nameof(ArtKycHighExpiredController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycHighOneMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},
                    }
    }
            },
             {
    nameof(ArtKycHighThreeMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                         "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycHighTwoMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycLowExpiredController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycLowOneMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycLowThreeMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycLowTwoMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
            },
             {
    nameof(ArtKycMediumExpiredController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
             },
             {
    nameof(ArtKycMediumOneMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
             },
             {
    nameof(ArtKycMediumThreeMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
             },
             {
    nameof(ArtKycMediumTwoMonthController).ToLower(),new ReportConfig
    {
        SkipList = new List<string> {
                        "Month"
                            },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "ClientNumber",new GridColumnConfiguration { DisplayName ="Client Number"}},
                        {  "EntityName",new GridColumnConfiguration { DisplayName ="Entity Name"}},
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "RiskClassIndustry",new GridColumnConfiguration { DisplayName ="Risk Class"}},
                        {  "NextUpdateDate",new GridColumnConfiguration { DisplayName ="Next Update Date"}},

                    }
    }
             },
             {
    nameof(ArtKycSummaryByRiskController).ToLower(),new ReportConfig
    {
        SkipList = new List<string>
        {
        },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>{
                        {  "AmlRisk",new GridColumnConfiguration { DisplayName ="AML Risk"}},
                        {  "Type",new GridColumnConfiguration { DisplayName ="Type"}},
                        {  "NumberOfUpdatedKyc",new GridColumnConfiguration { DisplayName ="Number Of Updated KYC"}},
                        {  "NumberOfNotUpdatedKyc",new GridColumnConfiguration { DisplayName ="Number Of Not Updated KYC"}},
                        {  "Total",new GridColumnConfiguration { DisplayName ="Total"}},

                    }
    }
             },
             {
    nameof(CrpSystemPerformanceController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                    { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User ID"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name"}},
                    { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number"}},
                    { "CaseCurrentRate", new GridColumnConfiguration { DisplayName = "Case Current Rate"}},
                    { "Casetargetrate", new GridColumnConfiguration { DisplayName = "Case Target Rate"}},
                    { "EcmLastStatusDate", new GridColumnConfiguration { DisplayName = "Ecm Last Status Date"}},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}}
            }
    }
            },
             {
    nameof(CrpConfigController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "Maker", new GridColumnConfiguration { DisplayName = "Maker"}},
                    { "MakerDate", new GridColumnConfiguration { DisplayName = "Maker Date"}},
                    { "Checker", new GridColumnConfiguration { DisplayName = "Checker"}},
                    { "CheckerDate", new GridColumnConfiguration { DisplayName = "Checker Date"}},
                    { "CheckerAction", new GridColumnConfiguration { DisplayName = "Checker Action"}},
                    { "ActionDetail", new GridColumnConfiguration { DisplayName = "Action Detail"}},

            },
        SkipList = new List<string>
        {/*"ActionDetail"*/},
    }
            },
              {
    nameof(CrpUserPerformanceController).ToLower() , new ReportConfig
    {
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                    { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User ID"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "AsssignedTime", new GridColumnConfiguration { DisplayName = "Assigned Time"}},
                    { "ActionUser", new GridColumnConfiguration { DisplayName = "Action User"}},
                    { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name"}},
                    { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number"}},
                    { "CaseCurrentRate", new GridColumnConfiguration { DisplayName = "Case Current Rate"}},
                    { "Casetargetrate", new GridColumnConfiguration { DisplayName = "Case Target Rate"}},
                    { "Action", new GridColumnConfiguration { DisplayName = "Action"}},
                    { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date"}},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}}
            }
    }
            },
            

            //TRADE_BASE
            {
    nameof(TradeBaseAMLSummaryController).ToLower(), new ReportConfig
    {
        SkipList = new List<string>
        { },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    {"EntityNumber", new GridColumnConfiguration { DisplayName ="Entity Number"}},
                    {"EntityName", new GridColumnConfiguration { DisplayName ="Entity Name"}},
                    {"Active", new GridColumnConfiguration { DisplayName ="Active"}},
                    {"AddedToCase", new GridColumnConfiguration { DisplayName ="Added To Case"}},
                    {"Closed", new GridColumnConfiguration { DisplayName ="Closed"}},
                    {"SuppressedAlert", new GridColumnConfiguration { DisplayName ="SuppressedAlert"}},

            }
    }
            },
            {
    nameof(ArtTradeBaseSummary).ToLower(), new ReportConfig
    {
        SkipList = new List<string>
        { },
        DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    {"EntityNumber", new GridColumnConfiguration { DisplayName ="Entity Number"}},
                    {"EntityName", new GridColumnConfiguration { DisplayName ="Entity Name"}},
                    {"Active", new GridColumnConfiguration { DisplayName ="Active"}},
                    {"AddedToCase", new GridColumnConfiguration { DisplayName ="Added To Case"}},
                    {"Closed", new GridColumnConfiguration { DisplayName ="Closed"}},
                    {"SuppressedAlert", new GridColumnConfiguration { DisplayName ="Suppressed Alert"}},

            }
               ,
        ShowExportCsv = (s => true),
        ShowExportPdf = (s => false)

    }
            },




            { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_CRIME).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "CRIME", new GridColumnConfiguration { DisplayName = "Crime" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }
    }
            },


            { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_PRODUCT).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                    { "PRODUCT", new GridColumnConfiguration { DisplayName = "Product" } },
                    { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
                }}
            },


             { nameof(ART_ST_YEARLY_AML_PER_TRRANSACTION_TYPE).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "TRRANSACTION_TYPE", new GridColumnConfiguration { DisplayName = "Transaction Type" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } }
                }}
            },

            { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
                }}
            },

            { nameof(ART_ST_YEARLY_SANCTION_PER_YEAR).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "year", new GridColumnConfiguration { DisplayName = "Year" } },

                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } }
                }}
            },

            { nameof(ART_ST_YEARLY_SANCTION_PER_PRODUCT).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "year", new GridColumnConfiguration { DisplayName = "Year" } },

                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } }
                }}
            },

            { nameof(ART_ST_YEARLY_SANCTION_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "year", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } }
                }}
            },

            { nameof(ART_ST_YEARLY_TOP_GOAML_BRANCHES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                   "RN"
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                     { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REPORT_TYPE", new GridColumnConfiguration { DisplayName = "Report Type" } },
                 { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                  { "MONTHLY_AVG_OF_ALERTS_OR_CASES", new GridColumnConfiguration { DisplayName = "Monthly Avergae Of Alerts Of Cases" } },
                   { "RN", new GridColumnConfiguration { DisplayName = "RN" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                }}
                
            },


             { nameof(ART_ST_YEARLY_BOTTOM_GOAML_BRANCHES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                     { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REPORT_TYPE", new GridColumnConfiguration { DisplayName = "Report Type" } },
                 { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                  { "MONTHLY_AVG_OF_ALERTS_OR_CASES", new GridColumnConfiguration { DisplayName = "Monthly Avergae Of Alerts Of Cases" } },
                   { "RN", new GridColumnConfiguration { DisplayName = "RN" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                }}
            },

             { nameof(ART_ST_YEARLY_TOP_AML_BRANCHES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                     { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } },
                { "region", new GridColumnConfiguration { DisplayName = "Region" } },
                }}
            },
           

            { nameof(ART_ST_YEARLY_TOP_SANCTION_BRANCHES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                     { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                }}
            },

            { nameof(ART_ST_YEARLY_BOTTOM_AML_BRANCHES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                     { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                     { "region", new GridColumnConfiguration { DisplayName = "Region" } },
                { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
                }}
            },

            { nameof(ART_ST_YEARLY_BOTTOM_SANCTION_BRANCHES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                      { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                      { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
                }}
            },
            ///////////////////
            ///
            
          /*  { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_PRODUCT).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                    { "PRODUCT", new GridColumnConfiguration { DisplayName = "Product" } },
                    { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
                }}
            },*/

           /* { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },*/

            { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
                DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "PRODUCT", new GridColumnConfiguration { DisplayName = "Product" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_TYPE).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REPORT_TYPE", new GridColumnConfiguration { DisplayName = "Report Type" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_STAFF_GOAML_AML_PER_CRIME).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "CRIME", new GridColumnConfiguration { DisplayName = "Crime" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_STAFF_GOAML_AML_PER_PRODUCT).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames =  new Dictionary<string, GridColumnConfiguration>
                {
                    { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                    { "PRODUCT", new GridColumnConfiguration { DisplayName = "Product" } },
                    { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
                }}
            },

            { nameof(ART_ST_YEARLY_STAFF_GOAML_AML_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_PRODUCT).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "PRODUCT", new GridColumnConfiguration { DisplayName = "Product" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },

            { nameof(ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_TYPE).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REPORT_TYPE", new GridColumnConfiguration { DisplayName = "Report Type" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },



            { nameof(ART_ST_YEARLY_AML_PER_REGION).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                 { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            }}
            },



            { nameof(ART_ST_YEARLY_UNUSAL_ACTIVITIES).ToLower(), new ReportConfig {
               SkipList =  new List<string>
                {
                },
               DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "NUMBER_OF_ALERTS", new GridColumnConfiguration { DisplayName = "Number Of Alerts" } },
                { "TYPE_OF_ACTIVITY", new GridColumnConfiguration { DisplayName = "Type of Acivity" } }
            }}
            },
        };

    }
}

