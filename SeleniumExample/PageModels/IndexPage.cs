using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumExample.PageModels
{
    public class IndexPage
    {
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver)
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

        public IWebElement LoginButton
        {
            get
            {
                return _driver.FindElement(By.LinkText("Login"));
            }
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://www.phptravels.net/index.php");
        }
    }
}
