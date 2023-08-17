using System.Text.Json.Serialization;

namespace ART_PACKAGE.Areas.Identity.Data;


public class ArtSavedReportsColumns
{
    public string Column { get; set; } = null!;
    public string JsType { get; set; } = null!;
    public bool IsNullable { get; set; }
    public int ReportId { get; set; }
    [JsonIgnore]
    public ArtSavedCustomReport Report { get; set; } = null!;

}

