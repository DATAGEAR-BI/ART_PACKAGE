namespace Data.Setting
{
    public class TenantSettings
    {
        public Defaults Defaults { get; set; } = default!;
        public List<Tenant> Tenants { get; set; } = new();
    }
}
