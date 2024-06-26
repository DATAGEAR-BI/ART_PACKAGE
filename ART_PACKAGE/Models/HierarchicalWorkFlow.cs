namespace ART_PACKAGE.Models
{
    public class HierarchicalWorkFlow
    {
        public string id { get; set; }
        public string? name { get; set; }
        public string? title { get; set; }
        public string? parentId { get; set; }
        public bool? expanded { get; set; }

    }
}
