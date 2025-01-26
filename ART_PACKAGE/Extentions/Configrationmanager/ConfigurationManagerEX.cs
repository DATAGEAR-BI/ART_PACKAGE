using ART_PACKAGE.Helpers.Jasypt;

namespace ART_PACKAGE.Extentions.Configrationmanager
{
    public static class ConfigurationManagerEX
    {
        
        public static string GetEncodedValue(this ConfigurationManager configuration, string key)
        {


            var encodedValue = configuration.GetValue<string>(key);
            var value = JasyptDecryptor.Decrypt(encodedValue);
            return value;
        }

        
    }
}
