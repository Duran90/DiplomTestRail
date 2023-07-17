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

        public Header(WebDriver driver) : base(driver)
        {
        }

        //TODO Методы

        public DashboardPage openDashboardPage()
        {
            return new DashboardPage(driver);
        }

        public TestCasesPage OpenTestCasesPage()
        {
            return new TestCasesPage(driver);
        }

    }
}
