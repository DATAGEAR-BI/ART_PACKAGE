namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttimastereventhistoryConfig : ReportConfig
    {
        public arttimastereventhistoryConfig()
        {

            SkipList = new List<string>(){ "Product",
"Outstamt",
"Outstccy",
"OutstamtEgp",
"Started",
"CrossRef",
"StepStatus",
"BranchCode",
"Gfcun",
"CusMnm",
"SwBank",
"SwCtr",
"SwLoc",
"SwBranch",
"Team",
"Extrainfo",
"Language",
"Isfinished",
"Stepkey" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Shortname" , new GridColumnConfiguration { DisplayName = "Event"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventRef" , new GridColumnConfiguration { DisplayName = "Event Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Stepdescr" , new GridColumnConfiguration { DisplayName = "Event Steps"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartedFilter" , new GridColumnConfiguration { DisplayName = "Event Start Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Master Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address1" , new GridColumnConfiguration { DisplayName = "Principal Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StatusEv" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ccy" , new GridColumnConfiguration { DisplayName = "Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmountEgp" , new GridColumnConfiguration { DisplayName = "Amount Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Bookoffdat" , new GridColumnConfiguration { DisplayName = "Book Off Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExpiryDat" , new GridColumnConfiguration { DisplayName = "Expiry Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DeactDate" , new GridColumnConfiguration { DisplayName = "Deactivation Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Product" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstamt" , new GridColumnConfiguration { DisplayName = "Outstamt"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstccy" , new GridColumnConfiguration { DisplayName = "Outstccy"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OutstamtEgp" , new GridColumnConfiguration { DisplayName = "OutstamtEgp"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Started" , new GridColumnConfiguration { DisplayName = "Started"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CrossRef" , new GridColumnConfiguration { DisplayName = "CrossRef"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StepStatus" , new GridColumnConfiguration { DisplayName = "StepStatus"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchCode" , new GridColumnConfiguration { DisplayName = "BranchCode"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Gfcun" , new GridColumnConfiguration { DisplayName = "Gfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CusMnm" , new GridColumnConfiguration { DisplayName = "CusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBank" , new GridColumnConfiguration { DisplayName = "SwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwCtr" , new GridColumnConfiguration { DisplayName = "SwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwLoc" , new GridColumnConfiguration { DisplayName = "SwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBranch" , new GridColumnConfiguration { DisplayName = "SwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Team" , new GridColumnConfiguration { DisplayName = "Team"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Extrainfo" , new GridColumnConfiguration { DisplayName = "Extrainfo"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Language" , new GridColumnConfiguration { DisplayName = "Language"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Isfinished" , new GridColumnConfiguration { DisplayName = "Isfinished"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Stepkey" , new GridColumnConfiguration { DisplayName = "Stepkey"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}