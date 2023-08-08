using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Components
{
    public class MainProjectComponent
    {
        private static string _cssTitle = "div.summary-title.text-ppp>a";
        private static string _cssLinks = "div.summary-links.text-secondary>a";


        private IWebElement _title;
        private ICollection<IWebElement> _links;

        public MainProjectComponent(IWebElement title, ICollection<IWebElement> links)
        {
            this._title = title;
            this._links = links;
        }

        public String GetTitle()
        {
            return _title.Text;
        }

        public void ClickLink(string link)
        {
            foreach (IWebElement linkElement in this._links)
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
            _title.Click();
        }

        public static MainProjectComponent Create(IWebElement element)
        {
            IWebElement title = element.FindElement(By.CssSelector(_cssTitle));
            ICollection<IWebElement> links = element.FindElements(By.CssSelector(_cssLinks));
            return new MainProjectComponent(title, links);
        }
    }
}