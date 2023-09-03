using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class GroupedData
    {
        public Dictionary<string, object>? Key { get; set; }
        public List<Dictionary<string, object>>? Items { get; set; }

        public List<(string Column, bool HasAggreGate, string AggregateType)> Columns { get; set; }
    }
}
