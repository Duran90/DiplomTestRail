namespace Core.Models;

public class BaseApiResponse<T>
{
    public bool Status { get; set; }
    public T? Result { get; set; }
}