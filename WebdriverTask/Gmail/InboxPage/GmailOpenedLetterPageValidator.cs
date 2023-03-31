using OpenQA.Selenium;

namespace WebdriverTask.Gmail.InboxPage
{
    internal class GmailOpenedLetterPageValidator
    {
        protected readonly IWebDriver driver;

        public GmailOpenedLetterPageValidator(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected GmailOpenedLetterPageMap Map
        {
            get 
            {
                return new GmailOpenedLetterPageMap(this.driver);
            }
        }

        public void ValidateMailContent(string body)
        {
            Assert.Equal(body, Map.MailBody.FindElement(By.XPath(".//*[text()]")).Text);
        }
    }
}
