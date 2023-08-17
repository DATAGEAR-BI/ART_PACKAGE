
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ART_PACKAGE.Areas.Identity.Data;
public class ArtSavedReportsChart
{
    [NotMapped]
    public string ChartInfo
    {
        get
        {
            return this.Column + " - " + this.Type.ToString();
        }
    }
    public ChartType Type { get; set; }
    public string Column { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int ReportId { get; set; }

    [JsonIgnore]
    public ArtSavedCustomReport Report { get; set; } = null!;


}

