using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.GMail.LoginPage
{
    internal class GmailLoginPageValidator
    {
        protected readonly IWebDriver driver;
        WebDriverWait wait;

        public GmailLoginPageValidator(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(15));
        }

        public void ValidateLoginSuccess(string expectedUrl)
        {
            wait.Until(ExpectedConditions.UrlContains(expectedUrl));
            Assert.Contains(expectedUrl, driver.Url);
        }
    }
}
