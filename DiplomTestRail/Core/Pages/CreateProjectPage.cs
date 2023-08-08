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
        private const string LinkCss = "div .tab>a";
        private ICollection<IWebElement> _links;
        private const string InputProjectNameCss = "div>#name";
        private const string ButtonAacceptAddProjectId = "accept";

        private const string ErrorAddProjectMessage = "#content-inner>div.message.message-error";

        public InputElement Name;
        public ButtonElement AddButton;

        public CreateProjectPage(IWebDriver driver) : base(driver)
        {
            this._links = new List<IWebElement>();
            foreach (IWebElement element in driver.FindElements(By.CssSelector(LinkCss)))
            {
                _links.Add(element);
            }

            this.Name = new InputElement(driver, By.CssSelector(InputProjectNameCss));
            this.AddButton = new ButtonElement(driver, By.Id(ButtonAacceptAddProjectId));
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(By.CssSelector(ErrorAddProjectMessage)).Text;
        }
    }
}
