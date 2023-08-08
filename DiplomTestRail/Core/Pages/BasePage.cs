﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomTestRail.Core.PageObject;
using OpenQA.Selenium;

namespace DiplomTestRail.Core.Pages
{
    public abstract class BasePage : AbsPageObject
    {
        public const string BaseUrl = "https://gagaha2808.testrail.io/index.php?/auth/login/LWZhMDA0NWExYzgyM2UyNWUzMDVjMjE3ZmRjNzU1ZWEzMjJkOTZmNWY1MWEwODk0MDNjZDJhN2E1NTQ2YTEzM2Y:"; //TODO
        private Header _header;
        public BasePage(IWebDriver driver) : base(driver)
        {
            this._header = new Header(driver);
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        public Header GetHeader()
        {
            return _header;
        }
    }
}
