namespace ART_PACKAGE.Helpers.CustomReportHelpers
{

    public class KendoRequest
    {
        public int Id { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public List<SortOptions> Sort { get; set; }
        public Filter Filter { get; set; }
        public bool IsIntialize { get; set; }

    }


}
