namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskAlert
    {
        public FskAlert()
        {
            FskAlertEvents = new HashSet<FskAlertEvent>();
        }

        public decimal AlertId { get; set; }
        public string ProductType { get; set; } = null!;
        public string AlertStatusCode { get; set; } = null!;
        public decimal MoneyLaunderingRiskScore { get; set; }
        public decimal? TerrorFinancingRiskScore { get; set; }
        public string? AlertDescription { get; set; }
        public string PrimaryEntityLevelCode { get; set; } = null!;
        public string AlertedEntityNumber { get; set; } = null!;
        public string? AlertedEntityName { get; set; }
        public string PrimaryEntityNumber { get; set; } = null!;
        public decimal? PrimaryEntityKey { get; set; }
        public string? PrimaryEntityName { get; set; }
        public decimal? ScenarioId { get; set; }
        public string? ScenarioName { get; set; }
        public DateTime? SuppressionEndDate { get; set; }
        public string? ActualValuesText { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string? EmployeeInd { get; set; }
        public decimal VersionNumber { get; set; }
        public string LogicalDeleteInd { get; set; } = null!;
        public string? AlertTypeCd { get; set; }
        public string? AlertCategoryCd { get; set; }
        public string? AlertSubcategoryCd { get; set; }
        public decimal? AlertedEntityKey { get; set; }
        public string? AlertedEntityLevelCode { get; set; }
        public decimal? EntitySegmentId { get; set; }
        public string? QueueCode { get; set; }

        public virtual ICollection<FskAlertEvent> FskAlertEvents { get; set; }
    }
}
