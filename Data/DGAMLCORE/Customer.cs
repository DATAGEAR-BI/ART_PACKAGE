using System;
using System.Collections.Generic;

namespace Data.DGAMLCORE
{
    public partial class Customer
    {
        public int CustKey { get; set; }
        public string CustNo { get; set; } = null!;
        public string? CustTypeDesc { get; set; }
        public string? CustTaxId { get; set; }
        public string? CustTaxIdTypeCd { get; set; }
        public string? CustIdentId { get; set; }
        public string? CustIdentTypeDesc { get; set; }
        public DateTime? CustIdentIssDate { get; set; }
        public DateTime? CustIdentExpDate { get; set; }
        public string? CustGen { get; set; }
        public string? CustIdStateCd { get; set; }
        public string? CustIdCntryCd { get; set; }
        public DateTime? CustBirthDate { get; set; }
        public string? CustFname { get; set; }
        public string? CustLname { get; set; }
        public string? CustMname { get; set; }
        public string? CustName { get; set; }
        public string? DoBusAsName { get; set; }
        public string? CustStatusDesc { get; set; }
        public string? ParentName { get; set; }
        public string? MatchCdOrg { get; set; }
        public string? MatchCdIndv { get; set; }
        public string? MatchCdAddr { get; set; }
        public string? MatchCdMailAddr { get; set; }
        public string? MatchCdAddrLine { get; set; }
        public string? MatchCdCity { get; set; }
        public string? MatchCdState { get; set; }
        public string? MatchCdCntry { get; set; }
        public string? MachCdMailAddrLine { get; set; }
        public string? MatchCdMailCity { get; set; }
        public string? MatchCdMailState { get; set; }
        public string? MatchCdMailCntry { get; set; }
        public string? Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public string? CityName { get; set; }
        public string? StateCd { get; set; }
        public string? StateName { get; set; }
        public string? PostCd { get; set; }
        public string? CntryCd { get; set; }
        public string? CntryName { get; set; }
        public string? MailAddr1 { get; set; }
        public string? MailAddr2 { get; set; }
        public string? MailCityName { get; set; }
        public string? MailStateCd { get; set; }
        public string? MailStateName { get; set; }
        public string? MailPostCd { get; set; }
        public string? MailCntryCd { get; set; }
        public string? MailCntryName { get; set; }
        public string? ResidCntryCd { get; set; }
        public string? ResidCntryName { get; set; }
        public string? CitizenCntryCd { get; set; }
        public string? CitizenCntryName { get; set; }
        public string? OrgCntryOfBusCd { get; set; }
        public string? OrgCntryOfBusName { get; set; }
        public string? EmpInd { get; set; }
        public string? EmpNo { get; set; }
        public string? EmprName { get; set; }
        public string? EmprTelNo { get; set; }
        public string? EmailAddr { get; set; }
        public string? OccupDesc { get; set; }
        public string? IndsCd { get; set; }
        public string? IndsCdRr { get; set; }
        public string? IndsDesc { get; set; }
        public string? TelNo1 { get; set; }
        public string? TelNo2 { get; set; }
        public string? TelNo3 { get; set; }
        public decimal? AnnualIncomeAmt { get; set; }
        public decimal? NetWorthAmt { get; set; }
        public string? MaritalStatusDesc { get; set; }
        public DateTime? LastContactDate { get; set; }
        public string? PoliticalExpPrsnInd { get; set; }
        public string? NonProfitOrgInd { get; set; }
        public DateTime? CustSinceDate { get; set; }
        public DateTime? LstSuspActReportDate { get; set; }
        public DateTime? LstCashTransReportDate { get; set; }
        public DateTime? LstRiskAssmntDate { get; set; }
        public int? RiskClass { get; set; }
        public string? ExtCustInd { get; set; }
        public string? LegalObjType { get; set; }
        public string? MoneyOrderInd { get; set; }
        public string? TravChekInd { get; set; }
        public string? PrepCardInd { get; set; }
        public string? MoneyServiceBusInd { get; set; }
        public string? MoneyTransmtrInd { get; set; }
        public string? CcyExchInd { get; set; }
        public string? CheckCasherInd { get; set; }
        public string? InternetGmblngInd { get; set; }
        public string? TrustAcctInd { get; set; }
        public string? FrgnConsulate { get; set; }
        public string? IssBearsSharesInd { get; set; }
        public string? NegtvNewsInd { get; set; }
        public decimal? SuspActRptCount { get; set; }
        public DateTime? LstUpdateDate { get; set; }
        public DateTime? ChgBeginDate { get; set; }
        public DateTime ChgEndDate { get; set; }
        public string ChgCurrentInd { get; set; } = null!;
        public string? NationalAddr { get; set; }
    }
}
