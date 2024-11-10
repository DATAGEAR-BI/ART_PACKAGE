using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace ART_PACKAGE.Areas.Identity.Data;


public class ArtReportsColumns
{
    public string Column { get; set; } = null!;
    public string JsType { get; set; } = null!;
    public bool IsNullable { get; set; }
    public int ReportId { get; set; }
    public string? DisplayName { get; set; } 
    public string? DropDownView { get; set; }
    public string? DropDownText { get; set; }
    public string? DropDownValue { get; set; }
    [JsonIgnore]
    public ArtCustomReport Report { get; set; } = null!;

}

