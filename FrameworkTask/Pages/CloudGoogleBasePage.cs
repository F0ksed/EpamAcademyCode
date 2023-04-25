using FrameworkTask.Driver;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

namespace FrameworkTask.Pages
{
    public abstract class CloudGoogleBasePage
    {      
        internal IWebDriver driver;
        internal WebDriverWait wait;
        internal Logger logger;

        public CloudGoogleBasePage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
            logger = LogManager.GetCurrentClassLogger();
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
