using Core.Selenium.Components;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Components;

public class ConfirmationModalComponent : BaseComponent
{
    private Checkbox _checkBoxElement => new (Element, By.Name("deleteCheckbox"));
    private Button _okButtonElement => new Button(Element, By.CssSelector("a.button.button-ok"));
    private Button _cancelButtonElement => new (Element, By.CssSelector("a.button.button-cancel")) ;
    public ConfirmationModalComponent Confirm()
    {
        _checkBoxElement.Toggle();
        return this;
    }
    public ConfirmationModalComponent(IWebElement element, IWebDriver driver) : base(element, driver)
    {
    }
    public ConfirmationModalComponent Submit()
    {
        _okButtonElement.Click();
        return this;
    }
    
    public ConfirmationModalComponent Cancel()
    {
        _cancelButtonElement.Click();
        return this;
    }



}