using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtUserPerformancePerActionUser
    {
        public string ACTION_USER { get; set; }
        public decimal? TOTAL_NUMBER_OF_CASES { get; set; }
        public decimal? DURATIONS_IN_SECONDS { get; set; }
        public decimal? AVG_DURATIONS_IN_SECONDS { get; set; }
        public decimal? DURATIONS_IN_MINUTES { get; set; }
        public decimal? AVG_DURATIONS_IN_MINUTES { get; set; }
        public decimal? DURATIONS_IN_HOURS { get; set; }
        public decimal? AVG_DURATIONS_IN_HOURS { get; set; }
        public decimal? DURATIONS_IN_DAYS { get; set; }
        public decimal? AVG_DURATIONS_IN_DAYS { get; set; }
    }
}
