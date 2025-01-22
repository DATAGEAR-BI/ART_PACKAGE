using System;
using System.Collections.Generic;

namespace Data.Data.KYC
{
    public partial class ArtKycHighExpiredU3
    {
        public string? ClientNumber { get; set; }
        public string? AmlRisk { get; set; }
        public string? Type { get; set; }
        public string? EntityName { get; set; }
        public string? RiskClassIndustry { get; set; }
        public DateTime? NextUpdateDate { get; set; }



        public string? CustomerBranch { get; set; }
        public string? AccountOfficer { get; set; }
        public string? CustomerBusinessSegment { get; set; }
    }
}
