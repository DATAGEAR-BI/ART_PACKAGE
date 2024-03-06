using System;
using System.Collections.Generic;

namespace Data.Data.KYC
{
    public partial class ArtKycSummaryByRisk
    {
        public string? AmlRisk { get; set; }
        public string? Type { get; set; }
        public int? NumberOfUpdatedKyc { get; set; }
        public int? NumberOfNotUpdatedKyc { get; set; }
        public int? Total { get; set; }
    }
}
