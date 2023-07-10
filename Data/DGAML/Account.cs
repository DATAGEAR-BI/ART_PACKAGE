using System;
using System.Collections.Generic;

namespace Data.DGAML
{
    public partial class Account
    {
        public int AcctKey { get; set; }
        public string AcctNo { get; set; } = null!;
        public string? LineBusName { get; set; }
        public string AcctTypeDesc { get; set; } = null!;
        public string AcctCcyCd { get; set; } = null!;
        public string? AcctCcyName { get; set; }
        public string? AcctRegTypeDesc { get; set; }
        public string? AcctRegName { get; set; }
        public string? AcctName { get; set; }
        public string? AltName { get; set; }
        public DateTime? AcctOpenDate { get; set; }
        public DateTime? AcctCloseDate { get; set; }
        public string? AcctStatusDesc { get; set; }
        public string? DormInd { get; set; }
        public string? ProdLineName { get; set; }
        public string? ProdCategName { get; set; }
        public string? ProdTypeName { get; set; }
        public string? ProdName { get; set; }
        public string? ProdNo { get; set; }
        public string? AcctTaxId { get; set; }
        public string? AcctTaxIdTypeCd { get; set; }
        public string? AcctTaxStateCd { get; set; }
        public string? AcctPrimBranchName { get; set; }
        public string? MailAddr1 { get; set; }
        public string? MailAddr2 { get; set; }
        public string? MailCityName { get; set; }
        public string? MailStateCd { get; set; }
        public string? MailStateName { get; set; }
        public string? MailPostCd { get; set; }
        public string? MailCntryCd { get; set; }
        public string? MailCntryName { get; set; }
        public string? CcyBasedAcctInd { get; set; }
        public DateTime? MaturityDate { get; set; }
        public decimal? OrigLoanAmt { get; set; }
        public string? ColtrlTypeCd { get; set; }
        public string? ColtrlTypeDesc { get; set; }
        public decimal? InsurAmt { get; set; }
        public string? EmpInd { get; set; }
        public string? LetterCrOnfileInd { get; set; }
        public string? CashIntsBusInd { get; set; }
        public string? TradeFinInd { get; set; }
        public DateTime? ChgBeginDate { get; set; }
        public DateTime ChgEndDate { get; set; }
        public string ChgCurrentInd { get; set; } = null!;
        public decimal? InstAmt { get; set; }
        public string? LeaseTransfer { get; set; }
        public string? Vinno { get; set; }
        public string? Tenure { get; set; }
    }
}
