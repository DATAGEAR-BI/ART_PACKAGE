namespace Data.Data.CRP
{
    public partial class ArtCrpCase
    {
        public decimal CaseRk { get; set; }
        public string CaseId { get; set; } = null!;
        public string? CaseStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? PartyNumber { get; set; }
        public string? PartyName { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? RiskClassification { get; set; }
        public DateTime? LastRiskAssessmentDate { get; set; }
    }
}
