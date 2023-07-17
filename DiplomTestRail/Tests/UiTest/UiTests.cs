using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Tests.UiTest
{
    public class UiPositiveTests
    {

        private string browser = "";//TODO
        private WebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            this.driver = new DriverFactory().getDriver(browser);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}