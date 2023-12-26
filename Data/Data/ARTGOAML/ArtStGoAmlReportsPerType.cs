using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTGOAML
{
    public class ArtStGoAmlReportsPerType:IChartDataEntity
    {
        public string? REPORT_TYPE { get; set; }
        public decimal? NUMBER_OF_REPORTS { get; set; }
    }
}
