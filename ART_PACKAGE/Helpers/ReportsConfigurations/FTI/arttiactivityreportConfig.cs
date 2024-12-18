using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiactivityreportConfig : ReportConfig
    {
        public arttiactivityreportConfig()
        {

            SkipList = new List<string>(){ "Product",
"Touched",
"Relmstrref",
"SwBank",
"SwCtr",
"SwLoc",
"SwBranch",
"CusMnm",
"Gfcun",
"Gfcun12",
"CusMnm12",
"SwBank12",
"SwCtr12",
"SwLoc12",
"SwBranch12",
"CcyCed",
"Relmstrref12",
"BhalfBrn",
"Started",
"StartedFilter",
"Language",
"Stepdescr",
"BaseStatus" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Team" , new GridColumnConfiguration { DisplayName = "Team"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventRef" , new GridColumnConfiguration { DisplayName = "Event Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventStatus" , new GridColumnConfiguration { DisplayName = "Event Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartDate" , new GridColumnConfiguration { DisplayName = "Event Start Date"  , Format = "{0:dd/MM/yyyy}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartTime" , new GridColumnConfiguration { DisplayName = "Event Start Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address1" , new GridColumnConfiguration { DisplayName = "Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address12" , new GridColumnConfiguration { DisplayName = "Non principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ccy" , new GridColumnConfiguration { DisplayName = "Event Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmountEgp" , new GridColumnConfiguration { DisplayName = "Amount Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Lstmoduser" , new GridColumnConfiguration { DisplayName = "User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Shortname" , new GridColumnConfiguration { DisplayName = "Event"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Product" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Touched" , new GridColumnConfiguration { DisplayName = "Touched"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Relmstrref" , new GridColumnConfiguration { DisplayName = "Relmstrref"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBank" , new GridColumnConfiguration { DisplayName = "SwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwCtr" , new GridColumnConfiguration { DisplayName = "SwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwLoc" , new GridColumnConfiguration { DisplayName = "SwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBranch" , new GridColumnConfiguration { DisplayName = "SwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CusMnm" , new GridColumnConfiguration { DisplayName = "CusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Gfcun" , new GridColumnConfiguration { DisplayName = "Gfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Gfcun12" , new GridColumnConfiguration { DisplayName = "Gfcun12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CusMnm12" , new GridColumnConfiguration { DisplayName = "CusMnm12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBank12" , new GridColumnConfiguration { DisplayName = "SwBank12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwCtr12" , new GridColumnConfiguration { DisplayName = "SwCtr12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwLoc12" , new GridColumnConfiguration { DisplayName = "SwLoc12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBranch12" , new GridColumnConfiguration { DisplayName = "SwBranch12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CcyCed" , new GridColumnConfiguration { DisplayName = "CcyCed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Relmstrref12" , new GridColumnConfiguration { DisplayName = "Relmstrref12"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BhalfBrn" , new GridColumnConfiguration { DisplayName = "BhalfBrn"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Started" , new GridColumnConfiguration { DisplayName = "Started"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartedFilter" , new GridColumnConfiguration { DisplayName = "StartedFilter"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Language" , new GridColumnConfiguration { DisplayName = "Language"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BaseStatus" , new GridColumnConfiguration { DisplayName = "BaseStatus"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Stepdescr" , new GridColumnConfiguration { DisplayName = "Stepdescr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };




            ReportTitle = "Activity Report";
            ReportDescription = "This report produces information for a single master record or for all master records, showing what events have been initiated for each master record and the status of the current active steps for each event within it";


        }
    }
}