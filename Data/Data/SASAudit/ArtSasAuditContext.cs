using System;
using System.Collections.Generic;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Data.SASAudit
{
    public partial class ArtSasAuditContext : DbContext
    {
        public ArtSasAuditContext()
        {
        }

        public ArtSasAuditContext(DbContextOptions<ArtSasAuditContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditTrailReport> AuditTrailReports { get; set; } = null!;
        public virtual DbSet<ListAccessRightPerProfile> ListAccessRightPerProfiles { get; set; } = null!;
        public virtual DbSet<ListAccessRightPerRole> ListAccessRightPerRoles { get; set; } = null!;
        public virtual DbSet<SasUsersAndGroupsRole> SasUsersAndGroupsRoles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSasAuditModelCreating(modelBuilder);
        }
    }
}
