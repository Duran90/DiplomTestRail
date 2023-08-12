namespace Core.Configuration;

public class ApiConfiguration : IConfiguration
{
    public string SectionName => "API";

    public string BaseUrl { get; set; }

    public string ApiKey { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}