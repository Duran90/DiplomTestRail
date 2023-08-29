using BusinessObject.Builders;
using BusinessObject.UI.Pages;
using Core.Selenium;
using OpenQA.Selenium;

namespace BusinessObject.UI.Steps;

public static class ProjectsSteps
{
    public static ProjectAddPage OpenProjectsAddPage()
    {
        var mainPage = new LoginPage().Open().Login(UserBuilder.GetTestRailUser());
        WaitingHelper.WaitUntilUrlToBe(Browser.Instance.Driver, mainPage.Url);
        return mainPage.AddProject();
    }

    public static ProjectsPage OpenProjectsPage()
    {
        var mainPage = new LoginPage().Open().Login(UserBuilder.GetTestRailUser());
        WaitingHelper.WaitUntilUrlToBe(Browser.Instance.Driver, mainPage.Url);
        return new ProjectsPage().Open();
    }
}