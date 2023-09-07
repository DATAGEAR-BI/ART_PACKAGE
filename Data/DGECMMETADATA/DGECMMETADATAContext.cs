using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DGECMMETADATA
{
    public partial class DGECMMETADATAContext:DbContext
    {
        public DGECMMETADATAContext() { }
        public DGECMMETADATAContext(DbContextOptions<DGECMMETADATAContext> options) : base(options) { }
        public virtual DbSet<Comment> Comments { get; set; }=null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this.Database.IsSqlServer())
                ModelCreatingConfigurator.CommentSqlServerOnModelCreating(modelBuilder);

            if (this.Database.IsOracle())
                ModelCreatingConfigurator.CommentOracleOnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
