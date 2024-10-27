using System.ComponentModel.DataAnnotations.Schema;
using ART_PACKAGE.Areas.Identity.Data;
using Newtonsoft.Json;

namespace Data.Data;

public class UserReport
{
    public int ReportId { get; set; }
    public string UserId { get; set; }
    public string? SharedFromId { get; set; }
    public string? ShareMessage { get; set; }
    [NotMapped]
    public bool isOwner => UserId == SharedFromId;
   /* [JsonIgnore]
    public AppUser User { get; set; }*/
    [JsonIgnore]
    public ArtSavedCustomReport Report { get; set; }
}