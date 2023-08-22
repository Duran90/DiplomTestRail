using BusinessObject.UI.Components;
using Core.Configuration;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class ProjectsPage : HeaderPage
{
    public override string Url => $"{AppConfiguration.Browser.BaseUrl}/index.php?/projects/overview";

    private By _projectRow = By.CssSelector(".hoverSensitive");
    private By _deleteDialog = By.Id("dialog-ident-deleteDialog");
    
    private By _successMessage = By.CssSelector(".message.message-success");
    private BaseElement SuccessMessage => new(Driver, _successMessage);
    

    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    public override ProjectsPage Open() => (ProjectsPage)base.Open();

    public override ProjectsPage Refresh() => (ProjectsPage)base.Refresh();

    public string GetSuccessMessage()
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _successMessage);
        return SuccessMessage.GetElementText();
    }

    public List<ProjectRowComponent> GetProjectList()
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, By.ClassName("grid"));

        return Driver.FindElements(_projectRow)
            .Select<IWebElement, ProjectRowComponent>(element => new ProjectRowComponent(element, Driver))
            .ToList();
    }

    public ProjectRowComponent GetProject(string projectName)
    {
        return GetProjectList().SingleOrDefault(project => project.ProjectName.Equals(projectName))!;
    }

    public ProjectsPage DeleteProject(string projectName)
    {
        Logger.Info($"Delete project {projectName}");

        GetProject(projectName).DeleteProject();
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _deleteDialog);
        new ConfirmationModalComponent(Driver.FindElement(_deleteDialog), Driver).Confirm().Submit();

        return this;
    }

    public ProjectEditPage OpenProject(string projectName)
    {
        return GetProject(projectName).EditProject();
    }
}