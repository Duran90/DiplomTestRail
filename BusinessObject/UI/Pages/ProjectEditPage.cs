using NLog;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class ProjectEditPage : ProjectPage
{
    public ProjectEditPage(string url)
    {
        Url = url;
    }

    public override string Url { get; }

    public override ProjectEditPage Open() => (ProjectEditPage)base.Open();

    public override ProjectEditPage Refresh()
    {
        Logger.Info("Project page was refreshed");
        
        return (ProjectEditPage)base.Refresh() ;
    } 

    public ProjectEditPage SetProjectName(string name)
    {
        ProjectNameInput.TypeText(name);
        
        Logger.Info("Set name " + name);
        return this;
    }

    public ProjectEditPage SetProjectAnnouncement(string announcement)
    {
        ProjectAnnouncementInput.TypeText(announcement);
        
        Logger.Info("Set announcement " + announcement);
        
        return this;
    }

    public bool IsSaveEnabled => SubmitEnabled();

    public ProjectsPage SaveProject()
    {
        Logger.Info("Project was saved");
        return Submit();
    }

    public ProjectsPage Back()
    {
        Logger.Info("Changes have been canceled");
        return base.Cancel();
    }
}