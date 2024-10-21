using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Data.ECM;
using Data.DGAML;
using Data.DGECM;
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

        public DGAMLContext DGAML { get; }
        public TIZONE2Context TI { get; }
        public EcmContext EcmDb { get; }
    }
}
