using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Selenium.WebDriverFactory.Conf;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Selenium.WebDriverFactory
{
    internal class DriverFactory: IDriverFactory
    {
        private var sting = "";
        string browserType = TestContext.Parameters.Get("BrowserType");
        public WebDriver getDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return ChromeWebDriver.newDriver();
                case "firefox":
                    return FireFoxWebDriver.newDriver();
                case "edge":
                    return EdgeWebDriver.newDriver();
                default:
                    throw new DriveNotFoundException();

            }
        }
    }
}
