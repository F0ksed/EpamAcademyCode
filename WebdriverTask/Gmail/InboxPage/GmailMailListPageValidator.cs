using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.Gmail.InboxPage
{
    internal class GmailMailListPageValidator
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public GmailMailListPageValidator(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(60));
        }

        protected GmailMailListPageMap Map
        { 
            get
            {
                return new GmailMailListPageMap(this.driver);
            }
        }

        public void ValidateMailArrival(string sender, string subject)
        {
            List<IWebElement> fittingMail = new();

            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text() = '{subject}']")));
            foreach (var item in Map.AllMail)
            {
                if (Map.MailSender(item).ToLower() == sender.ToLower() &&
                    Map.MailSubject(item) == subject &&
                    Map.IsUnread(item))
                {
                    fittingMail.Add(item);
                }
            }

            Assert.Single(fittingMail);
        }
    }
}
