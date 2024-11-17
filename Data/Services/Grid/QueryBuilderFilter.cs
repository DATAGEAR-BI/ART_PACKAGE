using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Grid
{
    public class QueryBuilderFilter
    {

        public string? field { get; set; }
        public string? id { get; set; }
        public string? input { get; set; }
        public string? @operator { get; set; }
        public string? type { get; set; }
        public string? value { get; set; }
    }
}
