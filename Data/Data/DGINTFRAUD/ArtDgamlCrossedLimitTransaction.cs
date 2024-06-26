using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlCrossedLimitTransaction
    {
        public string? CustomerID { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? EmployeeName { get; set; }
        public string? Department { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string? AccountName { get; set; } 
        public string? TransactionReference { get; set; }
        public string? TransactionType { get; set; }
        public int TransactionDate { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal EquivalentAmount { get; set; }
        public string? EquivalentCurrency { get; set; }
        public decimal? ThresholdCrossing { get; set; }
    }
}
