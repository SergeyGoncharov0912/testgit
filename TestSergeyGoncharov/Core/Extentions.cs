using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestSergeyGoncharov.Core
{
    public static class Extentions
    {
        public static void WaitAndClick(this By locator, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
        public static void ClearAndSendKey(this By locator, string text, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var field = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            field.Clear();
            field.SendKeys(text);
        }
    }
}
