namespace ART_PACKAGE.Models
{
    public class HierarchicalWorkFlow
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? title { get; set; }
        public int? parentId { get; set; }
        public bool? expanded { get; set; }

    }
}
