using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtUserPerformPerAction
    {
        public string action { get; set; }
        public int? Total_Number_Of_Cases { get; set; }
        public int? durations_in_seconds { get; set; }
        public int? AVG_durations_in_seconds { get; set; }
        public int? durations_in_minutes { get; set; }
        public int? AVG_durations_in_minutes { get; set; }
        public int? durations_in_hours { get; set; }
        public int? AVG_durations_in_hours { get; set; }
        public int? durations_in_days { get; set; }
        public int? AVG_durations_in_days { get; set; }
    }
}
