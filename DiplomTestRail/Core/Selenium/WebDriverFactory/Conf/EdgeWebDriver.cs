using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace DiplomTestRail.Core.Selenium.WebDriverFactory.Conf
{
    internal class EdgeWebDriver
    {
        public static WebDriver newDriver()
        {
            EdgeOptions options = new EdgeOptions();
            return new FirefoxDriver();
        }
    }
}
