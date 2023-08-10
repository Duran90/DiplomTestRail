using System.Net;
using System.Text.Json.Serialization;
using DiplomTestRail.BussinessObject.ApiObject;
using DiplomTestRail.BussinessObject.Models;
using DiplomTestRail.Core.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DiplomTestRail.BussinessObject.ApiServiseSteps;

public class ApiProjectSteps
{
    protected ProjectService ProjectService;

    public ApiProjectSteps(ProjectService projectService)
    {
        ProjectService = projectService;
    }

    public ApiProjectModel GetProjectById(int id)
    {
        var response = ProjectService.GetProjectById(id);
        Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.IsNotNull(response.Content);
        return JsonConvert.DeserializeObject<ApiProjectModel>(response.Content);
    }
    
    public ApiProjectsModel GetProjects()
    {
        var response = ProjectService.GetProjects();
        Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.IsNotNull(response.Content);
        return JsonConvert.DeserializeObject<ApiProjectsModel>(response.Content);
    }

    public ApiProjectModel CreateProject(ApiProjectModel apiProjectModel)
    {
        var response = ProjectService.CreateProject(apiProjectModel);
        Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.IsNotNull(response.Content);
        return JsonConvert.DeserializeObject<ApiProjectModel>(response.Content);
    }
    
    

}
