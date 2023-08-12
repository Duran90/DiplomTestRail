using Allure.Commons;
using BusinessObject.Builders;
using BusinessObject.UI.Steps;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UI;

public class ProjectPageTests : BaseTest
{
    protected const string ExpectedAddProjectErrorMessage = "Field Name is a required field.";

    protected const string ExpectedAddProjectESuccessfullyMessage = "Successfully added the new project.";
    protected const string ExpectedDeletedProjectESuccessfullyMessage = "Successfully deleted the project.";
    protected const string ExpectedEditProjectESuccessfullyMessage = "Successfully updated the project.";


    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void CreateProject()
    {
        var project = ProjectBuilder.GetProject();
        var projectsPage = ProjectsSteps.OpenProjectsAddPage()
            .CreateProject(project);

        Assert.That(projectsPage.GetSuccessMessage(), Is.EqualTo(ExpectedAddProjectESuccessfullyMessage));
        var projectRow = projectsPage.GetProject(project.Name);
        Assert.That(projectRow.ProjectName, Is.EqualTo(project.Name));
    }

    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void EditProject()
    {
        var project = ProjectBuilder.GetProject();
        var editPage = ProjectsSteps.OpenProjectsAddPage()
            .CreateProject(project)
            .GetProject(project.Name)
            .EditProject();

        var newProject = ProjectBuilder.GetProject();

        Assert.That(editPage.IsSaveEnabled, Is.False);
        var projectsPage = editPage.SetProjectName(newProject.Name)
            .SetProjectAnnouncement(newProject.Announcement ?? "")
            .SaveProject();

        Assert.That(projectsPage.GetSuccessMessage(), Is.EqualTo(ExpectedEditProjectESuccessfullyMessage));
    }

    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void DeleteProject()
    {
        var project = ProjectBuilder.GetProject();
        var page = ProjectsSteps.OpenProjectsAddPage()
            .CreateProject(project)
            .Refresh()
            .DeleteProject(project.Name);

        Assert.That(page.GetSuccessMessage(), Is.EqualTo(ExpectedDeletedProjectESuccessfullyMessage));
    }

    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    public void CreateProjectNegative()
    {
        var project = ProjectBuilder.GetEmptyProject();
        var page = ProjectsSteps.OpenProjectsAddPage();
        page.CreateProject(project);
        
        Assert.Multiple(() =>
        {
            Assert.That(page.GetErrorMessage(), Is.EqualTo(ExpectedAddProjectErrorMessage));
            Assert.That(Browser.Instance.Driver.Url, Is.EqualTo(page.Url));
        });
    }
}