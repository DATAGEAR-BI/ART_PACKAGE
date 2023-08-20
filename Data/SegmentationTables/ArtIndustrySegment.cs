using System;
using System.Collections.Generic;

namespace Data.SegmentationTables
{
    public partial class ArtIndustrySegment
    {
        public decimal? MonthKey { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? IndustryDesc { get; set; }
        public decimal? SegmentSorted { get; set; }
        public decimal? NumberOfCustomers { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalCreditAmount { get; set; }
        public decimal? TotalDebitAmount { get; set; }
    }
}
