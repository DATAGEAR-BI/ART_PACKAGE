using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public interface ISchemaModelCreatingStrategy
    {
        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder);
        public void OnFcfkcSASAMLModelCreating(ModelBuilder modelBuilder);

        public void OnDGECMModelCreating(ModelBuilder modelBuilder);
        public void OnDGCFTWLModelCreating(ModelBuilder modelBuilder);
        public void OnDGFATCAModelCreating(ModelBuilder modelBuilder);

        public void OnDGMGMGModelCreating(ModelBuilder modelBuilder);
        public void OnDGMGMGMAUDodelCreating(ModelBuilder modelBuilder);
        public void OnDgAMLCOREModelCreating(ModelBuilder modelBuilder);
        public void OnDgAMLACModelCreating(ModelBuilder modelBuilder);
        public void OnFCFCOREModelCreating(ModelBuilder modelBuilder);
        public void OnGoAmlModelCreating(ModelBuilder modelBuilder);
        public void OnTiZoneModelCreating(ModelBuilder modelBuilder);


    }
}
