using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace Core.Selenium.Components;

public abstract class BaseComponent
{
    protected readonly IWebElement Element;
    protected readonly IWebDriver WebDriver;

    protected BaseComponent(IWebElement element, IWebDriver driver)
    {
        Element = element;
        WebDriver = driver;
    }
}