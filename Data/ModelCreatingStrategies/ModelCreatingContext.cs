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
    }
}
