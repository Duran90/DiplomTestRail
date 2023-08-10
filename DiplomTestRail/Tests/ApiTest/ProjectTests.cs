using System.Net;
using DiplomTestRail.BussinessObject.ApiObject;
using DiplomTestRail.BussinessObject.ApiServiseSteps;
using DiplomTestRail.BussinessObject.Models;
using DiplomTestRail.Core.Models;
using RestSharp;

namespace DiplomTestRail.Tests.ApiTest;

public class ProjectTests: BaseApiTest
{
    protected ProjectService _service;
    protected ApiProjectSteps _apiProjectSteps;

    [OneTimeSetUp]
    public void InitialService()
    {
        _service = new ProjectService(_apiClient);
        _apiProjectSteps = new ApiProjectSteps(_service);
    }

    [Test]
    public void GetProjects()
    {
        var response = _apiProjectSteps.GetProjects();
        Assert.That(response.Size, Is.EqualTo(3));
    }
    
    [Test]
    public void GetProjectById()
    {
        var project = _apiProjectSteps.GetProjectById(1);
        Assert.That(project.Name, Is.EqualTo("Exam"));
    }

    [Test]
    public void CreateProject()
    {
        var projectModel = new ApiProjectModel()
        {
            Name =  "Project X",
            Announcement = "Welcome to project X",
            ShowAnnouncement = true
        };
        var projectResponse = _apiProjectSteps.CreateProject(projectModel);
        Assert.That(projectResponse.Name, Is.EqualTo(projectModel.Name));
        Assert.That(projectResponse.Announcement, Is.EqualTo(projectModel.Announcement));
        var deletProject = _service.DeleteProject(projectResponse.Id);
        Assert.IsTrue(deletProject.StatusCode.Equals(HttpStatusCode.OK));
    }
}  