using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.BackGroundServices;
using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Extentions.WebApplicationExttentions;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DgUserManagement;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Handlers;
using ART_PACKAGE.Helpers.LDap;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.Middlewares;
using ART_PACKAGE.Middlewares.Logging;
using ART_PACKAGE.Services;
using Microsoft.AspNetCore.Identity;
using Rotativa.AspNetCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = "Production", //=> make it Production before you make the release
});

builder.Services.AddDbs(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddHostedService<LicenseWatcher>();
builder.Services.AddScoped<IDropDownService, DropDownService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddScoped<DBFactory>();
builder.Services.AddScoped<LDapUserManager>();
builder.Services.AddScoped<IDgUserManager, DgUserManager>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddCustomAuthorization();
builder.Services.AddScoped<ICsvExport, CsvExport>();
builder.Services.AddDefaultIdentity<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthContext>();


var cerPath = Path.Combine(builder.Environment.ContentRootPath, "dgum_cer", "DG-DEMO.Datagearbi.local.crt");
var cerPass = builder.Configuration.GetSection("DgUserManagementAuth").GetSection("CertificatePassword").Value;
var certificate = Certificate.LoadCertificate(cerPath, cerPass);

builder.Services.AddHttpClient("CertificateClient")
        .ConfigurePrimaryHttpMessageHandler(() => new CertificateHttpClientHandler(certificate));

builder.Services.ConfigureApplicationCookie(opt =>
{
    string LoginProvider = builder.Configuration.GetSection("LoginProvider").Value;
    if (LoginProvider == "DGUM") opt.LoginPath = new PathString("/Account/DgUMAuth/login");
    else if (LoginProvider == "LDAP") opt.LoginPath = new PathString("/Account/Ldapauth/login");

});
var maxHeaderSize = builder.Configuration.GetValue<int>("Kestrel:Limits:MaxRequestHeadersTotalSize", 32768);
var maxLineSize = builder.Configuration.GetValue<int>("Kestrel:Limits:MaxRequestLineSize", 8192);
var maxHeaderCount = builder.Configuration.GetValue<int>("Kestrel:Limits:MaxRequestHeaderCount", 100);


builder.WebHost.ConfigureKestrel(options =>
{

    options.Limits.MaxRequestHeadersTotalSize = builder.Configuration.GetValue<int>("Kestrel:Limits:MaxRequestHeadersTotalSize", 1048576);; // Default is 32 KB, increase as needed
    options.Limits.MaxRequestLineSize = builder.Configuration.GetValue<int>("Kestrel:Limits:MaxRequestLineSize", 8192);  ; // Default is 8 KB
    options.Limits.MaxRequestHeaderCount = builder.Configuration.GetValue<int>("Kestrel:Limits:MaxRequestHeaderCount", 100);  ; // Default is 100
});


Console.WriteLine($"MaxRequestHeadersTotalSize: {maxHeaderSize}");
Console.WriteLine($"MaxRequestLineSize: {maxLineSize}");
Console.WriteLine($"MaxRequestHeaderCount: {maxHeaderCount}");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLicense(builder.Configuration);
builder.Services.AddSingleton<UsersConnectionIds>();

IHttpContextAccessor HttpContextAccessor = builder.Services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>();



// Get the IHttpContextAccessor instance
Serilog.Core.Logger logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()

    .CreateLogger();
builder.Logging.AddConsole();
builder.Logging.AddSerilog(logger);
RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)builder.Environment, "Rotativa");


WebApplication app = builder.Build();
//app.ApplyModulesMigrations();

app.SeedModuleRoles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCustomAuthorization();
app.UseMiddleware<LogUserNameMiddleware>();
app.UseLicense();
app.MapRazorPages();
app.MapHub<LicenseHub>("/LicHub");
app.MapHub<ExportHub>("/ExportHub");
app.MapHub<AmlAnalysisHub>("/AmlAnalysisHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Use(async (context, next) =>
{
    var totalHeaderSize = context.Request.Headers.Sum(h => h.Key.Length + h.Value.Sum(v => v.Length));
    Console.WriteLine($"Total Header Size: {totalHeaderSize} bytes");

    foreach (var header in context.Request.Headers)
    {
        Console.WriteLine($"{header.Key}: {header.Value} (Size: {header.Value.Sum(v => v.Length)} bytes)");
    }

    await next();
});

app.Run();



