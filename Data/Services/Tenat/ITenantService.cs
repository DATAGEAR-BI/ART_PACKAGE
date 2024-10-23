using Data.Setting;

namespace Data.Services;

public interface ITenantService
{
    string? GetDatabaseProvider();
    int? GetCommendTimeOut();
    string? GetConnectionString(string? module = "ARTContextConnection", string? contextName = "default>>");
    string? GetTenantConnectionString(string tenantID,string? module = "ARTContextConnection");

    Tenant? GetCurrentTenant();
    List<string>? GetAllTenantsIDs();
    void ManiualSetCurrentTenant(string tenantId);
    void ManiualSetCurrentConnections(string tenantId);
    void Print(string? module = "ARTContextConnection", string? contextName = "default>>");


}