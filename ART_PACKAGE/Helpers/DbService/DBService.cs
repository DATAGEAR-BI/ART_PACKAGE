using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Data.SASAml;
using Data.Data.TRADE_BASE;
using Data.DGAMLCORE;
using Data.DGAMLAC;
using Data.DGECM;
using Data.DGFATCA;
using Data.FCFCORE;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.TIZONE2;
using Data.DGCRP;
using Data.DGECMFilters;
using Data.DGAMLFilters;
using Data.DGAMLAdmin;

namespace ART_PACKAGE.Helpers.DBService
{
    public class DBService : IDbService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;

        public DBService(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
            List<string>? modules = _configuration.GetSection("Modules").Get<List<string>>();
            if (modules is not null)
            {



                if (modules.Contains("SASAML"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    FCFKC kc = scope.ServiceProvider.GetRequiredService<FCFKC>();
                    fcf71Context core = scope.ServiceProvider.GetRequiredService<fcf71Context>();
                    SasAmlContext sasAml = scope.ServiceProvider.GetRequiredService<SasAmlContext>();
                    SasAML = sasAml;
                    KC = kc;
                    CORE = core;
                }
                if (modules.Contains("DGAML"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    DGAMLCOREContext dgAmlCore = scope.ServiceProvider.GetRequiredService<DGAMLCOREContext>();
                    DGAMLCORE = dgAmlCore;
                    DGAMLACContext dgAmlAc = scope.ServiceProvider.GetRequiredService<DGAMLACContext>();
                    DGAMLAC = dgAmlAc;
                    DGAMLFiltersContext dgAmlFilters = scope.ServiceProvider.GetRequiredService<DGAMLFiltersContext>();
                    DGAMLFilters = dgAmlFilters;
                    DGAMLAdminContext dgAdmin = scope.ServiceProvider.GetRequiredService<DGAMLAdminContext>();
                    DGAMLAdmin = dgAdmin;

                }
                if (modules.Contains("GOAML"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    GoAmlContext goAml = scope.ServiceProvider.GetRequiredService<GoAmlContext>();
                    GOAML = goAml;
                }
                if (modules.Contains("ECM"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    DGECMContext ecmService = scope.ServiceProvider.GetRequiredService<DGECMContext>();
                    DGECMFiltersContext ecmFiltersService = scope.ServiceProvider.GetRequiredService<DGECMFiltersContext>();
                    ECM = ecmService;
                    DGECMFilters = ecmFiltersService;
                }
                if (modules.Contains("FATCA"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    DGFATCAContext fatcaService = scope.ServiceProvider.GetRequiredService<DGFATCAContext>();
                    FATCA = fatcaService;
                }
                if (modules.Contains("DGAUDIT"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    DGMGMTContext dgmgmt = scope.ServiceProvider.GetRequiredService<DGMGMTContext>();
                    DGMGMTAUDContext dgmgmtAud = scope.ServiceProvider.GetRequiredService<DGMGMTAUDContext>();
                    DGMGMT = dgmgmt;
                    DGMGMTAUD = dgmgmtAud;
                }
                if (modules.Contains("FTI"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    TIZONE2Context ti = scope.ServiceProvider.GetRequiredService<TIZONE2Context>();
                    TI = ti;
                }
                if (modules.Contains("TRADE_BASE"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    TRADE_BASEContext tb = scope.ServiceProvider.GetRequiredService<TRADE_BASEContext>();
                    TB = tb;
                }
                if (modules.Contains("CRP"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    DGCRPContext _DGCRP = scope.ServiceProvider.GetRequiredService<DGCRPContext>();
                    DGCRP = _DGCRP;
                }
            }
        }

        public FCFKC KC { get; }
        public fcf71Context CORE { get; }
        public DGECMContext ECM { get; }
        public DGFATCAContext FATCA { get; }

        public GoAmlContext GOAML { get; }

        public DGAMLCOREContext DGAMLCORE { get; }
        public DGAMLACContext DGAMLAC { get; }


        public TIZONE2Context TI { get; }
        public TRADE_BASEContext TB { get; }

        public DGMGMTContext DGMGMT { get; }

        public DGMGMTAUDContext DGMGMTAUD { get; }
        public SasAmlContext SasAML { get; }
        public DGCRPContext DGCRP { get; }

        public DGECMFiltersContext DGECMFilters { get; }
        public DGAMLFiltersContext DGAMLFilters { get; }
        public DGAMLAdminContext DGAMLAdmin { get; }

    }
}
