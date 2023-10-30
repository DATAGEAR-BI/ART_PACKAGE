using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ARTDGAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.KYC;
using Data.Data.SASAml;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static ART_PACKAGE.Helpers.CustomReport.DbContextExtentions;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly AuthContext db;
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext _db;
        private readonly KYCContext _kyc;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly ArtAuditContext _dbAd;
        private readonly List<string>? modules;
        private readonly DBFactory dBFactory;
        private DbContext dbInstance;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, EcmContext context, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, DBFactory dBFactory, AuthContext db)
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
                _db = ecmService;
            }
            if (modules.Contains("KYC"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                KYCContext kycService = scope.ServiceProvider.GetRequiredService<KYCContext>();
                _kyc = kycService;
            }
            if (modules.Contains("DGAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtDgAmlContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
                _dgaml = dgamlService;
            }
            if (modules.Contains("DGAUDIT"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtAuditContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtAuditContext>();
                _dbAd = dgamlService;
            }
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            this.dBFactory = dBFactory;
            this.db = db;
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

        public async Task GetMissedFiles(string reqId, List<int> missedFiles)
        {
            await _csvSrv.ExportMissed(reqId, Context.User.Identity.Name, missedFiles);

        }

        public async Task ClearExportFolder(string reqId)
        {
            _csvSrv.ClearExportFolder(reqId);

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


            #region ECM
            if (nameof(SystemPerformanceController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtSystemPerformanceNcba, SystemPerformanceController>(_db, Context.User.Identity.Name, para);
            if (nameof(AlertedEntitiesController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAlertedEntity, AlertedEntitiesController>(_db, Context.User.Identity.Name, para);
            #endregion
            #region KYC
            if (nameof(CustomersWithExpiredDocumentU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<CustomersWithExpiredDocumentU2, CustomersWithExpiredDocumentU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(CustomersRenewalU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<CustomersRenewalU2, CustomersRenewalU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighExpiredU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighExpiredU2, ArtKycHighExpiredU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighOneMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighOneMonthU2, ArtKycHighOneMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighThreeMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighThreeMonthU2, ArtKycHighThreeMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighTwoMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighTwoMonthU2, ArtKycHighTwoMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowExpiredU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowExpiredU2, ArtKycLowExpiredU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowOneMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowOneMonthU2, ArtKycLowOneMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowThreeMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowThreeMonthU2, ArtKycLowThreeMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowTwoMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowTwoMonthU2, ArtKycLowTwoMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumExpiredU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumExpiredU2, ArtKycMediumExpiredU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumOneMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumOneMonthU2, ArtKycMediumOneMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumThreeMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumThreeMonthU2, ArtKycMediumThreeMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumTwoMonthU2Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumTwoMonthU2, ArtKycMediumTwoMonthU2Controller>(_kyc, Context.User.Identity.Name, para);
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            if (nameof(CustomersRenewalU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<CustomersRenewalU3, CustomersRenewalU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighExpiredU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighExpiredU3, ArtKycHighExpiredU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighOneMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighOneMonthU3, ArtKycHighOneMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighThreeMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighThreeMonthU3, ArtKycHighThreeMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycHighTwoMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycHighTwoMonthU3, ArtKycHighTwoMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowExpiredU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowExpiredU3, ArtKycLowExpiredU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowOneMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowOneMonthU3, ArtKycLowOneMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowThreeMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowThreeMonthU3, ArtKycLowThreeMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycLowTwoMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycLowTwoMonthU3, ArtKycLowTwoMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumExpiredU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumExpiredU3, ArtKycMediumExpiredU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumOneMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumOneMonthU3, ArtKycMediumOneMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumThreeMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumThreeMonthU3, ArtKycMediumThreeMonthU3Controller>(_kyc, Context.User.Identity.Name, para);
            if (nameof(ArtKycMediumTwoMonthU3Controller).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtKycMediumTwoMonthU3, ArtKycMediumTwoMonthU3Controller>(_kyc, Context.User.Identity.Name, para);

            #endregion
        }


        private async Task ExportCustomReport(ExportDto<object> exportDto)
        {
            string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
            ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
            List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            string filter = exportDto.Req.Filter.GetFiltersString(dbtype);
            List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;
            ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();

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
    }
}
