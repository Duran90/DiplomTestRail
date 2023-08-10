using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class ProjectEditPage : ProjectPage
{
    public ProjectEditPage(IWebDriver driver, string url) : base(driver)
    {
        Url = url;
    }

    public override string Url { get; }

    public override ProjectEditPage Open() => (ProjectEditPage)base.Open();

    public override ProjectEditPage Refresh() => (ProjectEditPage)base.Refresh();

    public ProjectEditPage SetProjectName(string name)
    {
        ProjectNameInput.TypeText(name);
        return this;
    }

    public ProjectEditPage SetProjectAnnouncement(string announcement)
    {
        ProjectAnnouncementInput.TypeText(announcement);
        return this;
    }

    public bool IsSaveEnabled => SubmitEnabled();

    public ProjectsPage SaveProject()
    {
        return Submit();
    }

    public ProjectsPage Back()
    {
        return base.Cancel();
    }
}