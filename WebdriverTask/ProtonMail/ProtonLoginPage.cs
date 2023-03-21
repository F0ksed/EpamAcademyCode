using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonLoginPage
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://account.proton.me/login";

        public ProtonLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ProtonLoginPageValidator Validator
        {
            get
            {
                return new ProtonLoginPageValidator(driver);
            }
        }

        protected ProtonLoginPageMap Map
        {
            get
            {
                return new ProtonLoginPageMap(driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string address, string password)
        {
            Map.InputEmailField.Clear();
            Map.InputPasswordField.Clear();
            Map.InputEmailField.SendKeys(address);
            Map.InputPasswordField.SendKeys(password);
            Map.SubmitButton.Click();
        }
    }
}
