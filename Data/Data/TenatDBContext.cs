using Data.Constants.db;
using Data.Contracts;
using Data.Services;
using Data.Setting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class TenatDBContext :DbContext
    {
        public string TenantId { get; set; }
        private readonly ITenantService _tenantService;
        public TenatDBContext(DbContextOptions options, ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
            TenantId = _tenantService.GetCurrentTenant()?.TId;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entityclass>().HasQueryFilter(e => e.TenantId == TenantId);

            base.OnModelCreating(modelBuilder);
        }

        void contextBuilder(DbContextOptionsBuilder options, string conn, int commandTimeOut = 120)
        {
            var tenantConnectionString = _tenantService.GetConnectionString(conn);
            if (!string.IsNullOrWhiteSpace(tenantConnectionString))
            {
                string dbType = _tenantService.GetDatabaseProvider();
                _ = dbType switch
                {
                    DbTypes.SqlServer => options.UseSqlServer(
                        conn,
                        x => { _ = x.MigrationsAssembly("SqlServerMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    DbTypes.Oracle => options.UseOracle(
                        conn,
                        x => { _ = x.MigrationsAssembly("OracleMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    DbTypes.MySql => options.UseMySQL(
                    conn,
                    x => { _ = x.MigrationsAssembly("MySqlMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                    ),
                    _ => throw new Exception($"Unsupported provider: {dbType}")
                };
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.TenantId = TenantId;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
