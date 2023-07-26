using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtKycSummaryByRisk
    {
        public string? AmlRisk { get; set; }
        public string? Type { get; set; }
        public decimal? NumberOfUpdatedKyc { get; set; }
        public decimal? NumberOfNotUpdatedKyc { get; set; }
        public decimal? Total { get; set; }
    }
}
