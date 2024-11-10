using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Grid
{
    public  class ExportPDFRequest:ExportRequest
    {
        public bool? IsLandscape { get; set; }=false;
        public int? NumberOfRowsInPage { get; set; }
        public int? NumberOfColumnsInPage { get; set; }

    }
}
