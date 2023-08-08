using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace DiplomTestRail.Tests.UiTest
{
    public class BaseTest
    {

            protected Browser browser;
            private Logger logger = LogManager.GetCurrentClassLogger();


                [SetUp]
            public void Setup()
            {   
                
                var browserType = TestContext.Parameters.Get("Browser");
                if (browserType == null)
                {
                    throw new Exception("browser type must be set in params");
                }

                this.browser = new Browser(browserType);

            }


            [TearDown]
            public void TearDown()
            {
                browser.CloseBrowser();
            }
        
    }
}
