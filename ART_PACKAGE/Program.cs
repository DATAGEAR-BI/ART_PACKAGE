using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.BackGroundServices;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.LDap;
using ART_PACKAGE.Helpers.Logging;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.IServiceCollectionExtentions;
using ART_PACKAGE.Middlewares;
using ART_PACKAGE.Services.Pdf;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Segmentation;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = "Development",
});

builder.Services.AddDbs(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddHostedService<LicenseWatcher>();
builder.Services.AddScoped<IDropDownService, DropDownService>();
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<DBFactory>();
builder.Services.AddScoped<LDapUserManager>();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthContext>();
builder.Services.ConfigureApplicationCookie(opt =>
 {
     opt.LoginPath = new PathString("/Ldapauth/login");
 });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLicense(builder.Configuration);
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
List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();
using IServiceScope scope = app.Services.CreateScope();
AuthContext authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();
SegmentationContext SegContext = scope.ServiceProvider.GetRequiredService<SegmentationContext>();
ArtGoAmlContext GoAmlContext = scope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();
ArtDgAmlContext DgAmlContext = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
if (authContext.Database.GetPendingMigrations().Any())
{
    authContext.Database.Migrate();
}

if (modules.Contains("SEG"))
{

    if (SegContext.Database.GetPendingMigrations().Any())
    {
        SegContext.Database.Migrate();
    }
}
if (modules.Contains("GOAML"))
{

    if (GoAmlContext.Database.GetPendingMigrations().Any())
    {
        GoAmlContext.Database.Migrate();
    }
}

if (modules.Contains("DGAML"))
{

    if (DgAmlContext.Database.GetPendingMigrations().Any())
    {
        DgAmlContext.Database.Migrate();
    }
}





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
app.UseLicense();
app.MapRazorPages();
app.MapHub<LicenseHub>("/LicHub");
app.MapHub<ExportHub>("/ExportHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



