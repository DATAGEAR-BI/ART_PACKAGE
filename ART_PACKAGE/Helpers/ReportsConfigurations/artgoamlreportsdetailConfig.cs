using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artgoamlreportsdetailConfig : ReportConfig
    {
        public artgoamlreportsdetailConfig()
        {

            SkipList = new List<string>(){ "Version",
"Isvalid",
"Location",
"Rentityid",
"Reportcloseddate",
"Reportrisksignificance",
"Reportxml",
"Submissioncode" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Id" , new GridColumnConfiguration { DisplayName = "Report ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reportcode" , new GridColumnConfiguration { DisplayName = "Report Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reportstatuscode" , new GridColumnConfiguration { DisplayName = "Report Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reportcreateddate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Submissiondate" , new GridColumnConfiguration { DisplayName = "Submission Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Priority" , new GridColumnConfiguration { DisplayName = "Priority"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reportuserlockid" , new GridColumnConfiguration { DisplayName = "Locked By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reportcreatedby" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Currencycodelocal" , new GridColumnConfiguration { DisplayName = "Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedDate" , new GridColumnConfiguration { DisplayName = "Last Updated Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Entityreference" , new GridColumnConfiguration { DisplayName = "Entity Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Fiurefnumber" , new GridColumnConfiguration { DisplayName = "FUI Reference Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Rentitybranch" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reportingpersontype" , new GridColumnConfiguration { DisplayName = "Reporting Person Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reason" , new GridColumnConfiguration { DisplayName = "Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}