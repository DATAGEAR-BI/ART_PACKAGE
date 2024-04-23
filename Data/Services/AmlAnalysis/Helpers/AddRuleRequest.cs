namespace Data.Services.AmlAnalysis
{
    public class AddRuleRequest
    {
        public string ReadableOutPut { get; set; }
        public string TableName { get; set; }
        public string Sql { get; set; }
        public string RouteToUser { get; set; }
        public string Action { get; set; }
    }
}
