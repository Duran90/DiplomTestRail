using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Selenium.Elements
{
    public class InputElement: BaseElement
    {
        public InputElement(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        public InputElement(IWebDriver driver, string xPath) : base(driver, xPath)
        {
        }

        public void setText(string text)
        {
            GetElement().SendKeys(text);
        }

        public void clearText()
        {
            GetElement().Clear();
        }
    }
}
