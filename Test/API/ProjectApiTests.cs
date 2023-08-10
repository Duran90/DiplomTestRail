using System.Net;
using Allure.Commons;
using BusinessObject.Models;
using BusinessObject.API.Services;
using BusinessObject.API.Steps;
using BusinessObject.Builders;
using NUnit.Allure.Attributes;

namespace Test.API;

public class ProjectApiTests : BaseApiTest
{
    protected ProjectService _service;
    protected ProjectSteps _apiProjectSteps;

    [OneTimeSetUp]
    public void InitialService()
    {
        _service = new ProjectService(ApiClient);
        _apiProjectSteps = new ProjectSteps(_service);
    }

    [Test]
    [Category("API")]
    [AllureTag("API")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void GetProjects()
    {
        var response = _apiProjectSteps.GetProjects();
        Assert.Multiple(() =>
        {
            Assert.That(response!.Size, Is.GreaterThan(0));
            Assert.That(response.Size, Is.EqualTo(response.Projects.Count));
        });
    }

    [Test]
    [Category("API")]
    [AllureTag("API")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void GetProjectPositive()
    {
        var project = _apiProjectSteps.GetProject(71);
        Assert.That(project!.Id, Is.EqualTo(71));
    }

    [Test]
    [Category("API")]
    [AllureTag("API")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    public void GetProjectNegative()
    {
        var response = _service.GetProject(-1);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    [Category("API")]
    [AllureTag("API")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void CreateProjectPositive()
    {
        var projectModel = ProjectBuilder.GetProject();
        var projectResponse = _apiProjectSteps.CreateProject(projectModel);
        Assert.Multiple(() =>
        {
            Assert.That(projectResponse!.Name, Is.EqualTo(projectModel.Name));
            Assert.That(projectResponse.Announcement, Is.EqualTo(projectModel.Announcement));
        });

        var deleteProject = _service.DeleteProject(projectResponse!.Id);
        Assert.That(deleteProject.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    [Category("API")]
    [AllureTag("API")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Project")]
    [AllureSubSuite("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    public void CreateProjectNegative()
    {
        var projectModel = ProjectBuilder.GetEmptyProject();
        var response = _service.CreateProject(projectModel);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
    
}