using System;
using System.Collections.Generic;

namespace Data.SegmentationTables
{
    public partial class ArtAllSegmentsOutlier
    {
        public decimal? MonthKey { get; set; }
        public decimal? PartyNumber { get; set; }
        public string? PartyName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public string? PartyTypeDesc { get; set; }
        public decimal? SegmentSorted { get; set; }
        public string? Feature { get; set; }
        public decimal? UpperOutlierLimit { get; set; }
        public decimal? Amount { get; set; }
    }
}
