using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ART_PACKAGE.Areas.Identity.Data;
using Serilog;
using Microsoft.AspNetCore.Http;
using ART_PACKAGE.Helpers.Logging;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Data.DGCMGMT;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.LDap;
using Data.FCF71;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using Rotativa.AspNetCore;
using Data.DGECM;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = "Development",
});
var connectionString = builder.Configuration.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
var DGECMContextConnection = builder.Configuration.GetConnectionString("DGECMContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
var migrationsToApply = builder.Configuration.GetSection("migrations").Get<List<string>>();
var dbType = builder.Configuration.GetValue<string>("dbType").ToUpper();
var migrationPath = dbType == Data.Constants.db.DbTypes.SqlServer ? "SqlServerMigrations" : "OracleMigrations";
builder.Services.AddDbContext<AuthContext>(options => _ = dbType switch
{
    Data.Constants.db.DbTypes.SqlServer => options.UseSqlServer(
        connectionString,
        x => x.MigrationsAssembly("SqlServerMigrations")
        ),
    Data.Constants.db.DbTypes.Oracle => options.UseOracle(
        connectionString,
        x => x.MigrationsAssembly("OracleMigrations")
        ),
    _ => throw new Exception($"Unsupported provider: {dbType}")
});

builder.Services.AddDbContext<DGECMContext>(options => _ = dbType switch
{
    Data.Constants.db.DbTypes.SqlServer => options.UseSqlServer(
        DGECMContextConnection,
        x => x.MigrationsAssembly("SqlServerMigrations")
        ),
    Data.Constants.db.DbTypes.Oracle => options.UseOracle(
        DGECMContextConnection,
        x => x.MigrationsAssembly("OracleMigrations")
        ),
    _ => throw new Exception($"Unsupported provider: {dbType}")
});



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
app.UseAuthentication(); ;
app.UseMiddleware<LogUserNameMiddleware>();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



