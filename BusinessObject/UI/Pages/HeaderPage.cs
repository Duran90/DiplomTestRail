using BusinessObject.UI.Components;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public abstract class HeaderPage : BasePage
{
    public HeaderComponent Header => new (Driver);
    
    protected HeaderPage(IWebDriver driver) : base(driver)
    {
    }
}