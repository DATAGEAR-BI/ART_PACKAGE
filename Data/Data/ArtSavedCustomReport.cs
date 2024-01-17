
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Data.Data;

namespace ART_PACKAGE.Areas.Identity.Data;
public class ArtSavedCustomReport
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DbSchema Schema { get; set; }
    public DateTime CreateDate { get; set; }
    public string Table { get; set; } = null!;
    public string Type { get; set; } = null!;
    public bool IsShared { get; set; }
    [JsonIgnore]
    public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    public ICollection<ArtSavedReportsColumns> Columns { get; set; }
    public ICollection<ArtSavedReportsChart> Charts { get; set; }

    [NotMapped]
    public string SharedFrom
    {
        get
        {
            var owner = UserReports.FirstOrDefault(u => u.ReportId == Id && u.isOwner);
           
            return owner.User.Email;
        }
    }
    [NotMapped] public string ShareMessage => UserReports.FirstOrDefault(u => u.ReportId == Id && !u.isOwner)?.ShareMessage;

    [JsonIgnore] public ICollection<UserReport>? UserReports { get; set; } = new List<UserReport>();


}

