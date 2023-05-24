using System;
using System.Collections.Generic;

namespace Data.FCF71
{
    public partial class ArtHomeAlertsPerDate
    {
        public int? Year { get; set; }
        public string? Month { get; set; }
        public int? Day { get; set; }
        public int? NumberOfAlerts { get; set; }
    }
}
