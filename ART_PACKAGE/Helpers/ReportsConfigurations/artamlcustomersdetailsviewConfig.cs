using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artamlcustomersdetailsviewConfig : ReportConfig
    {
        public artamlcustomersdetailsviewConfig()
        {

            SkipList = new List<string>(){ "CustomerTaxId",
"DoingBusinessAsName",
"GovernorateName",
"StreetPostalCode",
"StreetCountryCode",
"StreetCountryName",
"MailingAddress1",
"MailingCityName",
"MailingPostalCode",
"MailingCountryName",
"IsEmployee",
"EmployeeNumber",
"EmployerName",
"EmployerPhoneNumber",
"EmailAddress",
"PhoneNumber3",
"AnnualIncomeAmount",
"NetWorthAmount",
"CityName",
"ResidenceCountryName",
"CitizenshipCountryName",
"NonProfitOrgInd",
"ActiveFlg" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CustomerName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerNumber" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerSinceDate" , new GridColumnConfiguration { DisplayName = "Customer Since Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerType" , new GridColumnConfiguration { DisplayName = "Customer Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NonProfitOrgInd" , new GridColumnConfiguration { DisplayName = "Non Profit Org Ind"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PoliticallyExposedPersonInd" , new GridColumnConfiguration { DisplayName = "PEP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CharityDonationsInd" , new GridColumnConfiguration { DisplayName = "Charity Donations Ind"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskClassification" , new GridColumnConfiguration { DisplayName = "Risk Classification"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ResidenceCountryName" , new GridColumnConfiguration { DisplayName = "Residence Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CitizenshipCountryName" , new GridColumnConfiguration { DisplayName = "Citizenship Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StreetAddress1" , new GridColumnConfiguration { DisplayName = "Street Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CityName" , new GridColumnConfiguration { DisplayName = "City Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerDateOfBirth" , new GridColumnConfiguration { DisplayName = "Customer Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OccupationDesc" , new GridColumnConfiguration { DisplayName = "Occupation Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MaritalStatusDesc" , new GridColumnConfiguration { DisplayName = "Marital Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IndustryDesc" , new GridColumnConfiguration { DisplayName = "Industry Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchNumber" , new GridColumnConfiguration { DisplayName = "Branch Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerStatus" , new GridColumnConfiguration { DisplayName = "Customer Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerLevel" , new GridColumnConfiguration { DisplayName = "Customer Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntitySegmentId" , new GridColumnConfiguration { DisplayName = "Current Segment Id"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastSegmentId" , new GridColumnConfiguration { DisplayName = "Last Segment Id"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerIdentificationId" , new GridColumnConfiguration { DisplayName = "Customer Identification ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PhoneNumber1" , new GridColumnConfiguration { DisplayName = "Phone Number1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PhoneNumber2" , new GridColumnConfiguration { DisplayName ="Phone Number2"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerAge" , new GridColumnConfiguration { DisplayName = "Customer Age"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Nationality2" , new GridColumnConfiguration { DisplayName = "Nationality 2"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Nationality3" , new GridColumnConfiguration { DisplayName = "Nationality 3"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastRiskAssessmentDate" , new GridColumnConfiguration { DisplayName = "Last Risk Assessment Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerIdentificationType" , new GridColumnConfiguration { DisplayName = "Customer Identification Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}