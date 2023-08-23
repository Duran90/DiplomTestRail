using BusinessObject.Models;
using Core.API;
using Core.Configuration;
using NLog;
using RestSharp;

namespace BusinessObject.API.Services;

public class ProjectService : BaseService
{
    
    public string GetProjectByIdEndpoint = "/index.php?/api/v2/get_project/{projectId}";
    public string GetProjectsEndpoint = "/index.php?/api/v2/get_projects";
    public string AddProjectEndpoint = "/index.php?/api/v2/add_project";
    public string UpdateProjectByIdEndpoint = "/index.php?/api/v2/update_project/{projectId}";
    public string DeleteProjectByIdEndpoint = "/index.php?/api/v2/delete_project/{projectId}";
    
    public ProjectService(BaseApiClient apiClient) : base(apiClient)
    {
    }
    
    public RestResponse GetProject(int id) 
    {
        var request = new RestRequest(GetProjectByIdEndpoint).AddUrlSegment("projectId", id);
        
        Logger.Info("Project ID = " + id);
        
        return ApiClient.Execute(request);
    }

    public RestResponse GetProjects()
    {
        var request = new RestRequest(GetProjectsEndpoint);
        return ApiClient.Execute(request);
    }

    public RestResponse CreateProject(ProjectModel projectModel)
    {
        var request = new RestRequest(AddProjectEndpoint, Method.Post);
        request.AddBody(projectModel);
        
        Logger.Info("Project " + projectModel.Name + " was created");
        return ApiClient.Execute(request);
    }
    
    public RestResponse UpdateProject()
    {
        var request = new RestRequest(UpdateProjectByIdEndpoint);
        return ApiClient.Execute(request);
    }
    
    public RestResponse DeleteProject(int id)
    {
        var request = new RestRequest(DeleteProjectByIdEndpoint, Method.Post).AddUrlSegment("projectId",id);
        Logger.Info("Project whis" + id + " has been deleted");
        return ApiClient.Execute(request);
    }
    
}