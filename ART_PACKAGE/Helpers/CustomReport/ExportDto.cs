namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class ExportDto<T>
    {
        public T[] SelectedIdz { get; set; }
        public KendoRequest Req { get; set; }

        public bool All { get; set; }
    }
}
