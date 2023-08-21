using System;
using System.Collections.Generic;

namespace ART_PACKAGE.SegmentationTables
{
    public partial class ArtIndustrySegmentTb
    {
        public string? MonthKey { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? IndustryDesc { get; set; }
        public string? SegmentSorted { get; set; }
        public decimal? NumberOfCustomers { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalCreditAmount { get; set; }
        public decimal? TotalDebitAmount { get; set; }
    }
}
