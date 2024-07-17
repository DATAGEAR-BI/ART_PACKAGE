using System;
using System.Collections.Generic;

namespace Data.FCFKC.SASAML
{
    public partial class FskCaseTransaction
    {
        public long CaseId { get; set; }
        public long AlertId { get; set; }
        public string TransactionId { get; set; } = null!;
        public long? AlertedEntityKey { get; set; }
        public string? AlertedEntityLevelCode { get; set; }
        public decimal? TransactionAmt { get; set; }
        public string? TransactionCdiDesc { get; set; }
        public string? PrimaryMediumDesc { get; set; }
        public string? SecondaryMediumDesc { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? TransactionMechanism { get; set; }
        public string? AccountNumber { get; set; }
        public string? BeneficiaryName { get; set; }
        public string? AssociateName { get; set; }
        public string? BranchName { get; set; }
        public string? TransactionDesc { get; set; }
        public string? TransactionStatus { get; set; }
        public string? TriggeringIndicatorCd { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public int? DateKey { get; set; }
        public int? TimeKey { get; set; }
    }
}
