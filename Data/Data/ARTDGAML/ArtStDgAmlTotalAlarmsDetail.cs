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
        public decimal? ALARM_ID { get; set; }

        // nvarchar with a maximum length of 6, not nullable
        public string? ALARM_LEVEL { get; set; }

        // varchar with a maximum length of 17, nullable
        public string? ALARM_STATUS { get; set; }

        // nvarchar with a maximum length of 200, not nullable
        public string? ALARM_MESSAGE { get; set; }

        // nvarchar with a maximum length of 64, nullable
        public string? SCENARIO_NAME { get; set; }

        // nvarchar with a maximum length of 510, nullable
        public string? SCENARIO_DESCRIPTION { get; set; }

        // datetime, not nullable
        public DateTime? RUN_DATE { get; set; }
        public string? CLOSED_USER_ID { get; set; }  
        public DateTime? CLOSE_DATE { get; set; }
        public string? CLOSE_REASON { get; set; }
        public string? CUSTOMER_NAME { get; set; }
        public string? CUSTOMER_NUMBER { get; set; }
        public string? CUSTOMER_IDENTIFICATION_ID { get; set; }
        public DateTime? CUSTOMER_DATE_OF_BIRTH { get; set; }
        public string? PHONE_NUMBER { get; set; }
        public int MONEY_LAUNDERING_RISK_SCORE { get; set; }
        public string? OCCUPATION_DESC { get; set; }
        public DateTime? CUSTOMER_SINCE_DATE { get; set; }
        public string? LOAN_NUMBERS { get; set; }
        public string? POLITICALLY_EXPOSED { get; set; }
        public string? TRANSACTION_REFERENCE { get; set; }
        public string? TRANSACTION_TYPE { get; set; }
        public int? TRANSACTION_DATE { get; set; }
        public Decimal? EQUIVALENT_AMOUNT { get; set; }
        public string? EQUIVALENT_CURRENCY { get; set; }
    }
}
