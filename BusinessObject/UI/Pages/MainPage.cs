using BusinessObject.UI.Components;
using Core.Configuration;
using Core.Selenium;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;
////*[@id="project-6"]
public class MainPage : HeaderPage
{
    private readonly By _addProjectLink = By.CssSelector("a#sidebar-projects-add");
    private readonly By _projectSummary = By.CssSelector("[id^='project-']");

    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    public override string Url => $"{AppConfiguration.Browser.BaseUrl}/index.php?/dashboard";

    public override MainPage Open() => (MainPage)base.Open();
    public override MainPage Refresh() => (MainPage)base.Refresh();

    public ProjectAddPage AddProject()
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _addProjectLink);
        var element = Driver.FindElement(_addProjectLink);
        element.Click();
        return new ProjectAddPage(Driver);
    }

    public void OpenProject(string projectId)
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _projectSummary);
        foreach (var findElement in Driver.FindElements(_projectSummary))
        {
            var component = new ProjectSummaryComponent(findElement, Driver);
            if (!component.ProjectTitle.Equals(projectId)) continue;
            component.OpenOverviewPage();
            return;
        }

        throw new Exception("project not found");
    }
}