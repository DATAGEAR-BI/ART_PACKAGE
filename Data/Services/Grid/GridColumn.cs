﻿namespace Data.Services.Grid
{
    public class GridColumn
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public string CollectionPropertyName { get; set; }
        public bool isDropDown { get; set; }
        public bool isCollection { get; set; }
        public bool isNullable { get; set; }

        public string format { get; set; }
        public IEnumerable<SelectItem> menu { get; set; }
        public string AggType { get; set; }
        public string AggTitle { get; set; }

        public string? template { get; set; }
    }
}
