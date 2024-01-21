namespace Data.Data.FTI
{
    public partial class ArtDgecmActivity
    {
        public string EcmReference { get; set; } = null!;
        public string? BranchName { get; set; }
        public DateTime CaseCreationDate { get; set; }
        public string? CustomerName { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public string? CustomerClassification { get; set; }
        public string? CustomerCIF { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? CaseStatus { get; set; }
        public string? CaseComments { get; set; }
        public string? Product { get; set; }
        public string? ProductType { get; set; }
        public string? EventName { get; set; }
        public string? ParentCaseId { get; set; }
        public string? Reference { get; set; }
        public string? EcmEventStep { get; set; }
        public string? EcmEventCreatedBy { get; set; }
        public DateTime? EcmEventCreatedDate { get; set; }
        public string? StepDifference { get; set; }
        public string? StepDifferenceSla { get; set; }
        public string? Assignee { get; set; }
        public string? AssignedBy { get; set; }
        public DateTime? AssignedTime { get; set; }
        public string? UnAssignee { get; set; }
        public string? UnAssignedBy { get; set; }
        public DateTime? UnAssignedTime { get; set; }
        public string? AssignDifference { get; set; }
        public string? AssignDifferenceSla { get; set; }

    }
}
