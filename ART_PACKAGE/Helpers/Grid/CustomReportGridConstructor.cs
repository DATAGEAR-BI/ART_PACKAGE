using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Handlers;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Data.Services.CustomReport;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{

    public class CustomReportGridConstructor : ICustomReportGridConstructor
    {
        private readonly DBFactory _dbFactory;
        private readonly ICsvExport _csvSrv;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static readonly Dictionary<int, int> fileProgress = new();
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private readonly ProcessesHandler _processesHandler;
        private readonly IPdfService _pdfSrv;

        public CustomReportGridConstructor(ICustomReportRepo repo, DBFactory dbFactory, ICsvExport csvSrv, IWebHostEnvironment webHostEnvironment, IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IPdfService pdfSrv, ProcessesHandler processesHandler)
        {
            Repo = repo;
            _dbFactory = dbFactory;
            _csvSrv = csvSrv;
            _webHostEnvironment = webHostEnvironment;
            _exportHub = exportHub;
            this.connections = connections;
            _pdfSrv = pdfSrv;
            _processesHandler = processesHandler;
        }
        public ICustomReportRepo Repo { get; private set; }
        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User)
        {
            throw new NotImplementedException();
        }

        public GridResult<Dictionary<string, object>> GetGridData(GridRequest request, Expression<Func<Dictionary<string, object>, bool>> baseCondition, IEnumerable<Expression<Func<Dictionary<string, object>, object>>>? includes = null)
        {
            throw new NotImplementedException();
        }

        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }

        public GridResult<Dictionary<string, object>> GetGridData(GridRequest request, Expression<Func<object, bool>> baseCondition, IEnumerable<Expression<Func<object, object>>>? includes = null)
        {
            throw new NotImplementedException();
        }

        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, Expression<Func<object, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }

        public GridIntializationConfiguration IntializeGrid(int reportId)
        {
            IEnumerable<GridColumn> columns = Repo.GetReportColumns(reportId);
            return new GridIntializationConfiguration()
            {
                columns = columns.ToList(),
            };
        }

        public GridResult<Dictionary<string, object>> GetGridData(int reportId, GridRequest request)
        {
            ArtSavedCustomReport report = Repo.GetReport(reportId);
            Microsoft.EntityFrameworkCore.DbContext? schemaContext = _dbFactory.GetDbInstance(report.Schema.ToString());
            GridResult<Dictionary<string, object>> dataResult = Repo.GetGridData(schemaContext, report, request);
            return dataResult;
        }

        public IEnumerable<ChartDataDto> GetReportChartsData(int reportId, GridRequest request)
        {
            ArtSavedCustomReport report = Repo.GetReport(reportId);
            Microsoft.EntityFrameworkCore.DbContext? schemaContext = _dbFactory.GetDbInstance(report.Schema.ToString());
            IEnumerable<ChartDataDto> chartsData = Repo.GetReportChartsData(schemaContext, report, request);
            return chartsData;
        }

        public IEnumerable<DbObject> GetDbObjectsOf(int schema)
        {
            DbSchema schemaType = (DbSchema)schema;
            Microsoft.EntityFrameworkCore.DbContext? schemaContext = _dbFactory.GetDbInstance(schemaType.ToString());
            IEnumerable<DbObject> dbObjects = Repo.GetDbObjectsOf(schemaContext);
            return dbObjects;
        }

        public IEnumerable<ColumnDto> GetObjectColumns(int schema, string view, string type)
        {
            DbSchema schemaType = (DbSchema)schema;
            Microsoft.EntityFrameworkCore.DbContext? schemaContext = _dbFactory.GetDbInstance(schemaType.ToString());
            IEnumerable<ColumnDto> Columns = Repo.GetObjectColumns(schemaContext, view, type);
            return Columns;
        }

        public string ExportGridToCsv(int reportId, ExportRequest exportRequest, string user, string gridId)
        {
            string folderGuid = gridId;//Guid.NewGuid().ToString();
            _processesHandler.AddProcess(gridId,"CSV");
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), folderGuid);
            ArtSavedCustomReport report = Repo.GetReport(reportId);
            Microsoft.EntityFrameworkCore.DbContext? schemaContext = _dbFactory.GetDbInstance(report.Schema.ToString());
            int total = Repo.GetDataCount(schemaContext, report, exportRequest.DataReq);
            int totalcopy = total;
            int batch = 500_000;
            int round = 0;

            _csvSrv.OnProgressChanged += (recordsDone, fileNumber) =>
            {
                if (total == 0 && recordsDone == 0)
                {
                    _ = _exportHub.Clients.Clients(connections.GetConnections(user))
                        .SendAsync("updateExportProgress", 100, folderGuid, gridId);
                }
                else
                {
                    fileProgress[fileNumber] = recordsDone;
                    float progress = fileProgress.Sum(x => x.Value) / (float)totalcopy;
                    _ = _exportHub.Clients.Clients(connections.GetConnections(user))
                        .SendAsync("updateExportProgress", progress * 100, folderGuid, gridId);
                }
            };
            if (total == 0)
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

                _ = Task.Run(() => _csvSrv.ExportCustomData(report, roundReq, folderPath, "Report.csv", localRound, folderGuid));

            }
            else
            {
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

                    _ = Task.Run(() => _csvSrv.ExportCustomData(report, roundReq, folderPath, "Report.csv", localRound, folderGuid));

                    total -= batch;
                    round++;
                }
            }

            return folderGuid;
        }



        public async Task<byte[]> ExportGridToPdf(int reportId, ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            ArtSavedCustomReport report = Repo.GetReport(reportId);

            _processesHandler.AddProcess((string)ViewData["reportId"], "PDF");
            DbContext? schemaContext = _dbFactory.GetDbInstance(report.Schema.ToString());
            GridResult<Dictionary<string, object>> dataRes = Repo.GetGridData(schemaContext, report, exportRequest.DataReq);
            IQueryable<CustomReportRecord> data = dataRes.data.Select(x => new CustomReportRecord() { Data = x });

            byte[] pdfBytes = await _pdfSrv.ExportCustomReportToPdf(data, ViewData, actionContext, 5
                                                     , user, report.Columns.Select(cols => cols.Column).ToList());

            /* var  dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition);
             ViewData["title"] = report.Name;
             ViewData["desc"] = report.Description;
             byte[] pdfBytes = await _pdfSrv.ExportCustomReportToPdf(report, ViewData, actionContext, 5
                                                     , user, reportConfig.SkipList, reportConfig.DisplayNames);
             (IEnumerable<dynamic> data, ViewDataDictionary ViewData
             , ActionContext ControllerContext
             , int ColumnsPerPage
             , string UserName
             , List<string> DataColumns)*/
            return pdfBytes;
            //return pdfBytes;
        }

        public Task<byte[]> ExportGridToPdf(ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ExportGridToPdf(ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, string reportId, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }

        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, string reportGUID, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }


    }
}