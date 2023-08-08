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
    public class ProjectTests : BaseTest
    {
        protected const string ExpectedAddProjectErrorMessage = "Field Name is a required field.";

        protected string Email = TestContext.Parameters.Get("Email") ?? throw new InvalidOperationException();
        protected string Password = TestContext.Parameters.Get("Password") ?? throw new InvalidOperationException();

        protected string ProjectTestName = "TestProject";

        private MainPage _mainPage;

            [SetUp]
        public void SetUp()
        {
            base.Setup();
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.Open();
            loginPage.Login(Email,Password);
            this._mainPage = new MainPage(browser.Driver);
        }


        [Test]
        public void CreateProjectEmptyNameTest()
        {
            _mainPage.ClickAddProject();
            CreateProjectPage cp = new CreateProjectPage(browser.Driver);
            cp.AddButton.Submit();
            Assert.That(cp.GetErrorMessage(), Is.EqualTo(ExpectedAddProjectErrorMessage));

        }
        [Test]
        public void CreateProjectTest()
        {
            _mainPage.ClickAddProject();
            CreateProjectPage cp = new CreateProjectPage(browser.Driver);
            cp.Name.clearText();
            cp.Name.setText(ProjectTestName);
            cp.AddButton.Submit();
            ProjectsPage pp = new ProjectsPage(browser.Driver);
            Assert.NotNull(pp.GetPageProjectComponent(ProjectTestName));
            Assert.That(pp.GetPageProjectComponent(ProjectTestName).GetName(), Is.EqualTo(ProjectTestName));
            pp.DeleteProject(ProjectTestName);
            Assert.IsNull(pp.GetPageProjectComponent(ProjectTestName));
        }

    

    }
}
