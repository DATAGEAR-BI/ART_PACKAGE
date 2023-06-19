

namespace Data.Data
{
    public class ListOfRole
    {
        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string RoleType { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
