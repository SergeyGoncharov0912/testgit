using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSergeyGoncharov.Core.Pages
{
    class Header : PageObject
    {
        public Header(IWebDriver driver) : base(driver) { }

        public By AccountLabelLocator => By.XPath("//header[@id='gb']//a[@class='gb_B gb_Da gb_g']");
        public By SignOutLocator => By.XPath("//header[@id='gb']//a[@id='gb_71']");

        public Header ClickOnAccountLabel()
        {
            var accountLabel = _driver.FindElement(AccountLabelLocator);
            accountLabel.Click();
            return this;
        }
        public Header ClickOnSignOut()
        {
            var signOut = _driver.FindElement(SignOutLocator);
            signOut.Click();
            return this;
        }
        public void SignOut()
        {
            ClickOnAccountLabel();
            ClickOnSignOut();
        }
    }
}
