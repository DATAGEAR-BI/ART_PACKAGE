using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public interface ISchemaModelCreatingStrategy
    {
        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder);
        public void OnFcfkcSASAMLModelCreating(ModelBuilder modelBuilder);

        public void OnDGECMModelCreating(ModelBuilder modelBuilder);

        public void OnDGMGMGModelCreating(ModelBuilder modelBuilder);
        public void OnDGMGMGMAUDodelCreating(ModelBuilder modelBuilder);
        public void OnDgAMLModelCreating(ModelBuilder modelBuilder);
        public void OnFCFCOREModelCreating(ModelBuilder modelBuilder);
        public void OnGoAmlModelCreating(ModelBuilder modelBuilder);
        public void OnTiZoneModelCreating(ModelBuilder modelBuilder);


    }
}
