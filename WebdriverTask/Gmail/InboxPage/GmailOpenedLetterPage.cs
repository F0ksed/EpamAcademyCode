using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebdriverTask.Gmail.InboxPage;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.GMail.InboxPage
{
    internal class GmailOpenedLetterPage
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;
        string messageSentText = "Message sent";

        public GmailOpenedLetterPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public GmailOpenedLetterPageValidator Validator
        {
            get
            {
                return new GmailOpenedLetterPageValidator(this.driver);
            }
        }

        protected GmailOpenedLetterPageMap Map
        {
            get
            {
                return new GmailOpenedLetterPageMap(this.driver);
            }
        }

        public void Reply(string body)
        {
            Map.FooterReplyButton().Click();
            Map.ReplyMessageBody().SendKeys(body);
            Map.SendButton().Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text() = '{messageSentText}']")));
        }
    }
}
