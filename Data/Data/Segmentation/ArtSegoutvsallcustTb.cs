using System;
using System.Collections.Generic;

namespace Data.Data.Segmentation
{
    public partial class ArtSegoutvsallcustTb
    {
        public string? MonthKey { get; set; }
        public string? SegmentSorted { get; set; }
        public string PartyTypeDesc { get; set; } = null!;
        public decimal? NumberOfCustomers { get; set; }
        public decimal? NumberOfOutliers { get; set; }
    }
}
