using System.Net;
using BusinessObject.Models;
using BusinessObject.API.Services;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace BusinessObject.API.Steps;

public class ProjectSteps
{
    private readonly ProjectService _projectService;

    public ProjectSteps(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [AllureStep]
    public ProjectModel? GetProject(int id)
    {
        var response = _projectService.GetProject(id);
        Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.IsNotNull(response.Content);
        return JsonConvert.DeserializeObject<ProjectModel>(response.Content!);
    }

    [AllureStep]
    public ProjectsModel? GetProjects()
    {
        var response = _projectService.GetProjects();
        Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.IsNotNull(response.Content);
        return JsonConvert.DeserializeObject<ProjectsModel>(response.Content!);
    }

    [AllureStep]
    public ProjectModel? CreateProject(ProjectModel apiProjectModel)
    {
        var response = _projectService.CreateProject(apiProjectModel);
        Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.IsNotNull(response.Content);
        return JsonConvert.DeserializeObject<ProjectModel>(response.Content!);
    }

    [AllureStep]
    public bool DeleteProject(int id)
    {
        var response = _projectService.DeleteProject(id);
        return response.StatusCode.Equals(HttpStatusCode.OK);
    }
}