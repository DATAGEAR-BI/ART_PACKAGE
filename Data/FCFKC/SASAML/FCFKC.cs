﻿using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.FCFKC.SASAML
{
    public class FCFKC : DbContext
    {
        public FCFKC(DbContextOptions<FCFKC> opts) : base(opts)
        {

        }
        public virtual DbSet<FskLov> FskLovs { get; set; } = null!;
        public virtual DbSet<FskRiskAssessment> FskRiskAssessments { get; set; } = null!;
        public virtual DbSet<FskScenario> FskScenarios { get; set; } = null!;
        public virtual DbSet<FskCase> FskCases { get; set; } = null!;
        public virtual DbSet<FskQueue> FskQueues { get; set; } = null!;
        public virtual DbSet<Fsk_EntityQueue> FskEntityQueues { get; set; } = null!;




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFcfkcSASAMLModelCreating(modelBuilder);
        }
    }
}
