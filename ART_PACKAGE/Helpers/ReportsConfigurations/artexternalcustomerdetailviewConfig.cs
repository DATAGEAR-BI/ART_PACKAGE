namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artexternalcustomerdetailviewConfig : ReportConfig
    {
        public artexternalcustomerdetailviewConfig()
        {

            SkipList = new List<string>(){ "CustomerTaxId",
"GovernorateName",
"StreetPostalCode",
"StreetCountryCode",
"StreetCountryName",
"PhoneNumber1",
"PhoneNumber2" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CustomerName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerNumber" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerType" , new GridColumnConfiguration { DisplayName = "Customer Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerIdentificationId" , new GridColumnConfiguration { DisplayName = "Customer Identification ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerIdentificationType" , new GridColumnConfiguration { DisplayName = "Customer Identification Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerDateOfBirth" , new GridColumnConfiguration { DisplayName = "Customer Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StreetAddress1" , new GridColumnConfiguration { DisplayName = "Street Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CityName" , new GridColumnConfiguration { DisplayName = "City Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ResidenceCountryName" , new GridColumnConfiguration { DisplayName = "Residence Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CitizenshipCountryName" , new GridColumnConfiguration { DisplayName = "Citizenship Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}