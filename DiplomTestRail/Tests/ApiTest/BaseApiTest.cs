
using DiplomTestRail.Core.Configuration.ApiConfiguration;


namespace DiplomTestRail.Tests.ApiTest;

public class BaseApiTest
{
    protected BaseApiClient _apiClient;
    

    [OneTimeSetUp]
    public void Initial()
    {
        _apiClient = new BaseApiClient("https://gagaha2808.testrail.io/");
 
    }
}