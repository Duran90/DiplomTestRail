using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class Input : BaseElement
    {
        
        public void TypeText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }

        public void Clear()
        {
            Element.Clear();
        }

        public string GetValue()
        {
            return Element.GetAttribute("value");
        }

        public Input(ISearchContext context, By locator) : base(context, locator)
        {
        }

        public Input(ISearchContext context, string xpath) : base(context, xpath)
        {
        }
    }
}
