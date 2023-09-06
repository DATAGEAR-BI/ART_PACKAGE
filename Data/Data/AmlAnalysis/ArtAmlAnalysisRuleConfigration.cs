using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.AmlAnalysis
{
    public class ArtAmlAnalysisRuleConfigration : IEntityTypeConfiguration<ArtAmlAnalysisRule>
    {
        private readonly string _dbType;
        public ArtAmlAnalysisRuleConfigration(string dbType)
        {
            _dbType = dbType;
        }
        public void Configure(EntityTypeBuilder<ArtAmlAnalysisRule> builder)
        {
            string getDateMethod = _dbType == "sqlserver" ? "GetDate()" : _dbType == "oracle" ? "CURRENT_DATE" : "";
            builder.Property(x => x.Action).HasMaxLength(20);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql(getDateMethod);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Deleted).HasDefaultValue(false);
        }
    }
}
