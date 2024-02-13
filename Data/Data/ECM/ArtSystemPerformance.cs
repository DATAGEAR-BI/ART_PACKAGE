namespace Data.Data.ECM
{
    public partial class ArtSystemPerformance
    {
        public decimal CaseRk { get; set; }
        public string CaseId { get; set; } = null!;
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
        public decimal? DurationsInSeconds { get; set; }
        public decimal? DurationsInMinutes { get; set; }
        public decimal? DurationsInHours { get; set; }
        public decimal? DurationsInDays { get; set; }
    }
}
