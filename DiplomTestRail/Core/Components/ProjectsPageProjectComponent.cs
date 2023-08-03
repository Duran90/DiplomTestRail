using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Components
{
    public class ProjectsPageProjectComponent
    {
        private IWebElement nameElem;
        private IWebElement editElem;
        private IWebElement deletedElem;

        private static string nameCss = "td:nth-child(1)>a";
        private static string editCss = "td:nth-child(2)>a";
        private static string deletedCss = "td:nth-child(3)>a";

        public ProjectsPageProjectComponent(IWebElement nameElem,IWebElement editElem,IWebElement deletedElem)
        {
            this.nameElem = nameElem;
            this.editElem = editElem;
            this.deletedElem = deletedElem;
        }

        public string getName()
        {
             return nameElem.Text;
        }

        public void DeletedClick()
        {
            this.deletedElem.Click();
            return;
        }


        public static ProjectsPageProjectComponent CreProjectsPageProjectComponent (IWebElement element)
        {
            IWebElement name = element.FindElement(By.CssSelector(nameCss));
            IWebElement edit = element.FindElement(By.CssSelector(editCss));
            IWebElement deleted = element.FindElement(By.CssSelector(deletedCss));
            return new ProjectsPageProjectComponent(name, edit, deleted);
        }

    }
}
