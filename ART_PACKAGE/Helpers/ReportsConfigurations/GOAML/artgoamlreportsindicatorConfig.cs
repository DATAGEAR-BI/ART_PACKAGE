using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artgoamlreportsindicatorConfig : ReportConfig
    {
        public artgoamlreportsindicatorConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"ReportId" , new GridColumnConfiguration { DisplayName = "Report ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Indicator" , new GridColumnConfiguration { DisplayName = "Indicator Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Description" , new GridColumnConfiguration { DisplayName = "Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            ReportTitle = "GOAML Reports Indicatores";
            ReportDescription = "Presents each GOAML report with the related indicators";



        }
    }
}