namespace Data.FCFKC.SASAML
{
    public partial class FskCase
    {
        public decimal CaseId { get; set; }
        public string CaseCategoryCode { get; set; } = null!;
        public string CaseSubCategoryCode { get; set; } = null!;
        public string CasePriorityCode { get; set; } = null!;
        public string CaseTypeCode { get; set; } = null!;
        public string? CaseCloseReasonCode { get; set; }
        public string? CaseDescription { get; set; }
        public string? CaseSummary { get; set; }
        public decimal? AggregateAmt { get; set; }
        public string LeContactedInd { get; set; } = null!;
        public string? LeContactAgency { get; set; }
        public string? LeContactName { get; set; }
        public string? LeContactPhone { get; set; }
        public string? LeContactPhoneExt { get; set; }
        public DateTime? LeContactDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string OpenedInd { get; set; } = null!;
        public string ModifiedInd { get; set; } = null!;
        public string EmployeeInd { get; set; } = null!;
        public string CaseStatusCode { get; set; } = null!;
        public DateTime? FirstTransactionDate { get; set; }
        public DateTime? LastTransactionDate { get; set; }
        public decimal VersionNumber { get; set; }
        public string LogicalDeleteInd { get; set; } = null!;
        public string? LstupdateUserId { get; set; }
        public DateTime LstupdateDate { get; set; }
        public string? OwnerUserLongId { get; set; }
        public DateTime? ActivateDate { get; set; }
        public string? QueueCode { get; set; }
        public DateTime? CaseCloseDate { get; set; }
        public string? LockUserid { get; set; }
        public DateTime? LockTimestamp { get; set; }
    }
}
