using OpenQA.Selenium;

namespace Core.Selenium.Elements;

public class Checkbox : BaseElement
{
    public void Toggle()
    {
        Element.Click();
    }

    public bool Selected()
    {
        return Element.Selected;
    }

    public Checkbox(ISearchContext context, By locator) : base(context, locator)
    {
    }

    public Checkbox(ISearchContext context, string xpath) : base(context, xpath)
    {
    }
}