using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BusinessObject.UI.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly Logger Logger;
    protected Actions Actions;

    public abstract string Url { get; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Logger = LogManager.GetCurrentClassLogger();
        Actions = new Actions(driver: driver);
    }

    public virtual BasePage Open()
    {
        Logger.Info($"Open page - {Url}");
        Driver.Navigate().GoToUrl(Url);
        return this;
    }

    public virtual BasePage Refresh()
    {
        Logger.Info($"Refresh page - {Url}");
        Driver.Navigate().Refresh();
        return this;
    }
    
}