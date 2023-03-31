using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.GMail.LoginPage
{
    internal class GmailLoginPageMap
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public GmailLoginPageMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement InputEmailField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@* = 'email']")));
                return driver.FindElement(By.XPath("//input[@* = 'email']"));
            }
        }

        public IWebElement InputPasswordField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@* = 'password']")));
                return driver.FindElement(By.XPath("//input[@* = 'password']"));
            }
        }

        public IWebElement NextButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[attribute::data-primary-action-label]/div/div[1]//button"));
            }
        }
    }
}
