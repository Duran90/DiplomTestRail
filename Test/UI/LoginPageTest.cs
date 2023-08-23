using Allure.Commons;
using BusinessObject.Builders;
using BusinessObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UI;

public class LoginPageTest : BaseTest
{
    private const string ExpectedLogInErrorMessage = "Sorry, there was a problem.";
    private const string ExpectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";
    private const string ExpectedValidationErrorMessage = "Email/Login is required.";

    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Login")]
    [AllureSubSuite("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    public void LoginPositive()
    {
        var user = UserBuilder.GetTestRailUser();
        var loginPage = new LoginPage(Browser.Instance.Driver);
        var mainPage = loginPage.Open().Login(user);
        
        WaitingHelper.WaitUntilUrlToBe(Browser.Instance.Driver, mainPage.Url);
        
        Assert.That(Browser.Url, Is.EqualTo(mainPage.Url));
    }

    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Login")]
    [AllureSubSuite("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    public void LoginNegative()
    {
        var user = UserBuilder.GetTestRailFakeUser();
        var loginPage = new LoginPage(Browser.Instance.Driver);
        loginPage.Open().Login(user);
        var errorMessage = loginPage.GetLoginErrorMessage();
        
        Assert.Multiple(() =>
        {
            Assert.That(errorMessage.Title, Is.EqualTo(ExpectedLogInErrorMessage));
            Assert.That(errorMessage.Text, Is.EqualTo(ExpectedLogInErrorDescription));
        });
    }

    [Test]
    [Category("UI")]
    [AllureTag("UI")]
    [AllureOwner("Igor Kardanov")]
    [AllureSuite("Login")]
    [AllureSubSuite("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    public void LoginEmpty()
    {
        var user = UserBuilder.GetTestRailEmptyUser();
        var loginPage = new LoginPage(Browser.Instance.Driver);
        loginPage.Open().Login(user);
        var errorEmailValidation = loginPage.GetEmailValidationError();
        
        Assert.That(errorEmailValidation, Is.EqualTo(ExpectedValidationErrorMessage));
    }
}