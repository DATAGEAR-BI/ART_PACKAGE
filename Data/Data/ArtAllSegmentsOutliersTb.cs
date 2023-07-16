using System;
using System.Collections.Generic;

namespace Data.SEGMODEL
{
    public partial class ArtAllSegmentsOutliersTb
    {
        public string? MonthKey { get; set; }
        public string? PartyNumber { get; set; }
        public string? PartyName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? SegmentSorted { get; set; }
        public string? Feature { get; set; }
        public double? UpperOutlierLimit { get; set; }
        public double? Amount { get; set; }
    }
}
