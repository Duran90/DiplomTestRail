using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.Helers;
using DiplomTestRail.Core.Pages;
using DiplomTestRail.Core.Selenium.WebDriverFactory;
using OpenQA.Selenium;

namespace DiplomTestRail.Tests.UiTest
{
    public class ProjectTests : BaseTest
    {
        

        protected string expectedAddProjectErrorMessage = "Field Name is a required field.";

        protected string email = TestContext.Parameters.Get("Email");
        protected string password = TestContext.Parameters.Get("Password");

        protected string projectTestName = "TestProject";

        private MainPage mainPage;

            [SetUp]
        public void SetUp()
        {
            base.Setup();
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.Open();
            loginPage.Login(email,password);
            this.mainPage = new MainPage(browser.Driver);
        }


        [Test]
        public void CreateProjectEmptyNameTest()
        {
            mainPage.ClickAddProject();
            CreateProjectPage cp = new CreateProjectPage(browser.Driver);
            cp.AddButton.Submit();
            Assert.AreEqual(expectedAddProjectErrorMessage, cp.GetErrorMessage());

        }
        [Test]
        public void CreateProjectTest()
        {
            mainPage.ClickAddProject();
            CreateProjectPage cp = new CreateProjectPage(browser.Driver);
            cp.Name.clearText();
            cp.Name.setText(projectTestName);
            cp.AddButton.Submit();
            ProjectsPage pp = new ProjectsPage(browser.Driver);
            Assert.NotNull(pp.GetPageProjectComponent(projectTestName));
            Assert.AreEqual(projectTestName, pp.GetPageProjectComponent(projectTestName).getName());
            pp.DeleteProject(projectTestName);
            Assert.IsNull(pp.GetPageProjectComponent(projectTestName));
        }

    

    }
}
