using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.GMail
{
    internal class GmailInboxPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        readonly string url = "https://mail.google.com/mail/u/0/#inbox";

        public GmailInboxPage(IWebDriver browser)
        {
            driver = browser;
            wait = new(driver, TimeSpan.FromSeconds(10));
        }
    }
}
