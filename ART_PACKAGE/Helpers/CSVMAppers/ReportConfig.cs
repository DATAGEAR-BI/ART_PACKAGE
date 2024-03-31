using Data.Services.Grid;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportConfig
    {
        public List<string> SkipList { get; set; }
        public Dictionary<string, GridColumnConfiguration> DisplayNames { get; set; }
        public bool ContainsActions { get; set; }
        public bool Selectable { get; set; }
        public List<GridButton>? Actions { get; set; }
        public List<GridButton>? Toolbar { get; set; }
        public Func<ClaimsPrincipal, bool>? ShowExportCsv { get; set; }
        public Func<ClaimsPrincipal, bool>? ShowExportPdf { get; set; }
        public Type MapperType { get; set; }
    }
}