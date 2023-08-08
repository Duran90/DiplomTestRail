using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Components
{
    public class TestCaseRowComponent
    {
        private const string CheckBoxCss = "td.checkbox>.selectionCheckbox";
        private const string IdCss = "td.id";
        private const string TitleCss = "span.title";


        private IWebElement _checkBoxElement;
        private IWebElement _idElement;
        private IWebElement _titlElement;

        public TestCaseRowComponent(IWebElement checkBoxElement, IWebElement idElement, IWebElement titlElement)
        {
            this._checkBoxElement = checkBoxElement;
            this._idElement = idElement;
            this._titlElement = titlElement;
        }

        public static TestCaseRowComponent Create(IWebElement element)
        {
            Console.WriteLine(element.Text);
            IWebElement checkBox = element.FindElement(By.CssSelector(CheckBoxCss));
            IWebElement id = element.FindElement(By.CssSelector(IdCss));
            IWebElement title = element.FindElement(By.CssSelector(TitleCss));
            return new TestCaseRowComponent(checkBox, id, title);
        }
        
            public string GetTitleText()
        {
            return _titlElement.Text;
        }

            public string getId()
            {
                return _idElement.Text;

            }

        public void checkBoxClick()
        {
            _checkBoxElement.Click();
        }
        public void idClick() { _idElement.Click(); }
        public void titlClick() {  _titlElement.Click(); }

    }
}
