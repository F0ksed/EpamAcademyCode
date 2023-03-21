using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonInboxPageMap
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://mail.proton.me/u/0/inbox";
        private readonly WebDriverWait wait;

        public ProtonInboxPageMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(15));
        }

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

        public IWebElement MessageWindow
        {
            get
            {
                return driver.FindElement(By.XPath("/html/body/div[1]/div[4]"));
            }
        }

        public IWebElement ComposeMessageAdressToField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@data-testid = 'composer:to']"));
            }
        }

        public IWebElement ComposeMessageSubjectField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@data-testid = 'composer:subject']"));
            }
        }

        public IWebElement ComposeMessageBody
        {
            get
            {
                return driver.FindElement(By.Id("rooster-editor"));
            }
        }

        public IWebElement ComposeMessageSendMailButton
        {
            get
            {
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
            return mail.FindElement(By.XPath(".//descendant::*[@data-testid= 'message-column:sender-address']")).GetAttribute("title");
        }

        public string MailTopic(IWebElement mail)
        {
            return mail.FindElement(By.XPath(".//descendant::*[@data-testid= 'message-row:subject']")).GetAttribute("title");
        }

        public bool IsUnread(IWebElement mail)
        {
            return mail.FindElements(By.XPath("self::div[@class[contains(., 'unread')]]")).Count() > 0;
        }
    }
}
