using ART_PACKAGE.Controllers.CRP;
using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.DGAUDIT;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.FATCA;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Controllers.TRADE_BASE;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.CRP;
using Data.Data.ECM;
using Data.Data.SASAml;
using Data.Data.TRADE_BASE;
using Data.Data.FATCA;
using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly ICsvExport _csvSrv;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly Module _module;



        private readonly UsersConnectionIds connections;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, IServiceScopeFactory serviceScopeFactory, Module _module)
        {
            _csvSrv = csvSrv;
            this._module = _module;
            this.connections = connections;
            _serviceScopeFactory = serviceScopeFactory;

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
        public async Task Export(ExportDto<object> para, string controller)
        {





            /* if (controller.ToLower() == nameof(AlertDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfcfkc.AmlAlertDetailView, AlertDetailsController>(dbfcfkc, Context.User.Identity.Name, para);

             if (controller.ToLower() == nameof(ClearDetectController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbdgwllogs.ClearDetectReport, ClearDetectController>(dbdgwllogs, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(CustomersController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfcfcore.AmlCustomersDetail, CustomersController>(dbfcfcore, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(FATCAAlertsDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfagpdb.ArtFatcaAlert, FATCAAlertsDetailsController>(dbfagpdb, Context.User.Identity.Name, para);

             if (controller.ToLower() == nameof(FATCACasesDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfagpdb.ArtFatcaCace, FATCACasesDetailsController>(dbfagpdb, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(FATCADetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfagpdb.ArtFatcaCustomer, FATCADetailsController>(dbfagpdb, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(GOAMLReportIndicatorDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbgoaml.GoamlReportsIndicator, GOAMLReportIndicatorDetailsController>(dbgoaml, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(GOAMLReportsDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbgoaml.GoamlReportsDetail, GOAMLReportsDetailsController>(dbgoaml, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(GOAMLReportsSuspectController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbgoaml.GoamlReportsSusbectParty, GOAMLReportsSuspectController>(dbgoaml, Context.User.Identity.Name, para);

             if (controller.ToLower() == nameof(RiskAssessmentController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfcfcore.AmlRiskAssessment, RiskAssessmentController>(dbfcfcore, Context.User.Identity.Name, para);


             if (controller.ToLower() == nameof(SystemPerformanceController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbdgcmgmt.ArtSystemPerformance, SystemPerformanceController>(dbdgcmgmt, Context.User.Identity.Name, para);
             if (controller.ToLower() == nameof(TriageController).ToLower().Replace("controller", "")) await _csvSrv.Export<dbfcfkc.AmlTriageView, TriageController>(dbfcfkc, Context.User.Identity.Name, para);
             */
            #region ECM
            //ECM
            if (_module.HasModule("ECM"))
            {
                EcmContext _ecm;
                IServiceScope _ecmscope = _serviceScopeFactory.CreateScope();
                EcmContext ecmService = _ecmscope.ServiceProvider.GetRequiredService<EcmContext>();
                _ecm = ecmService;
                if (controller.ToLower() == nameof(AlertedEntitiesController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtAlertedEntity, AlertedEntitiesController>(_ecm, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(CFTConfigController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtCFTConfig, CFTConfigController>(_ecm, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ClearDetectController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtClearDetect, ClearDetectController>(_ecm, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(SystemPerformanceController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtSystemPerformance, SystemPerformanceController>(_ecm, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(UserPerformanceController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtUserPerformance, UserPerformanceController>(_ecm, Context.User.Identity.Name, para);
            }
            #endregion

            #region CRP
            if (_module.HasModule("CRP"))
            {
                //CRP
                CRPContext _crp;
                IServiceScope _crpscope = _serviceScopeFactory.CreateScope();
                CRPContext crpService = _crpscope.ServiceProvider.GetRequiredService<CRPContext>();
                _crp = crpService;
                if (controller.ToLower() == nameof(CrpCasesController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtCrpCase, CrpCasesController>(_crp, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(CrpConfigController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtCrpConfig, CrpConfigController>(_crp, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(CrpSystemPerformanceController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtCrpSystemPerformance, CrpSystemPerformanceController>(_crp, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(CrpUserPerformanceController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtCrpUserPerformance, CrpUserPerformanceController>(_crp, Context.User.Identity.Name, para);

            }
            #endregion

            #region DGAML
            if (_module.HasModule("DGAML"))
            {
                ArtDgAmlContext _dgAml;
                IServiceScope _dgAmlscope = _serviceScopeFactory.CreateScope();
                ArtDgAmlContext dgAmlService = _dgAmlscope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
                _dgAml = dgAmlService;
                if (controller.ToLower() == nameof(DGAMLAlertDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtDgAmlAlertDetailView, DGAMLAlertDetailsController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLArtExternalCustomerDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtExternalCustomerDetailView, DGAMLArtExternalCustomerDetailsController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLArtScenarioAdminController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtScenarioAdminView, DGAMLArtScenarioAdminController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLArtScenarioHistoryController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtScenarioHistoryView, DGAMLArtScenarioHistoryController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLArtSuspectDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtSuspectDetailView, DGAMLArtSuspectDetailsController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLCasesDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtDgAmlCaseDetailView, DGAMLCasesDetailsController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLCustomersDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtDgAmlCustomerDetailView, DGAMLCustomersDetailsController>(_dgAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(DGAMLTriageController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtDgAmlTriageView, DGAMLTriageController>(_dgAml, Context.User.Identity.Name, para);
            }
            #endregion

            #region DGAudit
            if (_module.HasModule("DGAUDIT"))
            {
                ArtAuditContext __udit;
                IServiceScope __uditscope = _serviceScopeFactory.CreateScope();
                ArtAuditContext _uditService = __uditscope.ServiceProvider.GetRequiredService<ArtAuditContext>();
                __udit = _uditService;

                if (controller.ToLower() == nameof(AuditGroupsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtGroupsAuditView, AuditGroupsController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(AuditRolesController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtRolesAuditView, AuditRolesController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(AuditUsersController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtUsersAuditView, AuditUsersController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(LastLoginPerDayController).ToLower().Replace("controller", "")) await _csvSrv.Export<LastLoginPerDayView, LastLoginPerDayController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListGroupsRolesSummaryController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListGroupsRolesSummary, ListGroupsRolesSummaryController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListGroupsSubGroupsSummaryController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListGroupsSubGroupsSummary, ListGroupsSubGroupsSummaryController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfDeletedUsersController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfDeletedUser, ListOfDeletedUsersController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfGroupsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfGroup, ListOfGroupsController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfRoleController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfRole, ListOfRoleController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfUserController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfUser, ListOfUserController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfUsersAndGroupsRoleController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfUsersAndGroupsRole, ListOfUsersAndGroupsRoleController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfUsersGroupController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfUsersGroup, ListOfUsersGroupController>(__udit, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(ListOfUsersRolesController).ToLower().Replace("controller", "")) await _csvSrv.Export<ListOfUsersRole, ListOfUsersRolesController>(__udit, Context.User.Identity.Name, para);
            }
            #endregion

            #region FATCA
            if (_module.HasModule("FATCA"))
            {

                FATCAContext _fatca;
                IServiceScope _fatcascope = _serviceScopeFactory.CreateScope();
                FATCAContext fatcaService = _fatcascope.ServiceProvider.GetRequiredService<FATCAContext>();
                _fatca = fatcaService;
                if (controller.ToLower() == nameof(FATCAAlertsDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtFatcaAlert, FATCAAlertsDetailsController>(_fatca, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(FATCACasesDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtFatcaCace, FATCACasesDetailsController>(_fatca, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(FATCADetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtFatcaCustomer, FATCADetailsController>(_fatca, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(FATCAIrsReportController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtFatcaIrsReport, FATCAIrsReportController>(_fatca, Context.User.Identity.Name, para);
            }
            #endregion

            #region GOAML
            if (_module.HasModule("GOAML"))
            {
                ArtGoAmlContext _goAml;
                IServiceScope _goAmlscope = _serviceScopeFactory.CreateScope();
                ArtGoAmlContext goAmlService = _goAmlscope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();
                _goAml = goAmlService;
                if (controller.ToLower() == nameof(GOAMLReportIndicatorDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtGoamlReportsIndicator, GOAMLReportIndicatorDetailsController>(_goAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(GOAMLReportsDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtGoamlReportsDetail, GOAMLReportsDetailsController>(_goAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(GOAMLReportsSuspectController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtGoamlReportsSusbectParty, GOAMLReportsSuspectController>(_goAml, Context.User.Identity.Name, para);
            }
            #endregion

            #region SEG
            #endregion

            #region TRADE_BASE
            if (_module.HasModule("TRADE_BASE"))
            {
                TRADE_BASEContext tradeBase;
                IServiceScope tradeBaseScope = _serviceScopeFactory.CreateScope();
                TRADE_BASEContext tradeBaseService = tradeBaseScope.ServiceProvider.GetRequiredService<TRADE_BASEContext>();
                tradeBase = tradeBaseService;
                if (controller.ToLower() == nameof(TradeBaseAMLSummaryController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtTradeBaseSummary, TradeBaseAMLSummaryController>(tradeBase, Context.User.Identity.Name, para);
            }
            #endregion
            #region SASAML
            if (_module.HasModule("SASAML"))
            {
                SasAmlContext sasAml;
                IServiceScope sasScope = _serviceScopeFactory.CreateScope();
                SasAmlContext sasService = sasScope.ServiceProvider.GetRequiredService<SasAmlContext>();
                sasAml = sasService;

                if (controller.ToLower() == nameof(AlertDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtAmlAlertDetailView, AlertDetailsController>(sasAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(CasesDetailsController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtAmlCaseDetailsView, CasesDetailsController>(sasAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(CustomersController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtAmlCustomersDetailsView, CustomersController>(sasAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(HighRiskController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtAmlHighRiskCustView, HighRiskController>(sasAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(RiskAssessmentController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtRiskAssessmentView, RiskAssessmentController>(sasAml, Context.User.Identity.Name, para);
                if (controller.ToLower() == nameof(TriageController).ToLower().Replace("controller", "")) await _csvSrv.Export<ArtAmlTriageView, TriageController>(sasAml, Context.User.Identity.Name, para);
            }
            #endregion



        }



        //
        // private async Task ExportSegOutliers(ExportDto<object> para, List<string> @params)
        // {
        //     int monthKey = Convert.ToInt32(@params.First());
        //     string desc = @params[1];
        //     string seg = @params[2];
        //     IQueryable<ArtAllSegmentsOutliersTb> data = _seg.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == monthKey.ToString() && x.PartyTypeDesc == desc && x.SegmentSorted == seg);
        //     await _csvSrv.ExportAllCsv<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController, object>(data, Context.User.Identity.Name, para);
        // }
        // private async Task ExportForAuditTrial(ExportDto<object> para)
        // {
        //     IQueryable<ArtTiEcmAuditReport> data = _fti.ArtTiEcmAuditReports.AsQueryable().CallData(para.Req).Data;
        //     var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.FtiReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
        //     IEnumerable<ExportDto> after = res.Select(x =>
        //     {
        //         IQueryable<string?>? ListOfMatchingEcm = ti.Masters.Where(c => c.MasterRef == x.Key.FtiReference)?.Join(ti.Notes, c => c.Key97, co => co.MasterKey, (c, co) => co.NoteText);
        //         return new ExportDto
        //         {
        //             Record = x.FirstOrDefault(),
        //             Note = ListOfMatchingEcm?.Select(e => e).ToList(),
        //
        //         };
        //
        //     });
        //     MemoryStream stream = new();
        //     using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
        //     using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
        //     {
        //
        //
        //         sw.Write("");
        //         System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmAuditReport).GetProperties();
        //
        //         foreach (System.Reflection.PropertyInfo item in props)
        //         {
        //             cw.WriteField(item.Name);
        //         }
        //
        //         cw.WriteField("Note");
        //
        //
        //         cw.NextRecord();
        //         foreach (ExportDto? elm in after)
        //         {
        //             foreach (System.Reflection.PropertyInfo prop in props)
        //             {
        //                 cw.WriteField(prop.GetValue(elm.Record));
        //             }
        //
        //             cw.NextRecord();
        //             for (int i = 0; i < elm.Note.Count; i++)
        //             {
        //                 foreach (System.Reflection.PropertyInfo prop in props)
        //                 {
        //                     cw.WriteField("");
        //                 }
        //
        //                 cw.WriteField(elm.Note[i]);
        //
        //                 cw.NextRecord();
        //             }
        //             cw.NextRecord();
        //         }
        //     }
        //     string FileName = nameof(EcmAuditTrialController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     await Clients.Caller
        //                       .SendAsync("csvRecevied", stream.ToArray(), FileName);
        // }
        //
        //
        // private async Task ExportCustomReport(ExportDto<object> exportDto)
        // {
        //     //string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
        //     //ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
        //     //List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
        //     //dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
        //     //string dbtype = dbInstance.Database.IsOracle() ? DbTypes.Oracle : dbInstance.Database.IsSqlServer() ? DbTypes.SqlServer : "";
        //     //ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
        //     //{
        //     //    name = x.Column,
        //     //    type = x.JsType,
        //     //    isNullable = x.IsNullable,
        //     //}).ToArray();
        //     //string filter = exportDto.Req.Filter.GetFiltersString(dbtype, columns);
        //     //List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;
        //
        //     //List<List<object>> filterCells = exportDto.Req.Filter.GetFilterTextForCsv();
        //
        //     //DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
        //     //byte[] bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata?.Select(x => x.Data).ToList(), filterCells);
        //     //string FileName = Report.Name + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     //await Clients.Clients(connections.GetConnections(Context.User.Identity.Name))
        //     //                    .SendAsync("csvRecevied", bytes, FileName);
        // }
        //
        // private async Task ExportForWorkflowProg(ExportDto<object> para)
        // {
        //
        //     IQueryable<ArtTiEcmWorkflowProgReport> data = _fti.ArtTiEcmWorkflowProgReports.AsQueryable().CallData(para.Req).Data;
        //     var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
        //     IEnumerable<ExportDtoWorkflowProg> after = res.Select(x =>
        //     {
        //         IQueryable<ArtTiEcmWorkflowProgReportOld>? ListOfMatchingEcm = _fti.ArtTiEcmWorkflowProgReportOlds.Where(o => o.EcmReference == x.Key.EcmReference && x.Key.CaseStatCd == o.CaseStatCd && x.Key.EventSteps == o.EventSteps && x.Key.StepStatus == o.StepStatus);
        //         return new ExportDtoWorkflowProg
        //         {
        //             Record = x.FirstOrDefault(),
        //             Comments = ListOfMatchingEcm?.Select(e => e.Comments).ToList(),
        //             Note = ListOfMatchingEcm?.Select(e => e.Note).ToList(),
        //             NoteCreationTime = ListOfMatchingEcm?.Select(e => e.NoteCreationTime).ToList()
        //         };
        //
        //     });
        //     MemoryStream stream = new();
        //     using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
        //     using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
        //     {
        //
        //
        //         sw.Write("");
        //         System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmWorkflowProgReport).GetProperties();
        //
        //         foreach (System.Reflection.PropertyInfo item in props)
        //         {
        //             cw.WriteField(item.Name);
        //         }
        //         cw.WriteField("Comments");
        //         cw.WriteField("Note");
        //         cw.WriteField("NoteCreationTime");
        //
        //         cw.NextRecord();
        //         foreach (ExportDtoWorkflowProg? elm in after)
        //         {
        //             foreach (System.Reflection.PropertyInfo prop in props)
        //             {
        //                 cw.WriteField(prop.GetValue(elm.Record));
        //             }
        //
        //             cw.NextRecord();
        //             for (int i = 0; i < elm.Comments.Count; i++)
        //             {
        //                 foreach (System.Reflection.PropertyInfo prop in props)
        //                 {
        //                     cw.WriteField("");
        //                 }
        //                 cw.WriteField(elm.Comments[i]);
        //                 cw.WriteField(elm.Note[i]);
        //                 cw.WriteField(elm.NoteCreationTime[i]);
        //                 cw.NextRecord();
        //             }
        //         }
        //     }
        //     string FileName = nameof(EcmAuditTrialController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     await Clients.Caller
        //                       .SendAsync("csvRecevied", stream.ToArray(), FileName);
        // }
        //
        //
        // public override Task OnDisconnectedAsync(Exception? exception)
        // {
        //     string? user = Context.User.Identity.Name;
        //     connections.RemoveConnection(user, Context.ConnectionId);
        //     return base.OnDisconnectedAsync(exception);
        // }
        //
        // public class ExportDto
        // {
        //     public ArtTiEcmAuditReport Record { get; set; }
        //
        //     public List<string> Note { get; set; }
        //
        // }
        // public class ExportDtoWorkflowProg
        // {
        //     public ArtTiEcmWorkflowProgReport Record { get; set; }
        //     public List<string> Comments { get; set; }
        //     public List<string> Note { get; set; }
        //     public List<DateTime?> NoteCreationTime { get; set; }
        // }
    }
}
