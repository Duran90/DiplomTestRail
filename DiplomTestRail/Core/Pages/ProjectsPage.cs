using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Components;
using DiplomTestRail.Core.Helpers;
using DiplomTestRail.Core.PageObject;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class ProjectsPage : AbsPageObject
    {
        private const string ProjetsRows = ".hoverSensitive";

        private const string ConfirmationDialogId = "dialog-ident-deleteDialog";

        private List<ProjectsPageProjectComponent> _projectsList;
        private ConfirmationComponent _confirmationComponent;

        public ProjectsPage(IWebDriver driver) : base(driver)
        {
            LoadProjectList();
        }

        private void LoadProjectList()
        {
            this._projectsList = new List<ProjectsPageProjectComponent>();
            foreach (IWebElement element in Driver.FindElements(By.CssSelector(ProjetsRows)))
            {
                _projectsList.Add(ProjectsPageProjectComponent.CreProjectsPageProjectComponent(element));
            }
        }

        public ICollection<ProjectsPageProjectComponent> GetProjectsList()
        {
            return this._projectsList;
        }

        public ProjectsPageProjectComponent GetPageProjectComponent(String name)
        {
            foreach (var element in GetProjectsList())
            {
                if (element.GetName().Equals(name))
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
                WaitingHelper.WaitElementUntilIsIsDisplay(Driver, By.Id(ConfirmationDialogId));
                IWebElement confDialog = Driver.FindElement(By.Id(ConfirmationDialogId));
                ConfirmationComponent.CreateConfirmationComponent(confDialog).ClickOnCheckBox();
                ConfirmationComponent.CreateConfirmationComponent(confDialog).clickOnOk();
                LoadProjectList();
            }
        }
    }
}