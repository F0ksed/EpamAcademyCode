using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.InboxPage
{
    internal class ProtonInboxPage
    {
        protected readonly IWebDriver driver;
        WebDriverWait wait;
        IWebElement selectedMail;
        protected readonly string url = "https://mail.proton.me/u/0/inbox";
        private string messageSentText = "Message sent.";

        public ProtonInboxPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public ProtonInboxPageValidator Validator
        {
            get
            {
                return new ProtonInboxPageValidator(driver);
            }
        }

        protected ProtonInboxPageMap Map
        {
            get
            {
                return new ProtonInboxPageMap(driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void SendMail(string address, string subject, string body)
        {
            Map.NewMessageButton.Click();
            Map.ComposeMessageAdressToField.SendKeys(address);
            Map.ComposeMessageSubjectField.SendKeys(subject);
            driver.SwitchTo().Frame(0); //there's only one frame and it belongs to the mail body. Unable to locate it through other means.
            Map.ComposeMessageBody.Clear();
            Map.ComposeMessageBody.SendKeys(body);
            driver.SwitchTo().DefaultContent();
            Map.ComposeMessageSendMailButton.Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text() = '{messageSentText}']")));
        }

        public void SelectMail(string sender, string subject)
        {
            foreach (var item in Map.AllMail)
            {
                if (Map.MailSender(item).ToLower().Contains(sender.ToLower()) &&
                    Map.MailSubject(item) == subject)
                {
                    selectedMail = item;
                    break;
                }
            }
        }

        public void OpenSelectedMail()
        {
            selectedMail.Click();
        }
    }
}
