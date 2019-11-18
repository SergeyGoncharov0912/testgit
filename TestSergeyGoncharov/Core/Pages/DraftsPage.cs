using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestSergeyGoncharov.Core;

namespace TestSergeyGoncharov
{
    public class LoginPage : PageObject
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public IWebElement EmailField => _driver.FindElement(By.XPath("//input[@type='email']"));
        public IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@type='password']"));
        public IWebElement NextButton => _driver.FindElement(By.XPath("//span[@class='RveJvd snByac']"));
        public LoginPage GoToLoginPage()
        {
            _driver.Navigate().GoToUrl(URLs.LoginPage);
            return this;
        }

        public LoginPage TypePassword(string password)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='password']")));
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            return this;
        }

        public LoginPage TypeEmail(string email)
        {
            EmailField.Clear();
            EmailField.SendKeys(email);
            return this;
        }

        public LoginPage ClickOnNextButton()
        {
            NextButton.Click();
            return this;
        }
    }
}