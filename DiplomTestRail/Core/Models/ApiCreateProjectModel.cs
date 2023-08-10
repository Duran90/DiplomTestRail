using Newtonsoft.Json;

namespace DiplomTestRail.Core.Models;

public class ApiCreateProjectModel
{
    public string Name { get; set; }
    public string Announcement { get; set; }
    [JsonProperty("show_announcement")]
    public bool ShowAnnouncement { get; set; }
}