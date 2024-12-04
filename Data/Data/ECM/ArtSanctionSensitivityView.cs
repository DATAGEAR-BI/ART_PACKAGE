using System;
using System.Collections.Generic;

namespace Data.Data.ECM
{
    public partial class ArtSanctionSensitivityView
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string? UserName { get; set; }
        public string? Category { get; set; }
        public string? ActionName { get; set; }
        public string? ActionDetails { get; set; }
    }
}
