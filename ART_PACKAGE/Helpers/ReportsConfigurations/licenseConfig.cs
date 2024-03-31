using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class licenseConfig : ReportConfig
    {
        public licenseConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"ExpireDate" , new GridColumnConfiguration { DisplayName = "Expire Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RemainingDays" , new GridColumnConfiguration { DisplayName = "Remaining Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };





            Toolbar = new List<GridButton>() { new GridButton { action = "addreplic", text = "Add/Replace Module License", icon = "k-i-folder-up" } };

        }
    }
}