using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.LoginPage
{
    internal class ProtonLoginPageValidator
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public ProtonLoginPageValidator(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        protected ProtonLoginPageMap Map
        {
            get
            {
                return new ProtonLoginPageMap(this.driver);
            }
        }

        public void ValidateLoginSuccess(string expectedUrl)
        {
            wait.Until(ExpectedConditions.UrlContains(expectedUrl));
            Assert.Contains(expectedUrl, driver.Url);
        }

        public void ValidateDeniedLogin(string expectedUrl)
        {
            wait.Until(ExpectedConditions.StalenessOf(Map.SubmitButtonBusy));
            Assert.Contains(expectedUrl, driver.Url);
        }

        public void ValidateEmptyNameFieldLoginFailure(string expectedUrl)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(Map.NecessaryFieldAlertName));
            Assert.Contains(expectedUrl, driver.Url);
        }

        public void ValidateEmptyPasswordFieldLoginFailure(string expectedUrl)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(Map.NecessaryFieldAlertPassword));
            Assert.Contains(expectedUrl, driver.Url);
        }
    }
}
