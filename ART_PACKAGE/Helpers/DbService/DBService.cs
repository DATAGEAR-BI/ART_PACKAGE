using Data.Audit;
using Data.DGAML;
using Data.DGECM;
using Data.FCFCORE;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.TIZONE2;

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
            if (modules.Contains("SASAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                FCFKC kc = scope.ServiceProvider.GetRequiredService<FCFKC>();
                fcf71Context core = scope.ServiceProvider.GetRequiredService<fcf71Context>();
                KC = kc;
                CORE = core;
            }
            if (modules.Contains("DGAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                DGAMLContext dgAml = scope.ServiceProvider.GetRequiredService<DGAMLContext>();
                DGAML = dgAml;
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
                ECM = ecmService;
            }
            if (modules.Contains("DGAUDIT"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                AuditContext audit = scope.ServiceProvider.GetRequiredService<AuditContext>();
                AUDIT = audit;
            }
            if (modules.Contains("FTI"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                TIZONE2Context ti = scope.ServiceProvider.GetRequiredService<TIZONE2Context>();
                TI = ti;
            }
        }

        public FCFKC KC { get; }
        public fcf71Context CORE { get; }
        public DGECMContext ECM { get; }

        public GoAmlContext GOAML { get; }

        public AuditContext AUDIT { get; }
        public DGAMLContext DGAML { get; }

        public TIZONE2Context TI { get; }
    }
}
