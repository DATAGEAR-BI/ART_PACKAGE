using Data.Audit;
using Data.DGAML;
using Data.DGECM;
using Data.GOAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FCF71
{
    public interface IDbService
    {
        public FCFKC.FCFKC KC { get; }
        public FCFCORE.fcf71Context CORE { get; }
        public DGECMContext ECM { get; }
        public GoAmlContext GOAML { get; }
        public AuditContext AUDIT { get; }
        public DGAMLContext DGAML { get; }
    }
}
