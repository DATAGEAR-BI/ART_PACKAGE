using System;
using System.Collections.Generic;

namespace Data.SegmentationTables
{
    public partial class ArtSegoutvsalloutTb
    {
        public string? MonthKey { get; set; }
        public string? SegmentSorted { get; set; }
        public string? PartyTypeDesc { get; set; }
        public decimal? NumberOfOutliers { get; set; }
        public decimal? TotalNumberOfOutliers { get; set; }
    }
}
