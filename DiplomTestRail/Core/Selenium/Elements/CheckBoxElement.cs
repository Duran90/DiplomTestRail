using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Selenium.Elements
{
    public class CheckBoxElement :BaseElement
    {
        public CheckBoxElement(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        public CheckBoxElement(IWebDriver driver, string xPath) : base(driver, xPath)
        {
        }

        public void Click()
        {
            GetElement().Click();

        }
    }
}
