using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Extentions.WebApplicationExttentions;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DgUserManagement;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.LDap;
using ART_PACKAGE.Helpers.Logging;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.Identity;
using Rotativa.AspNetCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
{

    EnvironmentName = "UAT",
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

builder.Services.AddScoped<ICsvExport, CsvExport>();
builder.Services.AddDefaultIdentity<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthContext>();

builder.Services.ConfigureApplicationCookie(opt =>
 {

     opt.LoginPath = new PathString("/Account/Ldapauth/login");
 });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddLicense(builder.Configuration);
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
app.ApplyModulesMigrations();


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
//app.UseLicense();
app.MapRazorPages();
app.MapHub<LicenseHub>("/LicHub");
app.MapHub<ExportHub>("/ExportHub");
app.MapHub<AmlAnalysisHub>("/AmlAnalysisHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



