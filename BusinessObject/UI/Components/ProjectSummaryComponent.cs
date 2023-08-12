using BusinessObject.UI.Pages;
using Core.Selenium;
using Core.Selenium.Components;
using OpenQA.Selenium;

namespace BusinessObject.UI.Components;

public class ProjectSummaryComponent : BaseComponent
{
    private readonly By _projectTitle = By.CssSelector(".summary-title.text-ppp>a");
    private readonly By _link = By.CssSelector("div.summary-links.text-secondary>a");
    
    
    public IWebElement SummaryDescription => Element.FindElement(By.ClassName("summary-description"));

    public string ProjectTitle => Element.FindElement(_projectTitle).Text;
    public void OpenOverviewPage()
    {
        var elem = Element.FindElement(_projectTitle);
        var href = elem.GetAttribute("href");
        elem.Click();
    }

    public ProjectSummaryComponent(IWebElement element, IWebDriver driver) : base(element, driver)
    {
        
    }
}