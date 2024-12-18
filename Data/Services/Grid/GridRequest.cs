using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Grid
{
    public class GridRequest:KendoGridRequest
    {
        public List<QueryBuilderFilter>? procFilters { get; set; }

    }
}
