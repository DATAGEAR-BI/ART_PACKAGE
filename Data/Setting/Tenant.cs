namespace Data.Setting
{
    public class Tenant
    {
        public string Name { get; set; } = null!;
        public string TId { get; set; } = null!;
        public ModulesConnections ModulesConnections { get; set; } = default;
    }
}
