using Core.Models;
using Newtonsoft.Json;

namespace BusinessObject.Models;

public class ProjectsModel : BaseApiPagingResponse
{
    
    public List<ProjectModel> Projects { get; set; }
    
}