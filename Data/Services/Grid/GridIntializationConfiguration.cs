namespace Data.Services.Grid
{
    public class GridIntializationConfiguration
    {
        public List<GridColumn>? columns { get; set; }
        public bool containsActions { get; set; }
        public bool selectable { get; set; }
        public List<GridButton>? actions { get; set; }
        public List<GridButton>? toolbar { get; set; }

        public bool showCsvBtn { get; set; } = true;
        public bool showPdfBtn { get; set; } = true;
        public bool hasFixedWidth { get; set; } = false;
    }
}
