using Data.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Grid
{
    public  class ExportPDFRequest:ExportRequest
    {
      
        public PDF? PdfOptions { get; set; }
        

    }
}
