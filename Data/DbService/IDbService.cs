using Data.DGECM;
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
        public FCFCORE CORE { get; }
        public DGECMContext ECM { get; }
    }
}
