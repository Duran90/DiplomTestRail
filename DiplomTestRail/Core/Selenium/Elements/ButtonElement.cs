using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomTestRail.Core.Selenium.Elements
{
    public class ButtonElement : BaseElement
    {
        public ButtonElement(IWebDriver driver, By locator) : base(driver, locator)
        {
        }
        public ButtonElement(IWebDriver driver, string xpath) : base(driver, xpath)
        {

        }
        
        public void Click()
        {
            GetElement().Click();
            
        }
        public void Submit()
        {
            GetElement().Submit();
        }

    }
}
