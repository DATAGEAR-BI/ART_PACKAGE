using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtIndustrySegmentTb
    {
        public string? MonthKey { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? IndustryDesc { get; set; }
        public string? SegmentSorted { get; set; }
        public int? NumberOfCustomers { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalCreditAmount { get; set; }
        public double? TotalDebitAmount { get; set; }
    }
}
