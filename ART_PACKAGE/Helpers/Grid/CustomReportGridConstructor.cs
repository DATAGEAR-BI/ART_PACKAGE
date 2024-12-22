using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Handlers;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using ART_PACKAGE.Hubs;
using Data.GOAML;
using Data.Services;
using Data.Services.CustomReport;
using Data.Services.Grid;
using Data.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using sun.net;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{

    public class CustomReportGridConstructor : ICustomReportGridConstructor
    {
        private readonly DBFactory _dbFactory;
        private readonly ICsvExport _csvSrv;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static  Dictionary<int, int> fileProgress = new();
        private static Dictionary<int, int> chunksProgress = new();

        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private readonly ProcessesHandler _processesHandler;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly PDF _pdfSettings;

        public CustomReportGridConstructor(ICustomReportRepo repo, DBFactory dbFactory, ICsvExport csvSrv, IWebHostEnvironment webHostEnvironment, IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IPdfService pdfSrv, ProcessesHandler processesHandler, IConfiguration _config, IOptions<PDF> pdfSettings)
        {
            Repo = repo;
            _dbFactory = dbFactory;
            _csvSrv = csvSrv;
            _webHostEnvironment = webHostEnvironment;
            _exportHub = exportHub;
            this.connections = connections;
            _pdfSrv = pdfSrv;
            _processesHandler = processesHandler;
            this._config = _config;
            _pdfSettings = pdfSettings.Value;

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

        public GridResult<Dictionary<string, object>> GetGridData(KendoGridRequest request, Expression<Func<object, bool>> baseCondition, IEnumerable<Expression<Func<object, object>>>? includes = null)
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

        public GridResult<Dictionary<string, object>> GetGridData(int reportId, KendoGridRequest request)
        {
            ArtSavedCustomReport report = Repo.GetReport(reportId);
            Microsoft.EntityFrameworkCore.DbContext? schemaContext = _dbFactory.GetDbInstance(report.Schema.ToString());
            GridResult<Dictionary<string, object>> dataResult = Repo.GetGridData(schemaContext, report, request);
            return dataResult;
        }

        public IEnumerable<ChartDataDto> GetReportChartsData(int reportId, KendoGridRequest request)
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
                KendoGridRequest dataReq = new()
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

                _ = Task.Run(() => _csvSrv.ExportCustomData(report, roundReq, folderPath, "Report.csv", localRound, folderGuid, "tenantId"));

            }
            else
            {
                while (total > 0)
                {
                    KendoGridRequest dataReq = new()
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

                    _ = Task.Run(() => _csvSrv.ExportCustomData(report, roundReq, folderPath, "Report.csv", localRound, folderGuid, "tenantId"));

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

        public Task<string> ExportGridToPDFUsingIText(ExportPDFRequest exportRequest, string user, string gridId, string reportGUID,
            Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();

        }

        public async Task<string> ExportGridToPDFUsingIText(ExportPDFRequest exportRequest, string user, int gridId, string reportGUID,
       Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            string folderGuid = reportGUID;//Guid.NewGuid().ToString();
            exportRequest.PdfOptions = _pdfSettings;//while not using user configs
            exportRequest.PdfOptions.NumberOfColumnsInPage = exportRequest.IncludedColumns.Count();
            _processesHandler.AddProcess(reportGUID, "PDF");
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "PDF"), folderGuid);

            ArtSavedCustomReport report = Repo.GetReport(gridId);
            DbContext? schemaContext = _dbFactory.GetDbInstance(report.Schema.ToString());
            GridResult<Dictionary<string, object>> dataRes = Repo.GetGridData(schemaContext, report, exportRequest.DataReq);
            //IQueryable<CustomReportRecord> data = dataRes.data.Select(x => new CustomReportRecord() { Data = x });


            int total = dataRes.total;
            int totalcopy = total;
            var d = _config.GetValue<int>("export_Patch", 50000);// is not null ? _config.GetSection("export_Patch").ToString() : "500_000";
            //var saved_batch = Int32.Parse(_config.GetSection("export_Patch") is not null ? _config.GetSection("export_Patch").ToString() : "500_000");
            int batch = exportRequest.PdfOptions.NumberOfRowsInFile;// d;
            //500_000:
            int round = 0;
            fileProgress = new();
            chunksProgress = new();
            int totalchunks = 0;

            if (exportRequest.PdfOptions.UsingPartitionApproach)
                totalchunks = CalculateTotalChunks(total,

                    exportRequest.IncludedColumns.Count()
                    ,
                    batch,
                    exportRequest.IncludedColumns.Count()
                    ,
                    exportRequest.PdfOptions.NumberOfRowsInPage);
            else
                totalchunks = (int)Math.Ceiling((double)total / batch);


            _pdfSrv.OnProgressChanged += (recordsDone, fileNumber) =>
            {
                fileProgress[fileNumber] = recordsDone;
                var done = fileProgress.Values.Sum();
                decimal progress = done / (decimal)(totalcopy + totalchunks);

                _processesHandler.UpdateCompletionPercentage(reportGUID, progress * 100);
                /*if (progress < 1)
                {*/
                    _ = _exportHub.Clients.Clients(connections.GetConnections(user))
                                                   .SendAsync("updateExportPDFProgress", progress * 100, folderGuid, gridId);
                //}



            };
     

            
            while (total > 0)
            {
                KendoGridRequest dataReq = new()
                {
                    Skip = round * batch,
                    Take = batch,
                    Filter = exportRequest.DataReq.Filter,
                    Sort = exportRequest.DataReq.Sort,
                    Group = exportRequest.DataReq.Group,
                    All = exportRequest.DataReq.All,
                    IdColumn = exportRequest.DataReq.IdColumn,
                    SelectedValues = exportRequest.DataReq.SelectedValues,
                    IsStored = exportRequest.DataReq.IsStored,
                    QueryBuilderFilters = exportRequest.DataReq.QueryBuilderFilters,
                };
                ExportPDFRequest roundReq = new()
                {
                    DataReq = dataReq,
                    IncludedColumns = exportRequest.IncludedColumns.Select(x => (string)x.Clone()).ToList(),
                    PdfOptions = exportRequest.PdfOptions
                };
                int localRound = round + 1;

                _ = Task.Run(() => _pdfSrv.ITextPdf(roundReq, localRound, folderPath, "Report.pdf", reportGUID, gridId));

                total -= batch;
                round++;
            }
            return folderGuid;
        }
        protected int CalculateTotalChunks(int totalRows, int totalColumns, int rowsPerFile, int columnsPerChunk, int rowsPerChunk)
        {
            // Calculate the number of files
            int numberOfFiles = (int)Math.Ceiling((double)totalRows / rowsPerFile);
            int totalChunks = 0;

            for (int fileIndex = 0; fileIndex < numberOfFiles; fileIndex++)
            {
                // Calculate the number of rows in the current file
                int remainingRows = totalRows - (fileIndex * rowsPerFile);
                int rowsInFile = Math.Min(remainingRows, rowsPerFile);

                // Calculate the number of column groups (chunks by column)
                int columnGroups = (int)Math.Ceiling((double)totalColumns / columnsPerChunk);

                for (int columnGroup = 0; columnGroup < columnGroups; columnGroup++)
                {
                    // Calculate the number of chunks in the current column group
                    int rowChunks = (int)Math.Ceiling((double)rowsInFile / rowsPerChunk);
                    totalChunks += rowChunks;
                }
            }

            return totalChunks;
        }
        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, string reportGUID, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }
      

    }
}