using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class lastloginperdayviewConfig : ReportConfig
    {
        public lastloginperdayviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AppName" , new GridColumnConfiguration { DisplayName = "App Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DeviceName" , new GridColumnConfiguration { DisplayName = "Device Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ip" , new GridColumnConfiguration { DisplayName = "IP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DeviceType" , new GridColumnConfiguration { DisplayName = "Device Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Logindatetime" , new GridColumnConfiguration { DisplayName = "Last Login Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}