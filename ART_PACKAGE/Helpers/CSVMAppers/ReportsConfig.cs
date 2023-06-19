using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportsConfig
    {
        public static readonly Dictionary<string, ReportConfig> CONFIG = new Dictionary<string, ReportConfig>
        {
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
            },{
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
        };

    }
}

