using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper;
using ART_PACKAGE.Hubs;
using Data.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{
    public class GridConstructor<TContext, TModel> : IGridConstructor<TContext, TModel> where TContext : DbContext
        where TModel : class
    {
        private readonly IDropDownMapper _dropDownMap;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICsvExport _csvSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private static readonly Dictionary<int, int> fileProgress = new();



        public GridConstructor(IBaseRepo<TContext, TModel> repo, IDropDownMapper dropDownMap, IWebHostEnvironment webHostEnvironment, ICsvExport csvSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
        {
            Repo = repo;
            _dropDownMap = dropDownMap;
            _webHostEnvironment = webHostEnvironment;
            _csvSrv = csvSrv;
            _exportHub = exportHub;
            this.connections = connections;
        }
        public IBaseRepo<TContext, TModel> Repo { get; private set; }

        public string ExportGridToCsv(GridRequest gridRequest, string user, string gridId)
        {
            string folderGuid = Guid.NewGuid().ToString();
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), folderGuid);
            GridResult<TModel> dataRes = Repo.GetGridData(gridRequest);
            int total = dataRes.total;
            int totalcopy = total;
            int batch = 500_000;
            int round = 0;

            _csvSrv.OnProgressChanged += (recordsDone, fileNumber) =>
            {
                fileProgress[fileNumber] = recordsDone;
                float progress = fileProgress.Sum(x => x.Value) / (float)totalcopy;
                _exportHub.Clients.Clients(connections.GetConnections(user))
                               .SendAsync("updateExportProgress", progress * 100, folderGuid, gridId);
            };
            while (total > 0)
            {
                GridRequest roundReq = new()
                {
                    Skip = round * batch,
                    Take = batch,
                    Filter = gridRequest.Filter,
                    Sort = gridRequest.Sort,
                    Group = gridRequest.Group,
                    All = gridRequest.All,
                    IdColumn = gridRequest.IdColumn,
                    SelectedValues = gridRequest.SelectedValues,
                };

                int localRound = round + 1;

                Task.Run(() => _csvSrv.ExportData<TContext, TModel>(roundReq, totalcopy, folderPath, "Test.csv", localRound, user));

                total -= batch;
                round++;
            }
            return folderGuid;
        }

        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User)
        {
            ReportConfig? reportConfig = ReportsConfig.CONFIG.ContainsKey(controller.ToLower()) ? ReportsConfig.CONFIG[controller.ToLower()] : null;
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
                showPdfBtn = hasConfig && (reportConfig.ShowExportPdf is null || reportConfig.ShowExportPdf(User))
            };
            return conf;
        }

        public GridResult<TModel> GetGridData(GridRequest request, Expression<Func<TModel, bool>> baseCondition)
        {
            GridResult<TModel> dataRes = Repo.GetGridData(request);
            if (baseCondition is not null)
            {
                dataRes.data = dataRes.data?.Where(baseCondition);
                dataRes.total = dataRes.data.Count();
            }
            return dataRes;
        }
    }
}
