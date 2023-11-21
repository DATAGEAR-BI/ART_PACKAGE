using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Grid
{
    public class GridConstructor<TContext, TModel> : IGridConstructor<TContext, TModel> where TContext : DbContext
        where TModel : class
    {
        private readonly IDropDownMapper _dropDownMap;
        public GridConstructor(IBaseRepo<TContext, TModel> repo, IDropDownMapper dropDownMap)
        {
            Repo = repo;
            _dropDownMap = dropDownMap;
        }
        public IBaseRepo<TContext, TModel> Repo { get; private set; }

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
