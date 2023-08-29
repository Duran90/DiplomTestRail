using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace Core.Selenium.Drivers;

public class Safari
{
    public static WebDriver Driver => NewDriver();
    
    private static WebDriver NewDriver()
    {
        return new SafariDriver();
    }
}