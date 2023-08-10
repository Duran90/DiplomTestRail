namespace DiplomTestRail.Core.Models;

public class CommonResultResponse<T>
{
    public bool Status { get; set; }
    public T Result { get; set; }

}