using System.Security.Cryptography.X509Certificates;

namespace ART_PACKAGE.Helpers.Handlers
{
    public class CertificateHttpClientHandler : HttpClientHandler
    {
        public CertificateHttpClientHandler(X509Certificate2 certificate)
        {
            ClientCertificates.Add(certificate);
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        }
    }
}