using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Selenium.Elements
{
    public class BaseElement
    {
        protected IWebDriver Driver;
        protected By Locator;

        public BaseElement(IWebDriver driver, By locator)
        {
            this.Driver = driver;
            this.Locator = locator;
        }
        public BaseElement(IWebDriver driver, string xPath)
        {
            this.Locator = By.XPath(xPath);
            this.Driver = driver;
        }

        public IWebElement GetElement() => Driver.FindElement(Locator);




    }
}
