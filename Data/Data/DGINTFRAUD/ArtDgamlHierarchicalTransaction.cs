using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlHierarchicalTransaction
    {
        public string? EmployeeNumber { get; set; }
        public string? CustomerId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Role { get; set; }
        public string? StaffRelativeInd { get; set; }
        public string? Department { get; set; }
        public string? Division { get; set; }
        public string? Job { get; set; }
        public string? Grad { get; set; }
        public string? Status { get; set; }
        public string? TransactionReference { get; set; }
        public string? TransactionType { get; set; }
        public int? TransactionDate { get; set; }
        public decimal BaseAmountEgp { get; set; }
        public decimal EquivalentAmount { get; set; }
        public string? EquivalentCurrency { get; set; }
    }
}
