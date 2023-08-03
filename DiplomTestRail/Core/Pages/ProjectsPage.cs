using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Components;
using DiplomTestRail.Core.Helers;
using DiplomTestRail.Core.PageObject;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class ProjectsPage: AbsPageObject

    {
        private string projetsRows = ".hoverSensitive";

        private string confirmationDialogId = "dialog-ident-deleteDialog";

        private List<ProjectsPageProjectComponent> projectsList;
        private ConfirmationComponent confirmationComponent;

        public ProjectsPage(IWebDriver driver) : base(driver)
        {
            loadProjectList();
            
        }

        private void loadProjectList()
        {
            this.projectsList = new List<ProjectsPageProjectComponent>();
            foreach (IWebElement element in driver.FindElements(By.CssSelector(projetsRows)))
            {
                projectsList.Add(ProjectsPageProjectComponent.CreProjectsPageProjectComponent(element));
            }
        }

        public ICollection<ProjectsPageProjectComponent> GetProjectsList()
        {
            return this.projectsList;
        }

        public ProjectsPageProjectComponent GetPageProjectComponent(String name)
        {
            foreach (var element in GetProjectsList())
            {
                if (element.getName().Equals(name))
                {
                    return element;
                }
            }
            return null;
        }

        public void DeleteProject(String name)
        {
            ProjectsPageProjectComponent project = GetPageProjectComponent(name);
            if (project != null)
            {
                project.DeletedClick();
                WaitingHelper.WaitElementUntilIsIsDisplay(driver, By.Id(confirmationDialogId));
                IWebElement confDialog = driver.FindElement(By.Id(confirmationDialogId));
                ConfirmationComponent.CreateConfirmationComponent(confDialog).ClickOnCheckBox();
                ConfirmationComponent.CreateConfirmationComponent(confDialog).clickOnOk();
                loadProjectList();
            }

        }
    }
}
