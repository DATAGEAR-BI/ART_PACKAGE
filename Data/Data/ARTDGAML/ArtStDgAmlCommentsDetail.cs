using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public partial class ArtStDgAmlCommentsDetail
    {
        public Decimal ALARM_ID { get; set; }
        public string? ALARM_LEVEL { get; set; } //
        public string? ALARM_STATUS { get; set; } //
        public string? ALARM_MESSAGE { get; set; } //
        public string? SCENARIO_NAME { get; set; } //
        public string? SCENARIO_DESCRIPTION { get; set; } //
        public DateTime RUN_DATE { get; set; } 
        public string? CLOSED_USER_ID { get; set; }  //
        public DateTime? CLOSE_DATE { get; set; }  //
        public string? CLOSE_REASON { get; set; }  //
        public string? CUSTOMER_NAME { get; set; }  //
        public string? CUSTOMER_NUMBER { get; set; }  //
        public string? CUSTOMER_IDENTIFICATION_ID { get; set; }  //
        public DateTime? CUSTOMER_DATE_OF_BIRTH { get; set; }  //
        public string? PHONE_NUMBER { get; set; }  //
        public int? MONEY_LAUNDERING_RISK_SCORE { get; set; }  //
        public string? OCCUPATION_DESC { get; set; }  //
        public DateTime? CUSTOMER_SINCE_DATE { get; set; }  //
        public string? LOAN_NUMBERS { get; set; }  //
        public string? POLITICALLY_EXPOSED { get; set; }  //
        public string? COMMENT { get; set; }

        public Decimal? COMMENT_USER { get; set; }

        public DateTime? COMMENT_DATE { get; set; }
    }
}
