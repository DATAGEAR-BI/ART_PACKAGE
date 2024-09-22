using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public class ModelCreatingContext : IBaseModelCreatingStrategy
    {
        private readonly IBaseModelCreatingStrategy _strategy;


        public ModelCreatingContext(IBaseModelCreatingStrategy strategy)
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
        public void OnTRADE_BASEModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnTRADE_BASEModelCreating(modelBuilder);
        }
        public void OnFATCAModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnFATCAModelCreating(modelBuilder);
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

        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnFcfkcAmlAnalysisModelCreating(modelBuilder);
        }

        public void OnFcfkcSASAMLModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnFcfkcSASAMLModelCreating(modelBuilder);
        }

        public void OnFTIModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnFTIModelCreating(modelBuilder);
        }

        public void OnKYCModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnKYCModelCreating(modelBuilder);
        }

        public void OnDGECMModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDGECMModelCreating(modelBuilder);
        }
        public void OnDGFATCAModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDGFATCAModelCreating(modelBuilder);
        }



        public void OnDgAMLCOREModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDgAMLCOREModelCreating(modelBuilder);
        }
        public void OnDgAMLACModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDgAMLACModelCreating(modelBuilder);
        }

        public void OnFCFCOREModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnFCFCOREModelCreating(modelBuilder);
        }

        public void OnGoAmlModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnGoAmlModelCreating(modelBuilder);
        }

        public void OnTiZoneModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnTiZoneModelCreating(modelBuilder);
        }

        public void OnDGMGMGModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDGMGMGModelCreating(modelBuilder);
        }

        public void OnDGMGMGMAUDodelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDGMGMGMAUDodelCreating(modelBuilder);
        }

        public void OnCRPModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnCRPModelCreating(modelBuilder);
        }
        public void OnSasAuditModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnSasAuditModelCreating(modelBuilder);
        }

        public void OnDGWLLOGSModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnDGWLLOGSModelCreating(modelBuilder);
        }
    }
}
