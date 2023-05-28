using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleMigrations
{
    public  class ProjType
    {
        public static string GetType()
        {
           IConfiguration _config;
             var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
            var Type = _config["HomeType"].ToUpper();
            return Type;
            
        }
        public static readonly string AML = "AML";
        public static readonly string SANCTION = "SANCTION";
        public static readonly string AML_AND_SANCTION = "AML&SANCTION";
    }
}
