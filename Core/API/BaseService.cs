namespace Core.API;

public class BaseService
{
    protected readonly BaseApiClient ApiClient;


    public BaseService(BaseApiClient apiClient)
    {
        ApiClient = apiClient;
    }
}