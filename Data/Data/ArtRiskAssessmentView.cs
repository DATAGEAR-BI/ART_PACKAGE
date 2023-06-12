namespace Data.Data
{
    public class ArtRiskAssessmentView
    {
        public string? RiskStatus { get; set; }
        public string? RiskClass { get; set; }
        public string? ProposedRiskClass { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public long RiskAssessmentId { get; set; }
        public string PartyNumber { get; set; } = null!;
        public string? PartyName { get; set; }
        public byte RiskAssessmentDuration { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public int VersionNumber { get; set; }
        public string? AssessmentTypeCd { get; set; }
        public string? AssessmentCategoryCd { get; set; }
        public string? AssessmentSubcategoryCd { get; set; }
        public string? OwnerUserLongId { get; set; }
    }
}
