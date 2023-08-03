using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Components;
using DiplomTestRail.Core.PageObject;
using DiplomTestRail.Core.Selenium.Elements;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class CreateProjectPage: AbsPageObject

    {
 
        private static string linkCss = "div .tab>a";
        private ICollection<IWebElement> links;
        private static string InputProjectNameCss = "div>#name";
        private static string ButtonAacceptAddProjectId = "accept";

        private static string ErrorAddProjectMessage = "#content-inner>div.message.message-error";

        public InputElement Name;
        public ButtonElement AddButton;

        public CreateProjectPage(IWebDriver driver) : base(driver)
        {
            this.links = new List<IWebElement>();
            foreach (IWebElement element in driver.FindElements(By.CssSelector(linkCss)))
            {
                links.Add(element);
            }

            this.Name = new InputElement(driver, By.CssSelector(InputProjectNameCss));
            this.AddButton = new ButtonElement(driver, By.Id(ButtonAacceptAddProjectId));
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(By.CssSelector(ErrorAddProjectMessage)).Text;
        }
    }
}
