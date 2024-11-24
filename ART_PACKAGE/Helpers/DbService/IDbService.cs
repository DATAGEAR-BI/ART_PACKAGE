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
using Data.Data.ECM;
using Data.DGCFTWL;
using Data.DGCRP;

namespace ART_PACKAGE.Helpers.DBService
{
    public interface IDbService
    {

        public FCFKC KC { get; }
        public fcf71Context CORE { get; }
        public DGECMContext ECM { get; }
        public EcmContext ARTECM { get; }
        public DGCFTWLContext DGCFTWL { get; }
        public GoAmlContext GOAML { get; }
        public DGMGMTContext DGMGMT { get; }
        public DGMGMTAUDContext DGMGMTAUD { get; }
        public DGFATCAContext FATCA { get; }

        public DGAMLCOREContext DGAMLCORE { get; }
        public DGAMLACContext DGAMLAC { get; }
        public TIZONE2Context TI { get; }
        public TRADE_BASEContext TB { get; }
        public SasAmlContext SasAML { get; }

        public DGCRPContext DGCRP { get; }

    }
}
