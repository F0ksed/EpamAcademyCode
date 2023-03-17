using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebdriverTask
{
    internal class ProtonInboxPage
    {
        private readonly IWebDriver driver;
        public readonly string url = "https://mail.proton.me/u/0/inbox";

        public ProtonInboxPage(IWebDriver browser)
        {
            driver = browser;
        }

        IWebElement Mailbox
        {
            get
            {
                return driver.FindElement(By.XPath("//div[@data-testid='mailbox']/main/div/div/div/div[2]"));
            }
        }

        IWebElement NewMessageButton
        {
            get
            {//*[@data-testid='navigation-link:inbox']
                return driver.FindElement(By.XPath("//*[@data-testid = 'sidebar:compose']"));
            }
        }

        IWebElement InboxButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@data-testid='navigation-link:inbox']"));
            }
        }

        IWebElement MessageWindow
        {
            get 
            {
                return driver.FindElement(By.XPath("/html/body/div[1]/div[4]"));
            }
        }

        IWebElement ComposeMessageAdressToField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@data-testid = 'composer:to']"));
            }
        }

        IWebElement ComposeMessageSubjectField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@data-testid = 'composer:subject']"));
            }
        }

        IWebElement ComposeMessageBody
        {
            get
            {
                return driver.FindElement(By.Id("rooster-editor"));
            }
        }

        IWebElement ComposeMessageSendMailButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@data-testid = 'composer:send-button']"));
            }
        }

        IEnumerable<IWebElement> UnreadMail
        {
            get 
            {
                return driver.FindElements(By.XPath("//div[@class[contains(., 'unread')]]"));
            }
        }
        IEnumerable<IWebElement> ReadMail
        {
            get 
            {
                return driver.FindElements(By.XPath
                    ("//div[@class[contains(., 'read') and not(contains(., 'unread'))]]"));
            }
        }


        public void SendMail(string adress, string subject, string body)
        {
            NewMessageButton.Click();
            ComposeMessageAdressToField.SendKeys(adress);
            ComposeMessageSubjectField.SendKeys(subject);
            driver.SwitchTo().Frame(0); //there's only one frame and it belongs to the mail body. Unable to locate it through other means.
            ComposeMessageBody.Clear();
            ComposeMessageBody.SendKeys(body);
            driver.SwitchTo().DefaultContent();
            ComposeMessageSendMailButton.Click();
        }

        public IEnumerable<IWebElement> SearchForMail(string sender, string subject, string body, bool unread)
        {
            List<IWebElement> fittingMail = new();
            IEnumerable<IWebElement> mail = UnreadMail;

            if (!unread)
            {
                mail = ReadMail;
            }             
            
            foreach (IWebElement item in mail)
            {
                if (item.FindElement(By.XPath(".//descendant::*[@data-testid= 'message-column:sender-address']")).
                    GetAttribute("title") == sender &&
                    item.FindElement(By.XPath(".//descendant::*[@data-testid= 'message-row:subject']")).
                    GetAttribute("title") == subject)
                {
                    item.Click();
                    if (true)
                    {
                        fittingMail.Add(item);
                    }

                    driver.Navigate().Back();
                }

            }

            return fittingMail;
        }
    }
}
