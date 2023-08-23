using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public class ModelCreatingContext : IModelCreatingStrategy
    {
        private readonly IModelCreatingStrategy _strategy;

        public ModelCreatingContext(IModelCreatingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnModelCreating(modelBuilder);
        }
        public void OnSegmentionModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnSegmentionModelCreating(modelBuilder);
        }

        public void OnARTGOAMLModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnARTGOAMLModelCreating(modelBuilder);
        }

        public void OnARTDGAMLModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnARTDGAMLModelCreating(modelBuilder);
        }

        public void OnEcmModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnEcmModelCreating(modelBuilder);
        }

        public void OnSasAmlModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnSasAmlModelCreating(modelBuilder);
        }

        public void OnAuditModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnAuditModelCreating(modelBuilder);

        }

        public void OnAmlAnalysisModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnAmlAnalysisModelCreating(modelBuilder);

        }
    }
}
