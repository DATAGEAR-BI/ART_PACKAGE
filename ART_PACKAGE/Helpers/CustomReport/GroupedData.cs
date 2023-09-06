namespace ART_PACKAGE.Helpers.CustomReport
{
    public class GroupedData
    {
        public Dictionary<string, object>? Key { get; set; }
        public List<Dictionary<string, object>>? Items { get; set; }

        public List<(string Column, bool HasAggreGate, string AggregateType)> Columns { get; set; }
    }
}
