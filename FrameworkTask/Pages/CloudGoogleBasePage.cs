using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkTask.Pages
{
    public abstract class CloudGoogleBasePage
    {
        internal IWebDriver driver;
        internal WebDriverWait wait;

        public CloudGoogleBasePage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        internal CloudGoogleBasePageMap Map => new CloudGoogleBasePageMap(this.driver);

        public void Search(string query) 
        {
            Map.SearchBar.Click();
            Map.SearchBar.SendKeys(query);
            Map.SearchBar.Submit();
        }
    }
}
