using OpenQA.Selenium;

namespace WebdriverTask.Gmail.InboxPage
{
    internal class GmailMailListPage
    {
        protected readonly IWebDriver driver;
        IWebElement selectedMail;

        public GmailMailListPage(IWebDriver driver)
        { 
            this.driver = driver;
        }

        public GmailMailListPageValidator Validator
        {
            get
            {
                return new GmailMailListPageValidator(this.driver);
            }
        }

        protected GmailMailListPageMap Map 
        { 
            get 
            {
                return new GmailMailListPageMap(this.driver);
            }
        }

        public void SelectMail(string sender, string subject)
        {
            foreach (var item in Map.AllMail)
            {
                if (Map.MailSender(item).ToLower() == sender.ToLower() &&
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
