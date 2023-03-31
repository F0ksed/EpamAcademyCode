using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.InboxPage
{
    internal class ProtonInboxPageMap : ProtonHeaderMap
    {
        protected readonly string url = "https://mail.proton.me/u/0/inbox";

        public ProtonInboxPageMap(IWebDriver driver) : base(driver) { }

        public IWebElement NewMessageButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-testid = 'sidebar:compose']")));
                return driver.FindElement(By.XPath("//*[@data-testid = 'sidebar:compose']"));
            }
        }

        public IWebElement InboxButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-testid='navigation-link:inbox']")));
                return driver.FindElement(By.XPath("//*[@data-testid='navigation-link:inbox']"));
            }
        }

        public IWebElement SentButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-testid='navigation-link:sent']")));
                return driver.FindElement(By.XPath("//*[@data-testid='navigation-link:sent']"));
            }
        }

        public IWebElement ComposeMessageAdressToField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@data-testid = 'composer:to']")));
                return driver.FindElement(By.XPath("//input[@data-testid = 'composer:to']"));
            }
        }

        public IWebElement ComposeMessageSubjectField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@data-testid = 'composer:subject']")));
                return driver.FindElement(By.XPath("//input[@data-testid = 'composer:subject']"));
            }
        }

        public IWebElement ComposeMessageBody
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("rooster-editor")));
                return driver.FindElement(By.Id("rooster-editor"));
            }
        }

        public IWebElement ComposeMessageSendMailButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@data-testid = 'composer:send-button']")));
                return driver.FindElement(By.XPath("//button[@data-testid = 'composer:send-button']"));
            }
        }

        public IEnumerable<IWebElement> AllMail
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class[contains(., 'read')]]")));
                return driver.FindElements(By.XPath("//div[@class[contains(., 'read')]]"));
            }
        }

        public string MailSender(IWebElement mail)
        {
            return mail.FindElement(By.XPath(".//descendant::*[@title][@data-testid[contains(., 'sender-address')]]")).GetAttribute("title");
        }

        public string MailSubject(IWebElement mail)
        {
            return mail.FindElement(By.XPath(".//descendant::*[@title][@data-testid[contains(., 'subject')]]")).GetAttribute("title");
        }

        public bool IsUnread(IWebElement mail)
        {
            return mail.FindElements(By.XPath(".//self::*[@class[contains(., 'unread')]]")).Count() > 0;
        }

        public string MailBody()
        {     
            return driver.FindElement(By.XPath("//*[text()]")).Text;
        }
    }
}
