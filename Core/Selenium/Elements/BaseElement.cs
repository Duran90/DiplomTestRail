using OpenQA.Selenium;
namespace Core.Selenium.Elements
{
    public class BaseElement
    {
        protected ISearchContext Context;
        protected IWebElement Element => Context.FindElement(Locator);
        
        protected readonly By Locator;

        public BaseElement(ISearchContext context, By locator)
        {
            this.Locator = locator;
            this.Context = context;
        }

        public BaseElement(ISearchContext context,string xpath)
        {
            this.Locator = By.XPath(xpath);
            this.Context = context;
        }

        public bool Enabled() => Element.Enabled;

    }
}
