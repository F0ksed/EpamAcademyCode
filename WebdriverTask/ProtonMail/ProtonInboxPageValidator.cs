using OpenQA.Selenium;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonInboxPageValidator
    {
        private readonly IWebDriver driver;

        public ProtonInboxPageValidator(IWebDriver driver)
        {
            this.driver = driver;
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
            
            foreach (IWebElement item in Map.AllMail)
            {
                if (Map.MailSender(item) == sender && Map.MailTopic(item) == subject && Map.IsUnread(item))
                {
                    fittingMail.Add(item);
                }
            }

            Assert.Single(fittingMail);
        }

    }
}
