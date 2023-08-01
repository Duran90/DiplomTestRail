using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Components;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class MainPage : BasePage
    {
        private static string CssProjectElem = "div.table.summary-auto>div";

        private List<ProjectComponent> projects;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this.projects = new List<ProjectComponent>();
            foreach (IWebElement element in driver.FindElements(By.CssSelector(CssProjectElem)))
            {
                projects.Add(ProjectComponent.Create(element));
            }
        }

        public ICollection<ProjectComponent> GetProjects()
        {
            return this.projects;
             
        }

        public ProjectComponent getCartByName(string name)
        {
            foreach (var projectComponent in projects)
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
            getCartByName(name).Click();
            Console.WriteLine("Вход выполнен");
        }
    }
}
