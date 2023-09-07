using System;
using System.Collections.Generic;

namespace Data.Data.FTI
{
    public partial class ArtTiFullJournalReport
    {
        public string? Dataitem { get; set; }
        public string? Username { get; set; }
        public string? MtceType { get; set; }
        public string? Mcmtcetype { get; set; }
        public string? Mcusername { get; set; }
        public string? AreaCode { get; set; }
        public string? Area { get; set; }
        public decimal? Jkey { get; set; }
        public DateTime? Datetime { get; set; }
        public decimal? Mcowner { get; set; }
        public DateTime? Entrytimeutc { get; set; }
        public string? Mcaction { get; set; }
        public string? Mcnote { get; set; }
        public string? DataAfter { get; set; }
        public string? Databefore { get; set; }
    }
}
