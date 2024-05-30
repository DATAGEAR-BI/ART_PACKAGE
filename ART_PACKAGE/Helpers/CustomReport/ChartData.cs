using ART_PACKAGE.Areas.Identity.Data;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public class ChartData<T>
    {
        public string ChartId { get; set; }
        public string Cat { get; set; }
        public string Val { get; set; }
        public string Title { get; set; }
        public string? LeggendLabelTemplate { get; set; }
        public List<T> Data { get; set; }

        public ChartType Type { get; set; }

    }
}
