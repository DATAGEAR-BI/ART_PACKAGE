using System;
using System.Collections.Generic;

namespace Data.Data.ECM
{
    public partial class ArtCaseIncidentsInfo
    {
        public string CaseId { get; set; } = null!;
        public decimal CaseRk { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Amount { get; set; }
        public string? DebtorBankName { get; set; }
        public string? DebtorBranchName { get; set; }
        public string? DebtorBranchBic { get; set; }
        public string? DebtorAcctype { get; set; }
        public string? DebtorAccno { get; set; }
        public string? DebtorName { get; set; }
        public string? CreditorBankName { get; set; }
        public string? CreditorBranchName { get; set; }
        public string? CreditorBranchBic { get; set; }
        public string? CreditorName { get; set; }
        public string? CreditorAccType { get; set; }
        public string? CreditorAccNo { get; set; }
        public string? CreditorNationalId { get; set; }
        public string? XIncidentId { get; set; }
        public string? XSourceName { get; set; }
        public string? XPartynameMaxrank { get; set; }
        public string? XIncidentDesc { get; set; }
    }
}
