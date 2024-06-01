using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlCasesTransactionsDetail
    {
        public string? Employee_Number { get; set; }
        public string? Employee_Name { get; set; }
        public string? Department { get; set; }
        public string? Division { get; set; }
        public string? Job { get; set; }
        public string? Grad { get; set; }
        public string? Status { get; set; }
        public string? Transaction_Reference { get; set; }
        public long Transaction_Date { get; set; }
        public string? Transaction_Type { get; set; }
        public decimal? Base_Amount { get; set; }
        public string? Base_Currency { get; set; }
        public decimal? Equivalent_Amount { get; set; }
        public string? Equivalent_Currency { get; set; }
        public string? case_id { get; set; }
        public string? Case_Status { get; set; }
        public string? Scenario { get; set; }
        public string? Remitter_Name { get; set; }
        public string? Remitter_Number { get; set; }
    }
}
