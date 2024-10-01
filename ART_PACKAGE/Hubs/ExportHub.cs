
﻿using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using CsvHelper;
using Data.Data.ARTDGAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.SASAml;
using Data.TIZONE2;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;
using System.Text;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext _ecm;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly ArtAuditContext _dbAd;
        private readonly List<string>? modules;
        private readonly FTIContext _fti;
        private readonly TIZONE2Context ti;
       // private readonly List<string>? modules;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
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
