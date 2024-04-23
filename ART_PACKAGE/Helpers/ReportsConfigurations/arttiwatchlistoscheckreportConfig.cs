namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiwatchlistoscheckreportConfig : ReportConfig
    {
        public arttiwatchlistoscheckreportConfig()
        {

            SkipList = new List<string>(){ "RefnoPfix",
"RefnoSerl",
"Touched",
"Amount",
"Ccy",
"AmountEgp",
"Workgroup",
"CcyCed",
"BhalfBrn",
"Pcpgfcun",
"PcpcusMnm",
"PcpswBank",
"PcpswCtr",
"PcpswLoc",
"PcpswBranch",
"Npcpgfcun",
"NpcpcusMnm",
"NpcpswBank",
"NpcpswCtr",
"NpcpswLoc",
"NpcpswBranch",
"Language",
"Isfinished",
"Type",
"Lstmoduser" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Fullname" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descri56" , new GridColumnConfiguration { DisplayName = "Team"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Referance"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Pcpaddress1" , new GridColumnConfiguration { DisplayName = "Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Npcpaddress1" , new GridColumnConfiguration { DisplayName = "Non-Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Longna85" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Shortname" , new GridColumnConfiguration { DisplayName = "Event"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Started" , new GridColumnConfiguration { DisplayName = "Event Started"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descr" , new GridColumnConfiguration { DisplayName = "Step"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RefnoPfix" , new GridColumnConfiguration { DisplayName = "RefnoPfix"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RefnoSerl" , new GridColumnConfiguration { DisplayName = "RefnoSerl"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Touched" , new GridColumnConfiguration { DisplayName = "Touched"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ccy" , new GridColumnConfiguration { DisplayName = "Ccy"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmountEgp" , new GridColumnConfiguration { DisplayName = "AmountEgp"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Workgroup" , new GridColumnConfiguration { DisplayName = "Workgroup"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CcyCed" , new GridColumnConfiguration { DisplayName = "CcyCed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BhalfBrn" , new GridColumnConfiguration { DisplayName = "BhalfBrn"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Pcpgfcun" , new GridColumnConfiguration { DisplayName = "Pcpgfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpcusMnm" , new GridColumnConfiguration { DisplayName = "PcpcusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpswBank" , new GridColumnConfiguration { DisplayName = "PcpswBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpswCtr" , new GridColumnConfiguration { DisplayName = "PcpswCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpswLoc" , new GridColumnConfiguration { DisplayName = "PcpswLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpswBranch" , new GridColumnConfiguration { DisplayName = "PcpswBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Npcpgfcun" , new GridColumnConfiguration { DisplayName = "Npcpgfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpcusMnm" , new GridColumnConfiguration { DisplayName = "NpcpcusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpswBank" , new GridColumnConfiguration { DisplayName = "NpcpswBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpswCtr" , new GridColumnConfiguration { DisplayName = "NpcpswCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpswLoc" , new GridColumnConfiguration { DisplayName = "NpcpswLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpswBranch" , new GridColumnConfiguration { DisplayName = "NpcpswBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Language" , new GridColumnConfiguration { DisplayName = "Language"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Isfinished" , new GridColumnConfiguration { DisplayName = "Isfinished"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Type" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Lstmoduser" , new GridColumnConfiguration { DisplayName = "Lstmoduser"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}