using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiperiodicchrgspayreportConfig : ReportConfig
    {
        public arttiperiodicchrgspayreportConfig()
        {

            SkipList = new List<string>(){ "BhalfBrn",
"NpcpGfcun",
"NpcpCusMnm",
"NpcpSwBank",
"NpcpSwCtr",
"NpcpSwLoc",
"NpcpSwBranch",
"NpcpAddress11",
"ChgGfcun1",
"ChgCusMnm1",
"ChgSwBank1",
"ChgSwCtr1",
"ChgSwLoc1",
"ChgSwBranch1",
"PcpGfcun",
"PcpCusMnm",
"PcpSwBank",
"PcpSwCtr",
"PcpSwLoc",
"PcpSwBranch",
"Outccyced",
"Relmstrref",
"Id",
"SuppAcc",
"EndDat",
"StartDat",
"Firststart",
"Chgpextraday",
"Workgroup",
"Ddate",
"ChargeAmt",
"ChargeCcy",
"ChargeAmtEgp" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Fullname" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descr" , new GridColumnConfiguration { DisplayName = "Charge Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpAddress1" , new GridColumnConfiguration { DisplayName = "Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Payrec" , new GridColumnConfiguration { DisplayName = "Pay/Receive"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstamt" , new GridColumnConfiguration { DisplayName = "Current Available Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstccy" , new GridColumnConfiguration { DisplayName = "Current Available Amount Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OutstamtEgp" , new GridColumnConfiguration { DisplayName = "Current Available Amount Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpAddress1" , new GridColumnConfiguration { DisplayName = "Non-Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchAmt" , new GridColumnConfiguration { DisplayName = "Projected Total Charges"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchCcy" , new GridColumnConfiguration { DisplayName = "Projected Total Charges Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchAmtEgp" , new GridColumnConfiguration { DisplayName = "Projected Total Charges EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AccrueAmt" , new GridColumnConfiguration { DisplayName = "Total Accrued/Amortized Amount to date"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AccrueCcy" , new GridColumnConfiguration { DisplayName = "Total Accrued/Amortized Amount to date Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AccrueAmtEgp" , new GridColumnConfiguration { DisplayName = "Total Accrued/Amortized Amount to date EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descr1" , new GridColumnConfiguration { DisplayName = "Commission Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BhalfBrn" , new GridColumnConfiguration { DisplayName = "BhalfBrn"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpGfcun" , new GridColumnConfiguration { DisplayName = "NpcpGfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpCusMnm" , new GridColumnConfiguration { DisplayName = "NpcpCusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwBank" , new GridColumnConfiguration { DisplayName = "NpcpSwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwCtr" , new GridColumnConfiguration { DisplayName = "NpcpSwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwLoc" , new GridColumnConfiguration { DisplayName = "NpcpSwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpSwBranch" , new GridColumnConfiguration { DisplayName = "NpcpSwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NpcpAddress11" , new GridColumnConfiguration { DisplayName = "NpcpAddress11"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgGfcun1" , new GridColumnConfiguration { DisplayName = "ChgGfcun1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgCusMnm1" , new GridColumnConfiguration { DisplayName = "ChgCusMnm1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgSwBank1" , new GridColumnConfiguration { DisplayName = "ChgSwBank1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgSwCtr1" , new GridColumnConfiguration { DisplayName = "ChgSwCtr1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgSwLoc1" , new GridColumnConfiguration { DisplayName = "ChgSwLoc1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgSwBranch1" , new GridColumnConfiguration { DisplayName = "ChgSwBranch1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpGfcun" , new GridColumnConfiguration { DisplayName = "PcpGfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpCusMnm" , new GridColumnConfiguration { DisplayName = "PcpCusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwBank" , new GridColumnConfiguration { DisplayName = "PcpSwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwCtr" , new GridColumnConfiguration { DisplayName = "PcpSwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwLoc" , new GridColumnConfiguration { DisplayName = "PcpSwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PcpSwBranch" , new GridColumnConfiguration { DisplayName = "PcpSwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outccyced" , new GridColumnConfiguration { DisplayName = "Outccyced"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Relmstrref" , new GridColumnConfiguration { DisplayName = "Relmstrref"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Id" , new GridColumnConfiguration { DisplayName = "Id"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SuppAcc" , new GridColumnConfiguration { DisplayName = "SuppAcc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EndDat" , new GridColumnConfiguration { DisplayName = "End Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartDat" , new GridColumnConfiguration { DisplayName = "Start Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Firststart" , new GridColumnConfiguration { DisplayName = "First start"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Chgpextraday" , new GridColumnConfiguration { DisplayName = "Chgpextraday"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Workgroup" , new GridColumnConfiguration { DisplayName = "Team"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ddate" , new GridColumnConfiguration { DisplayName = "Ddate"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChargeCcy" , new GridColumnConfiguration { DisplayName = "ChargeCcy"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChargeAmtEgp" , new GridColumnConfiguration { DisplayName = "ChargeAmtEgp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}