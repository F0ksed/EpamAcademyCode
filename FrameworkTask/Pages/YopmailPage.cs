using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    internal class YopmailPage
    {
        IWebDriver driver;
        WebDriverWait wait;
        private string url = "https://yopmail.com";

        public YopmailPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(5));
        }

        private YopmailPageMap Map
        {
            get
            {
                return new YopmailPageMap(this.driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
            if (Map.AcceptNecesaryCookiesButton.Displayed)
            {
                Map.AcceptNecesaryCookiesButton.Click();
            }
        }

        public void CreateNewMailbox()
        {
            Map.CreateRandomAddressButton.Click();
            wait.Until(ExpectedConditions.ElementExists(Map.CheckMailButton));
            if (Map.AcceptNecesaryCookiesButton.Displayed)
            {
                Map.AcceptNecesaryCookiesButton.Click();
            }

            driver.FindElement(Map.CheckMailButton).Click();
            wait.Until(ExpectedConditions.ElementExists(Map.CurrentMailboxAddress));
        }

        public string GetMailAddress()
        {
            return driver.FindElement(Map.CurrentMailboxAddress).Text;
        }
    }
}
