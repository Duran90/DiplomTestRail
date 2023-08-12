using BusinessObject.UI.Pages;
using Core.Selenium;
using Core.Selenium.Components;
using OpenQA.Selenium;

namespace BusinessObject.UI.Components;

public class HeaderComponent : BaseComponent
{
    private readonly By _testCasePage = By.CssSelector("#header>ul>li:nth-child(6)");
    private readonly By _backToMainPage = By.Id("navigation-dashboard-top");
    private readonly By _overviewPage = By.Id("navigation-projects");

    public HeaderComponent(IWebDriver driver) : base(driver.FindElement(By.Id("header")), driver)
    {
    }

    public MainPage OpenDashboard()
    {
        Element.FindElement(_backToMainPage).Click();
        var page = new MainPage(WebDriver);
        WaitingHelper.WaitUntilUrlToBe(WebDriver, page.Url);
        return page;
    }

    public TestCasesPage OpenTestCasesPage()
    {
        var elem = Element.FindElement(_testCasePage);
        elem.Click();
        var page = new TestCasesPage(WebDriver, elem.GetAttribute("href"));
        WaitingHelper.WaitUntilUrlToBe(WebDriver, page.Url);
        return page;
    }
    
}