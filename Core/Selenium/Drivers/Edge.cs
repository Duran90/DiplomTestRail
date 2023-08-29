using Core.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Core.Selenium.Drivers;

    internal class Edge
    {
        public static WebDriver Driver => NewDriver();
        
        private static WebDriver NewDriver()
        {
            var options = new EdgeOptions();
            if(AppConfiguration.Browser.Headless) options.AddArgument("--headless");
            return new FirefoxDriver();
        }
    }

