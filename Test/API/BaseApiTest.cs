using Allure.Commons;
using Core.API;
using Core.Configuration;
using NLog;
using NUnit.Allure.Core;

namespace Test.API;

[AllureNUnit]
[Parallelizable(ParallelScope.Fixtures)]
public class BaseApiTest
{
    private AllureLifecycle _allure;
    protected BaseApiClient ApiClient;

    [OneTimeSetUp]
    public void InitApiClient()
    {
        _allure = AllureLifecycle.Instance; 
        ApiClient = new BaseApiClient(AppConfiguration.API.BaseUrl);
    }
}