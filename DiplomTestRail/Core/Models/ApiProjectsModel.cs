using DiplomTestRail.BussinessObject.Models;

namespace DiplomTestRail.Core.Models;

public class ApiProjectsModel
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Size { get; set; }
    public List<ApiProjectModel> Projects { get; set; }
}