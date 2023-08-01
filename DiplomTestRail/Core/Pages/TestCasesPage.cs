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
        private static string testCasesCss = ".caseRow";

        private List<TestCaseRowComponent> testCases;
        public TestCasesPage(IWebDriver driver) : base(driver)
        {
            var gridOneElem = driver.FindElement(By.Id("grid-1")); 
            this.testCases = new List<TestCaseRowComponent>();
            foreach (IWebElement element in gridOneElem.FindElements(By.CssSelector(testCasesCss)))
            {
                Console.WriteLine("grid elem " + element.TagName + " " + element.Text);
                testCases.Add(TestCaseRowComponent.Create(element));
            }
        }

        public TestCaseRowComponent getTestCaseById(string id)
        {
            foreach (var testCaseComponent in testCases)
            {
                if (testCaseComponent.getId().ToLower().Equals(id.ToLower()))
                {
                    return testCaseComponent;
                }
            }
            throw new Exception("no such id");
        }

        public TestCaseRowComponent getTestCAseByTitle(string title)
        {
            foreach (var testCaseComponent in testCases)
            {
                return testCaseComponent;
            }
            throw new Exception("no such title");
        }

        public void ClickIdTestCase(String name)
        {
            getTestCaseById(name).idClick();
        }
        public void ClickTitleTestCase(String name)
        {
            getTestCAseByTitle(name).titlClick();
        }
    }
}
