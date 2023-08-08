
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Components
{
    public class ConfirmationComponent
    {
        private IWebElement _checkBoxElement;
        private IWebElement _okButtonElement;
        private IWebElement _cancelButtonElement;

        private static string _checkBoxElementXPath = "//*[@id=\"deleteDialog\"]/div[2]/div/div/label/input";
        private static string _okButtonElementXPath = "//*[@id=\"deleteDialog\"]/div[3]/a[1]";
        private static string _cancelButtonElementXPath = "//*[@id=\"deleteDialog\"]/div[3]/a[3]";

        public ConfirmationComponent(IWebElement checkBoxElement, IWebElement okButtonElement,
            IWebElement cancelButtonElement)
        {
            this._checkBoxElement = checkBoxElement;
            this._okButtonElement = okButtonElement;
            this._cancelButtonElement = cancelButtonElement;
        }

        public static ConfirmationComponent CreateConfirmationComponent(IWebElement element)
        {
            IWebElement checkBox = element.FindElement(By.XPath(_checkBoxElementXPath));
            IWebElement ok = element.FindElement(By.XPath(_okButtonElementXPath));
            IWebElement cansel = element.FindElement(By.XPath(_cancelButtonElementXPath));
            return new ConfirmationComponent(checkBox, ok, cansel);
        }

        public void ClickOnCheckBox()
        {
            this._checkBoxElement.Click();
        }

        public void clickOnOk()
        {
            this._okButtonElement.Click();
        }
    }
}