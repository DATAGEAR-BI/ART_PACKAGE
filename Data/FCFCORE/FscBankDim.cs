using System;
using System.Collections.Generic;

namespace Data.FCFCORE
{
    public partial class FscBankDim
    {
        public long BankKey { get; set; }
        public string? BankNumber { get; set; }
        public string? BankChipsNumber { get; set; }
        public string? BankSwiftNumber { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress1 { get; set; }
        public string? BankAddress2 { get; set; }
        public string? BankCityName { get; set; }
        public string? BankStateCode { get; set; }
        public string? BankStateName { get; set; }
        public string? BankPostalCode { get; set; }
        public string? BankCountryCode { get; set; }
        public string? BankCountryName { get; set; }
        public string? BankPhoneNumber { get; set; }
        public DateTime? ChangeBeginDate { get; set; }
        public DateTime ChangeEndDate { get; set; }
        public string ChangeCurrentInd { get; set; } = null!;
    }
}
