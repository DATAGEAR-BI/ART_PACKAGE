using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlCasesTransactionsDetail
    {
        public string? EmployeeNumber { get; set; }
        public string? EmployeeName { get; set; }
        public string? Department { get; set; }
        public string? Division { get; set; }
        public string? Job { get; set; }
        public string? Grad { get; set; }
        public string? Status { get; set; }
        public string? TransactionReference { get; set; }
        public int? TransactionDate { get; set; }
        public string? TransactionType { get; set; }
        public decimal? BaseAmount { get; set; }
        public string? BaseCurrency { get; set; }
        public decimal? EquivalentAmount { get; set; }
        public string? EquivalentCurrency { get; set; }
        public string? CaseId { get; set; }
        public string? CaseStatus { get; set; }
        public string? Scenario { get; set; }
        public string? RemitterName { get; set; }
        public string? RemitterNumber { get; set; }
    }
}
