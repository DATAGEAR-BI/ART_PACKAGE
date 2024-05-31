using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGSASAUDIT
{
    public class DGSASAUDITContext : DbContext
    {


        public DGSASAUDITContext()
        {
        }

        public DGSASAUDITContext(DbContextOptions<DGSASAUDITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VaAuthdomain> VaAuthdomains { get; set; } = null!;
        public virtual DbSet<VaEmail> VaEmails { get; set; } = null!;
        public virtual DbSet<VaEmailInfo> VaEmailInfos { get; set; } = null!;
        public virtual DbSet<VaGroupInfo> VaGroupInfos { get; set; } = null!;
        public virtual DbSet<VaGrouploginsInfo> VaGrouploginsInfos { get; set; } = null!;
        public virtual DbSet<VaGroupmemgroupsInfo> VaGroupmemgroupsInfos { get; set; } = null!;
        public virtual DbSet<VaGroupmempersonsInfo> VaGroupmempersonsInfos { get; set; } = null!;
        public virtual DbSet<VaGrpmem> VaGrpmems { get; set; } = null!;
        public virtual DbSet<VaIdgrp> VaIdgrps { get; set; } = null!;
        public virtual DbSet<VaLicensed> VaLicenseds { get; set; } = null!;
        public virtual DbSet<VaLocation> VaLocations { get; set; } = null!;
        public virtual DbSet<VaLocationInfo> VaLocationInfos { get; set; } = null!;
        public virtual DbSet<VaLogin> VaLogins { get; set; } = null!;
        public virtual DbSet<VaLoginsInfo> VaLoginsInfos { get; set; } = null!;
        public virtual DbSet<VaPerson> VaPeople { get; set; } = null!;
        public virtual DbSet<VaPersonInfo> VaPersonInfos { get; set; } = null!;
        public virtual DbSet<VaPhone> VaPhones { get; set; } = null!;
        public virtual DbSet<VaPhoneInfo> VaPhoneInfos { get; set; } = null!;
        public virtual DbSet<VaUserCapability> VaUserCapabilities { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.45; Database=ART_DB; User Id=sa; Password=P@ssw0rd; Encrypt=False; MultipleActiveResultSets=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGSasAuditModelCreating(modelBuilder);
        }
    }
}
