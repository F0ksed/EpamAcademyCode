using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonLoginPageMap
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        public ProtonLoginPageMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement InputEmailField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'username']")));
                return driver.FindElement(By.XPath("//input[@id = 'username']"));
            }
        }

        public IWebElement InputPasswordField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'password']")));
                return driver.FindElement(By.XPath("//input[@id = 'password']"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@type= 'submit']"));
            }
        }
    }
}
