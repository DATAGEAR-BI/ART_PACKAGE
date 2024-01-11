using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using Data.Data;

namespace ART_PACKAGE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public bool Active { get; set; }
    [JsonIgnore]
    public ICollection<ArtSavedCustomReport>? Reports { get; set; }
    [JsonIgnore]
    public ICollection<UserReport>? UserReports { get; set; }
    
}

