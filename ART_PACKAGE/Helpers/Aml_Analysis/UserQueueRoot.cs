namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class UserQueueRoot
    {
        public List<object> links { get; set; }
        public string name { get; set; }
        public string accept { get; set; }
        public int start { get; set; }
        public int count { get; set; }
        public List<QueueUser> items { get; set; }
        public int limit { get; set; }
        public int version { get; set; }
    }
}
