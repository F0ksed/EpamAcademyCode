using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.Gmail.InboxPage
{
    internal abstract class GmailInboxPageMap
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public GmailInboxPageMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement ComposeButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role = 'navigation']/div[1]//div[@role = 'button']")));
                return driver.FindElement(By.XPath("//div[@role = 'navigation']/div[1]//div[@role = 'button']"));
            }
        }

        public IWebElement InboxButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role = 'navigation']//div[@class = 'aim ain']")));
                return driver.FindElement(By.XPath("//div[@role = 'navigation']//div[@class = 'aim ain']"));
            }
        }
    }
}
