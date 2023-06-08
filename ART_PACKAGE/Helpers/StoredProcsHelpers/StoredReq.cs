using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace ART_PACKAGE.Helpers.StoredProcsHelpers
{
    public class StoredReq
    {
        public KendoRequest req { get; set; }
        public List<Filters> procFilters { get; set; }

        public string GetCacheKey()
        {
            var sb = new StringBuilder();
            this.procFilters.ForEach(x =>
            {
                sb.Append((string)x.value);
            });
            return sb.ToString();
        }
    }

}
