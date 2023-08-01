using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Pages;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Tests.UiTest
{
    public class UiTests : BaseTest
    {
        protected string expectedURL = "https://gagaha2808.testrail.io/index.php?/dashboard";
        protected string expectedLogInErrorMessage = "Sorry, there was a problem.";
        protected string expectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";

        protected string email = TestContext.Parameters.Get("Email");
        protected string password = TestContext.Parameters.Get("Password");
        [Test]
        public void LogInPositive()
        {
            LogIn(email,password);
            Assert.AreEqual(expectedURL,browser.Driver.Url.ToString());
        }

        [Test]
        public void LogInNegative()
        {
            LoginPage lp = LogIn(email+"4", password);
            Assert.AreEqual(expectedLogInErrorMessage,lp.GetErrorMessage());
            Assert.AreEqual(expectedLogInErrorDescription,lp.GetErrorDescription());
        }


        // [Test]
        // public void LogoutTest() { }

        [Test]
       public void MainPageTest()
       {
           LogIn(email,password);
           MainPage mainPage = new MainPage(browser.Driver);
           mainPage.ClickProjectCard("exam");
           mainPage.GetHeader().OpenTestCasesPage();
       }

       public LoginPage LogIn(string email,string password)
       {
           LoginPage loginPage = new LoginPage(browser.Driver);
           Console.WriteLine(email + "  " + password);
           loginPage.Open();
           loginPage.Login(email, password);
           return loginPage;
       }

    }
}
