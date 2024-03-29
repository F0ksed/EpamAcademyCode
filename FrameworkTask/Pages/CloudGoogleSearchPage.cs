﻿using OpenQA.Selenium;

namespace FrameworkTask.Pages
{
    public class CloudGoogleSearchPage: CloudGoogleBasePage
    {
        protected readonly string url = "https://cloud.google.com/";

        public CloudGoogleSearchPage(IWebDriver driver): base(driver) { }

        new CloudGoogleSearchPageMap Map => new (driver);

        public void Navigate() => driver.Navigate().GoToUrl(url);       
        
        public void ClickSearchResultItem(string item)
        {
            Map.SearchResult(item).Click();
        }
    }
}
