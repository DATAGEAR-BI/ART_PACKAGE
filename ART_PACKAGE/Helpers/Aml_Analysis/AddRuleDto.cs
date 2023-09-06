namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class AddRuleDto
    {
        public string ReadableOutPut { get; set; }
        public string TableName { get; set; }
        public string Sql { get; set; }
        public string RouteToUser { get; set; }
        public AmlAnalysisAction Action { get; set; }
    }
}
