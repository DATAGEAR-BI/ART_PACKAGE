using System;
using System.Collections.Generic;

namespace Data.FCFKC
{
    public partial class FskRiskAssessment
    {
        public decimal RiskAssessmentId { get; set; }
        public string RiskAssessmentStatusCode { get; set; } = null!;
        public decimal? RiskClassification { get; set; }
        public decimal? ProposedRiskClassification { get; set; }
        public string PartyNumber { get; set; } = null!;
        public decimal? PartyKey { get; set; }
        public string? PartyName { get; set; }
        public decimal? StartingMonthKey { get; set; }
        public decimal RiskAssessmentDuration { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string? EmployeeInd { get; set; }
        public decimal VersionNumber { get; set; }
        public string LogicalDeleteInd { get; set; } = null!;
        public string? AssessmentTypeCd { get; set; }
        public string? AssessmentCategoryCd { get; set; }
        public string? AssessmentSubcategoryCd { get; set; }
        public string? OwnerUserLongId { get; set; }
    }
}
