using System;
using System.Collections.Generic;

namespace Data.Data.KYC
{
    public partial class ArtKycExpiredId
    {
        public string? ClientNumber { get; set; }
        public string? EntityName { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? IdExpireDate { get; set; }
    }
}
