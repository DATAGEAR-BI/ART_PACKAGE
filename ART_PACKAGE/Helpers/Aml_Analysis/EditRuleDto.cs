namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class EditRuleDto
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public AmlAnalysisAction Action { get; set; }

        public string? RouteToUser { get; set; }
    }
}
