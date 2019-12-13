using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumExample.PageModels
{
    class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AccountButton
        {
            get
            {
                return _driver.FindElements(By.Id("dropdownCurrency"))[1];
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return _driver.FindElement(By.LinkText("Logout"));
            }
        }

        public IWebElement MyProfileLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//ul/li/a[@href='#profile']"));
            }
        }
    }
}
