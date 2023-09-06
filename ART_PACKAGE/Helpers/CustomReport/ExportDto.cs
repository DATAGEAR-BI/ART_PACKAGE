namespace ART_PACKAGE.Helpers.CustomReport
{
    public class ExportDto<T>
    {
        public List<T> SelectedIdz { get; set; }
        public KendoRequest Req { get; set; }

        public bool All { get; set; }
    }
}
