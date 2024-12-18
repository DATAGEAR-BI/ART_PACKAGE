using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artcustomreportConfig : ReportConfig
    {
        public artcustomreportConfig()
        {

            SkipList = new List<string>(){ "Users",
"Schema",
"Columns",
"Charts",
"UserReports" };



            ContainsActions = true;

            Actions = new List<GridButton>(){ new GridButton { action = "GoToReportDetails" , text = "Show" ,icon = "k-i-redo" },
new GridButton { action = "shareReport" , text = "Share" ,icon = "k-i-share" },
new GridButton { action = "unShareReport" , text = "UnShare" ,icon = "k-i-cancel" } };



        }
    }
}