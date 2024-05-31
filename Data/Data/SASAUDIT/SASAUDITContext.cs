using Data.ModelCreatingStrategies;
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

        public virtual DbSet<SasAuditTrailReport> SasAuditTrailReports { get; set; } = null!;
        public virtual DbSet<SasListAccessRightPerProfile> SasListAccessRightPerProfiles { get; set; } = null!;
        public virtual DbSet<SasListAccessRightPerRole> SasListAccessRightPerRoles { get; set; } = null!;
        public virtual DbSet<SasListAccessUsersGroupsCap> SasListAccessUsersGroupsCaps { get; set; } = null!;
        public virtual DbSet<SasListGroupsRolesSummary> SasListGroupsRolesSummaries { get; set; } = null!;
        public virtual DbSet<SasListOfUsersAndGroupsRole> SasListOfUsersAndGroupsRoles { get; set; } = null!;
        public virtual DbSet<SasListUsersDepartment> SasListUsersDepartments { get; set; } = null!;
        public virtual DbSet<VaLastLoginView> VaLastLoginViews { get; set; } = null!;
        public virtual DbSet<VaLicensedView> VaLicensedViews { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* if (!optionsBuilder.IsConfigured)
             {
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                 optionsBuilder.UseSqlServer("Server=192.168.1.45; Database=ART_DB; User Id=sa; Password=P@ssw0rd; Encrypt=False; MultipleActiveResultSets=True;");
             }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSasAuditModelCreating(modelBuilder);
        }

    }

}
