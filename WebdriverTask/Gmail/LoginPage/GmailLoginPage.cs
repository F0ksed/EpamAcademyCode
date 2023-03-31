using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.GMail.LoginPage
{
    internal class GmailLoginPage
    {
        protected readonly IWebDriver driver;
        protected readonly string url = "https://mail.google.com/";
        WebDriverWait wait;

        public GmailLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public GmailLoginPageValidator Validator
        {
            get
            {
                return new GmailLoginPageValidator(driver);
            }
        }

        protected GmailLoginPageMap Map
        {
            get
            {
                return new GmailLoginPageMap(driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string address, string password)
        {
            Map.InputEmailField.Clear();
            Map.InputEmailField.SendKeys(address);
            Map.NextButton.Click();
            Map.InputPasswordField.SendKeys(password);
            Map.NextButton.Click();
        }
    }
}
