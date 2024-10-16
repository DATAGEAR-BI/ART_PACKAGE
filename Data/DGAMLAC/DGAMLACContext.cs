using System;
using System.Collections.Generic;
using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DGAMLAC
{
    public partial class DGAMLACContext : TenatDBContext
    {


        public DGAMLACContext(DbContextOptions<DGAMLACContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        public virtual DbSet<AcLkpTable> AcLkpTables { get; set; } = null!;
        public virtual DbSet<AcRoutine> AcRoutines { get; set; } = null!;
        public virtual DbSet<AcRoutineParameter> AcRoutineParameters { get; set; } = null!;
        public virtual DbSet<AcScenarioEvent> AcScenarioEvents { get; set; } = null!;
        public virtual DbSet<AcSuspectedObject> AcSuspectedObjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "DGAMLACContextConnection");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            OnModelCreatingPartial(modelBuilder);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDgAMLACModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
