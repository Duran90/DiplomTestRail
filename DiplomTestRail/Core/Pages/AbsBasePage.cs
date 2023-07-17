using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.PageObject;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public abstract class AbsBasePage : AbsPageObject
    {
        public static string BASE_URL = "BASE_URL"; //TODO

        private Header header;


        public AbsBasePage(WebDriver driver) : base(driver)
        {
            this.header = new Header(driver);
        }

        public void open()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public Header getHeader()
        {
            return header;
        }
    }
}
