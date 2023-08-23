
using BusinessObject.Models;
using Core.Configuration;
using Core.Selenium;
using Core.Selenium.Elements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class LoginPage : BasePage
{
    private readonly By _usernameFieldLocator = By.XPath(".//input[@name='name']");
    private readonly By _passwordFieldLocator = By.XPath(".//input[@name='password']");
    private readonly By _loginButtonLocator = By.CssSelector("#button_primary");
    private Input UsernameField => new (Driver, _usernameFieldLocator);
    private Input PasswordField => new (Driver, _passwordFieldLocator);
    private Button LoginButton =>new (Driver, _loginButtonLocator);
    
    
    private readonly By _errorLoginMessageLocator = By.CssSelector(".error-on-top");
    private readonly By _errorLoginDescriptionLocator = By.CssSelector(".error-text");
    private readonly By _errorEmailValidationLocator = By.CssSelector("div.loginpage-message-image.loginpage-message");
    
    private BaseElement ErrorLoginMessage => new(Driver, _errorLoginMessageLocator);
    private BaseElement ErrorLoginDescription => new (Driver, _errorLoginDescriptionLocator);
    private BaseElement ErrorEmailValidation => new(Driver ,_errorEmailValidationLocator);

    public override string Url => $"{AppConfiguration.Browser.BaseUrl}/index.php?/auth/login/";
    
    [AllureStep("Open Login page")]
    public override LoginPage Open() => (LoginPage) base.Open();
    public override LoginPage Refresh() => (LoginPage) base.Refresh();

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public MainPage Login(UserModel user)
    {
        
        UsernameField.TypeText(user.Username);
        Logger.Info($"Login as \"{user.Username}\"");
        
        PasswordField.TypeText(user.Password);
        Logger.Info($"Login as \"{user.Password}\"");
        
        LoginButton.ClickElement();
        return new MainPage(Driver);
    }

    public ErrorMessageModel GetLoginErrorMessage()
    {
        WaitingHelper.WaitElementUntilIsDisplay(driver: Driver, _errorLoginDescriptionLocator);
        
        Logger.Debug(_errorLoginDescriptionLocator);
        
        var errTitle = ErrorLoginMessage.GetElementText().Trim();
        var errText = ErrorLoginDescription.GetElementText().Trim();
        return new ErrorMessageModel(errTitle, errText);
    }

    public string GetEmailValidationError()
    {
        WaitingHelper.WaitElementUntilIsDisplay(driver: Driver, _errorEmailValidationLocator);
        
        Logger.Debug(_errorEmailValidationLocator);
        
        return ErrorEmailValidation.GetElementText();
    }
}