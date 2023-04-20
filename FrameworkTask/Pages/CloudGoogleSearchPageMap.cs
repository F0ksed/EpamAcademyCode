using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    public class CloudGoogleSearchPageMap: CloudGoogleBasePageMap
    {
        public CloudGoogleSearchPageMap(IWebDriver driver): base(driver) { }

        public IWebElement SearchResult(string headline)
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(
                $"//div[@class = 'gs-title']/a[child::*[contains(., '{headline}')]]")));
            return driver.FindElement(By.XPath(
                $"//div[@class = 'gs-title']/a[child::*[contains(., '{headline}')]]"));
        }
    }
}
