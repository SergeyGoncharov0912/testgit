using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestSergeyGoncharov.Core;

namespace TestSergeyGoncharov
{
    public class LoginPage : PageObject
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public By EmailFieldLocator => By.XPath("//input[@type='email']");
        public By PasswordFieldLocator => By.XPath("//div[@role='presentation']//input[@type='password']");
        public By NextButtonLocator => By.XPath("//span[@class='RveJvd snByac']");
        public LoginPage GoToLoginPage()
        {
            _driver.Navigate().GoToUrl(URLs.LoginPage);
            return this;
        }
         public void SuccessLogIn(string email, string password)
        {
            GoToLoginPage();
            TypeEmail(email);
            ClickOnNextButton();
            TypePassword(password);
            ClickOnNextButton();
        }

        public LoginPage TypePassword(string password)
        {
            PasswordFieldLocator.ClearAndSendKey(password, _driver);
            return this;
        }

        public LoginPage TypeEmail(string email)
        {
            EmailFieldLocator.ClearAndSendKey(email, _driver);
            return this;
        }

        public LoginPage ClickOnNextButton()
        {
            NextButtonLocator.WaitAndClick(_driver);
            return this;
        }
    }
}