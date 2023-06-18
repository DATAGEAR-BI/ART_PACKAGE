using Data.DGECM;
using Data.GOAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FCF71
{
    public class DBService : IDbService
    {
        private readonly FCFKC.FCFKC _kc;
        private readonly FCFCORE.fcf71Context _core;
        private readonly DGECMContext _ecm;
        private readonly GoAmlContext _goAml;

        public DBService(FCFKC.FCFKC kc, FCFCORE.fcf71Context core, DGECMContext ecm, GoAmlContext goAml)
        {
            _kc = kc;
            _core = core;
            _ecm = ecm;
            _goAml = goAml;
        }

        public FCFKC.FCFKC KC => _kc;
        public FCFCORE.fcf71Context CORE => _core;
        public DGECMContext ECM => _ecm;

        public GoAmlContext GOAML => _goAml;
    }
}
