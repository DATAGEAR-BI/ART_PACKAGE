﻿using Data.Services.Tenat;
using Data.Setting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace Data.Services;

public class TenantService : ITenantService
{
    private readonly TenantSettings _tenantSettings;
    private HttpContext? _httpContext;
    private Tenant? _currentTenant;
    private ModulesConnections? _currentConnections;
    private string tenantId;
    public TenantService( IHttpContextAccessor contextAccessor, IOptions<TenantSettings> tenantSettings, [CallerMemberName] string caller = "")
    {
        _httpContext = contextAccessor.HttpContext;
        Console.WriteLine(@$"Called By : {caller}");
        //Console.WriteLine(@$"CONTEXT :  {JsonConvert.SerializeObject(_httpContext)}");
        _tenantSettings = tenantSettings.Value;
        if(_httpContext is not null)
        {
            var claims = _httpContext.User.Claims.ToList();

            if (_httpContext.User!=null && claims.Any(s=>s.Type=="tenant_id"))
            {
                tenantId = _httpContext.User.FindFirst("tenant_id")?.Value;

                SetCurrentConnections(tenantId);
                //tenantConstants.SetID(tenantId);
                //SetCurrentTenant(tenantId!);
            }
            else
            {
                SetCurrentConnections();
               // throw new Exception("No tenant provided!");
            }
        }
        else
        {
            SetCurrentConnections();
        }

        

    }

    public string? GetConnectionString(string? module= "ARTContextConnection",string? contextName="default>>" )
    {
        try
        {
                
                var ModulesConnectionType = typeof(ModulesConnections);
                var properties = ModulesConnectionType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                string connectionString = properties.FirstOrDefault(s => s.Name == module)
                    .GetValue(_currentConnections)?.ToString() ?? throw new InvalidOperationException($@"Connection string '{module}' not found.");
            
          
            
            return connectionString;
        }
        catch (Exception)
        {
            Console.WriteLine($@"Current Context : {contextName} ,conn {module}");
            Console.WriteLine(@$"CONTEXT :  {JsonConvert.SerializeObject(_currentConnections)}");
            Console.WriteLine(@$"CONTEXT :  {JsonConvert.SerializeObject(_httpContext, Formatting.Indented,
new JsonSerializerSettings
{
    PreserveReferencesHandling = PreserveReferencesHandling.Objects
})}");
            throw new Exception("No tenant provided!");
        }
    }
    public string? GetTenantConnectionString(string tenantID, string? module = "ARTContextConnection")
    {
        try
        {
            var ModulesConnectionType = typeof(ModulesConnections);
            var properties = ModulesConnectionType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var connectionString = properties.FirstOrDefault(s => s.Name == module)
                .GetValue(_tenantSettings.Tenants.FirstOrDefault(s=>s.TId==tenantID).ModulesConnections)?.ToString() ?? throw new InvalidOperationException($@"Connection string '{module}' not found.");
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
    public ModulesConnections? GetCurrentConnections()
    {
        return _currentConnections;
    }

    public string? GetDatabaseProvider()
    {
        return _tenantSettings.Defaults.DBProvider;
    }
    public int? GetCommendTimeOut()
    {
        return _tenantSettings.Defaults.CommandTimeOut;
    }
    private void SetCurrentTenant(string tenantId)
    {
        _currentTenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TId == tenantId);

        if (_currentTenant is null)
        {
            throw new Exception("Invalid tenant ID");
        }

    }
    private void SetCurrentConnections(string? tenantId="")
    {

        _currentTenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TId == tenantId);
        if (_currentTenant != null)
        {
            _currentConnections = _currentTenant.ModulesConnections;
        }
        else if (_tenantSettings.Defaults!.Connections!=null)
        {
            _currentConnections = _tenantSettings.Defaults.Connections;
        }else
        {

            throw new Exception("Couldn't spacify connections");
        }
            


    }
    public void ManiualSetCurrentTenant(string tenantId)
    {
        _currentTenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TId == tenantId);

        if (_currentTenant is null)
        {
            throw new Exception("Invalid tenant ID");
        }

    }
    public void ManiualSetCurrentConnections(string tenantId)
    {
        _currentTenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TId == tenantId);
        if (_currentTenant != null)
        {
            _currentConnections = _currentTenant.ModulesConnections;
        }
        else if (_tenantSettings.Defaults!.Connections != null)
        {
            _currentConnections = _tenantSettings.Defaults.Connections;
        }else
        {

            throw new Exception("Couldn't spacify connections");
        }

    }
    public List<string>? GetAllTenantsIDs()=>_tenantSettings.Tenants.Select(s => s.TId).ToList();
    public void Print(string? module = "ARTContextConnection", string? contextName = "default>>")
    {
        Console.WriteLine($@"Current Context : {contextName} ,conn {module}");
        Console.WriteLine(@$"CONTEXT :  {JsonConvert.SerializeObject(_currentConnections)}");
        var claims = _httpContext.User.Claims.ToList();

        if (_httpContext.User != null && claims.Any())
        {
            foreach (var item in claims)
            {
                Console.WriteLine($@" {item.Type} : {item.Value}");
            }
        }
/*            Console.WriteLine(@$"CONTEXT :  {JsonConvert.SerializeObject(_httpContext, Formatting.Indented,
new JsonSerializerSettings
{
PreserveReferencesHandling = PreserveReferencesHandling.Objects
})}");*/
    }
}