using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumExample
{
    [TestFixture]
    class PHPTravelsTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetupTest()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors when closing the driver
            }
        }

        [Test]
        public void LoginWithValidDemoCredentials()
        {
            //  Navigate to the index page
            IndexPage index = new IndexPage(_driver);
            index.NavigateTo();

            //  Navigate to the login page
            index.AccountButton.Click();
            index.LoginButton.Click();

            //  Login with valid demo credentials
            LoginPage login = new LoginPage(_driver);
            login.UsernameTextbox.SendKeys("user@phptravels.com");
            login.PasswordTextbox.SendKeys("demouser");
            login.LoginButton.Click();

            //  Verify we are logged in as the demo user
            HomePage home = new HomePage(_driver);
            Assert.AreEqual(home.AccountButton.Text, "DEMO");
            Assert.True(home.MyProfileLink.Displayed);

            //  Logout
            home.AccountButton.Click();
            home.LogoutButton.Click();
        }

        [Test]
        public void LoginWithInvalidDemoCredentials()
        {
            //  Navigate to the index page
            IndexPage index = new IndexPage(_driver);
            index.NavigateTo();

            //  Navigate to the login page
            index.AccountButton.Click();
            index.LoginButton.Click();

            //  Login with invalid demo credentials
            LoginPage login = new LoginPage(_driver);
            login.UsernameTextbox.SendKeys("user@phptravels.com");
            login.PasswordTextbox.SendKeys("badpassword");
            login.LoginButton.Click();

            //  Verify we are not logged in
            Assert.AreEqual(login.ErrorMessage.Text, "Invalid Email or Password");
            Assert.True(login.ErrorMessage.Displayed);
        }
    }
}
