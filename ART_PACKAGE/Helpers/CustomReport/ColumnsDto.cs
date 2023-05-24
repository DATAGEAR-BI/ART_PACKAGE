using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{

    public class ColumnsDto
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public string CollectionPropertyName { get; set; }
        public bool isDropDown { get; set; }
        public bool isCollection { get; set; }
        public bool isNullable { get; set; }

        public string format { get; set; }
        public List<dynamic> menu { get; set; }
    }

}
