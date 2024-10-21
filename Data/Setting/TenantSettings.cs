namespace Data.Setting
{
    public partial class TenantSettings
    {
        public Defaults Defaults { get; set; } = default!;
        public List<Tenant> Tenants { get; set; } = new();
    }
}
