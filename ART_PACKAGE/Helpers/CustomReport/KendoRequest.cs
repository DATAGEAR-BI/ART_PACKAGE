namespace ART_PACKAGE.Helpers.CustomReport

{

    public class KendoRequest
    {
        public int Id { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public List<SortOptions> Sort { get; set; }
        public Filter Filter { get; set; }
        public bool IsIntialize { get; set; }
        public bool? IsExport { get; set; } = false;
        public List<GridGroup>? Group { get; set; }

    }


}
