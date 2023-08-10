namespace Core.Configuration;

public class BrowserConfiguration : IConfiguration
{
    public string SectionName => "Browser";

    public bool Headless { get; set; }
    public string Type { get; set; }
    public int TimeOut { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string BaseUrl { get; set; }
}