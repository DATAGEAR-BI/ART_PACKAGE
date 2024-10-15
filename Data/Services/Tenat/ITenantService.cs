using Data.Setting;

namespace Data.Services;

public interface ITenantService
{
    string? GetDatabaseProvider();
    string? GetConnectionString(string? module = "AuthContextConnection");
    Tenant? GetCurrentTenant();
}