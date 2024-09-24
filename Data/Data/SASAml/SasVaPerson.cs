using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public partial class SasVaPerson
    {
        public string Keyid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Displayname { get; set; }
        public string Objid { get; set; }
        public int? Externalkey { get; set; }
    }
}
