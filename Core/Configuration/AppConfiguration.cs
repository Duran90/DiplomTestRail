namespace Core.Configuration;

using Microsoft.Extensions.Configuration;

public class AppConfiguration
{
    public static BrowserConfiguration Browser => BindConfiguration<BrowserConfiguration>();
    public static ApiConfiguration API => BindConfiguration<ApiConfiguration>();
    private static readonly IConfigurationRoot ConfigurationRoot;

    static AppConfiguration()
    {
        ConfigurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }

    private static T BindConfiguration<T>() where T : IConfiguration, new()
    {
        var config = new T();
        ConfigurationRoot.GetSection(config.SectionName).Bind(config);
        return config;
    }

    public static string? GetValue(string key)
    {
        return ConfigurationRoot[key];
    }
}