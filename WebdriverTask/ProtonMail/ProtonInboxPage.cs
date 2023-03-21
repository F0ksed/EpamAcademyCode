using OpenQA.Selenium;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonInboxPage
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://mail.proton.me/u/0/inbox";

        public ProtonInboxPage(IWebDriver browser)
        {
            driver = browser;
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

        public void SendMail(string adress, string subject, string body)
        {
            Map.NewMessageButton.Click();
            Map.ComposeMessageAdressToField.SendKeys(adress);
            Map.ComposeMessageSubjectField.SendKeys(subject);
            driver.SwitchTo().Frame(0); //there's only one frame and it belongs to the mail body. Unable to locate it through other means.
            Map.ComposeMessageBody.Clear();
            Map.ComposeMessageBody.SendKeys(body);
            driver.SwitchTo().DefaultContent();
            Map.ComposeMessageSendMailButton.Click();
        }
    }
}
