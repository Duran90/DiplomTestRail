using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Components
{
    public class ProjectComponent
    {
        private static string cssTitle = "div.summary-title.text-ppp>a";
        private static string cssLinks = "div.summary-links.text-secondary>a";


        private IWebElement title;
        private ICollection<IWebElement> links;
        public ProjectComponent(IWebElement title, ICollection<IWebElement> links)
        {
            this.title = title;
            this.links = links;
        }

        public String GetTitle()
        {
            return title.Text;
        }

        public void ClickLink(string link)
        {
            foreach (IWebElement linkElement in this.links)
            {
                if (linkElement.Text.ToLower().Equals(link.ToLower()))
                {
                    linkElement.Click();
                }
            }
            throw new Exception("no such link");
        }

        public void Click()
        {
            title.Click();
        }

        public static ProjectComponent Create(IWebElement element)
        {
            IWebElement title = element.FindElement(By.CssSelector(cssTitle));
            ICollection<IWebElement> links = element.FindElements(By.CssSelector(cssLinks));
            return new ProjectComponent(title,links);
        }
    }
}
