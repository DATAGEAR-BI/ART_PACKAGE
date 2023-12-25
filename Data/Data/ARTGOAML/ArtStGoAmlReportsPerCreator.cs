using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTGOAML
{
    public class ArtStGoAmlReportsPerCreator:IChartDataEntity
    {
        public string? CREATED_BY { get; set; }
        public decimal? NUMBER_OF_REPORTS { get; set; }
    }
}
