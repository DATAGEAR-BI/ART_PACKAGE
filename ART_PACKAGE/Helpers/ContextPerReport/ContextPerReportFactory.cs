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

namespace ART_PACKAGE.Helpers.ContextPerReport
{
    public class ContextPerReportFactory
    {

        private readonly List<string>? modules;
        public ContextPerReportFactory(IConfiguration config)
        {
            modules = config.GetSection("Modules").Get<List<string>>();
        }

        public Type GetContextOf(string reportName)
        {

            string module = ReportPerModule.GetModule(reportName);
            bool isModuleExist = modules is not null && modules.Contains(module);
            if (isModuleExist && module == AppModules.SASAML)
                return typeof(SasAmlContext);
            else if (isModuleExist && module == AppModules.ECM)
                return typeof(EcmContext);
            else if (isModuleExist && module == AppModules.DGAML)
                return typeof(ArtDgAmlContext);
            else if (isModuleExist && module == AppModules.DGAUDIT)
                return typeof(ArtAuditContext);
            else if (isModuleExist && module == AppModules.EXPORT_SCHEDULAR)
                return typeof(ExportSchedularContext);
            else if (isModuleExist && module == AppModules.SEG)
                return typeof(SegmentationContext);
            else if (isModuleExist && module == AppModules.FTI)
                return typeof(FTIContext);
            else if (isModuleExist && module == AppModules.AMLANALYSIS)
                return typeof(AmlAnalysisContext);
            else if (isModuleExist && module == AppModules.KYC)
                return typeof(KYCContext);
            else if (isModuleExist && module == AppModules.GOAML)
                return typeof(ArtGoAmlContext);
            else
                return typeof(AuthContext);


        }
    }
}
