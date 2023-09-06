using System;
using System.Collections.Generic;

namespace Data.Data.FTI
{
    public partial class ArtTiEcmTransactionsReport
    {
        public string CaseId { get; set; } = null!;
        public string? Behalfofbranch { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Applicantname { get; set; }
        public string? Product { get; set; }
        public string? Producttype { get; set; }
        public string? Eventname { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? CaseStatCd { get; set; }
        public string? UpdateUserId { get; set; }
    }
}
