namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public class RoleGroupsRes // Replace "YourClassName" with a meaningful name for your class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public List<object> Users { get; set; } // Change "object" to the appropriate data type if known
        public List<int> Groups { get; set; }
    }
}
