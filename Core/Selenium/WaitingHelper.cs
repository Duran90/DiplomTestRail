using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Core.Selenium;

public static class WaitingHelper
{
    public static void WaitElement(IWebDriver driver, By by, int time = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by));
    }

    public static void WaitElementUntilIsDisplay(IWebDriver driver, By by, int time = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by).Displayed);
    }

    public static void WaitElementWithTitle(IWebDriver driver, By by, string text, int time = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element =>
            element.FindElement(by).Text.ToLower().Equals(text.ToLower()));
    }

    public static void WaitElements(IWebDriver driver, By by, int count, int time = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElements(by).Count == count);
    }

    public static void WaitUntilUrlToBe(IWebDriver driver, string url, int time = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.UrlToBe(url));
    }

    public static void WaitUntilDocumentIsReady(IWebDriver driver, int time = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(time))
            .Until(webDriver => ((IJavaScriptExecutor)webDriver)
                .ExecuteScript("return document.readyState")
                .Equals("complete"));
    }
}