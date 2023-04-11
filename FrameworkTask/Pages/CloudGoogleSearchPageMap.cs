using OpenQA.Selenium;

namespace FrameworkTask.Pages
{
    internal class CloudGoogleSearchPageMap: CloudGoogleBasePageMap
    {
        public CloudGoogleSearchPageMap(IWebDriver driver): base(driver) { }

        public IWebElement SearchResult(string headline) => driver.FindElement(By.XPath(
            $"//div[@class = 'gs-title']/a[child::*[contains(., '{headline}')]]"));
    }
}
