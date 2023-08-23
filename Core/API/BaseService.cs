using NLog;

namespace Core.API;

public class BaseService
{
    protected readonly BaseApiClient ApiClient;
    protected readonly Logger Logger;

    public BaseService(BaseApiClient apiClient)
    {
        ApiClient = apiClient;
        Logger = LogManager.GetCurrentClassLogger();
    }
}