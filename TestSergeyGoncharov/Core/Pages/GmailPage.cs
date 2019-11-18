using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestSergeyGoncharov.Core;

namespace TestSergeyGoncharov
{
    public class GmailPage : PageObject
    {
        public GmailPage(IWebDriver driver) : base(driver) { }
        public By DraftsItemLocator => By.XPath("//div[@class='wT']//div[@class='TN bzz aHS-bnq']");
        public By ComposeButtonLocator => By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']");
        public GmailPage GoToGmailPage()
        {
            _driver.Navigate().GoToUrl(URLs.GmailPage);
            return this;
        }

        public GmailPage ClickOnDraftsItem()
        {
            try
            {
                DraftsItemLocator.WaitAndClick(_driver);
            }
            catch 
            {
                DraftsItemLocator.WaitAndClick(_driver);
            }
            return this;
        }

        public GmailPage ClickComposeButton()
        {
            var ComposeButton = _driver.FindElement(ComposeButtonLocator);
            ComposeButton.Click();
            return this;
        }
    }
}