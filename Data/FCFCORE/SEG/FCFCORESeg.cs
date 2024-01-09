using System;
using System.Collections.Generic;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.FCFCORE.SEG
{
    public partial class FCFCORESeg : DbContext
    {
        public FCFCORESeg()
        {
        }

        public FCFCORESeg(DbContextOptions<FCFCORESeg> options)
            : base(options)
        {
        }

        public virtual DbSet<MebSegmentsV3> MebSegmentsV3s { get; set; } = null!;
        public virtual DbSet<MebSegmentsV3Bk> MebSegmentsV3Bks { get; set; } = null!;

         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFCFCORESegModelCreating(modelBuilder);

        }

      
    }
}
