using Core.Selenium.Drivers;
using OpenQA.Selenium;

namespace Core.Selenium;

public class DriverFactory : IDriverFactory
{
    public WebDriver GetDriver(string browser)
    {
        return browser.ToLower() switch
        {
            "chrome" => Chrome.Driver,
            "firefox" => FireFox.Driver,
            "edge" => Edge.Driver,
            "safari" => Safari.Driver,
            _ => throw new Exception("driver not supported")
        };
    }
}