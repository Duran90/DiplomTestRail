using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace DiplomTestRail.Core.PageObject
{
    public abstract class AbsPageObject
    {
        protected IWebDriver driver;
        protected Actions actions;
        protected WebDriverWait wait;

        public AbsPageObject(IWebDriver driver)
        {
            this.driver = driver;
            this.actions = new Actions(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //TODO Методы получения элемен
        //public void ClickElementByCss(string css)
        //{
        //    Console.WriteLine("вход в клик");
        //    driver.FindElement(By.CssSelector(css)).Click();
        //    Console.WriteLine("вЫход в клик");
        //}

        //public void ClickElemetByXPath(string xpath)
        //{
        //    driver.FindElement(By.XPath(xpath)).Click();
        //}

        public void ClickElementById(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

    }
}
