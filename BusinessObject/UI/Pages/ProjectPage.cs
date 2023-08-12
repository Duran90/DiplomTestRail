using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public abstract class ProjectPage : HeaderPage
{
    protected Input ProjectNameInput => new(Driver, By.Id("name"));
    protected Input ProjectAnnouncementInput =>  new(Driver,By.Id("announcement_display"));
    protected Checkbox ProjectShowAnnouncementCheckbox =>  new(Driver,By.Id("show_announcement"));
    protected Button AcceptButton =>  new (Driver,_acceptButton);
    private readonly By _acceptButton = By.Id("accept");
    protected Button CancelButton =>  new (Driver,_cancelButton);
    private readonly By _cancelButton = By.Id("admin-integration-form-cancel");

    public string ProjectName => ProjectNameInput.GetValue();

    public string ProjectAnnouncement => ProjectAnnouncementInput.GetValue();

    public bool IsShowProjectAnnouncement => ProjectShowAnnouncementCheckbox.Selected();
    
    public override ProjectPage Open() => (ProjectPage)base.Open();
    
    public override ProjectPage Refresh() => (ProjectPage)base.Refresh();

    protected ProjectPage(IWebDriver driver) : base(driver)
    {
    }

    protected bool SubmitEnabled()
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _acceptButton);
        return AcceptButton.Enabled();
    }

    protected ProjectsPage Submit()
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _acceptButton);
        AcceptButton.Click();
        return new ProjectsPage(Driver);
    }
    
    protected ProjectsPage Cancel()
    {
        WaitingHelper.WaitElementUntilIsDisplay(Driver, _cancelButton);
        CancelButton.Click();
        return new ProjectsPage(Driver);
    }
}