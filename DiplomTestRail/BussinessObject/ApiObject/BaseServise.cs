using DiplomTestRail.Core.Configuration.ApiConfiguration;

namespace DiplomTestRail.BussinessObject.ApiObject;

public class BaseServise
{
    protected BaseApiClient _apiClient;

    public BaseServise(BaseApiClient apiClient)
    {
        this._apiClient = apiClient;
    }
}