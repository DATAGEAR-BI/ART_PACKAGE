using Data.ModelCreatingStrategies;
using DataGear_RV_Ver_1._7.dbcmcaudit;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.SASAUDIT
{
    public class SASAUDITContext : DbContext
    {
        public SASAUDITContext()
        {
        }

        public SASAUDITContext(DbContextOptions<SASAUDITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditTrailReport> AuditTrailReports { get; set; }
        public virtual DbSet<ListAccessRightPerProfile> ListAccessRightPerProfiles { get; set; }
        public virtual DbSet<ListAccessRightPerRole> ListAccessRightPerRoles { get; set; }
        public virtual DbSet<ListAccessUsersGroupsCap> ListAccessUsersGroupsCaps { get; set; }
        public virtual DbSet<ListGroupsRolesSummary> ListGroupsRolesSummaries { get; set; }
        public virtual DbSet<ListOfUsersAndGroupsRole> ListOfUsersAndGroupsRoles { get; set; }
        public virtual DbSet<ListOfUsersAndGroup> ListOfUsersAndGroups { get; set; }
        public virtual DbSet<VaLicensedView> VaLicensedViews { get; set; }
        public virtual DbSet<VaLastLoginView> VaLastLoginViews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSasAuditModelCreating(modelBuilder);
        }

    }

}
