using Data.Audit;
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
        public TIZONE2Context TI { get; }
        public FCFKC KC { get; }
        public fcf71Context CORE { get; }
        public DGECMContext ECM { get; }
        public GoAmlContext GOAML { get; }
        public AuditContext AUDIT { get; }

        public DGAMLContext DGAML { get; }
    }
}