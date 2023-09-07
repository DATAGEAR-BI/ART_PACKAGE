using System;
using System.Collections.Generic;

namespace Data.Data.KYC
{
    public partial class ArtKycHighTwoMonth
    {
        public string? ClientNumber { get; set; }
        public string? AmlRisk { get; set; }
        public string? Type { get; set; }
        public string? EntityName { get; set; }
        public string? RiskClassIndustry { get; set; }
        public DateTime? NextUpdateDate { get; set; }
        public decimal? Month { get; set; }
    }
}
