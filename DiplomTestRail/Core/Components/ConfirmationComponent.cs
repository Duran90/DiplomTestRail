using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Selenium.Elements;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Components
{
    public class ConfirmationComponent
    {
        private IWebElement CheckBoxElement;
        private IWebElement OkButtonElement;
        private IWebElement CancelButtonElement;

        private static string CheckBoxElementXPath = "//*[@id=\"deleteDialog\"]/div[2]/div/div/label/input";
        private static string OkButtonElementXPath = "//*[@id=\"deleteDialog\"]/div[3]/a[1]";
        private static string CancelButtonElementXPath = "//*[@id=\"deleteDialog\"]/div[3]/a[3]";

        public ConfirmationComponent(IWebElement checkBoxElement, IWebElement okButtonElement, IWebElement cancelButtonElement)
        {
            this.CheckBoxElement = checkBoxElement;
            this.OkButtonElement = okButtonElement;
            this.CancelButtonElement = cancelButtonElement;
        }
        public static ConfirmationComponent CreateConfirmationComponent(IWebElement element)
        {
            IWebElement cheacBox = element.FindElement(By.XPath(CheckBoxElementXPath));
            IWebElement ok = element.FindElement(By.XPath(OkButtonElementXPath));
            IWebElement cansel = element.FindElement(By.XPath(CancelButtonElementXPath));
            return new ConfirmationComponent(cheacBox, ok, cansel);
        }

        public void ClickOnCheckBox()
        {
            this.CheckBoxElement.Click();
        }

        public void clickOnOk()
        {
            this.OkButtonElement.Click();
        }
    }
}
