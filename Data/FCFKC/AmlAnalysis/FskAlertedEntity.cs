namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskAlertedEntity
    {
        public string AlertedEntityLevelCode { get; set; } = null!;
        public string AlertedEntityNumber { get; set; } = null!;
        public string? AlertedEntityName { get; set; }
        public int? AlertsCnt { get; set; }//
        public int? TransactionsCnt { get; set; }//
        public double? AggregateAmt { get; set; }//
        public int? AgeOldestAlert { get; set; }//
        public string? RiskScoreCode { get; set; }
        public int? MoneyLaunderingScore { get; set; }//
        public string? EmployeeInd { get; set; }
        public string? PoliticallyExposedPersonInd { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public int? AlertedEntitySegmentId { get; set; }//
        public string? LockUserid { get; set; }
        public DateTime? LockTimestamp { get; set; }
        public string? LstupdateUserId { get; set; }
        public DateTime? LstupdateDate { get; set; }
    }
}
