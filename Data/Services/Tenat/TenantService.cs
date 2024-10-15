using Data.Setting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Data.Services;

public class TenantService : ITenantService
{
    private readonly TenantSettings _tenantSettings;
    private HttpContext? _httpContext;
    private Tenant? _currentTenant;

    public TenantService(IHttpContextAccessor contextAccessor, IOptions<TenantSettings> tenantSettings)
    {
        _httpContext = contextAccessor.HttpContext;
        _tenantSettings = tenantSettings.Value;

        if(_httpContext is not null)
        {
            if(_httpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
            {
                SetCurrentTenant(tenantId!);
            }
            else
            {
                throw new Exception("No tenant provided!");
            }
        }
    }

    public string? GetConnectionString(string? module= "AuthContextConnection")
    {
        try
        {
            var ModulesConnectionType = typeof(ModulesConnections);
            var properties = ModulesConnectionType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var connectionString = properties.FirstOrDefault(s => s.Name == module)
                .GetValue(_currentTenant.ModulesConnections)?.ToString();
            return connectionString;
        }
        catch (Exception)
        {

            throw new Exception("No tenant provided!");
        }
    }

    public Tenant? GetCurrentTenant()
    {
        return _currentTenant;
    }

    public string? GetDatabaseProvider()
    {
        return _tenantSettings.Defaults.DBProvider;
    }

    private void SetCurrentTenant(string tenantId)
    {
        _currentTenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TId == tenantId);

        if (_currentTenant is null)
        {
            throw new Exception("Invalid tenant ID");
        }

    }
}