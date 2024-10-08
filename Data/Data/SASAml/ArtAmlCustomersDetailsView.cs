﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public class ArtAmlCustomersDetailsView
    {
        public string? CustomerName { get; set; }
        public string CustomerNumber { get; set; } = null!;
        public string? CustomerType { get; set; }
        public string? CustomerIdentificationId { get; set; }
        public string? CustomerIdentificationType { get; set; }
        public DateTime? CustomerDateOfBirth { get; set; }
        public string? RiskClassification { get; set; }
        public string? CustomerTaxId { get; set; }
        public string? DoingBusinessAsName { get; set; }
        public string? GovernorateName { get; set; }
        public string? StreetAddress1 { get; set; }
        public string? CityName { get; set; }
        public string? CustomerStatus { get; set; }
        public string? StreetPostalCode { get; set; }
        public string? StreetCountryCode { get; set; }
        public string? StreetCountryName { get; set; }
        public string? MailingAddress1 { get; set; }
        public string? MailingCityName { get; set; }
        public string? MailingPostalCode { get; set; }
        public string? MailingCountryName { get; set; }
        public string? ResidenceCountryName { get; set; }
        public string? CitizenshipCountryName { get; set; }
        public string? IsEmployee { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? EmployerName { get; set; }
        public string? EmployerPhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? OccupationDesc { get; set; }
        public string? IndustryDesc { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? PhoneNumber3 { get; set; }
        public int? AnnualIncomeAmount { get; set; }
        public int? NetWorthAmount { get; set; }
        public string? MaritalStatusDesc { get; set; }
        public DateTime? CustomerSinceDate { get; set; }
        public DateTime? LastRiskAssessmentDate { get; set; }
        public string? NonProfitOrgInd { get; set; }
        public string PoliticallyExposedPersonInd { get; set; } = null!;
        public string? ActiveFlg { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
    }
}
