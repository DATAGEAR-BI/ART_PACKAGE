using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Audit
{
    public class ArtAuditContext : DbContext
    {

        //Aduit
        public virtual DbSet<ArtGroupsAuditView> ArtGroupsAuditViews { get; set; } = null!;
        public virtual DbSet<ArtRolesAuditView> ArtRolesAuditViews { get; set; } = null!;
        public virtual DbSet<ArtUsersAuditView> ArtUsersAuditViews { get; set; } = null!;
        public virtual DbSet<LastLoginPerDayView> LastLoginPerDayViews { get; set; } = null!;
        public virtual DbSet<ListGroupsRolesSummary> ListGroupsRolesSummaries { get; set; } = null!;
        public virtual DbSet<ListGroupsSubGroupsSummary> ListGroupsSubGroupsSummaries { get; set; } = null!;
        public virtual DbSet<ListOfDeletedUser> ListOfDeletedUsers { get; set; } = null!;
        public virtual DbSet<ListOfGroup> ListOfGroups { get; set; } = null!;
        public virtual DbSet<ListOfRole> ListOfRoles { get; set; } = null!;
        public virtual DbSet<ListOfUser> ListOfUsers { get; set; } = null!;
        public virtual DbSet<ListOfUsersAndGroupsRole> ListOfUsersAndGroupsRoles { get; set; } = null!;
        public virtual DbSet<ListOfUsersGroup> ListOfUsersGroups { get; set; } = null!;
        public virtual DbSet<ListOfUsersRole> ListOfUsersRoles { get; set; } = null!;
        public ArtAuditContext(DbContextOptions<ArtAuditContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtGroupsAuditView>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtRolesAuditView>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtUsersAuditView>().HasNoKey().ToView(null);
            modelBuilder.Entity<LastLoginPerDayView>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListGroupsRolesSummary>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListGroupsSubGroupsSummary>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfDeletedUser>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfGroup>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfRole>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfUser>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfUsersAndGroupsRole>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfUsersGroup>().HasNoKey().ToView(null);
            modelBuilder.Entity<ListOfUsersRole>().HasNoKey().ToView(null);

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnAuditModelCreating(modelBuilder);
        }


    }
}
