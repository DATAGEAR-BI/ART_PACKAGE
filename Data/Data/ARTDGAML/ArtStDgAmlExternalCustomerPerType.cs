using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlExternalCustomerPerType : IChartDataEntity
    {
        public string? CUSTOMER_TYPE { get; set; }
        public decimal? NUMBER_OF_CUSTOMERS { get; set; }


    }
}
