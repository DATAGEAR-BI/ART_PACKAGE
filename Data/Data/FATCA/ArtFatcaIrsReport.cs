using System;
using System.Collections.Generic;

namespace Data.DATA.FATCA
{
    public partial class ArtFatcaIrsReport
    {
        public string? Accountnumber { get; set; }
        public string? Accountclosed { get; set; }
        public string? Countrycode { get; set; }
        public string? Tin { get; set; }
        public string? Middlename { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Countrycodeadd { get; set; }
        public string? AddressfreeI { get; set; }
        public string? AddressfreeE { get; set; }
        public string? Birthdate { get; set; }
        public string? Nationality { get; set; }
        public decimal? Accountbalance { get; set; }
        public string? Accountholdertype { get; set; }
        public string? Accounttype { get; set; }
        public string? OwnerFirstName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerTin { get; set; }
        public string? OwnerResCountryCode { get; set; }
        public string? OwnerAddress { get; set; }
        public decimal? Paymentamnt501 { get; set; }
        public decimal? Paymentamnt502 { get; set; }
        public decimal? Paymentamnt503 { get; set; }
        public decimal? Paymentamnt504 { get; set; }
        public string? AccountcountFatca201 { get; set; }
        public string? PoolbalanceFatca201 { get; set; }
        public string? AccountcountFatca202 { get; set; }
        public string? PoolbalanceFatca202 { get; set; }
        public decimal? AccountcountFatca203 { get; set; }
        public decimal? PoolbalanceFatca203 { get; set; }
        public string? AccountcountFatca204 { get; set; }
        public string? PoolbalanceFatca204 { get; set; }
        public string? AccountcountFatca205 { get; set; }
        public string? PoolbalanceFatca205 { get; set; }
        public string? AccountcountFatca206 { get; set; }
        public string? PoolbalanceFatca206 { get; set; }
        public string? SignW8 { get; set; }
        public string? SignW9 { get; set; }
    }
}
