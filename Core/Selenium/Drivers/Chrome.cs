using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.Selenium.Drivers;

public class Chrome
{

    public static WebDriver Driver => NewDriver();
    
    private static WebDriver NewDriver()
    {
        var options = new ChromeOptions();
        if (AppConfiguration.Browser.Headless) options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");
        options.AddArgument("incognito");
        options.AddArgument("--start-maximized");
        return new ChromeDriver(options);
    }
}