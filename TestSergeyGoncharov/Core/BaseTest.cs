using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TestSergeyGoncharov.Core
{
    public class BaseTest
    {
        private IWebDriver _driver;
        public IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }
                if (_driver == null)
                {
                    _driver = GetChromeDriver();
                    return _driver;
                }
                return _driver;
            }
        }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
        [SetUp]
        public void SetUp()
        {
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
