using System;
using System.Collections.Generic;

namespace Data.DGAML
{
    public partial class ExternalCustomer
    {
        public int ExtCustAcctKey { get; set; }
        public string? ExtCustNo { get; set; }
        public string? ExtCustTypeDesc { get; set; }
        public string? ExtFullName { get; set; }
        public string? ExtLname { get; set; }
        public string? ExtFname { get; set; }
        public string? ExtMname { get; set; }
        public DateTime? ExtBirthDate { get; set; }
        public string? CustTaxId { get; set; }
        public string? CustTaxIdTypeCd { get; set; }
        public string? MatchCdOrg { get; set; }
        public string? MatchCdIndv { get; set; }
        public string? MatchCdAddr { get; set; }
        public string? MatchCdAddrLine { get; set; }
        public string? MatchCdCity { get; set; }
        public string? MatchCdState { get; set; }
        public string? MatchCdCntry { get; set; }
        public string? Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public string? CityName { get; set; }
        public string? StateCd { get; set; }
        public string? StateName { get; set; }
        public string? PostCd { get; set; }
        public string? CntryCd { get; set; }
        public string? CntryName { get; set; }
        public string? AcctNo { get; set; }
        public string? FiNo { get; set; }
        public string? BranchNo { get; set; }
        public string? BranchName { get; set; }
        public string? CitizenCntryCd { get; set; }
        public string? CitizenCntryName { get; set; }
        public string? ResidCntryCd { get; set; }
        public string? ResidCntryName { get; set; }
        public string? TelNo1 { get; set; }
        public string? TelNo2 { get; set; }
        public string? IdentId { get; set; }
        public string? IdentTypeDesc { get; set; }
        public string? IdentStateCd { get; set; }
        public string? IdentCntryCd { get; set; }
        public string? IdentCntryName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
