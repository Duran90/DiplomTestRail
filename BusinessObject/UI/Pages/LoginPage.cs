
using BusinessObject.Models;
using Core.Configuration;
using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class LoginPage : BasePage
{
    private readonly By _usernameField = By.XPath(".//input[@name='name']");
    private readonly By _passwordField = By.XPath(".//input[@name='password']");
    private readonly By _loginButton = By.CssSelector("#button_primary");
    private readonly By _errorLoginMessage = By.CssSelector(".error-on-top");
    private readonly By _errorLoginDescription = By.CssSelector(".error-text");
    private readonly By _errorEmailValidation = By.CssSelector("div.loginpage-message-image.loginpage-message");

    public override string Url => $"{AppConfiguration.Browser.BaseUrl}/index.php?/auth/login/";
    
    [AllureStep("Open Login page")]
    public override LoginPage Open() => (LoginPage) base.Open();
    public override LoginPage Refresh() => (LoginPage) base.Refresh();

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public MainPage Login(UserModel user)
    {
        Logger.Info($"Login as \"{user.Username}\"");

        EnterText(_usernameField, user.Username);
        EnterText(_passwordField, user.Password);
        ClickElement(_loginButton);
        return new MainPage(Driver);
    }

    public ErrorMessageModel GetLoginErrorMessage()
    {
        WaitingHelper.WaitElementUntilIsDisplay(driver: Driver, _errorLoginDescription);
        
        var errTitle = GetElementText(_errorLoginMessage).Trim();
        var errText = GetElementText(_errorLoginDescription).Trim();

        return new ErrorMessageModel(errTitle, errText);
    }

    public string GetEmailValidationError()
    {
        WaitingHelper.WaitElementUntilIsDisplay(driver: Driver, _errorEmailValidation);
        return GetElementText(_errorEmailValidation);
    }
}