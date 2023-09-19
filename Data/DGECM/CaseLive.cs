namespace Data.DGECM
{
    public partial class CaseLive
    {
        public decimal CaseRk { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ValidToDate { get; set; }
        public string CaseId { get; set; } = null!;
        public string SrcSysCd { get; set; } = null!;
        public string? CaseTypeCd { get; set; }
        public string? CaseCtgryCd { get; set; }
        public string? CaseSubCtgryCd { get; set; }
        public string? CaseStatCd { get; set; }
        public string? CaseDisposCd { get; set; }
        public string? CaseDesc { get; set; }
        public decimal? CaseLinkSk { get; set; }
        public string? PriorityCd { get; set; }
        public string ReguRptRqdFlag { get; set; } = null!;
        public string? InvestrUserId { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? ReopenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? UiDefFileName { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public decimal VerNo { get; set; }
        public string DeleteFlag { get; set; } = null!;
        public string? CustFullName { get; set; }
        public string? Col1 { get; set; }
        public string? Col2 { get; set; }
        public string? Col3 { get; set; }
        public string? Col4 { get; set; }
        public string? Col5 { get; set; }
        public string? LockedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? SwiftReference { get; set; }
        public string? TransactionType { get; set; }
        public string? TransactionDirection { get; set; }
        public string? TransactionCurrency { get; set; }
        public double? TransactionAmount { get; set; }
        public string? TransactionRemitter { get; set; }
        public string? TransactionBenificiary { get; set; }
        public string? CustomerResidency { get; set; }
        public string? CustomerActivityCountry { get; set; }
        public string? CustomerCreatedUser { get; set; }
        public string? CustomerCreatedBranch { get; set; }
        public string? HitsCount { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? SearchUser { get; set; }
        public string? SearchUnit { get; set; }
        public string? SearchCountry { get; set; }
        public string? WlCategory { get; set; }
        public string? Nationality { get; set; }
        public string? OthNationality { get; set; }
        public string? WasPending { get; set; }
        public string? InputName { get; set; }
        public string? XIdentity { get; set; }
        public string? ReceiverBic { get; set; }
        public string? SenderBic { get; set; }
        public string? SenderCtry { get; set; }
        public string? BirthPlace { get; set; }
        public string? ReceiverCtry { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? MasterRef { get; set; }
        public string? EventRef { get; set; }
        public string? ApplicantRef { get; set; }
        public string? ApplicantId { get; set; }
        public string? ApplicantName { get; set; }
        public string? BehalfOfBranch { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public double? MaxSensitivityRank { get; set; }
        public string? EmployeeInd { get; set; }
        public string? EventName { get; set; }
        public string? ProductType { get; set; }
        public string? Product { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? RemitterCountry { get; set; }
        public string? BeneficiaryCountry { get; set; }
        public string? RemitterIdentity { get; set; }
        public string? BeneficiaryIdentity { get; set; }
        public string? RemitterBirthYear { get; set; }
        public string? BeneficiaryBirthYear { get; set; }
        public string? SenderBankBic { get; set; }
        public string? ReceiverBankBic { get; set; }
        public string? CreditorAgentBankBic { get; set; }
        public string? DebtorAgentBankBic { get; set; }
        public string? AnyBicFieldBic { get; set; }
        public DateTime? Amenddate { get; set; }
        public string? Reference { get; set; }
        public string? DocumentReference { get; set; }
        public string? RemitterAccountNum { get; set; }
        public string? RemitterNationality { get; set; }
        public string? SenderReceiverAgentCode { get; set; }
        public string? IntermediaryCode { get; set; }
        public string? BeneficiaryAccountNum { get; set; }
        public string? BeneficiaryNationality { get; set; }
        public string? PayOriginCountry { get; set; }
        public string? PayDestinationCountry { get; set; }
        public string? TransactionBeneficiary { get; set; }
        public string? TransactionReference { get; set; }
        public string? EcmWorkflow { get; set; }
        public string? ParentCaseId { get; set; }
        public decimal? ParentCaseRk { get; set; }
        public string? BeneficiaryName { get; set; }
    }
}
