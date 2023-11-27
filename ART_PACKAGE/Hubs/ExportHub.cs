using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Data.TIZONE2;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.Json;
using static ART_PACKAGE.Helpers.CustomReport.DbContextExtentions;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly ILogger<ExportHub> _logger;

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
        private readonly DBFactory dBFactory;
        private DbContext dbInstance;

        public ExportHub(ILogger<ExportHub> logger, UsersConnectionIds connections, ICsvExport csvSrv, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration, AuthContext db, DBFactory dBFactory)
        {
            _logger = logger;
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
            if (modules.Contains("DGAUDIT"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                SegmentationContext seg = scope.ServiceProvider.GetRequiredService<SegmentationContext>();
                _seg = seg;
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

            #region FTI
            if (nameof(ArtCasesInitiatedFromBranchController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtCasesInitiatedFromBranch, ArtCasesInitiatedFromBranchController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ArtDgecmActivityController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtDgecmActivity, ArtDgecmActivityController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ArtEcmFtiFullCycleController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtEcmFtiFullCycle, ArtEcmFtiFullCycleController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ArtFtiActivityController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtFtiActivity, ArtFtiActivityController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ArtFtiEcmTransactionController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtFtiEcmTransaction, ArtFtiEcmTransactionController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ArtFtiEndToEndController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtFtiEndToEnd, ArtFtiEndToEndController>(_fti, Context.User.Identity.Name, para);
            if (nameof(ArtFtiEndToEndNewController).ToLower().Replace("controller", "") == controller.ToLower()) await ExportEndToEnd(para);

            #endregion

        }

        public async Task ExportEndToEnd(ExportDto<object> para)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(para));
            _logger.LogInformation(para.SelectedIdz.Select(x => ((JsonElement)x).ToObject<string>()).FirstOrDefault());


            if (para.All)
            {
                await _csvSrv.Export<ArtFtiEndToEndNew, ArtFtiEndToEndController>(_fti, Context.User.Identity.Name, para);
            }
            else
            {


                if (para.WithExtraData)
                {

                    string? ecmRef = para.SelectedIdz.Select(x => ((JsonElement)x).ToObject<string>()).FirstOrDefault();

                    ArtFtiEndToEndNew? record = _fti.ArtFtiEndToEndsNew.FirstOrDefault(x => x.EcmReference == ecmRef);
                    EndToEndWithExtraDataDto data = new()
                    {
                        Record = record,
                        EcmEvents = _fti.ArtFtiEndToEndEcmEventsWorkflows.Where(x => x.EcmReference == record.EcmReference).ToList(),
                        FtiEvents = _fti.ArtFtiEndToEndFtiEventsWorkflows.Where(x => x.FtiReference == record.MasterReference).ToList(),
                        SubCases = _fti.ArtFtiEndToEndSubCasess.Where(x => x.ParentCaseId == record.EcmReference).ToList(),
                    };
                    CsvConfiguration config = new(CultureInfo.CurrentCulture)
                    {

                    };
                    using MemoryStream stream = new();
                    using StreamWriter sw = new(stream, new UTF8Encoding(true));
                    sw.AutoFlush = true;

                    using CsvWriter cw = new(sw, config);

                    System.Reflection.PropertyInfo[] props = typeof(ArtFtiEndToEndNew).GetProperties();
                    List<string> columnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiEndToEndNewController).ToLower()].SkipList;
                    Dictionary<string, DisplayNameAndFormat> Displaynames = ReportsConfig.CONFIG[nameof(ArtFtiEndToEndNewController).ToLower()].DisplayNames;
                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        if (columnsToSkip.Contains(prop.Name))
                            continue;
                        else
                        {
                            if (Displaynames.ContainsKey(prop.Name))
                            {
                                cw.WriteField(Displaynames[prop.Name].DisplayName);
                            }
                            else
                            {
                                cw.WriteField(prop.Name);
                            }
                        }
                    }
                    cw.WriteField("");

                    cw.WriteField("Case Comments");
                    cw.WriteField("Ecm Event Step");
                    cw.WriteField("Ecm Event Created By");
                    cw.WriteField("Ecm Event Created Date");
                    cw.WriteField("Ecm Event Time Difference");

                    cw.WriteField("");

                    cw.WriteField("Event Steps");
                    cw.WriteField("Step Status");
                    cw.WriteField("Started Time");
                    cw.WriteField("Last Mod Time");
                    cw.WriteField("Time Difference");
                    cw.WriteField("Last ModUser");
                    cw.WriteField("Ecm Refrence");

                    cw.WriteField("");


                    cw.WriteField("SubCase Reference");
                    cw.WriteField("Case Status");
                    cw.WriteField("Customer Classification");
                    cw.WriteField("Trade Instructions");
                    cw.WriteField("Firts Line Instructions");


                    cw.NextRecord();


                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        if (columnsToSkip.Contains(prop.Name))
                            continue;
                        else
                        {
                            cw.WriteField(prop.Name.ToLower().Contains("amount") ? string.Format("{0:n2}", prop.GetValue(data.Record)) : prop.GetValue(data.Record));
                        }
                    }


                    int subcasesCount = data.SubCases.Count();
                    int ftiEventsCount = data.FtiEvents.Count();
                    int ecmEventsCount = data.EcmEvents.Count();
                    int maxcount = new List<int>() { subcasesCount, ftiEventsCount, ecmEventsCount }.Max();


                    for (int i = 0; i < maxcount; i++)
                    {
                        if (i != 0)
                        {
                            foreach (System.Reflection.PropertyInfo prop in props)
                            {
                                if (columnsToSkip.Contains(prop.Name))
                                    continue;
                                else
                                {
                                    cw.WriteField("");
                                }
                            }
                        }

                        if (i < ecmEventsCount)
                        {

                            cw.WriteField("");
                            cw.WriteField(data.EcmEvents[i].CaseComments);
                            cw.WriteField(data.EcmEvents[i].EcmEventStep);
                            cw.WriteField(data.EcmEvents[i].EcmEventCreatedBy);
                            cw.WriteField(data.EcmEvents[i].EcmEventCreatedDate);
                            cw.WriteField(data.EcmEvents[i].EcmEventTimeDifference);



                        }
                        else
                        {
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");


                        }
                        if (i < ftiEventsCount)
                        {
                            cw.WriteField("");
                            cw.WriteField(data.FtiEvents[i].EventSteps);
                            cw.WriteField(data.FtiEvents[i].StepStatus);
                            cw.WriteField(data.FtiEvents[i].StartedTime);
                            cw.WriteField(data.FtiEvents[i].LastModTime);
                            cw.WriteField(data.FtiEvents[i].TimeDifference);
                            cw.WriteField(data.FtiEvents[i].LastModUser);
                            cw.WriteField(data.FtiEvents[i].EcmReference);

                        }
                        else
                        {
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");

                        }
                        if (i < subcasesCount)
                        {
                            cw.WriteField("");
                            cw.WriteField(data.SubCases[i].SubCaseReference);
                            cw.WriteField(data.SubCases[i].CaseStatus);
                            cw.WriteField(data.SubCases[i].CustomerClassification);
                            cw.WriteField(data.SubCases[i].TradeInstructions);
                            cw.WriteField(data.SubCases[i].FirtsLineInstructions);

                        }
                        else
                        {
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");
                            cw.WriteField("");


                        }
                        cw.NextRecord();
                    }


                    byte[] bytes = stream.ToArray();
                    string FileName = nameof(ArtFtiEndToEndNewController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
                    await Clients.Clients(connections.GetConnections(Context.User.Identity.Name))
                            .SendAsync("csvRecevied", bytes, FileName);


                }
                else
                {
                    await _csvSrv.Export<ArtFtiEndToEndNew, ArtFtiEndToEndController, string>(_fti, Context.User.Identity.Name, para, nameof(ArtFtiEndToEndNew.EcmReference));
                }
            }
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
                type = x.JsType
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

        private class EndToEndWithExtraDataDto
        {
            public ArtFtiEndToEndNew Record { get; set; }
            public List<ArtFtiEndToEndFtiEventsWorkflow> FtiEvents { get; set; }
            public List<ArtFtiEndToEndEcmEventsWorkflow> EcmEvents { get; set; }
            public List<ArtFtiEndToEndSubCases> SubCases { get; set; }
        }

    }
}