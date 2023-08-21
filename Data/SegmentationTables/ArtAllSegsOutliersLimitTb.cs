using System;
using System.Collections.Generic;

namespace Data.SegmentationTables
{
    public partial class ArtAllSegsOutliersLimitTb
    {
        public string? MonthKey { get; set; }
        public string? SegmentSorted { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? Feature { get; set; }
        public decimal? UpperOutlierLimit { get; set; }
    }
}
