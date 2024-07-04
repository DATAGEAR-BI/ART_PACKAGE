using System.Security.Cryptography.X509Certificates;

namespace ART_PACKAGE.Services
{
    public static class Certificate
    {
        public static X509Certificate2 LoadCertificate(string path, string password)
        {
            return new X509Certificate2(path, password);
        }
    }
}
