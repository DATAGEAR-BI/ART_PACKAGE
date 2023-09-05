using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtTiEcmAuditReport
    {
        public string EcmReference { get; set; } = null!;
        public string? BranchId { get; set; }
        public DateTime EcmCaseCreationDate { get; set; }
        public string? CutomerName { get; set; }
        public string? Product { get; set; }
        public string? Producttype { get; set; }
        public string? EcmEvent { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? CaseStatCd { get; set; }
        public string? UpdateUserId { get; set; }
        public string? Comments { get; set; }
        public string? FtiReference { get; set; }
        public string? EventName { get; set; }
        public string? EventStatus { get; set; }
        public DateTime? EventCreationDate { get; set; }
        public string? MasterAssignedTo { get; set; }
        public string? EventSteps { get; set; }
        public string? StepStatus { get; set; }
    }
}
