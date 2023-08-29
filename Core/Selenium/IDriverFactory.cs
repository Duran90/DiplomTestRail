using OpenQA.Selenium;

namespace Core.Selenium;

public interface IDriverFactory
{
    public WebDriver GetDriver(string browser);
}