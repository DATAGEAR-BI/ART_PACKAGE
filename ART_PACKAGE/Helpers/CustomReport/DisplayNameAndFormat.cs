﻿using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public class DisplayNameAndFormat
    {
        public string DisplayName { get; set; }
        public string Format { get; set; }
        public bool isLargeText { get; set; }
        public GridAggregateType AggType { get; set; }
        public string? AggText { get; set; }
    }
}
