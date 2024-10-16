using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Tenat
{
    public class TenantConstants
    {
        private string _tenantID { get; set; }
        public void SetID(string tenantID)
        {
            _tenantID = tenantID;
        }
        public string GetID()
        {
            return _tenantID;
        }

    }
}
