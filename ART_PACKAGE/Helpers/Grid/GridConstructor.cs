using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper;
using Data.Services;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Grid
{
    public class GridConstructor<TContext, TModel> : IGridConstructor<TContext, TModel> where TContext : DbContext
        where TModel : class
    {
        private readonly IDropDownMapper _dropDownMap;
        private readonly ICsvExport _csvSrv;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public GridConstructor(IBaseRepo<TContext, TModel> repo, IDropDownMapper dropDownMap, ICsvExport csvSrv, IWebHostEnvironment webHostEnvironment, IBackgroundJobClient backgroundJobClient)
        {
            Repo = repo;
            _dropDownMap = dropDownMap;
            _csvSrv = csvSrv;
            _webHostEnvironment = webHostEnvironment;
            _backgroundJobClient = backgroundJobClient;
        }
        public IBaseRepo<TContext, TModel> Repo { get; private set; }

        public string ExportGridToCsv(GridRequest gridRequest)
        {
            string folderGuid = Guid.NewGuid().ToString();
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), folderGuid);
            GridResult<TModel> dataRes = Repo.GetGridData(gridRequest);
            var total = dataRes.total;
            var batch = 500_000;
            var round = 0;
            while (total > 0)
            {
                var roundData = dataRes.data.Skip(round * batch).Take(batch);
                total -= batch;
                round++;
            }
            _ = _backgroundJobClient.Enqueue(() => _csvSrv.ExportData(dataRes.data.Take(1000).ToList(), dataRes.total, folderPath, "Test.csv"));
            return folderGuid;
        }

        public GridIntializationConfiguration IntializeGrid(string controller, bool containsActions = false, bool selectable = false, List<GridButton>? toolbar = null, List<GridButton>? action = null)
        {
            ReportConfig reportConfig = ReportsConfig.CONFIG[controller.ToLower()];
            Dictionary<string, List<SelectItem>> DropDownColumn = _dropDownMap.GetDorpDownForReport(controller);
            List<string> ColumnsToSkip = reportConfig.SkipList;
            Dictionary<string, GridColumnConfiguration> DisplayNames = reportConfig.DisplayNames;

            return new GridIntializationConfiguration()
            {
                columns = GridHelprs.GetColumns<TModel>(DropDownColumn, DisplayNames, ColumnsToSkip),
                selectable = selectable,
                toolbar = toolbar,
                actions = action,
                containsActions = containsActions,
            };
        }
    }
}
