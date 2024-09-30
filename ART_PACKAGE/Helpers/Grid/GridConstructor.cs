using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper;
using ART_PACKAGE.Helpers.Handlers;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using ART_PACKAGE.Hubs;
using Data.Services;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{
    public class GridConstructor<TRepo, TContext, TModel> : IGridConstructor<TRepo, TContext, TModel> where TContext : DbContext
        where TModel : class where TRepo : IBaseRepo<TContext, TModel>
    {
        private readonly ILogger<GridConstructor<TRepo, TContext, TModel>> _logger;
        private readonly IDropDownMapper _dropDownMap;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICsvExport _csvSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private static Dictionary<int, int> fileProgress = new();
        private readonly ReportConfigResolver _reportsConfigResolver;
        private readonly ProcessesHandler _processesHandler;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;

        public GridConstructor(TRepo repo, IDropDownMapper dropDownMap, IWebHostEnvironment webHostEnvironment, ICsvExport csvSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections, ReportConfigResolver reportsConfigResolver, IPdfService pdfSrv, ProcessesHandler processesHandler, IConfiguration _config, ILogger<GridConstructor<TRepo, TContext, TModel>> logger)
        {
            Repo = repo;
            _dropDownMap = dropDownMap;
            _webHostEnvironment = webHostEnvironment;
            _csvSrv = csvSrv;
            _exportHub = exportHub;
            this.connections = connections;
            _reportsConfigResolver = reportsConfigResolver;
            _pdfSrv = pdfSrv;
            this._config = _config;
            _logger = logger;
            _processesHandler = processesHandler;
        }
        public TRepo Repo { get; private set; }

        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, Expression<Func<TModel, bool>> baseCondition = null)
        {
            string folderGuid = Guid.NewGuid().ToString();
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), folderGuid);
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition);
            int total = dataRes.total;
            int totalcopy = total;
            var d = _config.GetValue<int>("export_Patch", 50000);// is not null ? _config.GetSection("export_Patch").ToString() : "500_000";
            //var saved_batch = Int32.Parse(_config.GetSection("export_Patch") is not null ? _config.GetSection("export_Patch").ToString() : "500_000");
            int batch = d;
            //500_000:
            int round = 0;
            fileProgress = new();

            _csvSrv.OnProgressChanged += (recordsDone, fileNumber) =>
            {
                fileProgress[fileNumber] = recordsDone;
                var done = fileProgress.Values.Sum();
                decimal progress = done / (decimal)totalcopy;
                _ = _exportHub.Clients.Clients(connections.GetConnections(user))
                               .SendAsync("updateExportProgress", progress * 100, folderGuid, gridId);
            };
            while (total > 0)
            {
                GridRequest dataReq = new()
                {
                    Skip = round * batch,
                    Take = batch,
                    Filter = exportRequest.DataReq.Filter,
                    Sort = exportRequest.DataReq.Sort,
                    Group = exportRequest.DataReq.Group,
                    All = exportRequest.DataReq.All,
                    IdColumn = exportRequest.DataReq.IdColumn,
                    SelectedValues = exportRequest.DataReq.SelectedValues,
                };
                ExportRequest roundReq = new()
                {
                    DataReq = dataReq,
                    IncludedColumns = exportRequest.IncludedColumns.Select(x => (string)x.Clone()).ToList()
                };
                int localRound = round + 1;

                _ = Task.Run(() => _csvSrv.ExportData<TRepo, TContext, TModel>(roundReq, folderPath, "Report.csv", localRound, baseCondition));

                total -= batch;
                round++;
            }
            return folderGuid;
        }

        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, string reportGUID, Expression<Func<TModel, bool>> baseCondition = null)
        {
            ReportConfig? reportConfig = _reportsConfigResolver((typeof(TModel).Name + "Config").ToLower());
            string folderGuid = reportGUID;//Guid.NewGuid().ToString();
            _processesHandler.AddProcess(reportGUID, "CSV");
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), folderGuid);
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition, defaultSort: reportConfig.defaultSortOption);
            int total = dataRes.total;
            int totalcopy = total;
            var d = _config.GetValue<int>("export_Patch", 50000);// is not null ? _config.GetSection("export_Patch").ToString() : "500_000";
            //var saved_batch = Int32.Parse(_config.GetSection("export_Patch") is not null ? _config.GetSection("export_Patch").ToString() : "500_000");
            int batch = d;
            //500_000:
            int round = 0;
            fileProgress = new();

            _csvSrv.OnProgressChanged += (recordsDone, fileNumber) =>
            {
                fileProgress[fileNumber] = recordsDone;
                var done = fileProgress.Values.Sum();
                decimal progress = done / (decimal)totalcopy;
                _processesHandler.UpdateCompletionPercentage(reportGUID, progress * 100);
                _ = _exportHub.Clients.Clients(connections.GetConnections(user))
                               .SendAsync("updateExportProgress", progress * 100, folderGuid, gridId);
            };
            while (total > 0)
            {
                GridRequest dataReq = new()
                {
                    Skip = round * batch,
                    Take = batch,
                    Filter = exportRequest.DataReq.Filter,
                    Sort = exportRequest.DataReq.Sort,
                    Group = exportRequest.DataReq.Group,
                    All = exportRequest.DataReq.All,
                    IdColumn = exportRequest.DataReq.IdColumn,
                    SelectedValues = exportRequest.DataReq.SelectedValues,
                };
                ExportRequest roundReq = new()
                {
                    DataReq = dataReq,
                    IncludedColumns = exportRequest.IncludedColumns.Select(x => (string)x.Clone()).ToList()
                };
                int localRound = round + 1;

                _ = Task.Run(() => _csvSrv.ExportData<TRepo, TContext, TModel>(roundReq, folderPath, "Report.csv", localRound, reportGUID, baseCondition, defaultSort: reportConfig.defaultSortOption));

                total -= batch;
                round++;
            }
            return folderGuid;
        }

        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User)
        {
            ReportConfig? reportConfig = _reportsConfigResolver(controller);
            bool hasConfig = reportConfig != null;
            Dictionary<string, List<SelectItem>> DropDownColumn = _dropDownMap.GetDorpDownForReport(controller);
            List<string>? ColumnsToSkip = reportConfig?.SkipList;
            Dictionary<string, GridColumnConfiguration>? DisplayNames = reportConfig?.DisplayNames;

            GridIntializationConfiguration conf = new()
            {
                columns = GridHelprs.GetColumns<TModel>(DropDownColumn, DisplayNames, ColumnsToSkip),
                selectable = hasConfig && reportConfig.Selectable,
                toolbar = hasConfig ? reportConfig.Toolbar : null,
                actions = hasConfig ? reportConfig.Actions : null,
                containsActions = hasConfig && reportConfig.ContainsActions,
                showCsvBtn = hasConfig && (reportConfig.ShowExportCsv is null || reportConfig.ShowExportCsv(User)),
                showPdfBtn = hasConfig && (reportConfig.ShowExportPdf is null || reportConfig.ShowExportPdf(User)),
                hasFixedWidth = hasConfig ? reportConfig.HasFixedWidth : false,
            };
            return conf;
        }

        public GridResult<TModel> GetGridData(GridRequest request, Expression<Func<TModel, bool>> baseCondition, IEnumerable<Expression<Func<TModel, object>>>? includes = null)
        {
            ReportConfig? reportConfig = _reportsConfigResolver((typeof(TModel).Name + "Config").ToLower());

            GridResult<TModel> dataRes = Repo.GetGridData(request, baseCondition: baseCondition, includes: includes, defaultSort: reportConfig.defaultSortOption);
            return dataRes;
        }

        public async Task<byte[]> ExportGridToPdf(ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, Expression<Func<TModel, bool>>? baseCondition = null)
        {
            ReportConfig? reportConfig = _reportsConfigResolver((typeof(TModel).Name + "Config").ToLower());
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition, defaultSort: reportConfig.defaultSortOption);

            ViewData["title"] = reportConfig.ReportTitle;
            ViewData["desc"] = reportConfig.ReportDescription;
            byte[] pdfBytes = await _pdfSrv.ExportToPdf<TModel>(dataRes.data, ViewData, actionContext, 5
                                                    , user, reportConfig.SkipList, reportConfig.DisplayNames);
            return pdfBytes;
        }
        public async Task<byte[]> ExportGridToPdf(ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, string reportId, Expression<Func<TModel, bool>>? baseCondition = null)
        {
            _processesHandler.AddProcess(reportId,"PDF");
            ReportConfig? reportConfig = _reportsConfigResolver((typeof(TModel).Name + "Config").ToLower());
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition, defaultSort: reportConfig.defaultSortOption);

            ViewData["title"] = reportConfig.ReportTitle;
            ViewData["desc"] = reportConfig.ReportDescription;
            byte[] pdfBytes = await _pdfSrv.ExportToPdf<TModel>(dataRes.data, ViewData, actionContext, 5
                                                    , user, reportId, reportConfig.SkipList, reportConfig.DisplayNames);
            return pdfBytes;
        }
        
        public async Task<string> ExportGridToPDFUsingIText(ExportRequest exportRequest, string user, string gridId, string reportGUID, Expression<Func<TModel, bool>> baseCondition = null)
        {
            ReportConfig? reportConfig = _reportsConfigResolver((typeof(TModel).Name + "Config").ToLower());
            string folderGuid = reportGUID;//Guid.NewGuid().ToString();
            _processesHandler.AddProcess(reportGUID, "CSV");
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "PDF"), folderGuid);
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition, defaultSort: reportConfig.defaultSortOption);
            int total = dataRes.total;
            int totalcopy = total;
            var d = _config.GetValue<int>("export_Patch", 50000);// is not null ? _config.GetSection("export_Patch").ToString() : "500_000";
            //var saved_batch = Int32.Parse(_config.GetSection("export_Patch") is not null ? _config.GetSection("export_Patch").ToString() : "500_000");
            int batch = d;
            //500_000:
            int round = 0;
            fileProgress = new();

            _csvSrv.OnProgressChanged += (recordsDone, fileNumber) =>
            {
                fileProgress[fileNumber] = recordsDone;
                var done = fileProgress.Values.Sum();
                decimal progress = done / (decimal)totalcopy;
                _processesHandler.UpdateCompletionPercentage(reportGUID, progress * 100);
                _ = _exportHub.Clients.Clients(connections.GetConnections(user))
                               .SendAsync("updateExportProgress", progress * 100, folderGuid, gridId);
            };
            while (total > 0)
            {
                GridRequest dataReq = new()
                {
                    Skip = round * batch,
                    Take = batch,
                    Filter = exportRequest.DataReq.Filter,
                    Sort = exportRequest.DataReq.Sort,
                    Group = exportRequest.DataReq.Group,
                    All = exportRequest.DataReq.All,
                    IdColumn = exportRequest.DataReq.IdColumn,
                    SelectedValues = exportRequest.DataReq.SelectedValues,
                };
                ExportRequest roundReq = new()
                {
                    DataReq = dataReq,
                    IncludedColumns = exportRequest.IncludedColumns.Select(x => (string)x.Clone()).ToList()
                };
                int localRound = round + 1;

                _ = Task.Run(() => _pdfSrv.ITextPdf<TRepo, TContext, TModel>(roundReq,localRound, folderPath, "Report.pdf", reportGUID, baseCondition, defaultSort: reportConfig.defaultSortOption));

                total -= batch;
                round++;
            }
            return folderGuid;
        }

        
    }
}
