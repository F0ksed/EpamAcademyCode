using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.InboxPage
{
    internal class ProtonInboxPageValidator
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public ProtonInboxPageValidator(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(60));
        }

        protected ProtonInboxPageMap Map
        {
            get
            {
                return new ProtonInboxPageMap(driver);
            }
        }

        public void ValidateMailArrival(string sender, string subject)
        {
            List<IWebElement> fittingMail = new();

            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text() = '{subject}']")));
            foreach (IWebElement item in Map.AllMail)
            {
                if (Map.MailSender(item).ToLower().Contains(sender.ToLower()) &&
                    Map.MailSubject(item) == subject &&
                    Map.IsUnread(item))
                {
                    fittingMail.Add(item);
                }
            }

            Assert.Single(fittingMail);
        }

        public void ValidateMailContent(string body)
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@data-testid='message-content:body']")));
            driver.SwitchTo().Frame(0);
            Assert.Contains(body, Map.MailBody());
            driver.SwitchTo().DefaultContent();
        }
    }
}
