namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiostransawaitiapprlreportConfig : ReportConfig
    {
        public arttiostransawaitiapprlreportConfig()
        {

            SkipList = new List<string>(){ "RefnoPfix",
"RefnoSerl",
"Workgroup",
"CcyCed",
"BhalfBrn",
"PcpGfcun",
"PcpCusMnm",
"PcpSwBank",
"PcpSwCtr",
"PcpSwLoc",
"PcpSwBranch",
"NpcpGfcun",
"NpcpCusMnm",
"NpcpSwBank",
"NpcpSwCtr",
"NpcpSwLoc",
"NpcpSwBranch",
"Language",
"Shortname",
"Isfinished",
"Type",
"Descr" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Fullname" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descri56" , new GridColumnConfiguration { DisplayName = "Team"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventReference" , new GridColumnConfiguration { DisplayName = "Event Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Event Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Started" , new GridColumnConfiguration { DisplayName = "Event Started"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpAddress1" , new GridColumnConfiguration { DisplayName = "Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Touched" , new GridColumnConfiguration { DisplayName = "Last Amended"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpAddress1" , new GridColumnConfiguration { DisplayName = "Non Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ccy" , new GridColumnConfiguration { DisplayName = "Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmountEgp" , new GridColumnConfiguration { DisplayName = "Amount Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Lstmoduser" , new GridColumnConfiguration { DisplayName = "User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RefnoPfix" , new GridColumnConfiguration { DisplayName = "RefnoPfix"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RefnoSerl" , new GridColumnConfiguration { DisplayName = "RefnoSerl"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Workgroup" , new GridColumnConfiguration { DisplayName = "Workgroup"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CcyCed" , new GridColumnConfiguration { DisplayName = "CcyCed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BhalfBrn" , new GridColumnConfiguration { DisplayName = "BhalfBrn"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpGfcun" , new GridColumnConfiguration { DisplayName = "PcpGfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpCusMnm" , new GridColumnConfiguration { DisplayName = "PcpCusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwBank" , new GridColumnConfiguration { DisplayName = "PcpSwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwCtr" , new GridColumnConfiguration { DisplayName = "PcpSwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwLoc" , new GridColumnConfiguration { DisplayName = "PcpSwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwBranch" , new GridColumnConfiguration { DisplayName = "PcpSwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpGfcun" , new GridColumnConfiguration { DisplayName = "NpcpGfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpCusMnm" , new GridColumnConfiguration { DisplayName = "NpcpCusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwBank" , new GridColumnConfiguration { DisplayName = "NpcpSwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwCtr" , new GridColumnConfiguration { DisplayName = "NpcpSwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwLoc" , new GridColumnConfiguration { DisplayName = "NpcpSwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwBranch" , new GridColumnConfiguration { DisplayName = "NpcpSwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Language" , new GridColumnConfiguration { DisplayName = "Language"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Shortname" , new GridColumnConfiguration { DisplayName = "Shortname"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Isfinished" , new GridColumnConfiguration { DisplayName = "Isfinished"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Type" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descr" , new GridColumnConfiguration { DisplayName = "Descr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}