using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtAmlHighRiskCustView
    {
        public string PartyNumber { get; set; } = null!;
        public string PartyTypeDesc { get; set; } = null!;
        public string? PartyTaxId { get; set; }
        public string? PartyIdentificationId { get; set; }
        public string? PartyIdentificationTypeDesc { get; set; }
        public DateTime? PartyDateOfBirth { get; set; }
        public string? PartyName { get; set; }
        public string? StreetAddress1 { get; set; }
        public string? StreetCityName { get; set; }
        public string? MailingAddress1 { get; set; }
        public string? MailingCityName { get; set; }
        public string? ResidenceCountryName { get; set; }
        public string? CitizenshipCountryName { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PoliticallyExposedPersonInd { get; set; }
        public string? RiskClassification { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
    }
}
