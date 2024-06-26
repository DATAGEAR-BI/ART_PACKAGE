using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlipntransactionconfig : ReportConfig
    {
        public artdgamlipntransactionconfig()
        {





            SkipList = new List<string>() { };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
{"EmployeeNumber" , new GridColumnConfiguration { DisplayName = "Employee Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployeeName" , new GridColumnConfiguration { DisplayName = "Employee Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Department" , new GridColumnConfiguration { DisplayName = "Department"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Division" , new GridColumnConfiguration { DisplayName = "Division"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Job" , new GridColumnConfiguration { DisplayName = "Job"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Grad" , new GridColumnConfiguration { DisplayName = "Grad"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionReference" , new GridColumnConfiguration { DisplayName = "Transaction Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionType" , new GridColumnConfiguration { DisplayName = "Transaction Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionDate" , new GridColumnConfiguration { DisplayName = "Transaction Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BaseAmount" , new GridColumnConfiguration { DisplayName = "Base Amount(EGP)"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EquivalentAmount" , new GridColumnConfiguration { DisplayName = "Equivalent Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } ,
            { "EquivalentCurrency" , new GridColumnConfiguration { DisplayName = "Equivalent Currency", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "SenderName" , new GridColumnConfiguration { DisplayName = "Sender Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "TransactionReason" , new GridColumnConfiguration { DisplayName = "Transaction Reason", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "CustomerID" , new GridColumnConfiguration { DisplayName = "Customer Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "AccountNumber" , new GridColumnConfiguration { DisplayName = "Account Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "AccountName" , new GridColumnConfiguration { DisplayName = "Account Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
        };

            ReportTitle = "IPN Transaction";
            ReportDescription = "Presents all IPN transactions (TRANS_TYPE_CD in (268, 274, 295, Z06))  for only staff with the related information as below";






        }
    }
}