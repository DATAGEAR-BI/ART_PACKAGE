using System;
using System.Collections.Generic;

namespace Data.Data.KYC
{
    public partial class ArtKycLowExpired
    {
        public string? ClientNumber { get; set; }
        public string? AmlRisk { get; set; }
        public string? Type { get; set; }
        public string? EntityName { get; set; }
        public string? BranchName { get; set; }
        public DateTime? NextUpdateDate { get; set; }
    }
}
