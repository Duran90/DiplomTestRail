using DiplomTestRail.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Models;

namespace DiplomTestRail.Tests.UiTest
{
    public class LoginPageTests: BaseTest
    {
        protected const string ExpectedUrl = "https://gagaha2808.testrail.io/index.php?/dashboard";
        protected const string ExpectedLogInErrorMessage = "Sorry, there was a problem.";
        protected const string ExpectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";
        


        [Test]
        public void LogInPositive()
        {
            UserModel user = UserBuilder.GetTestRailFakeUser();
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.Open();
            loginPage.Login(user.Email, user.Password);
            Assert.That(browser.Driver.Url.ToString(), Is.EqualTo(ExpectedUrl));
        }

        [Test]
        public void LogInNegative()
        {
            UserModel user = UserBuilder.GetTestRailFakeUser();
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.Open();
            loginPage.Login(user.Email, user.Password);
            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo(ExpectedLogInErrorMessage));
            Assert.That(loginPage.GetErrorDescription(), Is.EqualTo(ExpectedLogInErrorDescription));
        }
    }
}
