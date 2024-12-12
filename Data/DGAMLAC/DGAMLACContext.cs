using System;
using System.Collections.Generic;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DGAMLAC
{
    public partial class DGAMLACContext : DbContext
    {
        public DGAMLACContext()
        {
        }

        public DGAMLACContext(DbContextOptions<DGAMLACContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcLkpTable> AcLkpTables { get; set; } = null!;
        public virtual DbSet<AcRoutine> AcRoutines { get; set; } = null!;
        public virtual DbSet<AcRoutineParameter> AcRoutineParameters { get; set; } = null!;
        public virtual DbSet<AcScenarioEvent> AcScenarioEvents { get; set; } = null!;
        public virtual DbSet<AcSuspectedObject> AcSuspectedObjects { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySQL("Server=192.168.1.182;Database=ac;User=root;Password=P@ssw0rd;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            OnModelCreatingPartial(modelBuilder);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDgAMLACModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
