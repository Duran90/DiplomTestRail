using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.Selenium.Drivers;

internal class FireFox
{
    
    public static WebDriver Driver => NewDriver();
    
    private static WebDriver NewDriver()
    {
        var options = new FirefoxOptions();
        options.AddArgument("--headless");
        return new FirefoxDriver(options);
    }
}