using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Selenium.WebDriverFactory
{
    public class Browser
    {

        private WebDriver driver;
        public IWebDriver? Driver { get { return driver; } }


        public Browser(string browserType)
        {
            this.driver = new DriverFactory().getDriver(browserType);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void CloseBrowser()
        {
            driver?.Close();
            driver?.Quit();
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void AcceptDismiss()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void SwitchToFrame(string id)
        {
            driver.SwitchTo().Frame(id);
        }


    }

}
