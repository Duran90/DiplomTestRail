using Newtonsoft.Json;

namespace BusinessObject.Models;

public class ProjectModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonProperty("show_announcement")]
    public bool ShowAnnouncement { get; set; }
    [JsonProperty("is_completed")]
    public bool IsCompleted { get; set; }
    [JsonProperty("suite_mode")]
    public int SuiteMode { get; set; }
    public string Url { get; set; }
    public string Announcement { get; set; }
}