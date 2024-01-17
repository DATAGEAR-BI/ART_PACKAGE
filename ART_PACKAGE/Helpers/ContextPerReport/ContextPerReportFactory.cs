using ART_PACKAGE.Helpers.License;
using Data.Constants.AppModules;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.ExportSchedular;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.ContextPerReport
{
    public class ContextPerReportFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly List<string>? modules;
        public ContextPerReportFactory(IServiceScopeFactory serviceScopeFactory, IConfiguration config)
        {
            _serviceScopeFactory = serviceScopeFactory;
            modules = config.GetSection("Modules").Get<List<string>>();
        }

        public DbContext GetContextOf(string reportName)
        {
            IServiceProvider serviceProvider = _serviceScopeFactory.CreateScope().ServiceProvider;
            string module = ReportPerModule.GetModule(reportName);
            bool isModuleExist = modules is not null && modules.Contains(module);
            if (isModuleExist && module == AppModules.SASAML)
                return serviceProvider.GetRequiredService<SasAmlContext>();
            else if (isModuleExist && module == AppModules.ECM)
                return serviceProvider.GetRequiredService<EcmContext>();
            else if (isModuleExist && module == AppModules.DGAML)
                return serviceProvider.GetRequiredService<ArtDgAmlContext>();
            else if (isModuleExist && module == AppModules.DGAUDIT)
                return serviceProvider.GetRequiredService<ArtAuditContext>();
            else if (isModuleExist && module == AppModules.EXPORT_SCHEDULAR)
                return serviceProvider.GetRequiredService<ExportSchedularContext>();
            else if (isModuleExist && module == AppModules.SEG)
                return serviceProvider.GetRequiredService<SegmentationContext>();
            else if (isModuleExist && module == AppModules.FTI)
                return serviceProvider.GetRequiredService<FTIContext>();
            else if (isModuleExist && module == AppModules.AMLANALYSIS)
                return serviceProvider.GetRequiredService<AmlAnalysisContext>();
            else if (isModuleExist && module == AppModules.KYC)
                return serviceProvider.GetRequiredService<KYCContext>();
            else if (isModuleExist && module == AppModules.GOAML)
                return serviceProvider.GetRequiredService<ArtGoAmlContext>();
            else
                return serviceProvider.GetRequiredService<AuthContext>();


        }
    }
}
