

namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class CloseRequest
    {
        public List<string> Entities { get; set; } = new();
        public string Comment { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
    }
}
