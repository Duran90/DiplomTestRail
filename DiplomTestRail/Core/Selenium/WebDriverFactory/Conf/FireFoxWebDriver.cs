using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace DiplomTestRail.Core.Selenium.WebDriverFactory.Conf
{
    internal class FireFoxWebDriver
    {
        public static WebDriver newDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            return new FirefoxDriver(options);
        }
    }
}
