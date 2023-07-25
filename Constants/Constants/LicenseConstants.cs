using ART_PACKAGE.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
    public static class LicenseConstants
    {
        public const string PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnnl3z/woHb4RMgx1+QI6RXFJ/A4gY8y6qWkgdv1nApll1D5+zSCy6DChc+3nKUSq6tisppXEOVvw/d6lyrHKphHg6eyOdpgHYK7sDVVLaKKnFabxdkrUj28iPXBio1f+QvCy7Da3PFStZJnF3uNp0W8F7GySj3kqKFwkZPqkTunvT9yHcZpzMJOoYuiFkdChbJ5QzXbtFLzXXbYVcyFZVnIMy4jgXPSrZsyf5+ptgEhpkPZ1geGsVEF9Qe4mp5g+/go0dzLmL7Bx+NEn1o4NvL7tN4cGzmbU5ni7nx+i817pUoh+66RQmYXCPAtzpHI611M4Il9WC5ZNalHOOBbpGwIDAQAB";
        public const string LICENSE_POLICY = "License";
        public static readonly List<string> SASAMLControllers = new List<string>() { nameof(AlertDetailsController) };

        //public static string GetModule(string controllerName)
        //{

        //}
    }
}
