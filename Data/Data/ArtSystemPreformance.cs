using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtSystemPreformance
    {

        public string CaseId { get; set; } = null!;
        public decimal CaseRk { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public string? CaseType { get; set; }
        public string? CaseStatus { get; set; }
        public string? CaseDesc { get; set; }
        public string? Priority { get; set; }
        public string? CreateUserId { get; set; }
        public string? InvestrUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public string? TransactionType { get; set; }
        public double? TransactionAmount { get; set; }
        public string? TransactionDirection { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? SwiftReference { get; set; }
        public string? ClientName { get; set; }
        public string? IdentityNum { get; set; }
        public string? LockedBy { get; set; }
        public DateTime? EcmLastStatusDate { get; set; }
        public string? HitsCount { get; set; }
        public int? DurationsInSeconds { get; set; }
        public int? DurationsInMinutes { get; set; }
        public int? DurationsInHours { get; set; }
        public int? DurationsInDays { get; set; }
    }
}
