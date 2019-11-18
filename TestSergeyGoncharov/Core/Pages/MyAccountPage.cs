using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSergeyGoncharov.Core.Pages
{
    class MyAccountPage : PageObject
    {
        public MyAccountPage(IWebDriver driver) : base(driver) { }
        public MyAccountPage WaitUntilPageIsLoaded()
        {
            Wait.Until(ExpectedConditions.UrlContains("https://myaccount.google.com/"));
            return this;
        }
    }
}
