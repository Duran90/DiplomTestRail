using BusinessObject.Models;
using Core.Configuration;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class ProjectAddPage : ProjectPage
{
    public override string Url => $"{AppConfiguration.Browser.BaseUrl}/index.php?/admin/projects/add/1";

    private readonly By _errorMessageLocator = By.CssSelector("#content-inner>div.message.message-error");

    private BaseElement ErrorMessage => new(Driver, _errorMessageLocator);
    public ProjectAddPage(IWebDriver driver) : base(driver)
    {
    }

    public override ProjectAddPage Open() => (ProjectAddPage)base.Open();
    
    public override ProjectAddPage Refresh() => (ProjectAddPage)base.Refresh();

    public ProjectsPage CreateProject(ProjectModel project)
    {
        Logger.Info($"create project {project.Name}");
        
        ProjectNameInput.TypeText(project.Name ?? "");
        ProjectAnnouncementInput.TypeText(project.Announcement ?? "");
        if (project.ShowAnnouncement) ProjectShowAnnouncementCheckbox.Toggle();
        return Submit();
    }
    
    public string GetErrorMessage()
    {
        WaitingHelper.WaitElement(Driver, _errorMessageLocator);
        
        Logger.Debug(_errorMessageLocator);
        
        return ErrorMessage.GetElementText();
    }
}