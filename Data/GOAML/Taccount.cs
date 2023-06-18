using System;
using System.Collections.Generic;

namespace Data.GOAML
{
    public partial class Taccount
    {
        public int Id { get; set; }
        public string? Account { get; set; }
        public string? AccountName { get; set; }
        public decimal? Balance { get; set; }
        public string? Beneficiary { get; set; }
        public string? BeneficiaryComment { get; set; }
        public string? Branch { get; set; }
        public string? ClientNumber { get; set; }
        public string? Closed { get; set; }
        public string? Comments { get; set; }
        public string? CurrencyCode { get; set; }
        public string? DateBalance { get; set; }
        public string? Iban { get; set; }
        public string? InstitutionCode { get; set; }
        public string? InstitutionName { get; set; }
        public bool? IsEntity { get; set; }
        public bool? NonBankInstitution { get; set; }
        public string? Opened { get; set; }
        public string? PersonalAccountType { get; set; }
        public string? StatusCode { get; set; }
        public string? Swift { get; set; }
        public int? ReportPartyTypeId { get; set; }
        public bool? IsReviewed { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
