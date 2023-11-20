using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper;
using Data.Data.SASAml;
using MediatR;

namespace ART_PACKAGE.Queries.IntializeGridRequest
{
    public class IntializeGridHandler : IRequestHandler<IntializeGridRequest, GridIntializationConfiguration>
    {
        private readonly IDropDownMapper _dropDownMap;

        public IntializeGridHandler(IDropDownMapper dropDownMap)
        {
            _dropDownMap = dropDownMap;
        }

        public async Task<GridIntializationConfiguration> Handle(IntializeGridRequest request, CancellationToken cancellationToken)
        {
            string controller = request.Controller;
            ReportConfig reportConfig = ReportsConfig.CONFIG[controller.ToLower()];
            Dictionary<string, List<SelectItem>> DropDownColumn = _dropDownMap.GetDorpDownForReport(controller);
            List<string> ColumnsToSkip = reportConfig.SkipList;
            Dictionary<string, GridColumnConfiguration> DisplayNames = reportConfig.DisplayNames;

            return new GridIntializationConfiguration()
            {
                columns = GridHelprs.GetColumns<ArtAmlAlertDetailView>(DropDownColumn, DisplayNames, ColumnsToSkip),
                containsActions = false,
                selectable = true
            };
        }
    }
}
