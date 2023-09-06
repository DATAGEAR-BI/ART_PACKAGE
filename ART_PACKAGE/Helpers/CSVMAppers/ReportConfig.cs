using ART_PACKAGE.Helpers.CustomReportHelpers;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportConfig
    {
        public List<string> SkipList { get; set; }
        public Dictionary<string, DisplayNameAndFormat> DisplayNames { get; set; }
    }
}