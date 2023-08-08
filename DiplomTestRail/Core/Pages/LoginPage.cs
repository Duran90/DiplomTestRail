using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Selenium.Elements;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public class LoginPage: BasePage
    {
        private const string EmailInputXPath = ".//input[@name='name']";
        private const string PasswordInputXPath = ".//input[@name='password']";
        private const string LoginButtonCss = "#button_primary";
        private const string ErrorLogInMessage = ".error-on-top";
        private const string ErrorLogInDescription = ".error-text";
        public InputElement Name;
        public InputElement Password;
        public ButtonElement LoginButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.Name = new InputElement(driver, EmailInputXPath);
            this.Password = new InputElement(driver, PasswordInputXPath);
            this.LoginButton = new ButtonElement(driver, By.CssSelector(LoginButtonCss));
        }


        public MainPage Login(string username, string password)
        {
            this.Name.clearText();
            this.Name.setText(username);
            this.Password.clearText();
            this.Password.setText(password);
            this.LoginButton.Submit();
            return new MainPage(Driver);
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(By.CssSelector(ErrorLogInMessage)).Text;
        }
        public string GetErrorDescription()
        {
            return Driver.FindElement(By.CssSelector(ErrorLogInDescription)).Text;
           
        }


    }
}
