
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.AML_ANALYSIS;

using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.DGAUDIT;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Controllers.SEG;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using CsvHelper;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Data.TIZONE2;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using System.Text;
using static ART_PACKAGE.Helpers.CustomReport.DbContextExtentions;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly AuthContext db;
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext _ecm;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly ArtAuditContext _dbAd;
        private readonly ArtGoAmlContext _dbGoAml;
        private readonly SegmentationContext _seg;
        private readonly List<string>? modules;
        private readonly FTIContext _fti;
        private readonly TIZONE2Context ti;
        private readonly KYCContext _kyc;
        private readonly DBFactory dBFactory;
        private DbContext dbInstance;
        private readonly AmlAnalysisContext _amlanalysis;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration, AuthContext db, DBFactory dBFactory)
        {
            this.connections = connections;
            _csvSrv = csvSrv;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            modules = _configuration.GetSection("Modules").Get<List<string>>();
            if (modules.Contains("SASAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                SasAmlContext amlService = scope.ServiceProvider.GetRequiredService<SasAmlContext>();
                _dbAml = amlService;
            }
            if (modules.Contains("ECM"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                EcmContext ecmService = scope.ServiceProvider.GetRequiredService<EcmContext>();
                _ecm = ecmService;
            }
            if (modules.Contains("DGAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtDgAmlContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
                _dgaml = dgamlService;
            }


            if (modules.Contains("FTI"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                FTIContext fticontext = scope.ServiceProvider.GetRequiredService<FTIContext>();
                TIZONE2Context _ti = scope.ServiceProvider.GetRequiredService<TIZONE2Context>();
                _fti = fticontext;
                ti = _ti;
            }
            if (modules.Contains("GOAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtGoAmlContext goamlcontext = scope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();
                _dbGoAml = goamlcontext;

            }
            if (modules.Contains("DGAUDIT"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtAuditContext auditcontext = scope.ServiceProvider.GetRequiredService<ArtAuditContext>();
                _dbAd = auditcontext;

            }
            if (modules.Contains("SEG"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                SegmentationContext seg = scope.ServiceProvider.GetRequiredService<SegmentationContext>();
                _seg = seg;
            }
            if (modules.Contains("KYC"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                KYCContext kyc = scope.ServiceProvider.GetRequiredService<KYCContext>();
                _kyc = kyc;
            }
            if (modules.Contains("AMLANALYSIS"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                AmlAnalysisContext amlanalysis = scope.ServiceProvider.GetRequiredService<AmlAnalysisContext>();
                _amlanalysis = amlanalysis;
            }
            this.db = db;
            this.dBFactory = dBFactory;
        }
        public override Task OnConnectedAsync()
        {

            string? user = Context.User.Identity.Name;
            connections.AddConnctionIdFor(user, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task KeepAlive()
        {
            await Clients.Caller.SendAsync("iAmAlive");
        }


        public async Task Export(ExportDto<object> para, string controller, string method, List<string> @params)
        {

            if (nameof(ReportController).ToLower().Replace("controller", "") == controller.ToLower())
            {
                if (method == "MyReports")
                {
                    await _csvSrv.Export<ArtSavedCustomReport, ReportController>(db, Context.User.Identity.Name, para);
                }
                else
                {
                    await ExportCustomReport(para);
                }

            }

            #region SASAML
            if (nameof(AlertDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlAlertDetailView, AlertDetailsController, long?>(_dbAml, Context.User.Identity.Name, para, nameof(ArtAmlAlertDetailView.AlertId));
            if (nameof(TriageController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlTriageView, TriageController, string>(_dbAml, Context.User.Identity.Name, para, nameof(ArtAmlTriageView.AlertedEntityNumber));
            if (nameof(CasesDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlCaseDetailsView, CasesDetailsController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(CustomersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlCustomersDetailsView, CustomersController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(RiskAssessmentController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtRiskAssessmentView, RiskAssessmentController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(HighRiskController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlHighRiskCustView, HighRiskController>(_dbAml, Context.User.Identity.Name, para);

            #endregion

            #region ECM
            if (nameof(SystemPerformanceController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtSystemPerformance, SystemPerformanceController>(_ecm, Context.User.Identity.Name, para);
            if (nameof(UserPerformanceController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtUserPerformance, UserPerformanceController>(_ecm, Context.User.Identity.Name, para);
            #endregion

            #region DGAML
            if (nameof(DGAMLAlertDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtDgAmlAlertDetailView, DGAMLAlertDetailsController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLArtExternalCustomerDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtExternalCustomerDetailView, DGAMLArtExternalCustomerDetailsController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLArtScenarioAdminController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtScenarioAdminView, DGAMLArtScenarioAdminController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLArtScenarioHistoryController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtScenarioHistoryView, DGAMLArtScenarioHistoryController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLArtSuspectDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtSuspectDetailView, DGAMLArtSuspectDetailsController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLCasesDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtDgAmlCaseDetailView, DGAMLCasesDetailsController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLCustomersDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtDgAmlCustomerDetailView, DGAMLCustomersDetailsController>(_dgaml, Context.User.Identity.Name, para);
            if (nameof(DGAMLTriageController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtDgAmlTriageView, DGAMLTriageController>(_dgaml, Context.User.Identity.Name, para);
            #endregion

            #region Audit
            if (nameof(ListOfUserController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUser, ListOfUserController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfGroupsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfGroup, ListOfGroupsController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfRoleController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfRole, ListOfRoleController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfUsersAndGroupsRoleController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUsersAndGroupsRole, ListOfUsersAndGroupsRoleController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfUsersGroupController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUsersGroup, ListOfUsersGroupController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfUsersRolesController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUsersRole, ListOfUsersRolesController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListGroupsRolesSummaryController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListGroupsRolesSummary, ListGroupsRolesSummaryController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListGroupsSubGroupsSummaryController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListGroupsSubGroupsSummary, ListGroupsSubGroupsSummaryController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfDeletedUsersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfDeletedUser, ListOfDeletedUsersController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(LastLoginPerDayController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<LastLoginPerDayView, LastLoginPerDayController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(AuditUsersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtUsersAuditView, AuditUsersController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(AuditGroupsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtGroupsAuditView, AuditGroupsController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(AuditRolesController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtRolesAuditView, AuditRolesController>(_dbAd, Context.User.Identity.Name, para);

            #endregion

            #region FTI
            if (nameof(EcmAuditTrialController).ToLower().Replace("controller", "") == controller.ToLower()) await ExportForAuditTrial(para);
            if (nameof(EcmWorkflowProgController).ToLower().Replace("controller", "") == controller.ToLower()) await ExportForWorkflowProg(para);
            if (nameof(ACPostingsAccountController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiAcpostingsAccReport, ACPostingsAccountController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ACPostingsCustomersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiAcpostingsCustReport, ACPostingsCustomersController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ActivityController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiActivityReport, ActivityController>(_fti, Context.User.Identity.Name, para);
            if (nameof(AdvancePaymentUtilizationController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiAdvancePaymentUtilizationReport, AdvancePaymentUtilizationController>(_fti, Context.User.Identity.Name, para);
            if (nameof(AmortizationController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiAmortizationReport, AmortizationController>(_fti, Context.User.Identity.Name, para);
            if (nameof(DiaryExceptionsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiDiaryExceptionsReport, DiaryExceptionsController>(_fti, Context.User.Identity.Name, para);
            if (nameof(EcmTransactionsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiEcmTransactionsReport, EcmTransactionsController>(_fti, Context.User.Identity.Name, para);
            if (nameof(FinancingInterestAccrualsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiFinanInterAccrual, FinancingInterestAccrualsController>(_fti, Context.User.Identity.Name, para);
            if (nameof(FullJournalController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiFullJournalReport, FullJournalController>(_fti, Context.User.Identity.Name, para);
            if (nameof(InterfaceDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiInterfaceDetailsReport, InterfaceDetailsController>(_fti, Context.User.Identity.Name, para);
            if (nameof(MasterEventHistoryController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiMasterEventHistory, MasterEventHistoryController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OSActivityController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiOsActivityReport, OSActivityController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OSLiabilityController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiOsLiabilityReport, OSLiabilityController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OSTransactionsAwaitiApprlController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiOsTransAwaitiApprlReport, OSTransactionsAwaitiApprlController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OSTransactionsByGatewayController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiOsTransByGatewayReport, OSTransactionsByGatewayController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OSTransactionsByNonPriController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiOsTransByNonpriReport, OSTransactionsByNonPriController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OSTransactionsByPrincipalController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiOsTransByPrincipalReport, OSTransactionsByPrincipalController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OurChargesByCustomerController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiChargesByCustReport, OurChargesByCustomerController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OurChargesByMasterController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiChargesByMasterReport, OurChargesByMasterController>(_fti, Context.User.Identity.Name, para);
            if (nameof(OurChargesDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiChargesDetailsReport, OurChargesDetailsController>(_fti, Context.User.Identity.Name, para);
            if (nameof(PeriodicCHRGsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiPeriodicChrgsReport, PeriodicCHRGsController>(_fti, Context.User.Identity.Name, para);
            if (nameof(PeriodicCHRGSPaymentController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiPeriodicChrgsPayReport, PeriodicCHRGSPaymentController>(_fti, Context.User.Identity.Name, para);
            if (nameof(WatchlistOSCheckController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiWatchlistOsCheckReport, WatchlistOSCheckController>(_fti, Context.User.Identity.Name, para);
            if (nameof(SystemTailoringController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtTiSystemTailoringReport, SystemTailoringController>(_fti, Context.User.Identity.Name, para);
            #endregion

            #region GOAML
            if (nameof(GOAMLReportIndicatorDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtGoamlReportsIndicator, GOAMLReportIndicatorDetailsController>(_dbGoAml, Context.User.Identity.Name, para);
            if (nameof(GOAMLReportsDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtGoamlReportsDetail, GOAMLReportsDetailsController>(_dbGoAml, Context.User.Identity.Name, para);
            if (nameof(GOAMLReportsSuspectController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtGoamlReportsSusbectParty, GOAMLReportsSuspectController>(_dbGoAml, Context.User.Identity.Name, para);

            #endregion

            #region SEG
            if (nameof(AllSegmentsOutliersNewController).ToLower().Replace("controller", "") == controller.ToLower()) await ExportSegOutliers(para, @params);
            #endregion
            #region KYC
            if (nameof(ArtAuditCorporateController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAuditCorporateView, ArtAuditCorporateController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtAuditIndividualsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAuditIndividualsView, ArtAuditIndividualsController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycExpiredIdController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycExpiredId, ArtKycExpiredIdController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighExpiredController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighExpired, ArtKycHighExpiredController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighOneMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighOneMonth, ArtKycHighOneMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighThreeMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighThreeMonth, ArtKycHighThreeMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighTwoMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighTwoMonth, ArtKycHighTwoMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowExpiredController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowExpired, ArtKycLowExpiredController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowOneMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowOneMonth, ArtKycLowOneMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowThreeMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowThreeMonth, ArtKycLowThreeMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowTwoMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowTwoMonth, ArtKycLowTwoMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumExpiredController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumExpired, ArtKycMediumExpiredController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumOneMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumOneMonth, ArtKycMediumOneMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumThreeMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumThreeMonth, ArtKycMediumThreeMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumTwoMonthController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumTwoMonth, ArtKycMediumTwoMonthController>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycSummaryByRiskController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycSummaryByRisk, ArtKycSummaryByRiskController>(_kyc, Context.User.Identity.Name, para);

            #endregion
            if (nameof(AML_ANALYSISController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlAnalysisViewTb, AML_ANALYSISController>(_amlanalysis, Context.User.Identity.Name, para);


        }

        private async Task ExportSegOutliers(ExportDto<object> para, List<string> @params)
        {
            int monthKey = Convert.ToInt32(@params.First());
            string desc = @params[1];
            string seg = @params[2];
            IQueryable<ArtAllSegmentsOutliersTb> data = _seg.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == monthKey.ToString() && x.PartyTypeDesc == desc && x.SegmentSorted == seg);
            await _csvSrv.ExportAllCsv<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController, object>(data, Context.User.Identity.Name, para);
        }
        private async Task ExportForAuditTrial(ExportDto<object> para)
        {
            IQueryable<ArtTiEcmAuditReport> data = _fti.ArtTiEcmAuditReports.AsQueryable().CallData(para.Req).Data;
            var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.FtiReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
            IEnumerable<ExportDto> after = res.Select(x =>
            {
                IQueryable<string?>? ListOfMatchingEcm = ti.Masters.Where(c => c.MasterRef == x.Key.FtiReference)?.Join(ti.Notes, c => c.Key97, co => co.MasterKey, (c, co) => co.NoteText);
                return new ExportDto
                {
                    Record = x.FirstOrDefault(),
                    Note = ListOfMatchingEcm?.Select(e => e).ToList(),

                };

            });
            MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
            {


                sw.Write("");
                System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmAuditReport).GetProperties();

                foreach (System.Reflection.PropertyInfo item in props)
                {
                    cw.WriteField(item.Name);
                }

                cw.WriteField("Note");


                cw.NextRecord();
                foreach (ExportDto? elm in after)
                {
                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        cw.WriteField(prop.GetValue(elm.Record));
                    }

                    cw.NextRecord();
                    for (int i = 0; i < elm.Note.Count; i++)
                    {
                        foreach (System.Reflection.PropertyInfo prop in props)
                        {
                            cw.WriteField("");
                        }

                        cw.WriteField(elm.Note[i]);

                        cw.NextRecord();
                    }
                    cw.NextRecord();
                }
            }
            string FileName = nameof(EcmAuditTrialController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
            await Clients.Caller
                              .SendAsync("csvRecevied", stream.ToArray(), FileName);
        }


        private async Task ExportCustomReport(ExportDto<object> exportDto)
        {
            string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
            ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
            List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column,
                type = x.JsType,
                isNullable = x.IsNullable,
            }).ToArray();
            string filter = exportDto.Req.Filter.GetFiltersString(dbtype, columns);
            List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;

            List<List<object>> filterCells = exportDto.Req.Filter.GetFilterTextForCsv();

            DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
            byte[] bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata?.Select(x => x.Data).ToList(), filterCells);
            string FileName = Report.Name + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
            await Clients.Clients(connections.GetConnections(Context.User.Identity.Name))
                                .SendAsync("csvRecevied", bytes, FileName);
        }

        private async Task ExportForWorkflowProg(ExportDto<object> para)
        {

            IQueryable<ArtTiEcmWorkflowProgReport> data = _fti.ArtTiEcmWorkflowProgReports.AsQueryable().CallData(para.Req).Data;
            var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
            IEnumerable<ExportDtoWorkflowProg> after = res.Select(x =>
            {
                IQueryable<ArtTiEcmWorkflowProgReportOld>? ListOfMatchingEcm = _fti.ArtTiEcmWorkflowProgReportOlds.Where(o => o.EcmReference == x.Key.EcmReference && x.Key.CaseStatCd == o.CaseStatCd && x.Key.EventSteps == o.EventSteps && x.Key.StepStatus == o.StepStatus);
                return new ExportDtoWorkflowProg
                {
                    Record = x.FirstOrDefault(),
                    Comments = ListOfMatchingEcm?.Select(e => e.Comments).ToList(),
                    Note = ListOfMatchingEcm?.Select(e => e.Note).ToList(),
                    NoteCreationTime = ListOfMatchingEcm?.Select(e => e.NoteCreationTime).ToList()
                };

            });
            MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
            {


                sw.Write("");
                System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmWorkflowProgReport).GetProperties();

                foreach (System.Reflection.PropertyInfo item in props)
                {
                    cw.WriteField(item.Name);
                }
                cw.WriteField("Comments");
                cw.WriteField("Note");
                cw.WriteField("NoteCreationTime");

                cw.NextRecord();
                foreach (ExportDtoWorkflowProg? elm in after)
                {
                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        cw.WriteField(prop.GetValue(elm.Record));
                    }

                    cw.NextRecord();
                    for (int i = 0; i < elm.Comments.Count; i++)
                    {
                        foreach (System.Reflection.PropertyInfo prop in props)
                        {
                            cw.WriteField("");
                        }
                        cw.WriteField(elm.Comments[i]);
                        cw.WriteField(elm.Note[i]);
                        cw.WriteField(elm.NoteCreationTime[i]);
                        cw.NextRecord();
                    }
                }
            }
            string FileName = nameof(EcmAuditTrialController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
            await Clients.Caller
                              .SendAsync("csvRecevied", stream.ToArray(), FileName);
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string? user = Context.User.Identity.Name;
            connections.RemoveConnection(user, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public class ExportDto
        {
            public ArtTiEcmAuditReport Record { get; set; }

            public List<string> Note { get; set; }

        }
        public class ExportDtoWorkflowProg
        {
            public ArtTiEcmWorkflowProgReport Record { get; set; }
            public List<string> Comments { get; set; }
            public List<string> Note { get; set; }
            public List<DateTime?> NoteCreationTime { get; set; }
        }
    }
}
