using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artkycexpiredidConfig : ReportConfig
    {
        public artkycexpiredidConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"ClientNumber" , new GridColumnConfiguration { DisplayName = "Client Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntityName" , new GridColumnConfiguration { DisplayName = "Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IdNumber" , new GridColumnConfiguration { DisplayName = "ID Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IdExpireDate" , new GridColumnConfiguration { DisplayName = "ID Expire Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };

            ReportTitle = "Expired ID customers Report";
            ReportDescription = "Presents all expired ID customers need to be update their expired IDs with the related information below";





        }
    }
}