using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public partial class ArtStDgAmlTotalAlarmsDetail
    {
        // Numeric type with 9 digits, using long to accommodate large numbers
        public decimal? Alarm_ID { get; set; }

        // nvarchar with a maximum length of 6, not nullable
        public string? Alarm_level { get; set; }

        // varchar with a maximum length of 17, nullable
        public string? Alarm_Status { get; set; }

        // nvarchar with a maximum length of 200, not nullable
        public string? Alarm_Message { get; set; }

        // nvarchar with a maximum length of 64, nullable
        public string? Scenario_Name { get; set; }

        // nvarchar with a maximum length of 510, nullable
        public string? Scenario_Description { get; set; }

        // datetime, not nullable
        public DateTime? Run_date { get; set; }
    }
}
