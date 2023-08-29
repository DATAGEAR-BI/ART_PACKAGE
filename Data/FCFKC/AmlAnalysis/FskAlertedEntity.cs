namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskAlertedEntity
    {
        public string AlertedEntityLevelCode { get; set; } = null!;
        public string AlertedEntityNumber { get; set; } = null!;
        public string? AlertedEntityName { get; set; }
        public decimal? AlertsCnt { get; set; }
        public decimal? TransactionsCnt { get; set; }
        public decimal? AggregateAmt { get; set; }
        public decimal? AgeOldestAlert { get; set; }
        public string? RiskScoreCode { get; set; }
        public decimal? MoneyLaunderingScore { get; set; }
        public string? EmployeeInd { get; set; }
        public string? PoliticallyExposedPersonInd { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public decimal? AlertedEntitySegmentId { get; set; }
        public string? LockUserid { get; set; }
        public DateTime? LockTimestamp { get; set; }
        public string? LstupdateUserId { get; set; }
        public DateTime? LstupdateDate { get; set; }
    }
}
