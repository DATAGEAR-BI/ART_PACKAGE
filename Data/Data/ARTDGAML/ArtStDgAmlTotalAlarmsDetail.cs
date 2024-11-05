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
        public string? Closed_USER_ID { get; set; }  // 
        public DateTime? close_date { get; set; }
        public string? close_reason { get; set; }
        public string? customer_name { get; set; }
        public string? customer_number { get; set; }
        public string? customer_identification_id { get; set; }
        public DateTime? customer_date_of_birth { get; set; }
        public string? PHONE_NUMBER { get; set; }
        public int RISK_CLASSIFICATION { get; set; }
        public string? occupation_desc { get; set; }
        public DateTime? CUSTOMER_SINCE_DATE { get; set; }
    }
}
