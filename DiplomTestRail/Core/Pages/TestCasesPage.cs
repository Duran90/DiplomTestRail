using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Components;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class TestCasesPage : BasePage
    {
        private const string TestCasesCss = ".caseRow";

        private List<TestCaseRowComponent> _testCases;
        public TestCasesPage(IWebDriver driver) : base(driver)
        {
            var gridOneElem = driver.FindElement(By.Id("grid-1")); 
            this._testCases = new List<TestCaseRowComponent>();
            foreach (IWebElement element in gridOneElem.FindElements(By.CssSelector(TestCasesCss)))
            {
                Console.WriteLine("grid elem " + element.TagName + " " + element.Text);
                _testCases.Add(TestCaseRowComponent.Create(element));
            }
        }

        public TestCaseRowComponent GetTestCaseById(string id)
        {
            foreach (var testCaseComponent in _testCases)
            {
                if (testCaseComponent.getId().ToLower().Equals(id.ToLower()))
                {
                    return testCaseComponent;
                }
            }
            throw new Exception("no such id");
        }

        public TestCaseRowComponent GetTestCAseByTitle(string title)
        {
            foreach (var testCaseComponent in _testCases)
            {
                return testCaseComponent;
            }
            throw new Exception("no such title");
        }

        public void ClickIdTestCase(String name)
        {
            GetTestCaseById(name).idClick();
        }
        public void ClickTitleTestCase(String name)
        {
            GetTestCAseByTitle(name).titlClick();
        }
    }
}
