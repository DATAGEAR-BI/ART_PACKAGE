using Data.Data;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ART_PACKAGE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public bool Active { get; set; }
    [JsonIgnore]
    public ICollection<ArtSavedCustomReport>? Reports { get; set; }
    [JsonIgnore]
    public ICollection<UserReport>? UserReports { get; set; }
    public int? DgUserId { get; set; } // Refer To Table Primary Key
    public string? DgUserName { get; set; } // Refer To User ID
    public DateTime? LastLoginDate { get; set; }

}

