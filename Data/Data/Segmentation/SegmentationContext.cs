using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Segmentation
{
    public class SegmentationContext : DbContext
    {
        public SegmentationContext(DbContextOptions<SegmentationContext> options)
      : base(options)
        {
        }
        // SEGMENTATION
        public virtual DbSet<ArtAlertsPerSegmentTb> ArtAlertsPerSegmentTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegmentCustCountTb> ArtAllSegmentCustCountTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegmentsOutliersTb> ArtAllSegmentsOutliersTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegsFeatrsStatcsTb> ArtAllSegsFeatrsStatcsTbs { get; set; } = null!;
        public virtual DbSet<ArtAllSegsOutliersLimitTb> ArtAllSegsOutliersLimitTbs { get; set; } = null!;
        public virtual DbSet<ArtChangedSegmentTb> ArtChangedSegmentTbs { get; set; } = null!;
        public virtual DbSet<ArtIndustrySegmentTb> ArtIndustrySegmentTbs { get; set; } = null!;
        public virtual DbSet<ArtMebSegmentsV3Tb> ArtMebSegmentsV3Tbs { get; set; } = null!;
        public virtual DbSet<ArtSegoutvsallcustTb> ArtSegoutvsallcustTbs { get; set; } = null!;
        public virtual DbSet<ArtSegoutvsalloutTb> ArtSegoutvsalloutTbs { get; set; } = null!;
        public virtual DbSet<ArtCustsPerTypeTb> ArtCustsPerTypeTbs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSegmentionModelCreating(modelBuilder);
        }
    }


}
