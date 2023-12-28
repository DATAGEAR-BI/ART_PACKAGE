using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public class ArtStAmlRiskClass : IChartDataEntity
    {
        public string? RISK_CLASSIFICATION { get; set; }
        public decimal? NUMBER_OF_CUSTOMERS { get; set; }
    }
}
