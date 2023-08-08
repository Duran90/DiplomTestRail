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
        private IWebElement _nameElem;
        private IWebElement _editElem;
        private IWebElement _deletedElem;

        private const string NameCss = "td:nth-child(1)>a";
        private const string EditCss = "td:nth-child(2)>a";
        private const string DeletedCss = "td:nth-child(3)>a";

        public ProjectsPageProjectComponent(IWebElement nameElem,IWebElement editElem,IWebElement deletedElem)
        {
            this._nameElem = nameElem;
            this._editElem = editElem;
            this._deletedElem = deletedElem;
        }

        public string GetName()
        {
             return _nameElem.Text;
        }

        public void DeletedClick()
        {
            this._deletedElem.Click();
            return;
        }


        public static ProjectsPageProjectComponent CreProjectsPageProjectComponent (IWebElement element)
        {
            IWebElement name = element.FindElement(By.CssSelector(NameCss));
            IWebElement edit = element.FindElement(By.CssSelector(EditCss));
            IWebElement deleted = element.FindElement(By.CssSelector(DeletedCss));
            return new ProjectsPageProjectComponent(name, edit, deleted);
        }

    }
}
