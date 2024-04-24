using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.DGAUDIT;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using Data.Data.ARTDGAML;
using Data.Data.Audit;
using Data.Data.FTI;
using Data.Services.Grid;


namespace ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper
{
    public class DropDownMapper : IDropDownMapper
    {
        private readonly IDropDownService _dropDown;
        private readonly FTIContext fti;
        private readonly ArtDgAmlContext artDgaml_;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly List<string>? modules;

        public DropDownMapper(IDropDownService dropDown, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _dropDown = dropDown;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            modules = _configuration.GetSection("Modules").Get<List<string>>();
            IServiceScope scope = _serviceScopeFactory.CreateScope();


            if (modules.Contains("FTI"))
                fti = scope.ServiceProvider.GetRequiredService<FTIContext>();


            if (modules.Contains("DGAML"))
                artDgaml_ = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();


        }
        public Dictionary<string, List<SelectItem>>? GetDorpDownForReport(string controller)
        {
            List<SelectItem> pipList = new() { new SelectItem { text = "Y", value = "Y" }, new SelectItem { text = "N", value = "N" } };
            List<SelectItem> actionList = new() { new SelectItem { text = "Add", value = "Add" }, new SelectItem { text = "Update", value = "Update" }, new SelectItem { text = "Delete", value = "Delete" } };
            Dictionary<string, List<SelectItem>>? ftiReportDropDown = GetFtiDropDowns(controller);
            if (ftiReportDropDown is not null)
                return ftiReportDropDown;


            return controller switch
            {
                //branch name,Alert status, Alert type, scenario name, queue, owner

                nameof(AlertDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown() },

                    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown() },
                    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown()},


                    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown()    },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown() },
                    {"PoliticallyExposedPersonInd".ToLower(), pipList},
                },
                nameof(CasesDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                      {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                      {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() },
                      {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown() },
                      {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown() },
                      {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown() },
                      {"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown() },
                      {"Owner".ToLower(),_dropDown.GetOwnerDropDown() },
                     {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown() }
                },
                nameof(CustomersController) => new Dictionary<string, List<SelectItem>>
                {
                      {"CustomerType".ToLower(),_dropDown.GetPartyTypeDropDown() },
                      {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                      {"NonProfitOrgInd".ToLower(),pipList },
                      {"PoliticallyExposedPersonInd".ToLower(),pipList },
                      {"CharityDonationsInd".ToLower(),pipList },
                      {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown() },
                      {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                      {"IndustryDesc".ToLower(),_dropDown.GetIndustryDescDropDown() },
                      {"CustomerIdentificationType".ToLower(),_dropDown.GetCustomerIdentificationTypeDropDown() },
                      {"OccupationDesc".ToLower(),_dropDown.GetOccupationDescDropDown() },
                      {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown() }
                },
                nameof(HighRiskController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    {"PartyIdentificationTypeDesc".ToLower(),_dropDown.GetPartyIdentificationTypeDropDown() },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown()},
                    {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    //{"PoliticallyExposedPersonInd".ToLower(),_dropDown.Getpo().ToDynamicList() },
                    {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown() },
                    {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown() },
                    //{"MailingCityName".ToLower(),_dropDown.().ToDynamicList() },
                },
                nameof(RiskAssessmentController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    {"AssessmentTypeCd".ToLower(),_dropDown.GetAssessmentTypeDropDown() },
                    {"CreateUserId".ToLower(),_dropDown.GetOwnerDropDown() },
                    {"RiskStatus".ToLower(),_dropDown.GetRiskStatusDropDown() },
                    {"RiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    {"ProposedRiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    {"OwnerUserLongId".ToLower(),_dropDown.GetOwnerDropDown() }
                },
                nameof(TriageController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(), _dropDown.GetBranchNameDropDown() },
                    {"RiskScore".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown() }
                },
                nameof(ArtAuditCorporateController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtAuditIndividualsController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycExpiredIdController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycHighExpiredController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycHighThreeMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycHighTwoMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowExpiredController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowOneMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowThreeMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowTwoMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumExpiredController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumOneMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumThreeMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumTwoMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycSummaryByRiskController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(GOAMLReportIndicatorDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                      {"Indicator".ToLower(),_dropDown.GetReportIndicatorDropDown() },

                },
                nameof(GOAMLReportsDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown()},
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown() },
                    {"Priority".ToLower(),_dropDown.GetReportPriorityDropDown() },
                    {"Rentitybranch".ToLower(),_dropDown.GetNonREntityBranchDropDown() },
                },
                //report types, report status, Currency Code Local, priority, Reporting person type
                var value when value == nameof(artgoamlreportsdetailConfig).ToLower() => new Dictionary<string, List<SelectItem>>
                {
                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown()},
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown() },
                    {"Priority".ToLower(),_dropDown.GetReportPriorityDropDown() },
                    {"Currencycodelocal".ToLower(),_dropDown.GetCurrencyCodeDropDown() },
                    {"Reportingpersontype".ToLower(),_dropDown.GetReportPersonTypeDropDown() },
                    //{"Rentitybranch".ToLower(),_dropDown.GetNonREntityBranchDropDown() },
                },
                nameof(GOAMLReportsSuspectController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown() },
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown() },
                    {"Branch".ToLower(),_dropDown.GetReportAcctBranchDropDown() },
                },
                nameof(SystemPerformanceController) => new Dictionary<string, List<SelectItem>>
                {
                    { "CaseType".ToLower()              , _dropDown.GetCaseTypeDropDown()            },
                    {"CaseStatus".ToLower()             , _dropDown.GetSystemCaseStatusDropDown()    },
                    {"Priority".ToLower()               ,  _dropDown.GetPriorityDropDown()          },
                    {"TransactionDirection".ToLower()   ,_dropDown.GetTransDirectionDropDown()      },
                    {"TransactionType".ToLower()        ,_dropDown.GetTransTypeDropDown()           },
                    {"UpdateUserId".ToLower()           ,_dropDown.GetUpdateUserIdDropDown()        },
                    {"InvestrUserId".ToLower()          ,_dropDown.GetInvestagtorDropDown()         },
                },
                nameof(UserPerformanceController) => new Dictionary<string, List<SelectItem>>
                {
                    {"CaseTypeCd".ToLower()              , _dropDown.GetCaseTypeDropDown()        },
                    {"CaseStatus".ToLower()             , _dropDown.GetUserCaseStatusDropDown()     },
                    {"Priority".ToLower()               ,  _dropDown.GetPriorityDropDown()        },
                },
                nameof(AuditGroupsController) => new Dictionary<string, List<SelectItem>>
                {
                 {nameof(ArtGroupsAuditView.GroupName            ).ToLower(), _dropDown.GetGroupAudNameDropDown() },
                 {nameof(ArtGroupsAuditView.CreatedBy            ).ToLower(), _dropDown.GetUserAudNameDropDown()  },
                 {nameof(ArtGroupsAuditView.LastUpdatedBy        ).ToLower(), _dropDown.GetUserAudNameDropDown()  },
                 {nameof(ArtGroupsAuditView.SubGroupNames        ).ToLower(), _dropDown.GetGroupAudNameDropDown() },
                 {nameof(ArtGroupsAuditView.RoleNames            ).ToLower(), _dropDown.GetRoleAudNameDropDown()  },
                 {nameof(ArtGroupsAuditView.MemberUsers          ).ToLower(), _dropDown.GetMemberUsersDropDown()  },
                 {nameof(ArtGroupsAuditView.Action               ).ToLower(), actionList },
                },
                nameof(AuditRolesController) => new Dictionary<string, List<SelectItem>>
                {
                 {nameof(ArtRolesAuditView.GroupNames)       .ToLower()    , _dropDown.GetGroupAudNameDropDown()},
                 {nameof(ArtRolesAuditView.CreatedBy)        .ToLower()    , _dropDown.GetUserAudNameDropDown() },
                 {nameof(ArtRolesAuditView.LastUpdatedBy)    .ToLower()    , _dropDown.GetUserAudNameDropDown() },
                 {nameof(ArtRolesAuditView.RoleName)         .ToLower()    , _dropDown.GetRoleAudNameDropDown() },
                 {nameof(ArtRolesAuditView.MemberUsers)      .ToLower()    , _dropDown.GetMemberUsersDropDown() },
                 {nameof(ArtRolesAuditView.Action)           .ToLower()    , actionList  },
                },
                nameof(AuditUsersController) => new Dictionary<string, List<SelectItem>>
                {
                 {nameof(ArtUsersAuditView.GroupNames)      .ToLower()     , _dropDown.GetGroupAudNameDropDown() },
                 {nameof(ArtUsersAuditView.CreatedBy)       .ToLower()     , _dropDown.GetUserAudNameDropDown()  },
                 {nameof(ArtUsersAuditView.LastUpdatedBy)   .ToLower()     , _dropDown.GetUserAudNameDropDown()  },
                 {nameof(ArtUsersAuditView.RoleNames)       .ToLower()     , _dropDown.GetRoleAudNameDropDown()  },
                 {nameof(ArtUsersAuditView.DomainAccounts)  .ToLower()     , _dropDown.GetMemberUsersDropDown()  },
                 {nameof(ArtUsersAuditView.UserName)        .ToLower()     , _dropDown.GetRoleAudNameDropDown()  },
                 {nameof(ArtUsersAuditView.Action)          .ToLower()     , actionList },
                },
                nameof(LastLoginPerDayController) => new Dictionary<string, List<SelectItem>>
                {
                 {nameof(LastLoginPerDayView.AppName)        .ToLower()    , _dropDown.GetAppNameDropDown()     },
                 {nameof(LastLoginPerDayView.DeviceName)     .ToLower()    , _dropDown.GetDeviceNameDropDown()  },
                 {nameof(LastLoginPerDayView.DeviceType)     .ToLower()    , _dropDown.GetDeviceTypeDropDown()  },
                 {nameof(LastLoginPerDayView.UserName)       .ToLower()    , _dropDown.GetRoleAudNameDropDown() },
                },
                nameof(ListGroupsRolesSummaryController) => new Dictionary<string, List<SelectItem>>
                {
                  {nameof(ListGroupsRolesSummary.GroupName)  .ToLower()     , _dropDown.GetGroupNameDropDown()   },
                  {nameof(ListGroupsRolesSummary.RoleName)   .ToLower()     , _dropDown.GetRoleAudNameDropDown() },
                },
                nameof(ListGroupsSubGroupsSummaryController) => new Dictionary<string, List<SelectItem>>
                {
                  {nameof(ListGroupsSubGroupsSummary.GroupName)     .ToLower()      , _dropDown.GetGroupNameDropDown()    },
                  {nameof(ListGroupsSubGroupsSummary.SubGroupName)  .ToLower()      , _dropDown.GetGroupAudNameDropDown() },
                },
                nameof(ListOfDeletedUsersController) => new Dictionary<string, List<SelectItem>>
                {
                  {nameof(ListOfDeletedUser.UserName)  .ToLower()  , _dropDown.GetUserAudNameDropDown() },
                   {nameof(ListOfDeletedUser.UserType)  .ToLower() , _dropDown.GetUserTypeDropDown()    },
                   {nameof(ListOfDeletedUser.CreatedBy) .ToLower() , _dropDown.GetUserAudNameDropDown() },
                },
                nameof(ListOfGroupsController) => new Dictionary<string, List<SelectItem>>
                {
                  { "GroupName".ToLower(),    _dropDown.GetGroupNameDropDown()  },
                  { "GroupType".ToLower(),    _dropDown.GetGroupTypeDropDown()  },
                  { "CreatedBy".ToLower(),    _dropDown.GetUserAudNameDropDown()},
                  { "LastUpdatedBy".ToLower(),_dropDown.GetUserAudNameDropDown()},
                },
                nameof(ListOfRoleController) => new Dictionary<string, List<SelectItem>>
                {
                  { "RoleName".ToLower(),     _dropDown.GetRoleNameDropDown()    },
                  { "RoleType".ToLower(),     _dropDown.GetRoleTypeDropDown()    },
                  { "CreatedBy".ToLower(),    _dropDown.GetUserAudNameDropDown() },
                  { "LastUpdatedBy".ToLower(),_dropDown.GetUserAudNameDropDown() },
                },
                nameof(ListOfUserController) => new Dictionary<string, List<SelectItem>>
                {
                  { "UserName".ToLower(),     _dropDown.GetUserNameDropDown()    },
                  { "UserType".ToLower(),     _dropDown.GetUserTypeDropDown()    },
                  { "CreatedBy".ToLower(),    _dropDown.GetUserAudNameDropDown() },
                  { "LastUpdatedBy".ToLower(),_dropDown.GetUserAudNameDropDown() },
              },
                nameof(ListOfUsersAndGroupsRoleController) => new Dictionary<string, List<SelectItem>>
                {
                   { "UserName".ToLower(),     _dropDown.GetUserNameDropDown()    },
                   { "MemberOfGroup".ToLower(),_dropDown.GetGroupAudNameDropDown()},
                   { "RoleOfGroup".ToLower(),  _dropDown.GetRoleAudNameDropDown() },
                },
                nameof(ListOfUsersGroupController) => new Dictionary<string, List<SelectItem>>
                {
                   { "UserName".ToLower(),     _dropDown.GetUserNameDropDown()    },
                   { "MemberOfGroup".ToLower(),_dropDown.GetGroupAudNameDropDown()},
                },
                nameof(ListOfUsersRolesController) => new Dictionary<string, List<SelectItem>>
                {
                   { "UserName".ToLower(),_dropDown.GetUserNameDropDown()   },
                   { "UserRole".ToLower(),_dropDown.GetRoleAudNameDropDown()},
                },
                /*DGAML*/
                nameof(DGAMLAlertDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                   {"AlertStatus".ToLower()                    ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x => x.AlertStatus)          .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()        },
                   {"AlertSubcategory".ToLower()                    ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.AlertSubcategory) .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()        },
                   {"AlertCategory".ToLower()                    ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.AlertCategory)       .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()        },
                   //{"OwnerUserid".ToLower()                  ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.)                      .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()                     },
                   {"BranchName".ToLower()                     ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.BranchName)            .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()                             },
                   {"ScenarioName".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.ScenarioName)          .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"ClosedUserId".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.ClosedUserId)          .Distinct()   .Where(x=> x != null)        .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"CloseUserName".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.CloseUserName)        .Distinct()   .Where(x=> x != null)        .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"CloseReason".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.CloseReason)            .Distinct()   .Where(x=> x != null)        .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"PoliticallyExposedPersonInd".ToLower()    ,new List<SelectItem>(){ new SelectItem { text = "Y", value = "Y" } ,new SelectItem { text = "N", value = "N" }}.ToList()                                               },
                   {"EmpInd".ToLower()    , new List<SelectItem>(){ new SelectItem { text = "Y", value = "Y" } ,new SelectItem { text = "N", value = "N" }}.ToList() }

                },
                nameof(DGAMLArtExternalCustomerDetailsController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"BranchName".ToLower(),_dropDown.GetDGExternalCustomerBranchNameDropDown() },
                    {nameof(ArtExternalCustomerDetailView.CitizenshipCountryName).ToLower(),_dropDown .GetDGCitizenshipCountryNameDropDown() },
                    {nameof(ArtExternalCustomerDetailView.ResidenceCountryName).ToLower(),_dropDown .GetDGresidenceCountryNameDropDown()},
                // {"CntryName".ToLower(),_dropDown.GetDGStreetCountryNameDropDown() .ToDynamicList() },
                    {"CityName".ToLower(),_dropDown .GetDGCityNameDropDown()},
                    {"IdentTypeDesc".ToLower(),_dropDown.GetDGCustomerIdentificationTypeDropDown() },
                    {"ExtCustTypeDesc".ToLower(),_dropDown.GetDGCustomerTypeDropDown() },

                },
                nameof(DGAMLArtScenarioAdminController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"ScenarioName".ToLower(),_dropDown         .GetDGScenarioNameDropDown()         },
                    {"ScenarioCategory".ToLower(),_dropDown     .GetDGScenarioCategoryDropDown()     },
                    {"ScenarioStatus".ToLower(),_dropDown       .GetDGScenarioStatusDropDown()       },
                    {"ProductType".ToLower(),_dropDown          .GetDGProductTypeDropDown()          },
                    {"ScenarioType".ToLower(),_dropDown         .GetDGScenarioTypeDropDown()         },
                    {"ScenarioFrequency".ToLower(),_dropDown    .GetDGScenarioFrequencyDropDown()    },
                    {"ObjectLevel".ToLower(),_dropDown          .GetDGObjectLevelDropDown()          },
                    {"AlarmType".ToLower(),_dropDown            .GetDGAlarmTypeDropDown()            },
                    {"AlarmCategory".ToLower(),_dropDown        .GetDGAlarmCategoryDropDown()        },
                    {"AlarmSubcategory".ToLower(),_dropDown     .GetDGAlarmSubcategoryDropDown()     },
                    {"RiskFact".ToLower(),_dropDown             .GetDGRiskFactDropDown()             },
                    {"CreateUserId".ToLower(),_dropDown         .GetDGRoutineCreateUserIdDropDown()  },
                    {"ParmValue".ToLower(),_dropDown            .GetDGParmValueDropDown()            },
                    {"ParmTypeDesc".ToLower(),_dropDown         .GetDGParmTypeDescDropDown()         },
                },
                nameof(DGAMLArtScenarioHistoryController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"CreateUserId".ToLower(),_dropDown.GetDGCreateUserIdDropDown() },
                    {"RoutineName".ToLower(),_dropDown.GetDGScenarioNameDropDown() },
                },
                nameof(DGAMLArtSuspectDetailsController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"BranchName".ToLower(),_dropDown           .GetDGBranchNameDropDown()          },
                    {"ProfileRisk".ToLower(),_dropDown          .GetDGProfileRiskDropDown()         },
                    {"OwnerUserid".ToLower(),_dropDown          .GetDGOwnerDropDown()               },
                    {"PoliticalExpPrsnInd".ToLower(),_dropDown  .GetDGPoliticalExpPrsnIndDropDown() },
                    {"RiskClassification".ToLower(),_dropDown   .GetDGRiskClassificationDropDown()  },
                    {"CitizenCntryName".ToLower(),_dropDown     .GetDGCitizenCountryNameDropDown()  },
                    {"CustIdentTypeDesc".ToLower(),_dropDown    .GetDGCustIdentTypeDescDropDown()   },
                    {"OccupDesc".ToLower(),_dropDown            .GetDGOccupDescDropDown()           },
                },
                nameof(DGAMLCasesDetailsController) => new Dictionary<string, List<SelectItem>>
                 {
                    //commented untill resolve drop down 
           {"BranchName".ToLower()                 ,artDgaml_.ArtDgAmlCaseDetailViews.Select(x=>x.BranchName)       .Distinct()         .Where(x=>x!=null).Select(x => new SelectItem { text = x, value = x }).ToList()          },
           {"CaseStatus".ToLower()                 ,artDgaml_.ArtDgAmlCaseDetailViews.Select(x=>x.CaseStatus)       .Distinct()     .Where(x=>x!=null)    .Select(x => new SelectItem { text = x, value = x }).ToList()          },
           {"CasePriority".ToLower()               ,artDgaml_.ArtDgAmlCaseDetailViews.Select(x=>x.CasePriority)     .Distinct()     .Where(x=>x!=null)    .Select(x => new SelectItem { text = x, value = x }).ToList()          },
           {"CaseCategory".ToLower()               ,artDgaml_.ArtDgAmlCaseDetailViews.Select(x=>x.CaseCategory)     .Distinct()     .Where(x=>x!=null)    .Select(x => new SelectItem { text = x, value = x }).ToList()          },
           {"EntityLevel".ToLower()                ,artDgaml_.ArtDgAmlCaseDetailViews.Select(x=>x.EntityLevel)      .Distinct()     .Where(x=>x!=null)    .Select(x => new SelectItem { text = x, value = x }).ToList()          }
                },
                nameof(DGAMLCustomersDetailsController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"CustomerType".ToLower()                           ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.CustomerType)                   .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"RiskClassification".ToLower()                     ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.RiskClassification)             .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x.ToString(), value = x.ToString() }).ToList() },
                    {"ResidenceCountryName".ToLower()                   ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.ResidenceCountryName)           .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"BranchName".ToLower()                             ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.BranchName)                     .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"IndustryDesc".ToLower()                           ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.IndustryDesc)                   .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CustomerIdentificationType".ToLower()             ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.CustomerIdentificationType)     .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"OccupationDesc".ToLower()                         ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.OccupationDesc)                 .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CitizenshipCountryName".ToLower()                 ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.CitizenshipCountryName)         .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CityName".ToLower()                               ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.CityName)                       .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"MaritalStatusDesc".ToLower()                      ,artDgaml_.ArtDGAMLCustomerDetailViews.Select(x=>x.MaritalStatusDesc)              .Distinct()    .Where(x=>x!=null)  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"NonProfitOrgInd".ToLower()                        ,new List<SelectItem>(){ new SelectItem { text = "Y", value = "Y" } ,new SelectItem { text = "N", value = "N" }}.ToList() },
                    {"PoliticallyExposedPersonInd".ToLower()            ,new List<SelectItem>(){ new SelectItem { text = "Y", value = "Y" } ,new SelectItem { text = "N", value = "N" }}.ToList() },

                },
                nameof(DGAMLTriageController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"BranchName".ToLower()         ,artDgaml_.ArtDGAMLTriageViews.Select(x=>x.BranchName)                   .Distinct()     .Where(x=> x != null).Select(x => new SelectItem { text = x, value = x }).ToList()          },
                    {"RiskScore".ToLower()          ,artDgaml_.ArtDGAMLTriageViews.Select(x=>x.RiskScore)                    .Distinct()     .Where(x=> x != null).Select(x => new SelectItem { text = x, value = x }).ToList()          },
                    {"OwnerUserid".ToLower()        ,artDgaml_.ArtDGAMLTriageViews.Select(x=>x.OwnerUserid)                  .Distinct()     .Where(x=> x != null).Select(x => new SelectItem { text = x, value = x }).ToList()          },
                    {"AlertedEntityLevel".ToLower()        ,artDgaml_.ArtDGAMLTriageViews.Select(x=>x.AlertedEntityLevel)    .Distinct()     .Where(x=> x != null).Select(x => new SelectItem { text = x, value = x }).ToList()          }
                },

                _ => null
            };
        }



        private Dictionary<string, List<SelectItem>>? GetFtiDropDowns(string controller)
        {
            return controller switch
            {
                nameof(ACPostingsAccountController) => new Dictionary<string, List<SelectItem>>
                {
                    { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(ACPostingsCustomersController) => new Dictionary<string, List<SelectItem>>
                {
                    {"MasterRef".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AcctNo".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AccountType".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.AccountType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Shortname".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"DrCrFlg".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.DrCrFlg).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Ccy".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CusMnm".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Spsk".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Spsk).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Mainbanking".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Mainbanking).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "BranchName".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(ActivityController) => new Dictionary<string, List<SelectItem>>
                {
                   {"BranchName".ToLower(), fti.ArtTiActivityReports.Select(x=>x.BranchName).Distinct()    .Where(x=> x != null)   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Team".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Team).Distinct()                .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"MasterRef".ToLower(), fti.ArtTiActivityReports.Select(x=>x.MasterRef).Distinct()      .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Sovalue".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Sovalue).Distinct()          .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"EventRef".ToLower(), fti.ArtTiActivityReports.Select(x=>x.EventRef).Distinct()        .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"EventStatus".ToLower(), fti.ArtTiActivityReports.Select(x=>x.EventStatus).Distinct()  .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Ccy".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Ccy).Distinct()                  .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Address1".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Address1).Distinct()        .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Address12".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Address12).Distinct()      .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Lstmoduser".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Lstmoduser).Distinct()    .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Shortname".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Shortname).Distinct()    .Where(x=> x != null)      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(AdvancePaymentUtilizationController) => new Dictionary<string, List<SelectItem>>
                {
                   {"PrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.PrincipalParty).Distinct()    .Where(x=> x != null)                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"NonPrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.NonPrincipalParty).Distinct()                .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"AdvCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvCurrency).Distinct()      .Where(x=> x != null)                          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"UtilizationCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.UtilizationCurrency).Distinct()          .Where(x=> x != null)      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Branch".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.Branch).Distinct()        .Where(x=> x != null)                                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"AdvReference".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvReference).Distinct()  .Where(x=> x != null)                            .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(AmortizationController) => new Dictionary<string, List<SelectItem>>
                {
                   { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(DiaryExceptionsController) => new Dictionary<string, List<SelectItem>>
                {
                   {"MasterRef".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Product".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Status".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Status).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"BranchName".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.BranchName).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Address1".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"BranchCode".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.BranchCode).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Team".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Team).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Outstccy".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Sovaluedesc".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Sovaluedesc).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Ccy".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(EcmAuditTrialController) => new Dictionary<string, List<SelectItem>>
                {
                   {"EcmReference".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.EcmReference != null).Select(x=>x.EcmReference).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"FtiReference".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.FtiReference != null).Select(x=>x.FtiReference).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   //{"CutomerName".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.CutomerName != null).Select(x=>x.CutomerName).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Product".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.Product != null).Select(x=>x.Product).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Producttype".ToLower(), fti.ArtTiEcmAuditReports.Where(x => x.Producttype != null).Select(x=>x.Producttype).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"BranchId".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.BranchId).Distinct().Where(x=> x != null )                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EcmEvent".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EcmEvent).Distinct().Where(x=> x != null )                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"TransactionCurrency".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"PrimaryOwner".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"CaseStatCd".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"UpdateUserId".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EventName".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventName).Distinct().Where(x=> x != null )                    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EventStatus".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventStatus).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterAssignedTo".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.MasterAssignedTo).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"StepStatus".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.StepStatus).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EventSteps".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventSteps).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(EcmTransactionsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"CaseId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseId).Distinct().Where(x=> x != null )                           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Product".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Producttype".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Producttype).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Behalfofbranch".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Behalfofbranch).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Eventname".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Eventname).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"TransactionCurrency".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"PrimaryOwner".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CaseStatCd".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null )                   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"UpdateUserId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(EcmWorkflowProgController) => new Dictionary<string, List<SelectItem>>
                {
                    {"EcmReference".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmReference).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"FtiReference".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.FtiReference).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    //{"CutomerName".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.CutomerName).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Product".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.Product).Distinct().Where(x=> x != null )                               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ProductType".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ProductType).Distinct().Where(x=> x != null )                       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"BranchId".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.BranchId).Distinct().Where(x=> x != null )                             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EcmEvent".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmEvent).Distinct().Where(x=> x != null )                             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"TransactionCurrency".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"PrimaryOwner".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CaseStatCd".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"UpdateUserId".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EcmRejectionReason".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmRejectionReason).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventName".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventName).Distinct().Where(x=> x != null )                           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventStatus).Distinct().Where(x=> x != null )                       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AssignedTo".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AssignedTo).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"StepStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.StepStatus).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventSteps".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventSteps).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AssignmentType".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AssignmentType).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Lstmoduser".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.Lstmoduser).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"WarningOverridden".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.WarningOverridden).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"InputSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.InputSlaStatus).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AuthorizeSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AuthorizeSlaStatus).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ReviewSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ReviewSlaStatus).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ExternalReviewSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ExternalReviewSlaStatus).Distinct().Where(x=> x != null).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(FinancingInterestAccrualsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.BranchName).Distinct().Where(x=> x != null )            .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"MasterRef".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"Prodcut".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Prodcut).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"Recccy".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Recccy).Distinct().Where(x=> x != null )                    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"Address1".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Address1).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"InterestRateType".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.InterestRateType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList()},
                },
                nameof(FullJournalController) => new Dictionary<string, List<SelectItem>>
                {
                    { "Username".ToLower(), fti.ArtTiFullJournalReports.Select(x=>x.Username).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "MtceType".ToLower(), fti.ArtTiFullJournalReports.Select(x=>x.MtceType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Area".ToLower(), fti.ArtTiFullJournalReports.Select(x => x.Area).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(MasterEventHistoryController) => new Dictionary<string, List<SelectItem>>
                {
                     {"BranchName".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"MasterRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Shortname".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Shortname).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"EventRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.EventRef).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Stepdescr".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Stepdescr).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Status".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Status).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Address1".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Address1).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"StatusEv".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.StatusEv).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Ccy".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Ccy).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList()},
                },
                nameof(OSActivityController) => new Dictionary<string, List<SelectItem>>
                {
                   {"BranchName".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.BranchName).Distinct()     .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Team".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Team).Distinct()                 .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterRef".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.MasterRef).Distinct()       .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Product".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Product).Distinct()           .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Descrip".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Descrip).Distinct()           .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Address1".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Address1).Distinct()         .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Ccy".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Ccy).Distinct()                   .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OSLiabilityController) => new Dictionary<string, List<SelectItem>>
                {
                  {"Gfcun".ToLower(),fti.ArtTiOsLiabilityReports.Select(x=>x.Gfcun).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Sovalue".ToLower(),fti.ArtTiOsLiabilityReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"LiabCcy".ToLower(),fti.ArtTiOsLiabilityReports.Select(x=>x.LiabCcy).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OSTransactionsAwaitiApprlController) => new Dictionary<string, List<SelectItem>>
                {
                  {"Fullname".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null )            .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Descri56".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null )            .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"MasterRef".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"EventReference".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.EventReference).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Status".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Status).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"PcpAddress1".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.PcpAddress1).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"NpcpAddress1".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.NpcpAddress1).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Ccy".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null )                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Lstmoduser".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Lstmoduser).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OSTransactionsByGatewayController) => new Dictionary<string, List<SelectItem>>
                {
                   {"Fullname".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"Address1".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"Sovalue".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"MasterRef".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"Partptd".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"Revolving".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"Outstccy".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList()},
                  {"Ccy".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList()},
                },
                nameof(OSTransactionsByNonPriController) => new Dictionary<string, List<SelectItem>>
                {
                   {"BhalfBrn".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.BhalfBrn).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Address1".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Sovalue".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Descrip".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Descrip).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterRef".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Partptd".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Revolving".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Outstccy".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Ccy".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OSTransactionsByPrincipalController) => new Dictionary<string, List<SelectItem>>
                {
                   {"BhalfBrn".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.BhalfBrn).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Address1".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Sovalue".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Descrip".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Descrip).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterRef".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Partptd".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Revolving".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Outstccy".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Ccy".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OurChargesByCustomerController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Hvbad1".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.Hvbad1).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Gfcun".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.Gfcun).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Longname".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.Longname).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterRef".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OurChargesByMasterController) => new Dictionary<string, List<SelectItem>>
                {
                     {"Hvbad1".ToLower(),fti.ArtTiChargesByMasterReports.Select(x=>x.Hvbad1).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Longname".ToLower(),fti.ArtTiChargesByMasterReports.Select(x=>x.Longname).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"MasterRef".ToLower(),fti.ArtTiChargesByMasterReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(OurChargesDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                     {"Hvbad1".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Hvbad1).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Longname".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Longname).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"MasterRef".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Address1".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Status".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Status).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Descr".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Descr).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ParticChg".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.ParticChg).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventRef".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.EventRef).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Action".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Action).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ChgbasCcy".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.ChgbasCcy).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"SchCcy".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.SchCcy).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"SchRate".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.SchRate).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x.ToString(), value = x.ToString() }).ToList() },
                    {"ChgCcy".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.ChgCcy).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(PeriodicCHRGsController) => new Dictionary<string, List<SelectItem>>
                {
                     {"Fullname".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Sovalue".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Descr".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Descr).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Descri56".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Address1".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"MasterRef".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Payrec".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Payrec).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"AdvArr".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.AdvArr).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"Outstccy".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                     {"AccrueCcy".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.AccrueCcy).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(PeriodicCHRGSPaymentController) => new Dictionary<string, List<SelectItem>>
                {
                       {"Fullname".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Sovalue".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Descr".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Descr).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Descr1".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Descr1).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"MasterRef".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"PcpAddress1".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.PcpAddress1).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Payrec".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Payrec).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    //{"AdvArr".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.adv).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Outstccy".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"NpcpAddress1".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.NpcpAddress1).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"SchCcy".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.SchCcy).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AccrueCcy".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.AccrueCcy).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(SystemTailoringController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Paramsetdescr".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Paramsetdescr).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Prodlongname".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Prodlongname).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Eventlongname".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Eventlongname).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Attachment".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Attachment).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Mappingtype".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Mappingtype).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Templateid".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Templateid).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Optional".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Optional).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Templatedescr".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Templatedescr).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(WatchlistOSCheckController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Fullname".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Descri56".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"MasterRef".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Pcpaddress1".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Pcpaddress1).Distinct().Where(x=> x != null )     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Npcpaddress1".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Npcpaddress1).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Longna85".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Longna85).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Shortname".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Descr".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Descr).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Status".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Status).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                _ => null
            };
        }
    }
}

