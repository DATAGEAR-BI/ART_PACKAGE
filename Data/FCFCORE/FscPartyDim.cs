using System;
using System.Collections.Generic;

namespace Data.FCFCORE
{
    public partial class FscPartyDim
    {
        public decimal PartyKey { get; set; }
        public string PartyNumber { get; set; } = null!;
        public string PartyTypeDesc { get; set; } = null!;
        public string? PartyTaxId { get; set; }
        public string? PartyTaxIdTypeCode { get; set; }
        public string? PartyIdentificationId { get; set; }
        public string? PartyIdentificationTypeDesc { get; set; }
        public string? PartyIdStateCode { get; set; }
        public string? PartyIdCountryCode { get; set; }
        public DateTime? PartyDateOfBirth { get; set; }
        public string? PartyFirstName { get; set; }
        public string? PartyLastName { get; set; }
        public string? PartyMiddleName { get; set; }
        public string? PartyName { get; set; }
        public string? DoingBusinessAsName { get; set; }
        public string? PartyStatusDesc { get; set; }
        public string? UltimateParentName { get; set; }
        public string? MatchCodeOrganization { get; set; }
        public string? MatchCodeIndividual { get; set; }
        public string? MatchCodeStreetAddress { get; set; }
        public string? MatchCodeMailingAddress { get; set; }
        public string? MatchCodeStreetAddrLines { get; set; }
        public string? MatchCodeStreetCity { get; set; }
        public string? MatchCodeStreetState { get; set; }
        public string? MatchCodeStreetCountry { get; set; }
        public string? MatchCodeMailingAddrLines { get; set; }
        public string? MatchCodeMailingCity { get; set; }
        public string? MatchCodeMailingState { get; set; }
        public string? MatchCodeMailingCountry { get; set; }
        public string? StreetAddress1 { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? StreetCityName { get; set; }
        public string? StreetStateCode { get; set; }
        public string? StreetStateName { get; set; }
        public string? StreetPostalCode { get; set; }
        public string? StreetCountryCode { get; set; }
        public string? StreetCountryName { get; set; }
        public string? MailingAddress1 { get; set; }
        public string? MailingAddress2 { get; set; }
        public string? MailingCityName { get; set; }
        public string? MailingStateCode { get; set; }
        public string? MailingStateName { get; set; }
        public string? MailingPostalCode { get; set; }
        public string? MailingCountryCode { get; set; }
        public string? MailingCountryName { get; set; }
        public string? ResidenceCountryCode { get; set; }
        public string? ResidenceCountryName { get; set; }
        public string? CitizenshipCountryCode { get; set; }
        public string? CitizenshipCountryName { get; set; }
        public string? OrgCountryOfBusinessCode { get; set; }
        public string? OrgCountryOfBusinessName { get; set; }
        public string? EmployeeInd { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? EmployerName { get; set; }
        public string? EmployerPhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? OccupationDesc { get; set; }
        public string? IndustryCode { get; set; }
        public string? IndustryCodeRr { get; set; }
        public string? IndustryDesc { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? PhoneNumber3 { get; set; }
        public decimal? AnnualIncomeAmount { get; set; }
        public decimal? NetWorthAmount { get; set; }
        public string? MaritalStatusDesc { get; set; }
        public DateTime? LastContactDate { get; set; }
        public string PoliticallyExposedPersonInd { get; set; } = null!;
        public string? NonProfitOrgInd { get; set; }
        public DateTime? CustomerSinceDate { get; set; }
        public DateTime? LastSuspActvRptDate { get; set; }
        public DateTime? LastCashTransRptDate { get; set; }
        public DateTime? LastRiskAssessmentDate { get; set; }
        public decimal? RiskClassification { get; set; }
        public DateTime? ChangeBeginDate { get; set; }
        public DateTime ChangeEndDate { get; set; }
        public string ChangeCurrentInd { get; set; } = null!;
        public string? ExternalPartyInd { get; set; }
        public string? LegalEntityType { get; set; }
        public string? MoneyOrdersInd { get; set; }
        public string? TravelersChequesInd { get; set; }
        public string? PrepaidCardsInd { get; set; }
        public string? MsbInd { get; set; }
        public string? MoneyTransmitterInd { get; set; }
        public string? CurrencyExchangeInd { get; set; }
        public string? CheckCasherInd { get; set; }
        public string? InternetGamblingInd { get; set; }
        public string? TrustAccountInd { get; set; }
        public string? ForeignConsulateEmbassyInd { get; set; }
        public string? IssuesBearerSharesInd { get; set; }
        public string? NegativeNewsInd { get; set; }
        public decimal? SuspActvRptCount { get; set; }
        public DateTime? LstUpdateDate { get; set; }
        public string? BenOwnExemptInd { get; set; }
        public decimal? EntitySegmentId { get; set; }
        public DateTime? PurgeDate { get; set; }
        public int? Result { get; set; }
        public DateTime? ScreeningDate { get; set; }
        public string? Errordesc { get; set; }
    }
}
