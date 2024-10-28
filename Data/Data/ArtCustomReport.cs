using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Data.Data;

namespace ART_PACKAGE.Areas.Identity.Data;
public class ArtCustomReport
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DbSchema Schema { get; set; }
    public DateTime CreateDate { get; set; }
    public string Table { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string UserId { get; set; }
    public ICollection<ArtReportsColumns> Columns { get; set; }
    public ICollection<ArtReportsChart> Charts { get; set; }

    



}