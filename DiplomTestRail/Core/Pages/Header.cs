using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.PageObject;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class Header : AbsPageObject
    {
        //TODO локаторы
        private static string TestCasePageCss = "#header>ul>li:nth-child(6)";
        private static string BackToMainPageId = "navigation-dashboard-top";

        public Header(IWebDriver driver) : base(driver)
        {
        }

        //TODO Методы

        public MainPage OpenDashboardPage()
        {
            return new MainPage(driver);
        }

        public TestCasesPage OpenTestCasesPage()
        {
            driver.FindElement(By.CssSelector(TestCasePageCss)).Click();
            return new TestCasesPage(driver);
        }

    }
}
