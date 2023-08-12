namespace Core.Models;

public class BaseApiPagingResponse
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Size { get; set; }
}