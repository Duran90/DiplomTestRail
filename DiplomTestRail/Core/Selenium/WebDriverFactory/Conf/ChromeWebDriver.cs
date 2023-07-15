using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomTestRail.Core.Selenium.WebDriverFactory.Conf
{
    public class ChromeWebDriver
    {
        public static WebDriver newDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--diable-gpu");
            options.AddArgument("incognito");
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
