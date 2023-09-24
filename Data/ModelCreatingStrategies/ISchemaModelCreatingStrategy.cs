using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public interface ISchemaModelCreatingStrategy
    {
        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder);
        public void OnFcfkcSASAMLModelCreating(ModelBuilder modelBuilder);

        public void OnDGECMModelCreating(ModelBuilder modelBuilder);
    }
}
