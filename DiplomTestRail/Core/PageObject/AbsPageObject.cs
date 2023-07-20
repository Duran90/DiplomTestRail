using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace DiplomTestRail.Core.PageObject
{
    public abstract class AbsPageObject
    {
        protected WebDriver driver;
        protected Actions actions;
        protected WebDriverWait wait;

        public AbsPageObject(WebDriver driver)
        {
            this.driver = driver;
            this.actions = new Actions(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //TODO Методы получения элементов

    }
}
