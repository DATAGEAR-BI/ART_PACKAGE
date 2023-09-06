using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtTiEcmWorkflowProgReport
    {
        public string EcmReference { get; set; } = null!;
        public DateTime EcmCaseCreationDate { get; set; }
        public string? BranchId { get; set; }
        public string? CutomerName { get; set; }
        public string? Product { get; set; }
        public string? ProductType { get; set; }
        public string? EcmEvent { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? CaseStatCd { get; set; }
        public string? UpdateUserId { get; set; }
        public string? EcmRejectionType { get; set; }
        public string? EcmRejectionReason { get; set; }
        public string? FtiReference { get; set; }
        public string? EventName { get; set; }
        public string? EventStatus { get; set; }
        public DateTime? EventCreationDate { get; set; }
        public string? AssignedTo { get; set; }
        public string? AssignmentType { get; set; }
        public string? EventSteps { get; set; }
        public string? StepStatus { get; set; }
        public DateTime? Lstmodtime { get; set; }
        public string? Lstmoduser { get; set; }
        public string? WarningOverridden { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime? SlaDeadline { get; set; }
        public decimal? InputStepTime { get; set; }
        public string? InputSlaStatus { get; set; }
        public decimal? InputMaxTime { get; set; }
        public decimal? ExternalReviewStepTime { get; set; }
        public string? ExternalReviewSlaStatus { get; set; }
        public decimal? ReviewStepTime { get; set; }
        public string? ReviewSlaStatus { get; set; }
        public decimal? AuthorizeStepTime { get; set; }
        public string? AuthorizeSlaStatus { get; set; }
        public DateTime? SlaDashboardAmber { get; set; }
        public DateTime? SlaDashboardRed { get; set; }
        public long? SlaRemainingTime { get; set; }
    }
}
