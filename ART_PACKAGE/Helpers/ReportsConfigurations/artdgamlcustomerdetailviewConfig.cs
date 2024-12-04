using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlcustomerdetailviewConfig : ReportConfig
    {
        public artdgamlcustomerdetailviewConfig()
        {

            SkipList = new List<string>(){ "CustomerTaxId",
"GovernorateName",
"DoingBusinessAsName",
"StreetPostalCode",
"StreetCountryCode",
"MailingAddress1",
"MailingCityName",
"MailingPostalCode",
"EmployeeNumber",
"EmployerName",
"EmployerPhoneNumber",
"EmailAddress",
"PhoneNumber1",
"PhoneNumber2",
"PhoneNumber3",
"AnnualIncomeAmount",
"NetWorthAmount",
"LastRiskAssessmentDate" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CustomerName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerNumber" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerStatus" , new GridColumnConfiguration { DisplayName = "Customer Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerType" , new GridColumnConfiguration { DisplayName = "Customer Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerIdentificationId" , new GridColumnConfiguration { DisplayName = "Customer Identification ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerIdentificationType" , new GridColumnConfiguration { DisplayName = "Customer Identification Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerDateOfBirth" , new GridColumnConfiguration { DisplayName = "Customer Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskClassification" , new GridColumnConfiguration { DisplayName = "Risk Classification"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StreetAddress1" , new GridColumnConfiguration { DisplayName = "Street Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CityName" , new GridColumnConfiguration { DisplayName = "City Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IsEmployee" , new GridColumnConfiguration { DisplayName = "Is Employee"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ResidenceCountryName" , new GridColumnConfiguration { DisplayName = "Residence Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StreetCountryName" , new GridColumnConfiguration { DisplayName = "Street Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MailingCountryName" , new GridColumnConfiguration { DisplayName = "Mailing Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CitizenshipCountryName" , new GridColumnConfiguration { DisplayName = "Citizenship Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OccupationDesc" , new GridColumnConfiguration { DisplayName = "Occupation Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IndustryDesc" , new GridColumnConfiguration { DisplayName = "Industry Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MaritalStatusDesc" , new GridColumnConfiguration { DisplayName = "Marital Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerSinceDate" , new GridColumnConfiguration { DisplayName = "Customer Since Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NonProfitOrgInd" , new GridColumnConfiguration { DisplayName = "Non Profit Org IND"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PoliticallyExposedPersonInd" , new GridColumnConfiguration { DisplayName = "PEP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            ReportTitle = "Customers Details Report";
            ReportDescription = "Presents all customers details";



        }
    }
}