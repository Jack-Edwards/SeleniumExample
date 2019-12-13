using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumExample.PageModels
{
    class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) 
        {
            _driver = driver;
        }

        public IWebElement UsernameTextbox
        {
            get
            {
                return _driver.FindElement(By.Name("username"));
            }
        }

        public IWebElement PasswordTextbox
        {
            get
            {
                return _driver.FindElement(By.Name("password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//button[contains(text(), 'Login')]"));
            }
        }

        public IWebElement ErrorMessage
        {
            get
            {
                return _driver.FindElement(By.XPath("//div[contains(@class, 'resultlogin')]/div[contains(@class, 'alert')]"));
            }
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://www.phptravels.net/login.php");
        }
    }
}