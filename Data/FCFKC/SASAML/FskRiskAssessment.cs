using System;
using System.Collections.Generic;

namespace Data.FCFKC.SASAML
{
    public partial class FskRiskAssessment
    {
        public long RiskAssessmentId { get; set; }
        public string RiskAssessmentStatusCode { get; set; } = null!;
        public bool? RiskClassification { get; set; }
        public bool? ProposedRiskClassification { get; set; }
        public string PartyNumber { get; set; } = null!;
        public long? PartyKey { get; set; }
        public string? PartyName { get; set; }
        public int? StartingMonthKey { get; set; }
        public byte RiskAssessmentDuration { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string? EmployeeInd { get; set; }
        public int VersionNumber { get; set; }
        public string LogicalDeleteInd { get; set; } = null!;
        public string? AssessmentTypeCd { get; set; }
        public string? AssessmentCategoryCd { get; set; }
        public string? AssessmentSubcategoryCd { get; set; }
        public string? OwnerUserLongId { get; set; }
    }
}
