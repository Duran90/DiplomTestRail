using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Selenium.Elements
{
    public class Button : BaseElement
    {
        public void Click()
        {
            Element.Click();
        }

        public string GetText()
        {
            return Element.Text;
        }

        public Button(ISearchContext context, By locator) : base(context, locator)
        {
        }

        public Button(ISearchContext context, string xpath) : base(context, xpath)
        {
        }
    }
}
