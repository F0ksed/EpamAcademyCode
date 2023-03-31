using OpenQA.Selenium;

namespace WebdriverTask.Gmail.InboxPage
{
    internal class GmailMailListPageMap: GmailInboxPageMap
    {
        public GmailMailListPageMap(IWebDriver driver) : base(driver) { }

        public IEnumerable<IWebElement> AllMail
        {
            get
            {
                return driver.FindElements(By.XPath("//*[@email]/ancestor::tr"));
            }
        }

        public string MailSender(IWebElement mail)
        {
            return mail.FindElement(By.XPath(".//descendant::span[@email]")).GetAttribute("email");
        }

        public string MailSubject(IWebElement mail)
        {
            return mail.FindElement(By.XPath("./td[5]/div/div/div/span/span")).Text;
        }

        public bool IsUnread(IWebElement mail)
        {
            return mail.FindElements(By.XPath("./descendant::text()[contains(., 'unread')]/..")).Count() > 0;
        }
    }
}
