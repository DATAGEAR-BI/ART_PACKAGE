﻿namespace Data.Data.FTI
{
    public partial class ArtCasesInitiatedFromBranch
    {
        public string EcmReference { get; set; } = null!;
        public string? BranchName { get; set; }
        public DateTime? CaseCreationDate { get; set; }
        public string? CustomerName { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? CaseStatus { get; set; }
        public string? LastActionTakenBy { get; set; }
        public string? Product { get; set; }
        public string? ProductType { get; set; }
        public string? EventName { get; set; }
        public string? ApplicantId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? BeneficiaryName { get; set; }
    }
}