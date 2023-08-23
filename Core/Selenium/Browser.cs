using Core.Configuration;
using OpenQA.Selenium;

namespace Core.Selenium;

public class Browser
{
    private static readonly ThreadLocal<Browser> BrowserInstances = new();
    public static Browser Instance => GetBrowser();

    public static string Url => Instance.Driver.Url;
    public IWebDriver Driver { get; }

    private static Browser GetBrowser()
    {
        return BrowserInstances.Value ?? (BrowserInstances.Value = new Browser(AppConfiguration.Browser.Type));
    }


    private Browser(string browserType)
    {
        Driver = new DriverFactory().GetDriver(browserType);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public void CloseBrowser()
    {
        Driver.Close();
        Driver.Quit();
    }

    public void NavigateToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void AcceptAlert()
    {
        Driver.SwitchTo().Alert().Accept();
    }

    public void AcceptDismiss()
    {
        Driver.SwitchTo().Alert().Dismiss();
    }

    public void SwitchToFrame(string id)
    {
        Driver.SwitchTo().Frame(id);
    }
}