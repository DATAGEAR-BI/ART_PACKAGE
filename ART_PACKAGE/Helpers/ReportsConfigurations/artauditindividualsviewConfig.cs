using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artauditindividualsviewConfig : ReportConfig
    {
        public artauditindividualsviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CaseRk" , new GridColumnConfiguration { DisplayName = "Case Rk"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AKA" , new GridColumnConfiguration { DisplayName = "AKA"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OpeningReasonId" , new GridColumnConfiguration { DisplayName = "Opening Reason ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmlRiskCd" , new GridColumnConfiguration { DisplayName = "Aml Risk CD"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CitizenOrResident" , new GridColumnConfiguration { DisplayName = "Citizen Or Resident"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ClientNumber" , new GridColumnConfiguration { DisplayName = "Client Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CloseDate" , new GridColumnConfiguration { DisplayName = "Close Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ClosingReasonId" , new GridColumnConfiguration { DisplayName = "Closing Reason ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskClassValue" , new GridColumnConfiguration { DisplayName = "Risk Class Value"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerType" , new GridColumnConfiguration { DisplayName = "Customer Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DefaultBranch" , new GridColumnConfiguration { DisplayName = "Default Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NumberOfDependents" , new GridColumnConfiguration { DisplayName = "Number Of Dependents"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FirstName" , new GridColumnConfiguration { DisplayName = "First Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FullNameAr" , new GridColumnConfiguration { DisplayName = "Full Name AR"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FullNameEn" , new GridColumnConfiguration { DisplayName = "Full Name EN"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GenderCd" , new GridColumnConfiguration { DisplayName = "Gender CD"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EducationId" , new GridColumnConfiguration { DisplayName = "Education ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CbRiskId" , new GridColumnConfiguration { DisplayName = "Cb Risk ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"KycStatus" , new GridColumnConfiguration { DisplayName = "Kyc Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RaceId" , new GridColumnConfiguration { DisplayName = "Race ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastName" , new GridColumnConfiguration { DisplayName = "Last Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MaritalStatusCd" , new GridColumnConfiguration { DisplayName = "Marital Status CD"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MiddleName" , new GridColumnConfiguration { DisplayName = "Middle Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MotherName" , new GridColumnConfiguration { DisplayName = "Mother Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NationalityCode1" , new GridColumnConfiguration { DisplayName = "Nationality Code1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NationalityCode2" , new GridColumnConfiguration { DisplayName = "Nationality Code2"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NationalityCode3" , new GridColumnConfiguration { DisplayName = "Nationality Code3"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NextUpdateDate" , new GridColumnConfiguration { DisplayName = "Next Update Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CbRiskRate" , new GridColumnConfiguration { DisplayName = "Cb Risk Rate"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Religion" , new GridColumnConfiguration { DisplayName = "Religion"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ResidenceCountry" , new GridColumnConfiguration { DisplayName = "Residence Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskReason" , new GridColumnConfiguration { DisplayName = "Risk Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskCode" , new GridColumnConfiguration { DisplayName = "Risk Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SictorCode" , new GridColumnConfiguration { DisplayName = "Sictor Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Title" , new GridColumnConfiguration { DisplayName = "Title"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdateDate" , new GridColumnConfiguration { DisplayName = "Update Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdatedBy" , new GridColumnConfiguration { DisplayName = "Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"VisaType" , new GridColumnConfiguration { DisplayName = "Visa Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FirstNameEng" , new GridColumnConfiguration { DisplayName = "First Name EN"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastNameEng" , new GridColumnConfiguration { DisplayName = "Last Name EN"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MiddleNameEng" , new GridColumnConfiguration { DisplayName = "Middle Name EN"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NameLanguage" , new GridColumnConfiguration { DisplayName = "Name Language"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployeeIndicator" , new GridColumnConfiguration { DisplayName = "Employee Indicator"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EducationIdOther" , new GridColumnConfiguration { DisplayName = "Education ID Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SpouseBusiness" , new GridColumnConfiguration { DisplayName = "Spouse Business"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SpouseName" , new GridColumnConfiguration { DisplayName = "Spouse Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"VisaExpirationDate" , new GridColumnConfiguration { DisplayName = "Visa Expiration Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CbRiskRateOther" , new GridColumnConfiguration { DisplayName = "Cb Risk Rate Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ClosingReasonIdOther" , new GridColumnConfiguration { DisplayName = "Closing Reason ID Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OpeningReasonIdOther" , new GridColumnConfiguration { DisplayName = "Opening Reason ID Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskCodeOther" , new GridColumnConfiguration { DisplayName = "Risk Code Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmploymentType" , new GridColumnConfiguration { DisplayName = "Employment Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployedOrBusiness" , new GridColumnConfiguration { DisplayName = "Employed Or Business"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerBusinessName" , new GridColumnConfiguration { DisplayName = "Employer Business Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerBusinessAdrs" , new GridColumnConfiguration { DisplayName = "Employer Business Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerBusinessCity" , new GridColumnConfiguration { DisplayName = "Employer Business City"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerBusinessCtry" , new GridColumnConfiguration { DisplayName = "Employer Business Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerBusinessState" , new GridColumnConfiguration { DisplayName = "Employer Business State"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerBusinessTown" , new GridColumnConfiguration { DisplayName = "Employer Business Town"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerPhone" , new GridColumnConfiguration { DisplayName = "Employer Phone"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployerCountryPhoneCode" , new GridColumnConfiguration { DisplayName = "Employer Country Phone Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Occupation" , new GridColumnConfiguration { DisplayName = "Occupation"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OccupationDtl" , new GridColumnConfiguration { DisplayName = "Occupation Dtl"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BusinessSector" , new GridColumnConfiguration { DisplayName = "Business Sector"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BusinessSectorOthers" , new GridColumnConfiguration { DisplayName = "Business Sector Others"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PepIndicator" , new GridColumnConfiguration { DisplayName = "PEP Indicator"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PepIndicatorDtls" , new GridColumnConfiguration { DisplayName = "PEP Indicator Dtls"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PepIndicatorOth" , new GridColumnConfiguration { DisplayName = "PEP Indicator Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SourceOfIncomeCd" , new GridColumnConfiguration { DisplayName = "Source Of Income CD"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SourceOfIncomeOther" , new GridColumnConfiguration { DisplayName = "Source Of Income Other"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AnnualIncomeCd" , new GridColumnConfiguration { DisplayName = "Annual Income CD"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MonthIncome" , new GridColumnConfiguration { DisplayName = "Month Income"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IncomeIsoCurrency" , new GridColumnConfiguration { DisplayName = "Income ISO Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MonthExpense" , new GridColumnConfiguration { DisplayName = "Month Expense"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExpenseIsoCurrency" , new GridColumnConfiguration { DisplayName = "Expense ISO Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"HomeCd" , new GridColumnConfiguration { DisplayName = "Home CD"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxRegulationCtryCd1" , new GridColumnConfiguration { DisplayName = "Tax Regulation Country CD1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxRegulationCtryCd2" , new GridColumnConfiguration { DisplayName = "Tax Regulation Country CD2"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxRegulationCtryCd3" , new GridColumnConfiguration { DisplayName = "Tax Regulation Country CD3"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxRegulationTin1" , new GridColumnConfiguration { DisplayName = "Tax Regulation Tin1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxRegulationTin2" , new GridColumnConfiguration { DisplayName = "Tax Regulation Tin2"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxRegulationTin3" , new GridColumnConfiguration { DisplayName = "Tax Regulation Tin3"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RelationToBankCode" , new GridColumnConfiguration { DisplayName = "Relation To Bank Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OtherBankAccounts" , new GridColumnConfiguration { DisplayName = "Other Bank Accounts"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DealtBankDetails" , new GridColumnConfiguration { DisplayName = "Dealt Bank Details"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DealAbrdBankDetails" , new GridColumnConfiguration { DisplayName = "Deal Abrd Bank Details"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BusinessCode" , new GridColumnConfiguration { DisplayName = "Business Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CalculateZakahFlag" , new GridColumnConfiguration { DisplayName = "Calculate Zakah Flag"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CharityFlag" , new GridColumnConfiguration { DisplayName = "Charity Flag"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CompanySalesAmountPerYear" , new GridColumnConfiguration { DisplayName = "Company Sales Amount Per Year"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerStatus" , new GridColumnConfiguration { DisplayName = "Customer Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EconomicMainCode" , new GridColumnConfiguration { DisplayName = "Economic Main Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EconomicSubCode" , new GridColumnConfiguration { DisplayName = "Economic Sub Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GeoCode" , new GridColumnConfiguration { DisplayName = "Geo Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastQueryDate" , new GridColumnConfiguration { DisplayName = "Last Query Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LegalMainCode" , new GridColumnConfiguration { DisplayName = "Legal Main Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LegalStepDate" , new GridColumnConfiguration { DisplayName = "Legal Step Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LegalStepMainCode" , new GridColumnConfiguration { DisplayName = "Legal Step Main Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LegalStepSubCode" , new GridColumnConfiguration { DisplayName = "Legal Step Sub Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LegalSubCode" , new GridColumnConfiguration { DisplayName = "Legal Sub Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ReferredPersonAddress" , new GridColumnConfiguration { DisplayName = "Referred Person Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ReferredPersonPhone" , new GridColumnConfiguration { DisplayName = "Referred Person Phone"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SectorAnalysesCode" , new GridColumnConfiguration { DisplayName = "Sector Analyses Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"WorthLastCalcDate" , new GridColumnConfiguration { DisplayName = "Worth Last Calcualte Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            HasFixedWidth = true;



        }
    }
}