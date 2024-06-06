using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public class ArtStAmlAlertAgeSummery
    {
        public string DataSource { get; set; }
        public int? Bucket1 { get; set; }
        public int? Bucket2 { get; set; }
        public int? Bucket3 { get; set; }
        public int? Bucket4 { get; set; }
        public int? Total { get; set; }
        public string? RISK_APPETITE { get; set; }
    }
}
