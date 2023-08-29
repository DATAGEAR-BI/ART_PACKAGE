using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public interface IModelCreatingStrategy
    {
        public void OnModelCreating(ModelBuilder modelBuilder);
        public void OnSegmentionModelCreating(ModelBuilder modelBuilder);
        public void OnARTGOAMLModelCreating(ModelBuilder modelBuilder);
        void OnARTDGAMLModelCreating(ModelBuilder modelBuilder);
        void OnEcmModelCreating(ModelBuilder modelBuilder);
        void OnSasAmlModelCreating(ModelBuilder modelBuilder);
        void OnAuditModelCreating(ModelBuilder modelBuilder);
        void OnAmlAnalysisModelCreating(ModelBuilder modelBuilder);
        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder);
        public void OnFcfkcECMModelCreating(ModelBuilder modelBuilder);
    }
}
