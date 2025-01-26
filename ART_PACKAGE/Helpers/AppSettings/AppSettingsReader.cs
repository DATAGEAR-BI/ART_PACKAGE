using ART_PACKAGE.Helpers.Jasypt;

namespace ART_PACKAGE.Helpers.AppSettings
{
    public class AppSettingsReader : IAppSettingsReader
    {
        private readonly IConfiguration _configuration;

        public AppSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public string GetEncodedValue(string key)
        {


            var encodedValue = _configuration.GetValue<string>(key);
            var  value= JasyptDecryptor.Decrypt(encodedValue);
            return value;
        }

        public T GetValue<T>(string key)
        {

            
            var value = _configuration.GetValue<T>(key);
            return value;
        }
    }
}
