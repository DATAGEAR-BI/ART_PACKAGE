namespace Data.Data.Audit
{
    public class ListOfUsersGroup
    {
        public string UserName { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? MemberOfGroup { get; set; }
    }
}
