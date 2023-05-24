
namespace ART_PACKAGE.Areas.Identity.Data;
public class ArtSavedCustomReport
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DbSchema Schema { get; set; }
    public DateTime CreateDate { get; set; }
    public string Table { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; }
    public ICollection<ArtSavedReportsColumns> Columns { get; set; }
    public ICollection<ArtSavedReportsChart> Charts { get; set; }
}

