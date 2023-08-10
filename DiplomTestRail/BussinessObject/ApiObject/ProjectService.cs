using DiplomTestRail.BussinessObject.Models;
using DiplomTestRail.Core.Configuration.ApiConfiguration;
using DiplomTestRail.Core.Models;
using RestSharp;

namespace DiplomTestRail.BussinessObject.ApiObject;

public class ProjectService: BaseServise
{
    public string GetProjectByIdEndpoint = "/index.php?/api/v2/get_project/{projectId}";
    public string GetProjectsEndpoint = "/index.php?/api/v2/get_projects";
    public string AddProjectEndpoint = "index.php?/api/v2/add_project";
    public string UpdateProjectByIdEndpoint = "index.php?/api/v2/update_project/{projectId}";
    public string DeleteProjectByIdEndpoint = "index.php?/api/v2/delete_project/{projectId}";
    public ProjectService(BaseApiClient apiClient) : base(apiClient)
    {
    }

    public RestResponse GetProjectById(int id) 
    {
        var request = new RestRequest(GetProjectByIdEndpoint).AddUrlSegment("projectId", id);
        return _apiClient.Execute(request);
    }

    public RestResponse GetProjects()
    {
        var request = new RestRequest(GetProjectsEndpoint);
        return _apiClient.Execute(request);
    }

    public RestResponse CreateProject(ApiProjectModel projectModel)
    {
        var request = new RestRequest(AddProjectEndpoint, Method.Post);
        request.AddBody(projectModel);
        return _apiClient.Execute(request);
    }
    
    public RestResponse UpdateProject()
    {
        var request = new RestRequest(UpdateProjectByIdEndpoint);
        return _apiClient.Execute(request);
    }
    
    public RestResponse DeleteProject(int id)
    {
        var request = new RestRequest(DeleteProjectByIdEndpoint, Method.Post).AddUrlSegment("projectId",id);
        return _apiClient.Execute(request);
    }
}