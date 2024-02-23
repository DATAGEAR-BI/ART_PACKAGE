using System;
using System.Collections.Generic;

namespace Data.FATCADBSQLSERVER
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
        public string Birthdate { get; set; } = null!;
        public string? Nationality { get; set; }
        public double? Accountbalance { get; set; }
        public string Accountholdertype { get; set; } = null!;
        public string Accounttype { get; set; } = null!;
        public string OwnerFirstName { get; set; } = null!;
        public string OwnerLastName { get; set; } = null!;
        public string OwnerTin { get; set; } = null!;
        public string OwnerResCountryCode { get; set; } = null!;
        public string OwnerAddress { get; set; } = null!;
        public double? Paymentamnt501 { get; set; }
        public double? Paymentamnt502 { get; set; }
        public double? Paymentamnt503 { get; set; }
        public double? Paymentamnt504 { get; set; }
        public string AccountcountFatca201 { get; set; } = null!;
        public string PoolbalanceFatca201 { get; set; } = null!;
        public string AccountcountFatca202 { get; set; } = null!;
        public string PoolbalanceFatca202 { get; set; } = null!;
        public double? AccountcountFatca203 { get; set; }
        public double? PoolbalanceFatca203 { get; set; }
        public string AccountcountFatca204 { get; set; } = null!;
        public string PoolbalanceFatca204 { get; set; } = null!;
        public string AccountcountFatca205 { get; set; } = null!;
        public string PoolbalanceFatca205 { get; set; } = null!;
        public string AccountcountFatca206 { get; set; } = null!;
        public string PoolbalanceFatca206 { get; set; } = null!;
        public string? SignW8 { get; set; }
        public string? SignW9 { get; set; }
    }
}
