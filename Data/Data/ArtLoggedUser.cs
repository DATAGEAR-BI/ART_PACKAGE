using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtLoggedUser
    {
        public int ID { get; set; } 
        public string? UserName { get; set; }
        public DateTime? LoginDate { get; set; }
        public string? LoginStatus { get; set; }
    }
}
