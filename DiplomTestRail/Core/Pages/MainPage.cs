using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Components;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class MainPage : BasePage
    {
        private const string CssProjectElem = "div.table.summary-auto>div";
        private const string IdAddProject = "sidebar-projects-add";

        private List<MainProjectComponent> _projects;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this._projects = new List<MainProjectComponent>();
            foreach (IWebElement element in driver.FindElements(By.CssSelector(CssProjectElem)))
            {
                _projects.Add(MainProjectComponent.Create(element));
            }
        }

        public ICollection<MainProjectComponent> GetProjects()
        {
            return this._projects;
             
        }

        public MainProjectComponent GetCartByName(string name)
        {
            foreach (var projectComponent in _projects)
            {
                if (projectComponent.GetTitle().ToLower().Equals(name.ToLower()))
                {
                    return projectComponent;
                }
            }
            Console.WriteLine("Ошибка поискаэлемента");
            throw new Exception("no such element");
        }

        public void ClickProjectCard(String name)
        {
            GetCartByName(name).Click();
        }

        public void ClickAddProject()
        {
            ClickElementById(IdAddProject);
        }
    }
}
