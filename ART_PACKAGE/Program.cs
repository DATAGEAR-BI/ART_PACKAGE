using Microsoft.EntityFrameworkCore;
using ART_PACKAGE.Areas.Identity.Data;
using Serilog;
using ART_PACKAGE.Helpers.Logging;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.LDap;
using Rotativa.AspNetCore;
using ART_PACKAGE.IServiceCollectionExtentions;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Middlewares;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.BackGroundServices;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
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

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.AddConsole();
builder.Logging.AddSerilog(logger);
RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)builder.Environment, "Rotativa");
var app = builder.Build();

using var scope = app.Services.CreateScope();
var authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();

if (authContext.Database.GetPendingMigrations().Any())
    authContext.Database.Migrate();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



