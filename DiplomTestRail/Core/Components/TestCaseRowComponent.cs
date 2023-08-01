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
        private static string checkBoxCss = "td.checkbox>.selectionCheckbox";
        private static string idCss = "td.id";
        private static string titleCss = "span.title";


        private IWebElement checkBoxElement;
        private IWebElement idElement;
        private IWebElement titlElement;

        public TestCaseRowComponent(IWebElement checkBoxElement, IWebElement idElement, IWebElement titlElement)
        {
            this.checkBoxElement = checkBoxElement;
            this.idElement = idElement;
            this.titlElement = titlElement;
        }

        public static TestCaseRowComponent Create(IWebElement element)
        {
            Console.WriteLine(element.Text);
            IWebElement checkBox = element.FindElement(By.CssSelector(checkBoxCss));
            IWebElement id = element.FindElement(By.CssSelector(idCss));
            IWebElement title = element.FindElement(By.CssSelector(titleCss));
            return new TestCaseRowComponent(checkBox, id, title);
        }
        
            public string getTitleText()
        {
            return titlElement.Text;
        }

            public string getId()
            {
                return idElement.Text;

            }

        public void checkBoxClick()
        {
            checkBoxElement.Click();
        }
        public void idClick() { idElement.Click(); }
        public void titlClick() {  titlElement.Click(); }

    }
}
