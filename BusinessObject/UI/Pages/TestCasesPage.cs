using OpenQA.Selenium;

namespace BusinessObject.UI.Pages;

public class TestCasesPage : HeaderPage
{
    public TestCasesPage(IWebDriver driver, string url) : base(driver)
    {
        Url = url;
    }
    
    public override TestCasesPage Open() => (TestCasesPage)base.Open();
    
    public override TestCasesPage Refresh() => (TestCasesPage)base.Refresh();

    public override string Url { get; }
}