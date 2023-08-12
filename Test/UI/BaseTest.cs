using Allure.Commons;
using Core.Selenium;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Test.UI;

[AllureNUnit]
[Parallelizable(ParallelScope.All)]
public class BaseTest
{
    private AllureLifecycle? _allure;


    [OneTimeSetUp]
    public void SetUp()
    {
        _allure = AllureLifecycle.Instance;
    }

    [TearDown]
    public void TearDown()
    {
        if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
            var bytes = screenshot.AsByteArray;
            _allure!.AddAttachment("Screenshot", "image/png", bytes);
        }

        Browser.Instance.CloseBrowser();
    }
}