using DiplomTestRail.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomTestRail.Tests.UiTest
{
    public class LoginPageTests: BaseTest
    {
        protected string expectedURL = "https://gagaha2808.testrail.io/index.php?/dashboard";
        protected string expectedLogInErrorMessage = "Sorry, there was a problem.";
        protected string expectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";


        protected string email = TestContext.Parameters.Get("Email");
        protected string password = TestContext.Parameters.Get("Password");


        [Test]
        public void LogInPositive()
        {
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.Open();
            loginPage.Login(email, password);
            Assert.AreEqual(expectedURL, browser.Driver.Url.ToString());
        }

        [Test]
        public void LogInNegative()
        {
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.Open();
            loginPage.Login(email+"2", password);
            Assert.AreEqual(expectedLogInErrorMessage, loginPage.GetErrorMessage());
            Assert.AreEqual(expectedLogInErrorDescription, loginPage.GetErrorDescription());
        }
    }
}
