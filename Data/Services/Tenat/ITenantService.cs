using Data.Setting;

namespace Data.Services;

public interface ITenantService
{
    string? GetDatabaseProvider();
    int? GetCommendTimeOut();
    string? GetConnectionString(string? module = "AuthContextConnection");
    string? GetTenantConnectionString(string tenantID,string? module = "AuthContextConnection" );

    Tenant? GetCurrentTenant();
    List<string>? GetAllTenantsIDs();
    void ManiualSetCurrentTenant(string tenantId);


}