using System;
using System.Collections.Generic;

namespace Data.SegmentationTables
{
    public partial class ArtAlertsPerSegment
    {
        public decimal? MonthKey { get; set; }
        public string? PartyTypeDesc { get; set; }
        public decimal? SegmentSorted { get; set; }
        public decimal? NumberOfAlerts { get; set; }
    }
}
