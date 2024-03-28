using Data.Services.QueryBuilder;
using System.Collections.Generic;

namespace Data.Services.Grid
{
    public class GridRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public Filter Filter { get; set; }
        public bool IsIntialize { get; set; }
        public List<SortOption> Sort { get; set; }
        public List<GroupOption>? Group { get; set; }
        public bool All { get; set; }
        public string? IdColumn { get; set; }
        public List<string>? SelectedValues { get; set; }

        public bool IsStored { get; set; }
        public List<BuilderFilter>? QueryBuilderFilters { get; set; }

    }


    public class Filter
    {
        public string logic { get; set; } // "and" or "or"
        public string field { get; set; }
        public string @operator { get; set; }
        public object value { get; set; }
        public List<Filter> filters { get; set; }
    }

    public class SortOption
    {
        public string dir { get; set; }
        public string field { get; set; }
    }

    public class GroupOption
    {
        public string field { get; set; } = null!;
        public string dir { get; set; } = null!;

        public List<AggregateOption>? aggregates { get; set; }
    }

    public class AggregateOption
    {
        public string field { get; set; } = null!;
        public string aggregate { get; set; } = null!;
    }

}
