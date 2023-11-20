using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportConfig
    {
        public List<string> SkipList { get; set; }
        public Dictionary<string, GridColumnConfiguration> DisplayNames { get; set; }
    }
}