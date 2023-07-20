using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Tests.UiTest
{
    public class UiPositiveTests
    {
        
        private WebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            var browserType = TestContext.Parameters.Get("BrowserType");

            this.driver = new DriverFactory().getDriver(browserType);
        }

        [TearDown]
        public void CloseBrowser()
        {

            driver?.Close();
            driver?.Quit();
        }
    }
}