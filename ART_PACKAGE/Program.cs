using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.BackGroundServices;
using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Extentions.WebApplicationExttentions;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Chart;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DgUserManagement;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper;
using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Handlers;
using ART_PACKAGE.Helpers.LDap;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.Middlewares;
using ART_PACKAGE.Middlewares.Logging;
using ART_PACKAGE.Services;
using Data.Services;
using Data.Services.AmlAnalysis;
using Data.Services.CustomReport;
using Hangfire;
using Hangfire.LiteDB;
using Microsoft.AspNetCore.Identity;
using Rotativa.AspNetCore;
using Serilog;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
{

    EnvironmentName = "Development",
});

builder.Services.AddDbs(builder.Configuration);

builder.Services.AddSignalR();
//builder.Services.AddHostedService<LicenseWatcher>();
builder.Services.AddScoped<IDropDownService, DropDownService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddScoped<DBFactory>();
builder.Services.AddScoped<LDapUserManager>();
builder.Services.AddScoped<IDgUserManager, DgUserManager>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<Module>();
builder.Services.AddSingleton<ProcessesHandler>();
//builder.Services.AddTransient(typeof(IAmlAnalysisRepo), typeof(AmlAnalysisRepo));


builder.Services.AddTransient(typeof(IBaseRepo<,>), typeof(BaseRepo<,>));
builder.Services.AddTransient(typeof(ICustomReportRepo), typeof(CustomReportRepo));
builder.Services.AddTransient(typeof(IMyReportsRepo), typeof(MyReportsRepo));
builder.Services.AddTransient(typeof(IGridConstructor<,,>), typeof(GridConstructor<,,>));
builder.Services.AddTransient(typeof(ICustomReportGridConstructor), typeof(CustomReportGridConstructor));

builder.Services.AddTransient(typeof(IChartConstructor<,>), typeof(ChartConstructor<,>));
builder.Services.AddScoped<IDropDownMapper, DropDownMapper>();
builder.Services.AddReportsConfiguratons();

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
     else opt.LoginPath = new PathString("/Identity/Account/Login");

 });

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddLicense(builder.Configuration);
builder.Services.AddCustomAuthorization();
builder.Services.AddSingleton<UsersConnectionIds>();
IHttpContextAccessor HttpContextAccessor = builder.Services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>();

builder.Services.AddSingleton<ReportConfigService>();

// Get the IHttpContextAccessor instance
Serilog.Core.Logger logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()

    .CreateLogger();
builder.Logging.AddConsole();
builder.Logging.AddSerilog(logger);
RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)builder.Environment, "Rotativa");

builder.Services.AddHangfire(configuration =>
{
    _ = configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings();

    _ = configuration.UseLiteDbStorage();

});
builder.Services.AddScoped<CSVJobs>();
var serviceProvider = builder.Services.BuildServiceProvider();
var _recurringService = serviceProvider.GetRequiredService<IRecurringJobManager>();
var csvJobs = serviceProvider.GetRequiredService<CSVJobs>();
_recurringService.AddOrUpdate("clean-csv-directory", () =>
    csvJobs.CleanDirectory(), $"0 0 * * *");

WebApplication app = builder.Build();

app.ApplyModulesMigrations();

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
app.UseMiddleware<LogUserNameMiddleware>();
app.UseAuthorization();
app.UseCustomAuthorization();
//app.UseLicense();
app.MapRazorPages();
app.MapHub<LicenseHub>("/LicHub");
app.MapHub<ExportHub>("/ExportHub");
app.MapHub<AmlAnalysisHub>("/AmlAnalysisHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseHangfireServer();
app.UseHangfireDashboard();
app.Run();



