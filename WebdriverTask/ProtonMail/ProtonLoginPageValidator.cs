using OpenQA.Selenium;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonLoginPageValidator
    {
        private readonly IWebDriver driver;

        public ProtonLoginPageValidator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ValidateLoginSuccess(string expectedUrl)
        {
            Assert.Contains(expectedUrl, driver.Url);
        }
    }
}
