namespace Data.Data.SASAml
{
    public class ArtAmlTriageView
    {
        public string? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchNumber { get; set; }
        public string? BranchName { get; set; }
        public string? RiskScore { get; set; }
        public string? OwnerUserid { get; set; }
        public string? AlertedEntityLevel { get; set; }
        public decimal? AggregateAmt { get; set; }
        public int? AgeOldestAlert { get; set; }
        public int? AlertsCnt { get; set; }
    }
}
