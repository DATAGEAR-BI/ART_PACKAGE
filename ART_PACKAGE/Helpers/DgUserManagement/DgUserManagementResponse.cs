namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public class DgUserManagementResponse
    {
        public List<Group> Groups { get; set; }
        public List<Role> Roles { get; set; }
        public List<object> GroupsIds { get; set; }
        public List<object> RolesIds { get; set; }
        public List<object> Accounts { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
        public string DisplayName { get; set; }
        public object Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public object CreatedBy { get; set; }
        public object CreatedDate { get; set; }
        public object Password { get; set; }
        public object LastUpdatedBy { get; set; }
        public object LastUpdatedDate { get; set; }
        public bool Active { get; set; }
        public bool Enable { get; set; }
    }
}
