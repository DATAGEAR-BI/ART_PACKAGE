using Data.Services.Grid;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
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
        public Func<ClaimsPrincipal, bool>? ShowExportPdf { get; set; } = (s => true);
        public Type MapperType { get; set; }
        public string? ReportTitle { get; set; }
        public string? ReportDescription { get; set; }
        public SortOption? defaultSortOption { get; set; }
        public bool HasFixedWidth { get; set; } = false;
    }
}