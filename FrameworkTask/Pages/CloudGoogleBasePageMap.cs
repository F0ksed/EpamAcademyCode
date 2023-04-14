using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkTask.Pages
{
    internal class CloudGoogleBasePageMap
    {
        internal protected IWebDriver driver;
        internal WebDriverWait wait;
        By searchBar = By.XPath("//input[@*[contains(., 'search-field')]]");

        public CloudGoogleBasePageMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement SearchBar => driver.FindElement(searchBar);
    }
}
