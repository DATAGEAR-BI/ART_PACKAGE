
namespace Data.Services.Grid
{
    public class GridResult<T>
    {
        public int total { get; set; }
        public IQueryable<T>? data { get; set; }
        public Dictionary<string, string?> dataTypeColumns { get; set; } = new Dictionary<string, string?>();
    }
}
