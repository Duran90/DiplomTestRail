using BusinessObject.UI.Pages;
using Core.Selenium.Components;
using OpenQA.Selenium;

namespace BusinessObject.UI.Components;

public class ProjectRowComponent : BaseComponent
{
    private By _name = By.CssSelector("td:nth-child(1)>a");
    private By _edit = By.ClassName("icon-small-edit");
    private By _delete = By.ClassName("icon-small-delete");
   

    public string ProjectName => Element.FindElement(_name).Text;

    public ProjectEditPage EditProject()
    {
        var href = Element.FindElement(_name).GetAttribute("href");
        Element.FindElement(_edit).Click();
        return new ProjectEditPage(href);
    }

    public void DeleteProject()
    {
        Element.FindElement(_delete).Click();
    }

    public ProjectRowComponent(IWebElement element, IWebDriver driver) : base(element, driver)
    {
    }
}