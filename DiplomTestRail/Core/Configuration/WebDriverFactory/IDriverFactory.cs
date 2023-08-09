using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Selenium.WebDriverFactory
{
    internal interface IDriverFactory
    {
        public WebDriver getDriver(string browser);
    }
}
