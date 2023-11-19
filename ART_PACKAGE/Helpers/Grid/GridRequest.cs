namespace ART_PACKAGE.Helpers.Grid
{
    public class GridRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public Filter Filter { get; set; }
        public bool IsIntialize { get; set; }
    }


    public class Filter
    {
        public string logic { get; set; } // "and" or "or"
        public string field { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }
        public List<Filter> filters { get; set; }
    }

}
