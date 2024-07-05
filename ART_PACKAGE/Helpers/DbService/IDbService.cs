using Data.AC;
using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Data.ARTAUDIT;
using Data.Data.DGINTFRAUD;
using Data.Data.SASAml;
using Data.Data.TRADE_BASE;
using Data.DGAML;
using Data.DGAMLCORE;
using Data.DGECM;
using Data.DGFATCA;
using Data.FCFCORE;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.TIZONE2;

namespace ART_PACKAGE.Helpers.DBService
{
    public interface IDbService
    {

        public FCFKC KC { get; }
        public fcf71Context CORE { get; }
        public DGECMContext ECM { get; }
        public GoAmlContext GOAML { get; }
        public DGMGMTContext DGMGMT { get; }
        public DGMGMTAUDContext DGMGMTAUD { get; }
        public DGFATCAContext FATCA { get; }

        public DGAMLCOREContext DGAMLCORE { get; }
        public DGAMLContext DGAML { get; }
        public ACContext AC { get; }
        public TIZONE2Context TI { get; }
        public TRADE_BASEContext TB { get; }
        public SasAmlContext SasAML { get; }
        public ARTAUDITContext ArtAudit { get; }
        public DGINTFRAUDContext ArtContext { get; }

    }
}
