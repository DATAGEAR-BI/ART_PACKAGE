using Microsoft.EntityFrameworkCore;

namespace Data.Audit
{
    public partial class AuditContext : DbContext
    {
        public AuditContext()
        {
        }

        public AuditContext(DbContextOptions<AuditContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountAud> AccountAuds { get; set; } = null!;
        public virtual DbSet<GroupDg> GroupDgs { get; set; } = null!;
        public virtual DbSet<GroupDgAud> GroupDgAuds { get; set; } = null!;
        public virtual DbSet<LoggedUserAud> LoggedUserAuds { get; set; } = null!;
        public virtual DbSet<RoleDg> RoleDgs { get; set; } = null!;
        public virtual DbSet<RoleDgAud> RoleDgAuds { get; set; } = null!;
        public virtual DbSet<UserDg> UserDgs { get; set; } = null!;
        public virtual DbSet<UserDgAud> UserDgAuds { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__account___BE3894F912DD22B1");

                entity.ToTable("account_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.AuthenticationDomain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("authentication_domain");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<GroupDg>(entity =>
            {
                entity.ToTable("group_dg", "DGMGMT");

                entity.HasIndex(e => e.Name, "UK_79kwwaf53vdtgfxwsemb2q3au")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<GroupDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__group_dg__BE3894F9084E2C5C");

                entity.ToTable("group_dg_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<LoggedUserAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__logged_u__BE3894F91A94C531");

                entity.ToTable("logged_user_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("app_name");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("device_name");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("device_type");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ip");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<RoleDg>(entity =>
            {
                entity.ToTable("role_dg", "DGMGMT");

                entity.HasIndex(e => e.Name, "UK_9dg6bnig1y6lu7h5njsigd013")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<RoleDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__role_dg___BE3894F923B2EE7A");

                entity.ToTable("role_dg_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<UserDg>(entity =>
            {
                entity.ToTable("user_dg", "DGMGMT");

                entity.HasIndex(e => e.Name, "UQ__user_dg__72E12F1B0D4D2B7D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock)
                    .HasColumnName("counter_lock")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<UserDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("PK__user_dg___BE3894F995453541");

                entity.ToTable("user_dg_aud", "DGMGMT_AUDIT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rev).HasColumnName("rev");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock).HasColumnName("counter_lock");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_date");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("data_update");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Revtype).HasColumnName("revtype");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
