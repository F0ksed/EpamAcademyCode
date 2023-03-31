using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.LoginPage
{
    internal class ProtonLoginPage
    {
        protected readonly IWebDriver driver;
        protected readonly string url = "https://account.proton.me/login";
        WebDriverWait wait;

        public ProtonLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(60));
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
