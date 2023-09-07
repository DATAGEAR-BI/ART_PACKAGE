namespace ART_PACKAGE.Helpers.CustomReport
{
    public class KendoDataDesc<T>
    {
        public IQueryable<T> Data { get; set; }
        public List<ColumnsDto> Columns { get; set; }

        public decimal Total { get; set; }
    }
}
