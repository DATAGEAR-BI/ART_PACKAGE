using System;
using System.Collections.Generic;

namespace Data.DGECM
{
    public partial class CaseLive
    {
        public int CaseRk { get; set; }
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
        public int? CaseLinkSk { get; set; }
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
        public int VerNo { get; set; }
        public string DeleteFlag { get; set; } = null!;
        public string? CustFullName { get; set; }
        public string? Col1 { get; set; }
        public string? Col2 { get; set; }
        public string? Col3 { get; set; }
        public string? Col4 { get; set; }
        public string? Col5 { get; set; }
        public string? UpdatedBy { get; set; }
        public string? LockedBy { get; set; }
        public string? SwiftReference { get; set; }
        public string? TransactionType { get; set; }
        public string? TransactionDirection { get; set; }
        public string? TransactionCurrency { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string? TransactionRemitter { get; set; }
        public string? TransactionBenificiary { get; set; }
        public string? CustomerResidency { get; set; }
        public string? CustomerActivityCountry { get; set; }
        public string? CustomerCreatedBranch { get; set; }
        public string? CustomerCreatedUser { get; set; }
        public string? HitsCount { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? Searchunit { get; set; }
        public string? Searchuser { get; set; }
        public string? Searchcountry { get; set; }
        public string? WlCategory { get; set; }
        public string? Nationality { get; set; }
        public string? Othnationality { get; set; }
        public string? Waspending { get; set; }
        public string? Inputname { get; set; }
        public string? XIdentity { get; set; }
        public string? Receiverbic { get; set; }
        public string? Receiverctry { get; set; }
        public string? Senderbic { get; set; }
        public string? Senderctry { get; set; }
        public string? Birthplace { get; set; }
        public decimal? Maxsensitivityrank { get; set; }
        public string? EmployeeInd { get; set; }
        public string? Masterref { get; set; }
        public string? Eventref { get; set; }
        public string? Applicantref { get; set; }
        public string? Applicantid { get; set; }
        public string? Applicantname { get; set; }
        public string? Behalfofbranch { get; set; }
        public DateTime? Applicationdate { get; set; }
        public DateTime? Issuedate { get; set; }
        public DateTime? Expirydate { get; set; }
        public string? Product { get; set; }
        public string? Producttype { get; set; }
        public string? Eventname { get; set; }
        public string? Remittercountry { get; set; }
        public string? Beneficiarycountry { get; set; }
        public string? Remitteridentity { get; set; }
        public string? Beneficiaryidentity { get; set; }
        public string? Remitterbirthyear { get; set; }
        public string? Beneficiarybirthyear { get; set; }
        public string? Senderbankbic { get; set; }
        public string? Receiverbankbic { get; set; }
        public string? Creditoragentbankbic { get; set; }
        public string? Debtoragentbankbic { get; set; }
        public string? Anybicfieldbic { get; set; }
        public string? Partytypedesc { get; set; }
        public DateTime? Amenddate { get; set; }
        public string? Reference { get; set; }
        public string? Documentreference { get; set; }
        public string? Remitteraccountnum { get; set; }
        public string? Remitternationality { get; set; }
        public string? Senderreceiveragentcode { get; set; }
        public string? Intermediarycode { get; set; }
        public string? Beneficiaryaccountnum { get; set; }
        public string? Beneficiarynationality { get; set; }
        public string? Payorigincountry { get; set; }
        public string? Paydestinationcountry { get; set; }
    }
}
