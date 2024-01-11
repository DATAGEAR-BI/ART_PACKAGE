namespace ART_PACKAGE.Helpers.CustomReport
{
    public class ShareReportDto
    {
        public int ReportId { get; set; }
        public List<string> Recievers { get; set; }
        public string ShareMessage { get; set; }
    }
}