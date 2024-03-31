namespace ART_PACKAGE.Helpers
{
    public class Module
    {
        private List<string>? modules = new List<string>();
        private readonly IConfiguration _configuration;

        public Module(IConfiguration configuration)
        {
            _configuration = configuration;
            modules = _configuration.GetSection("Modules").Get<List<string>>();
        }
        public bool HasModule(string Name) => (modules is not null && modules.Contains(Name)) ? true : false;



    }
}
