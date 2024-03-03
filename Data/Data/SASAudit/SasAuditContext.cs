using System;
using System.Collections.Generic;
using Data.Data.CRP;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Data.SASAudit
{
    public partial class SasAuditContext : DbContext
    {
        public virtual DbSet<SasAuditTrailReport> SasAuditTrailReports { get; set; } = null!;
        public virtual DbSet<SasListAccessRightPerProfile> SasListAccessRightPerProfiles { get; set; } = null!;
        public virtual DbSet<SasListAccessRightPerRole> SasListAccessRightPerRoles { get; set; } = null!;
        public virtual DbSet<SasListAccessUsersGroupsCap> SasListAccessUsersGroupsCaps { get; set; } = null!;
        public virtual DbSet<SasListGroupsRolesSummary> SasListGroupsRolesSummaries { get; set; } = null!;
        public virtual DbSet<SasListOfUsersAndGroupsRole> SasListOfUsersAndGroupsRoles { get; set; } = null!;
        public virtual DbSet<SasListUsersDepartment> SasListUsersDepartments { get; set; } = null!;
        public virtual DbSet<VaLastLogin> VaLastLogins { get; set; }=null!;
        public virtual DbSet<VaLicensed> VaLicenseds { get; set; }=null!;

        public SasAuditContext(DbContextOptions<SasAuditContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSasAuditModelCreating(modelBuilder);
        }

    }
}
