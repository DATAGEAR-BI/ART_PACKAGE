using System;
using System.Collections.Generic;

namespace Data.SegmentationTables
{
    public partial class ArtChangedSegment
    {
        public decimal? MonthKey { get; set; }
        public decimal? PartyNumber { get; set; }
        public decimal? RiskClassification { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? IndustryCode { get; set; }
        public string? IndustryDesc { get; set; }
        public string? OccupationDesc { get; set; }
        public decimal? SegmentSorted { get; set; }
        public decimal? LastSegmentId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
