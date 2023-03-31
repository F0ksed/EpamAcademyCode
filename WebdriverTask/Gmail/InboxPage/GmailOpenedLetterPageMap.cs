using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.Gmail.InboxPage
{
    internal class GmailOpenedLetterPageMap: GmailInboxPageMap
    {
        public GmailOpenedLetterPageMap(IWebDriver driver): base(driver) { }

        public IWebElement MailBody
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-message-id]/div[2]/div[3]")));
                return driver.FindElement(By.XPath("//*[@data-message-id]/div[2]/div[3]"));
            }
        }

        public IWebElement FooterReplyButton()
        {
            return driver.FindElement(By.XPath("//table[@role = 'presentation']//div[span/@role = 'link']/span[1]"));
        }

        public IWebElement ReplyMessageBody()
        {
            return driver.FindElement(By.XPath("//div[@role = 'textbox']"));
        }

        public IWebElement SendButton()
        {
            return driver.FindElement(By.XPath("//div[@role = 'textbox']/ancestor::tr/following-sibling::tr//table//tr/td[1]/div/div[2]/div[1]"));
        }
    }
}
