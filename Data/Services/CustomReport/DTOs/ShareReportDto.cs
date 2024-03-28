using System.Collections.Generic;

namespace Data.Services.CustomReport
{
    public class ShareReportDto
    {
        public int ReportId { get; set; }
        public List<string> Recievers { get; set; }
        public string ShareMessage { get; set; }
    }
}