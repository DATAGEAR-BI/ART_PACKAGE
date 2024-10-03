using System;
using System.Collections.Generic;

namespace Data.DGCFTWL
{
    public partial class FscEntityWatchListDim
    {
        public decimal EntityWatchListKey { get; set; }
        public string EntityWatchListNumber { get; set; } = null!;
        public string WatchListName { get; set; } = null!;
        public string? CategoryDesc { get; set; }
        public string? TypeDesc { get; set; }
        public string? Programs { get; set; }
        public string? TaxId { get; set; }
        public string? TaxIdTypeCode { get; set; }
        public string? IdentificationId { get; set; }
        public string? IdentificationTypeDesc { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? YearOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? DeceasedInd { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? EntityName { get; set; }
        public string? MatchCodeIndividual { get; set; }
        public string? MatchCodeOrganization { get; set; }
        public string? MatchCodeAddrLines { get; set; }
        public string? MatchCodeCity { get; set; }
        public string? MatchCodeState { get; set; }
        public string? MatchCodeCountry { get; set; }
        public string? EntityTitle { get; set; }
        public string? OccupationDesc { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? FullAddress { get; set; }
        public string? MatchCodeFullAddress { get; set; }
        public string? CitizenshipCountryCode { get; set; }
        public string? CitizenshipCountryName { get; set; }
        public string? MatchCodeCitizenship { get; set; }
        public string? NationalityCountryCode { get; set; }
        public string? NationalityCountryName { get; set; }
        public string? MatchCodeNationality { get; set; }
        public string? OrgCountryOfBusinessCode { get; set; }
        public string? OrgCountryOfBusinessName { get; set; }
        public string? MatchCodeOrgCountry { get; set; }
        public string? PoliticallyExposedPersonInd { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ExcludeInd { get; set; } = null!;
        public DateTime ChangeBeginDate { get; set; }
        public DateTime ChangeEndDate { get; set; }
        public string ChangeCurrentInd { get; set; } = null!;
        public string? Remarks { get; set; }
        public string? EddBic { get; set; }
        public string? EddCountry { get; set; }
        public string? WatchListSubCategory { get; set; }
        public string? AlternativeNames { get; set; }
        public string? ActiveInd { get; set; }
        public string? Gender { get; set; }
        public DateTime? ScreeningDate { get; set; }
        public int? Result { get; set; }
        public string? Errordesc { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
