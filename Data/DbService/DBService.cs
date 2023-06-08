using Data.DGECM;
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
        private readonly FCFCORE _core;
        private readonly DGECMContext _ecm;

        public DBService(FCFKC.FCFKC kc, FCFCORE core, DGECMContext ecm)
        {
            _kc = kc;
            _core = core;
            _ecm = ecm;
        }

        public FCFKC.FCFKC KC => _kc;
        public FCFCORE CORE => _core;
        public DGECMContext ECM => _ecm;
    }
}
