using Data.Data.AmlAnalysis;
using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAmlAnalysisViewTbConfig : ReportConfig
    {
        public ArtAmlAnalysisViewTbConfig()
        {
            List<string> columnsToKeep =
                new()
                {
                    "PartyNumber",
                    "SegmentSorted",
                    "AlertsCount",
                    "AlertsCnt",
                    "ClosedAlertsCount",
                    "TotalWireCAmt",
                    "MaxMls",
                    "PartyName",
                    "PartyTypeDesc",
                    "OccupationDesc",
                    "TotalWireDAmt",
                    "EmployeeInd",
                    "OwnerUserId",
                    "BranchName",
                    "IndustryDesc",
                    "TotalCreditAmount",
                    "TotalDebitAmount",
                    "TotalCreditCnt",
                    "TotalDebitCnt",
                    "TotalAmount",
                    "TotalCnt",
                    "AvgWireCAmt",
                    "MaxWireCAmt",
                    "TotalWireDCnt",
                    "MinWireDAmt",
                    "AvgWireDAmt",
                    "TotalCashCAmt",
                    "TotalCashCCnt",
                    "MinCashCAmt",
                    "AvgCashCAmt",
                    "MaxCashCAmt",
                    "AvgCashDAmt",
                    "TotalCashDAmt",
                    "TotalCashDCnt",
                    "MinCashDAmt",
                    "MaxCashDAmt",
                    "TotalCheckDCnt",
                    "AvgCheckDAmt",
                    "MaxCheckDAmt",
                    "TotalCheckDAmt",
                    "MinCheckDAmt",
                    "MaxClearingcheckCAmt",
                    "MinClearingcheckCAmt",
                    "AvgClearingcheckCAmt",
                    "TotalClearingcheckCAmt",
                    "TotalClearingcheckCCnt",
                    "MaxClearingcheckDAmt",
                    "AvgClearingcheckDAmt",
                    "TotalClearingcheckDAmt",
                    "TotalClearingcheckDCnt",
                    "MinClearingcheckDAmt",
                    "IndustryCode",
                    "Prediction"
                };
            DisplayNames = new()
            {
                {
                    nameof(ArtAmlAnalysisViewTb.Prediction),
                    new GridColumnConfiguration() { Template = "Aml_Analysis_prediction" }
                }
            };
            HasFixedWidth = true;
            SkipList = typeof(ArtAmlAnalysisViewTb)
                .GetProperties()
                .Where(x => !columnsToKeep.Contains(x.Name))
                .Select(x => x.Name)
                .ToList();
            Selectable = true;
            Toolbar = new List<GridButton>()
            {
                new GridButton()
                {
                    action = "closeAlerts",
                    text = "Close Alerts",
                    icon = "k-i-cancel-outline"
                },
                new GridButton()
                {
                    action = "routeAlerts",
                    text = "Route Alerts",
                    icon = "k-i-redo"
                },
            };
            HasFixedWidth = true;
        }
    }
}
