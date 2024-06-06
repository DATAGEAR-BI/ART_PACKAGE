using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artauditreportviewconfig : ReportConfig
    {
        public artauditreportviewconfig()
        {
            ReportTitle = "AML Audit Report";
            ReportDescription = "This report presents all users' actions with the related information below";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Date" , new GridColumnConfiguration { DisplayName = "Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Customer" , new GridColumnConfiguration { DisplayName = "Customer"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Time" , new GridColumnConfiguration { DisplayName = "Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"User" , new GridColumnConfiguration { DisplayName = "User"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ip" , new GridColumnConfiguration { DisplayName = "IP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Parameter" , new GridColumnConfiguration { DisplayName = "Parameter"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Details" , new GridColumnConfiguration { DisplayName = "Details"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"DurationInSeconds" , new GridColumnConfiguration { DisplayName = "Duration In Seconds"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"Alert" , new GridColumnConfiguration { DisplayName = "Alert"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"Case" , new GridColumnConfiguration { DisplayName = "Case"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"RiskAssessment" , new GridColumnConfiguration { DisplayName = "Risk Assessment"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
            };



        }
    }
}