namespace ART_PACKAGE.Helpers
{
    public static class AppSettingsResolver
    {
        private static IConfiguration _configuration;

        // Method to initialize the configuration
        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Static method to get the setting value
        public static dynamic GetSetting(string key)
        {
            return _configuration[key];
        }
        public static bool PDFButtonDefault()
        {
            Console.WriteLine
             ($@"{  _configuration.GetValue<bool>("PDF_Button_Apperence")}");
            return  _configuration.GetValue<bool>("PDF_Button_Apperence");
        }

    }
}
